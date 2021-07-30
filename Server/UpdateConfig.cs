using Newtonsoft.Json;
using System.IO;

namespace KronosDMS_Server
{
    public class UpdateConfig
    {
        public string Version { get; set; } = "1.0.0";
        public bool Force { get; set; } = true;

        public void Save()
        {
            string output = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(@"data/update/version.json", output);
        }

        public string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static UpdateConfig LoadConfig()
        {
            if (File.Exists(@"data/update/version.json"))
                return JsonConvert.DeserializeObject<UpdateConfig>(File.ReadAllText(@"data/update/version.json"));
            else
                return new UpdateConfig();
        }
    }
}
