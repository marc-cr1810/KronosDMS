using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client.Render.Controls
{
    public enum CharacterCasing
    {
        Normal, Upper
    }

    public class TextBox : Control
    {
        private float Width;
        private uint MaxLength;
        public bool ReadOnly = false;
        public CharacterCasing CharacterCasing = CharacterCasing.Normal;
        public bool Password = false;

        // Action event functions
        public Action EnterKeyPressed = null;

        public TextBox(string name, string text = "", float width = 0.0f, uint maxlength = 1024) : base(name)
        {
            Text = text == "" ? "" : text;
            Width = width;
            MaxLength = maxlength;
        }

        protected override void Render()
        {
            if (Text == null)
                Text = "";

            ImGuiInputTextFlags flags = ImGuiInputTextFlags.EnterReturnsTrue;
            if (ReadOnly)
                flags |= ImGuiInputTextFlags.ReadOnly;
            if (CharacterCasing == CharacterCasing.Upper)
                flags |= ImGuiInputTextFlags.CharsUppercase;
            if (Password)
                flags |= ImGuiInputTextFlags.Password;
            
            ImGui.AlignTextToFramePadding();
            ImGui.Text(Name);
            ImGui.SameLine();

            if (Width != 0.0f)
                ImGui.PushItemWidth(Width);

            string text = Text;
            bool enter = ImGui.InputText($"##{Name}", ref text, MaxLength, flags);
            Text = text;

            if (ReadOnly)
                ImGui.PopStyleColor();

            if (Width != 0.0f)
                ImGui.PopItemWidth();

            if (enter && EnterKeyPressed != null)
                EnterKeyPressed();
        }
    }
}
