using System.Configuration;
using System.Net;
using System.Web;
using System.Web.Services.Protocols;

namespace WebServices
{
    public class Configuration
    {
        public static string ODataServiceUrl()
        {
            string obj = string.Empty;
            obj = ConfigurationManager.AppSettings["ODataServiceUrl"];
            return obj;
        }

        public static SoapHttpClientProtocol getNavService(SoapHttpClientProtocol eVService, string serviceName, string serviceType, string companyName)
        {
            SoapHttpClientProtocol ws = eVService;
            //<add key="WebServiceUrl" value="http://172.16.4.11:8047/BC200/WS/GOVT%20POLYTECHNIC%20ANGUL/"/>
            string wsUrl = ConfigurationManager.AppSettings["WebServiceUrl"]+companyName+"/";  
            if (serviceType.Trim().Length != 0)
                wsUrl += serviceType + "/";
            if (serviceName.Trim().Length != 0)
                wsUrl += serviceName;
            ws.UseDefaultCredentials = false;
            ws.Url = HttpUtility.UrlPathEncode(wsUrl);
            ws.Credentials = ODataServiceUrlCredentials();
            return ws;
        }

        public static NetworkCredential ODataServiceUrlCredentials()
        {
            NetworkCredential obj = new NetworkCredential();
            obj.UserName = "SOMNATH";
            obj.Password = "Aug@1817";
            return obj;
        }
    }
}
