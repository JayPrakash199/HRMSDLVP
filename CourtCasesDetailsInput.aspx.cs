using HRMS.Common;
using InfrastructureManagement.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class CourtCasesDetailsInput : System.Web.UI.Page
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
                var stations = ODataServices.GetStationList(Session["SessionCompanyName"] as string);
                if (stations != null && stations.Count > 0)
                {
                    ddlLowestLevelOffice.DataSource = stations;
                    ddlLowestLevelOffice.DataTextField = "Institute_Name";
                    ddlLowestLevelOffice.DataValueField = "Institute_Code";
                    ddlLowestLevelOffice.DataBind();
                    ddlLowestLevelOffice.Items.Insert(0, new ListItem("Select", "0"));
                }
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                    .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Page_Name.Trim(), "Court Case", StringComparison.OrdinalIgnoreCase)
                    && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));
            if (role == null)
            {
                AddCourtCaseRecord();
            }
            else
            {
                if (!Convert.ToBoolean(role.Insert))
                {
                    Alert.ShowAlert(this, "W",
                        "You do not have permission to modify the content. Kindly contact the system administrator.");
                    return;
                }
                AddCourtCaseRecord();
            }
        }

        private void AddCourtCaseRecord()
        {
            var obj = new WebServices.CourtCaseReference.CourtCaseCard
            {
                Year_of_filingSpecified = true,
                Matter_Relating_toSpecified = true,
                Last_Case_DateSpecified = true,

                Case_No = txtCaseNo.Text,
                Year_of_filing = NumericHandler.ConvertToInteger(txtYearOfFiling.Text),
                Name_of_the_Court = txtCourtName.Text,
                Place = txtPlace.Text,
                Petitioner_Name = txtPetitionerName.Text,
                Opposite_Party_Name = txtOppositePartyName.Text,
                Matter_Relating_to = ddlMatterRelatingTo.SelectedItem.Text == "Land Building"
                    ? WebServices.CourtCaseReference.Matter_Relating_to.Land_Building
                    : ddlMatterRelatingTo.SelectedItem.Text == "Criminal"
                        ? WebServices.CourtCaseReference.Matter_Relating_to.Criminal
                        : ddlMatterRelatingTo.SelectedItem.Text == "Tax"
                            ? WebServices.CourtCaseReference.Matter_Relating_to.Tax
                            : ddlMatterRelatingTo.SelectedItem.Text == "Service Matter"
                                ? WebServices.CourtCaseReference.Matter_Relating_to.Service_matter
                                : ddlMatterRelatingTo.SelectedItem.Text == "Certificate Matter"
                                    ? WebServices.CourtCaseReference.Matter_Relating_to.Certificate_matter
                                    : ddlMatterRelatingTo.SelectedItem.Text == "Academics"
                                        ? WebServices.CourtCaseReference.Matter_Relating_to.Academics
                                        : ddlMatterRelatingTo.SelectedItem.Text == "Admission"
                                            ? WebServices.CourtCaseReference.Matter_Relating_to.Admission
                                            : ddlMatterRelatingTo.SelectedItem.Text == "SCTE_VT"
                                                ? WebServices.CourtCaseReference.Matter_Relating_to.SCTE_x0026_VT
                                                : ddlMatterRelatingTo.SelectedItem.Text == "Other"
                                                    ? WebServices.CourtCaseReference.Matter_Relating_to.Other
                                                    : WebServices.CourtCaseReference.Matter_Relating_to._blank_,
                Lowest_level_office_In_The_hierarchy_Relating_To_This_Case = ddlLowestLevelOffice.SelectedItem.Text,
                Last_Case_Date = DateTimeParser.ParseDateTime(txtLastDate.Text),
                Case_Status = txtCaseStatus.Text
            };
            var resultMessage = SOAPServices.AddCourtCaseRecord(obj, Session["SessionCompanyName"] as string);
            if (resultMessage == ResultMessages.SuccessfullMessage)
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