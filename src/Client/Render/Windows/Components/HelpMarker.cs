using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client.Render.Windows.Components
{
    public class HelpMarker
    {
        public string Text;

        public HelpMarker(string text)
        {
            Text = text;
        }

        public void Draw()
        {
            ImGui.TextDisabled("(?)");
            if (ImGui.IsItemHovered())
            {
                ImGui.BeginTooltip();
                ImGui.PushTextWrapPos(ImGui.GetFontSize() * 35.0f);
                ImGui.TextUnformatted(Text);
                ImGui.PopTextWrapPos();
                ImGui.EndTooltip();
            }
        }
    }
}
