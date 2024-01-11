using HRMS.Common;
using InfrastructureManagement.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class AnnualEstablishmentReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //txtAcademicYear.Text = DateTimeParser.GetCurrentAcademicYear();
                if (string.IsNullOrEmpty(Session["SessionCompanyName"] as string))
                {
                    string message = string.Format("Message: {0}\\n\\n", "Please select a company");
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
                    Response.Redirect("Default.aspx");
                }
                BindDesignation();

                BindAcademicyear();

                var trades = ODataServices.GetDepartmentTradeSections(Session["SessionCompanyName"] as string);
                if (trades != null && trades.Count > 0)
                {
                    ddlDeptTrade.DataSource = trades;
                    ddlDeptTrade.DataTextField = "Departments_Trades_Section";
                    ddlDeptTrade.DataValueField = "Entry_No";
                    ddlDeptTrade.DataBind();
                    ddlDeptTrade.Items.Insert(0, new ListItem("Select Trade", "0"));
                }
            }
        }

        private void BindAcademicyear()
        {
            var FyList = ODataServices.GetFinancialYearList(Session["SessionCompanyName"] as string);

            ddlAcademicYear.DataSource = FyList;
            ddlAcademicYear.DataTextField = "Financial_Code";
            ddlAcademicYear.DataValueField = "Financial_Code";
            ddlAcademicYear.DataBind();
            ddlAcademicYear.Items.Insert(0, new ListItem("Select Year", "0"));
        }

        protected override void Render(HtmlTextWriter writer)
        {
            ClientScript.RegisterForEventValidation(btnSubmit.UniqueID.ToString());
            base.Render(writer);
        }

        private void BindDesignation()
        {
            var lstDesignation = ODataServices.GetDesignation(Session["SessionCompanyName"] as string);
            ddlDesignation.DataSource = lstDesignation;
            ddlDesignation.DataTextField = "Description";
            ddlDesignation.DataValueField = "Code";
            ddlDesignation.DataBind();
            ddlDesignation.Items.Insert(0, new ListItem("Select Designation", "0"));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Part A(Regular)", StringComparison.OrdinalIgnoreCase)
                                     && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));
            if (role == null)
            {
                InsertAnnualEstData();
            }
            else
            {
                if (!Convert.ToBoolean(role.Insert))
                {
                    Alert.ShowAlert(this, "W",
                        "You do not have permission to insert the data. Kindly contact the system administrator.");
                    return;
                }
                InsertAnnualEstData();
            }

        }

        private void InsertAnnualEstData()
        {
            var obj = new WebServices.AnnualEstablishmentReviewReference.AnnualEstablishmentReviewCard
            {
                Establishment_TypeSpecified = true,
                Post_GroupSpecified = true,
                Pay_Scale_GPSpecified = true,
                Sanctioned_StrengthSpecified = true,
                Persons_in_PositionSpecified = true,
                Employee_CatagorySpecified = true,
                Pay_Scale_level_7th_paySpecified = true,

                Establishment_Type = WebServices.AnnualEstablishmentReviewReference.Establishment_Type
                    .Part__x2013__A_Regular_Establishment,

                Dept_Trade_Section = ddlDeptTrade.SelectedItem.Text,
                Designation = ddlDesignation.SelectedItem.Value,
                Pay_Scale_GP = !string.IsNullOrEmpty(txtPayScaleGP.Text) ? NumericHandler.ConvertToDecimal(txtPayScaleGP.Text) : 0,
                Pay_scale_6th_pay = txtPayScale6thPay.Text,
                Sanctioned_Strength = !string.IsNullOrEmpty(txtSanctionedStrength.Text) ? NumericHandler.ConvertToInteger(txtSanctionedStrength.Text) : 0,
                Persons_in_Position = !string.IsNullOrEmpty(txtPersonsInPosition.Text) ? NumericHandler.ConvertToInteger(txtPersonsInPosition.Text) : 0,
                //Persons_in_Position = NumericHandler.ConvertToInteger(txtPersonsInPosition.Text),
                Employee_Catagory = ddlCategoryofEmployee.SelectedItem.Text == "Group A"
                    ? WebServices.AnnualEstablishmentReviewReference.Employee_Catagory.Group_A
                    : ddlCategoryofEmployee.SelectedItem.Text == "Group B"
                        ? WebServices.AnnualEstablishmentReviewReference.Employee_Catagory.Group_B
                        : ddlCategoryofEmployee.SelectedItem.Text == "Group C"
                            ? WebServices.AnnualEstablishmentReviewReference.Employee_Catagory.Group_C
                            : WebServices.AnnualEstablishmentReviewReference.Employee_Catagory.Group_D,
                Academic_Year = ddlAcademicYear.SelectedItem.Text,
                Remark = txtRemark.Text,
                Pay_Scale_level_7th_pay = !string.IsNullOrEmpty(txt7thPayScale.Text) ? NumericHandler.ConvertToDecimal(txt7thPayScale.Text) : 0
            };
            var resultMessage = SOAPServices.AddAnnualEstablishmentReviewRecord(obj, Session["SessionCompanyName"] as string);
            Alert.ShowAlert(this, resultMessage == ResultMessages.SuccessfullMessage ? "s" : "e", resultMessage);
        }
    }
}