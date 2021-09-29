using ServiceStack;
using SharedData.Helpers;
using SharedData.InternalDefinition;
using System.Collections.Generic;

namespace SharedData.Models
{
    [Route("/parseURLRequest/{ParsingURL}")]
    public class ParseURLRequest : IReturn<ParseURLResponse>
    {
        public string ParsingURL { get; set; }
    }

    public class ParseURLResponse
    {
        public ERequestResult ResultState { get; set; }
        public List<DBData> ParsedPages { get; set; }
    }
}