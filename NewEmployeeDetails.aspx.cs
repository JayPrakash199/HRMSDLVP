using HRMS.Common;
using InfrastructureManagement.Common;
using System;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class NewEmployeeDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    if (string.IsNullOrEmpty(Session["SessionCompanyName"] as string))
            //    {
            //        string message = string.Format("Message: {0}\\n\\n", "Please select a company");
            //        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
            //        Response.Redirect("Default.aspx");
            //    }
            //    if (string.IsNullOrEmpty(Session["SessionCompanyName"] as string))
            //    {
            //        string message = string.Format("Message: {0}\\n\\n", "Please select a company");
            //        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
            //        Response.Redirect("Default.aspx");
            //    }
            //    var distircts = ODataServices.Getdistricts(Session["SessionCompanyName"] as string);
            //    ddlDistrict.DataSource = distircts;
            //    ddlDistrict.DataTextField = "Name";
            //    ddlDistrict.DataValueField = "Code";
            //    ddlDistrict.DataBind();
            //    ddlDistrict.Items.Insert(0, new ListItem("Select District", "0"));
            //}

        }

        protected void btnEmployeeSubmit_Click(object sender, EventArgs e)
        {
            //var employee = new WebServices.EmplaoyeeReference.EmployeeCard
            //{
            //    GenderSpecified = true,
            //    Employment_StatusSpecified = true,
            //    Pension_RemarkSpecified = true,
            //    MACP_StatusSpecified = true,
            //    D_O_J_ServiceSpecified = true,
            //    Date_of_incrementSpecified = true,
            //    Account_TypeSpecified = true,
            //    Basic_Gr_PaySpecified = true,
            //    Birth_DateSpecified = true,
            //    CategorySpecified = true,
            //    D_O_SSpecified = true,
            //    Post_GroupSpecified = true,
                
            //    No = txtHRMSId.Text,
            //    Bill_Group = ddlBillGroup.SelectedItem.Text,
            //    Account_Type = ddlAccountType.SelectedItem.Text == "GPF"
            //    ? WebServices.EmplaoyeeReference.Account_Type.GPF : ddlAccountType.SelectedItem.Text == "PRAN"
            //    ? WebServices.EmplaoyeeReference.Account_Type.PRAN : WebServices.EmplaoyeeReference.Account_Type._blank_,
            //    Designation = ddlDesignation.SelectedItem.Text,
            //    Post_Group = ddlPostGroup.SelectedItem.Text == "A"
            //    ? WebServices.EmplaoyeeReference.Post_Group.A : ddlPostGroup.SelectedItem.Text == "B"
            //    ? WebServices.EmplaoyeeReference.Post_Group.B : ddlPostGroup.SelectedItem.Text == "C"
            //    ? WebServices.EmplaoyeeReference.Post_Group.C : WebServices.EmplaoyeeReference.Post_Group._blank_,
            //    Birth_Date = DateTimeParser.ParseDateTime(txtDOB.Text),
            //    Home_Dist = ddlDistrict.SelectedItem.Text,
            //    E_Mail = txtEmail.Text,
            //    EPIC_No = txtEpicNo.Text,
            //    First_Name = txtNameOfStaff.Text,
            //    Bill_Type = ddlBillType.SelectedItem.Text,
            //    GPF_PRAN_No = txtGPFPRAN.Text,
            //    Gender = ddlGender.SelectedItem.Text == "Male"
            //    ? WebServices.EmplaoyeeReference.Gender.Male : ddlGender.SelectedItem.Text == "Female"
            //    ? WebServices.EmplaoyeeReference.Gender.Female : WebServices.EmplaoyeeReference.Gender._blank_,
            //    Category = ddlCategory.SelectedItem.Text == "General"
            //    ? WebServices.EmplaoyeeReference.Category.General : ddlCategory.SelectedItem.Text == "OBC"
            //    ? WebServices.EmplaoyeeReference.Category.OBC : ddlCategory.SelectedItem.Text == "SEBC"
            //    ? WebServices.EmplaoyeeReference.Category.SEBC : ddlCategory.SelectedItem.Text == "SC"
            //    ? WebServices.EmplaoyeeReference.Category.SC : ddlCategory.SelectedItem.Text == "ST"
            //    ? WebServices.EmplaoyeeReference.Category.ST : WebServices.EmplaoyeeReference.Category._blank_,
            //    D_O_S = DateTimeParser.ParseDateTime(txtDOS.Text),
            //    Basic_Gr_Pay = NumericHandler.ConvertToDecimal(txtBasicJRPay.Text),
            //    Mobile_No = txtBasicJRPay.Text,
            //    Aadhaar_No = txtAadhaarNo.Text
            //};
            //var resultMessage = SOAPServices.CreateEmployee(employee, Session["SessionCompanyName"] as string);
            //if (resultMessage == ResultMessages.SuccessfullMessage)
            //{
            //    Alert.ShowAlert(this, "s", resultMessage);
            //}
            //else
            //{
            //    Alert.ShowAlert(this, "e", resultMessage);
            //}
        }
    }
}