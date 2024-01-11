using HRMS.Common;
using System;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class Fee_GeneralPaymentList : System.Web.UI.Page
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
                BindListView();
            }
        }
        private void BindListView()
        {
            GeneralPaymentListView.DataSource = ODataServices.GetGeneralPaymentList(Session["SessionCompanyName"] as string);
            GeneralPaymentListView.DataBind();
        }
        protected void btnPost_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
            Label entryNo = item.FindControl("lblEntryNo") as Label;
            string returnVal = SOAPServices.PostingGeneralPayment(entryNo.Text, Session["SessionCompanyName"] as string);
            if (string.IsNullOrEmpty(returnVal))
            {
                BindListView();
                Alert.ShowAlert(this, "s", "Posted successfully.");
            }
            else
                Alert.ShowAlert(this, "e", returnVal);
        }
    }
}