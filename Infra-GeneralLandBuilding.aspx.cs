using HRMS.Common;
using InfrastructureManagement.Common;
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
    public partial class Infra_GeneralLandBuilding : System.Web.UI.Page
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
                var result = ODataServices.GetGeneralLandBuildingList(Session["SessionCompanyName"] as string);

                if (result != null && result.Any())
                {
                    var rec = result.FirstOrDefault();
                    hdnKey.Value = rec.Primary_Key;
                    chkBoys_Common_Room_Available.Checked = rec.Boys_Common_Room_Available == "Yes" ? true : false;
                    txtBoys_Common_Room_Details.Text = rec.Boys_Common_Room_Details;
                    txtCanteen_Cafeteria_Capacity.Text = Convert.ToString(rec.Canteen_Cafeteria_Capacity);
                    chkCanteen_Caf_for_Staffs_Avail.Checked = rec.Canteen_Caf_for_Staffs_Avail == "Yes" ? true : false;
                    chkCentralLibraryAvailable.Checked = rec.Central_Library_Available == "Yes" ? true : false;
                    chkCoE_Program_Available.Checked = rec.CoE_Program_Available == "Yes" ? true : false;
                    txtCoE_Program_Details.Text = rec.CoE_Program_Details;
                    chkConferenceRoomAvailable.Checked = rec.Conference_Room_Available == "Yes" ? true : false;
                    chkCSR_Activities_Available.Checked = rec.CSR_Activities_Available == "Yes" ? true : false;
                    txtCSR_Activity_Details.Text = rec.CSR_Activity_Details;
                    chkDigitalLibraryAvailable.Checked = rec.Digital_Library_Available == "Yes" ? true : false;
                    chkDispensary_Available.Checked = rec.Dispensary_Available == "Yes" ? true : false;
                    txtField_Area_in_Acres.Text = Convert.ToString(rec.Field_Area_in_Acres);
                    chkFieldAvailable.Checked = rec.Field_Available == "Yes" ? true : false;
                    chkFieldGalleryAvailable.Checked = rec.Field_Gallery_Available == "Yes" ? true : false;
                    txtFloor_size_of_the_Video_conf.Text = Convert.ToString(rec.Floor_size_of_the_Video_conf);
                    chkGirls_Common_Room_Available.Checked = rec.Girls_Common_Room_Available == "Yes" ? true : false;
                    txtGirls_Common_Room_Details.Text = rec.Girls_Common_Room_Details;
                    chkInternet_Connection_Available.Checked = rec.Internet_Connection_Available == "Yes" ? true : false;
                    chkLibrary_Available.Checked = rec.Library_Available == "Yes" ? true : false;
                    chkRain_Water_Harvesting_Avail.Checked = rec.Rain_Water_Harvesting_Avail == "Yes" ? true : false;
                    chkRoof_Top_Solar_Panel_Available.Checked = rec.Roof_Top_Solar_Panel_Available == "Yes" ? true : false;
                    chkSewage_Treatment_Plant_Avail.Checked = rec.Sewage_Treatment_Plant_Avail == "Yes" ? true : false;
                    txtSports_Court_Area_in_Sqft.Text = Convert.ToString(rec.Sports_Court_Area_in_Sqft);
                    chkSportCourt.Checked = rec.Sport_x2019_s_Court_Available == "Yes" ? true : false;
                    chkStaff_Common_Room_Available.Checked = rec.Staff_Common_Room_Available == "Yes" ? true : false;
                    txtStaff_Common_Room_Details.Text = rec.Staff_Common_Room_Details;
                    //txtUploaded_FileName.Text = rec.Uploaded_FileName;
                    chkVideo_Conference_Room_Avail.Checked = rec.Video_Conference_Room_Avail == "Yes" ? true : false;
                    txtVideo_Conference_Room_Capacity.Text = Convert.ToString(rec.Video_Conference_Room_Capacity);
                    txtVideo_Conference_Room_Location.Text = rec.Video_Conference_Room_Location;
                    txtYear_of_Establis_of_institute.Text = rec.Year_of_Establis_of_institute;
                }
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            string FileName = "GeneralBuilding.XLS";
            string exportedFilePath = ConfigurationManager.AppSettings["ExportFilePath"].ToString() 
                + StringHelper.GetFileNameFromURL(SOAPServices.Downlond_GeneralLand_Building_File(string.Empty, Session["SessionCompanyName"] as string));
            WebClient wc = new WebClient();
            byte[] buffer = wc.DownloadData(exportedFilePath);

            var fileName = "attachment; filename=" + FileName;
            base.Response.ClearContent();
            base.Response.AddHeader("content-disposition", fileName);
            base.Response.ContentType = "application/vnd.ms-excel";
            base.Response.BinaryWrite(buffer);
            base.Response.End();
        }

        public UploadedResult GenerateUploadPath(string fileName)
        {
            string fileExtention = Path.GetExtension(fileName);
            string finalFileName = Path.GetFileNameWithoutExtension(new string(fileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
            string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            if (Directory.Exists(path))
            {
                path = Path.Combine(path, finalFileName);
            }
            string servicePath = ConfigurationManager.AppSettings["PdfPath"].ToString() + finalFileName;
            return new UploadedResult { Path = path, ServicePath = servicePath };
        }

        protected void fileAvailableUpload_Click(object sender, EventArgs e)
        {
            if (FileAvailablepdfUploader.HasFile)
            {
                string fileExtention = Path.GetExtension(FileAvailablepdfUploader.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(new string(FileAvailablepdfUploader.FileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    FileAvailablepdfUploader.SaveAs(path);
                }
                string servicePath = ConfigurationManager.AppSettings["PdfPath"].ToString() + finalFileName;
                SOAPServices.Upload_GB_Field_Photos(servicePath, Session["SessionCompanyName"] as string);
            }
        }

        protected void btnFileAvailableDownload_Click(object sender, EventArgs e)
        {
            string FileName = "Field_Photos" + "_" + ".pdf";
            string bcPath = SOAPServices.Downlond_GB_Field_Photos(Session["SessionCompanyName"] as string);
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

        protected void SportCourtFileUploadButton_Click(object sender, EventArgs e)
        {
            if (SportCourtFileUploader.HasFile)
            {
                string fileExtention = Path.GetExtension(SportCourtFileUploader.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(new string(SportCourtFileUploader.FileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    SportCourtFileUploader.SaveAs(path);
                }
                string servicePath = ConfigurationManager.AppSettings["PdfPath"].ToString() + finalFileName;
                SOAPServices.Upload_GB_Sports_Court_photo(servicePath, Session["SessionCompanyName"] as string);
            }
        }

        protected void SportCourtDownloadButton_Click(object sender, EventArgs e)
        {
            string FileName = "Sports_Court" + "_" + ".pdf";
            string bcPath = SOAPServices.Downlond_GB_Sports_Court_photo(Session["SessionCompanyName"] as string);
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

        protected void fieldGalleryFileUploadButton_Click(object sender, EventArgs e)
        {
            if (fieldGalleryFileUploader.HasFile)
            {
                string fileExtention = Path.GetExtension(fieldGalleryFileUploader.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(new string(fieldGalleryFileUploader.FileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    fieldGalleryFileUploader.SaveAs(path);
                }
                string servicePath = ConfigurationManager.AppSettings["PdfPath"].ToString() + finalFileName;
                SOAPServices.Upload_GB_Field_Gallery_photo(servicePath, Session["SessionCompanyName"] as string);
            }
        }

        protected void fieldGalleryDownloadButton_Click(object sender, EventArgs e)
        {
            string FileName = "Field_Gallery" + "_" + ".pdf";
            string bcPath = SOAPServices.Downlond_GB_Field_Gallery_photo(Session["SessionCompanyName"] as string);
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

        protected void conferenceRoomUploadButton_Click(object sender, EventArgs e)
        {
            if (conferenceRoomFileUploader.HasFile)
            {
                string fileExtention = Path.GetExtension(conferenceRoomFileUploader.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(new string(conferenceRoomFileUploader.FileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    conferenceRoomFileUploader.SaveAs(path);
                }
                string servicePath = ConfigurationManager.AppSettings["PdfPath"].ToString() + finalFileName;
                SOAPServices.Upload_GB_Conference_Room_photo(servicePath, Session["SessionCompanyName"] as string);
            }
        }

        protected void conferenceRoomDownloadButton_Click(object sender, EventArgs e)
        {
            string FileName = "Conference_Room" + "_" + ".pdf";
            string bcPath = SOAPServices.Downlond_GB_Conference_Room_photo(Session["SessionCompanyName"] as string);
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

        protected void videoConferenceRoomUploadButton_Click(object sender, EventArgs e)
        {
            if (VideoConferenceRoomUploader.HasFile)
            {
                string fileExtention = Path.GetExtension(VideoConferenceRoomUploader.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(new string(VideoConferenceRoomUploader.FileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    VideoConferenceRoomUploader.SaveAs(path);
                }
                string servicePath = ConfigurationManager.AppSettings["PdfPath"].ToString() + finalFileName;
                SOAPServices.Upload_GB_Video_Conference_Room_photo(servicePath, Session["SessionCompanyName"] as string);
            }
        }

        protected void VideoConferenceRoomDownloadButton_Click(object sender, EventArgs e)
        {
            string FileName = "Video_Conference" + "_" + ".pdf";
            string bcPath = SOAPServices.Downlond_GB_Video_Conference_Room_photo(Session["SessionCompanyName"] as string);
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

        protected void Library_AvailableUploadButton_Click(object sender, EventArgs e)
        {
            if (Library_AvailableFileUploader.HasFile)
            {
                string fileExtention = Path.GetExtension(Library_AvailableFileUploader.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(new string(Library_AvailableFileUploader.FileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    Library_AvailableFileUploader.SaveAs(path);
                }
                string servicePath = ConfigurationManager.AppSettings["PdfPath"].ToString() + finalFileName;
                SOAPServices.Upload_GB_Library_Photos(servicePath, Session["SessionCompanyName"] as string);
            }
        }

        protected void Library_AvailableDownloadButton_Click(object sender, EventArgs e)
        {
            string FileName = "Library_Photos" + "_" + ".pdf";
            string bcPath = SOAPServices.Downlond_GB_Library_Photos(Session["SessionCompanyName"] as string);
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

        protected void CentralLibraryUploadButton_Click(object sender, EventArgs e)
        {
            if (CentralLibraryFileUploader.HasFile)
            {
                string fileExtention = Path.GetExtension(CentralLibraryFileUploader.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(new string(CentralLibraryFileUploader.FileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    CentralLibraryFileUploader.SaveAs(path);
                }
                string servicePath = ConfigurationManager.AppSettings["PdfPath"].ToString() + finalFileName;
                SOAPServices.Upload_GB_Central_Library_Photos(servicePath, Session["SessionCompanyName"] as string);
            }
        }

        protected void CentralLibraryDowloadButton_Click(object sender, EventArgs e)
        {
            string FileName = "Library_Photos" + "_" + ".pdf";
            string bcPath = SOAPServices.Downlond_GB_Central_Library_Photos(Session["SessionCompanyName"] as string);
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

        protected void mainEntranceUploadButton_Click(object sender, EventArgs e)
        {
            if (mainEntranceUploader.HasFile)
            {
                string fileExtention = Path.GetExtension(mainEntranceUploader.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(new string(mainEntranceUploader.FileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    mainEntranceUploader.SaveAs(path);
                }
                string servicePath = ConfigurationManager.AppSettings["PdfPath"].ToString() + finalFileName;
                SOAPServices.Upload_GB_Main_Entrance_Photos(servicePath, Session["SessionCompanyName"] as string);
            }
        }

        protected void mainEntranceDownButton_Click(object sender, EventArgs e)
        {
            string FileName = "Main_Entrance" + "_" + ".pdf";
            string bcPath = SOAPServices.Downlond_GB_Main_Entrance_Photos(Session["SessionCompanyName"] as string);
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

        protected void DispensaryAvailableUploadButton_Click(object sender, EventArgs e)
        {
            if (DispensaryAvailableUploader.HasFile)
            {
                string fileExtention = Path.GetExtension(DispensaryAvailableUploader.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(new string(DispensaryAvailableUploader.FileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    DispensaryAvailableUploader.SaveAs(path);
                }
                string servicePath = ConfigurationManager.AppSettings["PdfPath"].ToString() + finalFileName;
                SOAPServices.Upload_GB_Dispensary_Photos(servicePath, Session["SessionCompanyName"] as string);
            }
        }

        protected void DispensaryAvailableDownloadButton_Click(object sender, EventArgs e)
        {
            string FileName = "Dispensary_Photos" + "_" + ".pdf";
            string bcPath = SOAPServices.Downlond_GB_Dispensary_Photos(Session["SessionCompanyName"] as string);
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

        protected void StaffCommonRoomUploadButton_Click(object sender, EventArgs e)
        {
            if (StaffCommonRoomAvailableUploader.HasFile)
            {
                string fileExtention = Path.GetExtension(StaffCommonRoomAvailableUploader.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(new string(StaffCommonRoomAvailableUploader.FileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    StaffCommonRoomAvailableUploader.SaveAs(path);
                }
                string servicePath = ConfigurationManager.AppSettings["PdfPath"].ToString() + finalFileName;
                SOAPServices.Upload_GB_Staff_Common_Room_Photos(servicePath, Session["SessionCompanyName"] as string);
            }
        }

        protected void StaffCommonRoomAvailableDownloadButton_Click(object sender, EventArgs e)
        {
            string FileName = "Staff_Common_Room_Photos" + "_" + ".pdf";
            string bcPath = SOAPServices.Downlond_GB_Staff_Common_Room_Photos(Session["SessionCompanyName"] as string);
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

        protected void girlsCommonRoomUploadButton_Click(object sender, EventArgs e)
        {
            if (girlsCommonRoomAvailableUploader.HasFile)
            {
                string fileExtention = Path.GetExtension(girlsCommonRoomAvailableUploader.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(new string(girlsCommonRoomAvailableUploader.FileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    girlsCommonRoomAvailableUploader.SaveAs(path);
                }
                string servicePath = ConfigurationManager.AppSettings["PdfPath"].ToString() + finalFileName;
                SOAPServices.Upload_GB_Girls_Common_Room_Photos(servicePath, Session["SessionCompanyName"] as string);
            }
        }

        protected void girlsCommonRoomAvailableDownloadButton_Click(object sender, EventArgs e)
        {
            string FileName = "Girls_Common_Room_Photos" + "_" + ".pdf";
            string bcPath = SOAPServices.Downlond_GB_Girls_Common_Room_Photos(Session["SessionCompanyName"] as string);
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

        protected void BoysCommonRoomUploadButton_Click(object sender, EventArgs e)
        {
            if (Boys_Common_RoomUploader.HasFile)
            {
                string fileExtention = Path.GetExtension(Boys_Common_RoomUploader.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(new string(Boys_Common_RoomUploader.FileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    Boys_Common_RoomUploader.SaveAs(path);
                }
                string servicePath = ConfigurationManager.AppSettings["PdfPath"].ToString() + finalFileName;
                SOAPServices.Upload_GB_Boys_Common_Room_Photos(servicePath, Session["SessionCompanyName"] as string);
            }
        }

        protected void Boys_Common_RoomDownloadButton_Click(object sender, EventArgs e)
        {
            string FileName = "Boys_Common_Room_Photos" + "_" + ".pdf";
            string bcPath = SOAPServices.Downlond_GB_Boys_Common_Room_Photos(Session["SessionCompanyName"] as string);
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

        protected void Canteen_CafUploadButton_Click(object sender, EventArgs e)
        {
            if (Canteen_CafUploader.HasFile)
            {
                string fileExtention = Path.GetExtension(Canteen_CafUploader.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(new string(Canteen_CafUploader.FileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    Canteen_CafUploader.SaveAs(path);
                }
                string servicePath = ConfigurationManager.AppSettings["PdfPath"].ToString() + finalFileName;
                SOAPServices.Upload_GB_Staff_Canteena47Cafeteria_Photos(servicePath, Session["SessionCompanyName"] as string);
            }
        }

        protected void Canteen_CafDownloadButton_Click(object sender, EventArgs e)
        {
            string FileName = "Staff_Canteena_Cafeteria_Photos" + "_" + ".pdf";
            string exportedFilePath = ConfigurationManager.AppSettings["ExportFilePath"].ToString() + StringHelper.GetFileNameFromURL(SOAPServices.Downlond_GB_Staff_Canteena47Cafeteria_Photos(Session["SessionCompanyName"] as string));
            WebClient wc = new WebClient();
            byte[] buffer = wc.DownloadData(exportedFilePath);

            var fileName = "attachment; filename=" + FileName;
            base.Response.ClearContent();
            base.Response.AddHeader("content-disposition", fileName);
            base.Response.ContentType = "application/pdf";
            base.Response.BinaryWrite(buffer);
            base.Response.End();
        }
    }

    public class UploadedResult
    {
        public string Path { get; set; }
        public string ServicePath { get; set; }
    }
}