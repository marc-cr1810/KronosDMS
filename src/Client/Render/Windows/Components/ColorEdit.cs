using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client.Render.Windows.Components
{
    public class ColorEdit
    {
        public string Label;
        private ImGuiCol ImGuiCol;

        public ColorEdit(string label, ImGuiCol imGuiCol)
        {
            Label = label;
            ImGuiCol = imGuiCol;
        }

        public void Draw()
        {
            ImGuiStylePtr style = ImGui.GetStyle();

            ImGui.ColorEdit4(Label, ref style.Colors[(int)ImGuiCol]);
        }

    }
}
