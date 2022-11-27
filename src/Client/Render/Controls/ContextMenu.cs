using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client.Render.Controls
{
    public class ContextMenuItem : Control
    {
        public ContextMenuItem(string name, string text = "") : base(name, text)
        {
            Text = text != "" ? text : name;
        }

        protected override void Render()
        {
            ImGui.Text(Text);
        }
    }

    public class ContextMenuButton : ContextMenuItem
    {
        public ContextMenuButton(string name, string text = "") : base(name, text)
        {
        }

        protected override void Render()
        {
            if (ImGui.Selectable(Text))
            {
                if (Click != null)
                    Click();
            }
        }
    }

    public class ContextMenu : Control
    {
        public List<ContextMenuItem> Items = new List<ContextMenuItem>();

        public ContextMenu(string name) : base(name)
        {
        }

        protected override void Render()
        {
            if (ImGui.BeginPopup(Name))
            {
                foreach (ContextMenuItem item in Items)
                    item.Draw();
                ImGui.EndPopup();
            }
        }

        public void Open()
        {
            ImGui.OpenPopup(Name);
        }
    }
}
