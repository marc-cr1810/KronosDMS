using KronosDMS.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Server
{
    public class Config
    {
        public int Port { get; set; } = 8080;
        public string DefaultGroup { get; set; } = "Default";
        public int MaxSearchResults { get; set; } = 100;
        
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
