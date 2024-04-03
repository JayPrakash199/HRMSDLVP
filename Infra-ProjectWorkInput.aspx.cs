using HRMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class Infra_ProjectWorkInput : System.Web.UI.Page
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
                    string.Equals(x.Page_Name.Trim(), "New Project Details", StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Module_Name.Trim(), "Infra", StringComparison.OrdinalIgnoreCase));

                    if (role == null || Convert.ToBoolean(role.Read))
                    {
                        var collegeList = ODataServices.GetAllInstitutes(Session["SessionCompanyName"] as string).Where(x => !string.IsNullOrWhiteSpace(x.Institute_Code)).ToList();
                        ddlInstituteName.DataSource = collegeList;
                        ddlInstituteName.DataTextField = "Institute_Name";
                        ddlInstituteName.DataValueField = "Institute_Code";
                        ddlInstituteName.DataBind();
                        ddlInstituteName.Items.Insert(0, new ListItem("Select Institute", "0"));

                        ddlDistrict.DataSource = ODataServices.Getdistricts(Session["SessionCompanyName"] as string);
                        ddlDistrict.DataTextField = "Name";
                        ddlDistrict.DataValueField = "Code";
                        ddlDistrict.DataBind();
                        ddlDistrict.Items.Insert(0, new ListItem("Select District", "0"));
                    }
                    else
                    {
                        Alert.ShowAlert(this, "W", "You do not have permission to Read the content. Kindly contact the system administrator.");
                    }
                }
            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "New Project Details", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Infra", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Insert))
                {
                    var result = string.Empty;
                    if (ddlProjectType.SelectedValue == "Improvement")
                    {
                        var imporovment = new WebServices.InfraImprovementprojectReference.Improvementprojectcard
                        {
                            Date_of_commencement_as_per_agreementSpecified = true,
                            Date_of_completion_as_per_agreementSpecified = true,
                            Mode_of_WorkSpecified = true,
                            //Project_Code = txtProjectCode.Text,
                            Project_Type = WebServices.InfraImprovementprojectReference.Project_Type.Improvement,
                            Building_ID = txtBuildingId.Text,
                            District = ddlDistrict.SelectedItem.Text,
                            Name_of_the_Institute = ddlInstituteName.SelectedItem.Value,
                            Name_of_the_project = txtProjectName.Text,
                            Type_of_work = ddlTypeOfWork.SelectedValue == "Civil" ? WebServices.InfraImprovementprojectReference.Type_of_work.Civil : ddlTypeOfWork.SelectedValue == "Electrical" ? WebServices.InfraImprovementprojectReference.Type_of_work.Electrical : WebServices.InfraImprovementprojectReference.Type_of_work.PH,
                            Agency = ddlNameOfAgency.SelectedValue == "R&B" ? WebServices.InfraImprovementprojectReference.Agency.R_x0026_B
                            : ddlNameOfAgency.SelectedValue == "GPHD" ? WebServices.InfraImprovementprojectReference.Agency.GPHD
                            : ddlNameOfAgency.SelectedValue == "PHD" ? WebServices.InfraImprovementprojectReference.Agency.PHD
                            : ddlNameOfAgency.SelectedValue == "IDCO" ? WebServices.InfraImprovementprojectReference.Agency.IDCO
                            : ddlNameOfAgency.SelectedValue == "OSPH&WC" ? WebServices.InfraImprovementprojectReference.Agency.OSPH_x0026_WC
                            : ddlNameOfAgency.SelectedValue == "OSIC" ? WebServices.InfraImprovementprojectReference.Agency.OSIC
                            : WebServices.InfraImprovementprojectReference.Agency.GEMSat_principal_level,
                            Mode_of_Work = ddlModeOfWork.SelectedValue == "iOTMS" ? WebServices.InfraImprovementprojectReference.Mode_of_Work.iOTMS
                            : ddlModeOfWork.SelectedValue == "Works Module" ? WebServices.InfraImprovementprojectReference.Mode_of_Work.Works_Module
                            : WebServices.InfraImprovementprojectReference.Mode_of_Work.Deposit_mode_at_principal_level_referring_to_the_AA_issued_from_DTE_x0026_T_Govt,
                            Date_of_commencement_as_per_agreement = DateTimeParser.ParseDateTime(txtCommencementDate.Text),
                            Date_of_completion_as_per_agreement = DateTimeParser.ParseDateTime(txtCompletionPerAgreement.Text)
                        };

                        result = SOAPServices.CreateImprovementProject(imporovment, Session["SessionCompanyName"] as string);
                    }
                    else if (ddlProjectType.SelectedValue == "Ongoing")
                    {
                        var onGoing = new WebServices.InfraOngoingprojectReference.Ongoingprojectcard
                        {
                            Date_of_completion_as_per_agreementSpecified = true,
                            Date_of_commencementSpecified = true,
                            Mode_of_WorkSpecified = true,
                            //Project_Code = txtProjectCode.Text,
                            Project_Type = WebServices.InfraOngoingprojectReference.Project_Type.Ongoing,
                            District = ddlDistrict.SelectedItem.Text,
                            Name_of_the_Institute = ddlInstituteName.SelectedItem.Value,
                            Name_of_the_project = txtProjectName.Text,
                            Type_of_work = ddlTypeOfWork.SelectedValue == "Civil"
                            ? WebServices.InfraOngoingprojectReference.Type_of_work.Civil : ddlTypeOfWork.SelectedValue == "Electrical"
                            ? WebServices.InfraOngoingprojectReference.Type_of_work.Electrical : WebServices.InfraOngoingprojectReference.Type_of_work.PH,
                            Agency = ddlNameOfAgency.SelectedValue == "R&B" ? WebServices.InfraOngoingprojectReference.Agency.R_x0026_B
                            : ddlNameOfAgency.SelectedValue == "GPHD" ? WebServices.InfraOngoingprojectReference.Agency.GPHD
                            : ddlNameOfAgency.SelectedValue == "PHD" ? WebServices.InfraOngoingprojectReference.Agency.PHD
                            : ddlNameOfAgency.SelectedValue == "IDCO" ? WebServices.InfraOngoingprojectReference.Agency.IDCO
                            : ddlNameOfAgency.SelectedValue == "OSPH&WC" ? WebServices.InfraOngoingprojectReference.Agency.OSPH_x0026_WC
                            : ddlNameOfAgency.SelectedValue == "OSIC" ? WebServices.InfraOngoingprojectReference.Agency.OSIC
                            : WebServices.InfraOngoingprojectReference.Agency.GEMSat_principal_level,
                            Mode_of_Work = ddlModeOfWork.SelectedValue == "iOTMS" ? WebServices.InfraOngoingprojectReference.Mode_of_Work.iOTMS
                            : ddlModeOfWork.SelectedValue == "Works Module" ? WebServices.InfraOngoingprojectReference.Mode_of_Work.Works_Module
                            : WebServices.InfraOngoingprojectReference.Mode_of_Work.Deposit_mode_at_principal_level_referring_to_the_AA_issued_from_DTE_x0026_T_Govt,
                            Date_of_commencement = DateTimeParser.ParseDateTime(txtCommencementDate.Text),
                            Date_of_completion_as_per_agreement = DateTimeParser.ParseDateTime(txtCompletionPerAgreement.Text)
                        };
                        result = SOAPServices.CreateOngoingProject(onGoing, Session["SessionCompanyName"] as string);

                    }
                    else
                    {
                        var newProject = new WebServices.InfraNewprojectReference.Newprojectcard
                        {
                            Date_of_commencement_as_per_agreementSpecified = true,
                            Date_of_completion_as_per_agreementSpecified = true,
                            Mode_of_WorkSpecified = true,
                            //Project_Code = txtProjectCode.Text,
                            Project_Type = WebServices.InfraNewprojectReference.Project_Type.New,
                            District = ddlDistrict.SelectedItem.Text,
                            Name_of_the_Institute = ddlInstituteName.SelectedItem.Value,
                            Name_of_the_project = txtProjectName.Text,
                            Type_of_work = ddlTypeOfWork.SelectedValue == "Civil" ? WebServices.InfraNewprojectReference.Type_of_work.Civil : ddlTypeOfWork.SelectedValue == "Electrical" ? WebServices.InfraNewprojectReference.Type_of_work.Electrical : WebServices.InfraNewprojectReference.Type_of_work.PH,
                            Agency = ddlNameOfAgency.SelectedValue == "R&B" ? WebServices.InfraNewprojectReference.Agency.R_x0026_B
                            : ddlNameOfAgency.SelectedValue == "GPHD" ? WebServices.InfraNewprojectReference.Agency.GPHD
                            : ddlNameOfAgency.SelectedValue == "PHD" ? WebServices.InfraNewprojectReference.Agency.PHD
                            : ddlNameOfAgency.SelectedValue == "IDCO" ? WebServices.InfraNewprojectReference.Agency.IDCO
                            : ddlNameOfAgency.SelectedValue == "OSPH&WC" ? WebServices.InfraNewprojectReference.Agency.OSPH_x0026_WC
                            : ddlNameOfAgency.SelectedValue == "OSIC" ? WebServices.InfraNewprojectReference.Agency.OSIC
                            : WebServices.InfraNewprojectReference.Agency.GEMSat_principal_level,
                            Mode_of_Work = ddlModeOfWork.SelectedValue == "iOTMS" ? WebServices.InfraNewprojectReference.Mode_of_Work.iOTMS
                            : ddlModeOfWork.SelectedValue == "Works Module" ? WebServices.InfraNewprojectReference.Mode_of_Work.Works_Module
                            : WebServices.InfraNewprojectReference.Mode_of_Work.Deposit_mode_at_principal_level_referring_to_the_AA_issued_from_DTE_x0026_T_Govt,
                            Date_of_commencement_as_per_agreement = DateTimeParser.ParseDateTime(txtCommencementDate.Text),
                            Date_of_completion_as_per_agreement = DateTimeParser.ParseDateTime(txtCompletionPerAgreement.Text)
                        };
                        result = SOAPServices.CreateNewProject(newProject, Session["SessionCompanyName"] as string);

                    }
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