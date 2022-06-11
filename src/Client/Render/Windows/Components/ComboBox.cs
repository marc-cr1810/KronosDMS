using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client.Render.Windows.Components
{
    public class ComboBox
    {
        private string Name;
        public List<string> Items { get; set; }
        public int SelectedIndex = 0;
        public string Text = null;

        public Action SelectionChanged;

        public ComboBox(string[] items, string name = "ComboBox")
        {
            Items = items.ToList();
            Name = name;
            if (items.Length > 0)
                Text = items[0];
        }

        public void Draw()
        {
            if (ImGui.BeginCombo($"##{Name}", (Text is not null) ? Text : ""))
            {
                for (int n = 0; n < Items.Count(); n++)
                {
                    bool selected = (SelectedIndex == n);
                    if (ImGui.Selectable(Items[n], selected))
                    {
                        SelectedIndex = n;
                        Text = Items[n];
                        if (SelectionChanged != null)
                            SelectionChanged();
                    }

                    // Set the initial focus when opening the combo (scrolling + keyboard navigation focus)
                    if (selected)
                        ImGui.SetItemDefaultFocus();
                }
                ImGui.EndCombo();
            }
        }
    }
}
