using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client.Render.Windows.Components
{
    public enum CharacterCasing
    {
        Normal, Upper
    }

    public class TextBox
    {
        public string Name;
        public string Text;
        private float Width;
        private uint MaxLength;
        public bool ReadOnly = false;
        public CharacterCasing CharacterCasing = CharacterCasing.Normal;
        public bool Password = false;

        public TextBox(string name = "Textbox", string text = "", float width = 0.0f, uint maxlength = 1024)
        {
            Name = name;
            Text = text == null ? "" : text;
            Width = width;
            MaxLength = maxlength;
        }

        public bool Draw(bool displayName = true)
        {
            ImGuiStylePtr style = ImGui.GetStyle();

            if (Text == null)
                Text = "";

            ImGuiInputTextFlags flags = ImGuiInputTextFlags.EnterReturnsTrue;
            if (ReadOnly)
                flags |= ImGuiInputTextFlags.ReadOnly;
            if (CharacterCasing == CharacterCasing.Upper)
                flags |= ImGuiInputTextFlags.CharsUppercase;
            if (Password)
                flags |= ImGuiInputTextFlags.Password;


            if (displayName)
            {
                ImGui.AlignTextToFramePadding();
                ImGui.Text(Name);
                ImGui.SameLine();
            }

            if (Width != 0.0f)
                ImGui.PushItemWidth(Width);

            if (ReadOnly)
                ImGui.PushStyleColor(ImGuiCol.FrameBg, style.Colors[(int)ImGuiCol.TextDisabled]);

            bool enter = ImGui.InputText($"##{Name}", ref Text, MaxLength, flags);
            
            if (ReadOnly)
                ImGui.PopStyleColor();

            if (Width != 0.0f)
                ImGui.PopItemWidth();

            return enter;
        }
    }
}
