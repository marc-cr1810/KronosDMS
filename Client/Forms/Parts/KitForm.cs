using KronosDMS.Api.Endpoints;
using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KronosDMS_Client.Forms.Parts
{
    public partial class KitForm : Window
    {
        private bool NewKit = true;
        private Kit SelectedKit = new Kit();

        public KitForm(Kit kit = new Kit())
        {
            InitializeComponent();

            ListParts.Columns[3].Width = ListParts.Width - ListParts.Columns[0].Width - ListParts.Columns[1].Width - ListParts.Columns[2].Width - 5;

            this.labelMake.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelModel.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelKitNumber.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelDescription.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.groupDetails.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelPartNumber.ForeColor = Client.ActiveTheme.Colors.Text.Default;

            this.Tools.BackColor = Client.ActiveTheme.Colors.Foreground;

            this.ListParts.SetReadonly(false, false, true, true);
            this.ListParts.ItemEdited += PartsList_ItemEdited;

            MakesSearchResponse makes = new MakesSearch("").PerformRequestAsync().Result;
            foreach (KeyValuePair<string, Make> make in makes.Makes)
                boxMakes.Items.Add(make.Value.Name);

            SelectedKit.Parts = new List<PartQuantityPair>();

            if (kit.Number is not null)
                FillDetails(kit);
        }

        private void PartsList_ItemEdited(ListViewItem item, int index)
        {
            int itemIndex = item.Index;
            if (index == 0)
            {
                string partNumber = item.SubItems[index].Text;
                Part part;
                PartsSearchResponse response = new PartsSearch(partNumber.ToUpper()).PerformRequestAsync().Result;
                if (response.Parts.Count != 1)
                {
                    PartsSearchForm form = new PartsSearchForm(partNumber);
                    Client.MainWindow.OpenFormDialog(form);
                    part = form.Result;
                    form.Dispose();
                }
                else
                {
                    part = response.Parts.ElementAt(0).Value;
                }
                item.SubItems[0].Text = part.Number;
                item.SubItems[2].Text = part.Make;
                item.SubItems[3].Text = part.Description;

                SelectedKit.Parts[itemIndex] = new PartQuantityPair(part.Number, SelectedKit.Parts[itemIndex].Quantity);
            }
            else if (index == 1)
            {
                try
                {
                    int qty = int.Parse(item.SubItems[index].Text);
                    if (qty < 1)
                    {
                        ListParts.Items.Remove(item);
                        SelectedKit.Parts.RemoveAt(itemIndex);
                        return;
                    }
                    SelectedKit.Parts[itemIndex] = new PartQuantityPair(SelectedKit.Parts[itemIndex].Number, qty);
                }
                catch
                {
                    item.SubItems[index].Text = "1";
                }
            }
        }

        private void FillDetails(Kit kit)
        {
            if (kit.Number == null)
                return;
            NewKit = false;

            if (kit.Parts == null)
                kit.Parts = new List<PartQuantityPair>();

            SelectedKit = kit;

            this.Text = $"Kit | {kit.Number} \"{kit.Description}\" - Editing";

            textKitNumber.Text = kit.Number;
            boxMakes.Text = kit.Make;
            boxModel.Text = kit.Model;
            textDescription.Text = kit.Description;

            ListParts.Items.Clear();
            foreach (PartQuantityPair part in kit.Parts)
            {
                PartsSearchResponse response = new PartsSearch("", part.Number, "").PerformRequestAsync().Result;
                Part p = response.Parts.ElementAt(0).Value;
                ListViewItem partItem = ListParts.Items.Add(part.Number);
                partItem.Name = p.Number;
                partItem.SubItems.Add(part.Quantity.ToString());
                partItem.SubItems.Add(p.Make);
                partItem.SubItems.Add(p.Description);
            };

            ListParts.Columns[3].Width = ListParts.Width - ListParts.Columns[0].Width - ListParts.Columns[1].Width - ListParts.Columns[2].Width - 5;
        }

        private void ClearDetails()
        {
            SelectedKit = new Kit();
            NewKit = true;

            textKitNumber.Text = "";
            boxMakes.Text = "";
            boxModel.Text = "";
            textDescription.Text = "";

            this.Text = $"Kit";

            ListParts.Items.Clear();
        }

        private void SearchKit()
        {
            if (this.textKitNumber.Text == SelectedKit.Number)
                return;
            if (this.textKitNumber.Text != "")
            {
                KitsSearchForm form = new KitsSearchForm(this.textKitNumber.Text);
                Client.MainWindow.OpenFormDialog(form);
                FillDetails(form.Result);
                form.Dispose();
                return;
            }

            KitsSearchResponse response = new KitsSearch(this.textKitNumber.Text.ToUpper()).PerformRequestAsync().Result;
            if (response.Kits.Count != 1)
            {
                if (MessageBox.Show($"Create new kit?", "Create new kit?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Text = $"Kit | Creating new kit";
                    this.NewKit = true;
                    SelectedKit.Number = this.textKitNumber.Text;
                    return;
                }
            }
            else FillDetails(response.Kits.ElementAt(0).Value);
        }

        private void buttonKitSearch_Click(object sender, EventArgs e)
        {
            KitsSearchForm form = new KitsSearchForm();
            Client.MainWindow.OpenFormDialog(form);
            FillDetails(form.Result);
            form.Dispose();
        }

        private void buttonKitSearch_Leave(object sender, EventArgs e)
        {
            SearchKit();
        }

        private void textKitNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchKit();
            }
            this.NewKit = false;
        }

        private void boxMakes_TextUpdate(object sender, EventArgs e)
        {
            this.boxModel.Items.Clear();

            if (this.boxMakes.Text == "")
                return;

            MakesSearchResponse response = new MakesSearch(this.boxMakes.Text).PerformRequestAsync().Result;
            if (response.Makes.Count > 0)
            {
                foreach (string model in response.Makes[this.boxMakes.Text].Models)
                {
                    this.boxModel.Items.Add(model);
                }
            }
        }

        private void ListParts_Resize(object sender, EventArgs e)
        {
            ListParts.Columns[3].Width = ListParts.Width - ListParts.Columns[0].Width - ListParts.Columns[1].Width - ListParts.Columns[2].Width - 5;
        }

        private void ListParts_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenu.Show();
        }

        private void ButtonPartAdd_Click(object sender, EventArgs e)
        {
            PartsSearchResponse response = new PartsSearch(textPartNumber.Text).PerformRequestAsync().Result;
            Part part;
            if (response.Parts.Count != 1)
            {
                PartsSearchForm form = new PartsSearchForm(textPartNumber.Text);
                Client.MainWindow.OpenFormDialog(form);
                part = form.Result;
                form.Dispose();
            }
            else
            {
                part = response.Parts.ElementAt(0).Value;
            }

            SelectedKit.Parts.Add(new PartQuantityPair(part.Number, 1));
            ListViewItem partItem = ListParts.Items.Add(part.Number);
            partItem.Name = part.Number;
            partItem.SubItems.Add("1");
            partItem.SubItems.Add(part.Make);
            partItem.SubItems.Add(part.Description);

            textPartNumber.Text = "";
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (SelectedKit.Number is null && NewKit == false)
                return;

            SelectedKit.Make = this.boxMakes.Text;
            SelectedKit.Model = this.boxModel.Text;
            SelectedKit.Description = this.textDescription.Text;

            Response response;
            if (NewKit)
            {
                response = new KitAdd(SelectedKit).PerformRequestAsync().Result;
                if (!response.IsSuccess)
                {
                    MessageBox.Show($"Failed to save kit\n{response.RawMessage}");
                    return;
                }
            }
            else
            {
                response = new KitSet(SelectedKit).PerformRequestAsync().Result;
                if (!response.IsSuccess)
                {
                    MessageBox.Show($"Failed to save kit\n{response.RawMessage}");
                    return;
                }
            }
            ClearDetails();
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            if (SelectedKit.Number is null)
                return;
            ClearDetails();
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            if (SelectedKit.Number is null)
                return;

            Response response = new KitRemove(SelectedKit.Number).PerformRequestAsync().Result;
            if (!response.IsSuccess)
            {
                MessageBox.Show($"Failed to delete kit\n{response.RawMessage}");
                return;
            }
            ClearDetails();
        }
    }
}
