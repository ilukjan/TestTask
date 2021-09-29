using System.Text.RegularExpressions;

namespace SharedData.Helpers
{
    public static class Extensions
    {
        public static string RemoveHTML(this string raw)
        {
            Regex rx = new Regex(@"(\r\n|\r|\n|\t)");
            return rx.Replace(raw, "");
        }
    }
}
