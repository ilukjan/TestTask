using ServiceStack.OrmLite;
using SharedData.InternalDefinition;
using System;
using System.Collections.Generic;

namespace DBSaver.PostgreSQL
{
    public class PostgreWorker : IDBWorker
    {
        public void Dispose()
        {
        }

        public bool SaveParsedData(List<DBData> data, string pgConnString)
        {
            try
            {
                //var pgConnString = "Server=localhost;Port=5432;User Id=postgres;Password=sql;Database=postgres;";

                var dbFactory = new OrmLiteConnectionFactory(pgConnString, PostgreSqlDialect.Provider);
                if (dbFactory != null)
                {
                    using (var db = dbFactory.Open())
                    {
                        db.CreateTableIfNotExists<DBData>();

                        foreach (var item in data)
                        {
                            var id = db.Insert(item, true);
                            if (id > 0)
                            {
                                System.Diagnostics.Debug.WriteLine($"ORMLITE:\tOK\tRow inserted. ID:{id}");
                                continue;                             
                            }
                        }

                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ORMLITE:\tFAIL\tRow insert. {ex.Message}");
                return false;
            }
        }
        public bool SaveParsedData(DBData data, string pgConnString)
        {
            try
            {
                //var pgConnString = "Server=localhost;Port=5432;User Id=postgres;Password=sql;Database=postgres;";

                var dbFactory = new OrmLiteConnectionFactory(pgConnString, PostgreSqlDialect.Provider);
                if (dbFactory != null)
                {
                    using (var db = dbFactory.Open())
                    {
                        db.CreateTableIfNotExists<DBData>();

                        var id = db.Insert(data, true);
                        if (id > 0)
                            System.Diagnostics.Debug.WriteLine($"ORMLITE:\tOK\tRow inserted. ID:{id}");

                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ORMLITE:\tFAIL\tRow insert. {ex.Message}");
                return false;
            }
        }
    }
}
