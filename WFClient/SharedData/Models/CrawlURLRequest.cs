using ServiceStack;
using SharedData.Helpers;
using SharedData.InternalDefinition;
using System.Collections.Generic;

namespace SharedData.Models
{
    [Route("/parseURLRequest/{ParsingURL}")]
    public class CrawlURLRequest : IReturn<CrawlURLResponse>
    {
        public string ParsingURL { get; set; }
    }

    public class CrawlURLResponse
    {
        public ERequestResult ResultState { get; set; }
        public List<DBData> ParsedPages { get; set; }
    }
}