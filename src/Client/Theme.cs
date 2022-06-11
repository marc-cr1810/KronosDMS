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

        }

        public string Name;
        public ThemeColors Colors;

        public void Save()
        {
            ThemeManager.SaveTheme(this);
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

    public class ThemeManager
    {
        public static Theme LoadTheme(string theme)
        {
            Logger.Log($"Loading theme \"{theme}\"");
            Theme loadedTheme = new Theme();
            try
            {
                loadedTheme = JsonConvert.DeserializeObject<Theme>(File.ReadAllText($"themes/{theme}.json"));
            }
            catch { }
            return loadedTheme;
        }

        public static void SaveTheme(Theme theme)
        {
            File.WriteAllText($"themes/{theme.Name}.json", JsonConvert.SerializeObject(theme, Formatting.Indented));
        }

        public static string[] GetThemes()
        {
            List<string> result = new List<string>();

            DirectoryInfo d = new DirectoryInfo("themes");

            foreach (FileInfo file in d.GetFiles("*.json"))
                result.Add(file.Name.Split('.')[0]);

            return result.ToArray();
        }
    }
}
