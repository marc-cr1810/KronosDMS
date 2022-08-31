using ImGuiNET;
using KronosDMS_Client.Render.ImGUI;
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
            ImGuiWindow window1 = new ImGuiWindow("Window 1");
            ImGuiWindow window2 = new ImGuiWindow("Window 2");

            window1.Disabled = true;

            WindowManager.Open(window1);
            WindowManager.Open(window2);
        }

        protected override void Draw()
        {
            WindowManager.Render();
        }

        protected override void Update()
        {
            WindowManager.Update();
        }
    }
}
