using HRMS.Common;
using InfrastructureManagement.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using WebServices;

namespace HRMS
{
    public partial class Infra_EstimatePreparationMonitoring : System.Web.UI.Page
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

        protected void btnEstimateSubmit_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Estimate Preparation", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Infra", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Insert))
                {
                    var obj = new WebServices.InfraEstimatePrepReference.EstimatePrepCard
                    {
                        Estimate_amountSpecified = true,
                        Estimate_submittedSpecified = true,

                        Name_of_building_work = txtbuildingName.Text,
                        Present_Status = txtPresentStatus.Text,
                        Estimate_amount = NumericHandler.ConvertToDecimal(txtEstimatedAmount.Text),
                        Type_of_work = ddlTypeOfWork.SelectedItem.Text == "Civil" ?
                WebServices.InfraEstimatePrepReference.Type_of_work.Civil : ddlTypeOfWork.SelectedItem.Text == "Electrical" ?
                WebServices.InfraEstimatePrepReference.Type_of_work.Electrical : WebServices.InfraEstimatePrepReference.Type_of_work.PH,
                        Estimate_submitted = ddlEstimateSubmitted.SelectedItem.Text == "Yes" ?
                WebServices.InfraEstimatePrepReference.Estimate_submitted.Yes : WebServices.InfraEstimatePrepReference.Estimate_submitted.No_x003B_,
                        Remarks = txtRemarks.Text
                    };
                    var result = SOAPServices.CreateProjectEstimate(obj, Session["SessionCompanyName"] as string);
                    if (result == ResultMessages.SuccessfullMessage)
                    {
                        Alert.ShowAlert(this, "s", result);
                    }
                    else
                    {
                        Alert.ShowAlert(this, "e", result);
                    }
                }
                else
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to Submit the content. Kindly contact the system administrator.");
                }
            }
        }

    }
}