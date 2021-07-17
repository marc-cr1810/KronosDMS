 using KronosDMS.Api.Endpoints;
using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KronosDMS_Client.Forms.Parts
{
    public partial class RecallForm : Window
    {
        private bool NewRecall = false;
        private Recall SelectedRecall = new Recall();

        public RecallForm()
        {
            InitializeComponent();

            ListParts.Columns[3].Width = ListParts.Width - ListParts.Columns[0].Width - ListParts.Columns[1].Width - ListParts.Columns[2].Width - 5;

            this.labelMake.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelModel.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelRecallNumber.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelDescription.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.groupDetails.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelPartNumber.ForeColor = Client.ActiveTheme.Colors.Text.Default;

            this.Tools.BackColor = Client.ActiveTheme.Colors.Foreground;

            this.ListParts.SetReadonly(false, false, true, true);
            this.ListParts.ItemEdited += PartsList_ItemEdited;

            SelectedRecall.Parts = new List<PartQuantityPair>();
        }

        private void PartsList_ItemEdited(ListViewItem item, int index)
        {
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

                SelectedRecall.Parts[index] = new PartQuantityPair(part.Number, SelectedRecall.Parts[index].Quantity);
            }
            else if (index == 1)
            {
                try
                {
                    int qty = int.Parse(item.SubItems[index].Text);
                    if (qty < 1)
                    {
                        ListParts.Items.Remove(item);
                        SelectedRecall.Parts.RemoveAt(index);
                        return;
                    }
                    SelectedRecall.Parts[index] = new PartQuantityPair(SelectedRecall.Parts[index].Number, qty);
                }
                catch
                {
                    item.SubItems[index].Text = "1";
                }
            }
        }

        private void FillDetails(Recall recall)
        {
            if (recall.Number == null)
                return;

            SelectedRecall = recall;

            this.Text = $"Recall | {recall.Number} \"{recall.Description}\" - Editing";

            MakesSearchResponse makes = new MakesSearch("").PerformRequestAsync().Result;
            foreach (KeyValuePair<string, Make> make in makes.Makes)
                boxMakes.Items.Add(make.Value.Name);

            textRecallNumber.Text = recall.Number;
            boxMakes.Text = recall.Make;
            boxModel.Text = recall.Model;
            textDescription.Text = recall.Description;

            ListParts.Items.Clear();

            foreach (PartQuantityPair part in recall.Parts)
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
            SelectedRecall = new Recall();

            textRecallNumber.Text = "";
            boxMakes.Text = "";
            boxModel.Text = "";
            textDescription.Text = "";
            this.boxMakes.Items.Clear();
            this.boxModel.Items.Clear();

            this.Text = $"Recall";

            ListParts.Items.Clear();
        }

        private void buttonRecallSearch_Click(object sender, EventArgs e)
        {
            RecallsSearchForm form = new RecallsSearchForm();
            Client.MainWindow.OpenFormDialog(form);
            FillDetails(form.Result);
            form.Dispose();
        }

        private void buttonRecallSearch_Leave(object sender, EventArgs e)
        {
            if (this.textRecallNumber.Text == "" || this.textRecallNumber.Text == SelectedRecall.Number)
                return;
            RecallsSearchResponse response = new RecallsSearch("", "", this.textRecallNumber.Text, "").PerformRequestAsync().Result;
            if (response.Recalls.Count != 1)
                return;
            FillDetails(response.Recalls.ElementAt(0).Value);
        }

        private void textRecallNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.textRecallNumber.Text == "" || this.textRecallNumber.Text == SelectedRecall.Number)
                    return;
                RecallsSearchResponse response = new RecallsSearch(this.textRecallNumber.Text.ToUpper()).PerformRequestAsync().Result;
                if (response.Recalls.Count != 1)
                {
                    if (MessageBox.Show($"Create new recall \"{this.textRecallNumber.Text.ToUpper()}\"?", "Create new recall?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.Text = $"Recall | {this.textRecallNumber.Text.ToUpper()} - Creating new recall";
                        this.textRecallNumber.Text = this.textRecallNumber.Text.ToUpper();
                        this.NewRecall = true;
                        SelectedRecall.Number = this.textRecallNumber.Text;
                        FillDetails(SelectedRecall);
                        return;
                    }
                    else
                    {
                        RecallsSearchForm form = new RecallsSearchForm(this.textRecallNumber.Text);
                        Client.MainWindow.OpenFormDialog(form);
                        FillDetails(form.Result);
                        form.Dispose();
                    }
                }
                else FillDetails(response.Recalls.ElementAt(0).Value);
            }
            this.NewRecall = false;
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

            SelectedRecall.Parts.Add(new PartQuantityPair(part.Number, 1));
            ListViewItem partItem = ListParts.Items.Add(part.Number);
            partItem.Name = part.Number;
            partItem.SubItems.Add("1");
            partItem.SubItems.Add(part.Make);
            partItem.SubItems.Add(part.Description);

            textPartNumber.Text = "";
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (SelectedRecall.Number is null)
                return;

            SelectedRecall.Number = SelectedRecall.Number.ToUpper();
            SelectedRecall.Make = this.boxMakes.Text;
            SelectedRecall.Model = this.boxModel.Text;
            SelectedRecall.Description = this.textDescription.Text;

            Response response;
            if (NewRecall)
            {
                response = new RecallAdd(SelectedRecall).PerformRequestAsync().Result;
                if (!response.IsSuccess)
                    MessageBox.Show($"Failed to save recall\n{response.RawMessage}");
                return;
            }

            response = new RecallSet(SelectedRecall).PerformRequestAsync().Result;
            if (!response.IsSuccess)
            {
                MessageBox.Show($"Failed to save recall\n{response.RawMessage}");
                return;
            }
            ClearDetails();
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            if (SelectedRecall.Number is null)
                return;
            ClearDetails();
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            if (SelectedRecall.Number is null)
                return;

            Response response = new RecallRemove(SelectedRecall.Number).PerformRequestAsync().Result;
            if (!response.IsSuccess)
            {
                MessageBox.Show($"Failed to delete recall\n{response.RawMessage}");
                return;
            }
            ClearDetails();
        }
    }
}
