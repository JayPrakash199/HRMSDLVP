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
    public partial class ExistingDisciplinaryCaseUdate : System.Web.UI.Page
    {
        private List<HRMSODATA.EmployeeDscpList> disciplinaryList;
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
            disciplinaryList = ODataServices.GetDisciplinaryListByHRMSID(txtHRMSIDSearch.Text, Session["SessionCompanyName"] as string).ToList();
            if (disciplinaryList != null && disciplinaryList.Any())
            {
                txtEmployeeName.Text = disciplinaryList.FirstOrDefault().Employee_Name;
                txtDesignation.Text = disciplinaryList.FirstOrDefault().Designation;

                ddlCaseSerialNo.DataSource = disciplinaryList;
                ddlCaseSerialNo.DataTextField = "Entry_No";
                ddlCaseSerialNo.DataValueField = "Entry_No";
                ddlCaseSerialNo.DataBind();
                ddlCaseSerialNo.Items.Insert(0, new ListItem("Select Serial No", "0"));
                LblMessage.Text = string.Empty;
            }
            else
            {
                txtEmployeeName.Text = string.Empty;
                txtDesignation.Text = string.Empty;
                LblMessage.Text = "No record found. Try searching with valid HRMS ID.";
            }
        }

        protected void ddlCaseSerialNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            disciplinaryList = ODataServices.GetDisciplinaryListByHRMSID(txtHRMSIDSearch.Text, Session["SessionCompanyName"] as string).ToList();
            var serialNo = Convert.ToInt32(ddlCaseSerialNo.SelectedItem.Value);
            if (serialNo > 0)
            {
                var result = disciplinaryList.FirstOrDefault(x => x.Entry_No == serialNo);
                txtDisciplinaryCharges.Text = result.Disciplinary_Charges;
                txtCaseLetterDate.Text = DateTimeParser.ConvertDateTimeToText(result.Disciplinary_CaseDate);
                txtCaseLatterNo.Text = result.Disciplinary_CaseLetter_No;
                lblSerialNo.Text = Convert.ToString(serialNo);
                ddlUnderSuspension.SelectedValue = result.WhetherPlaced_under_suspension.Value ? "Yes" : "No";
                ddlReinstated.SelectedValue = result.Whether_reinstated.Value ? "Yes" : "No";
                ddlDisciplinarysCasesStatus.ClearSelection();
                ddlDisciplinarysCasesStatus.SelectedValue = result.Disciplinary_CasesStatus;
            }
            else 
            {
                txtDisciplinaryCharges.Text = string.Empty;
                txtCaseLetterDate.Text = string.Empty;
                txtCaseLatterNo.Text = string.Empty;
                lblSerialNo.Text = string.Empty;
                ddlUnderSuspension.ClearSelection();
                ddlReinstated.ClearSelection();
                ddlDisciplinarysCasesStatus.ClearSelection();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var obj = new WebServices.EmployeeDscpReference.EmployeeDscpCard
            {
                HRMS_ID = txtHRMSIDSearch.Text,
                Entry_No = Convert.ToInt32(lblSerialNo.Text),
                Disciplinary_CasesStatus = ddlDisciplinarysCasesStatus.SelectedItem.Text == "Explanation Called" ? WebServices.EmployeeDscpReference.Disciplinary_CasesStatus.Explanation_Called
                : ddlDisciplinarysCasesStatus.SelectedItem.Text == "Explanation Called" ? WebServices.EmployeeDscpReference.Disciplinary_CasesStatus.Explanation_Submitted
                : ddlDisciplinarysCasesStatus.SelectedItem.Text == "Charges Framed" ? WebServices.EmployeeDscpReference.Disciplinary_CasesStatus.Charges_Framed
                : ddlDisciplinarysCasesStatus.SelectedItem.Text == "Reply to charges submitted" ? WebServices.EmployeeDscpReference.Disciplinary_CasesStatus.Reply_to_charges_submitted
                : ddlDisciplinarysCasesStatus.SelectedItem.Text == "Inquiry officer appointed" ? WebServices.EmployeeDscpReference.Disciplinary_CasesStatus.Inquiry_officer_appointed
                : ddlDisciplinarysCasesStatus.SelectedItem.Text == "Inquiry officer submitted report" ? WebServices.EmployeeDscpReference.Disciplinary_CasesStatus.Inquiry_officer_submitted_report
                : ddlDisciplinarysCasesStatus.SelectedItem.Text == "Punishment Awarded" ? WebServices.EmployeeDscpReference.Disciplinary_CasesStatus.Punishment_Awarded
                : WebServices.EmployeeDscpReference.Disciplinary_CasesStatus.Exonerated,
                WhetherPlaced_under_suspension = ddlUnderSuspension.SelectedItem.Text == "Yes" ? true : false,
                Whether_reinstated = ddlReinstated.SelectedItem.Text == "Yes" ? true : false
            };

            var resultMessage = SOAPServices.UpdateEmployeeDscpRecord(obj, Session["SessionCompanyName"] as string);
            if (resultMessage == ResultMessages.UpdateSuccessfullMessage)
            {
                Alert.ShowAlert(this, "s", resultMessage);
            }
            else
            {
                Alert.ShowAlert(this, "e", resultMessage);
            }
        }
    }
}