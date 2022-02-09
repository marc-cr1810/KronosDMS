using KronosDMS;
using Newtonsoft.Json;
using System.IO;

namespace KronosDMS_Server
{
    public class UpdateConfig
    {
        public UpdateInfo UpdateInfo = new UpdateInfo()
        {
            Client = new UpdateInfo.ClientVerInfo
            {
                Version = "1.0.0",
                Force = true
            },
            Updater = new UpdateInfo.UpdaterVerInfo
            {
                Version = "1.0.0",
                Force = true
            }
        };

        public UpdateConfig()
        {
            this.UpdateInfo = JsonConvert.DeserializeObject<UpdateInfo>(File.ReadAllText(@"data/client/update/version.json"));
        }

        public void Save()
        {
            string output = JsonConvert.SerializeObject(UpdateInfo, Formatting.Indented);
            File.WriteAllText(@"data/client/update/version.json", output);
        }

        public string ToJSON()
        {
            return JsonConvert.SerializeObject(UpdateInfo);
        }
    }
}
