using HRMS.Common;
using HRMSODATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class EditEmployee : System.Web.UI.Page
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

                Dictionary<int, string> employeedData = new Dictionary<int, string>();
                employeedData.Add(0, "select");
                employeedData.Add(1, "Ad hoc");
                employeedData.Add(2, "Temporary status");
                employeedData.Add(3, "Initial appointee");
                employeedData.Add(4, "Regular");
                employeedData.Add(5, "Inactive");
                ddlempStatus.DataTextField = "Value";
                ddlempStatus.DataValueField = "Key";
                ddlempStatus.DataSource = employeedData;
                ddlempStatus.DataBind();

                ddlMACPStatus.ClearSelection();
                ddlMACPStatus.Items.Insert(0, new ListItem("Nil", "0"));
                ddlMACPStatus.Items.Insert(1, new ListItem("1st", "1"));
                ddlMACPStatus.Items.Insert(2, new ListItem("2nd", "2"));
                ddlMACPStatus.Items.Insert(3, new ListItem("3rd", "3"));
            }
        }

        protected void btnEditEmployeeSearch_Click(object sender, EventArgs e)
        {
            var lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.Page_Name.Trim(), "Update Additional Employee Details", StringComparison.OrdinalIgnoreCase)
                                     && string.Equals(x.Module_Name.Trim().Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));
            if (role == null)
            {
                var employeeResult = ODataServices.GetAdditionalEmployeeInfo(txtHRMSIDSearch.Text, Session["SessionCompanyName"] as string);
                if (employeeResult != null)
                {
                    SearchRecord(employeeResult);
                }
                else
                {
                    txtEmployeeName.Text = string.Empty;
                    txtDateOfIncrement.Text = string.Empty;
                    LblMessage.Text = string.Empty;
                    ddlempStatus.Enabled = false;
                    txtDateOfIncrement.Enabled = false;
                    ddlMACPStatus.Enabled = false;
                    LblMessage.Text = "No record found. Try searching with valid HRMS ID.";
                }
            }
            else
            {
                if (!Convert.ToBoolean(role.Read))
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to read the content. Kindly contact the system administrator.");
                    return;
                }
                var employeeResult = ODataServices.GetAdditionalEmployeeInfo(txtHRMSIDSearch.Text, Session["SessionCompanyName"] as string);
                if (employeeResult != null)
                {
                    SearchRecord(employeeResult);
                }
                else
                {
                    txtEmployeeName.Text = string.Empty;
                    txtDateOfIncrement.Text = string.Empty;
                    LblMessage.Text = string.Empty;
                    ddlempStatus.Enabled = false;
                    txtDateOfIncrement.Enabled = false;
                    ddlMACPStatus.Enabled = false;
                    LblMessage.Text = "No record found. Try searching with valid HRMS ID.";
                }
            }
        }

        private void SearchRecord(EmployeeAdditionalInfoList employeeResult)
        {
            txtEmployeeName.Text = employeeResult.Employee_Name;
            ddlempStatus.ClearSelection();
            ddlempStatus.Items.FindByText(employeeResult.Employment_Status).Selected = true;
            txtDateOfIncrement.Text = DateTimeParser.ConvertDateTimeToText(employeeResult.Date_of_increment);
            ddlMACPStatus.ClearSelection();
            ddlMACPStatus.Items.FindByText(employeeResult.MACP_Status).Selected = true;
            hdnEntryNo.Value = Convert.ToString(employeeResult.Entry_No);
            LblMessage.Text = string.Empty;
            ddlempStatus.Enabled = true;
            txtDateOfIncrement.Enabled = true;
            ddlMACPStatus.Enabled = true;
        }

        protected void btnEditAdditionalEmployee_Click(object sender, EventArgs e)
        {
            var lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Update Additional Employee Details", StringComparison.OrdinalIgnoreCase)
                && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));

            if (role == null)
            {
                EditAdditionalEmployee();
            }
            else
            {
                if (!Convert.ToBoolean(role.Modify))
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to modify the content. Kindly contact the system administrator.");
                    return;
                }
                EditAdditionalEmployee();
            }
        }

        private void EditAdditionalEmployee()
        {
            if (string.IsNullOrEmpty(hdnEntryNo.Value)) return;
            var obj = new WebServices.EmployeeAdditionalCardReference.EmployeeAdditionalInfoCard
            {
                HRMS_ID = txtHRMSIDSearch.Text,
                Entry_No = Convert.ToInt32(hdnEntryNo.Value),
                Employment_Status = ddlempStatus.SelectedItem.Text == "Ad hoc"
                    ? WebServices.EmployeeAdditionalCardReference.Employment_Status.Ad_hoc
                    : ddlempStatus.SelectedItem.Text == "Temporary status"
                        ? WebServices.EmployeeAdditionalCardReference.Employment_Status.Temporary_status
                        : ddlempStatus.SelectedItem.Text == "Initial appointee"
                            ? WebServices.EmployeeAdditionalCardReference.Employment_Status.Initial_appointee
                            : ddlempStatus.SelectedItem.Text == "Regular"
                                ? WebServices.EmployeeAdditionalCardReference.Employment_Status.Regular
                                : ddlempStatus.SelectedItem.Text == "Inactive"
                                    ? WebServices.EmployeeAdditionalCardReference.Employment_Status.Inactive
                                    : WebServices.EmployeeAdditionalCardReference.Employment_Status._blank_,
                Date_of_increment = DateTimeParser.ParseDateTime(txtDateOfIncrement.Text),
                MACP_Status = ddlMACPStatus.SelectedItem.Text == "Nil"
                    ? WebServices.EmployeeAdditionalCardReference.MACP_Status.Nil
                    : ddlMACPStatus.SelectedItem.Text == "1st"
                        ? WebServices.EmployeeAdditionalCardReference.MACP_Status._x0031_st
                        : ddlMACPStatus.SelectedItem.Text == "2nd"
                            ? WebServices.EmployeeAdditionalCardReference.MACP_Status._x0032_nd
                            : ddlMACPStatus.SelectedItem.Text == "3rd"
                                ? WebServices.EmployeeAdditionalCardReference.MACP_Status._x0033_rd
                                : WebServices.EmployeeAdditionalCardReference.MACP_Status._blank_
            };
            var resultMessage = SOAPServices.UpdateAdditionalEmployeeDetails(obj, Session["SessionCompanyName"] as string);
            Alert.ShowAlert(this, resultMessage == ResultMessages.UpdateSuccessfullMessage ? "s" : "e",
                resultMessage);
        }
    }
}