using HRMS.Common;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using WebServices;

namespace HRMS
{
    public partial class FeeClassification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Session["SessionCompanyName"] as string))
                {
                    string message = string.Format("Message: {0}\\n\\n", "Please select a company");
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
                    Response.Redirect("Default.aspx");
                }
                List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
                if (lstUserRole != null)
                {
                    var role = lstUserRole.FirstOrDefault(x =>
                    string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Page_Name, "Fee Classification List", StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Module_Name, "Accounts", StringComparison.OrdinalIgnoreCase));

                    if (role == null || Convert.ToBoolean(role.Read))
                    {
                        FeeClassificationListView.DataSource = ODataServices.GetFeeClassificationList(Session["SessionCompanyName"] as string);
                        FeeClassificationListView.DataBind();
                    }

                    else
                    {
                        Alert.ShowAlert(this, "W", "You do not have permission to read the content. Kindly contact the system administrator.");
                        
                    }
                }
                
            }
        }
    }
}