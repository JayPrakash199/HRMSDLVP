using HRMS.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using WebServices;

namespace HRMS
{
    public partial class RecruitmentsAndRetirements : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["SessionCompanyName"] as string))
            {
                string message = string.Format("Message: {0}\\n\\n", "Please select a company");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
                Response.Redirect("Default.aspx");
            }
        }

        protected void downloadTemplateCSVBtn_Click(object sender, EventArgs e)
        {
            string FileName = "EmployeeDataExportTemplate.csv";
            string exportedFilePath = ConfigurationManager.AppSettings["ExportFilePath"].ToString() + FileName;
            WebClient wc = new WebClient();
            byte[] buffer = wc.DownloadData(exportedFilePath);

            var fileName = "attachment; filename=" + FileName;
            base.Response.ClearContent();
            base.Response.AddHeader("content-disposition", fileName);
            base.Response.ContentType = "application/vnd.ms-excel";
            base.Response.BinaryWrite(buffer);
            base.Response.End();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (pdfUploader.HasFile)
            {

                List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
                var role = lstUserRole
                    .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Page_Name.Trim(), "Upload Employee", StringComparison.OrdinalIgnoreCase)
                                         && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));
                if (role == null)
                {
                    UploadData();
                }
                else
                {
                    if (!Convert.ToBoolean(role.Insert))
                    {
                        Alert.ShowAlert(this, "W", "You do not have permission to upload. Kindly contact the system administrator.");
                        return;
                    }
                    UploadData();
                }
            }
        }

        private void UploadData()
        {
            string fileExtention = Path.GetExtension(pdfUploader.FileName);
            string finalFileName = Path.GetFileNameWithoutExtension(pdfUploader.FileName.Substring(0, 10)) + "_" +
                                   DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
            string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            if (Directory.Exists(path))
            {
                path = Path.Combine(path, finalFileName);
                pdfUploader.SaveAs(path);
            }

            string servicePath = ConfigurationManager.AppSettings["PdfPath"].ToString() + finalFileName;

            SOAPServices.ImportHRMSDataImportFromGovtPortal(servicePath, Session["SessionCompanyName"] as string);
            Alert.ShowAlert(this, "s", "file Upload successfully");
        }
    }
}