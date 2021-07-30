using KronosDMS.Api.Endpoints;
using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KronosDMS_Client.Forms.Parts
{
    public partial class PartsMaintenanceForm : Window
    {
        private bool NewPart = false;
        Part SelectedPart = new Part();

        public PartsMaintenanceForm(Part part = new Part())
        {
            InitializeComponent();

            this.labelPartNumber.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelMake.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelDescription.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelBin.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelPredecessor.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelSuccessor.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.groupDetails.ForeColor = Client.ActiveTheme.Colors.Text.Default;

            this.Tools.BackColor = Client.ActiveTheme.Colors.Foreground;

            if (part.Number is not null)
                FillDetails(part);
        }

        private void FillDetails(Part part)
        {
            if (part.Number == null)
                return;

            SelectedPart = part;

            if (this.NewPart != true)
                this.Text = $"Parts Maintenance | {part.Number} \"{part.Description}\" - Editing";

            MakesSearchResponse makes = new MakesSearch("").PerformRequestAsync().Result;
            foreach (KeyValuePair<string, Make> make in makes.Makes)
                boxMakes.Items.Add(make.Value.Name);

            textPartNumber.Text = part.Number;
            boxMakes.Text = part.Make;
            textDescription.Text = part.Description;
            textBin.Text = part.Bin;
            textPredecessor.Text = part.Predecessor;
            textSuccessor.Text = part.Successor;

            boxMakes.Enabled = true;
            textDescription.Enabled = true;
            textBin.Enabled = true;
            textPredecessor.Enabled = true;
            textSuccessor.Enabled = true;

            buttonPredecessorSearch.Enabled = true;
            buttonSuccessorSearch.Enabled = true;
        }

        private void ClearDetails()
        {
            SelectedPart = new Part();

            this.Text = $"Parts Maintenance";

            boxMakes.Items.Clear();

            textPartNumber.Text = "";
            boxMakes.Text = "";
            textDescription.Text = "";
            textBin.Text = "";
            textPredecessor.Text = "";
            textSuccessor.Text = "";

            boxMakes.Enabled = false;
            textDescription.Enabled = false;
            textBin.Enabled = false;
            textPredecessor.Enabled = false;
            textSuccessor.Enabled = false;

            buttonPredecessorSearch.Enabled = false;
            buttonSuccessorSearch.Enabled = false;
        }

        private void SearchPart()
        {
            if (this.textPartNumber.Text == "" || this.textPartNumber.Text == SelectedPart.Number)
                return;
            PartsSearchResponse response = new PartsSearch(this.textPartNumber.Text.ToUpper()).PerformRequestAsync().Result;
            if (response.Parts.Count != 1)
            {
                if (MessageBox.Show($"Create new part \"{this.textPartNumber.Text.ToUpper()}\"?", "Create new part?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Text = $"Parts Maintenance | {this.textPartNumber.Text.ToUpper()} - Creating new part";
                    this.textPartNumber.Text = this.textPartNumber.Text.ToUpper();
                    this.NewPart = true;
                    SelectedPart.Number = this.textPartNumber.Text;
                    FillDetails(SelectedPart);
                    return;
                }
                else
                {
                    PartsSearchForm form = new PartsSearchForm(this.textPartNumber.Text);
                    Client.MainWindow.OpenFormDialog(form);
                    FillDetails(form.Result);
                    form.Dispose();
                }
            }
            else FillDetails(response.Parts.ElementAt(0).Value);
        }

        private Part SearchForPart(string number)
        {
            PartsSearchForm form = new PartsSearchForm(number);
            Client.MainWindow.OpenFormDialog(form);
            Part p = form.Result;
            form.Dispose();
            return p;
        }

        public override void Save()
        {
            if (SelectedPart.Number is null)
                return;

            SelectedPart.Number = SelectedPart.Number.ToUpper();
            SelectedPart.Make = boxMakes.Text;
            SelectedPart.Description = textDescription.Text;
            SelectedPart.Bin = textBin.Text;
            SelectedPart.Predecessor = textPredecessor.Text;
            SelectedPart.Successor = textSuccessor.Text;

            Response response;
            if (NewPart)
            {
                response = new PartAdd(SelectedPart).PerformRequestAsync().Result;
                if (!response.IsSuccess)
                {
                    MessageBox.Show($"Failed to save part\n{response.RawMessage}");
                    return;
                }
            }
            else
            {
                response = new PartSet(SelectedPart).PerformRequestAsync().Result;
                if (!response.IsSuccess)
                {
                    MessageBox.Show($"Failed to save part\n{response.RawMessage}");
                    return;
                }
            }
            ClearDetails();
        }

        public override void Delete()
        {
            if (SelectedPart.Number is null)
                return;

            if (MessageBox.Show($"Delete part \"{this.textPartNumber.Text.ToUpper()}\"?", "Delete part?", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            Response response = new PartRemove(SelectedPart.Number).PerformRequestAsync().Result;
            if (!response.IsSuccess)
            {
                MessageBox.Show($"Failed to delete part\n{response.RawMessage}");
                return;
            }
            ClearDetails();
        }

        private void textPartNumberSearch(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchPart();
            }
        }

        private void buttonPartSearch_Click(object sender, EventArgs e)
        {
            FillDetails(SearchForPart(textPartNumber.Text));
        }

        private void buttonPredecessorSearch_Click(object sender, EventArgs e)
        {
            Part part = SearchForPart(textPredecessor.Text);
            if (part.Number is null)
            {
                return;
            }
            textPredecessor.Text = part.Number;
            SelectedPart.Predecessor = part.Number;
        }

        private void buttonSuccessorSearch_Click(object sender, EventArgs e)
        {
            Part part = SearchForPart(textSuccessor.Text);
            if (part.Number is null)
            {
                return;
            }
            textSuccessor.Text = part.Number;
            SelectedPart.Successor = part.Number;
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            if (SelectedPart.Number is null)
                return;
            ClearDetails();
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void textPartNumber_Leave(object sender, EventArgs e)
        {
            SearchForPart(textPartNumber.Text);
        }
    }
}
