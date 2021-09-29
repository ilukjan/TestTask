using DBSaver.PostgreSQL;
using SharedData;
using SharedData.InternalDefinition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSaver
{
    public interface IDBWorker : IDisposable
    {
        bool SaveParsedData(List<DBData> data, string pgConString);
        bool SaveParsedData(DBData data, string pgConString);
    }
}
