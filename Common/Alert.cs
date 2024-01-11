using System.Web.UI;

namespace HRMS.Common
{
    public static class Alert
    {
        public static void ShowAlert(Page p, string Class, string Message)
        {
            ScriptManager.RegisterStartupScript(p, p.GetType(), "Key", "customAlert('" + Class.ToUpper() + "','" + Message + "');", true);
        }

    }
}