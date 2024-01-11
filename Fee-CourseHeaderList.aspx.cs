using System;
using WebServices;

namespace HRMS
{
    public partial class Fee_CourseHeaderList : System.Web.UI.Page
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
                CourseFeeHeaderListView.DataSource = ODataServices.GetCourseFeeHeaderList(Session["SessionCompanyName"] as string);
                CourseFeeHeaderListView.DataBind();
            }
        }
    }
}