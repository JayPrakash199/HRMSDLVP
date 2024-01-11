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
    public partial class TrainingHistory : System.Web.UI.Page
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

                var lstUserRole = ODataServices.GetUserAuthorizationList();
                var role = lstUserRole
                    .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Page_Name.Trim(), "Training History", StringComparison.OrdinalIgnoreCase)
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
                            "You do not have permission to read the data. Kindly contact the system administrator.");
                        return;
                    }

                    BindListView();
                }
            }

        }

        private void BindListView()
        {
            var trainingHistories = new List<SubTrainingHistory>();

            var result = ODataServices.GetEmployeeTrainingHistoryList(Session["SessionCompanyName"] as string);

            var groupedResult = result.GroupBy(x => x.HRMS_ID)
                                      .Select(grp => grp.ToList())
                                      .ToList();
            foreach (var item in groupedResult)
            {
                var history = new SubTrainingHistory
                {
                    Entry_No = item.FirstOrDefault().Entry_No,
                    HRMS_ID = item.FirstOrDefault().HRMS_ID,
                    Employee_Name = item.FirstOrDefault().Employee_Name,
                    Designation = item.FirstOrDefault().Designation,
                    Number_of_Training = item.Count,
                    Type_Of_Training = item.FirstOrDefault().Type_Of_Training,
                    Traing_Course_Title = item.FirstOrDefault().Traing_Course_Title,
                    Training_Starting_Date = item.FirstOrDefault().Training_Starting_Date,
                    Training_Ending_Date = item.FirstOrDefault().Training_Ending_Date,
                    Duration_Of_Training = item.FirstOrDefault().Duration_Of_Training,
                    Conducted_By = item.FirstOrDefault().Conducted_By,
                    Training_Location = item.FirstOrDefault().Training_Location
                };
                trainingHistories.Add(history);
            }

            if (result.Any())
            {
                TrainingHistoryListView.DataSource = trainingHistories;
                TrainingHistoryListView.DataBind();
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            var servicePath = SOAPServices.ExportEmployeeTrainingDetails(Session["SessionCompanyName"] as string);
            var FileName = "EmployeeTrainingDetails.XLS";
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

        protected void trainingHistoryUpload_Click(object sender, EventArgs e)
        {
            var lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                 string.Equals(x.Page_Name.Trim(), "Training History", StringComparison.OrdinalIgnoreCase)
                 && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));
            if (role == null)
            {
                UploadTrainingRecord(sender);
            }
            else
            {
                if (!Convert.ToBoolean(role.Modify))
                {
                    Alert.ShowAlert(this, "W",
                        "You do not have permission to modify the data. Kindly contact the system administrator.");
                    return;
                }
                UploadTrainingRecord(sender);
            }
        }

        private void UploadTrainingRecord(object sender)
        {
            LinkButton btn = sender as LinkButton;
            ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
            Label entryNo = item.FindControl("lblEntryNo") as Label;

            FileUpload uploadedFile = item.FindControl("trainingHistorypdfUploader") as FileUpload;

            if (uploadedFile != null && uploadedFile.HasFile && !string.IsNullOrEmpty(entryNo.Text))
            {
                string fileExtenstion = Path.GetExtension(uploadedFile.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(new string(uploadedFile.FileName.Take(10).ToArray())) +
                                       "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtenstion;
                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    uploadedFile.SaveAs(path);
                }

                string servicePath = ConfigurationManager.AppSettings["PdfPath"].ToString() + finalFileName;
                SOAPServices.UploadEmployeeTrainingHistoryCertificate(Convert.ToInt32(entryNo.Text), servicePath,
                    Session["SessionCompanyName"] as string);
                Alert.ShowAlert(this, "s", "file uploaded successfully");
            }
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {

            var lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                 string.Equals(x.Page_Name.Trim(), "Training History", StringComparison.OrdinalIgnoreCase)
                 && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));
            if (role == null)
            {
                DownloadTrainingRecord(sender);
            }
            else
            {
                if (!Convert.ToBoolean(role.Modify))
                {
                    Alert.ShowAlert(this, "W",
                        "You do not have permission to modify the data. Kindly contact the system administrator.");
                    return;
                }

                DownloadTrainingRecord(sender);
            }
        }

        private void DownloadTrainingRecord(object sender)
        {
            LinkButton btn = sender as LinkButton;
            ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
            if (item != null)
            {
                Label entryNo = item.FindControl("lblEntryNo") as Label;

                if (!string.IsNullOrEmpty(entryNo.Text))
                {
                    string FileName = "EmployeeTraining" + "_" + entryNo.Text + ".pdf";
                    string bcPath = SOAPServices.DownloadEmployeeTrainingHistoryCertificate(Convert.ToInt32(entryNo.Text),
                        Session["SessionCompanyName"] as string);
                    if (!string.IsNullOrEmpty(bcPath))
                    {
                        string exportedFilePath = ConfigurationManager.AppSettings["ExportFilePath"].ToString() +
                                                  StringHelper.GetFileNameFromURL(bcPath);

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
        }
    }
    public class SubTrainingHistory
    {
        public int Entry_No { get; set; }
        public string HRMS_ID { get; set; }
        public string Employee_Name { get; set; }
        public string Designation { get; set; }
        public int Number_of_Training { get; set; }
        public string Type_Of_Training { get; set; }
        public string Traing_Course_Title { get; set; }
        public Microsoft.OData.Edm.Date? Training_Starting_Date { get; set; }
        public Microsoft.OData.Edm.Date? Training_Ending_Date { get; set; }
        public int? Duration_Of_Training { get; set; }
        public string Conducted_By { get; set; }
        public string Training_Location { get; set; }
    }
}