using HRMS.Common;
using InfrastructureManagement.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using WebServices;

namespace HRMS
{
    public partial class AnnualEstablishmentReviewPartE : System.Web.UI.Page
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Part E(Outsourced)", StringComparison.OrdinalIgnoreCase)
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
                Persons_in_PositionSpecified = true,
                Establishment_Type = WebServices.AnnualEstablishmentReviewReference.Establishment_Type
                    .Part__x2013__E_Outsourced_on_contract,
                Persons_in_Position = !string.IsNullOrEmpty(txtPersonsinPosition.Text) ? NumericHandler.ConvertToInteger(txtPersonsinPosition.Text) : 0,
                Academic_Year = ddlFinancialYear.SelectedItem.Text,
                Remark = txtRemark.Text
            };
            var resultMessage = SOAPServices.AddAnnualEstablishmentReviewRecord(obj, Session["SessionCompanyName"] as string);
            Alert.ShowAlert(this, resultMessage == ResultMessages.SuccessfullMessage ? "s" : "e", resultMessage);
        }
    }
}