using HRMS.Common;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class Infra_ProjectList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["SessionCompanyName"] as string))
            {
                string message = string.Format("Message: {0}\\n\\n", "Please select a company");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
                Response.Redirect("Default.aspx");
            }
            ListView1.Visible = false;
            if (ddlProjectType.SelectedItem.Text == "New")
            {
                var result = ODataServices.GetAllProjectDetails(Session["SessionCompanyName"] as string);
                ListView1.DataSource = result.Where(x => x.Project_Type == Convert.ToString(WebServices.InfraNewprojectReference.Project_Type.New));
                ListView1.DataBind();
                ListView1.Visible = true;
            }
            if (ddlProjectType.SelectedItem.Text == "Ongoing")
            {
                var result = ODataServices.GetAllProjectDetails(Session["SessionCompanyName"] as string);
                ListView1.DataSource = result.Where(x => x.Project_Type == Convert.ToString(WebServices.InfraNewprojectReference.Project_Type.Ongoing));
                ListView1.DataBind();
                ListView1.Visible = true;
            }
            if (ddlProjectType.SelectedItem.Text == "Improvement")
            {
                var result = ODataServices.GetAllProjectDetails(Session["SessionCompanyName"] as string);
                ListView1.DataSource = result.Where(x => x.Project_Type == Convert.ToString(WebServices.InfraNewprojectReference.Project_Type.Improvement));
                ListView1.DataBind();
                ListView1.Visible = true;
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
            Label projectCode = item.FindControl("lblProjectCode") as Label;
            Label projectType = item.FindControl("lblProjectType") as Label;

            if (!string.IsNullOrEmpty(projectCode.Text) && !string.IsNullOrEmpty(projectType.Text))
            {
                var servicePath = SOAPServices.DownloadProjectFile(GetProjectTypeIndex(projectType.Text), projectCode.Text, Session["SessionCompanyName"] as string);
                if (!string.IsNullOrEmpty(servicePath))
                {
                    string exportedFilePath = ConfigurationManager.AppSettings["ExportFilePath"].ToString() + StringHelper.GetFileNameFromURL(servicePath);
                    WebClient wc = new WebClient();
                    byte[] buffer = wc.DownloadData(exportedFilePath);
                    var FileName = "Project" + "_" + projectCode.Text + ".PDF";
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
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
            Label projectCode = item.FindControl("lblProjectCode") as Label;
            Label projectType = item.FindControl("lblProjectType") as Label;

            FileUpload uploadedFile = item.FindControl("ProjectpdfUploader") as FileUpload;

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
                SOAPServices.UploadProjectFile(GetProjectTypeIndex(projectType.Text), projectCode.Text, servicePath, Session["SessionCompanyName"] as string);
                Alert.ShowAlert(this, "s", "file Upload successfully");
            }
        }

        public int GetProjectTypeIndex(string projectType)
        {
            int projectTypeIndex = 2;
            if (WebServices.InfraImprovementprojectReference.Project_Type.Improvement.ToString() == projectType)
            {
                projectTypeIndex = 0;
            }
            if (WebServices.InfraImprovementprojectReference.Project_Type.Ongoing.ToString() == projectType)
            {
                projectTypeIndex = 1;
            }
            //if (WebServices.ImprovementProjectReference.Project_Type.New.ToString() == projectType)
            //{
            //    projectTypeIndex = 2;
            //}
            return projectTypeIndex;
        }
    }
}