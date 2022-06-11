using Newtonsoft.Json;
using System.IO;
using Veldrid;

namespace KronosDMS_Client
{
    public class Config
    {
        public string IPAddress { get; set; } = "127.0.0.1:8080";
        public string Theme { get; set; } = "Dark";
        public bool StartMaximized { get; set; } = true;
        public string GraphicsBackend { get; set; } = "PlatformDefault";

        public void Save()
        {
            string output = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(@"config.json", output);
        }

        public GraphicsBackend GetGraphicsBackend()
        {
            switch (this.GraphicsBackend)
            {
                case "PlatformDefault": return Veldrid.StartupUtilities.VeldridStartup.GetPlatformDefaultBackend();
                case "DirectX3D11": return Veldrid.GraphicsBackend.Direct3D11;
                case "OpenGL": return Veldrid.GraphicsBackend.OpenGL;
                case "Vulkan": return Veldrid.GraphicsBackend.Vulkan;
                case "Metal": return Veldrid.GraphicsBackend.Metal;
            }
            return Veldrid.StartupUtilities.VeldridStartup.GetPlatformDefaultBackend();
        }

        public static Config LoadConfig()
        {
            if (File.Exists(@"config.json"))
            {
                Logger.Log("Loading config file");
                return JsonConvert.DeserializeObject<Config>(File.ReadAllText(@"config.json"));
            }
            else
            {
                Logger.Log("Creating config file");
                Config config = new Config();
                config.Save();
                return config;
            }
        }
    }
}
