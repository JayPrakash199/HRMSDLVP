using HRMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
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

                string companyName = Session["SessionCompanyName"] as string;
                List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();

                
                var role = lstUserRole.FirstOrDefault(x =>
                    string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Page_Name.Trim(), "Book Return List", StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Module_Name.Trim(), "Library", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Read))
                {
                   
                    var bookReturnList = ODataServices.GetBookReturnList(companyName);

                    if (bookReturnList != null)
                    {
                        
                        BookReturnListView.DataSource = bookReturnList;
                        BookReturnListView.DataBind();
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

        protected void btnSearchBookReturndata_Click(object sender, EventArgs e)
        {
            var lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Book Return List", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Library", StringComparison.OrdinalIgnoreCase));

            if (role == null || Convert.ToBoolean(role.Read))
            {
                string companyName = Session["SessionCompanyName"] as string;

                if (!string.IsNullOrEmpty(txtbookReturnSearch.Text))
                {
                    var librarySearchList = ODataServices.GetFilterBookreturnList(txtbookReturnSearch.Text, companyName);
                    if (librarySearchList != null)
                    {
                       
                        BookReturnListView.DataSource = librarySearchList;
                        BookReturnListView.DataBind();
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