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
    public partial class DayBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDocumentDropDownList();
                ShowDimentation();
            }

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
        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (!((Fee)this.Master).IsPageRefresh)
            {
                List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Day Book", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Accounts", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Read))
                {

                    try
                    {
                        if (string.IsNullOrEmpty(txtFromDate.Text) && !string.IsNullOrEmpty(txtToDate.Text)
                           || !string.IsNullOrEmpty(txtFromDate.Text) && string.IsNullOrEmpty(txtToDate.Text))
                        {
                            Alert.ShowAlert(this, "e", "plese select both From Date and To Date");
                            return;
                        }

                        var servicePath = SOAPServices.GetDayBookReport(
                                    rdLineNarration.Checked,
                                    rdvoucherNaration.Checked,
                                    ddlDocumentNo.SelectedValue == "0" ? "" : ddlDocumentNo.SelectedValue,
                                    !string.IsNullOrEmpty(txtFromDate.Text) ? txtFromDate.Text : "0D",
                                    !string.IsNullOrEmpty(txtToDate.Text) ? txtToDate.Text : "0D",
                                     ddlInstiuteCode.SelectedValue == "0" ? "" : ddlInstiuteCode.SelectedItem.Text,
                                     ddlDepartment.SelectedValue == "0" ? "" : ddlDepartment.SelectedItem.Text,
                                    Session["SessionCompanyName"] as string);

                        var FileName = "Day_Book_Report.pdf";
                        string exportedFilePath = ConfigurationManager.AppSettings["ExportFilePath"].ToString() + StringHelper.GetFileNameFromURL(servicePath);
                        WebClient wc = new WebClient();
                        byte[] buffer = wc.DownloadData(exportedFilePath);
                        var fileName = "attachment; filename=" + FileName;
                        base.Response.ClearContent();
                        base.Response.AddHeader("content-disposition", fileName);
                        base.Response.ContentType = "application/pdf";
                        base.Response.BinaryWrite(buffer);
                        base.Response.End();
                    }
                    catch (Exception ex)
                    {
                        Alert.ShowAlert(this, "e", ex.Message);
                    }

                }
                else
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to export the content. Kindly contact the system administrator.");
                    
                }
            }
            }
            else
            {
                ClearControls();
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