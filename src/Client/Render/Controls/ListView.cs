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
    public class ListView : Control
    {
        public List<string> Columns { get; set; }
        public List<ListViewItem> Items { get; set; }
        public int SelectedIndex = -1;
        public ContextMenu ContextMenuStrip { get; set; } = null;

        public Action<ListViewItem> DoubleClick;

        public ListView(string name, string[] columns) : base(name)
        {
            Items = new List<ListViewItem>();
            Columns = columns.ToList();
            Name = name;
        }

        protected override void Render()
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

                ImGui.TableHeadersRow();

                for (int row_n = 0; row_n < Items.Count(); row_n++)
                {
                    ListViewItem item = Items[row_n];

                    bool selected = item.Index == SelectedIndex;
                    ImGui.PushID(item.Index);
                    ImGui.TableNextRow(ImGuiTableRowFlags.None, 0.0f);

                    ImGuiSelectableFlags selectableFlags = ImGuiSelectableFlags.SpanAllColumns | ImGuiSelectableFlags.AllowItemOverlap | ImGuiSelectableFlags.AllowDoubleClick;

                    ImGui.TableSetColumnIndex(0);
                    if (ImGui.Selectable(item.Text, selected, selectableFlags, Vector2.Zero))
                    {
                        SelectedIndex = item.Index;
                        if (ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left))
                        {
                            if (DoubleClick != null)
                                DoubleClick(item);
                        }
                    }

                    if (ImGui.IsItemHovered() && ImGui.IsMouseReleased(ImGuiMouseButton.Right))
                    {
                        SelectedIndex = item.Index;
                        if (ContextMenuStrip != null)
                            ContextMenuStrip.Open();
                    }

                    // Draw the context menu strip here
                    if (ContextMenuStrip != null)
                        ContextMenuStrip.Draw();

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

        public ListViewItem AddItem(string text)
        {
            ListViewItem item = new ListViewItem(text);
            item.Index = Items.Count();
            Items.Add(item);
            return item;
        }

        public ListViewItem GetItem(int index)
        {
            return Items[index];
        }
    }

    public class ListViewItem : Control
    {
        public int Index { get; set; }
        public List<ListViewSubItem> SubItems { get; set; }

        public ListViewItem(string name) : base(name)
        {
            SubItems = new List<ListViewSubItem>();
        }

        public ListViewSubItem AddSubItem(string text)
        {
            ListViewSubItem subItem = new ListViewSubItem(text);
            SubItems.Add(subItem);
            return subItem;
        }
    }

    public class ListViewSubItem : Control
    {
        public ListViewSubItem(string name) : base(name)
        {
        }
    }
}
