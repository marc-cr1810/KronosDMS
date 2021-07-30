using System.Windows.Forms;

namespace KronosDMS_Client.Forms
{
    public partial class Window : Form
    {
        public Window()
        {
            this.InitializeComponent();
            this.BackColor = Client.ActiveTheme.Colors.Background;
        }

        public void MakeFocused()
        {
            if (Client.MainWindow.FocusedWindow != this)
            {
                this.BringToFront();
                Client.MainWindow.FocusedWindow = this;
            }
        }

        protected void Window_SizeChanged(object sender, System.EventArgs e)
        {
            //MakeFocused();
            if (this.WindowState == FormWindowState.Maximized)
            {
                //this.Dock = DockStyle.Fill;
                //this.FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                //this.Dock = DockStyle.None;
                //this.FormBorderStyle = FormBorderStyle.Sizable;
            }
        }

        public virtual void Save() { }
        public virtual void Delete() { }
        public virtual void ExportCSV() { }
        public virtual void ImportCSV() { }

        private void Window_Activated(object sender, System.EventArgs e)
        {
            MakeFocused();
        }

        private void Window_MouseClick(object sender, MouseEventArgs e)
        {
            MakeFocused();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            MakeFocused();
            return false;
        }

        private void Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Client.MainWindow.FocusedWindow == this)
            {
                Client.MainWindow.FocusedWindow = null;
            }
        }
    }
}
