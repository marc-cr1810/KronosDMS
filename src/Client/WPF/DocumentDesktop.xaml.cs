using AvalonDock.Layout;
using KronosDMS_Client.WPF.Windows;
using KronosDMS_Client.WPF.Windows.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KronosDMS_Client.WPF
{
    /// <summary>
    /// Interaction logic for DocumentDesktop.xaml
    /// </summary>
    public partial class DocumentDesktop : Window
    {
        public DocumentDesktop()
        {
            InitializeComponent();
        }

        public void ShowWindow(WPFWindow window, WPFWindow parent = null)
        {
            if (window == null)
                return;

            LayoutDocumentPane plane = dockManager.Layout.Descendents().OfType<LayoutDocumentPane>().FirstOrDefault();
            plane.Children.Add(window.Document);
        }

        private void PartSearch_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow(new WPFWindow("Test Parts", new TestContent()));
        }
    }
}
