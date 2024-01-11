using HRMS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class TransferAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindingListView();
            }
        }
        private void BindingListView()
        {
            var lstAAccount= ODataServices.GetTransferAccountList(Session["SessionCompanyName"] as string);
            TransferAccountListView.DataSource=lstAAccount;
            TransferAccountListView.DataBind();
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
                Label entryNo = item.FindControl("lblEntryNo") as Label;

                Label status = item.FindControl("lblStatus") as Label;
                if (status.Text.ToLower() == "posted")
                {
                    Alert.ShowAlert(this, "e", "Alredy Posted.");
                    return;
                }

                string returnVal = SOAPServices.PostTransferAccount(entryNo.Text, Session["SessionCompanyName"] as string);
                if (returnVal== ResultMessages.SuccessfullMessage)
                {
                    Alert.ShowAlert(this, "s", "Posted successfully.");
                }
                else
                    Alert.ShowAlert(this, "e", returnVal);
                BindingListView();
            }
            catch (Exception ex)
            {
                Alert.ShowAlert(this, "e", ex.Message);
            }
        }
    }
}