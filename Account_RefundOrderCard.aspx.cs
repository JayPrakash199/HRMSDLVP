using HRMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class Account_RefundOrderCard : System.Web.UI.Page
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
                    txtPostingDate.Text = System.DateTime.Now.ToString();
                }
                BindFianacialYear();
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
                    string.Equals(x.Page_Name.Trim(), "Add Caution Refund Order", StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Module_Name.Trim(), "Accounts", StringComparison.OrdinalIgnoreCase));

                    if (role == null || Convert.ToBoolean(role.Insert))
                    {
                        try
                        {
                            if (ddlPaymentMethod.SelectedValue.ToLower() == "bank")
                            {
                                if (ddlAccountNo.SelectedValue == "0")
                                {
                                    Alert.ShowAlert(this, "e", "Please select a Bank account no");
                                    return;
                                }
                            }
                            if (ddlPaymentMethod.SelectedValue.ToLower() == "cash")
                            {
                                if (ddlAccountNo.SelectedValue == "0")
                                {
                                    Alert.ShowAlert(this, "e", "Please select a account No");
                                    return;
                                }
                            }

                            var obj = new WebServices.CautionRefundOrderReference.CautionRefundOrder
                            {
                                Cheque_DateSpecified = true,
                                Payment_MethodSpecified = true,
                                Posting_DateSpecified = true,

                                Academic_Year = ddlAcademicYear.SelectedItem.Text,
                                Posting_Date = DateTimeParser.ParseDateTime(txtPostingDate.Text),
                                Payment_Method = ddlPaymentMethod.SelectedValue == "Bank" ? WebServices.CautionRefundOrderReference.Payment_Method.Bank : WebServices.CautionRefundOrderReference.Payment_Method.Cash,
                                Account_No = ddlAccountNo.SelectedValue,
                                Chaque_No = txtChequeNo.Text,
                                Cheque_Date = DateTimeParser.ParseDateTime(txtChequeDate.Text),
                                External_Document_No = txtExternalDocumentNo.Text,
                                Naration = txtNaration.Text
                            };

                            SOAPServices.AddCautionRefundOrder(obj, Session["SessionCompanyName"] as string);
                            ClearControl();
                            Alert.ShowAlert(this, "s", "Record added successfully.");
                        }
                        catch (Exception ex)
                        {
                            Alert.ShowAlert(this, "e", "Exception occured :" + ex.Message);
                        }
                    }
                    else
                    {
                        Alert.ShowAlert(this, "W", "You do not have permission to Submit the content. Kindly contact the system administrator.");

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
            ddlAcademicYear.ClearSelection();
            ddlAcademicYear.Items.FindByValue("0").Selected = true;
            txtPostingDate.Text = "";
            ddlPaymentMethod.ClearSelection();
            ddlPaymentMethod.Items.FindByValue("Select").Selected = true;
            ddlAccountNo.ClearSelection();
            ddlAccountNo.Items.FindByValue("0").Selected = true;
            txtChequeNo.Text = "";
            txtChequeDate.Text = "";
            txtExternalDocumentNo.Text = "";
            txtNaration.Text = "";
        }
        public void BindFianacialYear()
        {
            var FyList = ODataServices.GetFinancialYearList(Session["SessionCompanyName"] as string);
            ddlAcademicYear.DataSource = FyList;
            ddlAcademicYear.DataTextField = "Financial_Code";
            ddlAcademicYear.DataValueField = "Financial_Code";
            ddlAcademicYear.DataBind();
            ddlAcademicYear.Items.Insert(0, new ListItem("Select Year", "0"));
        }

        public void GetCashAccounts()
        {
            ddlAccountNo.DataSource = ODataServices.GetChartofAccounts(Session["SessionCompanyName"] as string);
            ddlAccountNo.DataTextField = "Name";
            ddlAccountNo.DataValueField = "No";
            ddlAccountNo.DataBind();
            ddlAccountNo.Items.Insert(0, new ListItem("Select Account No", "0"));
        }

        public void GetBankAccounts()
        {
            ddlAccountNo.DataSource = ODataServices.GetBankAccountList(Session["SessionCompanyName"] as string);
            ddlAccountNo.DataTextField = "Name";
            ddlAccountNo.DataValueField = "No";
            ddlAccountNo.DataBind();
            ddlAccountNo.Items.Insert(0, new ListItem("Select Account No", "0"));
        }

        protected void ddlPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPaymentMethod.SelectedValue == "Bank")
            {
                GetBankAccounts();
            }
            if (ddlPaymentMethod.SelectedValue == "Cash")
            {
                GetCashAccounts();
            }
        }
    }
}