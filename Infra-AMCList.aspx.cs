using System;
using WebServices;

namespace HRMS
{
    public partial class Infra_AMCList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["SessionCompanyName"] as string))
            {
                string message = string.Format("Message: {0}\\n\\n", "Please select a company");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
                Response.Redirect("Default.aspx");
            }
            var result = ODataServices.GetAMCList(Session["SessionCompanyName"] as string);
            SecurityServiceListView.DataSource = result;
            SecurityServiceListView.DataBind();
        }
    }
}