using ServiceStack;
using SharedData.InternalDefinition;
using System.Collections.Generic;

namespace SharedData.Models
{
    [Route("/pollCrawlStatusRequest/")]
    public class PollCrawlStatusRequest : IReturn<PollCrawlStatusResponse>
    {
    }

    public class PollCrawlStatusResponse
    {
        public Helpers.ERequestResult ResultState { get; set; }
        public List<DBData> ParsedPages { get; set; }
    }
}
