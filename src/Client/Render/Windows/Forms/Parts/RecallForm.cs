using ImGuiNET;
using KronosDMS_Client.Render.Windows.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client.Render.Windows.Forms.Parts
{
    public class RecallForm : Window
    {
        private Textbox RecallNumber;

        public RecallForm() : base("Recall")
        {
            RecallNumber = new Textbox("Recall Number", "", 152, 16);
        }

        protected override void Draw()
        {
            RecallNumber.Draw();

            ImGui.Separator();

            ImGui.Text("Make");
        }
    }
}
