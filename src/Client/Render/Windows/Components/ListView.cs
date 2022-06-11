using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client.Render.Windows.Components
{
    public class ListView
    {
        private string Name;
        public List<string> Columns { get; set; }
        public List<ListViewItem> Items { get; set; }
        public int SelectedIndex = -1;

        public ListView(string[] columns, string name = "ListView")
        {
            Items = new List<ListViewItem>();
            Columns = columns.ToList();
            Name = name;
        }

        public ListViewItem AddItem(string text)
        {
            ListViewItem item = new ListViewItem(text);
            item.Index = Items.Count();
            Items.Add(item);
            return item;
        }

        public void Draw()
        {
            ImGuiTableFlags flags =
                ImGuiTableFlags.Resizable | ImGuiTableFlags.Reorderable | ImGuiTableFlags.Hideable
                | ImGuiTableFlags.Sortable | ImGuiTableFlags.SortMulti
                | ImGuiTableFlags.RowBg | ImGuiTableFlags.Borders
                | ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY
                | ImGuiTableFlags.SizingFixedFit;

            if (ImGui.BeginTable(Name, Columns.Count, flags))
            {
                for (int i = 0; i < Columns.Count; i++)
                {
                    ImGuiTableColumnFlags columnFlags = ((i == 0) ? (ImGuiTableColumnFlags.DefaultSort | ImGuiTableColumnFlags.NoHide) : 0) |
                        ((i == Columns.Count - 1) ? ImGuiTableColumnFlags.WidthStretch : ImGuiTableColumnFlags.WidthFixed);
                    ImGui.TableSetupColumn(Columns[i], columnFlags, 0.0f, (uint)i);
                }
                ImGui.TableSetupScrollFreeze(1, 1);

                //ImGui.TableSetupColumn("ID", ImGuiTableColumnFlags.DefaultSort | ImGuiTableColumnFlags.WidthFixed | ImGuiTableColumnFlags.NoHide, 0.0f, 0);
                //ImGui.TableSetupColumn("Name", ImGuiTableColumnFlags.WidthFixed, 0.0f, 1);
                //ImGui.TableSetupColumn("Action", ImGuiTableColumnFlags.WidthStretch, 0.0f, 2);

                ImGui.TableHeadersRow();

                for (int row_n = 0; row_n < Items.Count(); row_n++)
                {
                    ListViewItem item = Items[row_n];

                    bool selected = item.Index == SelectedIndex;
                    ImGui.PushID(item.Index);
                    ImGui.TableNextRow(ImGuiTableRowFlags.None, 0.0f);

                    ImGui.TableSetColumnIndex(0);
                    ImGui.Selectable(item.Text, selected, ImGuiSelectableFlags.SpanAllColumns | ImGuiSelectableFlags.AllowItemOverlap, Vector2.Zero);

                    for (int i = 1; i < Columns.Count; i++)
                    {
                        if (i < item.SubItems.Count + 1)
                        {
                            ListViewSubItem subItem = item.SubItems[i - 1];
                            ImGui.TableSetColumnIndex(i);
                            ImGui.TextUnformatted(subItem.Text);
                            continue;
                        }
                        ImGui.TableSetColumnIndex(i);
                        ImGui.TextUnformatted("");
                    }

                    ImGui.PopID();
                }

                ImGui.EndTable();
            }
        }
    }

    public class ListViewItem
    {
        public int Index { get; set; }
        public List<ListViewSubItem> SubItems { get; set; }

        public string Text = "";

        public ListViewItem(string text)
        {
            SubItems = new List<ListViewSubItem>();
            Text = text;
        }

        public ListViewSubItem AddSubItem(string text)
        {
            ListViewSubItem subItem = new ListViewSubItem(text);
            SubItems.Add(subItem);
            return subItem;
        }
    }

    public class ListViewSubItem
    {
        public string Text = "";

        public ListViewSubItem(string text)
        {
            Text = text;
        }
    }
}
