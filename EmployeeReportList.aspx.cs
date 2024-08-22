using HRMS.Common;
using HRMSODATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices;
using WebServices.EmplaoyeeReference;

namespace HRMS
{
    public partial class EmployeeReportList : System.Web.UI.Page
    {
        IList<HRMSODATA.EmployeeList> employeeList = null;

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

            if (!string.IsNullOrEmpty(companyName))
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




            //if (!string.IsNullOrEmpty(companyName))
            //{
            //    employeeList = employeeList.Where(x => x.D_O_S == companyName).ToList();
            //}
            if (!string.IsNullOrEmpty(dosj_to))
            {
                employeeList = employeeList.Where(x => x.D_O_S == (DateTime.Parse(dosj_to.ToString()))).ToList();
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
        }
        private void BindCompany()
        {
            var companyList = ODataServices.GetCompanyList();
            ddlInstituteName.DataSource = companyList;
            ddlInstituteName.DataTextField = "Name";
            ddlInstituteName.DataValueField = "Name";
            ddlInstituteName.DataBind();
            ddlInstituteName.Items.Insert(0, new ListItem("Select company", "0"));
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
                    HttpContext.Current.Session["SessionCompanyName"] = "firstname";
                    lstOutput = employeeList.Select(employee => employee.First_Name).ToList();
                    break;
                case "idLastName": // Last Name
                    HttpContext.Current.Session["SessionCompanyName"] = "lastname";
                    lstOutput = employeeList.Select(employee => employee.Last_Name34464).ToList();
                    break;
            }


            // Return filtered HRMS IDs based on the prefix
            return lstOutput.Where(id => id.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)).ToList();
        }


    }

}