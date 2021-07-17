using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KronosDMS_Client.Forms
{
    public partial class Window : Form
    {
        public Window()
        {
            this.BackColor = Client.ActiveTheme.Colors.Background;
        }
    }
}
