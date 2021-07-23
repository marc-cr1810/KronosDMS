using System.Drawing;
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

        protected void Window_SizeChanged(object sender, System.EventArgs e)
        {
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

        private void Window_Activated(object sender, System.EventArgs e)
        {
            this.BringToFront();
        }

        private void Window_MouseClick(object sender, MouseEventArgs e)
        {
            this.BringToFront();
        }
    }
}
