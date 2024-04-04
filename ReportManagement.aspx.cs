using HRMS.Common;
using System;
using System.Configuration;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Net;
using WebServices;
using Microsoft.Office.Interop.Excel;
namespace HRMS
{
    public partial class ReportManagement : System.Web.UI.Page
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

        protected void btnEstimatePreparation_Click(object sender, EventArgs e)
        {
            var servicePath = SOAPServices.ExportDTETEstimatePreparationMonitoring(Session["SessionCompanyName"] as string);
            var fileName = "DTETEstimatePreparationMonitoring.XLS";
            this.FileExport(servicePath, fileName);
        }

        protected void btnAuditoriumBuilding_Click(object sender, EventArgs e)
        {
            var servicePath = SOAPServices.ExportDTETAuditoriumBuilding(Session["SessionCompanyName"] as string);
            var fileName = "DTETAuditoriumBuilding.XLS";
            this.FileExport(servicePath, fileName);
        }

        protected void btnHostelBuilding_Click(object sender, EventArgs e)
        {
            var servicePath = SOAPServices.ExportDTETHostelBuilding(Session["SessionCompanyName"] as string);
            var fileName = "DTETHostelBuilding.XLS";
            this.FileExport(servicePath, fileName);
        }

        protected void btnInstitutionalBuilding_Click(object sender, EventArgs e)
        {
            var servicePath = SOAPServices.ExportDTETInstitutionalBuilding(Session["SessionCompanyName"] as string);
            var fileName = "DTETInstitutionalBuilding.XLS";
            this.FileExport(servicePath, fileName);
        }

        protected void btnStaffBuilding_Click(object sender, EventArgs e)
        {
            var servicePath = SOAPServices.ExportDTETStaffBuilding(Session["SessionCompanyName"] as string);
            var fileName = "DTETStaffBuilding.XLS";
            this.FileExport(servicePath, fileName);
        }

        protected void btnLandDataDetail_Click(object sender, EventArgs e)
        {
            var servicePath = SOAPServices.ExportDTETLandDataDetails(Session["SessionCompanyName"] as string);
            var FileName = "DTETLandDataDetails.XLS";
            this.FileExport(servicePath, FileName);
        }

        protected void btnMaintanenceAndAMC_Click(object sender, EventArgs e)
        {
            var servicePath = SOAPServices.ExportDTETMaintanenceAndAMC(Session["SessionCompanyName"] as string);
            var FileName = "DTETMaintanenceAndAMC.XLS";
            this.FileExport(servicePath, FileName);
        }

        protected void btnProjectProgressDetail_Click(object sender, EventArgs e)
        {
            var servicePath = SOAPServices.ExportDTETProjectProgressDetails(Session["SessionCompanyName"] as string);
            var FileName = "ExportDTETProjectProgressDetails.XLS";
            this.FileExport(servicePath, FileName);
        }

        protected void btnServiceMonitoring_Click(object sender, EventArgs e)
        {
            var servicePath = SOAPServices.ExportDtetServiceMonitoring(Session["SessionCompanyName"] as string);
            var FileName = "DTETServiceMonitoring.XLS";
            this.FileExport(servicePath, FileName);
        }

        public void FileExport(string servicePath, string FileName)
        {
            try
            {
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
            catch (Exception ex)
            {
                if (ex.Message.Contains("404"))
                    Alert.ShowAlert(this, "e", "Report coud not be downloaded , because it was empty");

            }

        }

        protected void btnHome_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnEmployeLst_OnClick(object sender, EventArgs e)
        {
            var servicePath = SOAPServices.ExportDtetEmployeeList(Session["SessionCompanyName"] as string);
            var fileName = "DTETEmployeeList.XLS";
            this.FileExport(servicePath, fileName);
        }

        protected void btnEmpTransfr_OnClick(object sender, EventArgs e)
        {
            var servicePath = SOAPServices.ExportDtetTransferDetails(Session["SessionCompanyName"] as string);
            var fileName = "DTETTransferDetails.XLS";
            this.FileExport(servicePath, fileName);
        }

        protected void btnEmpPromotion_OnClick(object sender, EventArgs e)
        {
            var servicePath = SOAPServices.ExportDtetPromotionDetails(Session["SessionCompanyName"] as string);
            var fileName = "DTETPromotionDetails.XLS";
            this.FileExport(servicePath, fileName);
        }

        protected void btnAnualEstA_OnClick(object sender, EventArgs e)
        {
            var servicePath = SOAPServices.ExportDtetAnualEstPartA(Session["SessionCompanyName"] as string);
            var fileName = "DTETAnualEstPartA.XLS";
            this.FileExport(servicePath, fileName);
        }

        protected void btnStafProfile_OnClick(object sender, EventArgs e)
        {
            var servicePath = SOAPServices.ExportDtetStafProfile(Session["SessionCompanyName"] as string);
            var fileName = "DTETStafProfile.XLS";
            this.FileExport(servicePath, fileName);
        }

        protected void btnAnualEstC_OnClick(object sender, EventArgs e)
        {
            var servicePath = SOAPServices.ExportDtetAnualEstPartC(Session["SessionCompanyName"] as string);
            var fileName = "DTETAnualEstPartC.XLS";
            this.FileExport(servicePath, fileName);
        }

        protected void btnAnualEstE_OnClick(object sender, EventArgs e)
        {
            var servicePath = SOAPServices.ExportDtetAnualEstPartE(Session["SessionCompanyName"] as string);
            var fileName = "DTETAnualEstPartE.XLS";
            this.FileExport(servicePath, fileName);
        }

        protected void btnAnualPerformnc_OnClick(object sender, EventArgs e)
        {
            var servicePath = SOAPServices.ExportDtetAnualPerformance(Session["SessionCompanyName"] as string);
            var fileName = "DTETAnualPerformance.XLS";
            this.FileExport(servicePath, fileName);
        }

        protected void btnFinanceUpgrade_OnClick(object sender, EventArgs e)
        {
            var servicePath = SOAPServices.ExportDtetFinanceUpgrade(Session["SessionCompanyName"] as string);
            var fileName = "DTETFinanceUpgrade.XLS";
            this.FileExport(servicePath, fileName);
        }

        protected void lbLibrary_Click(object sender, EventArgs e)
        {
            var servicePath = SOAPServices.ExportLibrary(Session["SessionCompanyName"] as string);
            var fileName = "DTETLibrary.XLS";
            this.FileExport(servicePath, fileName);
        }


        protected void btnViewEmployeLst_ServerClick(object sender, EventArgs e)
        {
            var servicePath = SOAPServices.ExportDtetEmployeeList(Session["SessionCompanyName"] as string);
            string exportedFilePath = ConfigurationManager.AppSettings["ExportFilePath"].ToString() + StringHelper.GetFileNameFromURL(servicePath);
            var sheetname = exportedFilePath.Substring(exportedFilePath.IndexOf("PDF/") + 4, exportedFilePath.Length - (exportedFilePath.IndexOf("PDF/") + 4));
            Response.Write(exportedFilePath);
            string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PDF\\" + sheetname);
            Response.Write(path1);
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#myModal').modal('show')", true);
            try
            {
                GridView1.DataSource = ReadExcelFile("Sheet1", servicePath);
                GridView1.DataBind();
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
        }

        private System.Data.DataTable ReadExcelFile(string sheetName, string path)
        {
            using (OleDbConnection conn = new OleDbConnection())
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                string Import_FileName = path;
                string fileExtension = Path.GetExtension(Import_FileName);
                if (fileExtension.ToLower() == ".xls")
                    conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 8.0;HDR=YES;'";
                if (fileExtension.ToLower() == ".xlsx")
                    conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
                using (OleDbCommand comm = new OleDbCommand())
                {
                    comm.CommandText = "Select * from [" + sheetName + "$]";

                    comm.Connection = conn;

                    using (OleDbDataAdapter da = new OleDbDataAdapter())
                    {
                        da.SelectCommand = comm;
                        da.Fill(dt);
                        return dt;
                    }

                }
            }

        }

        protected void lbdailypaymentdtet_Click(object sender, EventArgs e)
        {
            Response.Redirect("DTETReport?reportname=daybookdtetreport");
        }

        protected void lbdailyreceiptdtet_Click(object sender, EventArgs e)
        {
            Response.Redirect("DTETReport?reportname=dailyreceiptdtetreport");
        }

        protected void lbdaybookdtet_Click(object sender, EventArgs e)
        {
            Response.Redirect("DTETReport?reportname=dailypaymentdtetreport");
        }
    }
}