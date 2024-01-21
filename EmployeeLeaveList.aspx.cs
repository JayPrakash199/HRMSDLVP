using HRMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class EmployeeLeaveList : System.Web.UI.Page
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
                    var role = lstUserRole
                        .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                        string.Equals(x.Page_Name.Trim(), "Employee Leave List", StringComparison.OrdinalIgnoreCase)
                        && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));

                    if (role == null)
                    {
                        LoadEmployeeLeaveData();
                    }
                    else
                    {
                        if (!Convert.ToBoolean(role.Read))
                        {
                            Alert.ShowAlert(this, "W", "You do not have permission to read the content. Kindly contact the system administrator.");
                            return;
                        }
                        LoadEmployeeLeaveData();
                    }
                }
            }

        }

        private void LoadEmployeeLeaveData()
        {
            var employeeList = ODataServices.GetEmployeeLeaveList(Session["SessionCompanyName"] as string);
            EmployeeleaveListView.DataSource = employeeList;
            EmployeeleaveListView.DataBind();
        }
    }
}