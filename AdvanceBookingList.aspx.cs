using HRMS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

                List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
                if (lstUserRole != null)
                {
                    var role = lstUserRole.FirstOrDefault(x =>
                        string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                        string.Equals(x.Page_Name.Trim(), "Advance Booking List", StringComparison.OrdinalIgnoreCase) &&
                        string.Equals(x.Module_Name.Trim(), "Library", StringComparison.OrdinalIgnoreCase));

                    if (role == null || Convert.ToBoolean(role.Read))
                    {
                        BindListView();
                    }
                    else
                    {
                        Alert.ShowAlert(this, "W", "You do not have permission to read the content. Kindly contact the system administrator.");
                        return;
                    }
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
            var lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Advance Booking List", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Library", StringComparison.OrdinalIgnoreCase));

            if (role == null || Convert.ToBoolean(role.Read))
            {
                string companyName = Session["SessionCompanyName"] as string;

                if (!string.IsNullOrEmpty(txtbookAdvanceBookData.Text))
                {
                    var bookIssueList = ODataServices.GetFilterAdvanceBookingList(txtbookAdvanceBookData.Text, companyName);
                    if (bookIssueList != null)
                    {
                        
                        AdvanceBooklListView.DataSource = bookIssueList;
                        AdvanceBooklListView.DataBind();
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
                return;
            }
        }

        protected void btnAddBookcard_Click(object sender, EventArgs e)
        {
            var lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Advance Booking List", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Library", StringComparison.OrdinalIgnoreCase));

            if (role == null || Convert.ToBoolean(role.Read))
            {
                Response.Redirect("AdvanceBookingCard.aspx");
            }
            else
            {
                Alert.ShowAlert(this, "W", "You do not have permission to access the content. Kindly contact the system administrator.");
            }
        }


    }
}


