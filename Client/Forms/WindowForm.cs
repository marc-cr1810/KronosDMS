using System.Windows.Forms;

namespace KronosDMS_Client.Forms
{
    public partial class Window : Form
    {
        private FormWindowState PrevState = FormWindowState.Normal;
        public FormWindowState CurrentWindowState = FormWindowState.Normal;
        public bool IsDialog = false;

        public Window()
        {
            this.InitializeComponent();

            this.BackColor = Client.ActiveTheme.Colors.Background;

            this.PrevState = this.WindowState;
            this.CurrentWindowState = this.WindowState;
        }

        protected void Window_SizeChanged(object sender, System.EventArgs e)
        {
            if (IsDialog)
                return;
            if (PrevState != this.WindowState)
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.Dock = DockStyle.Fill;
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Normal;
                    this.CurrentWindowState = FormWindowState.Maximized;
                }
                else
                {
                    this.Dock = DockStyle.None;
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    this.CurrentWindowState = this.WindowState;
                }

                this.PrevState = this.WindowState;
            }
        }

        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            Client.MainWindow.CloseForm(this);
        }

        public virtual void Save() { }
        public virtual void Delete() { }
        public virtual void ExportCSV() { }
        public virtual void ImportCSV() { }
    }
}
