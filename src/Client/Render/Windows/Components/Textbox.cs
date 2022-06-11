using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client.Render.Windows.Components
{
    public class Textbox
    {
        public string Name;
        public string Text;
        private float Width;
        private uint MaxLength;

        public Textbox(string name = "Textbox", string text = "", float width = 0.0f, uint maxlength = 1024)
        {
            Name = name;
            Text = text;
            Width = width;
            MaxLength = maxlength;
        }

        public void Draw(bool displayName = true)
        {
            if (displayName)
            {
                ImGui.AlignTextToFramePadding();
                ImGui.Text(Name);
                ImGui.SameLine();
            }
            if (Width != 0.0f)
                ImGui.PushItemWidth(Width);
            ImGui.InputText($"##{Name}", ref Text, MaxLength);
            if (Width != 0.0f)
                ImGui.PopItemWidth();
        }
    }
}
