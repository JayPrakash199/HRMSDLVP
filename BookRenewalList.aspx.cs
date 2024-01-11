using HRMS.Common;
using System;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class BookRenewalList : System.Web.UI.Page
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
                var BookIssueList = ODataServices.GetBookRenewalList(Session["SessionCompanyName"] as string);
                if (BookIssueList != null)
                {
                    BookRenewalListView.DataSource = BookIssueList;
                    BookRenewalListView.DataBind();
                }
            }
        }

        protected void btnSearchBookRenewaldata_Click(object sender, EventArgs e)
        {
            var LibrarySearchList = ODataServices.GetFilterBookRenewalList(txtbookRenewalSearch.Text, Session["SessionCompanyName"] as string);
            if (LibrarySearchList != null)
            {
                BookRenewalListView.DataSource = LibrarySearchList;
                BookRenewalListView.DataBind();
            }
        }
        protected void BookReturnListView_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {

                case ("Renewal"):
                    string Entry_No = e.CommandArgument.ToString();
                    try
                    {
                        SOAPServices.BookRenewal(Entry_No, Session["SessionCompanyName"] as string);
                        Alert.ShowAlert(this, "s", "Book renewed successfully.");
                    }
                    catch (Exception ex)
                    {
                        string message = string.Format("Message: {0}\\n\\n", ex.Message);
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
                    }
                    break;
            }
        }

    }
}