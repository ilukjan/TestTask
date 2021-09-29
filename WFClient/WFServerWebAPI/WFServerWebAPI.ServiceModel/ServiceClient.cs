using ServiceStack;
using SharedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFServerWebAPI.ServiceModel.Encoder;

namespace WFServerWebAPI.ServiceModel
{
    public class WebAPIServiceClient : IDisposable
    {
        public WebAPIServiceClient(string url = "http://localhost:50012/")
        {
            URL = url;
            Client = new JsonServiceClient(URL);
        }

        string URL = "";
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

        public bool ParseURL(string parsingUrl)
        {
            try
            {
                var urlEnc = EncodeHelper.Encode(parsingUrl);
                var request = new ParseURLRequest() { ParsingURL = urlEnc };
                var response = Client.Post(request);

                if (response != null && response.Result && response.ParsedPages != null)
                {
                    SaveParsedToDB(response.ParsedPages);
                    return response.Result;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SERVICECLIENT:\tFAIL\tParseURL. {ex.Message}");
                return false;
            }
        }

        public bool SaveParsedToDB(List<DBData> parsedPages)
        {
            try
            {
                var request = new SaveDBRequest() { ParsedPages = parsedPages };
                var response = Client.Post(request);

                if (response != null)
                    return response.Result;
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
