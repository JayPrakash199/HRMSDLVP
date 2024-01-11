using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class BookAccessionList : System.Web.UI.Page
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
            var BookAccessionList = ODataServices.GetBookAccessionList(Session["SessionCompanyName"] as string);
            if (BookAccessionList != null)
            {
                BookAccessionListView.DataSource = BookAccessionList;
                BookAccessionListView.DataBind();
            }
        }
    }
}