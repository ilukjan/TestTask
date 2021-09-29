using Pullenti.Ner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParser.PullentiWrapper
{
    public class PullentiParser : IWebParser
    {
        public List<string> GetInstances(string text)
        {
            Pullenti.Sdk.InitializeAll();
            var pullentiProcessor = ProcessorService.CreateProcessor();

            var result = new List<string>();            
            
            if (pullentiProcessor == null)            
                return new List<string>();            

            var aResult = pullentiProcessor.Process(new SourceOfAnalysis(text));
            foreach (Referent entity in aResult.Entities)            
                result.Add(entity.ToString());            

            return result;
        }

        public void Dispose()
        {
        }
    }
}
