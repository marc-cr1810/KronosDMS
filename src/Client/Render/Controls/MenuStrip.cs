using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client.Render.Controls
{
    public class MenuStripItem : Control
    {
        public MenuStripItem(string name, string text = "") : base(name)
        {
            Text = text == "" ? name : text;
        }

        public override void Draw()
        {
            if (ImGui.MenuItem(Text))
            {
                if (Click != null)
                    Click();
            }
        }
    }

    public class MenuStripMenuItem : MenuStripItem
    {
        public List<MenuStripItem> MenuItems = new List<MenuStripItem>();

        public MenuStripMenuItem(string name, string text = "") : base(name, text)
        {

        }

        public override void Draw()
        {
            if (ImGui.BeginMenu(Text))
            {
                foreach (MenuStripItem item in MenuItems)
                    item.Draw();
                ImGui.EndMenu();
            }
        }
    }

    public class MenuStrip : Control
    {
        public List<MenuStripItem> Items = new List<MenuStripItem>();

        public MenuStrip(string name) : base(name)
        {
        }

        public override void Draw()
        {
            if (ImGui.BeginMenuBar())
            {
                foreach (Control control in Items)
                {
                    control.Draw();
                }

                ImGui.EndMenuBar();
            }
        }
    }
}
