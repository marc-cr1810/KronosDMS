using KronosDMS.Objects;

namespace KronosDMS.Api.Responses
{
    public class GetFormatResponse : Response
    {
        internal GetFormatResponse(Response response) : base(response)
        {
        }

        public CSVFormat Format { get; set; }
    }
}
