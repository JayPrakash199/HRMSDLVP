using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS
{
    public partial class LibraryManagement : System.Web.UI.MasterPage
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
                    var isLibraryMgmnt = Convert.ToBoolean(userData["LibraryManagement"]);
                    if (!isLibraryMgmnt)
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