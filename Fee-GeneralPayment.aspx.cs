using HRMS.Common;
using HRMSODATA;
using InfrastructureManagement.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class Fee_GeneralPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["SessionCompanyName"] as string))
            {
                string message = string.Format("Message: {0}\\n\\n", "Please select a company");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
                Response.Redirect("Default.aspx");
                txtPostingDate.Text = System.DateTime.Now.ToString();
            }
        }

        protected void btnGeneralPaymentSubmit_Click(object sender, EventArgs e)
        {

            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();

            if (lstUserRole != null)
            {

                var role = lstUserRole.FirstOrDefault(x =>
                    string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Page_Name.Trim(), "Fee General Payment", StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Module_Name.Trim(), "Accounts", StringComparison.OrdinalIgnoreCase));


                if (role == null || Convert.ToBoolean(role.Insert))
                {
                    var obj = new WebServices.FeeGeneralPaymentReference.GeneralPayment
                    {
                        AmountSpecified = true,
                        Amount_LCYSpecified = true,
                        //Date__TimeSpecified = true,
                        // Cheque_DateSpecified = true,
                        Payment_Type_Collection_MethodSpecified = true,
                        Posting_DateSpecified = true,
                        StatusSpecified = true,
                        TypeSpecified = true,

                        Type = ddlType.SelectedItem.Text == "Vendor" ? WebServices.FeeGeneralPaymentReference.Type.Vendor
                : ddlType.SelectedItem.Text == "Caution_Money" ? WebServices.FeeGeneralPaymentReference.Type.Caution_Money
                : ddlType.SelectedItem.Text == "Employee" ? WebServices.FeeGeneralPaymentReference.Type.Employee
                : WebServices.FeeGeneralPaymentReference.Type._blank_,

                        Vendor_Name = ddlType.SelectedItem.Text == "Vendor" ? ddlVendorNo.SelectedItem.Text.Split('_')[1] : string.Empty,
                        Vendor_No = ddlType.SelectedItem.Text == "Vendor" ? ddlVendorNo.SelectedValue : string.Empty,
                        Student_Name = ddlType.SelectedItem.Text == "Caution_Money" ? ddlStudentNo.SelectedItem.Text.Split('_')[1] : string.Empty,
                        Student_No = ddlType.SelectedItem.Text == "Caution_Money" ? ddlStudentNo.SelectedValue : string.Empty,
                        Employee_Name = ddlType.SelectedItem.Text == "Employee" ? ddlEmployeeNo.SelectedItem.Text.Split('_')[1] : string.Empty,
                        Employee_No = ddlType.SelectedItem.Text == "Employee" ? ddlEmployeeNo.SelectedValue : string.Empty,


                        Posting_Date = DateTimeParser.ParseDateTime(txtPostingDate.Text),
                        Payment_Type_Collection_Method = ddlPaymentMethod.SelectedItem.Text == "CASH" ? WebServices.FeeGeneralPaymentReference.Payment_Type_Collection_Method.CASH
                : ddlPaymentMethod.SelectedItem.Text == "BANK" ? WebServices.FeeGeneralPaymentReference.Payment_Type_Collection_Method.BANK
                : WebServices.FeeGeneralPaymentReference.Payment_Type_Collection_Method._blank_,

                        Cash_G_L_Account_No = ddlPaymentMethod.SelectedItem.Text == "CASH" ? ddlCashAccountNo.SelectedValue : string.Empty,
                        Bank_Account_No = ddlPaymentMethod.SelectedItem.Text.ToLower() == "bank" ? ddlBank_AccountNo.SelectedValue : string.Empty,
                        Narration = txtNarration.Text,
                        External_Document_No = txtExternal_Document_No.Text,
                        Amount = NumericHandler.ConvertToDecimal(txtAmount.Text),
                        Cheque_DateSpecified = ddlPaymentMethod.SelectedItem.Text.ToLower() == "bank" ? true : false,
                        Cheque_Date = DateTimeParser.ParseDateTime(txtCheque_Date.Text),
                        Cheque_No_DD = txtCheque_No_DD.Text,

                    };

                    try
                    {
                        SOAPServices.AddGeneralPayment(obj, Session["SessionCompanyName"] as string);
                        // string message = string.Format("Message: {0}\\n\\n", "Record added successfully");
                        // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
                        Alert.ShowAlert(this, "s", "Record added successfully.");
                        ClearControl();
                        // Response.Redirect("Fee-GeneralPaymentList.aspx");
                    }
                    catch (Exception ex)
                    {
                        Alert.ShowAlert(this, "e", ex.Message);
                    }
                }
                else
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to Submit the content. Kindly contact the system administrator.");
                    
                }
            }
        }

        private void ClearControl()
        {
            if (ddlType.SelectedItem.Text == "Vendor")
            {
                ddlVendorNo.ClearSelection();
                ddlVendorNo.Items.FindByValue("0").Selected = true;
            }
            if (ddlType.SelectedItem.Text == "Employee")
            {
                ddlEmployeeNo.ClearSelection();
                ddlEmployeeNo.Items.FindByValue("0").Selected = true;
            }
            ddlType.ClearSelection();
            ddlType.Items.FindByText("Select").Selected = true;
            txtPostingDate.Text = "";
            txtCheque_No_DD.Text = "";
            txtCheque_Date.Text = "";
            if (ddlPaymentMethod.SelectedValue == "BANK")
            {
                ddlBank_AccountNo.ClearSelection();
                ddlBank_AccountNo.Items.FindByValue("0").Selected = true;
            }
            if (ddlPaymentMethod.SelectedValue == "CASH")
            {
                ddlCashAccountNo.ClearSelection();
                ddlCashAccountNo.Items.FindByValue("0").Selected = true;
            }

            ddlPaymentMethod.ClearSelection();
            ddlPaymentMethod.Items.FindByText("Select").Selected = true;


            txtExternal_Document_No.Text = "";
            txtAmount.Text = "";

        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlType.SelectedItem.Text == "Vendor")
            {
                BindVendor();
                divVendorNo.Visible = true;
                divStudentNo.Visible = false;
                divEmployeeNo.Visible = false;
            }
            else if (ddlType.SelectedItem.Text == "Caution Money")
            {
                BindStudent();
                divStudentNo.Visible = true;
                divVendorNo.Visible = false;
                divEmployeeNo.Visible = false;
            }
            else
            {
                BindEmployee();
                divEmployeeNo.Visible = true;
                divVendorNo.Visible = false;
                divStudentNo.Visible = false;
            }
        }

        public void BindVendor()
        {
            var vendors = ODataServices.GetVendorList(Session["SessionCompanyName"] as string);
            var finalVendors = new List<CommonList>();
            foreach (var vendor in vendors)
            {
                finalVendors.Add(new HRMS.CommonList { No = vendor.No, Name = vendor.No + "_" + vendor.Name });
            }
            ddlVendorNo.DataSource = finalVendors;
            ddlVendorNo.DataTextField = "Name";
            ddlVendorNo.DataValueField = "No";
            ddlVendorNo.DataBind();
            ddlVendorNo.Items.Insert(0, new ListItem("Select Vendor", "0"));
        }

        public void BindStudent()
        {
            var students = ODataServices.GetStudentList(Session["SessionCompanyName"] as string);
            var finalStudents = new List<CommonList>();
            foreach (var student in students)
            {
                finalStudents.Add(new HRMS.CommonList { No = student.No, Name = student.No + "_" + student.Student_Name });
            }
            ddlStudentNo.DataSource = finalStudents;
            ddlStudentNo.DataTextField = "Name";
            ddlStudentNo.DataValueField = "No";
            ddlStudentNo.DataBind();
            ddlStudentNo.Items.Insert(0, new ListItem("Select Student", "0"));
        }

        public void BindEmployee()
        {
            var employees = ODataServices.GetEmployeeList(Session["SessionCompanyName"] as string);
            var finalEmployeess = new List<CommonList>();
            foreach (var employee in employees)
            {
                finalEmployeess.Add(new HRMS.CommonList { No = employee.No, Name = employee.No + "_" + employee.First_Name });
            }
            ddlEmployeeNo.DataSource = finalEmployeess;
            ddlEmployeeNo.DataTextField = "Name";
            ddlEmployeeNo.DataValueField = "No";
            ddlEmployeeNo.DataBind();
            ddlEmployeeNo.Items.Insert(0, new ListItem("Select Employee", "0"));
        }

        protected void ddlPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPaymentMethod.SelectedValue == "BANK")
            {
                divGLNo.Visible = true;
                divCashGLAccount.Visible = false;
                txtCheque_Date.CssClass = "form-control";
                txtCheque_No_DD.CssClass = "form-control";
                txtCheque_No_DD.ReadOnly = false;
                txtCheque_Date.ReadOnly = false;
                GetBankAccounts();
            }
            if (ddlPaymentMethod.SelectedValue == "CASH")
            {
                divCashGLAccount.Visible = true;
                divGLNo.Visible = false;
                txtCheque_Date.CssClass += " inputreadonly";
                txtCheque_No_DD.CssClass += " inputreadonly";
                txtCheque_No_DD.ReadOnly = true;
                txtCheque_Date.ReadOnly = true;
                GetCashAccounts();
            }
        }

        public void GetBankAccounts()
        {
            var accounts = ODataServices.GetBankAccountList(Session["SessionCompanyName"] as string);
            var finalAccounts = new List<CommonList>();
            foreach (var account in accounts)
            {
                finalAccounts.Add(new HRMS.CommonList { No = account.No, Name = account.No + "_" + account.Name });
            }
            ddlBank_AccountNo.DataSource = finalAccounts;
            ddlBank_AccountNo.DataTextField = "Name";
            ddlBank_AccountNo.DataValueField = "No";
            ddlBank_AccountNo.DataBind();
            ddlBank_AccountNo.Items.Insert(0, new ListItem("Select Account No", "0"));
        }

        public void GetCashAccounts()
        {
            var glAccounts = ODataServices.GetChartofAccounts(Session["SessionCompanyName"] as string);
            var finalAccounts = new List<CommonList>();
            foreach (var account in glAccounts)
            {
                finalAccounts.Add(new HRMS.CommonList { No = account.No, Name = account.No + "_" + account.Name });
            }
            ddlCashAccountNo.DataSource = finalAccounts;
            ddlCashAccountNo.DataTextField = "Name";
            ddlCashAccountNo.DataValueField = "No";
            ddlCashAccountNo.DataBind();
            ddlCashAccountNo.Items.Insert(0, new ListItem("Select Cash Account No", "0"));
        }
    }
}