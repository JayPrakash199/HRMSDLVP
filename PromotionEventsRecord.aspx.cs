using HRMS.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class PromotionEventsRecord : System.Web.UI.Page
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
                BindDesignation();
            }
        }
        private void BindDesignation()
        {
            var lstDesignation = ODataServices.GetDesignation(Session["SessionCompanyName"] as string);
            ddlDesignation.DataSource = lstDesignation;
            ddlDesignation.DataTextField = "Description";
            ddlDesignation.DataValueField = "Code";
            ddlDesignation.DataBind();
            ddlDesignation.Items.Insert(0, new ListItem("Select Designation", "0"));
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Add Promotion Record", StringComparison.OrdinalIgnoreCase)
                && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));
            if (role == null)
            {
                SearchData();
            }
            else
            {
                if (!Convert.ToBoolean(role.Read))
                {
                    Alert.ShowAlert(this, "W",
                        "You do not have permission to read the content. Kindly contact the system administrator.");
                    return;
                }
                SearchData();
            }

        }

        private void SearchData()
        {
            var employeeResult = ODataServices.GetEmployeeInfo(txtHRMSIDSearch.Text, Session["SessionCompanyName"] as string);
            if (employeeResult != null)
            {
                txtEmployeeName.Text = employeeResult.First_Name;
                txtDesignation.Text = employeeResult.Designation;
                txtFromDesignation.Text = employeeResult.Designation;
                LblMessage.Text = string.Empty;
            }
            else
            {
                txtEmployeeName.Text = string.Empty;
                txtDesignation.Text = string.Empty;
                LblMessage.Text = "No record found. Try searching with valid HRMS ID.";
            }
        }

        protected void btnEstimateSubmit_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Add Promotion Record", StringComparison.OrdinalIgnoreCase)
                && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));
            if (role == null)
            {
                AddPromotionalRecord();
            }
            else
            {
                if (!Convert.ToBoolean(role.Insert))
                {
                    Alert.ShowAlert(this, "W",
                        "You do not have permission to insert the data. Kindly contact the system administrator.");
                    return;
                }
                AddPromotionalRecord();
            }
        }

        private void AddPromotionalRecord()
        {
            var obj = new WebServices.EmployeePromotionHistoryReference.EmployeePromotionHistoryCard
            {
                Promotion_Order_DateSpecified = true,
                Order_Issuing_AuthoritySpecified = true,

                HRMS_ID = txtHRMSIDSearch.Text,
                Employee_Name = txtEmployeeName.Text,
                From_Designation = txtFromDesignation.Text,
                To_Designation = ddlDesignation.SelectedValue,
                Promotion_Order_Date = DateTimeParser.ParseDateTime(txtPromotionOrderDate.Text),
                Letter_NO = txtLetterNo.Text,
                Order_Issuing_Authority = ddlPromotionOrderIssuingAuthority.SelectedItem.Text == "DTET"
                    ? WebServices.EmployeePromotionHistoryReference.Order_Issuing_Authority.DTE_x0026_T
                    : ddlPromotionOrderIssuingAuthority.SelectedItem.Text == "SDTE"
                        ? WebServices.EmployeePromotionHistoryReference.Order_Issuing_Authority.SDTE
                        : WebServices.EmployeePromotionHistoryReference.Order_Issuing_Authority.Principal
            };
            var resultMessage = SOAPServices.AddEmployeePromotionHistoryRecord(obj, Session["SessionCompanyName"] as string);
            //if (resultMessage == ResultMessages.SuccessfullMessage)
            //{
            //    if (this.pdfUploader.HasFile)
            //    {
            //        string fileExtention = Path.GetExtension(this.pdfUploader.FileName);
            //        string finalFileName = Path.GetFileNameWithoutExtension(this.pdfUploader.FileName.Substring(0, 10)) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
            //        string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
            //        if (!Directory.Exists(path))
            //            Directory.CreateDirectory(path);
            //        if (Directory.Exists(path))
            //        {
            //            path = Path.Combine(path, finalFileName);
            //            this.pdfUploader.SaveAs(path);
            //        }
            //        string servicePath = ConfigurationManager.AppSettings["PdfPath"].ToString() + finalFileName;
            //        //ODataServices.ImportLandFile(servicePath);
            //    }
            //    Alert.ShowAlert(this, "s", resultMessage);
            //}
            Alert.ShowAlert(this, "s", resultMessage);
        }
    }
}