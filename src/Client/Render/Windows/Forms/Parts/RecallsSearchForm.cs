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
    public class RecallsSearchForm : Window
    {
        private Textbox RecallNumber;
        private Textbox RecallDescription;

        private ComboBox MakesComboBox;
        private ComboBox ModelsComboBox;
        private ListView RecallsListView;

        public RecallsSearchForm() : base("Recalls Search")
        {
            List<string> makes = new List<string>();
            makes.Add(""); // First item be blank to search all makes
            MakesSearchResponse response = new MakesSearch("").PerformRequestAsync().Result;
            foreach (KeyValuePair<string, Make> make in response.Makes)
            {
                makes.Add(make.Value.Name);
            }

            RecallNumber = new Textbox("Recall Number");
            RecallDescription = new Textbox("Description");
            MakesComboBox = new ComboBox(makes.ToArray(), "makes_combobox");
            ModelsComboBox = new ComboBox(new string[] { "" }, "models_combobox");
            MakesComboBox.SelectionChanged = UpdateModels;
            RecallsListView = new ListView(new string[] { "Recall Number", "Make", "Model", "Description" }, "recalls_list");
        }

        protected override void Draw()
        {
            ImGui.AlignTextToFramePadding();
            ImGui.Text("Make"); ImGui.SameLine();
            MakesComboBox.Draw();

            ImGui.AlignTextToFramePadding();
            ImGui.Text("Model"); ImGui.SameLine();
            ModelsComboBox.Draw();

            RecallNumber.Draw();
            RecallDescription.Draw();

            ImGui.SameLine();
            if (ImGui.Button("Search"))
                Search();

            ImGui.Spacing();

            RecallsListView.Draw();
        }

        private void Search()
        {
            RecallsSearchResponse response = new RecallsSearch(MakesComboBox.Text, ModelsComboBox.Text, RecallNumber.Text, RecallDescription.Text).PerformRequestAsync().Result;

            if (!response.IsSuccess)
            {
                Logger.Log($"Failed to search for recalls\n{response.RawMessage}", LogLevel.ERROR);
                return;
            }

            RecallsListView.Items.Clear();

            foreach (KeyValuePair<string, Recall> recall in response.Recalls)
            {
                ListViewItem recallItem = RecallsListView.AddItem(recall.Key);
                recallItem.AddSubItem(recall.Value.Make);
                recallItem.AddSubItem(recall.Value.Model);
                recallItem.AddSubItem(recall.Value.Description);
            };
        }

        private void UpdateModels()
        {
            ModelsComboBox.Items.Clear();

            if (MakesComboBox.Text == "")
                return;

            MakesSearchResponse response = new MakesSearch(MakesComboBox.Text).PerformRequestAsync().Result;
            if (response.Makes.Count > 0)
            {
                foreach (KeyValuePair<string, Model> model in response.Makes[MakesComboBox.Text].Models)
                {
                    ModelsComboBox.Items.Add(model.Key);
                }
            }
        }
    }
}
