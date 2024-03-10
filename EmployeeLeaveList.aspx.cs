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

        protected void btnForwardTogoverment_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Employee Leave List", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Accounts", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Insert))
                {
                    try
                    {
                        Button btn = sender as Button;
                        ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
                        Label entryNo = item.FindControl("lblProjectCode") as Label;

                        //Label status = item.FindControl("lblStatus") as Label;
                        //if (status.Text.ToLower() == "posted")
                        //{
                        //    Alert.ShowAlert(this, "e", "Alredy Posted.");
                        //    return;
                        //}

                        SOAPServices.ForwardToGovt(entryNo.Text, Session["SessionCompanyName"] as string);
                        Alert.ShowAlert(this, "s", "Posted successfully.");

                        LoadEmployeeLeaveData();
                    }
                    catch (Exception ex)
                    {
                        Alert.ShowAlert(this, "e", ex.Message);
                    }
                }
                else
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to post the content. Kindly contact the system administrator.");

                }
            }
        }

        protected void btnSanction_Click(object sender, EventArgs e)
        {

            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Employee Leave List", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Accounts", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Insert))
                {
                    try
                    {
                        Button btn = sender as Button;
                        ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
                        Label entryNo = item.FindControl("lblProjectCode") as Label;

                        SOAPServices.LeaveSanctioned(entryNo.Text, Session["SessionCompanyName"] as string);
                        Alert.ShowAlert(this, "s", "Leave Sanctioned successfully.");

                        LoadEmployeeLeaveData();
                    }
                    catch (Exception ex)
                    {
                        Alert.ShowAlert(this, "e", ex.Message);
                    }
                }
                else
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to post the content. Kindly contact the system administrator.");

                }
            }
        }

        protected void btnDecliend_Click(object sender, EventArgs e)
        {

            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Employee Leave List", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Accounts", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Insert))
                {
                    try
                    {
                        Button btn = sender as Button;
                        ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
                        Label entryNo = item.FindControl("lblProjectCode") as Label;
                        SOAPServices.LeaveDecliened(entryNo.Text, Session["SessionCompanyName"] as string);
                        Alert.ShowAlert(this, "s", "Leave Decliened successfully.");

                        LoadEmployeeLeaveData();
                    }
                    catch (Exception ex)
                    {
                        Alert.ShowAlert(this, "e", ex.Message);
                    }
                }
                else
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to post the content. Kindly contact the system administrator.");

                }
            }
        }
    }
}