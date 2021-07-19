using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace KronosDMS.Api.Endpoints
{
    public class RecallAdd : IEndpoint<Response>
    {
        public Recall Recall { get; set; }

        public RecallAdd(Recall recall)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/recalls/add");
            this.Recall = recall;
        }

        public override async Task<Response> PerformRequestAsync()
        {
            this.PostContent = JsonConvert.SerializeObject(this.Recall);
            this.Response = Task.Run(() => Requester.Post(this)).Result;

            if (this.Response.IsSuccess)
            {
                return new Response(this.Response)
                {

                };
            }
            else
                return new Response(Error.GetError(this.Response));
        }
    }
}
