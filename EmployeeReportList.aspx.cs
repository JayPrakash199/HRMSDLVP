using BotDetect.C5;
using HRMS.Common;
using HRMSODATA;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices;
using WebServices.EmplaoyeeReference;
using ListItem = System.Web.UI.WebControls.ListItem;

namespace HRMS
{
    public partial class EmployeeReportList : System.Web.UI.Page
    {
        System.Collections.Generic.IList<HRMSODATA.EmployeeList> employeeList = null;

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
                BindTrade();
                BindStation();
                BindCompany();
                BindCategoryDropdown();
            }
        }
        private void BindListView()
        {
            var lstEmployee = ODataServices.GetEmployeeList(Session["SessionCompanyName"] as string);
            EmployeeListView.DataSource = lstEmployee;
            EmployeeListView.DataBind();
        }
        private void BindStation()
        {
            var stations = ODataServices.GetStationList(Session["SessionCompanyName"] as string);
            if (stations != null && stations.Count > 0)
            {
                ddlCurrentStation.DataSource = stations;
                ddlCurrentStation.DataTextField = "Institute_Name";
                ddlCurrentStation.DataValueField = "Institute_Code";
                ddlCurrentStation.DataBind();
                ddlCurrentStation.Items.Insert(0, new ListItem("Select Current Station", "0"));
            }
        }

        private void BindTrade()
        {
            var trades = ODataServices.GetDepartmentTradeSections(Session["SessionCompanyName"] as string);
            if (trades != null && trades.Count > 0)
            {
                ddlTrade.DataSource = trades;
                ddlTrade.DataTextField = "Departments_Trades_Section";
                ddlTrade.DataValueField = "Entry_No";
                ddlTrade.DataBind();
                ddlTrade.Items.Insert(0, new ListItem("Select Trade", "0"));
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

            ddlServiceJoiningDesignation.DataSource = lstDesignation;
            ddlServiceJoiningDesignation.DataTextField = "Description";
            ddlServiceJoiningDesignation.DataValueField = "Code";
            ddlServiceJoiningDesignation.DataBind();
            ddlServiceJoiningDesignation.Items.Insert(0, new ListItem("Select Designation", "0"));

        }

        private void BindCategoryDropdown()
        {
            // Get the enum values, excluding the _blank_ value
            var categories = Enum.GetValues(typeof(Category))
                                  .Cast<Category>()
                                  .Where(c => c != Category._blank_);

            // Clear existing items
            ddlCategory.Items.Clear();

            // Add default item if needed
            ddlCategory.Items.Add(new ListItem("Select Category", ""));

            // Add enum items to the dropdown list
            foreach (Category category in categories)
            {
                ddlCategory.Items.Add(new ListItem(category.ToString(), category.ToString()));
            }
        }

        protected void btnEmployeeFilter_Click(object sender, EventArgs e)
        {
            var companyName = ddlInstituteName.SelectedIndex == 0 ? "" : ddlInstituteName.SelectedValue;
            if (ddlInstituteType.SelectedIndex != 0)
            {
                employeeList = GetEmployeeByInstituteType(ddlInstituteType.SelectedValue);
            }
            else if (!string.IsNullOrEmpty(companyName))
            {
                employeeList = ODataServices.GetEmployeeList(System.Web.HttpUtility.UrlPathEncode(ddlInstituteName.SelectedItem.Text));
            }
            else
            {
                employeeList = ODataServices.GetEmployeeList(Session["SessionCompanyName"] as string);
            }

            var dosj_to = txtdosjto.Text;
            var hrmsId = txtHrmsId.Text;
            var dosfrom = txtdosfrom.Text;
            var dosTo = txtdosto.Text;
            var designation = ddlDesignation.SelectedIndex == 0 ? "" : ddlDesignation.SelectedValue;
            var trade = ddlTrade.SelectedIndex == 0 ? "" : ddlTrade.SelectedItem.Text;
            var postGrup = ddlPostGroup.SelectedIndex == 0 ? "" : ddlPostGroup.SelectedValue;
            var grossPay = txtGrossPay.Text;
            var pensionremark = ddlPensionRemark.SelectedIndex == 0 ? "" : ddlPensionRemark.SelectedItem.Text;

            var dosj_from = txtDosjfrom.Text;
            var acounttype = ddlAccountType.SelectedIndex == 0 ? "" : ddlAccountType.Text;
            var serviceJoiningDesg = ddlServiceJoiningDesignation.SelectedIndex == 0 ? "" : ddlServiceJoiningDesignation.SelectedValue;
            var gender = ddlGender.SelectedIndex == 0 ? "" : ddlGender.SelectedValue;
            var currentStation = ddlCurrentStation.SelectedIndex == 0 ? "" : ddlCurrentStation.SelectedValue;
            var employMentStatus = ddlEmplyomentStatus.SelectedIndex == 0 ? "" : ddlEmplyomentStatus.SelectedItem.Text;
            var macpStatus = ddlMACPStatus.SelectedIndex == 0 ? "" : ddlMACPStatus.SelectedValue;
            var selectedCategoryValue = ddlCategory.SelectedIndex == 0 ? "" : ddlCategory.SelectedValue;

            var deploymentStartdate = txtDeploymentStartDate.Text;
            var deploymentEndDate = txtDeploymentEndDate.Text;


            //if (!string.IsNullOrEmpty(companyName))
            //{
            //    employeeList = employeeList.Where(x => x.D_O_S == companyName).ToList();
            //}
            if (!string.IsNullOrEmpty(dosj_to))
            {
                employeeList = employeeList.Where(x => x.D_O_S == (DateTime.Parse(dosj_to.ToString()))).ToList();
            }

            if (!string.IsNullOrEmpty(deploymentStartdate))
            {
                employeeList = employeeList.Where(x => x.Deployment_Start_Date == (DateTime.Parse(deploymentStartdate.ToString()))).ToList();
            }
            if (!string.IsNullOrEmpty(deploymentEndDate))
            {
                employeeList = employeeList.Where(x => x.Deployment_End_Date == (DateTime.Parse(deploymentEndDate.ToString()))).ToList();
            }

            if (!string.IsNullOrEmpty(dosfrom) && !string.IsNullOrEmpty(dosTo))
            {
                DateTime fromDate = DateTime.Parse(dosfrom);
                DateTime toDate = DateTime.Parse(dosTo);

                employeeList = employeeList
                    .Where(x => x.D_O_S >= fromDate && x.D_O_S <= toDate)
                    .ToList();
            }

            if (!string.IsNullOrEmpty(hrmsId))
            {
                string EmployeeFilterName = Session["EmployeeFilterName"] as string;

                switch (EmployeeFilterName)
                {
                    case "hrms": // HRMS Id
                        employeeList = employeeList.Where(x => x.No == hrmsId).ToList();
                        break;
                    case "firstname": // First Name
                        employeeList = employeeList.Where(x => x.First_Name == hrmsId).ToList();
                        break;
                    case "lastname": // Last Name
                        employeeList = employeeList.Where(x => x.Last_Name34464 == hrmsId).ToList();
                        break;
                }
            }
            if (!string.IsNullOrEmpty(designation))
            {
                employeeList = employeeList.Where(x => x.Designation == designation).ToList();
            }
            if (!string.IsNullOrEmpty(trade))
            {
                employeeList = employeeList.Where(x => x.Dept_Trade_Section == trade).ToList();
            }
            if (!string.IsNullOrEmpty(postGrup))
            {
                employeeList = employeeList.Where(x => x.Post_Group == postGrup).ToList();
            }
            if (!string.IsNullOrEmpty(grossPay))
            {
                employeeList = employeeList.Where(x => x.Basic_Gr_Pay == Convert.ToDecimal(grossPay)).ToList();
            }
            if (!string.IsNullOrEmpty(pensionremark))
            {
                employeeList = employeeList.Where(x => x.Pension_Remark == pensionremark).ToList();
            }
            if (!string.IsNullOrEmpty(dosj_from))
            {
                employeeList = employeeList.Where(x => x.D_O_J_Service == (DateTime.Parse(dosj_from.ToString()))).ToList();
            }

            if (!string.IsNullOrEmpty(acounttype))
            {
                employeeList = employeeList.Where(x => x.Account_Type == acounttype).ToList();
            }

            if (!string.IsNullOrEmpty(serviceJoiningDesg))
            {
                employeeList = employeeList.Where(x => x.Service_Joining_Designation == serviceJoiningDesg).ToList();
            }
            if (!string.IsNullOrEmpty(gender))
            {
                employeeList = employeeList.Where(x => x.Gender == gender).ToList();
            }
            if (!string.IsNullOrEmpty(currentStation))
            {
                employeeList = employeeList.Where(x => x.Current_Station == currentStation).ToList();
            }
            if (!string.IsNullOrEmpty(employMentStatus))
            {
                employeeList = employeeList.Where(x => x.Employment_Status == employMentStatus).ToList();
            }
            if (!string.IsNullOrEmpty(macpStatus))
            {
                employeeList = employeeList.Where(x => x.MACP_Status == macpStatus).ToList();
            }
            if (!string.IsNullOrEmpty(selectedCategoryValue))
            {
                employeeList = employeeList.Where(x => x.Category == selectedCategoryValue).ToList();
            }


            EmployeeListView.DataSource = employeeList;
            EmployeeListView.DataBind();
            ViewState["isCompanySelected"] = false;
            Session["employeeList"] = employeeList;
        }

        private System.Collections.Generic.IList<HRMSODATA.EmployeeList> GetEmployeeByInstituteType(string instituteType)
        {
            var companyList = ODataServices.GetStationList("");
            companyList = companyList.Where(x => x.Institute_Type == instituteType).ToList();
            List<HRMSODATA.EmployeeList> allEmployees = new List<HRMSODATA.EmployeeList>();
            foreach (var company in companyList)
            {
                if (!string.IsNullOrEmpty(company.Company_Name))
                {
                    try
                    {
                        // Call GetEmployeeList with the appropriate company name
                        var employees = ODataServices.GetEmployeeList(System.Web.HttpUtility.UrlPathEncode(company.Company_Name));

                        // Append the returned employees to the allEmployees list
                        allEmployees.AddRange(employees);
                    }
                    catch (Exception)
                    {
                    }
                }

            }
            return allEmployees;
        }

        private void BindCompany()
        {
            var directorLogin = Session["directorLogin"] != null && Convert.ToBoolean(Session["directorLogin"]);
            if (directorLogin)
            {
                var companyList = ODataServices.GetCompanyList();
                ddlInstituteName.DataSource = companyList;
                ddlInstituteName.DataTextField = "Name";
                ddlInstituteName.DataValueField = "Name";
                ddlInstituteName.DataBind();
                ddlInstituteName.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select company", "0"));
            }
            else
            {
                divInstituteName.Attributes.Add("style", "display:none;");
                divInstituteType.Attributes.Add("style", "display:none;");
            }
        }
        [WebMethod]
        public static List<string> GetHrmsIds(string prefix, int selectedIndex, string selectedValue, string filterType)
        {
            // Retrieve company name based on the selected index
            var companyName = selectedIndex == 0
                ? HttpContext.Current.Session["SessionCompanyName"] as string
                : selectedValue;

            var employeeList = ODataServices.GetEmployeeList(companyName);
            List<string> lstOutput = new List<string>();

            switch (filterType)
            {
                case "rdHrms": // HRMS Id
                    HttpContext.Current.Session["EmployeeFilterName"] = "hrms";
                    lstOutput = employeeList.Select(employee => employee.No).ToList();
                    break;
                case "rdFirstName": // First Name
                    HttpContext.Current.Session["EmployeeFilterName"] = "firstname";
                    lstOutput = employeeList.Select(employee => employee.First_Name).ToList();
                    break;
                case "idLastName": // Last Name
                    HttpContext.Current.Session["EmployeeFilterName"] = "lastname";
                    lstOutput = employeeList.Select(employee => employee.Last_Name34464).ToList();
                    break;
            }


            // Return filtered HRMS IDs based on the prefix
            return lstOutput.Where(id => id.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        private void ExportListViewToExcel(ListView listView, string fileName)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            // Create a table to hold the ListView data
            Table table = new Table();
            TableRow headerRow = new TableRow();

            string[] headers = new string[]
            {
                "HRMS ID",
                "Name Of the Staff",
                "Bill Group",
                "Account Type",
                "Bill Type",
                "Designation",
                "Service Joining Designation",
                "Dept./Trade/Section",
                "Post Group",
                "GPF/PRAN No.",
                "D.O.B",
                "Gender",
                "D.O.S",
                "Category",
                "Joining Station",
                "D.O.J(Service)",
                "Current Station",
                "Joining Designation",
                "Base Qualification",
                "Basic Gr. Pay",
                "Employment Status",
                "Date of Increment",
                "Email ID",
                "MACP Status",
                "EPIC No.",
                "Mobile No.",
                "Pension Remark",
                "Aadhaar No.",
                "Designation as per HRMS Site",
                "Home Dist as per HRMS Site",
                "Home Dist",
                "Status",
                "Deployment Start Date",
                "Deployment End Date"
            };

            // Add header cells to the header row
            foreach (string header in headers)
            {
                TableCell headerCell = new TableCell();
                headerCell.Text = header;
                headerRow.Cells.Add(headerCell);
            }
            table.Rows.Add(headerRow);


            // Add data rows to the table
            foreach (ListViewDataItem item in listView.Items)
            {
                TableRow dataRow = new TableRow();
                foreach (Control control in item.Controls)
                {
                    if (control is Label label)
                    {
                        TableCell tableCell = new TableCell();
                        tableCell.Text = label.Text;
                        dataRow.Cells.Add(tableCell);
                    }
                }
                table.Rows.Add(dataRow);
            }

            table.RenderControl(hw);

            // Write the rendered content to the response
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }


        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportListViewToExcel(EmployeeListView, "ExportEmployeeList.xls");
        }

        protected void btnExportpdf_Click(object sender, EventArgs e)
        {
            // TestExportEmployeeListToPdf();
            if (Session["employeeList"] != null)
            {
                System.Collections.Generic.IList<HRMSODATA.EmployeeList> employeeList = (System.Collections.Generic.IList<HRMSODATA.EmployeeList>)Session["employeeList"];
                if (employeeList.Count > 0)
                    ExportEmployeeListToPdf(employeeList);

            }
        }

        
        public void ExportEmployeeListToPdf(System.Collections.Generic.IList<HRMSODATA.EmployeeList> employeeList)
        {

            // Create a new PDF document
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                try
                {
                    PdfWriter.GetInstance(pdfDoc, memoryStream);
                    // Create a PDF writer instance bound to the PDF document and a FileStream

                    // Open the document to enable writing
                    pdfDoc.Open();

                    // Create a table with the appropriate number of columns
                    PdfPTable pdfTable = new PdfPTable(34); // Adjust the number of columns as needed

                    // Add headers
                    pdfTable.AddCell("HRMS ID");
                    pdfTable.AddCell("Name Of the Staff");
                    pdfTable.AddCell("Bill Group");
                    pdfTable.AddCell("Account Type");
                    pdfTable.AddCell("Bill Type");
                    pdfTable.AddCell("Designation");
                    pdfTable.AddCell("Service Joining Designation");
                    pdfTable.AddCell("Dept./Trade/Section");
                    pdfTable.AddCell("Post Group");
                    pdfTable.AddCell("GPF/PRAN No.");
                    pdfTable.AddCell("D.O.B");
                    pdfTable.AddCell("Gender");
                    pdfTable.AddCell("D.O.S");
                    pdfTable.AddCell("Category");
                    pdfTable.AddCell("Joining Station");
                    pdfTable.AddCell("D.O.J(Service)");
                    pdfTable.AddCell("Current Station");
                    pdfTable.AddCell("Joining Designation");
                    pdfTable.AddCell("Base Qualification");
                    pdfTable.AddCell("Basic Gr. Pay");
                    pdfTable.AddCell("Employment Status");
                    pdfTable.AddCell("Date of Increment");
                    pdfTable.AddCell("Email ID");
                    pdfTable.AddCell("MACP Status");
                    pdfTable.AddCell("EPIC No.");
                    pdfTable.AddCell("Mobile No.");
                    pdfTable.AddCell("Pension Remark");
                    pdfTable.AddCell("Aadhaar No.");
                    pdfTable.AddCell("Designation as per HRMS Site");
                    pdfTable.AddCell("Home Dist as per HRMS Site");
                    pdfTable.AddCell("Home Dist");
                    pdfTable.AddCell("Status");
                    pdfTable.AddCell("Deployment Start Date");
                    pdfTable.AddCell("Deployment End Date");

                    // Add the data rows
                    foreach (var employee in employeeList)
                    {
                        pdfTable.AddCell(employee.No);
                        pdfTable.AddCell(employee.First_Name);
                        pdfTable.AddCell(employee.Bill_Group);
                        pdfTable.AddCell(employee.Account_Type);
                        pdfTable.AddCell(employee.Bill_Type);
                        pdfTable.AddCell(employee.Designation);
                        pdfTable.AddCell(employee.Service_Joining_Designation);
                        pdfTable.AddCell(employee.Dept_Trade_Section);
                        pdfTable.AddCell(employee.Post_Group);
                        pdfTable.AddCell(employee.GPF_PRAN_No);
                        pdfTable.AddCell(employee.Birth_Date.ToString());
                        pdfTable.AddCell(employee.Gender);
                        pdfTable.AddCell(employee.D_O_S.ToString());
                        pdfTable.AddCell(employee.Category);
                        pdfTable.AddCell(employee.Joining_Station);
                        pdfTable.AddCell(employee.D_O_J_Service.ToString());
                        pdfTable.AddCell(employee.Current_Station);
                        pdfTable.AddCell(employee.Service_Joining_Designation);
                        pdfTable.AddCell(employee.Base_Qualification);
                        pdfTable.AddCell(employee.Basic_Gr_Pay.ToString());
                        pdfTable.AddCell(employee.Employment_Status);
                        pdfTable.AddCell(employee.Date_of_increment.ToString());
                        pdfTable.AddCell(employee.E_Mail);
                        pdfTable.AddCell(employee.MACP_Status);
                        pdfTable.AddCell(employee.EPIC_No);
                        pdfTable.AddCell(employee.Mobile_Phone_No);
                        pdfTable.AddCell(employee.Pension_Remark);
                        pdfTable.AddCell(employee.Aadhaar_No);
                        pdfTable.AddCell(employee.Designation_as_per_HRMS_Site);
                        pdfTable.AddCell(employee.Home_Dist_as_per_HRMS_Site);
                        pdfTable.AddCell(employee.Home_Dist);
                        pdfTable.AddCell(employee.Status);
                        pdfTable.AddCell(employee.Deployment_Start_Date.ToString());
                        pdfTable.AddCell(employee.Deployment_End_Date.ToString());
                    }

                    // Add the table to the document
                    pdfDoc.Add(pdfTable);
                    pdfDoc.Close();
                    byte[] bytes = memoryStream.ToArray();

                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.ContentType = "application/pdf";
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=EmployeeList.pdf");
                    HttpContext.Current.Response.OutputStream.Write(bytes, 0, bytes.Length);
                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
                catch (Exception ex)
                {
                    // Handle exceptions here (e.g., log the error or display a message)
                    throw new Exception("Error occurred while exporting to PDF: " + ex.Message);
                }
                finally
                {
                    // Close the document
                    pdfDoc.Close();
                }
            }
        }
    }

}