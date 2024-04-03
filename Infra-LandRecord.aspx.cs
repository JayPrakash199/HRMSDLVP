using HRMS.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class LandRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["SessionCompanyName"] as string))
            {
                string message = string.Format("Message: {0}\\n\\n", "Please select company");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
                Response.Redirect("Default.aspx");
            }

            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Land Record List", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Infra", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Read))
                {
                    var data = ODataServices.GetLandDetailList(Session["SessionCompanyName"] as string).ToList();

                    if (data == null || !data.Any())
                    {
                        btnExport.Visible = false;
                    }
                    else
                    {
                        btnExport.Visible = true;
                    }

                    LandRecordList.DataSource = data;
                    LandRecordList.DataBind();
                }
                else
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to Read the content. Kindly contact the system administrator.");
                }
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {

            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Land Record List", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Infra", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Read))
                {
                    string FileName = "LandRecord.XLS";
                    string bcPath = SOAPServices.ExportLandFile(Session["SessionCompanyName"] as string);
                    if (!string.IsNullOrEmpty(bcPath))
                    {
                        string exportedFilePath = ConfigurationManager.AppSettings["ExportFilePath"].ToString() + StringHelper.GetFileNameFromURL(bcPath);
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
                        Alert.ShowAlert(this, "e", "No file found.");
                    }
                }
                else
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to Export the content. Kindly contact the system administrator.");
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Land Record List", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Infra", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Insert))
                {
                    LinkButton btn = sender as LinkButton;
                    ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
                    Label khatianNo = item.FindControl("lblKhatianNo") as Label;

                    FileUpload uploadedFile = item.FindControl("LandpdfUploader") as FileUpload;

                    if (uploadedFile.HasFile)
                    {
                        string fileExtention = Path.GetExtension(uploadedFile.FileName);
                        string finalFileName = Path.GetFileNameWithoutExtension(new string(uploadedFile.FileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                        string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);
                        if (Directory.Exists(path))
                        {
                            path = Path.Combine(path, finalFileName);
                            uploadedFile.SaveAs(path);
                        }
                        string servicePath = ConfigurationManager.AppSettings["PdfPath"].ToString() + finalFileName;
                        SOAPServices.ImportPdfRoRFile(khatianNo.Text, servicePath, Session["SessionCompanyName"] as string);
                        Alert.ShowAlert(this, "s", "file Upload successfully");
                    }
                }
                else
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to Upload the content. Kindly contact the system administrator.");
                }
            }
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Land Record List", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Infra", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Read))
                {
                    LinkButton btn = sender as LinkButton;
                    ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
                    Label khatianNo = item.FindControl("lblKhatianNo") as Label;

                    if (!string.IsNullOrEmpty(khatianNo.Text))
                    {
                        string FileName = "LandRecordList" + "_" + khatianNo.Text + ".pdf";
                        string bcPath = SOAPServices.ExportLandFileInPdf(khatianNo.Text, Session["SessionCompanyName"] as string);
                        if (!string.IsNullOrEmpty(bcPath))
                        {
                            string exportedFilePath = ConfigurationManager.AppSettings["ExportFilePath"].ToString() + StringHelper.GetFileNameFromURL(bcPath);
                            WebClient wc = new WebClient();
                            byte[] buffer = wc.DownloadData(exportedFilePath);

                            var fileName = "attachment; filename=" + FileName;
                            base.Response.ClearContent();
                            base.Response.AddHeader("content-disposition", fileName);
                            base.Response.ContentType = "application/pdf";
                            base.Response.BinaryWrite(buffer);
                            base.Response.End();
                        }
                        else
                        {
                            Alert.ShowAlert(this, "e", "No file found.");
                        }
                    }
                }
                else
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to Download the content. Kindly contact the system administrator.");
                }
            }
        }
    }
}