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
    public partial class MasterDataOnLandAndBuildings : System.Web.UI.Page
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

        protected void uploadBtn_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Land Master", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Infra", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Insert))
                {
                    if (this.csvUploader.HasFile)
                    {
                        string fileExtention = Path.GetExtension(this.csvUploader.FileName);
                        string finalFileName = Path.GetFileNameWithoutExtension(this.csvUploader.FileName.Substring(0, 10)) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                        string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);
                        if (Directory.Exists(path))
                        {
                            path = Path.Combine(path, finalFileName);
                            this.csvUploader.SaveAs(path);
                        }
                        string servicePath = ConfigurationManager.AppSettings["PdfPath"].ToString() + finalFileName;

                        try
                        {
                            SOAPServices.ImportLandFile(servicePath, Session["SessionCompanyName"] as string);
                        }
                        catch (Exception ex)
                        {
                            string message = string.Format("Message: {0}\\n\\n", ex.Message);
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
                        }
                        Alert.ShowAlert(this, "s", "file uploaded successfully");
                    }
                }
                else
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to Upload the content. Kindly contact the system administrator.");
                }
            }
        }

        protected void downloadTemplateCSVBtn_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
               string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
               string.Equals(x.Page_Name.Trim(), "Land Master", StringComparison.OrdinalIgnoreCase) &&
               string.Equals(x.Module_Name.Trim(), "Infra", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Read))
                {
                    string FileName = "LandDataExportTemplate.csv";
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
                else
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to Download the content. Kindly contact the system administrator.");
                }
            }
        }
    }
}