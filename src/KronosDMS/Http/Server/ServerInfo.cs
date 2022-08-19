using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS.Http.Server
{
    public class ServerInfo
    {
        public bool UseEncryption = true;

        public ServerInfo(bool useEncryption = true)
        {
            UseEncryption = useEncryption;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
