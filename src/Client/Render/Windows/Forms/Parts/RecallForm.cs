using ImGuiNET;
using KronosDMS;
using KronosDMS.Api.Endpoints;
using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using KronosDMS_Client.Render.Windows.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client.Render.Windows.Forms.Parts
{
    public class RecallForm : ImGuiWindow
    {
        private bool NewRecall = false;
        private Recall SelectedRecall = new Recall();
        private int SelectedOption = 0;

        private TextBox RecallNumber;
        private TextBox RecallDescription;
        private TextBox RecallNote;
        private ComboBox MakesComboBox;
        private ComboBox ModelsComboBox;
        private ComboBox OptionsComboBox;
        private ListView PartsList;

        public RecallForm(Recall recall = new Recall()) : base("Recall", 632, 528)
        {
            List<string> makes = new List<string>();
            makes.Add(""); // First item be blank to search all makes
            MakesSearchResponse response = new MakesSearch("").PerformRequestAsync().Result;
            foreach (KeyValuePair<string, Make> make in response.Makes)
            {
                makes.Add(make.Value.Name);
            }

            RecallNumber = new TextBox("Recall Number", "", 152, 16);
            RecallDescription = new TextBox("Description");
            RecallNote = new TextBox("Note");
            MakesComboBox = new ComboBox(makes.ToArray(), "Make");
            MakesComboBox.SelectionChanged = UpdateModels;
            ModelsComboBox = new ComboBox(new string[] { "" }, "Model");
            OptionsComboBox = new ComboBox(new string[] { }, "Option");
            PartsList = new ListView(new string[] { "Part Number", "Qty", "Make", "Description", "Note" }, "parts_list");

            if (recall.Number is not null)
            {
                FillDetails(recall);
            }
        }

        private void FillDetails(Recall recall)
        {
            if (recall.Number is null)
                return;
            NewRecall = false;

            if (recall.Options is null)
            {
                recall.Options = new List<KronosDMS.PartsOption>();
                recall.Options.Add(new KronosDMS.PartsOption("Default", new List<KronosDMS.PartQuantityPairNote>()));
            }

            SelectedRecall = recall;

            Title = $"Recall | {recall.Number} \"{recall.Description}\"{(SelectedRecall.Locked ? "" : " - Editing")}";

            MakesComboBox.Items.Clear();
            MakesSearchResponse makes = new MakesSearch("").PerformRequestAsync().Result;
            foreach (KeyValuePair<string, Make> make in makes.Makes)
                MakesComboBox.Items.Add(make.Value.Name);

            OptionsComboBox.Items.Clear();
            foreach (PartsOption option in recall.Options)
                OptionsComboBox.Items.Add(option.Name);
            OptionsComboBox.SelectedIndex = SelectedOption = 0;
            OptionsComboBox.SetItem(SelectedOption);

            RecallNumber.Text = SelectedRecall.Number;
            MakesComboBox.SetItem(SelectedRecall.Make);
            UpdateModels();
            ModelsComboBox.SetItem(SelectedRecall.Model);
            RecallDescription.Text = SelectedRecall.Description;
            RecallNote.Text = SelectedRecall.AttentionNote;

            // Set lock state

            FillPartsList(SelectedRecall.Options[SelectedOption]);

            // Message about note
        }

        private void FillPartsList(PartsOption option)
        {
            PartsList.Items.Clear();
            foreach (PartQuantityPairNote part in option.Parts)
            {
                PartsSearchResponse response = new PartsSearch("", part.Number, "").PerformRequestAsync().Result;
                Part p = response.Parts.ElementAt(0).Value;
                ListViewItem partItem = PartsList.AddItem(part.Number);
                partItem.Text = p.Number;
                partItem.AddSubItem(part.Quantity.ToString());
                partItem.AddSubItem(p.Make);
                partItem.AddSubItem(p.Description);
                partItem.AddSubItem(part.Note);
            };
        }

        protected override void Draw()
        {
            if (RecallNumber.Draw())
                Log(RecallNumber.Text);
            OptionsComboBox.Draw();

            ImGui.Separator();

            MakesComboBox.Draw();
            ModelsComboBox.Draw();

            RecallDescription.Draw();
            RecallNote.Draw();

            ImGui.Spacing();

            PartsList.Draw();
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
