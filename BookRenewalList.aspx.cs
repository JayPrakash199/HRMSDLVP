using HRMS.Common;
using Microsoft.Ajax.Utilities;
using System;
using System.Linq;
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

                var lstUserRole = ODataServices.GetUserAuthorizationList();
                var role = lstUserRole.FirstOrDefault(x =>
                    string.Equals(x.User_Name.Trim(), Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Page_Name.Trim(), "Book Renewal List", StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Module_Name.Trim(), "Library", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Read))
                {
                    string companyName = Session["SessionCompanyName"] as string;

                    var bookRenewalList = ODataServices.GetBookRenewalList(companyName);

                    if (bookRenewalList != null)
                    {
                        
                        BookRenewalListView.DataSource = bookRenewalList;
                        BookRenewalListView.DataBind();
                    }
                    else
                    {
                        
                    }
                }
                else
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to read the content. Kindly contact the system administrator.");
                    return;
                }
            }
        }


        protected void btnSearchBookRenewaldata_Click(object sender, EventArgs e)
        {
            var lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name.Trim(), Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Book Renewal List", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Library", StringComparison.OrdinalIgnoreCase));

            if (role == null || Convert.ToBoolean(role.Read))
            {
                string companyName = Session["SessionCompanyName"] as string;

                if (!string.IsNullOrEmpty(txtbookRenewalSearch.Text))
                {
                    var librarySearchList = ODataServices.GetFilterBookRenewalList(txtbookRenewalSearch.Text, companyName);
                    if (librarySearchList != null)
                    {
                        
                        BookRenewalListView.DataSource = librarySearchList;
                        BookRenewalListView.DataBind();
                    }
                    else
                    {
                        
                    }
                }
                else
                {
                   
                }
            }
            else
            {
                Alert.ShowAlert(this, "W", "You do not have permission to read the content. Kindly contact the system administrator.");
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