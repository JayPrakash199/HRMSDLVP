using HRMS.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebServices;

namespace HRMS
{
    public partial class FinancialUpgradation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["SessionCompanyName"] as string))
            {
                string message = string.Format("Message: {0}\\n\\n", "Please select a company");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnEditEmployeeSearch_Click(object sender, EventArgs e)
        {
            var lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) && 
                string.Equals(x.Page_Name.Trim(), "Financial Upgradation Application", StringComparison.OrdinalIgnoreCase)
                && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));

            if (role != null)
            {
                if (!Convert.ToBoolean(role.Read))
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to read the content. Kindly contact the system administrator.");
                    return;
                }
                EditData();
            }
            else
            {
                EditData();
            }
        }

        private void EditData()
        {
            var employeeResult = ODataServices.GetEmployeeInfo(txtHRMSId.Text, Session["SessionCompanyName"] as string);
            if (employeeResult != null)
            {
                txtEmployeeName.Text = employeeResult.First_Name;
                txtDesignation.Text = employeeResult.Designation;
                txtCurrentDate.Text= DateTimeParser.ConvertDateTimeToText(DateTime.UtcNow);
                LblMessage.Text = string.Empty;
            }
            else
            {
                txtEmployeeName.Text = string.Empty;
                txtDesignation.Text = string.Empty;
                LblMessage.Text = "No record found. Try searching with valid HRMS ID.";
            }
        }

        protected void btnFinancialSubmit_Click(object sender, EventArgs e)
        {

            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Financial Upgradation Application", StringComparison.OrdinalIgnoreCase)
                && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));
            if (role == null)
            {
                InsertData();
            }
            else
            {
                if (!Convert.ToBoolean(role.Insert))
                {
                    Alert.ShowAlert(this, "W",
                        "You do not have permission to modify the content. Kindly contact the system administrator.");
                    return;
                }
                InsertData();
            }
        }

        private void InsertData()
        {
            var obj = new WebServices.FinancialUpgradeReference.FinancialUpgradeCard
            {
                Date_of_application_upload_Current_DateSpecified = true,
                TypeSpecified = true,

                HRMS_ID=txtHRMSId.Text,
                //Employee_Name=txtEmployeeName.Text,
                Designation=txtDesignation.Text,
                Date_of_application_upload_Current_Date = DateTime.UtcNow,
                Type = ddlType.SelectedItem.Text == "MACP" ? WebServices.FinancialUpgradeReference.Type.MACP
                    : ddlType.SelectedItem.Text == "RACPs" ? WebServices.FinancialUpgradeReference.Type.RACP
                    : WebServices.FinancialUpgradeReference.Type._blank_
            };
            var resultMessage = SOAPServices.AddFinancialUpgradationForm(obj, Session["SessionCompanyName"] as string);
            Alert.ShowAlert(this, resultMessage == ResultMessages.SuccessfullMessage ? "s" : "e", resultMessage);
        }
    }
}