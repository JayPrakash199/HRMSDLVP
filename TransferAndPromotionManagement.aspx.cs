using HRMS.Common;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebServices;
using System.Linq;

namespace HRMS
{
    public partial class TransferAndPromotionManagement : System.Web.UI.Page
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
                string.Equals(x.Page_Name.Trim(), "Add Transfer Record", StringComparison.OrdinalIgnoreCase)
                && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));
            if (role == null)
            {
                SearchRecord();
            }
            else
            {
                if (!Convert.ToBoolean(role.Read))
                {
                    Alert.ShowAlert(this, "W",
                        "You do not have permission to read the content. Kindly contact the system administrator.");
                    return;
                }
                SearchRecord();
            }
        }

        private void SearchRecord()
        {
            var employeeResult = ODataServices.GetEmployeeInfo(txtHRMSID.Text, Session["SessionCompanyName"] as string);
            if (employeeResult != null)
            {
                txtEmployeeName.Text = employeeResult.First_Name;
                txtDesignation.Text = employeeResult.Designation;
                LblMessage.Text = string.Empty;
                txtCurrentStation.Text = employeeResult.Current_Station;
                ddlFromStation.ClearSelection();
                ddlFromStation.Items.FindByValue(employeeResult.Current_Station).Selected = true;
            }
            else
            {
                txtEmployeeName.Text = string.Empty;
                txtDesignation.Text = string.Empty;
                LblMessage.Text = "No record found. Try searching with valid HRMS ID.";
                LblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btntransferSubmit_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Add Transfer Record", StringComparison.OrdinalIgnoreCase)
                && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));
            if (role == null)
            {
                AddTransferRecord();
            }
            else
            {
                if (!Convert.ToBoolean(role.Insert))
                {
                    Alert.ShowAlert(this, "W",
                        "You do not have permission to insert the data. Kindly contact the system administrator.");
                    return;
                }
                AddTransferRecord();
            }
        }

        private void AddTransferRecord()
        {
            var obj = new WebServices.EmployeeTransferHistoryReference.EmployeeTransferHistoryCard
            {
                Relieving_EventSpecified = true,
                StatusSpecified = true,
                Transfer_Order_DateSpecified = true,
                Relief_Order_DateSpecified = true,
                Promotion_order_dateSpecified = true,

                HRMS_ID = txtHRMSID.Text,
                Employee_Name = txtEmployeeName.Text,
                Designation = txtDesignation.Text,
                From_Station = ddlFromStation.SelectedValue,
                To_Station = ddlToStation.SelectedValue,
                Transfer_Order_Date = DateTimeParser.ParseDateTime(txtTransferOrderDate.Text),
                Letter_No = ddlRelievingEvent.SelectedItem.Text == "Promotion Transfer"
                    ? txtLetterNo.Text
                    : txtPromotionLetterNo.Text,
                Relieving_Event = ddlRelievingEvent.SelectedItem.Text == "Routine Transfer"
                    ? WebServices.EmployeeTransferHistoryReference.Relieving_Event.Routine_Transfer
                    : ddlRelievingEvent.SelectedItem.Text == "Promotion Transfer"
                        ? WebServices.EmployeeTransferHistoryReference.Relieving_Event.Promotion_Transfer
                        : ddlRelievingEvent.SelectedItem.Text == "Correction Transfer"
                            ? WebServices.EmployeeTransferHistoryReference.Relieving_Event.Correction_Transfer
                            : ddlRelievingEvent.SelectedItem.Text == "Other Reason"
                                ? WebServices.EmployeeTransferHistoryReference.Relieving_Event.Other_Reason
                                : WebServices.EmployeeTransferHistoryReference.Relieving_Event._blank_,
                Relief_Order_No = txtReliefOrderNo.Text,
                Relief_Order_Date = DateTimeParser.ParseDateTime(txtReliefOrderDate.Text),
                Promotion_order_date = DateTimeParser.ParseDateTime(txtPromotionOrderDate.Text),
                //To_Designation = ddlDesignation.SelectedItem.Text
            };
            var resultMessage =
                SOAPServices.AddEmployeeTransferAndPromotionRecord(obj, Session["SessionCompanyName"] as string);

            String msg = string.Format("Employee :{0} Relieved Successfully", txtHRMSID.Text);

            if (resultMessage == ResultMessages.SuccessfullMessage)
            {
                Alert.ShowAlert(this, "s", msg);
            }
            else
            {
                Alert.ShowAlert(this, "e", resultMessage);
            }
        }
    }
}