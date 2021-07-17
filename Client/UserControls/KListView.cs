using System;
using System.Windows.Forms;

namespace KronosDMS_Client.UserControls
{
    public partial class KListView : ListView
    {
        TextBox EditBox;

        private bool[] ReadonlyColumns { get; set; }
        private ListViewItem EditingItem;
        private ListViewItem.ListViewSubItem EditingSubItem;

        public Action<ListViewItem, int> ItemEdited = null;

        public KListView()
        {
            InitializeComponent();

            EditBox = new TextBox();
            this.SuspendLayout();

            this.EditBox.Location = new System.Drawing.Point(0, 0);
            this.EditBox.Name = "EditBox";
            this.EditBox.Size = new System.Drawing.Size(131, 23);
            this.EditBox.TabIndex = 2;
            this.EditBox.Visible = false;

            this.EditBox.KeyDown += EditBox_KeyDown;
            this.EditBox.LostFocus += EditBox_LostFocus;

            this.FullRowSelect = true;
            this.GridLines = true;
            this.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.HideSelection = false;
            this.MultiSelect = false;
            this.TabIndex = 15;
            this.UseCompatibleStateImageBehavior = false;
            this.View = System.Windows.Forms.View.Details;

            this.MouseDoubleClick += _MouseDoubleClick;

            this.Controls.Add(EditBox);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public void SetReadonly(params bool[] columns)
        {
            ReadonlyColumns = new bool[this.Columns.Count];
            for (int i = 0; i < Columns.Count; i++)
            {
                ReadonlyColumns[i] = columns[i];
            }
        }

        public void BeginEditItem(ListViewItem item, ListViewItem.ListViewSubItem subItem)
        {
            EditingItem = item;
            EditingSubItem = subItem;

            int index = item.SubItems.IndexOf(subItem);
            if (ReadonlyColumns[index])
                return;

            int lLeft = subItem.Bounds.Left + 2;
            int LWidth = (index == 0 ? item.SubItems[1].Bounds.X : subItem.Bounds.Width) - 2;
            EditBox.SetBounds(lLeft, subItem.Bounds.Top, LWidth, subItem.Bounds.Height - 2);
            EditBox.Text = subItem.Text;
            EditBox.Show();
            EditBox.Focus();
        }

        private void _MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem currentItem = this.GetItemAt(e.X, e.Y);
            if (currentItem is null)
                return;
            ListViewItem.ListViewSubItem currentSB = currentItem.GetSubItemAt(e.X, e.Y);

            BeginEditItem(currentItem, currentSB);
        }


        private void EditBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    EditingSubItem.Text = EditBox.Text;
                    e.Handled = true;
                    EditBox.Hide();
                    break;
                case Keys.Escape:
                    e.Handled = true;
                    EditBox.Hide();
                    break;
            }
        }

        private void EditBox_LostFocus(object sender, EventArgs e)
        {
            EditBox.Hide();

            ItemEdited(EditingItem, EditingItem.SubItems.IndexOf(EditingSubItem));
        }
    }
}
