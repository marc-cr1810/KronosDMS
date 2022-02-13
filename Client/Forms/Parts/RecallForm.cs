using KronosDMS;
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
        private int SelectedOption = 0;

        public RecallForm(Recall recall = new Recall())
        {
            InitializeComponent();

            //ListParts.Columns[3].Width = ListParts.Width - ListParts.Columns[0].Width - ListParts.Columns[1].Width - ListParts.Columns[2].Width - 5;

            this.labelMake.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelModel.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelRecallNumber.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelDescription.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.groupDetails.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelPartNumber.ForeColor = Client.ActiveTheme.Colors.Text.Default;

            this.Tools.BackColor = Client.ActiveTheme.Colors.Foreground;

            this.ListParts.SetReadonly(false, false, true, true, false);
            this.ListParts.ItemEdited += PartsList_ItemEdited;

            if (recall.Number is not null)
                FillDetails(recall);
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

                SelectedRecall.Options[SelectedOption].Parts[itemIndex] = new PartQuantityPairNote(part.Number, SelectedRecall.Options[SelectedOption].Parts[itemIndex].Quantity, SelectedRecall.Options[SelectedOption].Parts[itemIndex].Note);
            }
            else if (index == 1)
            {
                try
                {
                    int qty = int.Parse(item.SubItems[index].Text);
                    if (qty < 1)
                    {
                        ListParts.Items.Remove(item);
                        SelectedRecall.Options[SelectedOption].Parts.RemoveAt(itemIndex);
                        return;
                    }
                    SelectedRecall.Options[SelectedOption].Parts[itemIndex] = new PartQuantityPairNote(SelectedRecall.Options[SelectedOption].Parts[itemIndex].Number, qty, SelectedRecall.Options[SelectedOption].Parts[itemIndex].Note);
                }
                catch
                {
                    item.SubItems[index].Text = "1";
                }
            }
            else if (index == 4)
            {
                try
                {
                    string note = item.SubItems[index].Text;
                    SelectedRecall.Options[SelectedOption].Parts[itemIndex] = new PartQuantityPairNote(SelectedRecall.Options[SelectedOption].Parts[itemIndex].Number, SelectedRecall.Options[SelectedOption].Parts[itemIndex].Quantity, note);
                }
                catch
                {
                    item.SubItems[index].Text = "";
                }
            }
        }

        private void FillDetails(Recall recall)
        {
            if (recall.Number == null)
                return;
            this.NewRecall = false;

            if (recall.Options == null)
            {
                recall.Options = new List<PartsOption>();
                recall.Options.Add(new PartsOption("Default", new List<PartQuantityPairNote>()));
            }

            SelectedRecall = recall;

            if (SelectedRecall.Options is null)
                SelectedRecall.Options = new List<PartsOption>();

            this.Text = $"Recall | {recall.Number} \"{recall.Description}\"{(SelectedRecall.Locked ? "" : " - Editing")}";

            MakesSearchResponse makes = new MakesSearch("").PerformRequestAsync().Result;
            foreach (KeyValuePair<string, Make> make in makes.Makes)
                boxMakes.Items.Add(make.Value.Name);

            boxOptions.Items.Clear();
            foreach (PartsOption option in recall.Options)
                boxOptions.Items.Add(option.Name);
            boxOptions.SelectedIndex = SelectedOption = 0;

            textRecallNumber.Text = recall.Number;
            boxMakes.Text = recall.Make;
            boxModel.Text = recall.Model;
            textDescription.Text = recall.Description;
            textNote.Text = recall.AttentionNote;

            ChangeLockState();

            FillPartsList(recall.Options[SelectedOption]);

            if (recall.AttentionNote != null && recall.AttentionNote != "")
            {
                MessageBox.Show(recall.AttentionNote, "Attention");
            }

            //ListParts.Columns[3].Width = ListParts.Width - ListParts.Columns[0].Width - ListParts.Columns[1].Width - ListParts.Columns[2].Width - 5;
        }

        private void FillPartsList(PartsOption option)
        {
            ListParts.Items.Clear();
            foreach (PartQuantityPairNote part in option.Parts)
            {
                PartsSearchResponse response = new PartsSearch("", part.Number, "").PerformRequestAsync().Result;
                Part p = response.Parts.ElementAt(0).Value;
                ListViewItem partItem = ListParts.Items.Add(part.Number);
                partItem.Name = p.Number;
                partItem.SubItems.Add(part.Quantity.ToString());
                partItem.SubItems.Add(p.Make);
                partItem.SubItems.Add(p.Description);
                partItem.SubItems.Add(part.Note);
            };
        }

        private void ClearDetails()
        {
            SelectedRecall = new Recall();

            textRecallNumber.Text = "";
            boxMakes.Text = "";
            boxModel.Text = "";
            textDescription.Text = "";
            textNote.Text = "";
            this.boxMakes.Items.Clear();
            this.boxModel.Items.Clear();

            boxOptions.Text = "";
            boxOptions.DropDownStyle = ComboBoxStyle.DropDown;
            boxOptions.Items.Clear();

            LockUnlockButton.Image = Properties.Resources.unlocked_icon;

            this.Text = $"Recall";

            ListParts.Items.Clear();
        }

        private void ChangeLockState()
        {
            if (SelectedRecall.Locked)
            {
                LockUnlockButton.Image = Properties.Resources.locked_icon;
                this.boxOptions.DropDownStyle = ComboBoxStyle.DropDownList;
                this.ListParts.SetReadonly(true, true, true, true, true);
                this.textDescription.Enabled = false;
                this.textNote.Enabled = false;
                this.boxMakes.DropDownStyle = ComboBoxStyle.Simple;
                this.boxMakes.Enabled = false;
                this.boxModel.DropDownStyle = ComboBoxStyle.Simple;
                this.boxModel.Enabled = false;
            }
            else
            {
                LockUnlockButton.Image = Properties.Resources.unlocked_icon;
                this.boxOptions.DropDownStyle = ComboBoxStyle.DropDown;
                this.ListParts.SetReadonly(false, false, true, true, false);
                this.textDescription.Enabled = true;
                this.textNote.Enabled = true;
                this.boxMakes.DropDownStyle = ComboBoxStyle.DropDownList;
                this.boxMakes.Enabled = true;
                this.boxModel.DropDownStyle = ComboBoxStyle.DropDownList;
                this.boxModel.Enabled = true;
            }
        }

        private void SearchRecall()
        {
            if (this.textRecallNumber.Text == "" || this.textRecallNumber.Text == SelectedRecall.Number)
                return;
            RecallsSearchResponse response = new RecallsSearch(this.textRecallNumber.Text.ToUpper()).PerformRequestAsync().Result;
            if (response.Recalls.Count != 1)
            {
                if (MessageBox.Show($"Create new recall \"{this.textRecallNumber.Text.ToUpper()}\"?", "Create new recall?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.textRecallNumber.Text = this.textRecallNumber.Text.ToUpper();
                    SelectedRecall.Number = this.textRecallNumber.Text;
                    FillDetails(SelectedRecall);
                    this.Text = $"Recall | {this.textRecallNumber.Text.ToUpper()} - Creating new recall";
                    this.NewRecall = true;
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

        private void AddPart()
        {
            if (SelectedRecall.Locked && !NewRecall)
            {
                MessageBox.Show($"Cannot add part to recall.\nThe recall is locked.", "Failed");
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

            SelectedRecall.Options[SelectedOption].Parts.Add(new PartQuantityPairNote(part.Number, 1, ""));
            ListViewItem partItem = ListParts.Items.Add(part.Number);
            partItem.Name = part.Number;
            partItem.SubItems.Add("1");
            partItem.SubItems.Add(part.Make);
            partItem.SubItems.Add(part.Description);
            partItem.SubItems.Add("");

            textPartNumber.Text = "";
        }

        //
        // OVERRIDES
        //

        public override void Save()
        {
            if (SelectedRecall.Number is null)
                return;

            if (SelectedRecall.Locked && !NewRecall)
            {
                MessageBox.Show($"Cannot save recall.\nThe recall is locked.", "Failed");
                return;
            }

            SelectedRecall.Number = SelectedRecall.Number.ToUpper();
            SelectedRecall.Make = this.boxMakes.Text;
            SelectedRecall.Model = this.boxModel.Text;
            SelectedRecall.Description = this.textDescription.Text;
            SelectedRecall.AttentionNote = this.textNote.Text;

            Response response;
            if (NewRecall)
            {
                response = new RecallAdd(SelectedRecall).PerformRequestAsync().Result;
                if (!response.IsSuccess)
                {
                    MessageBox.Show($"Failed to save recall\n{response.RawMessage}");
                    return;
                }
            }
            else
            {
                response = new RecallSet(SelectedRecall).PerformRequestAsync().Result;
                if (!response.IsSuccess)
                {
                    MessageBox.Show($"Failed to save recall\n{response.RawMessage}");
                    return;
                }
            }
            ClearDetails();
        }

        public override void Delete()
        {
            if (SelectedRecall.Number is null)
                return;

            if (SelectedRecall.Locked && !NewRecall)
            {
                MessageBox.Show($"Cannot delete recall.\nThe recall is locked.", "Failed");
                return;
            }

            if (MessageBox.Show($"Delete recall \"{this.textRecallNumber.Text.ToUpper()}\"?", "Delete recall?", MessageBoxButtons.YesNo) == DialogResult.No)
                return;


            if (NewRecall)
                ClearDetails();

            Response response = new RecallRemove(SelectedRecall.Number).PerformRequestAsync().Result;
            if (!response.IsSuccess)
            {
                MessageBox.Show($"Failed to delete recall\n{response.RawMessage}");
                return;
            }
            ClearDetails();
        }

        public override void ImportCSV()
        {
            if (SelectedRecall.Number is null)
                return;

            if (SelectedRecall.Locked && !NewRecall)
            {
                MessageBox.Show($"Cannot import parts.\nThe recall is locked.", "Failed");
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

                KeyValuePair<Part, int>[] parts = r.Format.GetRecallPartsList(file);

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

                    SelectedRecall.Options[SelectedOption].Parts.Add(new PartQuantityPairNote(p.Number, part.Value, ""));
                };
            }
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
            if (textRecallNumber.Text != "")
                SearchRecall();
        }

        private void textRecallNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchRecall();
            }
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
            //ListParts.Columns[3].Width = ListParts.Width - ListParts.Columns[0].Width - ListParts.Columns[1].Width - ListParts.Columns[2].Width - 5;
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
            if (SelectedRecall.Number is null)
                return;
            ClearDetails();
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void LockUnlockButton_Click(object sender, EventArgs e)
        {
            if (SelectedRecall.Number is null)
                return;

            if (MessageBox.Show($"Are you sure you want to {(SelectedRecall.Locked ? "unlock" : "lock")} this recall?", $"{(SelectedRecall.Locked ? "Unlock" : "Lock")} recall?", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            if (!NewRecall)
            {
                Response r = new RecallSetLockState(SelectedRecall.Number, !SelectedRecall.Locked).PerformRequestAsync().Result;

                if (!r.IsSuccess)
                {
                    MessageBox.Show($"Failed to {(SelectedRecall.Locked ? "unlock" : "lock")} recall.\n{r.RawMessage}", "Failed");
                    return;
                }
            }

            SelectedRecall.Locked = !SelectedRecall.Locked;

            ChangeLockState();

            if (!NewRecall)
                this.Text = $"Recall | {SelectedRecall.Number} \"{SelectedRecall.Description}\"{(SelectedRecall.Locked ? "" : "- Editing")}";
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
            if (SelectedRecall.Options[SelectedOption].Parts is not null)
            {
                if (SelectedRecall.Options[SelectedOption].Parts.Count > 0 && ListParts.SelectedItems.Count == 1)
                {
                    PartsListMenuCopy.Enabled = true;
                    PartsListMenuDelete.Enabled = true;
                }
                PartsListMenuImportCSV.Enabled = true;
                PartsListMenuExportCSV.Enabled = true;
                return;
            }
            PartsListMenuCopy.Enabled = false;
            PartsListMenuDelete.Enabled = false;
            PartsListMenuImportCSV.Enabled = false;
            PartsListMenuExportCSV.Enabled = false;
        }

        private void PartsListMenuCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(ListParts.SelectedItems[0].SubItems[0].Text);
        }

        private void PastListMenuDelete_Click(object sender, EventArgs e)
        {
            if (SelectedRecall.Locked && !NewRecall)
            {
                MessageBox.Show($"Cannot delete part.\nThe recall is locked.", "Failed");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete part " + ListParts.SelectedItems[0].SubItems[0].Text + " from this recall?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int index = ListParts.Items.IndexOf(ListParts.SelectedItems[0]);

                ListParts.Items.RemoveAt(index);
                SelectedRecall.Options[SelectedOption].Parts.RemoveAt(index);
            }
        }

        private void PartsListMenuImportCSV_Click(object sender, EventArgs e)
        {
            ImportCSV();
        }

        private void buttonAddOption_Click(object sender, EventArgs e)
        {
            if (SelectedRecall.Number == null)
                return;

            if (SelectedRecall.Locked)
            {
                MessageBox.Show($"Cannot add option.\nThe recall is locked.", "Failed");
                return;
            }

            SelectedRecall.Options.Add(new PartsOption("New Option", new List<PartQuantityPairNote>()));
            boxOptions.Items.Add("New Option");
            boxOptions.SelectedIndex = SelectedOption = boxOptions.Items.Count - 1;
        }

        private void boxOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedRecall.Number == null)
                return;

            FillPartsList(SelectedRecall.Options[SelectedOption = boxOptions.SelectedIndex]);
        }

        private void boxOptions_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
            {
                if (SelectedRecall.Options == null)
                    return;

                PartsOption option = SelectedRecall.Options[SelectedOption];
                if (option.Name == null || option.Name == boxOptions.Text)
                    return;

                if (boxOptions.Text == "")
                {
                    if (SelectedRecall.Options.Count > 1)
                    {
                        SelectedRecall.Options.RemoveAt(SelectedOption);
                        boxOptions.Items.RemoveAt(SelectedOption);
                        boxOptions.SelectedIndex = SelectedOption = 0;
                        return;
                    }
                    boxOptions.Text = "Default";
                }

                option.Name = boxOptions.Text;
                SelectedRecall.Options[SelectedOption] = option;
                boxOptions.Items[SelectedOption] = boxOptions.Text;
            }
        }

        private void boxOptions_Leave(object sender, EventArgs e)
        {

            if (SelectedRecall.Options == null)
                return;

            PartsOption option = SelectedRecall.Options[SelectedOption];
            if (option.Name == null || option.Name == boxOptions.Text)
                return;

            if (boxOptions.Text == "")
            {
                if (SelectedRecall.Options.Count > 1)
                {
                    SelectedRecall.Options.RemoveAt(SelectedOption);
                    boxOptions.Items.RemoveAt(SelectedOption);
                    boxOptions.SelectedIndex = SelectedOption = 0;
                    return;
                }
                boxOptions.Text = "Default";
            }

            option.Name = boxOptions.Text;
            SelectedRecall.Options[SelectedOption] = option;
            boxOptions.Items[SelectedOption] = boxOptions.Text;
        }
    }
}
