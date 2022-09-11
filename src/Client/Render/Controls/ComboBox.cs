using ImGuiNET;
using KronosDMS.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client.Render.Controls
{
    public class ComboBox : Control
    {
        public List<string> Items { get; set; }
        private int _SelectedIndex;
        public int SelectedIndex { 
            get
            {
                return _SelectedIndex;
            }
            set
            {
                if (Items is null)
                {
                    Logger.Log($"Items in ComboBox \"{Name}\" is null");
                    _SelectedIndex = -1;
                    return;
                }
                if (value >= Items.Count)
                {
                    _SelectedIndex = Items.Count - 1;
                    return;
                }

                _SelectedIndex = value;
                Text = Items[_SelectedIndex];
                if (SelectionChanged != null)
                    SelectionChanged();
            }
        }

        // Action event functions
        public Action SelectionChanged;

        public ComboBox(string name, string[] items) : base(name)
        {
            Items = items.ToList();
            SelectedIndex = 0;
        }

        public override void Draw()
        {
            ImGui.AlignTextToFramePadding();
            ImGui.Text(Name);
            ImGui.SameLine();

            if (ImGui.BeginCombo($"##{Name}", (Text is not null) ? Text : ""))
            {
                for (int n = 0; n < Items.Count(); n++)
                {
                    bool selected = (SelectedIndex == n);
                    if (ImGui.Selectable(Items[n], selected))
                    {
                        SelectedIndex = n;
                    }

                    // Set the initial focus when opening the combo (scrolling + keyboard navigation focus)
                    if (selected)
                        ImGui.SetItemDefaultFocus();
                }
                ImGui.EndCombo();
            }
        }

        public void SetItem(int i, bool callback = true)
        {
            SelectedIndex = i;
        }

        public void SetItem(string s, bool callback = true)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i] == s)
                {
                    SetItem(i, callback);
                    break;
                }
            }
        }
    }
}
