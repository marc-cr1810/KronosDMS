using KronosDMS.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS.Api.Responses
{
    public class ROCheckedSearchResponse : Response
    {
        internal ROCheckedSearchResponse(Response response) : base(response)
        {
            RepairOrders = new Dictionary<int, RepairOrder>();
        }

        public Dictionary<int, RepairOrder> RepairOrders { get; set; } = new Dictionary<int, RepairOrder>();
    }
}
