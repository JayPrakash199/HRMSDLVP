using Newtonsoft.Json.Linq;
using System;

namespace HRMS
{
    public partial class Infrastructure : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblCompanyName.Text = System.Web.HttpUtility.UrlDecode(Convert.ToString(Session["SessionCompanyName"]));
                var userobj = Session["UserData"] as string;
                if (!string.IsNullOrEmpty(userobj))
                {
                    var userData = JObject.Parse(userobj.ToString());
                    var isInfra = Convert.ToBoolean(userData["InfrastructureManagement"]);
                    if (!isInfra)
                    {
                        Response.Redirect("Login.aspx");
                    }
                }
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}