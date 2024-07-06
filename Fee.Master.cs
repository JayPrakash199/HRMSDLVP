using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS
{
    public partial class Fee : System.Web.UI.MasterPage
    {
        public bool IsPageRefresh;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["postGuids"] = System.Guid.NewGuid().ToString();
                Session["postGuid"] = ViewState["postGuids"].ToString();
                lblCompanyName.Text = System.Web.HttpUtility.UrlDecode(Convert.ToString(Session["SessionCompanyName"]));

                var userobj = Session["UserData"] as string;
                if (!string.IsNullOrEmpty(userobj))
                {
                    var userData = JObject.Parse(userobj.ToString());
                    var isFeeMgmnt = Convert.ToBoolean(userData["FeeManagement"]);
                    var isAccountMgmnt = Convert.ToBoolean(userData["AccountManagement"]);
                    if ((isFeeMgmnt == false) && (isAccountMgmnt = false))
                    {
                        Response.Redirect("Login.aspx");
                    }
                }
            }
            else
            {
                if (ViewState["postGuids"].ToString() != Session["postGuid"].ToString())
                {
                    IsPageRefresh = true;
                }
                Session["postGuid"] = System.Guid.NewGuid().ToString();
                ViewState["postGuids"] = Session["postGuid"].ToString();
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}