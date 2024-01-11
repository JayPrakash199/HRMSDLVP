using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Linq;

namespace HRMS.Common
{
    public static class Helper
    {
        public static string UserName => GetUserName();

        private static string GetUserName()
        {
            var userObject = HttpContext.Current.Session["UserData"] as string;
            if (!string.IsNullOrEmpty(userObject))
            {
                var userData = JObject.Parse(userObject.ToString());
                return userData["UserName"]?.ToString();
            }

            return "";
        }
    }
}