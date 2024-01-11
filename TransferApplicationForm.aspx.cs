using HRMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class TransferApplicationForm : System.Web.UI.Page
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
                var distircts = ODataServices.Getdistricts(Session["SessionCompanyName"] as string);
                ddlFirstPreference.DataSource = distircts;
                ddlFirstPreference.DataTextField = "Name";
                ddlFirstPreference.DataValueField = "Code";
                ddlFirstPreference.DataBind();
                ddlFirstPreference.Items.Insert(0, new ListItem("Select District", "0"));

                ddlSecondPreference.DataSource = distircts;
                ddlSecondPreference.DataTextField = "Name";
                ddlSecondPreference.DataValueField = "Code";
                ddlSecondPreference.DataBind();
                ddlSecondPreference.Items.Insert(0, new ListItem("Select District", "0"));

                ddlThirdPreference.DataSource = distircts;
                ddlThirdPreference.DataTextField = "Name";
                ddlThirdPreference.DataValueField = "Code";
                ddlThirdPreference.DataBind();
                ddlThirdPreference.Items.Insert(0, new ListItem("Select District", "0"));
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) && 
                string.Equals(x.Page_Name.Trim(), "Application Form", StringComparison.OrdinalIgnoreCase)
                && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));
            if (role == null)
            {
                SearchData();
            }
            else
            {
                if (!Convert.ToBoolean(role.Read))
                {
                    Alert.ShowAlert(this, "W",
                        "You do not have permission to read the data. Kindly contact the system administrator.");
                    return;
                }
                SearchData();
            }
        }

        private void SearchData()
        {
            var employeeResult = ODataServices.GetEmployeeInfo(txtHRMSIDSearch.Text, Session["SessionCompanyName"] as string);
            if (employeeResult != null)
            {
                txtEmployeName.Text = employeeResult.First_Name;
                txtDesignation.Text = employeeResult.Designation;
                txtCurrentDate.Text = DateTimeParser.ConvertDateTimeToText(DateTime.UtcNow);
                LblMessage.Text = string.Empty;
            }
            else
            {
                txtEmployeName.Text = string.Empty;
                txtDesignation.Text = string.Empty;
                LblMessage.Text = "No record found. Try searching with valid HRMS ID.";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Application Form", StringComparison.OrdinalIgnoreCase)
                && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));
            if (role == null)
            {
                TransferApplication();
            }
            else
            {
                if (!Convert.ToBoolean(role.Insert))
                {
                    Alert.ShowAlert(this, "W",
                        "You do not have permission to insert the data. Kindly contact the system administrator.");
                    return;
                }
                TransferApplication();
            }
        }

        private void TransferApplication()
        {
            var obj = new WebServices.EmployeeTransferApplicationReference.EmployeeTransferApplicationCard
            {
                Curren_DateSpecified=true,
                GroundSpecified=true,

                HRMS_ID = txtHRMSIDSearch.Text,
                //Employee_Name = txtEmployeName.Text,
                Designation = txtDesignation.Text,
                Curren_Date = DateTime.UtcNow,
                Ground = ddlGround.SelectedItem.Text == "Medical Ground - Self"
                    ? WebServices.EmployeeTransferApplicationReference.Ground.Medical_Ground_Self
                    : ddlGround.SelectedItem.Text == "Medical ground - Dependents"
                        ? WebServices.EmployeeTransferApplicationReference.Ground.Medical_ground_Dependents
                        : ddlGround.SelectedItem.Text == "Child Education"
                            ? WebServices.EmployeeTransferApplicationReference.Ground.Child_Education
                            : ddlGround.SelectedItem.Text == "Other"
                                ? WebServices.EmployeeTransferApplicationReference.Ground.Other
                                : WebServices.EmployeeTransferApplicationReference.Ground._blank_,
                First_Preference = ddlFirstPreference.SelectedItem.Text,
                Second_Preference = ddlSecondPreference.SelectedItem.Text,
                Third_Preference = ddlThirdPreference.SelectedItem.Text,
                Current_Station = txtCurrentStation.Text
            };

            var resultMessage = SOAPServices.AddEmployeeTransferApplicationRecord(obj, Session["SessionCompanyName"] as string);
            Alert.ShowAlert(this, resultMessage == ResultMessages.SuccessfullMessage ? "s" : "e", resultMessage);
        }
    }
}