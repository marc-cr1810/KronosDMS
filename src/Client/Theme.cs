using ImGuiNET;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Numerics;
using static KronosDMS_Client.Theme.ThemeColors.TextColors;

namespace KronosDMS_Client
{
    public struct Theme
    {
        public struct ThemeSettings
        {
            public struct RenderSettings
            {
                public bool WindowBorder;
                public bool FrameBorder;
                public bool PopupBorder;

                public bool AntiAliasedLines;
                public bool AntiAliasedLinesUseTex;
                public bool AntiAliasedFill;
            }

            public string Font;
            public RenderSettings Render;
        }

        public struct ThemeColors
        {
            public struct TextColors
            {
                public Color Default;
                public Color Error;
            }
            public struct ConsoleColors
            {
                public Color Info;
                public Color Ok;
                public Color Warning;
                public Color Error;
                public Color Fatal;
            }

            public struct ButtonColors
            {
                public Color Unfocused;
                public Color Focused;
            }

            public Color Foreground;
            public Color Background;

            public TextColors Text;
            public ConsoleColors Console;

            public ButtonColors Button;

            public Dictionary<string, Vector4> ImGuiColors;
        }

        public string Name;
        public ThemeSettings Settings;
        public ThemeColors Colors;

        public void Load()
        {
            bool edited = false;
            ImGuiStylePtr style = ImGui.GetStyle();

            SetImGuiStyle();

            if (Colors.ImGuiColors == null)
                Colors.ImGuiColors = new Dictionary<string, Vector4>();

            for (int i = 0; i < style.Colors.Count; i++)
            {
                string name = ImGui.GetStyleColorName((ImGuiCol)i);
                if (Colors.ImGuiColors.ContainsKey(name))
                {
                    style.Colors[i] = Colors.ImGuiColors[name];
                }
                else
                {
                    Colors.ImGuiColors.Add(name, style.Colors[i]);
                    edited = true;
                }
            }

            if (edited)
                Save();
        }

        public void Save()
        {
            ImGuiStylePtr style = ImGui.GetStyle();

            Settings.Render.WindowBorder = style.WindowBorderSize > 0.0f ? true : false;
            Settings.Render.FrameBorder = style.FrameBorderSize > 0.0f ? true : false;
            Settings.Render.PopupBorder = style.PopupBorderSize > 0.0f ? true : false;
            Settings.Render.AntiAliasedLines = style.AntiAliasedLines;
            Settings.Render.AntiAliasedLinesUseTex = style.AntiAliasedLinesUseTex;
            Settings.Render.AntiAliasedFill = style.AntiAliasedFill;

            if (Colors.ImGuiColors == null)
                Colors.ImGuiColors = new Dictionary<string, Vector4>();
            for (int i = 0; i < style.Colors.Count; i++)
            {
                string name = ImGui.GetStyleColorName((ImGuiCol)i);
                if (Colors.ImGuiColors.ContainsKey(name))
                {
                    Colors.ImGuiColors[name] = style.Colors[i];
                }
                else
                {
                    Colors.ImGuiColors.Add(name, style.Colors[i]);
                }
            }
            ThemeManager.SaveTheme(this);
        }

        public void SetImGuiStyle()
        {
            ImGuiStylePtr style = ImGui.GetStyle();

            style.WindowBorderSize = Settings.Render.WindowBorder ? 1.0f : 0.0f;
            style.FrameBorderSize = Settings.Render.FrameBorder ? 1.0f : 0.0f;
            style.PopupBorderSize = Settings.Render.PopupBorder ? 1.0f : 0.0f;

            style.AntiAliasedLines = Settings.Render.AntiAliasedLines;
            style.AntiAliasedLinesUseTex = Settings.Render.AntiAliasedLinesUseTex;
            style.AntiAliasedFill = Settings.Render.AntiAliasedFill;
        }

        public void SetImGuiColors()
        {
            if (Colors.ImGuiColors == null)
                return;

            ImGuiStylePtr style = ImGui.GetStyle();
            for (int i = 0; i < style.Colors.Count; i++)
            {
                string name = ImGui.GetStyleColorName((ImGuiCol)i);
                if (Colors.ImGuiColors.ContainsKey(name))
                {
                    style.Colors[i] = Colors.ImGuiColors[name];
                }
            }
        }

        public static Vector4 ColorToVec4(Color color)
        {
            float r = (float)color.R / 255;
            float g = (float)color.G / 255;
            float b = (float)color.B / 255;
            float a = (float)color.A / 255;

            return new Vector4(r, g, b, a);
        }
    }
}
