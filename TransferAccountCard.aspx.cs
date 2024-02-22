using HRMS.Common;
using HRMSODATA;
using InfrastructureManagement.Common;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class TransferAccountCard : System.Web.UI.Page
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
                List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
                if (lstUserRole != null)
                {
                    var role = lstUserRole.FirstOrDefault(x =>
                    string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Page_Name.Trim(), "Student Fee Collection List", StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Module_Name.Trim(), "Accounts", StringComparison.OrdinalIgnoreCase));

                    if (role == null || Convert.ToBoolean(role.Insert))
                    {
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.Cache.SetNoStore();
                        GetBankAccounts();
                        BindGlAccount();
                        ShowDimentation();
                        //BindData();
                    }
                    else
                    {
                        Alert.ShowAlert(this, "W", "You do not have permission to Read to the content. Kindly contact the system administrator.");
                    }

                }
            }
        }
        private void ShowDimentation()
        {
            var dimensionList = ODataServices.GetDimentionList(Session["SessionCompanyName"] as string);
            BindInstitute(dimensionList);
            BindDepartment(dimensionList);
            BindFundingSOurce(dimensionList);
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
        //private void BindData()
        //{
        //    var entry_No = Request.QueryString["Entry_No"];
        //    var lstAAccount = ODataServices.GetTransferAccountList(Session["SessionCompanyName"] as string);
        //    var data = lstAAccount.Where(x => string.Equals(x.Entry_No, entry_No, StringComparison.OrdinalIgnoreCase)).ToList();
        //    foreach (var dc in data)
        //    {

        //        txtntryNo.Text = dc.Entry_No;
        //        ddlType.Items.FindByText(dc.Type).Selected = true;
        //        if (!string.IsNullOrEmpty(dc.Payment_Type)) ddlPaymentType.Items.FindByValue(dc.Payment_Type).Selected = true;
        //        if (!string.IsNullOrEmpty(dc.G_L_account_name)) ddlglAcName.Items.FindByValue(dc.gl.ToUpper()).Selected = true;
        //        if (!string.IsNullOrEmpty(dc.G_L_account_no)) txtGlAcNo.Text = dc.G_L_account_no;
        //        if (!string.IsNullOrEmpty(dc.Bank_account_name)) ddlbankAcName.Items.FindByText(dc.Bank_account_name.ToUpper()).Selected = true;
        //        if (!string.IsNullOrEmpty(dc.Bank_account_no)) txtBnkAcNo.Text = dc.Bank_account_no;


        //        if (!string.IsNullOrEmpty( dc.Transferring_G_L_Account_Name))ddlTransferGlaccountname.Items.FindByText(dc.Transferring_G_L_Account_Name.ToUpper()).Selected = true;
        //        if (!string.IsNullOrEmpty( dc.Transferring_G_L_Account_No))txtTransferGlaccountNo.Text = dc.Transferring_G_L_Account_No;
        //        if (!string.IsNullOrEmpty( dc.Transferring_Bank_Account_Name))ddlTransferBankaccountname.Items.FindByText(dc.Transferring_Bank_Account_Name).Selected = true;
        //        if (!string.IsNullOrEmpty( dc.Transferring_Bank_Account_No))txtTransferBankaccountno.Text = dc.Transferring_Bank_Account_No;

        //        if (dc.Posting_Date!=null)txtPostingDate.Text = dc.Posting_Date.ToString();
        //        if (dc.Amount!=null)txtTotalAmount.Text = dc.Amount.ToString();
        //        if (!string.IsNullOrEmpty( dc.Status))txtStatus.Text = dc.Status;
        //    }


        //}

        public void BindGlAccount()
        {
            var glList = ODataServices.GetChartofAccounts(Session["SessionCompanyName"] as string);
            ddlglAcName.DataSource = glList;
            ddlglAcName.DataTextField = "Name";
            ddlglAcName.DataValueField = "No";
            ddlglAcName.DataBind();
            ddlglAcName.Items.Insert(0, new ListItem("Select Account", "0"));


            ddlTransferGlaccountname.DataSource = glList;
            ddlTransferGlaccountname.DataTextField = "Name";
            ddlTransferGlaccountname.DataValueField = "No";
            ddlTransferGlaccountname.DataBind();
            ddlTransferGlaccountname.Items.Insert(0, new ListItem("Select Account", "0"));

        }
        public void GetBankAccounts()
        {
            var accountList = ODataServices.GetBankAccountList(Session["SessionCompanyName"] as string);
            ddlbankAcName.DataSource = accountList;
            ddlbankAcName.DataTextField = "Name";
            ddlbankAcName.DataValueField = "No";
            ddlbankAcName.DataBind();
            ddlbankAcName.Items.Insert(0, new ListItem("Select Account", "0"));


            ddlTransferBankaccountname.DataSource = accountList;
            ddlTransferBankaccountname.DataTextField = "Name";
            ddlTransferBankaccountname.DataValueField = "No";
            ddlTransferBankaccountname.DataBind();
            ddlTransferBankaccountname.Items.Insert(0, new ListItem("Select Account", "0"));

        }
        protected void ddlTransferGlaccountname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(ddlTransferGlaccountname.SelectedValue)) && ddlTransferGlaccountname.SelectedValue != "0")
                txtTransferGlaccountNo.Text = ddlTransferGlaccountname.SelectedValue;
            if (ddlTransferGlaccountname.SelectedValue == "0")
                txtTransferGlaccountNo.Text = "";
        }
        protected void ddlglAcName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(ddlglAcName.SelectedValue)) && ddlglAcName.SelectedValue != "0")
                txtGlAcNo.Text = ddlglAcName.SelectedValue;
            if (ddlglAcName.SelectedValue == "0")
                txtGlAcNo.Text = "";
        }
        protected void ddlbankAcName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(ddlbankAcName.SelectedValue)) && ddlbankAcName.SelectedValue != "0")
                txtBnkAcNo.Text = ddlbankAcName.SelectedValue;
            if (ddlbankAcName.SelectedValue == "0")
                txtBnkAcNo.Text = "";
        }
        protected void ddlTransferBankaccountname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(ddlTransferBankaccountname.SelectedValue)) && ddlTransferBankaccountname.SelectedValue != "0")
                txtTransferBankaccountno.Text = ddlTransferBankaccountname.SelectedValue;
            if (ddlTransferBankaccountname.SelectedValue == "0")
                txtTransferBankaccountno.Text = "";
        }

        protected void btnPostTransferAccount_Click(object sender, EventArgs e)
        {
            if (!((Fee)this.Master).IsPageRefresh)
            {
                List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
                if (lstUserRole != null)
                {
                    var role = lstUserRole.FirstOrDefault(x =>
                    string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Page_Name.Trim(), "Transfer Account", StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Module_Name.Trim(), "Accounts", StringComparison.OrdinalIgnoreCase));

                    if (role == null || Convert.ToBoolean(role.Insert))
                    {
                        PostTransferAccount();
                    }
                    else
                    {
                        Alert.ShowAlert(this, "W", "You do not have permission to access the content. Kindly contact the system administrator.");

                    }
                }
            }
            else
            {
                ClearControls();
            }
        }
        private void PostTransferAccount()
        {  
            var entry_No = Request.QueryString["Entry_No"];

            if (string.IsNullOrEmpty(txtNaration.Text))
            {
                Alert.ShowAlert(this, "e", "Narration Filed can not be empty");
                return;
            }
            if (string.IsNullOrEmpty(txtTotalAmount.Text))
            {
                Alert.ShowAlert(this, "e", "Amount Filed can not be empty");
                return;
            }

            if (ddlPaymentType.SelectedValue == "CASH")
            {
                if (ddlglAcName.SelectedValue == "0")
                {
                    Alert.ShowAlert(this, "e", "Please select a G/L account name");
                    return;
                }
            }
            else if (ddlPaymentType.SelectedValue == "CASH")
            {
                if (ddlbankAcName.SelectedValue == "0")
                {
                    Alert.ShowAlert(this, "e", "Please select a Bank account name");
                    return;
                }
            }

            var obj = new WebServices.TransferAccountReference.TransferAccount
            {
                Payment_TypeSpecified = true,
                Transcation_DateSpecified = true,
                AmountSpecified = true,
                Posting_DateSpecified = true,
                StatusSpecified = true,
                TypeSpecified = true,

                Payment_Type = ddlPaymentType.SelectedItem.Text == "CASH" ? WebServices.TransferAccountReference.Payment_Type.CASH
                : ddlPaymentType.SelectedItem.Text == "BANK" ? WebServices.TransferAccountReference.Payment_Type.BANK
                : WebServices.TransferAccountReference.Payment_Type._blank_,

                G_L_account_name = (ddlPaymentType.SelectedValue == "CASH") ? ddlglAcName.SelectedItem.Text : "",
                G_L_account_no = (ddlPaymentType.SelectedValue == "CASH") ? txtGlAcNo.Text : "",
                Bank_account_no = (ddlPaymentType.SelectedValue == "BANK") ? txtBnkAcNo.Text : "",

                Transferring_G_L_Account_No = txtTransferGlaccountNo.Text,
                Transferring_Bank_Account_No = txtTransferBankaccountno.Text,

                Posting_Date = DateTimeParser.ParseDateTime(txtPostingDate.Text),
                Amount = NumericHandler.ConvertToDecimal(txtTotalAmount.Text),

                Transcation_Date = DateTimeParser.ParseDateTime(txtTranDate.Text),
                Transcation_No = txtTranNo.Text,
                Narration = txtNaration.Text,
                Shortcut_Dimension_1 = ddlInstiuteCode.SelectedItem.Text,
                Shortcut_Dimension_2 = ddlDepartmentCode.SelectedItem.Text,

            };
            var resultMessage = SOAPServices.CreateTransfer(obj, Session["SessionCompanyName"] as string);

            string page = "TransferAccount.aspx";

            if (resultMessage == ResultMessages.SuccessfullMessage)
            {
                ClearControls();
                Alert.ShowAlert(this, "s", resultMessage);
                //Response.Redirect(page);
            }
            else
                Alert.ShowAlert(this, "e", resultMessage);

        }

        private void ClearControls()
        {
            txtPostingDate.Text = "";
            ddlPaymentType.ClearSelection();
            ddlPaymentType.Items.FindByValue("Select Payment Type").Selected = true;
            ddlglAcName.ClearSelection();
            ddlglAcName.Items.FindByValue("0").Selected = true;
            txtGlAcNo.Text = "";
            ddlbankAcName.ClearSelection();
            ddlbankAcName.Items.FindByValue("0").Selected = true;
            txtBnkAcNo.Text = "";
            ddlTransferGlaccountname.ClearSelection();
            ddlTransferGlaccountname.Items.FindByValue("0").Selected = true;
            txtTransferGlaccountNo.Text = "";
            ddlTransferBankaccountname.ClearSelection();
            ddlTransferBankaccountname.Items.FindByValue("0").Selected = true;
            txtTransferBankaccountno.Text = "";
            txtTotalAmount.Text = "";
            ddlInstiuteCode.ClearSelection();
            ddlInstiuteCode.Items.FindByValue("0").Selected = true;
            ddlDepartmentCode.ClearSelection();
            ddlDepartmentCode.Items.FindByValue("0").Selected = true;
            ddlFundingsourceCode.ClearSelection();
            ddlFundingsourceCode.Items.FindByValue("0").Selected = true;
            txtNaration.Text = "";
            txtTranNo.Text = "";
        }

        protected void ddlPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPaymentType.SelectedValue == "CASH")
            {
                divGLac.Visible = true;
                divGLacNo.Visible = true;
                divBankAcName.Visible = false;
                divBankAcNo.Visible = false;

            }
            else if (ddlPaymentType.SelectedValue == "BANK")
            {
                divGLac.Visible = false;
                divGLacNo.Visible = false;
                divBankAcName.Visible = true;
                divBankAcNo.Visible = true;
            }
        }
    }
}