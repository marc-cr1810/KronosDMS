using ImGuiNET;
using KronosDMS.Utils;
using KronosDMS_Client.Render.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client.Render.ImGUI
{
    public class ImGuiWindow
    {
        public ImGuiWindow Parent = null;

        public static uint NextID = 0;
        protected string Name { get; set; }
        public uint ID { get; private set; }
        public string Title { get; set; }
        public bool Open = true;
        public bool Disabled { get; set; } = false;

        private Vector2 Size { get; set; }
        public Vector2 MinSize { get; set; } = new Vector2(0, 0);
        public Vector2 MaxSize { get; set; } = new Vector2(float.MaxValue, float.MaxValue);

        protected List<Control> Controls = new List<Control>();

        private int ShowMenuBar = -1;

        public ImGuiWindow(string title = "Window", int width = 640, int height = 468)
        {
            Name = title.Replace(" ", "_");
            ID = NextID++;
            Title = title;
            Size = new Vector2(width, height);

            OnLoad();
            Log($"Loaded ImGui window \"{Name}\"", LogLevel.INFO, 
                $"Window ID: {Name}#{ID}\n" +
                $"Window title: {title}\n" +
                $"Window width: {width}\n" +
                $"Window height: {height}");
        }

        public void Init()
        {
            if (Parent != null)
                Parent.Disabled = true;
        }

        public void Show()
        {
            // Check to see if there is a menu bar control to stop menu bars from showing on all windows
            if (ShowMenuBar == -1)
            {
                if (Controls.OfType<MenuStrip>().Any())
                    ShowMenuBar = 1;
                else 
                    ShowMenuBar = 0;
            }

            ImGuiWindowFlags flags = ImGuiWindowFlags.NoSavedSettings;
            if (ShowMenuBar == 1)
                flags |= ImGuiWindowFlags.MenuBar;

            if (Disabled)
            {
                flags |= ImGuiWindowFlags.NoResize
                      | ImGuiWindowFlags.NoMove
                      | ImGuiWindowFlags.NoMouseInputs
                      | ImGuiWindowFlags.NoCollapse
                      | ImGuiWindowFlags.NoScrollWithMouse
                      | ImGuiWindowFlags.NoDocking
                      | ImGuiWindowFlags.NoBringToFrontOnFocus
                      | ImGuiWindowFlags.NoFocusOnAppearing;

                ImGui.BeginDisabled(true);
            }

            ImGui.SetNextWindowSizeConstraints(MinSize, MaxSize);
            ImGui.SetNextWindowSize(Size, ImGuiCond.FirstUseEver);
            if (ImGui.Begin($"{Title}##{ID}", ref Open, flags))
            {
                Draw();
                ImGui.End();
            }

            if (Disabled)
                ImGui.EndDisabled();
        }

        public void Close()
        {
            OnClose();
            Log($"Closed ImGui window \"{Name}\"", LogLevel.INFO, 
                $"Window ID: {Name}##{ID}\n" +
                $"Window title: {Title}");
            ShowMenuBar = -1;

            if (Parent != null)
                Parent.Disabled = false;
        }

        protected void Log(string msg, LogLevel level = LogLevel.INFO, string details = "")
        {
            string source = $"Window\\\"{Name}#{ID}\"";
            Logger.Log(msg, level, details, source);
        }

        protected virtual void Draw() { }
        protected virtual void OnLoad() { }
        protected virtual void OnClose() { }
    }
}
