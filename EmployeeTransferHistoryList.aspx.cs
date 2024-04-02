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
    public partial class EmployeeTransferHistoryList : System.Web.UI.Page
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
                    string.Equals(x.Page_Name.Trim(), "Employee Transfer List", StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));

                    if (role == null || Convert.ToBoolean(role.Read))
                    {
                        BindListView();
                    }
                    else
                    {
                        Alert.ShowAlert(this, "W", "You do not have permission to read the content. Kindly contact the system administrator.");

                    }
                }
            }
        }
        private void BindListView()
        {
            var EmpTransferList = ODataServices.GetEmployeeTransferHistoryList(Session["SessionCompanyName"] as string);
            if (EmpTransferList != null)
            {
                EmployeeTransferListView.DataSource = EmpTransferList;
                EmployeeTransferListView.DataBind();
            }
        }

        protected void btnRelief_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Employee Transfer List", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Insert))
                {
                    try
                    {
                        Button btn = sender as Button;
                        ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
                        Label entryNo = item.FindControl("lblEntryNo") as Label;
                        Label empName = item.FindControl("lblEmployeeName") as Label;
                        SOAPServices.ReliefEmployee(Convert.ToInt32(entryNo.Text), Session["SessionCompanyName"] as string);
                        Alert.ShowAlert(this, "s", "Employee: "+empName.Text+ " relieved successfully.");
                        BindListView();
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