using HRMS.Common;
using Microsoft.Ajax.Utilities;
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
    public partial class CustomerStatement : System.Web.UI.Page
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
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Customer Statement", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Accounts", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Read))
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(ddlStudentNo.SelectedValue))
                        {
                            var servicePath = SOAPServices.GetCustomerStatement(
                               ddlStudentNo.SelectedItem.Value != "0" ? ddlStudentNo.SelectedItem.Value : "",
                                !string.IsNullOrEmpty(txtStartDate.Text) ? txtStartDate.Text : "0D",
                                !string.IsNullOrEmpty(txtEndDate.Text) ? txtEndDate.Text : "0D",
                                 rdshowOverDueEntries.Checked,
                                 rdShowAllcustomerLedger.Checked,
                                 rdCustomerbalance.Checked,
                                 rdShowReverseEntity.Checked,
                                 rdShowUnappliedEntity.Checked,
                                 rdShowAgingBand.Checked,
                                 !string.IsNullOrEmpty(txtperiodLength.Text) ? txtperiodLength.Text : "",
                                 Convert.ToInt32(ddlagingbandBy.SelectedItem.Value),
                                 rdlogInteraction.Checked,
                                 Session["SessionCompanyName"] as string);

                            var FileName = "Customer-Statement.pdf";
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
    }
}