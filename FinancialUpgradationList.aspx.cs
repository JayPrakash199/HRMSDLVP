using HRMS.Common;
using InfrastructureManagement.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class FinancialUpgradationList : System.Web.UI.Page
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
                List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
                var role = lstUserRole
                    .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Page_Name.Trim(), "Financial Upgradation Application List", StringComparison.OrdinalIgnoreCase)
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

                if (string.IsNullOrEmpty(Session["SessionCompanyName"] as string))
                {
                    string message = string.Format("Message: {0}\\n\\n", "Please select a company");
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
                    Response.Redirect("Default.aspx");
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
                string.Equals(x.Page_Name.Trim(), "Financial Upgradation Application List", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Read))
                {
                    var servicePath = SOAPServices.ExportFinancialUpgrdations(Session["SessionCompanyName"] as string);
                    if (!string.IsNullOrEmpty(servicePath))
                    {
                        var FileName = "FinancialUpgradations.XLS";
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
                        Alert.ShowAlert(this, "e", "No file found.");
                    }
                }
                else
                {
                    Alert.ShowAlert(this, "w", "You do not have permission to Export the content. Kindly contact the system administrator");
                }
            }
        }

        protected void FinancialUpgradeListView_ItemDataBound(object sender, System.Web.UI.WebControls.ListViewItemEventArgs e)
        {
            if (FinancialUpgradeListView.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("Status"));
                dt.Rows.Add("Applied");
                dt.Rows.Add("Objected");
                dt.Rows.Add("Processed");
                dt.Rows.Add("Rejected");
                DropDownList ddlStatus = (e.Item.FindControl("ddlStatus") as DropDownList);
                ddlStatus.DataSource = dt;
                ddlStatus.DataTextField = "Status";
                ddlStatus.DataValueField = "Status";
                ddlStatus.DataBind();
                ddlStatus.Items.Insert(0, new ListItem("Select Status", "0"));
                Label lblStatus = (e.Item.FindControl("lblStatus") as Label);
                ddlStatus.Items.FindByValue(lblStatus.Text).Selected = true;
            }
        }

        protected void FinancialUpgradeListView_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Financial Upgradation Application List", StringComparison.OrdinalIgnoreCase)
                && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));
            if (role == null)
            {
                FinancialUpgradeListView.EditIndex = e.NewEditIndex;
                BindListView();
            }
            else
            {
                if (!Convert.ToBoolean(role.Modify))
                {
                    Alert.ShowAlert(this, "W",
                        "You do not have permission to modify the content. Kindly contact the system administrator.");
                    FinancialUpgradeListView.EditIndex = -1;
                    BindListView();
                    return;
                }
                FinancialUpgradeListView.EditIndex = e.NewEditIndex;
                BindListView();
            }
        }

        public void BindListView()
        {
            var result = ODataServices.GetFinancialUpgradeList(Session["SessionCompanyName"] as string);
            if (result != null)
            {
                FinancialUpgradeListView.DataSource = result;
                FinancialUpgradeListView.DataBind();
            }
        }

        protected void FinancialUpgradeListView_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            string entryNo = (FinancialUpgradeListView.Items[e.ItemIndex].FindControl("lblEntryNo") as Label)?.Text;
            string hrmsId = (FinancialUpgradeListView.Items[e.ItemIndex].FindControl("lblHRMSId") as Label)?.Text;
            string status = (FinancialUpgradeListView.Items[e.ItemIndex].FindControl("ddlStatus") as DropDownList)?.SelectedItem.Value;
            //foreach (DataRow row in Persons.Rows)
            //{
            //    if (row["Name"].ToString() == name)
            //    {
            //        row["Country"] = country;
            //        break;
            //    }
            //}
            var updateObj = new WebServices.FinancialUpgradeReference.FinancialUpgradeCard
            {
                Entry_No = NumericHandler.ConvertToInteger(entryNo),
                HRMS_ID = hrmsId,
                Status = status == "Applied" ? WebServices.FinancialUpgradeReference.Status.Applied
                 : status == "Objected" ? WebServices.FinancialUpgradeReference.Status.Objected
                 : status == "Processed" ? WebServices.FinancialUpgradeReference.Status.Processed
                 : WebServices.FinancialUpgradeReference.Status.Rejected
            };
            SOAPServices.UpdateFinancialUpgradation(updateObj, Session["SessionCompanyName"] as string);
            FinancialUpgradeListView.EditIndex = -1;
            BindListView();
        }

        protected void FinancialUpgradeListView_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            FinancialUpgradeListView.EditIndex = -1;
            BindListView();
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Financial Upgradation Application List", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Read))
                {
                    LinkButton btn = sender as LinkButton;
                    ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
                    Label entryNo = item.FindControl("lblEntryNo") as Label;
                    Label hrmsID = item.FindControl("lblHRMSID") as Label;

                    if (!string.IsNullOrEmpty(entryNo.Text) && !string.IsNullOrEmpty(hrmsID.Text))
                    {
                        string FileName = "FinancialUpgradationList" + "_" + hrmsID.Text + ".pdf";
                        string companyName = Session["SessionCompanyName"] as string;
                        string bcPath = SOAPServices.DownloadFinancialUpgradationApplication(Convert.ToInt32(entryNo.Text), hrmsID.Text, companyName);
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

        protected void financialUpgradationUpload_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Financial Upgradation Application List", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Insert))
                {
                    LinkButton btn = sender as LinkButton;
                    ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
                    Label entryNo = item.FindControl("lblEntryNo") as Label;
                    Label hrmsID = item.FindControl("lblHRMSID") as Label;

                    FileUpload uploadedFile = item.FindControl("financialUpgradationpdfUploader") as FileUpload;

                    if (uploadedFile.HasFile && !string.IsNullOrEmpty(entryNo.Text) && !string.IsNullOrEmpty(hrmsID.Text))
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
                        SOAPServices.UploadFinancialUpgradationApplication(Convert.ToInt32(entryNo.Text), hrmsID.Text, servicePath, Session["SessionCompanyName"] as string);
                        Alert.ShowAlert(this, "s", "file uploaded successfully");
                    }
                }
                else
                {
                    Alert.ShowAlert(this, "w", "You do not have permission to Upload the content. Kindly contact the system administrator");
                }
            }
        }
    }
}