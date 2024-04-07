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
    public partial class PromotionHistoryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["SessionCompanyName"] as string))
            {
                string message = string.Format("Message: {0}\\n\\n", "Please select a company");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
                Response.Redirect("Default.aspx");
            }
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Promotion History List", StringComparison.OrdinalIgnoreCase)
                && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));
            if (role == null)
            {
                BindListView();
            }
            else
            {
                if (!Convert.ToBoolean(role.Read))
                {
                    Alert.ShowAlert(this, "W",
                        "You do not have permission to read the content. Kindly contact the system administrator.");
                    return;
                }
                BindListView();
            }

        }

        private void BindListView()
        {
            var result = ODataServices.GetPromotionHistoryList(Session["SessionCompanyName"] as string);
            if (result == null) return;
            promotionHistoryListView.DataSource = result;
            promotionHistoryListView.DataBind();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Promotion History List", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Read))
                {
                    var servicePath = SOAPServices.ExportPromotionHistory(Session["SessionCompanyName"] as string);
                    var FileName = "PromotionHistory.XLS";
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
                else
                {
                    Alert.ShowAlert(this, "w", "You do not have permission to Export the content. Kindly contact the system administrator");
                }
            }
        }

        protected void promotionHistoryUpload_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Promotion History List", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Insert))
                {
                    LinkButton btn = sender as LinkButton;
                    ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
                    Label entryNo = item.FindControl("lblEntryNo") as Label;

                    FileUpload uploadedFile = item.FindControl("promotionHistorypdfUploader") as FileUpload;

                    if (uploadedFile.HasFile && !string.IsNullOrEmpty(entryNo.Text))
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
                        SOAPServices.Upload_Promotion_Order(Convert.ToInt32(entryNo.Text), servicePath, Session["SessionCompanyName"] as string);
                        Alert.ShowAlert(this, "s", "file uploaded successfully");
                    }
                }
                else
                {
                    Alert.ShowAlert(this, "w", "You do not have permission to Upload the content. Kindly contact the system administrator");
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
                string.Equals(x.Page_Name.Trim(), "Promotion History List", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Read))
                {
                    LinkButton btn = sender as LinkButton;
                    ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
                    Label entryNo = item.FindControl("lblEntryNo") as Label;

                    if (!string.IsNullOrEmpty(entryNo.Text))
                    {
                        string FileName = "PromotionOrder" + "_" + entryNo.Text + ".pdf";
                        string bcPath = SOAPServices.Download_Promotion_Order(Convert.ToInt32(entryNo.Text), Session["SessionCompanyName"] as string);
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
                            Alert.ShowAlert(this, "e", "No file found. Please upload a file.");
                        }
                    }
                }
                else
                {
                    Alert.ShowAlert(this, "w", "You do not have permission to Download the content. Kindly contact the system administrator");
                }
            }
        }
    }
}