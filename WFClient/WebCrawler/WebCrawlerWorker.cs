using SharedData.InternalDefinition;
using System;
using System.Collections.Generic;
using WebCrawler.Abot;

namespace WebCrawler
{
    public interface IWebCrawler : IDisposable
    {
        List<DBData> Crawl(string url);
    }
}
