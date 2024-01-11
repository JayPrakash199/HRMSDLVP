using HRMS.Common;
using System;
using System.Configuration;
using System.Net;
using WebServices;

namespace HRMS
{
    public partial class Infra_Reports : System.Web.UI.Page
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
            var FileName = "DTETEstimatePreparationMonitoring.XLS";
            this.FileExport(servicePath, FileName);
        }

        protected void btnAuditoriumBuilding_Click(object sender, EventArgs e)
        {
            var servicePath = SOAPServices.ExportDTETAuditoriumBuilding(Session["SessionCompanyName"] as string);
            var FileName = "DTETAuditoriumBuilding.XLS";
            this.FileExport(servicePath, FileName);
        }

        protected void btnHostelBuilding_Click(object sender, EventArgs e)
        {
            var servicePath = SOAPServices.ExportDTETHostelBuilding(Session["SessionCompanyName"] as string);
            var FileName = "DTETHostelBuilding.XLS";
            this.FileExport(servicePath, FileName);
        }

        protected void btnInstitutionalBuilding_Click(object sender, EventArgs e)
        {
            var servicePath = SOAPServices.ExportDTETInstitutionalBuilding(Session["SessionCompanyName"] as string);
            var FileName = "DTETInstitutionalBuilding.XLS";
            this.FileExport(servicePath, FileName);
        }

        protected void btnStaffBuilding_Click(object sender, EventArgs e)
        {
            var servicePath = SOAPServices.ExportDTETStaffBuilding(Session["SessionCompanyName"] as string);
            var FileName = "DTETStaffBuilding.XLS";
            this.FileExport(servicePath, FileName);

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

        protected void btnHome_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/");
        }

    }
}