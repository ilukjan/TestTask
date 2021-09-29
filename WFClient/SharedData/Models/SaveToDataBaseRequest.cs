using ServiceStack;
using SharedData;
using SharedData.InternalDefinition;
using System.Collections.Generic;

namespace SharedData.Models
{
    [Route("/SaveDBRequest/{ParsedPage}")]
    public class SaveDBRequest : IReturn<SaveDBResponse>
    {
        public DBData ParsedPage { get; set; }
    }

    public class SaveDBResponse
    {
        public bool Result { get; set; }
    }
}
