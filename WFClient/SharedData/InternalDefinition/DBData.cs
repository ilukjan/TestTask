using System;

namespace SharedData.InternalDefinition
{
    [ServiceStack.DataAnnotations.Alias("DBData")]
    public class DBData
    {
        public DBData(string url, string title, string html, string clearText)
        {
            ID = 0;
            URL = url;
            ArticleName = title;
            HTMLData = html;
            ClearText = clearText;
            TimeStamp = DateTime.Now;
        }

        [ServiceStack.DataAnnotations.AutoIncrement]
        public long ID { get; set; }
        public string URL { get; set; }
        public string ArticleName { get; set; }
        public string HTMLData { get; set; }
        public string ClearText { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
