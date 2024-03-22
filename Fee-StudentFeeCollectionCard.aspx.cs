using HRMS.Common;
using HRMSODATA;
using InfrastructureManagement.Common;
using Microsoft.OData.Edm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices;
namespace HRMS
{
    public partial class Fee_StudentFeeCollectionCard : System.Web.UI.Page
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

        public void BindCustomerList()
        {
            var studentList = ODataServices.GetCustomerList(Session["SessionCompanyName"] as string);
            var finalStudentList = new List<CommonList>();

            foreach (var student in studentList)
            {
                finalStudentList.Add(new HRMS.CommonList { No = student.No, Name = student.No + "_" + student.Name });
            }

            ddlCustomerNo.DataSource = finalStudentList;
            ddlCustomerNo.DataTextField = "Name";
            ddlCustomerNo.DataValueField = "No";
            ddlCustomerNo.DataBind();
            ddlCustomerNo.Items.Insert(0, new ListItem("Select Student", "0"));
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlType.SelectedValue == "StudentFee")
            {
                divGLNo.Visible = false;
                dvdimension.Visible = false;
                divCustomerNo.Visible = true;
                BindCustomerList();
                divCustomerNo.Visible = true;
                divEmployeeNo.Visible = false;
                divfunding.Visible = false;
            }
            if (ddlType.SelectedValue == "InternalTransfer")
            {
                dvdimension.Visible = false;
                BindCustomerList();
                divCustomerNo.Visible = true;
                divEmployeeNo.Visible = false;
                divfunding.Visible = false;
            }
            if (ddlType.SelectedValue == "AdvancePayment")
            {
                dvdimension.Visible = false;
                BindCustomerList();
                divCustomerNo.Visible = true;
                divEmployeeNo.Visible = false;
                divfunding.Visible = false;
            }
            if (ddlType.SelectedValue == "OtherIncome")
            {
                dvdimension.Visible = true;
                divGLNo.Visible = true;
                divCustomerNo.Visible = false;
                divEmployeeNo.Visible = false;
                divfunding.Visible = true;
                divEmpCode.Visible = false;
                GetCashAccounts();
                ShowDimentation();
            }
            if (ddlType.SelectedValue == "StaffAdvanceRefund")
            {
                dvdimension.Visible = true;
                divGLNo.Visible = false;
                divCustomerNo.Visible = false;
                divEmployeeNo.Visible = true;
                divfunding.Visible = false;
                divEmpCode.Visible=true;
                BindEmployee();
                ShowDimentation();
            }

        }
        private void ShowDimentation()
        {
            var dimensionList = ODataServices.GetDimentionList(Session["SessionCompanyName"] as string);
            BindInstitute(dimensionList);
            BindDepartment(dimensionList);
           // BindSLCMNO(dimensionList);
            BindEmployee(dimensionList);
            BindFundingSOurce(dimensionList);
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
        private void BindFundingSOurce(IList<DimValueList> dimensionList)
        {
            var fsList = dimensionList.Where(x => string.Equals("FUNDING SOURCE", x.Dimension_Code, StringComparison.OrdinalIgnoreCase)).ToList();

            var lstFS = new List<Dimension>();
            foreach (var dc in fsList)
            {
                lstFS.Add(new HRMS.Dimension
                {
                    Code = dc.Code,
                    Name = dc.Name
                });
            }

            ddlFundingsourceCode.DataSource = lstFS;
            ddlFundingsourceCode.DataTextField = "Code";
            ddlFundingsourceCode.DataValueField = "Name";
            ddlFundingsourceCode.DataBind();
            ddlFundingsourceCode.Items.Insert(0, new ListItem("Select Funding Source", "0"));
        }

        private void BindEmployee(IList<DimValueList> dimensionList)
        {
            var empList = dimensionList.Where(x => string.Equals("EMPLOYEE", x.Dimension_Code, StringComparison.OrdinalIgnoreCase)).ToList();
            var lstemp = new List<Dimension>();
            foreach (var dc in empList)
            {
                lstemp.Add(new HRMS.Dimension
                {
                    Code = dc.Code,
                    Name = dc.Name
                });
            }


            ddlEmployeeCode.DataSource = lstemp;
            ddlEmployeeCode.DataTextField = "Code";
            ddlEmployeeCode.DataValueField = "Name";
            ddlEmployeeCode.DataBind();
            ddlEmployeeCode.Items.Insert(0, new ListItem("Select Employee", "0"));
        }

        //private void BindSLCMNO(IList<DimValueList> dimensionList)
        //{
        //    var slcmnoList = dimensionList.Where(x => string.Equals("SLCMNO", x.Dimension_Code, StringComparison.OrdinalIgnoreCase)).ToList();
        //    var lstslcmno = new List<Dimension>();
        //    foreach (var dc in slcmnoList)
        //    {
        //        lstslcmno.Add(new HRMS.Dimension
        //        {
        //            Code = dc.Code,
        //            Name = dc.Name
        //        });
        //    }
        //    ddlSlcmnoCode.DataSource = lstslcmno;
        //    ddlSlcmnoCode.DataTextField = "Code";
        //    ddlSlcmnoCode.DataValueField = "Name";
        //    ddlSlcmnoCode.DataBind();
        //    ddlSlcmnoCode.Items.Insert(0, new ListItem("Select Slcmno", "0"));
        //}

        private void BindDepartment(IList<DimValueList> dimensionList)
        {
            var departmentList = dimensionList.Where(x => string.Equals("DEPARTMENT", x.Dimension_Code, StringComparison.OrdinalIgnoreCase)).ToList();
            var lstDpt = new List<Dimension>();
            foreach (var dc in departmentList)
            {
                lstDpt.Add(new HRMS.Dimension
                {
                    Code = dc.Code,
                    Name = dc.Name
                });
            }
            ddlDepartmentCode.DataSource = lstDpt;
            ddlDepartmentCode.DataTextField = "Code";
            ddlDepartmentCode.DataValueField = "Code";
            ddlDepartmentCode.DataBind();
            ddlDepartmentCode.Items.Insert(0, new ListItem("Select Department", "0"));
        }

        private void BindInstitute(IList<DimValueList> dimensionList)
        {
            var instituteList = dimensionList.Where(x => string.Equals("INSTITUTE", x.Dimension_Code, StringComparison.OrdinalIgnoreCase)).ToList();
            var lstInstitute = new List<Dimension>();
            foreach (var dc in instituteList)
            {
                lstInstitute.Add(new HRMS.Dimension
                {
                    Code = dc.Code,
                    Name = dc.Name
                });
            }
            ddlInstiuteCode.DataSource = lstInstitute;
            ddlInstiuteCode.DataTextField = "Code";
            ddlInstiuteCode.DataValueField = "Code";
            ddlInstiuteCode.DataBind();
            ddlInstiuteCode.Items.Insert(0, new ListItem("Select Institute", "0"));
        }

        public void GetBankAccounts()
        {
            var accounts = ODataServices.GetBankAccountList(Session["SessionCompanyName"] as string);
            var finalAccounts = new List<CommonList>();
            foreach (var account in accounts)
            {
                finalAccounts.Add(new HRMS.CommonList { No = account.No, Name = account.No + "_" + account.Name });
            }
            ddlBankAccountNo.DataSource = finalAccounts;
            ddlBankAccountNo.DataTextField = "Name";
            ddlBankAccountNo.DataValueField = "No";
            ddlBankAccountNo.DataBind();
            ddlBankAccountNo.Items.Insert(0, new ListItem("Select Account No", "0"));
        }

        public void GetCashAccounts()
        {
            var glAccounts = ODataServices.GetChartofAccounts(Session["SessionCompanyName"] as string);
            var finalAccounts = new List<CommonList>();
            foreach (var account in glAccounts)
            {
                finalAccounts.Add(new HRMS.CommonList { No = account.No, Name = account.No + "_" + account.Name });
            }
            ddlCashGLAccountNo.DataSource = finalAccounts;
            ddlCashGLAccountNo.DataTextField = "Name";
            ddlCashGLAccountNo.DataValueField = "No";
            ddlCashGLAccountNo.DataBind();
            ddlCashGLAccountNo.Items.Insert(0, new ListItem("Select Cash Account No", "0"));

            ddlGLNo.DataSource = finalAccounts;
            ddlGLNo.DataTextField = "Name";
            ddlGLNo.DataValueField = "No";
            ddlGLNo.DataBind();
            ddlGLNo.Items.Insert(0, new ListItem("Select Cash Account No", "0"));
        }

        protected void ddlPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPaymentType.SelectedValue == "BANK")
            {
                divCashGLAccount.Visible = false;
                divBankAccountNo.Visible = true;
                divTranDate.Visible = true;
                divTranNo.Visible = true;
                GetBankAccounts();
            }
            if (ddlPaymentType.SelectedValue == "CASH")
            {
                divCashGLAccount.Visible = true;
                divBankAccountNo.Visible = false;
                divTranDate.Visible = false;
                divTranNo.Visible = false;
                GetCashAccounts();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!((Fee)this.Master).IsPageRefresh)
            {
                List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
                if (lstUserRole != null)
                {
                    var role = lstUserRole.FirstOrDefault(x =>
                    string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Page_Name.Trim(), "Add Student Fee", StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Module_Name.Trim(), "Accounts", StringComparison.OrdinalIgnoreCase));

                    if (role == null || Convert.ToBoolean(role.Insert))
                    {
                        if (ddlPaymentType.SelectedValue == "BANK")
                        {
                            if (ddlBankAccountNo.SelectedValue == "0")
                            {
                                Alert.ShowAlert(this, "e", "Please select a Bank account no");
                                return;
                            }
                        }
                        if (ddlPaymentType.SelectedValue == "CASH")
                        {
                            if (ddlCashGLAccountNo.SelectedValue == "0")
                            {
                                Alert.ShowAlert(this, "e", "Please select a Cash GL Account No");
                                return;
                            }
                        }

                        var obj = new WebServices.StudentFeeCollectionCardReference.StudentFeeCollectionCard
                        {
                            TypeSpecified = true,
                            AmountSpecified = true,
                            // Amount_LCYSpecified = true,
                            Payment_Type_Collection_MethodSpecified = true,
                            Cheque_DateSpecified = true,
                            //  Date__TimeSpecified = true,
                              Posting_DateSpecified       = true, 
                            StatusSpecified = true,

                            Type = ddlType.SelectedValue == "StudentFee" ? WebServices.StudentFeeCollectionCardReference.Type.Student_Fee
                        : ddlType.SelectedValue == "OtherIncome" ? WebServices.StudentFeeCollectionCardReference.Type.Other_Income
                        : ddlType.SelectedValue == "InternalTransfer" ? WebServices.StudentFeeCollectionCardReference.Type.Internal_Transfer
                        : ddlType.SelectedValue == "AdvancePayment" ? WebServices.StudentFeeCollectionCardReference.Type.Advance_Payment
                        : ddlType.SelectedValue == "StaffAdvanceRefund" ? WebServices.StudentFeeCollectionCardReference.Type.Staff_Advance_Refund
                        : WebServices.StudentFeeCollectionCardReference.Type._blank_,
                            Customer_No = (ddlType.SelectedValue != "OtherIncome" || ddlType.SelectedValue != "StaffAdvanceRefund") ? ddlCustomerNo.SelectedValue : string.Empty,
                            Amount = NumericHandler.ConvertToDecimal(txtAmount.Text),
                            // Amount_LCY = NumericHandler.ConvertToDecimal(txtAmountLCY.Text),
                            Payment_Type_Collection_Method = ddlPaymentType.SelectedItem.Text == "CASH" ? WebServices.StudentFeeCollectionCardReference.Payment_Type_Collection_Method.CASH
                            : ddlPaymentType.SelectedItem.Text == "BANK" ? WebServices.StudentFeeCollectionCardReference.Payment_Type_Collection_Method.BANK
                            : WebServices.StudentFeeCollectionCardReference.Payment_Type_Collection_Method._blank_,
                            Cash_G_L_Account_No = ddlPaymentType.SelectedValue == "CASH" ? ddlCashGLAccountNo.SelectedItem.Value : string.Empty,
                            Bank_Account_No = ddlPaymentType.SelectedValue == "BANK" ? ddlBankAccountNo.SelectedValue : string.Empty,
                            G_L_No = ddlType.SelectedValue == "OtherIncome" ? ddlGLNo.SelectedValue : string.Empty,

                            Employee_No = ddlType.SelectedValue == "StaffAdvanceRefund" ? ddlEmployeeNo.SelectedValue : string.Empty,

                            Shortcut_Dimension_1 = ddlType.SelectedValue == "OtherIncome" || ddlType.SelectedValue == "StaffAdvanceRefund" ?
                    ddlInstiuteCode.SelectedItem.Text != "Select Institute" ? ddlInstiuteCode.SelectedItem.Text : "" : string.Empty,

                            Shortcut_Dimension_2 = ddlType.SelectedValue == "OtherIncome" || ddlType.SelectedValue == "StaffAdvanceRefund" ?
                    ddlDepartmentCode.SelectedItem.Text != "Select Department" ? ddlDepartmentCode.SelectedItem.Text : "" : string.Empty,

                            Shortcut_Dimension_5 = ddlType.SelectedValue == "OtherIncome" || ddlType.SelectedValue == "StaffAdvanceRefund" ?
                    ddlFundingsourceCode.SelectedItem.Text != "Select Funding Source" ? ddlFundingsourceCode.SelectedItem.Text : "" : string.Empty,

                            Ext_Doc_No = txtExDocNo.Text,
                            Narration = txtNarration.Text,
                            Cheque_No_DD = ddlPaymentType.SelectedValue == "BANK" ? txtTranNo.Text : string.Empty,
                            Cheque_Date = DateTimeParser.ParseDateTime(txtTranDate.Text),
                            Posting_Date = DateTimeParser.ParseDateTime(txtPostingDate.Text),
                        };

                        try
                        {
                            SOAPServices.AddStudentFee(obj, Session["SessionCompanyName"] as string);
                            ClearControl();
                            Alert.ShowAlert(this, "s", "Record added successfully.");
                        }
                        catch (Exception ex)
                        {
                            Alert.ShowAlert(this, "e", ex.Message);
                        }
                    }
                    else
                    {
                        Alert.ShowAlert(this, "W", "You do not have permission to submit the content. Kindly contact the system administrator.");

                    }
                } 
            }
            else
            {
                ClearControl();
            }

        }
        private void ClearControl()
        {

            if (ddlType.SelectedValue == "StudentFee")
            {
                ddlCustomerNo.ClearSelection();
                ddlCustomerNo.Items.FindByValue("0").Selected = true;
            }
            if (ddlType.SelectedValue == "InternalTransfer")
            {
                ddlCustomerNo.ClearSelection();
                ddlCustomerNo.Items.FindByValue("0").Selected = true;
            }
            if (ddlType.SelectedValue == "AdvancePayment")
            {
                ddlCustomerNo.ClearSelection();
                ddlCustomerNo.Items.FindByValue("0").Selected = true;
            }
            if (ddlType.SelectedValue == "OtherIncome")
            {
                ddlGLNo.ClearSelection();
                ddlGLNo.Items.FindByValue("0").Selected = true;
                ddlCashGLAccountNo.ClearSelection();
                ddlCashGLAccountNo.Items.FindByValue("0").Selected = true;
                ddlInstiuteCode.ClearSelection();
                ddlInstiuteCode.Items.FindByValue("0").Selected = true;
                ddlDepartmentCode.ClearSelection();
                ddlDepartmentCode.Items.FindByValue("0").Selected = true;
                //ddlSlcmnoCode.ClearSelection();
                //ddlSlcmnoCode.Items.FindByValue("0").Selected = true;
                ddlFundingsourceCode.ClearSelection();
                ddlFundingsourceCode.Items.FindByValue("0").Selected = true;
            }
            if (ddlType.SelectedValue == "StaffAdvanceRefund")
            {
                ddlInstiuteCode.ClearSelection();
                ddlInstiuteCode.Items.FindByValue("0").Selected = true;
                ddlDepartmentCode.ClearSelection();
                ddlDepartmentCode.Items.FindByValue("0").Selected = true;
                //ddlSlcmnoCode.ClearSelection();
                //ddlSlcmnoCode.Items.FindByValue("0").Selected = true;
                ddlEmployeeNo.ClearSelection();
                ddlEmployeeNo.Items.FindByValue("0").Selected = true;
                ddlFundingsourceCode.ClearSelection();
                ddlFundingsourceCode.Items.FindByValue("0").Selected = true;
                divCustomerNo.Visible = false;
                divEmployeeNo.Visible = true;
            }
            ddlType.ClearSelection();
            ddlType.Items.FindByValue("Select").Selected = true;

            if (ddlPaymentType.SelectedValue == "BANK")
            {
                ddlBankAccountNo.ClearSelection();
                ddlBankAccountNo.Items.FindByValue("0").Selected = true;
                txtTranDate.Text = "";
                txtTranNo.Text = "";
            }
            if (ddlPaymentType.SelectedValue == "CASH")
            {
                ddlCashGLAccountNo.ClearSelection();
                ddlCashGLAccountNo.Items.FindByValue("0").Selected = true;
            }
            ddlPaymentType.ClearSelection();
            ddlPaymentType.Items.FindByValue("Select").Selected = true;


            txtAmount.Text = "";
            txtExDocNo.Text = "";
            txtNarration.Text = "";
            txtPostingDate.Text = "";
        }
    }
    public class Dimension
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}