using HRMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using WebServices;

namespace HRMS
{
    public partial class RTIDetailsInput : System.Web.UI.Page
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) && 
                string.Equals(x.Page_Name.Trim(), "RTI Monitoring", StringComparison.OrdinalIgnoreCase)
                && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));
            if (role == null)
            {
                AddRtiMonitoringRecord();
            }
            else
            {
                if (!Convert.ToBoolean(role.Insert))
                {
                    Alert.ShowAlert(this, "W",
                        "You do not have permission to modify the content. Kindly contact the system administrator.");
                    return;
                }
                AddRtiMonitoringRecord();
            }
            
        }

        private void AddRtiMonitoringRecord()
        {
            var obj = new WebServices.RTIMonitoringReference.RTIMonitoringCard
            {
                Type_of_ApplicationSpecified = true,
                Date_of_Receipt_of_applicationSpecified = true,
                Reply_SentSpecified = true,
                Type_of_ReplySpecified = true,
                Reply_Letter_DateSpecified = true,
                Letter_Dispatch_DateSpecified = true,
                Reply_Due_DateSpecified = true,

                Type_of_Application = ddlApplicationType.SelectedItem.Text == "To PIO"
                    ? WebServices.RTIMonitoringReference.Type_of_Application.To_PIO
                    : ddlApplicationType.SelectedItem.Text == "To First Appellate Authority"
                        ? WebServices.RTIMonitoringReference.Type_of_Application.To_First_Appellate_Authority
                        : WebServices.RTIMonitoringReference.Type_of_Application._blank_,
                Name_of_the_applicant = txtApplicantName.Text,
                Date_of_Receipt_of_application = DateTimeParser.ParseDateTime(txtDateofReceiptofApplication.Text),
                Reply_Sent = ddlReplySent.SelectedItem.Text == "Yes"
                    ? WebServices.RTIMonitoringReference.Reply_Sent.Yes
                    : WebServices.RTIMonitoringReference.Reply_Sent.No,
                Type_of_Reply = ddlReplyType.SelectedItem.Text == "Rejected"
                    ? WebServices.RTIMonitoringReference.Type_of_Reply.Rejected
                    : ddlReplyType.SelectedItem.Text == "Asked to deposit dues"
                        ? WebServices.RTIMonitoringReference.Type_of_Reply.Asked_to_deposit_dues
                        : ddlReplyType.SelectedItem.Text == "Further Compliances"
                            ? WebServices.RTIMonitoringReference.Type_of_Reply.Further_Compliances
                            : ddlReplyType.SelectedItem.Text == "Information Supplied"
                                ? WebServices.RTIMonitoringReference.Type_of_Reply.Information_Supplied
                                : WebServices.RTIMonitoringReference.Type_of_Reply._blank_,
                Reply_Letter_Date = DateTimeParser.ParseDateTime(txtReplyLetterDate.Text),
                Letter_No = txtLetterNo.Text,
                Letter_Dispatch_Date = DateTimeParser.ParseDateTime(txtLetterDispatchDate.Text),
                Remark = txtRemark.Text,
                Application_No = txtApplicationNo.Text,
                Reply_Due_Date = DateTimeParser.ParseDateTime(txtReplyDueDate.Text)
            };
            var resultMessage = SOAPServices.AddRTIMonitoringRecord(obj, Session["SessionCompanyName"] as string);
            Alert.ShowAlert(this, resultMessage == ResultMessages.SuccessfullMessage ? "s" : "e", resultMessage);
        }
    }
}