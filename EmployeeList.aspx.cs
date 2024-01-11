using HRMS.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class EmployeeList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
                if (lstUserRole != null)
                {
                    var role = lstUserRole
                        .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) && 
                        string.Equals(x.Page_Name.Trim(), "Employee List", StringComparison.OrdinalIgnoreCase)
                        && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));

                    if (role == null)
                    {
                        LoadEmployeeData();
                    }
                    else
                    {
                        if (!Convert.ToBoolean(role.Read))
                        {
                            Alert.ShowAlert(this, "W", "You do not have permission to read the content. Kindly contact the system administrator.");
                            return;
                        }
                        LoadEmployeeData();
                    }
                }
            }
        }

        private void LoadEmployeeData()
        {
            if (string.IsNullOrEmpty(Session["SessionCompanyName"] as string))
            {
                string message = string.Format("Message: {0}\\n\\n", "Please select a company");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
                Response.Redirect("Default.aspx");
            }

            var employeeList = ODataServices.GetEmployeeList(Session["SessionCompanyName"] as string);
            EmployeeListView.DataSource = employeeList;
            EmployeeListView.DataBind();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            var servicePath = SOAPServices.ExportEmployees(Session["SessionCompanyName"] as string);
            var FileName = "HRMSEmployees.XLS";
            string exportedFilePath = ConfigurationManager.AppSettings["ExportFilePath"].ToString() + StringHelper.GetFileNameFromURL(servicePath);
            WebClient wc = new WebClient();
            byte[] buffer = wc.DownloadData(exportedFilePath);
            var fileName = "attachment; filename=" + FileName;
            base.Response.ClearContent();
            base.Response.AddHeader("content-disposition", fileName);
            base.Response.ContentType = "application/vnd.ms-excel";
            base.Response.BinaryWrite(buffer);
            base.Response.End();
        }
    }
}