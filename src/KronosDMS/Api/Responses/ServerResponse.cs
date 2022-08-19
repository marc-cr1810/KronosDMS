using KronosDMS.Http.Server;
using KronosDMS.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS.Api.Responses
{
    public class ServerGetInfoResponse : Response
    {
        internal ServerGetInfoResponse(Response response) : base(response)
        {
        }

        public ServerInfo ServerInfo { get; set; }
    }
}
