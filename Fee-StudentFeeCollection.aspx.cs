using HRMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class Fee_StudentFeeCollection : System.Web.UI.Page
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
                    string.Equals(x.Page_Name.Trim(), "Student Fee Collection", StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Module_Name.Trim(), "Accounts", StringComparison.OrdinalIgnoreCase));

                    if (role == null || Convert.ToBoolean(role.Read))
                    {
                        BindListView();
                    }
                    else
                    {
                        Alert.ShowAlert(this, "W", "You do not have permission to read the content. Kindly contact the system administrator.");

                    }
                }
            }
        }

        private void BindListView()
        {
            StudentFeeCollectionListView.DataSource = ODataServices.GetStudentFeeCollectionList(Session["SessionCompanyName"] as string);
            StudentFeeCollectionListView.DataBind();
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            if (!((Fee)this.Master).IsPageRefresh)
            {
                List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
                if (lstUserRole != null)
                {
                    var role = lstUserRole.FirstOrDefault(x =>
                    string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Page_Name.Trim(), "Student Fee Collection", StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Module_Name.Trim(), "Accounts", StringComparison.OrdinalIgnoreCase));

                    if (role == null || Convert.ToBoolean(role.Insert))
                    {
                        LinkButton btn = sender as LinkButton;
                        ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
                        Label entryNo = item.FindControl("lblEntryNo") as Label;
                        string returnVaal = SOAPServices.PostingStudentFeeCollection(entryNo.Text, Session["SessionCompanyName"] as string);
                        if (string.IsNullOrEmpty(returnVaal))
                        {
                            BindListView();
                            Alert.ShowAlert(this, "s", "Posted successfully.");
                        }
                        else
                            Alert.ShowAlert(this, "e", returnVaal);
                    }

                    else
                    {
                        Alert.ShowAlert(this, "W", "You do not have permission to post the content. Kindly contact the system administrator.");
                    }
                }
            }
        }
    }
}