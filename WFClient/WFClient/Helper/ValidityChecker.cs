using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WFClient.Helper
{
    internal class ValidityChecker
    {
        internal static bool IsURLValid(string url)
        {
            if (string.IsNullOrEmpty(url))
                return false;

            var urlPatter = @"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_]*)?$";
            var regex = new Regex(urlPatter, RegexOptions.IgnoreCase);
            var res = regex.IsMatch(url);

            return res;

            //return Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute);
        }
    }
}
