using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace KronosDMS_Client.WPF
{
    /// <summary>
    /// Interaction logic for WPFApplication.xaml
    /// </summary>
    public partial class WPFApplication : Application
    {
        public void InitializeComponent() {

            #line 4 "..\..\..\App.xaml"
            this.StartupUri = new System.Uri("WPF/DocumentDesktop.xaml", System.UriKind.Relative);

            #line default
            #line hidden
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Create the startup window
            DocumentDesktop wnd = new DocumentDesktop();
            // Do stuff here, e.g. to the window
            wnd.Title = "Something else";
            // Show the window
            wnd.Show();
        }
    }
}
