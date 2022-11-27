using AvalonDock.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KronosDMS_Client.WPF.Windows
{
    public partial class WPFWindow
    {
        public LayoutDocument Document { get; private set; }

        public WPFWindow(string title, UserControl content)
        {
            Document = new LayoutDocument()
            {
                Title = title,
                Content = content
            };
        }
    }
}
