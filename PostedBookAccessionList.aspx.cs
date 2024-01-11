using System;
using WebServices;

namespace HRMS
{
    public partial class PostedBookAccessionList : System.Web.UI.Page
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
            var postedBookAccessionList = ODataServices.GetPostedBookAccessionList(Session["SessionCompanyName"] as string);
            if (postedBookAccessionList != null)
            {
                PostedBookAccessionListView.DataSource = postedBookAccessionList;
                PostedBookAccessionListView.DataBind();
            }
        }
    }
}