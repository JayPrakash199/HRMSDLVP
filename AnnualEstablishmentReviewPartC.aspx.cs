using HRMS.Common;
using InfrastructureManagement.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class AnnualEstablishmentReviewPartC : System.Web.UI.Page
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
                BindDesignation();
                BindAcademicyear();
            }
        }

        private void BindAcademicyear()
        {
            var FyList = ODataServices.GetFinancialYearList(Session["SessionCompanyName"] as string);
            ddlFinancialYear.DataSource = FyList;
            ddlFinancialYear.DataTextField = "Financial_Code";
            ddlFinancialYear.DataValueField = "Financial_Code";
            ddlFinancialYear.DataBind();
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
                string.Equals(x.Page_Name.Trim(), "Part C(Non-regular)", StringComparison.OrdinalIgnoreCase)
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
                Persons_in_PositionSpecified=true,
                Establishment_TypeSpecified = true,
                Employee_CatagorySpecified = true,
                Pay_Scale_level_7th_paySpecified = true,
                Establishment_Type = WebServices.AnnualEstablishmentReviewReference.Establishment_Type
                    .Part__x2013__C_Non_regular_Establishment,
                Academic_Year = ddlFinancialYear.SelectedItem.Text,
                Employee_Catagory = ddlCategoryofEmployee.SelectedItem.Text == "Group A"
                    ? WebServices.AnnualEstablishmentReviewReference.Employee_Catagory.Group_A
                    : ddlCategoryofEmployee.SelectedItem.Text == "Group B"
                        ? WebServices.AnnualEstablishmentReviewReference.Employee_Catagory.Group_B
                        : ddlCategoryofEmployee.SelectedItem.Text == "Group C"
                            ? WebServices.AnnualEstablishmentReviewReference.Employee_Catagory.Group_C
                            : WebServices.AnnualEstablishmentReviewReference.Employee_Catagory.Group_D,
                Remark = txtRemark.Text,
                Designation = ddlDesignation.SelectedItem.Value,
                Persons_in_Position= !string.IsNullOrEmpty(txtPersonsinPosition.Text) ? NumericHandler.ConvertToInteger(txtPersonsinPosition.Text) : 0,
                Pay_Scale_level_7th_pay = NumericHandler.ConvertToDecimal(txtPayScaleLevel7thPay.Text)
            };
            var resultMessage = SOAPServices.AddAnnualEstablishmentReviewRecord(obj, Session["SessionCompanyName"] as string);
            Alert.ShowAlert(this, resultMessage == ResultMessages.SuccessfullMessage ? "s" : "e", resultMessage);
        }

    }
}