using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client.Render.Windows.Components
{
    public class FloatInput
    {
        public string Name;
        private float Value;

        public FloatInput(string name = "FloatInput", float value = 0.0f)
        {
            Name = name;
            Value = value;
        }

        public void Draw(bool displayName = true)
        {
            if (displayName)
            {
                ImGui.AlignTextToFramePadding();
                ImGui.Text(Name);
                ImGui.SameLine();
            }

            ImGui.DragFloat($"##{Name}", ref Value);
        }
    }
}
