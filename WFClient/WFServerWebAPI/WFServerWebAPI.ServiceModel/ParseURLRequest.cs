using ServiceStack;
using SharedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WFServerWebAPI.ServiceModel
{
    [Route("/parseURLRequest/{ParsingURL}")]
    public class ParseURLRequest : IReturn<ParseURLResponse>
    {
        public string ParsingURL { get; set; }
    }

    public class ParseURLResponse
    {
        public bool Result { get; set; }
        public List<DBData> ParsedPages { get; set; }
    }
}