using HRMS.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using WebServices;

namespace HRMS
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_Error(object sender, EventArgs e)
        {
            Exception Ex = Server.GetLastError();
            Server.ClearError();
            Server.Transfer("Error.aspx?e=" + Ex.Message);
        }
        void Session_Start(object sender, EventArgs e)
        {
           
        }

        void Session_End(object sender, EventArgs e)
        {
            var UserName = "";
            var userObject = Session["UserData"] as string;
            if (!string.IsNullOrEmpty(userObject))
            {
                var userData = JObject.Parse(userObject.ToString());
                UserName= userData["UserName"]?.ToString();
            }

            SOAPServices.UpdateSessionData(UserName, this.Session.SessionID, System.DateTime.Now, Session["SessionCompanyName"] as string);
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.
        }
    }
}