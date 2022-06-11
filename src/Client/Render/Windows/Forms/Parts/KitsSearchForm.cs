﻿using ImGuiNET;
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
    public class KitsSearchForm : Window
    {
        private Textbox KitNumber;
        private Textbox KitDescription;

        private ComboBox MakesComboBox;
        private ComboBox ModelsComboBox;
        private ListView KitsListView;

        public KitsSearchForm() : base("Kits Search")
        {
            List<string> makes = new List<string>();
            makes.Add(""); // First item be blank to search all makes
            MakesSearchResponse response = new MakesSearch("").PerformRequestAsync().Result;
            foreach (KeyValuePair<string, Make> make in response.Makes)
            {
                makes.Add(make.Value.Name);
            }

            KitNumber = new Textbox("Kit Number");
            KitDescription = new Textbox("Description");
            MakesComboBox = new ComboBox(makes.ToArray(), "makes_combobox");
            ModelsComboBox = new ComboBox(new string[] { "" }, "models_combobox");
            MakesComboBox.SelectionChanged = UpdateModels;
            KitsListView = new ListView(new string[] { "Kit Number", "Make", "Model", "Description" }, "kits_list");
        }

        protected override void Draw()
        {
            ImGui.AlignTextToFramePadding();
            ImGui.Text("Make"); ImGui.SameLine();
            MakesComboBox.Draw();

            ImGui.AlignTextToFramePadding();
            ImGui.Text("Model"); ImGui.SameLine();
            ModelsComboBox.Draw();

            KitNumber.Draw();
            KitDescription.Draw();

            ImGui.SameLine();
            if (ImGui.Button("Search"))
                Search();

            ImGui.Spacing();

            KitsListView.Draw();
        }

        private void Search()
        {
            KitsSearchResponse response = new KitsSearch(MakesComboBox.Text, ModelsComboBox.Text, KitNumber.Text, KitDescription.Text).PerformRequestAsync().Result;

            if (!response.IsSuccess)
            {
                Logger.Log($"Failed to search for kits\n{response.RawMessage}", LogLevel.ERROR);
                return;
            }

            KitsListView.Items.Clear();

            foreach (KeyValuePair<string, Kit> kit in response.Kits)
            {
                ListViewItem kitItem = KitsListView.AddItem(kit.Key);
                kitItem.AddSubItem(kit.Value.Make);
                kitItem.AddSubItem(kit.Value.Model);
                kitItem.AddSubItem(kit.Value.Description);
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