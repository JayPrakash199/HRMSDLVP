using HRMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class StaffProfile : System.Web.UI.Page
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

            ddlAcademicYear.DataSource = FyList;
            ddlAcademicYear.DataTextField = "Financial_Code";
            ddlAcademicYear.DataValueField = "Financial_Code";
            ddlAcademicYear.DataBind();
            ddlAcademicYear.Items.Insert(0, new ListItem("Select Year", "0"));
        }
        protected override void Render(HtmlTextWriter writer)
        {
            ClientScript.RegisterForEventValidation(btnSearch.UniqueID.ToString());
            base.Render(writer);
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Employee Profile & Award Achievement", StringComparison.OrdinalIgnoreCase)
                && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));
            if (role == null)
            {
                SearchAndBindData();
            }
            else
            {
                if (!Convert.ToBoolean(role.Read))
                {
                    Alert.ShowAlert(this, "W",
                        "You do not have permission to read the data. Kindly contact the system administrator.");
                    return;
                }
                SearchAndBindData();
            }
        }

        private void SearchAndBindData()
        {
            var employeeResult = ODataServices.GetEmployeeInfo(txtHRMSIDSearch.Text, Session["SessionCompanyName"] as string);
            if (employeeResult != null)
            {
                txtEmployeeName.Text = employeeResult.First_Name;
                txtDesignation.Text = employeeResult.Designation;
                LblMessage.Text = string.Empty;
                txtBaseQualification.Text = employeeResult.Base_Qualification;
            }
            else
            {
                txtEmployeeName.Text = string.Empty;
                txtDesignation.Text = string.Empty;
                LblMessage.Text = "No record found. Try searching with valid HRMS ID.";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Employee Profile & Award Achievement", StringComparison.OrdinalIgnoreCase)
                && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));
            if (role == null)
            {
                SubmitEmployeeData();
            }
            else
            {
                if (!Convert.ToBoolean(role.Insert))
                {
                    Alert.ShowAlert(this, "W",
                        "You do not have permission to insert the data. Kindly contact the system administrator.");
                    return;
                }
                SubmitEmployeeData();
            }
        }

        private void SubmitEmployeeData()
        {
            var obj = new WebServices.EmployeeAchvReference.EmployeeAchvCard
            {
                Inservice_Qualification_UpgradationSpecified = true,
                AwardSpecified = true,

                HRMS_ID = txtHRMSIDSearch.Text,
                Employee_Name = txtEmployeeName.Text,
                Designation = txtDesignation.Text,
                Base_Qualification = txtBaseQualification.Text,
                Inservice_Qualification_Upgradation = inserviceCheck.Checked,
                Award = chkAwards.Checked,
                Achivement_Remarks = txtAchievementRemark.Text,
                Award_Details = chkAwards.Checked ? txtAwardsDetails.Text : "",



                Academic_Year = ddlAcademicYear.SelectedItem.Text == string.Empty
                    ? DateTimeParser.GetCurrentAcademicYear()
                    : ddlAcademicYear.SelectedItem.Text
            };
            var resultMessage = SOAPServices.AddEmployeeAchvRecord(obj, Session["SessionCompanyName"] as string);
            Alert.ShowAlert(this, resultMessage == ResultMessages.SuccessfullMessage ? "s" : "e", resultMessage);
        }
    }
}