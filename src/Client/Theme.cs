using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace KronosDMS_Client
{
    public struct Theme
    {
        public struct ThemeColors
        {
            public struct TextColours
            {
                public Color Default;
                public Color Error;
            }

            public struct ButtonColors
            {
                public Color Unfocused;
                public Color Focused;
            }

            public Color Foreground;
            public Color Background;

            public TextColours Text;

            public ButtonColors Button;

        }

        public string Name;
        public ThemeColors Colors;

        public void Save()
        {
            ThemeManager.SaveTheme(this);
        }
    }

    public class ThemeManager
    {
        public static Theme LoadTheme(string theme)
        {
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
