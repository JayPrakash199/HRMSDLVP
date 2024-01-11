using HRMS.Common;
using System;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class BookReturnList : System.Web.UI.Page
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
                var BookIssueList = ODataServices.GetBookReturnList(Session["SessionCompanyName"] as string);
                if (BookIssueList != null)
                {
                    BookReturnListView.DataSource = BookIssueList;
                    BookReturnListView.DataBind();
                }
            }
        }

        protected void btnSearchBookReturndata_Click(object sender, EventArgs e)
        {
            var LibrarySearchList = ODataServices.GetFilterBookreturnList(txtbookReturnSearch.Text, Session["SessionCompanyName"] as string);
            if (LibrarySearchList != null)
            {
                BookReturnListView.DataSource = LibrarySearchList;
                BookReturnListView.DataBind();
            }
        }

        protected void BookReturnListView_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {

                case ("Return"):
                    string Entry_No = e.CommandArgument.ToString();
                    try
                    {
                        SOAPServices.ReturnBook(Entry_No, Session["SessionCompanyName"] as string);
                        Alert.ShowAlert(this, "s", "Books Returned Successfully");
                    }
                    catch(Exception ex)
                    {
                        Alert.ShowAlert(this, "e", ex.Message);
                    }
                    break;

            }
        }
    }
}