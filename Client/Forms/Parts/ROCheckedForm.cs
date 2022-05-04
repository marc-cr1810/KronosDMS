using KronosDMS.Api.Endpoints;
using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KronosDMS_Client.Forms.Parts
{
    public partial class ROCheckedForm : Window
    {
        public ROCheckedForm()
        {
            InitializeComponent();

            this.labelRONumber.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelDate.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.groupSearch.ForeColor = Client.ActiveTheme.Colors.Text.Default;

            this.Tools.BackColor = Client.ActiveTheme.Colors.Foreground;

            Search();
        }

        private void Search()
        {
            ROCheckedSearchResponse response = new ROCheckedSearch(this.textRONumber.Text, this.datePicker.Value).PerformRequestAsync().Result;

            if (!response.IsSuccess)
            {
                MessageBox.Show($"Failed to search for checked RO's\n{response.RawMessage}", "Failed");
                return;
            }

            ROList.Items.Clear();

            foreach (KeyValuePair<int, RepairOrder> ro in response.RepairOrders)
            {
                ListViewItem partItem = ROList.Items.Add(ro.Key.ToString());
                partItem.Name = ro.Key.ToString();
                partItem.SubItems.Add(ro.Value.CreationDate.ToShortDateString());
            };
        }

        private void addToolStripButton_Click(object sender, EventArgs e)
        {
            ROCheckedSubmitForm form = new ROCheckedSubmitForm();
            Client.MainWindow.OpenFormDialog(form);
            form.Dispose();
            return;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}
