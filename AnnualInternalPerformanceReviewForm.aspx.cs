using HRMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using WebServices;

namespace HRMS
{
    public partial class AnnualInternalPerformanceReviewForm : System.Web.UI.Page
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
                BindFianacialYear();
            }
        }

        private void BindFianacialYear()
        {
            var FyList = ODataServices.GetFinancialYearList(Session["SessionCompanyName"] as string);

            ddlAcademicYear.DataSource = FyList;
            ddlAcademicYear.DataTextField = "Financial_Code";
            ddlAcademicYear.DataValueField = "Financial_Code";
            ddlAcademicYear.DataBind();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Add Annual Performance", StringComparison.OrdinalIgnoreCase)
                                     && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));
            if (role == null)
            {
                AddAnnualPerformanceRecord();
            }
            else
            {
                if (!Convert.ToBoolean(role.Insert))
                {
                    Alert.ShowAlert(this, "W",
                        "You do not have permission to modify the content. Kindly contact the system administrator.");
                    return;
                }
                AddAnnualPerformanceRecord();
            }
        }

        private void AddAnnualPerformanceRecord()
        {
            var obj = new WebServices.AnnualPerformanceReference.AnnualPerformanceCard
            {
                HRMS_ID = txtHRMSIDSearch.Text,
                Name = txtEmployeeName.Text,
                Department = txtSection.Text,
                Designation = txtDesignation.Text,
                Academic_Year = ddlAcademicYear.SelectedItem.Value,
                Performance_Rating = ddlPerformanceReview.SelectedItem.Text
            };
            var resultMessage = SOAPServices.AddAnnualPerformanceRecord(obj, Session["SessionCompanyName"] as string);
            Alert.ShowAlert(this, resultMessage == ResultMessages.SuccessfullMessage ? "s" : "e", resultMessage);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                    .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Page_Name.Trim(), "Add Annual Performance", StringComparison.OrdinalIgnoreCase)
                    && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));
            if (role == null)
            {
                SearchAndBind();
            }
            else
            {
                if (!Convert.ToBoolean(role.Read))
                {
                    Alert.ShowAlert(this, "W",
                        "You do not have permission to read the data. Kindly contact the system administrator.");
                    return;
                }

                SearchAndBind();
            }
        }

        private void SearchAndBind()
        {
            if (!string.IsNullOrEmpty(txtHRMSIDSearch.Text))
            {
                var employeeResult =
                    ODataServices.GetEmployeeInfo(txtHRMSIDSearch.Text, Session["SessionCompanyName"] as string);
                if (employeeResult != null)
                {
                    txtEmployeeName.Text = employeeResult.First_Name;
                    txtDesignation.Text = employeeResult.Designation;
                    txtSection.Text = employeeResult.Dept_Trade_Section;
                    LblMessage.Text = string.Empty;
                }
                else
                {
                    txtEmployeeName.Text = string.Empty;
                    txtDesignation.Text = string.Empty;
                    txtSection.Text = string.Empty;
                    LblMessage.Text = "No record found. Try searching with valid HRMS ID.";
                }
            }
        }
    }
}