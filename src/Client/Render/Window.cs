using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client.Render
{
    public class Window
    {
        public static uint NextID = 0;
        public uint ID { get; private set; }
        public string Title { get; set; }
        public bool Open = true;

        private Vector2 Size { get; set; }

        public Window(string title = "Window", int width = 640, int height = 468)
        {
            ID = NextID++;
            Title = title;
            Size = new Vector2(width, height);
        }

        public void Show()
        {
            ImGui.SetNextWindowSize(Size, ImGuiCond.FirstUseEver);
            if (ImGui.Begin($"{Title}##{ID}", ref Open, ImGuiWindowFlags.NoSavedSettings))
            {
                Draw();
                ImGui.End();
            }
        }

        protected virtual void Draw() { }
    }
}
