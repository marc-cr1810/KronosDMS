using KronosDMS.Api.Endpoints;
using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KronosDMS_Client.Forms.Server
{
    public partial class MakesMaintenanceForm : FormWindow
    {
        private bool Dialog = false;
        private bool NewMake = false;
        public Make SelectedMake = new Make();
        public bool Saved = false;

        public MakesMaintenanceForm(Make make = new Make())
        {
            InitializeComponent();

            this.labelPartNumber.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelMakeName.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.groupDetails.ForeColor = Client.ActiveTheme.Colors.Text.Default;

            this.Tools.BackColor = Client.ActiveTheme.Colors.Foreground;

            if (make.Name is not null)
                FillDetails(make);
        }

        private void FillDetails(Make make)
        {
            if (make.Name == null)
                return;

            SelectedMake = make;

            if (this.NewMake != true)
                this.Text = $"Makes Maintenance | {make.Name} - Editing";

            if (SelectedMake.Models != null)
            {
                foreach (KeyValuePair<string, Model> model in SelectedMake.Models)
                {
                    ListViewItem modelItem = ListModels.Items.Add(model.Key);
                    modelItem.Name = model.Key;
                    if (model.Value.SubModels is not null)
                        modelItem.SubItems.Add(model.Value.SubModels.Count.ToString());
                    else
                        modelItem.SubItems.Add("0");
                }
            }

            textMakeID.Text = make.Name;
            textMakeName.Text = make.Name;

            textMakeID.Enabled = false;
            textMakeName.Enabled = true;
        }

        private void ClearDetails()
        {
            SelectedMake = new Make();

            this.Text = $"Makes Maintenance";

            ListModels.Items.Clear();

            textMakeID.Text = "";
            textMakeName.Text = "";

            textMakeID.Enabled = true;
            textMakeName.Enabled = false;
        }

        private void SearchMake()
        {
            if (this.textMakeID.Text == "" || this.textMakeID.Text == SelectedMake.Name)
                return;
            MakesSearchResponse response = new MakesSearch(this.textMakeID.Text).PerformRequestAsync().Result;
            if (response.Makes.Count != 1)
            {
                if (MessageBox.Show($"Create new make \"{this.textMakeID.Text}\"?", "Create new make?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SelectedMake.Name = this.textMakeID.Text;
                    FillDetails(SelectedMake);
                    this.Text = $"Makes Maintenance | {this.textMakeID.Text} - Creating new make";
                    this.NewMake = true;
                    return;
                }
                else
                {
                    MakesSearchForm form = new MakesSearchForm(this.textMakeID.Text);
                    Client.MainFormWindow.OpenFormDialog(form);
                    FillDetails(form.Result);
                    form.Dispose();
                }
            }
            else FillDetails(response.Makes.ElementAt(0).Value);
        }

        private Make SearchForMake(string id)
        {
            MakesSearchForm form = new MakesSearchForm(id);
            Client.MainFormWindow.OpenFormDialog(form);
            Make m = form.Result;
            form.Dispose();
            return m;
        }

        public override void Save()
        {
            if (SelectedMake.Name is null)
                return;

            Response response;
            if (NewMake)
            {
                response = new MakeAdd(SelectedMake).PerformRequestAsync().Result;
                if (!response.IsSuccess)
                {
                    MessageBox.Show($"Failed to add make\n{response.RawMessage}");
                    return;
                }
            }
            else
            {
                response = new MakeSet(SelectedMake).PerformRequestAsync().Result;
                if (!response.IsSuccess)
                {
                    MessageBox.Show($"Failed to save make\n{response.RawMessage}");
                    return;
                }
            }
            if (Dialog)
            {
                Saved = true;
                this.Close();
                return;
            }
            ClearDetails();
        }

        public override void Delete()
        {
            if (SelectedMake.Name is null)
                return;

            if (MessageBox.Show($"Delete make \"{this.textMakeID.Text.ToUpper()}\"?", "Delete make?", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            Response response = new MakeRemove(SelectedMake.Name).PerformRequestAsync().Result;
            if (!response.IsSuccess)
            {
                MessageBox.Show($"Failed to delete make\n{response.RawMessage}");
                return;
            }
            ClearDetails();
        }

        private void textMakeIDSearch(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textMakeID.Text != SelectedMake.Name)
                    SearchMake();
            }
        }

        private void buttonMakeIDSearch_Click(object sender, EventArgs e)
        {
            if (textMakeID.Text != SelectedMake.Name)
                FillDetails(SearchForMake(textMakeID.Text));
        }

        private void textMakeID_Leave(object sender, EventArgs e)
        {
            if (textMakeID.Text != SelectedMake.Name && textMakeID.Text != "")
                SearchForMake(textMakeID.Text);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            if (SelectedMake.Name is null || Dialog)
                return;
            ClearDetails();
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            if (Dialog)
                return;
            Delete();
        }
    }
}
