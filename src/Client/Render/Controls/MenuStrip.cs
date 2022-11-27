using ImGuiNET;
using KronosDMS.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        protected override void Render()
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

        protected override void Render()
        {
            if (ImGui.BeginMenu(Text))
            {
                foreach (MenuStripItem item in MenuItems)
                    item.Draw();
                ImGui.EndMenu();
            }
        }
    }

    public class MenuStripButton : MenuStripItem
    {
        private enum ButtonType
        {
            Text,
            Image
        }

        private ButtonType Type = ButtonType.Text;
        private Image Image;

        public MenuStripButton(string name, string text = "") : base(name, text)
        {
        }

        public MenuStripButton(string name, Image image) : base(name)
        {
            Type = ButtonType.Image;
            Image = image;
        }

        protected override void Render()
        {
            bool clicked = false;
            if (Type == ButtonType.Image)
            {
                ImGuiStylePtr style = ImGui.GetStyle();
                Vector2 size = new Vector2(ImGui.GetTextLineHeightWithSpacing());
                clicked = ImGui.ImageButton(Image.GetID(), size, Vector2.Zero, Vector2.One, 1, style.Colors[(int)ImGuiCol.MenuBarBg]);
            }
            else
                clicked = ImGui.Button(Text);

            if (clicked && Click != null)
                Click();
        }
    }

    public class MenuStripSeparator : MenuStripItem
    {
        public MenuStripSeparator(string name) : base(name)
        {
        }

        protected override void Render()
        {
            ImGui.Separator();
        }
    }

    public class MenuStrip : Control
    {
        public List<MenuStripItem> Items = new List<MenuStripItem>();

        public MenuStrip(string name) : base(name)
        {
        }

        protected override void Render()
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
