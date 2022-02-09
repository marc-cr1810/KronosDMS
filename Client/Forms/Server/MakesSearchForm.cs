using KronosDMS.Api.Endpoints;
using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KronosDMS_Client.Forms.Server
{
    public partial class MakesSearchForm : Window
    {
        private bool IsDialog;
        public Make Result;

        public MakesSearchForm(string id = "", bool dialog = true)
        {
            InitializeComponent();

            ListMakes.Columns[1].Width = ListMakes.Width - ListMakes.Columns[0].Width - 5;

            this.labelMakeID.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelMakeName.ForeColor = Client.ActiveTheme.Colors.Text.Default;

            this.textMakeID.Text = id;

            if (id != "")
                Search();

            this.IsDialog = dialog;
        }

        private void Search()
        {
            MakesSearchResponse response = new MakesSearch(this.textMakeID.Text != "" ? this.textMakeID.Text : this.textMakeName.Text).PerformRequestAsync().Result;

            if (!response.IsSuccess)
            {
                MessageBox.Show($"Failed to search for makes\n{response.RawMessage}", "Failed");
                return;
            }

            ListMakes.Items.Clear();

            foreach (KeyValuePair<string, Make> make in response.Makes)
            {
                ListViewItem partItem = ListMakes.Items.Add(make.Key);
                partItem.Name = make.Key;
                partItem.SubItems.Add(make.Value.Name);
            };

            ListMakes.Columns[1].Width = ListMakes.Width - ListMakes.Columns[0].Width - 5;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void ListMakes_Resize(object sender, EventArgs e)
        {
            if (ListMakes.Columns.Count > 0)
            {
                ListMakes.Columns[1].Width = ListMakes.Width - ListMakes.Columns[0].Width - 5;
            }
        }

        private void ListMakes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string id = ListMakes.SelectedItems[0].Name;

            MakesSearchResponse response = new MakesSearch(id).PerformRequestAsync().Result;
            Result = response.Makes[id];
            if (!IsDialog)
                Client.MainWindow.OpenForm(new MakesMaintenanceForm(Result));
            Client.MainWindow.CloseForm(this);
        }
    }
}
