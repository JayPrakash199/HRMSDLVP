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
    public partial class EmployeeLeave : System.Web.UI.Page
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
            }
        }

        protected void btnLeaveSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                SOAPServices.ApplyLeave(txtHRMSID.Text, 
                    DateTimeParser.ParseDateTime(txtLeaveFrom.Text), DateTimeParser.ParseDateTime(txtLeaveTo.Text)
                    , Convert.ToInt32( ddlTypeOfLeave.SelectedItem.Value), Session["SessionCompanyName"] as string);
                ClaerControl();
                Alert.ShowAlert(this, "s", "Leave Applied successfully.");
            }
            catch (Exception ex)
            {
                Alert.ShowAlert(this, "e", ex.Message);
            }
        }

        private void ClaerControl()
        {
            txtHRMSID.Text = "";
            txtEmpName.Text = "";
            txtEmpDesignation.Text = "";
            txtLeaveFrom.Text = "";
            txtLeaveTo.Text = "";
            ddlTypeOfLeave.ClearSelection();
            ddlTypeOfLeave.Items.FindByValue("-1").Selected=true;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Add Transfer Record", StringComparison.OrdinalIgnoreCase)
                && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));
            if (role == null)
            {
                SearchRecord();
            }
            else
            {
                if (!Convert.ToBoolean(role.Read))
                {
                    Alert.ShowAlert(this, "W",
                        "You do not have permission to read the content. Kindly contact the system administrator.");
                    return;
                }
                SearchRecord();
            }
        }

        private void SearchRecord()
        {
            var employeeResult = ODataServices.GetEmployeeInfo(txtHRMSID.Text, Session["SessionCompanyName"] as string);
            if (employeeResult != null)
            {
                txtEmpName.Text = employeeResult.First_Name;
                txtEmpDesignation.Text = employeeResult.Designation;
                LblMessage.Text = string.Empty;
            }
            else
            {
                txtEmpName.Text = string.Empty;
                txtEmpDesignation.Text = string.Empty;
                LblMessage.Text = "No record found. Try searching with valid HRMS ID.";
            }
        }
    }
}