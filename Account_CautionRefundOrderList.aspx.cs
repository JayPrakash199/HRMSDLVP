﻿using HRMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class Account_CautionRefundOrderList : System.Web.UI.Page
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
                    string.Equals(x.Page_Name.Trim(), "Caution Refund Order List", StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Module_Name.Trim(), "Accounts", StringComparison.OrdinalIgnoreCase));

                    if (role == null || Convert.ToBoolean(role.Read))
                    {

                        var cautionRefundOrderList = ODataServices.GetCautionRefundOrder(Session["SessionCompanyName"] as string);
                        if (cautionRefundOrderList.Any())
                        {
                            CautionMoneyRefundOrderListView.DataSource = cautionRefundOrderList;
                            CautionMoneyRefundOrderListView.DataBind();
                        }
                    }
                    else
                    {
                        Alert.ShowAlert(this, "W", "You do not have permission to read the content. Kindly contact the system administrator.");
                        return;
                    }
                }
            }

        }

        //protected void btnGetLines_Click(object sender, EventArgs e)
        //{
        //    LinkButton btn = sender as LinkButton;
        //    ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
        //    Label refund_Sl_No = item.FindControl("lblRefund_Sl_No") as Label;
        //    Label academic_Year = item.FindControl("lblAcademic_Year") as Label;

        //    SOAPServices.GetLines(refund_Sl_No.Text, academic_Year.Text, Session["SessionCompanyName"] as string);
        //    Alert.ShowAlert(this, "s", "Successful.");
        //}

        //protected void btnPOstToJournal_Click(object sender, EventArgs e)
        //{
        //    LinkButton btn = sender as LinkButton;
        //    ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
        //    Label refund_Sl_No = item.FindControl("lblRefund_Sl_No") as Label;
        //    Label externalDocumentNo = item.FindControl("lblExternal_Document_No") as Label;
        //    Label posting_Date = item.FindControl("lblPosting_Date") as Label;
        //    Label naration = item.FindControl("lblNaration") as Label;
        //    Label payment_Method = item.FindControl("lblPayment_Method") as Label;
        //    Label account_No = item.FindControl("lblAccount_No") as Label;
        //    Label Chaque_No = item.FindControl("lblChaque_No") as Label;
        //    Label cheque_Date = item.FindControl("lblCheque_Date") as Label;

        //    SOAPServices.PostToJournal(false,
        //                                refund_Sl_No.Text,
        //                                externalDocumentNo.Text,
        //                                DateTimeParser.ParseDateTime(posting_Date.Text),
        //                                naration.Text,
        //                                Convert.ToInt32(payment_Method.Text == "Bank" ? WebServices.CautionRefundOrderReference.Payment_Method.Bank : WebServices.CautionRefundOrderReference.Payment_Method.Cash),
        //                                account_No.Text, Chaque_No.Text,
        //                                DateTimeParser.ParseDateTime(cheque_Date.Text),
        //                                Session["SessionCompanyName"] as string);
        //    Alert.ShowAlert(this, "s", "Successful.");
        //}
    }
}