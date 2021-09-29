using DBSaver;
using DBSaver.PostgreSQL;
using ServiceStack;
using SharedData.Helpers;
using SharedData.InternalDefinition;
using SharedData.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using WebCrawler;
using WebCrawler.Abot;
using WFServerWebAPI.ServiceModel.Encoder;

namespace WFServerWebAPI.ServiceInterface
{
    public class MyServices : Service
    {
        public MyServices()
        {
            
        }

        public object Any(HelloRequest request)
        {            
            return new HelloResponse { Result = $"Hello, {request.Name}!" };
        }

        public object Any(ParseURLRequest request)
        {
            var urlDec = EncodeHelper.Decode(request.ParsingURL);
            var parsedpages = new List<DBData>();

            if (ExecutionMonitor.IsFinished == false && ExecutionMonitor.IsBusy == false)
                ExecutionMonitor.Run(urlDec);
            else
            {
                if (ExecutionMonitor.IsFinished)
                    return ExecutionMonitor.ExecutionResult;
            }

            return new ParseURLResponse { ResultState = ERequestResult.InProcess, ParsedPages = parsedpages };
        }

        public object Any(SaveDBRequest request)
        {
            var result = true;

            if (request.ParsedPage != null)
            {
                var pgConStr = ConfigurationManager.ConnectionStrings["db_pg"];

                using (IDBWorker db = new PostgreWorker())
                {
                    result = db.SaveParsedData(request.ParsedPage, pgConStr.ConnectionString);
                }                
            }
            else
                result = false;

            return new SaveDBResponse { Result = result };
        }
    }
}