using ImGuiNET;
using KronosDMS_Client.Render.ImGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client.Render
{
    public enum MessageBoxButtons
    {
        Ok,
        YesNo
    }

    public enum DialogResult
    {
        Ok,
        Yes, No
    }

    public class MessageBox : ImGuiWindow
    {
        string Content;
        MessageBoxButtons Buttons;
        Action<DialogResult> OnCloseDialog;

        public MessageBox(string content, string title = "Message", MessageBoxButtons buttons = MessageBoxButtons.Ok, Action<DialogResult> onClose = null) 
            : base(title, 0, 0)
        {
            Content = content;
            Buttons = buttons;
            OnCloseDialog = onClose;

            ImGuiStylePtr style = ImGui.GetStyle();
            Vector2 contentSize = ImGui.CalcTextSize(content);
            Vector2 minSize = new Vector2(
                (contentSize.X + style.FramePadding.X * 2.0f + style.WindowPadding.X) / 2, 
                contentSize.Y * 6 + style.FramePadding.Y * 4.0f + style.WindowPadding.Y * 2);
            MinSize = minSize;
        }

        protected override void Draw()
        {
            ImGui.TextWrapped(Content);

            ImGuiStylePtr style = ImGui.GetStyle();
            Vector2 buttonArea = Vector2.Zero;
            Vector2 framePadding = new Vector2(style.FramePadding.X, 0);
            Vector2 itemSpacing = new Vector2(style.ItemSpacing.X, 0);
            switch (Buttons)
            {
                case MessageBoxButtons.Ok:
                    {
                        buttonArea = ImGui.CalcTextSize("Ok") + style.FramePadding * 2.0f + style.WindowPadding;
                        ImGui.SetCursorPos(ImGui.GetWindowSize() - buttonArea);

                        if (ImGui.Button("Ok") && OnCloseDialog != null)
                        {
                            OnCloseDialog(DialogResult.Ok);
                            Open = false;
                        }
                        break;
                    }
                case MessageBoxButtons.YesNo:
                    {
                        buttonArea = ImGui.CalcTextSize("Yes") + framePadding * 2.0f;
                        buttonArea += itemSpacing;
                        buttonArea += ImGui.CalcTextSize("No") + framePadding * 2.0f;
                        buttonArea += style.WindowPadding;
                        ImGui.SetCursorPos(ImGui.GetWindowSize() - buttonArea);
                        if (ImGui.Button("Yes") && OnCloseDialog != null)
                        {
                            OnCloseDialog(DialogResult.Yes);
                            Open = false;
                        }
                        ImGui.SameLine();
                        if (ImGui.Button("No") && OnCloseDialog != null)
                        {
                            OnCloseDialog(DialogResult.No);
                            Open = false;
                        }
                        break;
                    }
            }
        }

        public static void ShowDialog(ImGuiWindow parent, string content, string title = "Message", MessageBoxButtons buttons = MessageBoxButtons.Ok, Action<DialogResult> onClose = null)
        {
            MessageBox msgBox = new MessageBox(content, title, buttons, onClose);
            WindowManager.OpenChild(parent, msgBox);
        }
    }
}
