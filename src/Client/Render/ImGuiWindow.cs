﻿using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client.Render
{
    public class ImGuiWindow
    {
        public static uint NextID = 0;
        private string Name { get; set; }
        public uint ID { get; private set; }
        public string Title { get; set; }
        public bool Open = true;

        private Vector2 Size { get; set; }

        public ImGuiWindow(string title = "Window", int width = 640, int height = 468)
        {
            Name = title.Replace(" ", "_");
            ID = NextID++;
            Title = title;
            Size = new Vector2(width, height);

            OnLoad();
            Log($"Loaded ImGui window \"{Name}\"", LogLevel.INFO, $"Window ID: {Name}#{ID}\n" +
                $"Window title: {title}\n" +
                $"Window width: {width}\n" +
                $"Window height: {height}");
        }

        public void Show()
        {
            ImGui.SetNextWindowSize(Size, ImGuiCond.FirstUseEver);
            if (ImGui.Begin($"{Title}##{ID}", ref Open, ImGuiWindowFlags.NoSavedSettings))
            {
                Draw();
                ImGui.End();
            }
        }

        public void Close()
        {
            OnClose();
            Log($"Closed ImGui window \"{Name}\"", LogLevel.INFO, $"Window ID: {Name}##{ID}\n" +
                $"Window title: {Title}");
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