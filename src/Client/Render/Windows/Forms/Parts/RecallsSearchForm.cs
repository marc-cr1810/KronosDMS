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
        private TextBox RecallNumber;
        private TextBox RecallDescription;

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

            RecallNumber = new TextBox("Recall Number");
            RecallNumber.CharacterCasing = CharacterCasing.Upper;
            RecallDescription = new TextBox("Description");
            MakesComboBox = new ComboBox(makes.ToArray(), "Make");
            MakesComboBox.SelectionChanged = UpdateModels;
            ModelsComboBox = new ComboBox(new string[] { "" }, "Model");
            RecallsListView = new ListView(new string[] { "Recall Number", "Make", "Model", "Description" }, "recalls_list");
            RecallsListView.DoubleClick += OpenRecallForm;
        }

        protected override void Draw()
        {
            MakesComboBox.Draw();
            ModelsComboBox.Draw();

            if (RecallNumber.Draw())
                Search();
            if (RecallDescription.Draw())
                Search();

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
                Log($"Failed to search for recalls\n{response.RawMessage}", LogLevel.ERROR);
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

        private void OpenRecallForm(ListViewItem item)
        {
            string id = item.Text;
            string number = item.Text;
            string make = item.SubItems[0].Text;
            string model = item.SubItems[1].Text;
            string description = item.SubItems[2].Text;

            RecallsSearchResponse response = new RecallsSearch(make, model, number, description).PerformRequestAsync().Result;
            Recall result = response.Recalls[id];

            Log($"Opening recall form for recall number \"{item.Text}\"");
            WindowManager.Open(new RecallForm(result));
            WindowManager.Close(this);
        }
    }
}
