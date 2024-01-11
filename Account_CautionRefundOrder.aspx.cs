using HRMS.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class Account_CautionRefundOrder : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindFianacialYear();

                if (Request.QueryString["SLNO"] != null)
                {
                    var refundOrderSerialNo = Request.QueryString["SLNO"];
                    var cautionRefundOrderList = ODataServices.GetCautionRefundOrder(Session["SessionCompanyName"] as string);
                    if (cautionRefundOrderList.Any())
                    {
                        var cautionRefundOrder = cautionRefundOrderList
                                                    .Where(x => string.Equals(refundOrderSerialNo, x.Refund_Sl_No, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                        if (cautionRefundOrder != null)
                        {
                            bool IsPosted;
                            lblRefundOrderSerialNo.Text = refundOrderSerialNo;
                            ddlAcademicYear.SelectedItem.Text = cautionRefundOrder.Academic_Year;
                            txtPostingDate.Text = DateTimeParser.ConvertDateTimeToText(cautionRefundOrder.Posting_Date);
                            ddlPaymentMethod.SelectedValue = cautionRefundOrder.Payment_Method;
                            ddlAccountNo.SelectedValue = cautionRefundOrder.Account_No;
                            txtChequeNo.Text = cautionRefundOrder.Chaque_No;
                            txtChequeDate.Text = DateTimeParser.ConvertDateTimeToText(cautionRefundOrder.Cheque_Date);
                            txtExternalDocumentNo.Text = cautionRefundOrder.External_Document_No;
                            txtNaration.Text = cautionRefundOrder.Naration;
                            IsPosted=chkPosted.Checked = Convert.ToBoolean(cautionRefundOrder.Posted);
                            BindSubFormListView(refundOrderSerialNo);
                            btnPostedCautionMoneyReport.Visible = IsPosted;
                            btnUnpostedCautionMoneyReport.Visible = !IsPosted;
                            if (cautionRefundOrder.Payment_Method == "Bank")
                            {
                                GetBankAccounts();
                            }
                            if (cautionRefundOrder.Payment_Method == "Cash")
                            {
                                GetCashAccounts();
                            }
                        }
                    }
                }
            }
        }

        public void BindSubFormListView(string refundOrderSerialNo)
        {

            var cautionRefundOrderSubformList = ODataServices.GetCautionRefundOrderSubform(Session["SessionCompanyName"] as string);
            var filteredCautionRefundOrderSubformList = cautionRefundOrderSubformList
                                                            .Where(x => string.Equals(refundOrderSerialNo, x.Refund_Document_No, StringComparison.OrdinalIgnoreCase))
                                                            .ToList();
            if (filteredCautionRefundOrderSubformList.Any())
            {
                CautionMoneySubFormListView.DataSource = filteredCautionRefundOrderSubformList;
                CautionMoneySubFormListView.DataBind();
            }
        }
        public void BindFianacialYear()
        {
            int currentYear = DateTime.Today.Year;
            ddlAcademicYear.Items.Clear();
            ddlAcademicYear.Items.Add("Select");
            for (int i = 10; i >= 0; i--)
            {
                int fy = currentYear - i;
                int fy1 = fy + 1;
                if (DateTime.Now.Date > Convert.ToDateTime(fy + "-03-31").Date)
                {
                    ddlAcademicYear.Items.Add(fy.ToString() + "-" + fy1.ToString().Remove(0, 2));
                }
            }
        }

        protected void btnGetLines_Click(object sender, EventArgs e)
        {

            SOAPServices.GetLines(lblRefundOrderSerialNo.Text,
                                    ddlAcademicYear.SelectedItem.Text,
                                    Session["SessionCompanyName"] as string);
            BindSubFormListView(lblRefundOrderSerialNo.Text);
            Alert.ShowAlert(this, "s", "Successful.");
        }

        protected void btnPostToJournal_Click(object sender, EventArgs e)
        {
            string returnVal = SOAPServices.PostToJournal(lblRefundOrderSerialNo.Text, Session["SessionCompanyName"] as string);
            if (!string.IsNullOrEmpty(returnVal))
            {
                Alert.ShowAlert(this, "e", returnVal);
            }
            else
                Alert.ShowAlert(this, "s", "Posted successfully.");
        }

        protected void btnPostedCautionMoneyReport_Click(object sender, EventArgs e)
        {
            var servicePath = SOAPServices.PostedCautionMoneyReport(lblRefundOrderSerialNo.Text, Session["SessionCompanyName"] as string);
            var FileName = "PostedCautionMoneyReport.pdf";
            string exportedFilePath = ConfigurationManager.AppSettings["ExportFilePath"].ToString() + StringHelper.GetFileNameFromURL(servicePath);
            WebClient wc = new WebClient();
            byte[] buffer = wc.DownloadData(exportedFilePath);
            var fileName = "attachment; filename=" + FileName;
            base.Response.ClearContent();
            base.Response.AddHeader("content-disposition", fileName);
            base.Response.ContentType = "application/pdf";
            base.Response.BinaryWrite(buffer);
            base.Response.End();
        }

        protected void btnUnpostedCautionMoneyReport_Click(object sender, EventArgs e)
        {
            var servicePath = SOAPServices.UnpostedCautionMoneyReport(lblRefundOrderSerialNo.Text, Session["SessionCompanyName"] as string);
            var FileName = "UnPostedCautionMoneyReport.pdf";
            string exportedFilePath = ConfigurationManager.AppSettings["ExportFilePath"].ToString() + StringHelper.GetFileNameFromURL(servicePath);
            WebClient wc = new WebClient();
            byte[] buffer = wc.DownloadData(exportedFilePath);
            var fileName = "attachment; filename=" + FileName;
            base.Response.ClearContent();
            base.Response.AddHeader("content-disposition", fileName);
            base.Response.ContentType = "application/pdf";
            base.Response.BinaryWrite(buffer);
            base.Response.End();
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

        protected void btnCautionRefundUpdate_Click(object sender, EventArgs e)
        {
            var obj = new WebServices.CautionRefundOrderReference.CautionRefundOrder
            {
                Academic_Year = ddlAcademicYear.SelectedItem.Text,
                Posting_Date = DateTimeParser.ParseDateTime(txtPostingDate.Text),
                Payment_Method = ddlPaymentMethod.SelectedItem.Text == "Bank" ? WebServices.CautionRefundOrderReference.Payment_Method.Bank
                : WebServices.CautionRefundOrderReference.Payment_Method.Cash,
                Account_No = ddlAccountNo.SelectedValue,
                Chaque_No = txtChequeNo.Text,
                Cheque_Date = DateTimeParser.ParseDateTime(txtChequeDate.Text),
                External_Document_No = txtExternalDocumentNo.Text,
                Naration = txtNaration.Text,
                Refund_Sl_No = lblRefundOrderSerialNo.Text
            };

            try
            {
                SOAPServices.UpdateCautionRefund(obj, Session["SessionCompanyName"] as string);
                Alert.ShowAlert(this, "s", "Updated.");
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
            Label lineNo = item.FindControl("lblLineNo") as Label;
            Label refundDocNo = item.FindControl("lblRefundDocNo") as Label;
            try
            {
                var result = SOAPServices.DeleteCautionRefundOrder(refundDocNo.Text, Convert.ToInt32(lineNo.Text), Session["SessionCompanyName"] as string);
                if (result)
                {
                    BindSubFormListView(refundDocNo.Text);
                    Alert.ShowAlert(this, "s", "Deleted successfully.");
                }
                else
                    Alert.ShowAlert(this, "e", "Delete unsuccessfully.");
            }
            catch (Exception ex)
            {

            }
        }


        protected void btndeleteall_Click(object sender, EventArgs e)
        {
            List<string> lst = new List<string>();
            bool result = false;
            for (int i = 0; i < CautionMoneySubFormListView.Items.Count; i++)
            {
                HtmlInputCheckBox chkDelete = CautionMoneySubFormListView.Items[i].FindControl("chkitem") as HtmlInputCheckBox;
                if (chkDelete.Checked)
                {
                    Label refundDocNo = CautionMoneySubFormListView.Items[i].FindControl("lblRefundDocNo") as Label;
                    Label lineNo = CautionMoneySubFormListView.Items[i].FindControl("lblLineNo") as Label;
                    result = SOAPServices.DeleteCautionRefundOrder(refundDocNo.Text, Convert.ToInt32(lineNo.Text), Session["SessionCompanyName"] as string);

                }
            }
            if (result)
            {
                var refundOrderSerialNo = Request.QueryString["SLNO"];
                BindSubFormListView(refundOrderSerialNo);
                Alert.ShowAlert(this, "s", "Deleted successfully.");
            }
            else
                Alert.ShowAlert(this, "e", "Delete unsuccessfully.");

        }
    }
}