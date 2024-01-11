using HRMS.Common;
using InfrastructureManagement.Common;
using System;
using System.Linq;
using WebServices;

namespace HRMS
{
    public partial class Infra_ProjectProgressDetailsInput : System.Web.UI.Page
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

        protected void ProjectProgressSubmit_Click(object sender, EventArgs e)
        {
            var obj = new WebServices.InfraProjectprogressdetailsReference.Projectprogressdetailscard
            {
                AA_dateSpecified = true,
                Amount_of_AA_accordedSpecified = true,
                Agreement_Value_with_GST_in_LakhSpecified = true,
                Running_FY_expenditure_in_LakhSpecified = true,
                Expected_date_for_completionSpecified = true,
                Expenditure_made_as_on_31_march_of_Last_FY_in_LakhSpecified = true,
                Balance_fund_required_for_commencement_of_Work_in_Running_FY_in_LakhSpecified = true,
                Balance_fund_requried_for_completion_of_work_in_Running_FY_in_LakhSpecified = true,
                Percentage_of_work_completionSpecified = true,
                Fund_now_proposed_for_release_in_Running_FY_inSpecified = true,
                Project_TypeSpecified = true,
                Tender_VariationSpecified = true,
                UC_statusSpecified = true,

                Project_Type = lblProjectType.InnerText == "Improvement" ? WebServices.InfraProjectprogressdetailsReference.Project_Type.Improvement : lblProjectType.InnerText == "Ongoing" ? WebServices.InfraProjectprogressdetailsReference.Project_Type.Ongoing : WebServices.InfraProjectprogressdetailsReference.Project_Type.New,
                Project_Code = hiddenFiledProjectCode.Value,
                AA_No = txtAANo.Text,
                AA_date = DateTimeParser.ParseDateTime(txtAADate.Text),
                Amount_of_AA_accorded = NumericHandler.ConvertToDecimal(txtAmountOfAA.Text),
                Agreement_Value_with_GST_in_Lakh = NumericHandler.ConvertToDecimal(txtAgreementValue.Text),
                Running_FY_expenditure_in_Lakh = NumericHandler.ConvertToDecimal(txtRunningExp.Text),
                Expenditure_made_as_on_31_march_of_Last_FY_in_Lakh = NumericHandler.ConvertToDecimal(txtExpenditureMade.Text),
                Balance_fund_required_for_commencement_of_Work_in_Running_FY_in_Lakh = NumericHandler.ConvertToDecimal(txtCommencementBalanceWork.Text),
                Balance_fund_requried_for_completion_of_work_in_Running_FY_in_Lakh = NumericHandler.ConvertToDecimal(txtCompletionBalanceFund.Text),
                Present_status = txtPresentStatus.Text,
                Expected_date_for_completion = DateTimeParser.ParseDateTime(txtExpectedDate.Text),
                Reason_for_delayif_delayed = txtDelayReason.Text,
                Tender_Variation = ddlTenderVariation.SelectedItem.Text == "Excess" ? WebServices.InfraProjectprogressdetailsReference.Tender_Variation.Excess : WebServices.InfraProjectprogressdetailsReference.Tender_Variation.Less,
                Percentage_of_work_completion = NumericHandler.ConvertToDecimal(txtWorkCompletionPercentage.Text),
                Fund_now_proposed_for_release_in_Running_FY_in = NumericHandler.ConvertToDecimal(txtFundNow.Text),
                UC_status = ddlUCStatus.SelectedValue == "blank" ?
                WebServices.InfraProjectprogressdetailsReference.UC_status._blank_ : ddlUCStatus.SelectedValue == "Submitted" ? 
                WebServices.InfraProjectprogressdetailsReference.UC_status.Submitted : WebServices.InfraProjectprogressdetailsReference.UC_status.To_be_submitted,
                Running_Financial_Year = txtRunningFinanacialYear.Text
            };
            var result = SOAPServices.AddProjectProgressDeatils(obj, Session["SessionCompanyName"] as string);
            if (result == ResultMessages.SuccessfullMessage || result == ResultMessages.UpdateSuccessfullMessage)
            {
                Alert.ShowAlert(this, "s", result);
            }
            else
            {
                Alert.ShowAlert(this, "e", result);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var ongoingobj = new HRMSODATA.Ongoingprojectcard();
            var improvementObj = new HRMSODATA.Improvementprojectcard();
            var InputProgectCode = txtProjectSearch.Text;
            ongoingobj = ODataServices.GetOnGoingTypeProjectDetails(Session["SessionCompanyName"] as string).Where(x => string.Equals(x.Project_Code, InputProgectCode, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            if (ongoingobj == null)
            {
                improvementObj = ODataServices.GetImprovementTypeProjectDetails(Session["SessionCompanyName"] as string).Where(x => string.Equals(x.Project_Code, InputProgectCode, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            }
            if (ongoingobj == null && improvementObj != null)
            {
                lblDistrict.InnerText = improvementObj.District;
                lblInstitute.InnerText = improvementObj.Name_of_the_Institute;
                lblProjectType.InnerText = improvementObj.Project_Type;
                lblBuildingId.InnerText = improvementObj.Building_ID;
                lblProjectName.InnerText = improvementObj.Name_of_the_project;
                lblAgencyName.InnerText = improvementObj.Agency;
                lblWorkType.InnerText = improvementObj.Type_of_work;
                lblWorkMode.InnerText = improvementObj.Mode_of_Work;
                lblCommencementDate.InnerText = DateTimeParser.ConvertDateTimeToText(improvementObj.Date_of_commencement_as_per_agreement);
                lblCompletionDate.InnerText = DateTimeParser.ConvertDateTimeToText(improvementObj.Date_of_completion_as_per_agreement);
            }
            else if (ongoingobj != null)
            {
                lblDistrict.InnerText = ongoingobj.District;
                lblInstitute.InnerText = ongoingobj.Name_of_the_Institute;
                lblProjectType.InnerText = ongoingobj.Project_Type;
                lblProjectName.InnerText = ongoingobj.Name_of_the_project;
                lblAgencyName.InnerText = ongoingobj.Agency;
                lblWorkType.InnerText = ongoingobj.Type_of_work;
                lblWorkMode.InnerText = ongoingobj.Mode_of_Work;
                lblCompletionDate.InnerText = DateTimeParser.ConvertDateTimeToText(ongoingobj.Date_of_completion_as_per_agreement);
            }
            else
            {
                lblDistrict.InnerText = string.Empty;
                lblInstitute.InnerText = string.Empty;
                lblProjectType.InnerText = string.Empty;
                lblBuildingId.InnerText = string.Empty;
                lblProjectName.InnerText = string.Empty;
                lblAgencyName.InnerText = string.Empty;
                lblWorkType.InnerText = string.Empty;
                lblWorkMode.InnerText = string.Empty;
                lblCommencementDate.InnerText = string.Empty;
                lblCompletionDate.InnerText = string.Empty;
            }
            if (ongoingobj == null && improvementObj == null)
            {
                LblMessage.Text = "No record found. Please try with valid Project Code";
            }
            else
            {
                hiddenFiledProjectCode.Value = txtProjectSearch.Text;
                LblMessage.Text = string.Empty;
            }
        }
    }
}