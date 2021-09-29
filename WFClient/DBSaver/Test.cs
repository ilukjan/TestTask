using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSaver
{
    public interface ITest : IDisposable
    {
        bool DoWork();
    }

    public class ATest : ITest, IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool DoWork()
        {
            return true;
        }
    }

    public class TestCaller
    {
        void A()
        {
            using (ITest worker = new ATest())
            {
                worker.DoWork();
            }
        }
    }
}
