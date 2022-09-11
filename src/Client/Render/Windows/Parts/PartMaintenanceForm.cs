using ImGuiNET;
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
    public class PartMaintenanceForm : ImGuiWindow
    {
        private MenuStrip Toolbar;
        private MenuStripButton ToolbarSave;
        private MenuStripSeparator ToolbarSeparator;
        private TextBox PartNumber;

        public PartMaintenanceForm() : base("Part Maintenance")
        {
            // Initialize controls
            Toolbar = new MenuStrip("Toolbar");
            ToolbarSave = new MenuStripButton("Save", ResourceManager.ImageSaveIcon);
            ToolbarSeparator = new MenuStripSeparator("Separator");
            PartNumber = new TextBox("Part Number");

            // Toolbar
            Toolbar.Items.AddRange(new MenuStripItem[]
            {
                ToolbarSave, ToolbarSeparator
            });

            // ToolbarSave
            ToolbarSave.Click = Save;

            // PartNumber
            PartNumber.CharacterCasing = CharacterCasing.Upper;

            // Add controls
            Controls.Add(Toolbar);
            Controls.Add(PartNumber);
        }

        protected override void Draw()
        {
            Toolbar.Draw();
            PartNumber.Draw();

            if (ImGui.BeginChild("test", Vector2.Zero, true))
            {
                ImGui.Text("Test");
                ImGui.EndChild();
            }
        }

        #region Event Handlers

        private void Save()
        {
            Logger.Log("Clicked the save button!", LogLevel.DEBUG);
        }

        #endregion
    }
}
