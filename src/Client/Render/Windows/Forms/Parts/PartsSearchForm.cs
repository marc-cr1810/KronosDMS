using ImGuiNET;
using KronosDMS.Api.Endpoints;
using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using KronosDMS_Client.Render.Windows.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client.Render.Windows.Forms.Parts
{
    public class PartsSearchForm : ImGuiWindow
    {
        private TextBox PartNumber;
        private TextBox PartDescription;

        private ComboBox MakesComboBox;
        private ListView PartsListView;

        public PartsSearchForm() : base("Parts Search")
        {
            List<string> makes = new List<string>();
            makes.Add(""); // First item be blank to search all makes
            MakesSearchResponse response = new MakesSearch("").PerformRequestAsync().Result;
            foreach (KeyValuePair<string, Make> make in response.Makes)
            {
                makes.Add(make.Value.Name);
            }

            PartNumber = new TextBox("Part Number");
            PartNumber.CharacterCasing = CharacterCasing.Upper;
            PartDescription = new TextBox("Description");
            MakesComboBox = new ComboBox(makes.ToArray(), "Make");
            PartsListView = new ListView(new string[] { "Part Number", "Make", "Description"}, "parts_list");
        }

        protected override void Draw()
        {
            MakesComboBox.Draw();

            PartNumber.Draw();
            PartDescription.Draw();

            ImGui.SameLine();
            if (ImGui.Button("Search"))
                Search();

            ImGui.Spacing();

            PartsListView.Draw();
        }

        private void Search()
        {
            PartsSearchResponse response = new PartsSearch(MakesComboBox.Text, PartNumber.Text, PartDescription.Text).PerformRequestAsync().Result;

            if (!response.IsSuccess)
            {
                Log($"Failed to search for parts\n{response.RawMessage}", LogLevel.ERROR);
                return;
            }

            PartsListView.Items.Clear();

            foreach (KeyValuePair<string, Part> part in response.Parts)
            {
                ListViewItem partItem = PartsListView.AddItem(part.Key);
                partItem.AddSubItem(part.Value.Make);
                partItem.AddSubItem(part.Value.Description);
            };
        }
    }
}
