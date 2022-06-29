using ImGuiNET;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client
{
    public struct Font
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public float Size;
    }

    public static class FontManager
    {
        private static string FontsDir = "themes/font/";
        public static List<Font> Fonts { get; set;}
        private static int FontStack = 0;

        public static void Init()
        {
            Fonts = new List<Font>();

            DirectoryInfo root = new DirectoryInfo(FontsDir);
            if (!root.Exists)
                root.Create();
            foreach (DirectoryInfo subdir in root.GetDirectories())
            {
                foreach (FileInfo file in subdir.GetFiles())
                {
                    if (file.Extension == ".ttf")
                    {
                        string name = file.Name.Substring(0, file.Name.Length - file.Extension.Length);
                        Fonts.Add(new Font { Name = name, FilePath = file.FullName });
                    }
                }
            }

            foreach (FileInfo file in root.GetFiles())
            {
                if (file.Extension == ".ttf")
                {
                    string name = file.Name.Substring(0, file.Name.Length - file.Extension.Length);
                    Fonts.Add(new Font { Name = name, FilePath = file.FullName });
                }
            }

            Logger.Log("Initialized font manager", LogLevel.OK, $"Found {Fonts.Count} font('s)");
        }

        public static string SetThemeFont(string fontName, ref Theme theme)
        {
            if (fontName == null || fontName == "Default")
            {
                theme.Settings.Font = "Default";
                return "Default";
            }

            foreach(Font font in Fonts)
            {
                if (font.Name == fontName)
                    theme.Settings.Font = font.Name;
            }
            return theme.Settings.Font;
        }

        public static void LoadFontsToImGui()
        {
            ImGuiIOPtr io = ImGui.GetIO();
            foreach (Font font in Fonts)
            {
                io.Fonts.AddFontFromFileTTF(font.FilePath, Client.Config.FontSize);
            }
        }

        public static void PushFont(string font)
        {
            if (font == null || font == "Default")
                return;

            ImGuiIOPtr io = ImGui.GetIO();
            for (int n = 0; n < io.Fonts.Fonts.Size; n++)
            {
                ImFontPtr fontPtr = io.Fonts.Fonts[n];
                if (fontPtr.GetDebugName() == font + $".ttf, {(int)fontPtr.FontSize}px")
                {
                    ImGui.PushFont(fontPtr);
                    FontStack++;
                    return;
                }
            }
        }

        public static void PopFont()
        {
            if (FontStack > 0)
            {
                ImGui.PopFont();
                FontStack--;
            }
        }

        public static string[] GetFontNames()
        {
            List<string> names = new List<string>();
            names.Add("Default");
            foreach (Font font in Fonts)
                names.Add(font.Name);
            return names.ToArray();
        }
    }
}
