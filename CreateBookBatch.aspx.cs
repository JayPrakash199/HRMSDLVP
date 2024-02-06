using HRMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using WebServices;

namespace HRMS
{
    public partial class CreateBookBatch : System.Web.UI.Page
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

                IList<HRMSODATA.ItemCategories> bookIssueList = ODataServices.GetItemCategoriesList(Session["SessionCompanyName"] as string);
                List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();

                if (lstUserRole != null)
                {
                    var role = lstUserRole.FirstOrDefault(x =>
                        string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                        string.Equals(x.Page_Name.Trim(), "Create Book Batch", StringComparison.OrdinalIgnoreCase) &&
                        string.Equals(x.Module_Name.Trim(), "Library", StringComparison.OrdinalIgnoreCase));

                    if (role == null || Convert.ToBoolean(role.Read))
                    {
                        if (bookIssueList != null)
                        {
                            ddlCategory.DataSource = bookIssueList;
                            ddlCategory.DataTextField = "Code";
                            ddlCategory.DataValueField = "Description";
                            ddlCategory.DataBind();
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




        protected void btnSubmitCategory_Click(object sender, EventArgs e)
        {
            var lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Create Book Batch", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Library", StringComparison.OrdinalIgnoreCase));

            if (role == null || Convert.ToBoolean(role.Read))
            {
                if (!string.IsNullOrEmpty(ddlCategory.SelectedItem.Text))
                {
                    try
                    {
                        SOAPServices.CreateBookBatch(ddlCategory.SelectedItem.Text, Session["SessionCompanyName"] as string);
                        Alert.ShowAlert(this, "s", "Batch executed successfully.");
                    }
                    catch (Exception ex)
                    {
                        string message = string.Format("Message: {0}\\n\\n", ex.Message);
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
                    }
                }
            }
            else
            {
                Alert.ShowAlert(this, "W", "You do not have permission to execute the batch. Kindly contact the system administrator.");
            }
        }
    }
}