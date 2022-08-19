using Newtonsoft.Json;
using System.IO;

namespace KronosDMS_Client
{
    public class Config
    {
        public string IPAddress { get; set; } = "127.0.0.1:8080";
        public string Theme { get; set; } = "Dark";
        public bool StartMaximized { get; set; } = true;

        public void Save()
        {
            string output = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(@"config.json", output);
        }
        public static Config LoadConfig()
        {
            if (File.Exists(@"config.json"))
                return JsonConvert.DeserializeObject<Config>(File.ReadAllText(@"config.json"));
            else
                return new Config();
        }
    }
}
