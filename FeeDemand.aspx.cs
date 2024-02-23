using HRMS.Common;
using HRMSODATA;
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
    public partial class FeeDemand : System.Web.UI.Page
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
                if (lstUserRole != null)
                {
                    var role = lstUserRole.FirstOrDefault(x =>
                        string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                        string.Equals(x.Page_Name.Trim(), "Course Fee Header List", StringComparison.OrdinalIgnoreCase) &&
                        string.Equals(x.Module_Name.Trim(), "Accounts", StringComparison.OrdinalIgnoreCase));

                    if (role == null || Convert.ToBoolean(role.Read))
                    {
                        BindStudentDropDownList();
                        BindFianacialYear();
                        BindDocumentDropDownList();
                    }
                    else
                    {
                        Alert.ShowAlert(this, "W", "You do not have permission to read the content. Kindly contact the system administrator.");
                        
                    }
                }
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
            {
                var list = ODataServices.GetDocumentData(Session["SessionCompanyName"] as string);
                var data = list.Where(x => string.Equals(x.Customer_No, ddlStudentNo.SelectedValue, StringComparison.OrdinalIgnoreCase)
                && string.Equals(x.Document_Type.ToLower(), "invoice", StringComparison.OrdinalIgnoreCase)
                && string.Equals(x.Academic_Year, ddlacademicYear.SelectedItem.Text, StringComparison.OrdinalIgnoreCase)
                ).ToList();

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
                    string.Equals(x.Page_Name.Trim(), "Fee Demand", StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Module_Name.Trim(), "Accounts", StringComparison.OrdinalIgnoreCase));

                    if (role == null || Convert.ToBoolean(role.Read))
                    {
                        if (!string.IsNullOrEmpty(ddlacademicYear.SelectedItem.Text) &&
                    !string.IsNullOrEmpty(ddlStudentNo.SelectedValue) &&
                    !string.IsNullOrEmpty(ddlDocumentNo.SelectedItem.Text))
                        {
                            var servicePath = SOAPServices.GetFeeDemand(ddlacademicYear.SelectedItem.Text,
                                                                        ddlStudentNo.SelectedValue,
                                                                        ddlDocumentNo.SelectedValue,
                                                                        Session["SessionCompanyName"] as string);
                            var FileName = "Fee-Demand.pdf";
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
            ddlStudentNo.ClearSelection();
            ddlStudentNo.Items.FindByValue("0").Selected = true;
            ddlacademicYear.ClearSelection();
            ddlacademicYear.Items.FindByValue("0").Selected = true;
        }

        public void BindFianacialYear()
        {
            var FyList = ODataServices.GetFinancialYearList(Session["SessionCompanyName"] as string);

            ddlacademicYear.DataSource = FyList;
            ddlacademicYear.DataTextField = "Financial_Code";
            ddlacademicYear.DataValueField = "Financial_Code";
            ddlacademicYear.DataBind();
            ddlacademicYear.Items.Insert(0, new ListItem("Select Year", "0"));
        }


        protected void ddlStudentNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDocumentDropDownList();
        }

    }




    public class DocumentList
    {

        public string DocumentNo { get; set; }
        public string DocumentName { get; set; }
    }
}