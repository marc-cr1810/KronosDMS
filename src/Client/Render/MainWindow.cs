using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client.Render
{
    public class MainWindow : Window
    {
        public MainWindow(string title, int width = 1280, int height = 720) : base(title, width, height)
        {
        }

        protected override void Draw()
        {
            ImGui.Text("Test");
        }
    }
}
