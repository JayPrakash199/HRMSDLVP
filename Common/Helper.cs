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
        public static string Employee_Student_No => GetEmployeeStudentNo();

        private static string GetEmployeeStudentNo()
        {
           var authList = HttpContext.Current.Session["UserAuthData"];
            if (authList != null )
            {
                return ((HRMSODATA.UserAuthenticationList)authList).Employee_Student_No;
            }
            return "";
        }
        public static string SLCMLoginType => GetSLCMLoginType();

        private static string GetSLCMLoginType()
        {
            var authList = HttpContext.Current.Session["UserAuthData"];
            if (authList != null)
            {
                return ((HRMSODATA.UserAuthenticationList)authList).SLCM_Login_Type;
            }
            return "";
        }
    }
}