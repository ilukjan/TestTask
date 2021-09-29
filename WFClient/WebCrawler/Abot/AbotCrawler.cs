using Abot2.Crawler;
using Abot2.Poco;
using AngleSharp.Html.Dom;
using SharedData.InternalDefinition;
using System;
using System.Collections.Generic;
using System.Linq;
using SharedData.Helpers;
using System.Threading;
using System.Threading.Tasks;

namespace WebCrawler.Abot
{
    public class AbotCrawler : IWebCrawler
    {
        List<DBData> _CrawlResults = new List<DBData>();
        object _Locker = new object();

        public void Dispose()
        {
        }

        public List<DBData> Crawl(string url)
        {
            var config = new CrawlConfiguration
            {
                MaxConcurrentThreads = 10,
                MinCrawlDelayPerDomainMilliSeconds = 300,
                MaxPagesToCrawl = 500
            };

            var crawler = new PoliteWebCrawler(config);
            crawler.PageCrawlCompleted += PageCrawlCompleted;

            _CrawlResults = new List<DBData>();

            // wait till crowler end
            var result = Task.Run(async () => await crawler.CrawlAsync(new Uri(url))).Result;
            return _CrawlResults;
        }

        void PageCrawlCompleted(object sender, PageCrawlCompletedArgs e)
        {
            if (e.CrawledPage == null || e.CrawledPage.HttpResponseMessage == null)
                return;

            if (e.CrawledPage.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var htmlText = e.CrawledPage.Content.Text;
                var angleSharpHtmlDocument = e.CrawledPage.AngleSharpHtmlDocument;
                var title = angleSharpHtmlDocument.Title;
                var texts = angleSharpHtmlDocument.All
                           .OfType<IHtmlHeadElement>()
                           .Select(h => h.TextContent.Trim().RemoveHTML())
                           .ToList();

                var clearText = string.Join(" ", texts);
                var uri = e.CrawledPage.Uri.AbsoluteUri;

                var crawlRes = new DBData(uri, title, htmlText, clearText);

                // safe add
                if (Monitor.TryEnter(_Locker, 100))
                {
                    _CrawlResults.Add(crawlRes);
                    Monitor.Exit(_Locker);
                }
            }
        }
    }
}
