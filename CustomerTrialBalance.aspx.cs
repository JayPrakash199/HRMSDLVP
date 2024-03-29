﻿using HRMS.Common;
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
    public partial class CustomerTrialBalance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindStudentDropDownList();
            }

        }
        public void BindStudentDropDownList()
        {
            var studentList = ODataServices.GetCustomerList(Session["SessionCompanyName"] as string);
            var finalStudentList = new List<CommonList>();

            foreach (var student in studentList)
            {
                finalStudentList.Add(new HRMS.CommonList { No = student.No, Name = student.No + "_" + student.Name });
            }

            ddlStudentNo.DataSource = finalStudentList;
            ddlStudentNo.DataTextField = "Name";
            ddlStudentNo.DataValueField = "No";
            ddlStudentNo.DataBind();
            ddlStudentNo.Items.Insert(0, new ListItem("Select Student", "0"));
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
                    string.Equals(x.Page_Name.Trim(), "Customer Trial Balance", StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Module_Name.Trim(), "Accounts", StringComparison.OrdinalIgnoreCase));

                    if (role == null || Convert.ToBoolean(role.Read))
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(ddlStudentNo.SelectedValue))
                            {
                                var servicePath = SOAPServices.GetCustomerTrialBalanceReport(
                                    ddlStudentNo.SelectedItem.Value != "0" ? ddlStudentNo.SelectedItem.Value : "",
                                     rdPrintAmtInLCY.Checked,
                                     rdPrintOnlyOnePerPage.Checked,
                                     rdExcludeBalanceOnly.Checked,
                                     Session["SessionCompanyName"] as string);

                                var FileName = "Customer_Trial_Balance-Report.pdf";
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
                        }
                        catch (Exception ex)
                        {
                            Alert.ShowAlert(this, "e", ex.Message.ToString());
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
            rdPrintAmtInLCY.Checked = false;
            rdExcludeBalanceOnly.Checked = false;
            rdExcludeBalanceOnly.Checked = false;
            ddlStudentNo.ClearSelection();
            ddlStudentNo.Items.FindByValue("0").Selected = true;
        }
    }
}