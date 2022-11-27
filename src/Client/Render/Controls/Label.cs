using ImGuiNET;
using KronosDMS_Client.Render.ImGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client.Render.Controls
{
    public class Label : Control
    {
        public ImGuiWindow Parent { get; set; }

        public Label(string name, string text = "") : base(name)
        {
            Text = text == "" ? name : text;
        }

        protected override void Render()
        {
            ImGui.Text(Text);
        }
    }
}
