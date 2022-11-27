using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client.Render.Controls
{
    public class Control
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public bool Disabled = false;

        // Action event functions
        public Action Click = null;

        public Control(string name)
        {
            Name = name;
            Text = name;
        }

        public Control(string name, string text)
        {
            Name = name;
            Text = text;
        }

        public void Draw() 
        {
            if (Disabled)
                ImGui.BeginDisabled();

            Render();

            if (Disabled)
                ImGui.EndDisabled();
        }
        protected virtual void Render() { }
    }
}
