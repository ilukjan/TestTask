using System;
using System.Collections.Generic;
using WebParser.PullentiWrapper;

namespace WebParser
{
    public interface IWebParser : IDisposable
    {
        List<string> GetInstances(string text);
    }
}
