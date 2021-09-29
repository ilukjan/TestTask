using ServiceStack;
using SharedData;
using SharedData.InternalDefinition;
using SharedData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WFServerWebAPI.ServiceModel.Encoder;

namespace WFServerWebAPI.ServiceModel
{
    public class WebAPIServiceClient : IDisposable
    {
        public WebAPIServiceClient(string url = "http://localhost:50012/")
        {
            Client = new JsonServiceClient(url);
        }


        JsonServiceClient Client = null;


        public bool CheckOnline(string name = "client")
        {
            try
            {
                var request = new HelloRequest() { Name = name };
                var response = Client.Post(request);

                if (response != null && !string.IsNullOrEmpty(response.Result))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SERVICECLIENT:\tFAIL\tCheckOnline. {ex.Message}");
                return false;
            }            
        }

        public bool ParseURL(string parsingUrl, IProgress<string> progress, out List<string> parsedPages)
        {
            try
            {
                parsedPages = new List<string>();
                progress.Report("Perform parsing.....");

                var urlEnc = EncodeHelper.Encode(parsingUrl);
                var request = new ParseURLRequest() { ParsingURL = urlEnc };

                var response = Client.Post(request);

                if (response != null)
                {
                    if (response.ResultState == SharedData.Helpers.ERequestResult.Failed)
                        return false;

                    if (response.ResultState == SharedData.Helpers.ERequestResult.Succeed)
                    {
                        parsedPages = response.ParsedPages.Select(x => x.ClearText).ToList();
                        return SaveParsedToDB(response.ParsedPages, progress);
                    }

                    // polling
                    if (response.ResultState == SharedData.Helpers.ERequestResult.InProcess)
                    {
                        Thread.Sleep(5 * 1000);
                        return ParseURL(parsingUrl, progress, out parsedPages);
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SERVICECLIENT:\tFAIL\tParseURL. {ex.Message}");
                parsedPages = new List<string>();
                return false;
            }
        }

        public bool SaveParsedToDB(List<DBData> parsedPages, IProgress<string> progress)
        {
            try
            {
                progress.Report("Perform DB save.....");

                var requests = new List<SaveDBRequest>();
                foreach (var item in parsedPages)
                    requests.Add(new SaveDBRequest() { ParsedPage = item });

                var responses = Client.SendAll(requests);

                if (responses != null && responses.Count == requests.Count)
                    return responses.Any(x => false) ? false : true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SERVICECLIENT:\tFAIL\tSaveParsedToDB. {ex.Message}");
                return false;
            }
        }



        public void Dispose()
        {
        }
    }
}
