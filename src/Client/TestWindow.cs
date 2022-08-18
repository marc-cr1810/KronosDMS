using ImGuiNET;
using KronosDMS_Client.Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client
{
    internal class TestWindow : Window
    {
        public TestWindow(string title, int width = 1280, int height = 720) 
            : base(title, width, height)
        {
        }

        protected override void Draw()
        {           
            ImGui.Text("Test");
        }
    }
}
