using KronosDMS.Api.Endpoints;
using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using KronosDMS.Utils;
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

            this.Text = $"Kit | {kit.Number} \"{kit.Description}\"{(kit.Locked ? "" : "- Editing")}";

            textKitNumber.Text = kit.Number;
            boxMakes.Text = kit.Make;
            boxModel.Text = kit.Model;
            textDescription.Text = kit.Description;

            if (SelectedKit.Locked)
            {
                LockUnlockButton.Image = Properties.Resources.locked_icon;
                this.ListParts.SetReadonly(true, true, true, true);
            }
            else
            {
                LockUnlockButton.Image = Properties.Resources.unlocked_icon;
                this.ListParts.SetReadonly(false, false, true, true);
            }

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

            this.boxMakes.SelectedItem = null;
            this.boxModel.SelectedItem = null;

            this.Text = $"Kit";

            LockUnlockButton.Image = Properties.Resources.unlocked_icon;

            ListParts.Items.Clear();
        }

        private void SearchForKit(string number)
        {
            KitsSearchForm form = new KitsSearchForm(number);
            Client.MainWindow.OpenFormDialog(form);
            FillDetails(form.Result);
            form.Dispose();
            return;
        }

        private void SearchKit()
        {
            if (this.textKitNumber.Text == SelectedKit.Number)
                return;
            if (this.textKitNumber.Text != "")
            {
                KitsSearchResponse response = new KitsSearch(this.textKitNumber.Text.ToUpper()).PerformRequestAsync().Result;

                if (response.Kits.Count != 1)
                {
                    KitsSearchForm form = new KitsSearchForm(this.textKitNumber.Text);
                    Client.MainWindow.OpenFormDialog(form);
                    FillDetails(form.Result);
                    form.Dispose();
                    return;
                }
                else if (MessageBox.Show($"Create new kit?", "Create new kit?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SelectedKit.Number = this.textKitNumber.Text;
                    FillDetails(SelectedKit);
                    this.Text = $"Kit | Creating new kit";
                    this.NewKit = true;
                    return;
                }
                else FillDetails(response.Kits.ElementAt(0).Value);
            }
        }

        private void AddPart()
        {
            if (SelectedKit.Locked)
            {
                MessageBox.Show($"Cannot add part to kit.\nThe kit is locked.", "Failed");
                return;
            }

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

            if (part.Number is null)
                return;

            if (SelectedKit.Parts is null)
                SelectedKit.Parts = new List<PartQuantityPair>();

            SelectedKit.Parts.Add(new PartQuantityPair(part.Number, 1));
            ListViewItem partItem = ListParts.Items.Add(part.Number);
            partItem.Name = part.Number;
            partItem.SubItems.Add("1");
            partItem.SubItems.Add(part.Make);
            partItem.SubItems.Add(part.Description);

            textPartNumber.Text = "";
        }

        //
        // OVERRIDES
        //

        public override void Save()
        {
            if (SelectedKit.Number is null && NewKit == false)
                return;

            if (SelectedKit.Locked && !NewKit)
            {
                MessageBox.Show($"Cannot save kit.\nThe kit is locked.", "Failed");
                return;
            }

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
        public override void Delete()
        {
            if (SelectedKit.Number is null)
                return;

            if (SelectedKit.Locked)
            {
                MessageBox.Show($"Cannot delete kit.\nThe kit is locked.", "Failed");
                return;
            }

            if (MessageBox.Show($"Delete kit \"{this.textKitNumber.Text.ToUpper()}\"?", "Delete kit?", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            Response response = new KitRemove(SelectedKit.Number).PerformRequestAsync().Result;
            if (!response.IsSuccess)
            {
                MessageBox.Show($"Failed to delete kit\n{response.RawMessage}");
                return;
            }
            ClearDetails();
        }

        public override void ImportCSV()
        {
            if (SelectedKit.Parts is null)
                SelectedKit.Parts = new List<PartQuantityPair>();

            if (SelectedKit.Locked)
            {
                MessageBox.Show($"Cannot import parts.\nThe kit is locked.", "Failed");
                return;
            }

            DialogResult result = ImportFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = ImportFileDialog.FileName;
                GetFormatResponse r = new GetFormat("csv", "titan").PerformRequestAsync().Result;

                if (!r.IsSuccess)
                {
                    MessageBox.Show($"Failed to get CSV format.\n{r.RawMessage}", "Failed");
                    return;
                }

                KeyValuePair<Part, int>[] parts = r.Format.GetKitPartsList(file);

                foreach (KeyValuePair<Part, int> part in parts)
                {
                    PartsSearchResponse response = new PartsSearch(part.Key.Number).PerformRequestAsync().Result;
                    Part p;
                    if (response.Parts.Count != 1)
                    {
                        PartsMaintenanceForm pmf = new PartsMaintenanceForm(part.Key, true, true);
                        Client.MainWindow.OpenFormDialog(pmf);
                        if (!pmf.Saved)
                            continue;
                        p = pmf.SelectedPart;
                    }
                    else
                        p = response.Parts.ElementAt(0).Value;

                    ListViewItem partItem = ListParts.Items.Add(p.Number);
                    partItem.Name = p.Number;
                    partItem.SubItems.Add(part.Value.ToString());
                    partItem.SubItems.Add(p.Make);
                    partItem.SubItems.Add(p.Description);

                    SelectedKit.Parts.Add(new PartQuantityPair(p.Number, part.Value));
                };
            }
        }

        private void buttonKitSearch_Click(object sender, EventArgs e)
        {
            SearchForKit(textKitNumber.Text);
        }

        private void textKitNumber_Leave(object sender, EventArgs e)
        {
            if (textKitNumber.Text != "")
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
                foreach (KeyValuePair<string, Model> model in response.Makes[this.boxMakes.Text].Models)
                {
                    this.boxModel.Items.Add(model.Key);
                }
            }
        }

        private void ListParts_Resize(object sender, EventArgs e)
        {
            ListParts.Columns[3].Width = ListParts.Width - ListParts.Columns[0].Width - ListParts.Columns[1].Width - ListParts.Columns[2].Width - 5;
        }

        private void textPartNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddPart();
                e.Handled = true;
            }
        }

        private void ButtonPartAdd_Click(object sender, EventArgs e)
        {
            AddPart();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            ClearDetails();
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void LockUnlockButton_Click(object sender, EventArgs e)
        {
            if (SelectedKit.Number is null)
                return;

            if (MessageBox.Show($"Are you sure you want to {(SelectedKit.Locked ? "unlock" : "lock")} this kit?", $"{(SelectedKit.Locked ? "Unlock" : "Lock")} kit?", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            if (!NewKit)
            {
                Response r = new KitSetLockState(SelectedKit.Number, !SelectedKit.Locked).PerformRequestAsync().Result;

                if (!r.IsSuccess)
                {
                    MessageBox.Show($"Failed to {(SelectedKit.Locked ? "unlock" : "lock")} kit.\n{r.RawMessage}", "Failed");
                    return;
                }
            }

            SelectedKit.Locked = !SelectedKit.Locked;

            if (SelectedKit.Locked)
            {
                LockUnlockButton.Image = Properties.Resources.locked_icon;
                this.ListParts.SetReadonly(true, true, true, true);
            }
            else
            {
                LockUnlockButton.Image = Properties.Resources.unlocked_icon;
                this.ListParts.SetReadonly(false, false, true, true);
            }

            if (!NewKit)
                this.Text = $"Kit | {SelectedKit.Number} \"{SelectedKit.Description}\"{(SelectedKit.Locked ? "" : "- Editing")}";
        }

        private void ListParts_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                if (e.KeyCode == Keys.C)
                {
                    if (ListParts.SelectedItems.Count > 0)
                        Clipboard.SetText(ListParts.SelectedItems[0].SubItems[0].Text);
                }
            }
        }

        //
        //      PartsListMenu stuff
        //
        private void PartsListMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (SelectedKit.Parts is not null)
            {
                if (SelectedKit.Parts.Count > 0 && ListParts.SelectedItems.Count == 1)
                {
                    PartsListMenuCopy.Enabled = true;
                    PartsListMenuDelete.Enabled = true;
                    return;
                }
            }
            PartsListMenuCopy.Enabled = false;
            PartsListMenuDelete.Enabled = false;
        }

        private void PartsListMenuCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(ListParts.SelectedItems[0].SubItems[0].Text);
        }

        private void PastListMenuDelete_Click(object sender, EventArgs e)
        {
            if (SelectedKit.Locked)
            {
                MessageBox.Show($"Cannot delete part.\nThe kit is locked.", "Failed");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete part " + ListParts.SelectedItems[0].SubItems[0].Text + " from this kit?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int index = ListParts.Items.IndexOf(ListParts.SelectedItems[0]);

                ListParts.Items.RemoveAt(index);
                SelectedKit.Parts.RemoveAt(index);
            }
        }

        private void PartsListMenuImportCSV_Click(object sender, EventArgs e)
        {
            ImportCSV();
        }
    }
}
