using HRMS.Common;
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
                }
            }
            catch (Exception ex)
            {
                Alert.ShowAlert(this, "e", ex.Message.ToString());
            }
        }
    }
}