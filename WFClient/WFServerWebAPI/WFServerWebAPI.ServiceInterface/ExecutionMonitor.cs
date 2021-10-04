using SharedData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebCrawler;
using WebCrawler.Abot;

namespace WFServerWebAPI.ServiceInterface
{
    internal static class ExecutionMonitor
    {
        internal static bool IsBusy { get; private set; }
        internal static bool IsFinished { get; private set; }
        internal static PollCrawlStatusResponse ExecutionResult { get; private set; }

        internal static void Run(string url)
        {
            Task.Run(async () => await Crawl(url));
        }

        async static Task<PollCrawlStatusResponse> Crawl(string url)
        {
            Init();

            PollCrawlStatusResponse result = null;

            using (IWebCrawler crawler = new AbotCrawler())
            {
                var parsedPages = crawler.Crawl(url);
                if (parsedPages == null && parsedPages.Count <= 0)
                    result = new PollCrawlStatusResponse() { ResultState = SharedData.Helpers.ERequestResult.Failed, ParsedPages = new List<SharedData.InternalDefinition.DBData>() };
                else
                    result = new PollCrawlStatusResponse() { ResultState = SharedData.Helpers.ERequestResult.Succeed, ParsedPages = parsedPages };
            }

            Finalize(result);

            return result;
        }

        static void Init()
        {
            IsBusy = true;
            IsFinished = false;
            ExecutionResult = null;
        }

        static void Finalize(PollCrawlStatusResponse result)
        {
            IsBusy = false;
            IsFinished = true;
            ExecutionResult = result;
        }
    }
}
