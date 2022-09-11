using KronosDMS.Api.Endpoints;
using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using KronosDMS.Utils;
using KronosDMS_Client.Render.Controls;
using KronosDMS_Client.Render.ImGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client.Render.Windows.Parts
{
    public class PartsSearchForm : ImGuiWindow
    {
        private ComboBox MakesComboBox;
        private TextBox PartNumber;
        private TextBox PartDescription;
        private ListView PartList;
        private ContextMenu PartListMenu;
        private ContextMenuButton PartListMenuCopy;
        private ContextMenuButton PartListMenuEdit;
        private ContextMenuButton PartListMenuDelete;

        public PartsSearchForm() : base("Parts Search")
        {
            List<string> makes = new List<string>();
            makes.Add(""); // First item be blank to search all makes
            MakesSearchResponse response = new MakesSearch("").PerformRequestAsync().Result;
            foreach (KeyValuePair<string, Make> make in response.Makes)
            {
                makes.Add(make.Value.Name);
            }

            MinSize = new Vector2(458, 278);

            // Initialize controls
            MakesComboBox = new ComboBox("Make", makes.ToArray());
            PartNumber = new TextBox("Part Number");
            PartDescription = new TextBox("Description");
            PartList = new ListView("PartsList", new string[] { "Part Number", "Make", "Description" });
            PartListMenu = new ContextMenu("PartsListMenu");
            PartListMenuCopy = new ContextMenuButton("PartListMenuCopy", "Copy");
            PartListMenuEdit = new ContextMenuButton("PartListMenuEdit", "Edit");
            PartListMenuDelete = new ContextMenuButton("PartListMenuDelete", "Delete");

            // MakesComboBox
            MakesComboBox.SelectionChanged = Search;

            // PartNumber
            PartNumber.CharacterCasing = CharacterCasing.Upper;
            PartNumber.EnterKeyPressed = Search;

            // PartDescription
            PartDescription.EnterKeyPressed = Search;

            // PartList
            PartList.ContextMenuStrip = PartListMenu;

            // PartListMenu
            PartListMenu.Items.AddRange(new ContextMenuItem[]
            {
                PartListMenuCopy, PartListMenuEdit, PartListMenuDelete
            });

            // PartListMenuCopy
            PartListMenuCopy.Click = PartListMenuCopy_Click;

            // PartListMenuEdit
            PartListMenuEdit.Click = PartListMenuEdit_Click;

            // PartListMenuDelete
            PartListMenuDelete.Click = PartListMenuDelete_Click;

            // Add controls
            Controls.Add(MakesComboBox);
            Controls.Add(PartNumber);
            Controls.Add(PartDescription);
            Controls.Add(PartList);
            Controls.Add(PartListMenu);
        }

        protected override void Draw()
        {
            MakesComboBox.Draw();
            PartNumber.Draw();
            PartDescription.Draw();
            PartList.Draw();
        }

        #region Event Handlers

        private void Search()
        {
            PartsSearchResponse response = new PartsSearch(MakesComboBox.Text, PartNumber.Text, PartDescription.Text).PerformRequestAsync().Result;

            if (!response.IsSuccess)
            {
                Log($"Failed to search for parts\n{response.RawMessage}", LogLevel.ERROR);
                return;
            }

            PartList.Items.Clear();

            foreach (KeyValuePair<string, Part> part in response.Parts)
            {
                ListViewItem partItem = PartList.AddItem(part.Key);
                partItem.AddSubItem(part.Value.Make);
                partItem.AddSubItem(part.Value.Description);
            };
        }

        private void PartListMenuCopy_Click()
        {
            Client.SetClipboard(PartList.GetItem(PartList.SelectedIndex).Text);
        }

        private void PartListMenuEdit_Click()
        {
            Logger.Log($"Edit Part {PartList.GetItem(PartList.SelectedIndex).Text}", LogLevel.DEBUG);
        }

        private void PartListMenuDelete_Click()
        {
            Logger.Log($"Delete Part {PartList.GetItem(PartList.SelectedIndex).Text}", LogLevel.DEBUG);
        }

        #endregion
    }
}
