using HRMS.Common;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebServices;
using System.Linq;

namespace HRMS
{
    public partial class TransferEmployeeJoiningForm : System.Web.UI.Page
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
                var station = ODataServices.GetStationList(Session["SessionCompanyName"] as string);
                ddlToStation.DataSource = station;
                ddlToStation.DataTextField = "Institute_Name";
                ddlToStation.DataValueField = "Institute_Code";
                ddlToStation.DataBind();
                ddlToStation.Items.Insert(0, new ListItem("Select Station", "0"));

                ddlFromStation.DataSource = station;
                ddlFromStation.DataTextField = "Institute_Name";
                ddlFromStation.DataValueField = "Institute_Code";
                ddlFromStation.DataBind();
                ddlFromStation.Items.Insert(0, new ListItem("Select Station", "0"));
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Joining Form", StringComparison.OrdinalIgnoreCase)
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
                        "You do not have permission to read the content. Kindly contact the system administrator.");
                    return;
                }
                SearchData();
            }

        }

        private void SearchData()
        {
            if (string.IsNullOrEmpty(txtHRMSIDSearch.Text)) return;
            var result =
                ODataServices.FindEmployeeTransferHistory(txtHRMSIDSearch.Text, Session["SessionCompanyName"] as string);
            if (result == null) return;
            txtEmployeeName.Text = result.Employee_Name;
            txtDesignation.Text = result.Designation;
            ddlFromStation.ClearSelection();
            ddlFromStation.Items.FindByValue(result.From_Station).Selected = true;
            ddlToStation.ClearSelection();
            ddlToStation.Items.FindByValue(result.To_Station).Selected = true;
            txtOrderDate.Text = DateTimeParser.ConvertDateTimeToText(result.Transfer_Order_Date);
            txtLetterNo.Text = result.Letter_No;

            hdnEntryNo.Value = Convert.ToString(result.Entry_No);
            txtOrderIssuingAuthority.Text = result.Order_Issuing_Authority;
            txtReliefOrderDate.Text = DateTimeParser.ConvertDateTimeToText(result.Relief_Order_Date);
            txtReliefOrderNo.Text = result.Relief_Order_No;
            txtPromotionToDesignation.Text = result.To_Designation;
            if (result.Joining_Date.ToString() != "0001-01-01")
                txtJoiningDate.Text = DateTimeParser.ConvertDateTimeToText(result.Joining_Date);
            txtReliefOrderDate.Text = DateTimeParser.ConvertDateTimeToText(result.Relief_Order_Date);
            txtPromotionOrderDate.Text = DateTimeParser.ConvertDateTimeToText(result.Transfer_Order_Date);
            ddlJoiningEvent.ClearSelection();
            ddlJoiningEvent.Items.FindByText(string.IsNullOrEmpty(result.Relieving_Event.Trim()) ? "Select" : result.Relieving_Event).Selected = true;
        }

        protected void btnJoin_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Joining Form", StringComparison.OrdinalIgnoreCase)
                && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));
            if (role == null)
            {
                InsertJoiningData();
            }
            else
            {
                if (!Convert.ToBoolean(role.Insert))
                {
                    Alert.ShowAlert(this, "W",
                        "You do not have permission to insert the data. Kindly contact the system administrator.");
                    return;
                }
                InsertJoiningData();
            }
        }

        private void InsertJoiningData()
        {
            var obj = new WebServices.EmployeeTransferHistoryReference.EmployeeTransferHistoryCard
            {
                HRMS_ID = txtHRMSIDSearch.Text,
                Joining_Date = DateTimeParser.ParseDateTime(txtJoiningDate.Text),
                Joining_Event = ddlJoiningEvent.SelectedItem.Text == ""
                    ? WebServices.EmployeeTransferHistoryReference.Joining_Event.Transfer
                    : ddlJoiningEvent.SelectedItem.Text == "Promotion Transfer"
                        ? WebServices.EmployeeTransferHistoryReference.Joining_Event.Promotion__x0026__Transfer
                        : ddlJoiningEvent.SelectedItem.Text == "Other Reason"
                            ? WebServices.EmployeeTransferHistoryReference.Joining_Event.Other_Reasons
                            : WebServices.EmployeeTransferHistoryReference.Joining_Event._blank_,
                Entry_No = Convert.ToInt32(hdnEntryNo.Value)
            };
            var resultMessage = SOAPServices.UpdateTransferEmployeeDetails(obj, Session["SessionCompanyName"] as string);
            Alert.ShowAlert(this, resultMessage == ResultMessages.UpdateSuccessfullMessage ? "s" : "e", resultMessage);
        }
    }
}