using System;
using System.Linq;

namespace HRMS.Common
{
    public static class StringHelper
    {
        public static string GetFileNameFromURL(string url)
        {
            var valueArray = url.Split('\\');
            if (valueArray.Count() > 1)
            {
                return new Uri(url).Segments.Last();
            }
            return url;
        }
    }
}