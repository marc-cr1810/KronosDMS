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
    public partial class ROCheckedSubmitForm : FormWindow
    {
        private List<RepairOrder> RepairOrders = new List<RepairOrder>();

        public ROCheckedSubmitForm()
        {
            InitializeComponent();

            this.labelRONumber.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelDate.ForeColor = Client.ActiveTheme.Colors.Text.Default;

            this.Tools.BackColor = Client.ActiveTheme.Colors.Foreground;
        }

        private void Add()
        {
            int number = 0;
            if (!int.TryParse(textRONumber.Text, out number))
            {
                MessageBox.Show("Invalid RO number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RepairOrder ro = new RepairOrder(number, datePicker.Value);
            ListViewItem roItem = ROList.Items.Add(ro.Number.ToString());
            roItem.Name = ro.Number.ToString();
            roItem.SubItems.Add(ro.CreationDate.ToString("d"));

            RepairOrders.Add(ro);
            textRONumber.Text = "";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void textRONumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Add();
            }
        }

        private void CloseForm()
        {
            Client.MainFormWindow.CloseForm(this);
        }

        //
        // OVERRIDES
        //

        public override void Save()
        {
            if (RepairOrders.Count == 0)
            {
                CloseForm();
                return;
            }
            Response response = new ROCheckedAdd(RepairOrders).PerformRequestAsync().Result;
            if (!response.IsSuccess)
            {
                MessageBox.Show($"Failed to submit RO's\n{response.RawMessage}");
                return;
            }
            CloseForm();
        }
    }
}
