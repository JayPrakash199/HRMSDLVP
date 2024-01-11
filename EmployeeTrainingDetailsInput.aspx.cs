using HRMS.Common;
using InfrastructureManagement.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using WebServices;

namespace HRMS
{
    public partial class EmployeeTrainingDetailsInput : System.Web.UI.Page
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) && 
                string.Equals(x.Page_Name.Trim(), "Add Training", StringComparison.OrdinalIgnoreCase)
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
            var lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Add Training", StringComparison.OrdinalIgnoreCase)
                && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));
            if (role == null)
            {
                AddEmployeeTrainingHistoryRecord();
            }
            else
            {
                if (!Convert.ToBoolean(role.Insert))
                {
                    Alert.ShowAlert(this, "W",
                        "You do not have permission to insert the data. Kindly contact the system administrator.");
                    return;
                }
                AddEmployeeTrainingHistoryRecord();
            }
        }

        private void AddEmployeeTrainingHistoryRecord()
        {
            var obj = new WebServices.EmployeeTrainingHistoryReference.EmployeeTrainingHistoryCard
            {
                Type_Of_TrainingSpecified = true,
                Training_Starting_DateSpecified = true,
                Training_Ending_DateSpecified = true,
                Duration_Of_TrainingSpecified = true,


                HRMS_ID = txtHRMSIDSearch.Text,
                Employee_Name = txtEmployeeName.Text,
                Designation = txtDesignation.Text,
                Type_Of_Training = ddlTrainingType.SelectedItem.Text == "Induction Training"
                    ? WebServices.EmployeeTrainingHistoryReference.Type_Of_Training.Induction_Training
                    : ddlTrainingType.SelectedItem.Text == "Industrial Training"
                        ? WebServices.EmployeeTrainingHistoryReference.Type_Of_Training.Industrial_Training
                        : ddlTrainingType.SelectedItem.Text == "Accounts Training"
                            ? WebServices.EmployeeTrainingHistoryReference.Type_Of_Training.Accounts_Training
                            : ddlTrainingType.SelectedItem.Text == "Domain Related Training"
                                ? WebServices.EmployeeTrainingHistoryReference.Type_Of_Training.Domain_Related_Training
                                : ddlTrainingType.SelectedItem.Text == "Leadership Training"
                                    ? WebServices.EmployeeTrainingHistoryReference.Type_Of_Training.Leadership_Training
                                    : ddlTrainingType.SelectedItem.Text == "Management Training"
                                        ? WebServices.EmployeeTrainingHistoryReference.Type_Of_Training.Management_Training
                                        : ddlTrainingType.SelectedItem.Text == "NCC Training"
                                            ? WebServices.EmployeeTrainingHistoryReference.Type_Of_Training.NCC_Training
                                            : WebServices.EmployeeTrainingHistoryReference.Type_Of_Training.Other,
                Spcified_Type_of_training = ddlTrainingType.SelectedItem.Text == "Other"
                    ? txtSpcified_Type_of_training.Text
                    : string.Empty,
                Traing_Course_Title = txtCourseTitle.Text,
                Training_Starting_Date = DateTimeParser.ParseDateTime(txtStartingDate.Text),
                Training_Ending_Date = DateTimeParser.ParseDateTime(txtEndingDate.Text),
                Conducted_By = txtConductedBy.Text,
                Duration_Of_Training = NumericHandler.ConvertToInteger(txtTrainingDuration.Text),
                Training_Location = txtLocation.Text
            };
            var resultMessage = SOAPServices.AddEmployeeTrainingHistoryRecord(obj, Session["SessionCompanyName"] as string);
            Alert.ShowAlert(this, resultMessage == ResultMessages.SuccessfullMessage ? "s" : "e", resultMessage);
        }
    }
}