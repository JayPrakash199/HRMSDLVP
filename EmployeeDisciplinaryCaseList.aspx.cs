using System;
using WebServices;

namespace HRMS
{
    public partial class EmployeeDisciplinaryCaseList : System.Web.UI.Page
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
                var HRMSID = Request.QueryString["HID"];
                if (HRMSID != null && !string.IsNullOrEmpty(HRMSID))
                {
                    var DisciplinaryCases = ODataServices.GetDisciplinaryListByHRMSID(HRMSID, Session["SessionCompanyName"] as string);
                    if (DisciplinaryCases != null)
                    {
                        DisciplinaryCaseListView.DataSource = DisciplinaryCases;
                        DisciplinaryCaseListView.DataBind();
                    }
                }
            }
        }
    }
}