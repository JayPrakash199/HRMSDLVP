using System;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class AdvanceBookingList : System.Web.UI.Page
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
            var BookIssueList = ODataServices.GeAdvncedtBookList(Session["SessionCompanyName"] as string);
            if (BookIssueList != null)
            {
                AdvanceBooklListView.DataSource = BookIssueList;
                AdvanceBooklListView.DataBind();
            }
        }

        protected void AdvanceBooklListView_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

        }

        protected void btnSearchAdvanceBookData_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtbookAdvanceBookData.Text))
            {
                var BookIssueList = ODataServices.GetFilterAdvanceBookingList(txtbookAdvanceBookData.Text, Session["SessionCompanyName"] as string);
                if (BookIssueList != null)
                {
                    AdvanceBooklListView.DataSource = BookIssueList;
                    AdvanceBooklListView.DataBind();
                }
            }
        }

        protected void btnAddBookcard_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdvanceBookingCard.aspx");
        }
    }
}