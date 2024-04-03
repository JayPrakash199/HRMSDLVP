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
    public partial class InfraBuildingList : System.Web.UI.Page
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
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Building List", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Infra", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Read))
                {
                    AuditoriumListView.Visible = false;
                    InstituteListView.Visible = false;
                    HostelBuildingListView.Visible = false;
                    StaffQuarterListView.Visible = false;
                    if (ddlBuldingType.SelectedItem.Text == "Auditorium")
                    {
                        var auditoriumList = ODataServices.GetAuditoriumList(Session["SessionCompanyName"] as string);
                        AuditoriumListView.DataSource = auditoriumList;
                        AuditoriumListView.DataBind();
                        AuditoriumListView.Visible = true;
                        InstituteListView.Visible = false;
                        HostelBuildingListView.Visible = false;
                        StaffQuarterListView.Visible = false;
                    }
                    if (ddlBuldingType.SelectedItem.Text == "Institute")
                    {
                        var instituteBuildings = ODataServices.GetInstituteBuildings(Session["SessionCompanyName"] as string);
                        InstituteListView.DataSource = instituteBuildings;
                        InstituteListView.DataBind();
                        InstituteListView.Visible = true;
                        AuditoriumListView.Visible = false;
                        HostelBuildingListView.Visible = false;
                        StaffQuarterListView.Visible = false;
                    }
                    if (ddlBuldingType.SelectedItem.Text == "Hostel")
                    {
                        var hostelBuildings = ODataServices.GetHostelBuildings(Session["SessionCompanyName"] as string);
                        HostelBuildingListView.DataSource = hostelBuildings;
                        HostelBuildingListView.DataBind();

                        AuditoriumListView.Visible = false;
                        InstituteListView.Visible = false;
                        StaffQuarterListView.Visible = false;
                        HostelBuildingListView.Visible = true;
                    }
                    if (ddlBuldingType.SelectedItem.Text == "StaffQuarter")
                    {
                        var staffQuarters = ODataServices.GetStaffQuarters(Session["SessionCompanyName"] as string);
                        StaffQuarterListView.DataSource = staffQuarters;
                        StaffQuarterListView.DataBind();

                        AuditoriumListView.Visible = false;
                        InstituteListView.Visible = false;
                        HostelBuildingListView.Visible = false;
                        StaffQuarterListView.Visible = true;
                    }
                }
                else
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to Read the content. Kindly contact the system administrator.");
                }
            }
        }

        protected void hostelBuildingUpload_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Building List", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Infra", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Insert))
                {
                    LinkButton btn = sender as LinkButton;
                    ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
                    Label blockCode = item.FindControl("lblHostelBlockCode") as Label;

                    FileUpload uploadedFile = item.FindControl("hostelBuildingpdfUploader") as FileUpload;

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
                        SOAPServices.Upload_Hostel_Buliding_File(blockCode.Text, servicePath, Session["SessionCompanyName"] as string);
                        Alert.ShowAlert(this, "s", "file Upload successfully");
                    }
                }
                else
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to Upload the content. Kindly contact the system administrator.");
                }
            }
        }
        protected void btnHostelDownload_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Building List", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Infra", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Read))
                {
                    LinkButton btn = sender as LinkButton;
                    ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
                    Label blockCode = item.FindControl("lblHostelBlockCode") as Label;

                    if (!string.IsNullOrEmpty(blockCode.Text))
                    {
                        string FileName = "Hostel" + "_" + blockCode.Text + ".pdf";
                        string bcPath = SOAPServices.Download_Hostel_Building_File(blockCode.Text, Session["SessionCompanyName"] as string);
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
                            Alert.ShowAlert(this, "e", "No file found. Please upload a file");
                        }
                    }
                }
                else
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to Download the content. Kindly contact the system administrator.");
                }
            }
        }

        protected void btnAuditoriumDownload_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Building List", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Infra", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Read))
                {
                    LinkButton btn = sender as LinkButton;
                    ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
                    Label buildingCode = item.FindControl("lblAuditoriumBuildingCode") as Label;

                    if (!string.IsNullOrEmpty(buildingCode.Text))
                    {
                        string FileName = "Auditorium" + "_" + buildingCode.Text + ".pdf";
                        string bcPath = SOAPServices.Download_Auditorium_Building_File(buildingCode.Text, Session["SessionCompanyName"] as string);
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
                            Alert.ShowAlert(this, "e", "No file found. Please upload a file");
                        }
                    }
                }
                else
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to Download the content. Kindly contact the system administrator.");
                }
            }
        }

        protected void auditoriumUpload_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Building List", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Infra", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Insert))
                {
                    LinkButton btn = sender as LinkButton;
                    ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
                    Label buildingCode = item.FindControl("lblAuditoriumBuildingCode") as Label;

                    FileUpload uploadedFile = item.FindControl("auditoriumpdfUploader") as FileUpload;

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
                        SOAPServices.Upload_Auditorium_Buliding_File(buildingCode.Text, servicePath, Session["SessionCompanyName"] as string);
                        Alert.ShowAlert(this, "s", "file Uploaded successfully");
                    }
                }
                else
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to Upload the content. Kindly contact the system administrator.");
                }
            }
        }

        protected void InstituteUpload_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Building List", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Infra", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Insert))
                {
                    LinkButton btn = sender as LinkButton;
                    ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
                    Label blockCode = item.FindControl("lblInstituteBlockCode") as Label;

                    FileUpload uploadedFile = item.FindControl("InstitutepdfUploader") as FileUpload;

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
                        SOAPServices.Upload_Institute_Buliding_File(blockCode.Text, servicePath, Session["SessionCompanyName"] as string);
                        Alert.ShowAlert(this, "s", "file Upload successfully");
                    }
                }
                else
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to Upload the content. Kindly contact the system administrator.");
                }
            }
        }

        protected void btnInstituteDownload_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Building List", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Infra", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Read))
                {
                    LinkButton btn = sender as LinkButton;
                    ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
                    Label blockCode = item.FindControl("lblInstituteBlockCode") as Label;

                    if (!string.IsNullOrEmpty(blockCode.Text))
                    {
                        string FileName = "Institute" + "_" + blockCode.Text + ".pdf";
                        string bcPath = SOAPServices.Download_Institutional_File(blockCode.Text, Session["SessionCompanyName"] as string);
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
                            Alert.ShowAlert(this, "e", "No file found. Please upload a file");
                        }
                    }
                }
                else
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to Download the content. Kindly contact the system administrator.");
                }
            }
        }

        protected void StaffQuarterUpload_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Building List", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Infra", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Insert))
                {
                    LinkButton btn = sender as LinkButton;
                    ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
                    Label quarterCode = item.FindControl("lblStaffQuarterCode") as Label;

                    FileUpload uploadedFile = item.FindControl("StaffQuarterpdfUploader") as FileUpload;

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
                        SOAPServices.Upload_Staff_Buliding_File(quarterCode.Text, servicePath, Session["SessionCompanyName"] as string);
                        Alert.ShowAlert(this, "s", "file Upload successfully");
                    }
                }
                else
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to Upload the content. Kindly contact the system administrator.");
                }
            }
        }

        protected void btnStaffQuarterDownload_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Building List", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Infra", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Read))
                {
                    LinkButton btn = sender as LinkButton;
                    ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
                    Label quarterCode = item.FindControl("lblStaffQuarterCode") as Label;

                    if (!string.IsNullOrEmpty(quarterCode.Text))
                    {
                        string FileName = "StaffQuarter" + "_" + quarterCode.Text + ".pdf";
                        string bcPath = SOAPServices.Download_Staff_Building_File(quarterCode.Text, Session["SessionCompanyName"] as string);
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
                            Alert.ShowAlert(this, "e", "No file found. Please upload a file");
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
}
    