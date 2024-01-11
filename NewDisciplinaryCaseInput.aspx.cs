using HRMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using WebServices;

namespace HRMS
{
    public partial class NewDisciplinaryCaseInput : System.Web.UI.Page
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) && 
                string.Equals(x.Page_Name.Trim(), "Add Case", StringComparison.OrdinalIgnoreCase)
                && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));
            if (role == null)
            {
                SearchAndBindData();
            }
            else
            {
                if (!Convert.ToBoolean(role.Read))
                {
                    Alert.ShowAlert(this, "W",
                        "You do not have permission to read the data. Kindly contact the system administrator.");
                    return;
                }
                SearchAndBindData();
            }

        }

        private void SearchAndBindData()
        {
            var employeeResult = ODataServices.GetEmployeeInfo(txtHRMSIDSearch.Text, Session["SessionCompanyName"] as string);
            if (employeeResult != null)
            {
                txtEmployeeName.Text = employeeResult.First_Name;
                txtDesignation.Text = employeeResult.Designation;
                LblMessage.Text = string.Empty;
            }
            else
            {
                txtEmployeeName.Text = string.Empty;
                txtDesignation.Text = string.Empty;
                LblMessage.Text = "No record found. Try searching with valid HRMS ID.";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Add Case", StringComparison.OrdinalIgnoreCase)
                && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));
            if (role == null)
            {
                AddEmployeeDscpRecord();
            }
            else
            {
                if (!Convert.ToBoolean(role.Insert))
                {
                    Alert.ShowAlert(this, "W",
                        "You do not have permission to insert the data. Kindly contact the system administrator.");
                    return;
                }
                AddEmployeeDscpRecord();
            }
        }

        private void AddEmployeeDscpRecord()
        {
            var obj = new WebServices.EmployeeDscpReference.EmployeeDscpCard
            {
                Disciplinary_CaseDateSpecified = true,
                Disciplinary_CasesStatusSpecified = true,
                WhetherPlaced_under_suspensionSpecified = true,
                Whether_reinstatedSpecified = true,

                HRMS_ID = txtHRMSIDSearch.Text,
                Employee_Name = txtEmployeeName.Text,
                Designation = txtDesignation.Text,
                Disciplinary_Charges = txtDisciplinaryCharges.Text,
                Disciplinary_CaseLetter_No = txtDisciplinaryCaseLetterNo.Text,
                Disciplinary_CaseDate = DateTimeParser.ParseDateTime(txtDisciplinaryCaseLetterDate.Text),
                Disciplinary_CasesStatus = ddlDisciplinarysCasesStatus.SelectedItem.Text == "Explanation Called"
                    ? WebServices.EmployeeDscpReference.Disciplinary_CasesStatus.Explanation_Called
                    : ddlDisciplinarysCasesStatus.SelectedItem.Text == "Explanation Submitted"
                        ? WebServices.EmployeeDscpReference.Disciplinary_CasesStatus.Explanation_Submitted
                        : ddlDisciplinarysCasesStatus.SelectedItem.Text == "Charges Framed"
                            ? WebServices.EmployeeDscpReference.Disciplinary_CasesStatus.Charges_Framed
                            : ddlDisciplinarysCasesStatus.SelectedItem.Text == "Reply to charges submitted"
                                ? WebServices.EmployeeDscpReference.Disciplinary_CasesStatus.Reply_to_charges_submitted
                                : ddlDisciplinarysCasesStatus.SelectedItem.Text == "Inquiry officer appointed"
                                    ? WebServices.EmployeeDscpReference.Disciplinary_CasesStatus.Inquiry_officer_appointed
                                    : ddlDisciplinarysCasesStatus.SelectedItem.Text == "Inquiry officer submitted report"
                                        ? WebServices.EmployeeDscpReference.Disciplinary_CasesStatus
                                            .Inquiry_officer_submitted_report
                                        : ddlDisciplinarysCasesStatus.SelectedItem.Text == "Punishment Awarded"
                                            ? WebServices.EmployeeDscpReference.Disciplinary_CasesStatus.Punishment_Awarded
                                            : WebServices.EmployeeDscpReference.Disciplinary_CasesStatus.Exonerated,
                WhetherPlaced_under_suspension = chkSuspension.Checked,
                Whether_reinstated = chkReinstated.Checked
            };
            var resultMessage = SOAPServices.AddEmployeeDscpRecord(obj, Session["SessionCompanyName"] as string);
            Alert.ShowAlert(this, resultMessage == ResultMessages.SuccessfullMessage ? "s" : "e", resultMessage);
            ClearControl();
        }

        private void ClearControl()
        {
            txtHRMSIDSearch.Text = "";
            txtEmployeeName.Text = "";
            txtDesignation.Text = "";
            txtDisciplinaryCharges.Text = "";
            txtDisciplinaryCaseLetterDate.Text = "";
            chkSuspension.Checked=false;
            chkReinstated.Checked = false;
            txtDisciplinaryCaseLetterNo.Text = "";
        }
    }
}