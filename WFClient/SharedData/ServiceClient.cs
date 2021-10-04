using Hangfire;
using Hangfire.PostgreSql;
using Hangfire.SqlServer;
using ServiceStack;
using SharedData.InternalDefinition;
using SharedData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WFServerWebAPI.ServiceModel.Encoder;

namespace WFServerWebAPI.ServiceModel
{
    public class WebAPIServiceClient : IDisposable
    {
        public WebAPIServiceClient(string url = "http://localhost:50012/")
        {
            Client = new JsonServiceClient(url);
            PollTimer.Elapsed += PollTimer_Elapsed;
        }


        JsonServiceClient Client = null;
        AutoResetEvent ARE = new AutoResetEvent(false);
        PollCrawlStatusResponse CrawlResponse= new PollCrawlStatusResponse() { ResultState = SharedData.Helpers.ERequestResult.InProcess };
        System.Timers.Timer PollTimer = new System.Timers.Timer(5 * 1000);
        object Locker = new object();

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

        public bool CrawlURL(string parsingUrl, IProgress<string> progress, out List<string> parsedPages)
        {
            try
            {
                parsedPages = new List<string>();
                progress.Report("Perform crawling.....");

                var urlEnc = EncodeHelper.Encode(parsingUrl);
                var request = new CrawlURLRequest() { ParsingURL = urlEnc };

                // start the crawler
                var response = Client.Post(request);

                if (response != null)
                {
                    var pgConnString = @"Server=localhost;Port=5432;User Id=postgres;Password=sql;Database=postgres;";
                    JobStorage.Current = new PostgreSqlStorage(pgConnString);


                    PollTimer.Start();

                    // ToDo: Minute is too long for polling
                    //RecurringJob.AddOrUpdate(() => PollServerForCrawledData(), Cron.Minutely);
                    
                    ARE.WaitOne();

                    PollTimer.Stop();

                    // save to db
                    parsedPages = CrawlResponse.ParsedPages.Select(x => x.ClearText).ToList();
                    return SaveParsedToDB(response.ParsedPages, progress);
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



        public void PollServerForCrawledData()
        {
            var request = new PollCrawlStatusRequest();
            var response = Client.Post(request);

            if (response != null)
            {
                CrawlResponse = response;

                if (response.ResultState == SharedData.Helpers.ERequestResult.Failed ||
                    response.ResultState == SharedData.Helpers.ERequestResult.Succeed)
                    ARE.Set();
            }
        }

        void PollTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Monitor.TryEnter(Locker))
            {
                // actually checks previous state
                if (CrawlResponse.ResultState == SharedData.Helpers.ERequestResult.InProcess)
                    PollServerForCrawledData();

                Monitor.Exit(Locker);
            }
        }
    }
}
