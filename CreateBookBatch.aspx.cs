using HRMS.Common;
using System;
using System.Collections.Generic;
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
                IList<HRMSODATA.ItemCategories> BookIssueList = ODataServices.GetItemCategoriesList(Session["SessionCompanyName"] as string);

                if (BookIssueList != null)
                {
                    ddlCategory.DataSource = BookIssueList;
                    ddlCategory.DataTextField = "Code";
                    ddlCategory.DataValueField = "Description";
                    ddlCategory.DataBind();
                }
            }
        }

        protected void btnSubmitCategory_Click(object sender, EventArgs e)
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
    }
}