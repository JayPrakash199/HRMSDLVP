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
    public partial class Fee_MoneyReceipt : System.Web.UI.Page
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
                BindStudentDropDownList();
                BindDocumentDropDownList();
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
        public void BindDocumentDropDownList()
        {
            var list = ODataServices.GetDocumentData(Session["SessionCompanyName"] as string);
            var data = list.Where(x => string.Equals(x.Customer_No, ddlStudentNo.SelectedValue, StringComparison.OrdinalIgnoreCase)
            && string.Equals(x.Document_Type.ToLower(), "payment", StringComparison.OrdinalIgnoreCase)).ToList();

            var DcList = new List<DocumentList>();

            foreach (var dc in data)
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
        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlStudentNo.SelectedValue))
            {
                var servicePath = SOAPServices.GetMoneyReceipt(ddlStudentNo.SelectedValue,
                                                                Session["SessionCompanyName"] as string, ddlDocumentNo.SelectedValue);

                var FileName = "Money-Receipt.pdf";
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

        protected void ddlStudentNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDocumentDropDownList();
        }
    }
}