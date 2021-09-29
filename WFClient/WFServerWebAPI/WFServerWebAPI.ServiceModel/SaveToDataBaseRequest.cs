using ServiceStack;
using SharedData;
using System.Collections.Generic;

namespace WFServerWebAPI.ServiceModel
{
    [Route("/SaveDBRequest/{ParsedPages}")]
    public class SaveDBRequest : IReturn<SaveDBResponse>
    {
        public List<DBData> ParsedPages { get; set; }
    }

    public class SaveDBResponse
    {
        public bool Result { get; set; }
    }
}
