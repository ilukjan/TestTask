using SharedData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler;
using WebCrawler.Abot;

namespace WFServerWebAPI.ServiceInterface
{
    internal static class ExecutionMonitor
    {
        internal static bool IsBusy { get; private set; }
        internal static bool IsFinished { get; private set; }
        internal static ParseURLResponse ExecutionResult { get; private set; }

        internal static void Run(string url)
        {
            Task.Run(async () => await Crawl(url));
        }

        async static Task<ParseURLResponse> Crawl(string url)
        {
            Init();

            ParseURLResponse result = null;

            using (IWebCrawler crawler = new AbotCrawler())
            {
                var parsedPages = crawler.Crawl(url);
                if (parsedPages == null && parsedPages.Count <= 0)
                    result = new ParseURLResponse() { ResultState = SharedData.Helpers.ERequestResult.Failed, ParsedPages = new List<SharedData.InternalDefinition.DBData>() };
                else
                    result = new ParseURLResponse() { ResultState = SharedData.Helpers.ERequestResult.Succeed, ParsedPages = parsedPages };
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

        static void Finalize(ParseURLResponse result)
        {
            IsBusy = false;
            IsFinished = true;
            ExecutionResult = result;
        }
    }
}
