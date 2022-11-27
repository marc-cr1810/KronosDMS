using ImGuiNET;
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
    public class PartMaintenanceForm : ImGuiWindow
    {
        private MenuStrip Toolbar;
        private MenuStripButton ToolbarSave;
        private MenuStripSeparator ToolbarSeparator;
        private MenuStripButton ToolbarReset;
        private TextBox PartNumber;
        private Label DetailsLabel;
        private ComboBox MakeComboBox;
        private TextBox PartDescription;
        private TextBox PartBinLocation;
        private TextBox PartPredecessor;
        private TextBox PartSuccessor;

        public Part SelectedPart = new Part();
        private bool NewPart = false;

        public PartMaintenanceForm() : base("Part Maintenance", 440, 270)
        {
            MinSize = new Vector2(440, 270);

            // Initialize controls
            Toolbar = new MenuStrip("Toolbar");
            ToolbarSave = new MenuStripButton("Save", ResourceManager.ImageSaveIcon);
            ToolbarSeparator = new MenuStripSeparator("Separator");
            ToolbarReset = new MenuStripButton("Reset", ResourceManager.ImageResetIcon);
            PartNumber = new TextBox("Part Number");
            DetailsLabel = new Label("DetailsLabel", "Details");
            MakeComboBox = new ComboBox("Makes", new string[] { "" });
            PartDescription = new TextBox("Description");
            PartBinLocation = new TextBox("Bin");
            PartPredecessor = new TextBox("Predecessor");
            PartSuccessor = new TextBox("Successor");

            // Toolbar
            Toolbar.Items.AddRange(new MenuStripItem[]
            {
                ToolbarSave, ToolbarSeparator, ToolbarReset
            });

            // ToolbarSave
            ToolbarSave.Click = Save;
            ToolbarSave.Disabled = true;

            // ToolbarReset
            ToolbarReset.Click = Reset;
            ToolbarReset.Disabled = true;

            // PartNumber
            PartNumber.CharacterCasing = CharacterCasing.Upper;
            PartNumber.EnterKeyPressed = Search;

            // MakeComboBox
            MakeComboBox.Disabled = true;

            // PartDescription
            PartDescription.Disabled = true;

            // PartBinLocation
            PartBinLocation.CharacterCasing = CharacterCasing.Upper;
            PartBinLocation.Disabled = true;

            // PartPredecessor
            PartPredecessor.CharacterCasing = CharacterCasing.Upper;
            PartPredecessor.Disabled = true;

            // PartSuccessor
            PartSuccessor.CharacterCasing = CharacterCasing.Upper;
            PartSuccessor.Disabled = true;

            // Add controls
            Controls.Add(Toolbar);
            Controls.Add(PartNumber);
            Controls.Add(DetailsLabel);
            Controls.Add(MakeComboBox);
            Controls.Add(PartDescription);
            Controls.Add(PartBinLocation);
            Controls.Add(PartPredecessor);
            Controls.Add(PartSuccessor);
        }

        public PartMaintenanceForm(string number, string make) : this()
        {
            SearchPart(number, make);
        }

        protected override void Draw()
        {
            Toolbar.Draw();
            PartNumber.Draw();

            if (ImGui.BeginChild("group", Vector2.Zero, true))
            {
                DetailsLabel.Draw();
                MakeComboBox.Draw();
                PartDescription.Draw();
                PartBinLocation.Draw();
                PartPredecessor.Draw();
                PartSuccessor.Draw();

                ImGui.EndChild();
            }
        }

        private void SearchPart(string number, string make)
        {
            PartsSearchResponse response = new PartsSearch(make, number, "").PerformRequestAsync().Result;
            if (response.Parts.Count == 1)
            {
                FillDetails(response.Parts.ElementAt(0).Value);
                return;
            }
            else if (response.Parts.Count > 1)
            {
                WindowManager.OpenChild(this, new PartsSearchForm(PartNumber.Text));
            }
            else
            {
                MessageBox.ShowDialog(this,
                    $"Part number \"{PartNumber.Text}\" does not exist on file.\n" +
                    $"Would you like to create it?",
                    "Create a new part?", MessageBoxButtons.YesNo, MessageBox_CreateNewPart);
            }
        }

        private void FillDetails(Part part)
        {
            SelectedPart = part;

            PartNumber.Text = SelectedPart.Number;
            PartNumber.Disabled = true;

            MakesSearchResponse makes = new MakesSearch("").PerformRequestAsync().Result;
            foreach (KeyValuePair<string, Make> make in makes.Makes)
                MakeComboBox.Items.Add(make.Value.Name);

            PartDescription.Text = SelectedPart.Description;
            MakeComboBox.SetItem(SelectedPart.Make, false);
            PartBinLocation.Text = SelectedPart.Bin;
            PartPredecessor.Text = SelectedPart.Predecessor;
            PartSuccessor.Text = SelectedPart.Successor;

            PartDescription.Disabled = false;
            MakeComboBox.Disabled = false;
            PartBinLocation.Disabled = false;
            PartPredecessor.Disabled = false;
            PartSuccessor.Disabled = false;

            ToolbarSave.Disabled = false;
            ToolbarReset.Disabled = false;
        }

        #region Event Handlers

        private void Save()
        {
            Log("Clicked the save button!", LogLevel.DEBUG);
            if (SelectedPart.Number is null)
                return;

            Response response;
            
        }

        private void Reset()
        {
            SelectedPart = new Part();

            PartNumber.Text = "";
            PartNumber.Disabled = false;

            MakeComboBox.Items.Clear();
            MakeComboBox.Items.Add("");

            PartDescription.Text = "";
            MakeComboBox.SetItem("", false);
            PartBinLocation.Text = "";
            PartPredecessor.Text = "";
            PartSuccessor.Text = "";

            PartDescription.Disabled = true;
            MakeComboBox.Disabled = true;
            PartBinLocation.Disabled = true;
            PartPredecessor.Disabled = true;
            PartSuccessor.Disabled = true;

            ToolbarSave.Disabled = true;
            ToolbarReset.Disabled = true;

            NewPart = false;
        }

        private void Search()
        {
            SearchPart(PartNumber.Text, "");
        }

        private void MessageBox_CreateNewPart(DialogResult result)
        {
            if (result == DialogResult.Yes)
            {
                Part part = new Part();
                part.Number = PartNumber.Text;
                FillDetails(part);
                NewPart = true;
                return;
            }
            else if (result == DialogResult.No)
            {
                WindowManager.OpenChild(this, new PartsSearchForm());
                return;
            }

            Log("Unexpected dialog result response!", LogLevel.ERROR, $"Dialog response was \"{result.ToString()}\", excpected \"Yes\" or \"No\"");
        }

        #endregion
    }
}
