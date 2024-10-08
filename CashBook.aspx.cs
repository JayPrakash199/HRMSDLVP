﻿using HRMS.Common;
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
    public partial class CashBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGlNo();
                ShowDimentation();
            }
        }

        public void BindGlNo()
        {
            var glAccounts = ODataServices.GetChartofAccounts(Session["SessionCompanyName"] as string);
            var finalAccounts = new List<CommonList>();
            foreach (var account in glAccounts)
            {
                finalAccounts.Add(new HRMS.CommonList { No = account.No, Name = account.No + "_" + account.Name });
            }
            ddlGlNo.DataSource = finalAccounts;
            ddlGlNo.DataTextField = "Name";
            ddlGlNo.DataValueField = "No";
            ddlGlNo.DataBind();
            ddlGlNo.Items.Insert(0, new ListItem("Select GL no", "0"));

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

            foreach (var dimension in departmentList)
            {
                lstDpt.Add(new HRMS.Dimension { Name = dimension.Code + "_" + dimension.Name, Code = dimension.Code });
            }
            ddlDepartment.DataSource = lstDpt;
            ddlDepartment.DataTextField = "Name";
            ddlDepartment.DataValueField = "Code";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("Select Department", "0"));
        }

        private void BindInstitute(IList<DimValueList> dimensionList)
        {
            var instituteList = dimensionList.Where(x => string.Equals("INSTITUTE", x.Dimension_Code, StringComparison.OrdinalIgnoreCase)).ToList();
            var lstInstitute = new List<Dimension>();

            foreach (var dimension in instituteList)
            {
                lstInstitute.Add(new HRMS.Dimension { Name = dimension.Code + "_" + dimension.Name, Code = dimension.Code });
            }

            ddlInstiuteCode.DataSource = lstInstitute;
            ddlInstiuteCode.DataTextField = "Name";
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
                    string.Equals(x.Page_Name.Trim(), "Cash Book Report", StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Module_Name.Trim(), "Accounts", StringComparison.OrdinalIgnoreCase));

                    if (role == null || Convert.ToBoolean(role.Read))
                    {

                        try
                        {
                            if (string.IsNullOrEmpty(txtFromDate.Text) && !string.IsNullOrEmpty(txtToDate.Text)
                               || !string.IsNullOrEmpty(txtFromDate.Text) && string.IsNullOrEmpty(txtToDate.Text))
                            {
                                Alert.ShowAlert(this, "e", "plese select both from date and to date");
                                return;
                            }
                            string institutecode = ddlInstiuteCode.SelectedValue != "0"
                                  ? ddlInstiuteCode.SelectedItem.Text.Trim().Substring(0, ddlInstiuteCode.SelectedItem.Text.Trim().IndexOf('_')) : "";
                            string deptcode = ddlDepartment.SelectedValue != "0"
                                ? ddlDepartment.SelectedItem.Text.Trim().Substring(0, ddlDepartment.SelectedItem.Text.Trim().IndexOf('_')) : "";


                            var servicePath = SOAPServices.GetCashBookReport(
                                        rdPrintDetails.Checked,
                                        rdLineNarration.Checked,
                                        rdvoucherNaration.Checked,
                                        ddlGlNo.SelectedValue == "0" ? "" : ddlGlNo.SelectedValue,
                                         !string.IsNullOrEmpty(txtFromDate.Text) ? txtFromDate.Text : "0D",
                                        !string.IsNullOrEmpty(txtToDate.Text) ? txtToDate.Text : "0D",
                                          ddlInstiuteCode.SelectedValue == "0" ? "" : institutecode,
                                         ddlDepartment.SelectedValue == "0" ? "" : deptcode,
                                        Session["SessionCompanyName"] as string);

                            var FileName = "Cash_Book_Report.pdf";
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
                            if (ex.Message.Contains("404"))
                            {
                                Alert.ShowAlert(this, "e", "Report is empty");
                            }
                            else
                            {
                                Alert.ShowAlert(this, "e", ex.Message);
                            }
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
            ddlGlNo.ClearSelection();
            ddlGlNo.Items.FindByValue("0").Selected = true;
            ddlInstiuteCode.ClearSelection();
            ddlInstiuteCode.Items.FindByValue("0").Selected = true;
            ddlDepartment.ClearSelection();
            ddlDepartment.Items.FindByValue("0").Selected = true;
            rdLineNarration.Checked = false;
            rdvoucherNaration.Checked = false;
            rdPrintDetails.Checked = false;
            txtFromDate.Text = "";
            txtToDate.Text = "";
        }
    }
}