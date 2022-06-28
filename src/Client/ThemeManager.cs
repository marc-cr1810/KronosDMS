using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client
{
    public class ThemeManager
    {
        public static Theme LoadTheme(string theme)
        {
            Logger.Log($"Loading theme \"{theme}\"");
            Theme loadedTheme = new Theme();
            try
            {
                loadedTheme = JsonConvert.DeserializeObject<Theme>(File.ReadAllText($"themes/{theme}.json"));
                if (loadedTheme.Name == null)
                {
                    Logger.Log($"Failed to load theme \"{theme}\"", LogLevel.ERROR, "Name of theme is NULL.\nPlease check the theme file to se if it has a name.");
                }
                if (Client.MainWindow != null)
                {
                    if (Client.MainWindow.ImGuiInitialized())
                        loadedTheme.Load();
                }
            }
            catch
            {
                Logger.Log("Failed to load theme", LogLevel.ERROR);
                return Client.ActiveTheme;
            }
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
