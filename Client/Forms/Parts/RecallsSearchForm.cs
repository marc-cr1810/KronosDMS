using KronosDMS.Api.Endpoints;
using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KronosDMS_Client.Forms.Parts
{
    public partial class RecallsSearchForm : Window
    {
        public Recall Result;

        public RecallsSearchForm(string number = "")
        {
            InitializeComponent();

            MakesSearchResponse response = new MakesSearch("").PerformRequestAsync().Result;
            foreach (KeyValuePair<string, Make> make in response.Makes)
            {
                boxMakes.Items.Add(make.Value.Name);
            }

            ListParts.Columns[3].Width = ListParts.Width - ListParts.Columns[0].Width - ListParts.Columns[1].Width - ListParts.Columns[2].Width - 5;

            this.labelMake.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelModel.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelPartNumber.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelDescription.ForeColor = Client.ActiveTheme.Colors.Text.Default;

            this.textRecallNumber.Text = number;
            if (number != "")
                Search();
        }

        public void Search()
        {
            RecallsSearchResponse response = new RecallsSearch(this.boxMakes.Text, this.boxModel.Text, this.textRecallNumber.Text, this.textDescription.Text).PerformRequestAsync().Result;

            ListParts.Items.Clear();

            foreach (KeyValuePair<string, Recall> recall in response.Recalls)
            {
                ListViewItem partItem = ListParts.Items.Add(recall.Value.Number);
                partItem.Name = recall.Key;
                partItem.SubItems.Add(recall.Value.Make);
                partItem.SubItems.Add(recall.Value.Model);
                partItem.SubItems.Add(recall.Value.Description);
            };

            ListParts.Columns[3].Width = ListParts.Width - ListParts.Columns[0].Width - ListParts.Columns[1].Width - ListParts.Columns[2].Width - 5;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void boxMakes_TextUpdate(object sender, EventArgs e)
        {
            this.boxModel.Items.Clear();
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

        private void ListParts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string id = ListParts.SelectedItems[0].Name;
            string number = ListParts.SelectedItems[0].Text;
            string make = ListParts.SelectedItems[0].SubItems[1].Text;
            string model = ListParts.SelectedItems[0].SubItems[2].Text;
            string description = ListParts.SelectedItems[0].SubItems[3].Text;

            RecallsSearchResponse response = new RecallsSearch(make, model, number, description).PerformRequestAsync().Result;
            Result = response.Recalls[id];
            Client.MainWindow.CloseForm(this);
        }
    }
}
