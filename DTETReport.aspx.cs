using HRMS.Common;
using HRMSODATA;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class DTETReport : System.Web.UI.Page
    {
        string reportName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDocumentDropDownList();
                ShowDimentation();
                BindCompany();
            }
            reportName = Request.QueryString["reportname"];


        }
        public void BindDocumentDropDownList()
        {
            var list = ODataServices.GetDocumentData(Session["SessionCompanyName"] as string);

            var DcList = new List<DocumentList>();

            foreach (var dc in list)
            {
                DcList.Add(new HRMS.DocumentList
                {
                    DocumentNo = dc.Document_No,
                    DocumentName = dc.Document_No + " " + dc.Document_Type + " " + dc.Customer_No + " " + dc.Amount_LCY
                });
            }

            ddlDocumentNo.DataSource = DcList;
            ddlDocumentNo.DataTextField = "DocumentName";
            ddlDocumentNo.DataValueField = "DocumentNo";
            ddlDocumentNo.DataBind();
            ddlDocumentNo.Items.Insert(0, new ListItem("Select Document", "0"));
        }
        private void ShowDimentation()
        {
            var dimensionList = ODataServices.GetDimentionList(Session["SessionCompanyName"] as string);
            BindInstitute(dimensionList);
            BindDepartment(dimensionList);
        }
        private void BindDepartment(IList<DimValueList> dimensionList)
        {
            var departmentList = dimensionList.Where(x => string.Equals("DEPARTMENT", x.Dimension_Code, StringComparison.OrdinalIgnoreCase)).ToList();
            var lstDpt = new List<Dimension>();
            foreach (var dc in departmentList)
            {
                lstDpt.Add(new HRMS.Dimension
                {
                    Code = dc.Code,
                    Name = dc.Name
                });
            }
            ddlDepartment.DataSource = lstDpt;
            ddlDepartment.DataTextField = "Code";
            ddlDepartment.DataValueField = "Code";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("Select Department", "0"));
        }

        private void BindInstitute(IList<DimValueList> dimensionList)
        {
            var instituteList = dimensionList.Where(x => string.Equals("INSTITUTE", x.Dimension_Code, StringComparison.OrdinalIgnoreCase)).ToList();
            var lstInstitute = new List<Dimension>();
            foreach (var dc in instituteList)
            {
                lstInstitute.Add(new HRMS.Dimension
                {
                    Code = dc.Code,
                    Name = dc.Name
                });
            }
            ddlInstiuteCode.DataSource = lstInstitute;
            ddlInstiuteCode.DataTextField = "Code";
            ddlInstiuteCode.DataValueField = "Code";
            ddlInstiuteCode.DataBind();
            ddlInstiuteCode.Items.Insert(0, new ListItem("Select Institute", "0"));
        }
        private void BindCompany()
        {
            var companyList = ODataServices.GetCompanyList();
            ddlCompany.DataSource = companyList;
            ddlCompany.DataTextField = "Name";
            ddlCompany.DataValueField = "Name";
            ddlCompany.DataBind();
            ddlCompany.Items.Insert(0, new ListItem("Select company", "0"));
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(txtFromDate.Text) && !string.IsNullOrEmpty(txtToDate.Text)
                   || !string.IsNullOrEmpty(txtFromDate.Text) && string.IsNullOrEmpty(txtToDate.Text))
                {
                    Alert.ShowAlert(this, "e", "plese select both From Date and To Date");
                    return;
                }

                string servicePath = "";

                if (reportName.ToLower() == "daybookdtetreport")
                {
                    servicePath = SOAPServices.GetDayBookDTETReport(
                            rdLineNarration.Checked,
                            rdvoucherNaration.Checked,
                            ddlDocumentNo.SelectedValue == "0" ? "" : ddlDocumentNo.SelectedValue,
                            !string.IsNullOrEmpty(txtFromDate.Text) ? txtFromDate.Text : "0D",
                            !string.IsNullOrEmpty(txtToDate.Text) ? txtToDate.Text : "0D",
                             ddlInstiuteCode.SelectedValue == "0" ? "" : ddlInstiuteCode.SelectedItem.Text,
                             ddlDepartment.SelectedValue == "0" ? "" : ddlDepartment.SelectedItem.Text,
                            Session["SessionCompanyName"] as string,
                            ddlCompany.SelectedItem.Text);
                }
                if (reportName.ToLower() == "dailyreceiptdtetreport")
                {
                    servicePath = SOAPServices.GetDailyPaymentDTETReport(
                            rdLineNarration.Checked,
                            rdvoucherNaration.Checked,
                            ddlDocumentNo.SelectedValue == "0" ? "" : ddlDocumentNo.SelectedValue,
                            !string.IsNullOrEmpty(txtFromDate.Text) ? txtFromDate.Text : "0D",
                            !string.IsNullOrEmpty(txtToDate.Text) ? txtToDate.Text : "0D",
                             ddlInstiuteCode.SelectedValue == "0" ? "" : ddlInstiuteCode.SelectedItem.Text,
                             ddlDepartment.SelectedValue == "0" ? "" : ddlDepartment.SelectedItem.Text,
                            Session["SessionCompanyName"] as string,
                            ddlCompany.SelectedItem.Text);
                }
                if (reportName.ToLower() == "dailypaymentdtetreport")
                {
                    servicePath = SOAPServices.GetDailyPaymentDTETReport(
                            rdLineNarration.Checked,
                            rdvoucherNaration.Checked,
                            ddlDocumentNo.SelectedValue == "0" ? "" : ddlDocumentNo.SelectedValue,
                            !string.IsNullOrEmpty(txtFromDate.Text) ? txtFromDate.Text : "0D",
                            !string.IsNullOrEmpty(txtToDate.Text) ? txtToDate.Text : "0D",
                             ddlInstiuteCode.SelectedValue == "0" ? "" : ddlInstiuteCode.SelectedItem.Text,
                             ddlDepartment.SelectedValue == "0" ? "" : ddlDepartment.SelectedItem.Text,
                            Session["SessionCompanyName"] as string,
                            ddlCompany.SelectedItem.Text);
                }

                var FileName = reportName + ".pdf";
                string exportedFilePath = ConfigurationManager.AppSettings["ExportFilePath"].ToString() + StringHelper.GetFileNameFromURL(servicePath);
                WebClient wc = new WebClient();
                byte[] buffer = wc.DownloadData(exportedFilePath);
                var fileName = "attachment; filename=" + FileName;
                base.Response.ClearContent();
                base.Response.AddHeader("content-disposition", fileName);
                base.Response.ContentType = "application/pdf";
                base.Response.BinaryWrite(buffer);
                base.Response.End();
                ClearControls();
            }
            catch (Exception ex)
            {
                Alert.ShowAlert(this, "e", ex.Message);
            }


        }
        private void ClearControls()
        {
            ddlDocumentNo.ClearSelection();
            ddlDocumentNo.Items.FindByValue("0").Selected = true;
            ddlInstiuteCode.ClearSelection();
            ddlInstiuteCode.Items.FindByValue("0").Selected = true;
            ddlDepartment.ClearSelection();
            ddlDepartment.Items.FindByValue("0").Selected = true;
            rdLineNarration.Checked = false;
            rdvoucherNaration.Checked = false;
            txtFromDate.Text = "";
            txtToDate.Text = "";
        }
    }
}