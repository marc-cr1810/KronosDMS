using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace KronosDMS.Api.Endpoints
{
    public class ROCheckedAdd : IEndpoint<Response>
    {
        public List<RepairOrder> RepairOrders { get; set; }

        public ROCheckedAdd(List<RepairOrder> repairOrders)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/checkedros/add");
            this.RepairOrders = repairOrders;
        }

        public override async Task<Response> PerformRequestAsync()
        {
            this.PostContent = JsonConvert.SerializeObject(this.RepairOrders);
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

    public class ROCheckedSearch : IEndpoint<ROCheckedSearchResponse>
    {
        public string Number { get; set; }
        public string Date { get; set; }

        public ROCheckedSearch(string number, string date)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/checkedros/get");

            this.Number = number;
            this.Date = date;
        }

        public ROCheckedSearch(string number, DateTime date)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/checkedros/get");
            
            this.Number = number;
            this.Date = date.ToString();
        }

        public override async Task<ROCheckedSearchResponse> PerformRequestAsync()
        {
            this.Arguments.Add($"n={HttpUtility.UrlEncode(this.Number)}");
            this.Arguments.Add($"d={HttpUtility.UrlEncode(this.Date)}");

            this.Response = Task.Run(() => Requester.Get(this)).Result;

            if (this.Response.IsSuccess)
            {
                return new ROCheckedSearchResponse(this.Response)
                {
                    RepairOrders = JsonConvert.DeserializeObject<Dictionary<int, RepairOrder>>(this.Response.RawMessage)
                };
            }
            else
                return new ROCheckedSearchResponse(Error.GetError(this.Response));
        }
    }
}
