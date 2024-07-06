using HRMS.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class EmployeeList : System.Web.UI.Page
    {
        static IList<HRMSODATA.EmployeeList> employeeList = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
                if (lstUserRole != null)
                {
                    var role = lstUserRole
                        .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                        string.Equals(x.Page_Name.Trim(), "Employee List", StringComparison.OrdinalIgnoreCase)
                        && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));

                    if (role == null)
                    {
                        LoadEmployeeData();
                    }
                    else
                    {
                        if (!Convert.ToBoolean(role.Read))
                        {
                            Alert.ShowAlert(this, "W", "You do not have permission to read the content. Kindly contact the system administrator.");
                            return;
                        }
                        LoadEmployeeData();

                    }
                }
            }
        }

        private void LoadEmployeeData()
        {
            if (string.IsNullOrEmpty(Session["SessionCompanyName"] as string))
            {
                string message = string.Format("Message: {0}\\n\\n", "Please select a company");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
                Response.Redirect("Default.aspx");
            }

            employeeList = ODataServices.GetEmployeeList(Session["SessionCompanyName"] as string);
            EmployeeListView.DataSource = employeeList;
            EmployeeListView.DataBind();
            BindFilters(employeeList);
        }
        private void BindFilters(IList<HRMSODATA.EmployeeList> employeeList)
        {
            var HrmsNoList = employeeList.Select(x => x.No).Distinct().ToList();


            var chkHrmsFilter = (CheckBoxList)EmployeeListView.FindControl("chkHrmsFilter");
            if (chkHrmsFilter != null)
            {
                chkHrmsFilter.DataSource = HrmsNoList;
                chkHrmsFilter.DataBind();
            }

            // Bind Country Filter
            var countryList = employeeList.Select(x => x.First_Name).Distinct().ToList();
            var chkCountryFilter = (CheckBoxList)EmployeeListView.FindControl("chkFirstName");
            if (chkCountryFilter != null)
            {
                chkCountryFilter.DataSource = countryList;
                chkCountryFilter.DataBind();
            }

            var billGroupList = employeeList.Select(x => x.Bill_Group).Distinct().ToList();
            var chkBillGroupFilter = (CheckBoxList)EmployeeListView.FindControl("chkBillGroup");
            if (chkBillGroupFilter != null)
            {
                chkBillGroupFilter.DataSource = billGroupList;
                chkBillGroupFilter.DataBind();
            }

            var AccountTypeList = employeeList.Select(x => x.Account_Type).Distinct().ToList();
            var chkAcTypeFilter = (CheckBoxList)EmployeeListView.FindControl("chkAcType");
            if (chkAcTypeFilter != null)
            {
                chkAcTypeFilter.DataSource = AccountTypeList;
                chkAcTypeFilter.DataBind();
            }

            var BilTypeList = employeeList.Select(x => x.Bill_Type).Distinct().ToList();
            var chkBillTypeFilter = (CheckBoxList)EmployeeListView.FindControl("chkBillType");
            if (chkBillTypeFilter != null)
            {
                chkBillTypeFilter.DataSource = BilTypeList;
                chkBillTypeFilter.DataBind();
            }

            var DesignationList = employeeList.Select(x => x.Designation).Distinct().ToList();
            var chkDesignationFilter = (CheckBoxList)EmployeeListView.FindControl("chkDesignation");
            if (chkDesignationFilter != null)
            {
                chkDesignationFilter.DataSource = DesignationList;
                chkDesignationFilter.DataBind();
            }

            var SJDList = employeeList.Select(x => x.Service_Joining_Designation).Distinct().ToList();
            var chkSJDFilter = (CheckBoxList)EmployeeListView.FindControl("chkSJD");
            if (chkSJDFilter != null)
            {
                chkSJDFilter.DataSource = SJDList;
                chkSJDFilter.DataBind();
            }

            var TradeList = employeeList.Select(x => x.Dept_Trade_Section).Distinct().ToList();
            var chkTradeFilter = (CheckBoxList)EmployeeListView.FindControl("chkTrade");
            if (chkTradeFilter != null)
            {
                chkTradeFilter.DataSource = TradeList;
                chkTradeFilter.DataBind();
            }

            var PostGroupList = employeeList.Select(x => x.Post_Group).Distinct().ToList();
            var chkPostGroupFilter = (CheckBoxList)EmployeeListView.FindControl("chkPostGroup");
            if (chkPostGroupFilter != null)
            {
                chkPostGroupFilter.DataSource = PostGroupList;
                chkPostGroupFilter.DataBind();
            }

            var GPFList = employeeList.Select(x => x.GPF_PRAN_No).Distinct().ToList();
            var chkGPFFilter = (CheckBoxList)EmployeeListView.FindControl("chkGPF");
            if (chkGPFFilter != null)
            {
                chkGPFFilter.DataSource = GPFList;
                chkGPFFilter.DataBind();
            }

            var DOBList = employeeList.Select(x => x.Birth_Date).Distinct().ToList();
            var chkDOBFilter = (CheckBoxList)EmployeeListView.FindControl("chkDOB");
            if (chkDOBFilter != null)
            {
                chkDOBFilter.DataSource = DOBList;
                chkDOBFilter.DataBind();
            }

            var GenderList = employeeList.Select(x => x.Gender).Distinct().ToList();
            var chkGenderFilter = (CheckBoxList)EmployeeListView.FindControl("chkGender");
            if (chkGenderFilter != null)
            {
                chkGenderFilter.DataSource = GenderList;
                chkGenderFilter.DataBind();
            }

            var DOSList = employeeList.Select(x => x.D_O_S).Distinct().ToList();
            var chkDOSFilter = (CheckBoxList)EmployeeListView.FindControl("chkDOS");
            if (chkDOSFilter != null)
            {
                chkDOSFilter.DataSource = DOSList;
                chkDOSFilter.DataBind();
            }

            var CategoryList = employeeList.Select(x => x.Category).Distinct().ToList();
            var chkCategoryFilter = (CheckBoxList)EmployeeListView.FindControl("chkCategory");
            if (chkCategoryFilter != null)
            {
                chkCategoryFilter.DataSource = CategoryList;
                chkCategoryFilter.DataBind();
            }

            var JSList = employeeList.Select(x => x.Joining_Station).Distinct().ToList();
            var chkJSFilter = (CheckBoxList)EmployeeListView.FindControl("chkJS");
            if (chkJSFilter != null)
            {
                chkJSFilter.DataSource = JSList;
                chkJSFilter.DataBind();
            }

            var DOJServiceList = employeeList.Select(x => x.D_O_J_Service).Distinct().ToList();
            var chkDOJFilter = (CheckBoxList)EmployeeListView.FindControl("chkDOJ");
            if (chkDOJFilter != null)
            {
                chkDOJFilter.DataSource = DOJServiceList;
                chkDOJFilter.DataBind();
            }

            var CurrentStationList = employeeList.Select(x => x.Current_Station).Distinct().ToList();
            var chkCurrentStationFilter = (CheckBoxList)EmployeeListView.FindControl("chkCurrentStation");
            if (chkCurrentStationFilter != null)
            {
                chkCurrentStationFilter.DataSource = CurrentStationList;
                chkCurrentStationFilter.DataBind();
            }

            var JoiningDesignationList = employeeList.Select(x => x.Service_Joining_Designation).Distinct().ToList();
            var chkJoiningDesignationFilter = (CheckBoxList)EmployeeListView.FindControl("chkJoiningDesignation");
            if (chkJoiningDesignationFilter != null)
            {
                chkJoiningDesignationFilter.DataSource = JoiningDesignationList;
                chkJoiningDesignationFilter.DataBind();
            }

            var BaseQualificationList = employeeList.Select(x => x.Base_Qualification).Distinct().ToList();
            var chkBaseQualificationFilter = (CheckBoxList)EmployeeListView.FindControl("chkBaseQualification");
            if (chkBaseQualificationFilter != null)
            {
                chkBaseQualificationFilter.DataSource = BaseQualificationList;
                chkBaseQualificationFilter.DataBind();
            }

            var BasicPayList = employeeList.Select(x => x.Basic_Gr_Pay).Distinct().ToList();
            var chkBasicPayFilter = (CheckBoxList)EmployeeListView.FindControl("chkBasicPay");
            if (chkBasicPayFilter != null)
            {
                chkBasicPayFilter.DataSource = BasicPayList;
                chkBasicPayFilter.DataBind();
            }

            var EmploymentStatusList = employeeList.Select(x => x.Employment_Status).Distinct().ToList();
            var chkEmploymentStatusFilter = (CheckBoxList)EmployeeListView.FindControl("chkEmploymentStatus");
            if (chkEmploymentStatusFilter != null)
            {
                chkEmploymentStatusFilter.DataSource = EmploymentStatusList;
                chkEmploymentStatusFilter.DataBind();
            }

            var DateofIncrementList = employeeList.Select(x => x.Date_of_increment).Distinct().ToList();
            var chkDateofIncrementFilter = (CheckBoxList)EmployeeListView.FindControl("chkDateofIncrement");
            if (chkDateofIncrementFilter != null)
            {
                chkDateofIncrementFilter.DataSource = DateofIncrementList;
                chkDateofIncrementFilter.DataBind();
            }

            var EmailList = employeeList.Select(x => x.E_Mail).Distinct().ToList();
            var chkEmailFilter = (CheckBoxList)EmployeeListView.FindControl("chkEmail");
            if (chkEmailFilter != null)
            {
                chkEmailFilter.DataSource = EmailList;
                chkEmailFilter.DataBind();
            }

            var MacpList = employeeList.Select(x => x.MACP_Status).Distinct().ToList();
            var chkMACPFilter = (CheckBoxList)EmployeeListView.FindControl("chkMACP");
            if (chkMACPFilter != null)
            {
                chkMACPFilter.DataSource = MacpList;
                chkMACPFilter.DataBind();
            }

            var EpicNoList = employeeList.Select(x => x.EPIC_No).Distinct().ToList();
            var chkEPICFilter = (CheckBoxList)EmployeeListView.FindControl("chkEPIC");
            if (chkEPICFilter != null)
            {
                chkEPICFilter.DataSource = EpicNoList;
                chkEPICFilter.DataBind();
            }

            var MobileNoList = employeeList.Select(x => x.Mobile_Phone_No).Distinct().ToList();
            var chkMobileNoFilter = (CheckBoxList)EmployeeListView.FindControl("chkMobileNo");
            if (chkMobileNoFilter != null)
            {
                chkMobileNoFilter.DataSource = MobileNoList;
                chkMobileNoFilter.DataBind();
            }

            var PRList = employeeList.Select(x => x.Pension_Remark).Distinct().ToList();
            var chkPensionRemarkFilter = (CheckBoxList)EmployeeListView.FindControl("chkPensionRemark");
            if (chkPensionRemarkFilter != null)
            {
                chkPensionRemarkFilter.DataSource = PRList;
                chkPensionRemarkFilter.DataBind();
            }

            var AadharList = employeeList.Select(x => x.Aadhaar_No).Distinct().ToList();
            var chkAadhaarNoFilter = (CheckBoxList)EmployeeListView.FindControl("chkAadhaarNo");
            if (chkAadhaarNoFilter != null)
            {
                chkAadhaarNoFilter.DataSource = AadharList;
                chkAadhaarNoFilter.DataBind();
            }

            var HrmsDesgList = employeeList.Select(x => x.Designation_as_per_HRMS_Site).Distinct().ToList();
            var chkDesignationHRMSFilter = (CheckBoxList)EmployeeListView.FindControl("chkDesignationHRMS");
            if (chkDesignationHRMSFilter != null)
            {
                chkDesignationHRMSFilter.DataSource = HrmsDesgList;
                chkDesignationHRMSFilter.DataBind();
            }

            var HrmsHomeDistList = employeeList.Select(x => x.Home_Dist_as_per_HRMS_Site).Distinct().ToList();
            var chkHomeDistHrmsFilter = (CheckBoxList)EmployeeListView.FindControl("chkHomeDistHrms");
            if (chkHomeDistHrmsFilter != null)
            {
                chkHomeDistHrmsFilter.DataSource = HrmsHomeDistList;
                chkHomeDistHrmsFilter.DataBind();
            }

            var HomeDistList = employeeList.Select(x => x.Home_Dist).Distinct().ToList();
            var chkHomeDistFilter = (CheckBoxList)EmployeeListView.FindControl("chkHomeDist");
            if (chkHomeDistFilter != null)
            {
                chkHomeDistFilter.DataSource = HomeDistList;
                chkHomeDistFilter.DataBind();
            }

            var StatusList = employeeList.Select(x => x.Status).Distinct().ToList();
            var chkStatusFilter = (CheckBoxList)EmployeeListView.FindControl("chkStatus");
            if (chkStatusFilter != null)
            {
                chkStatusFilter.DataSource = StatusList;
                chkStatusFilter.DataBind();
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            var servicePath = SOAPServices.ExportEmployees(Session["SessionCompanyName"] as string);
            var FileName = "HRMSEmployees.XLS";
            string exportedFilePath = ConfigurationManager.AppSettings["ExportFilePath"].ToString() + StringHelper.GetFileNameFromURL(servicePath);
            WebClient wc = new WebClient();
            byte[] buffer = wc.DownloadData(exportedFilePath);
            var fileName = "attachment; filename=" + FileName;
            base.Response.ClearContent();
            base.Response.AddHeader("content-disposition", fileName);
            base.Response.ContentType = "application/vnd.ms-excel";
            base.Response.BinaryWrite(buffer);
            base.Response.End();

        }
       
        private void ApplyFilter()
        {
            var filteredData = employeeList.AsQueryable();

            // Apply Company Filter
            var chkHrmsFilter = (CheckBoxList)EmployeeListView.FindControl("chkHrmsFilter");
            HtmlGenericControl filterIcon = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (chkHrmsFilter != null)
            {
                var selectedCompanies = chkHrmsFilter.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedCompanies.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedCompanies.Contains(x.No));
                    filterIcon.Attributes["style"] = "color: red;";
                }
                else
                {
                    filterIcon.Attributes["style"] = "color: #fff;";
                }
            }

            // Apply Country Filter
            var chkFirstNameFilter = (CheckBoxList)EmployeeListView.FindControl("chkFirstName");
            if (chkFirstNameFilter != null)
            {
                var selectedCountries = chkFirstNameFilter.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedCountries.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedCountries.Contains(x.First_Name));
                }
            }

            var chkBillGroupFilter = (CheckBoxList)EmployeeListView.FindControl("chkBillGroup");
            HtmlGenericControl BillGroupfilterIcon = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (chkHrmsFilter != null)
            {
                var selectedBillGroup = chkBillGroupFilter.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedBillGroup.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedBillGroup.Contains(x.Bill_Group));
                    BillGroupfilterIcon.Attributes["style"] = "color: red;";
                }
                else
                {
                    BillGroupfilterIcon.Attributes["style"] = "color: #fff;";
                }
            }
            var chkAcType = (CheckBoxList)EmployeeListView.FindControl("chkAcType");
            HtmlGenericControl AcTypefilterIcon = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (chkAcType != null)
            {
                var selectedAcType = chkAcType.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedAcType.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedAcType.Contains(x.Account_Type));
                    AcTypefilterIcon.Attributes["style"] = "color: red;";
                }
                else
                {
                    AcTypefilterIcon.Attributes["style"] = "color: #fff;";
                }
            }

            var chkBillType = (CheckBoxList)EmployeeListView.FindControl("chkBillType");
            HtmlGenericControl filterIconBillType = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (chkBillType != null)
            {
                var selectedBillType = chkBillType.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedBillType.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedBillType.Contains(x.Bill_Type));
                    filterIconBillType.Attributes["style"] = "color: red;";
                }
                else
                {
                    filterIconBillType.Attributes["style"] = "color: #fff;";
                }
            }

            var chkDesignation = (CheckBoxList)EmployeeListView.FindControl("chkDesignation");
            HtmlGenericControl filterIconDesignation = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (chkDesignation != null)
            {
                var selectedDesignation = chkDesignation.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedDesignation.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedDesignation.Contains(x.Designation));
                    filterIconDesignation.Attributes["style"] = "color: red;";
                }
                else
                {
                    filterIconDesignation.Attributes["style"] = "color: #fff;";
                }
            }

            var chkSJD = (CheckBoxList)EmployeeListView.FindControl("chkSJD");
            HtmlGenericControl filterIconSJD = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (chkSJD != null)
            {
                var selectedSJD = chkSJD.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedSJD.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedSJD.Contains(x.Service_Joining_Designation));
                    filterIconSJD.Attributes["style"] = "color: red;";
                }
                else
                {
                    filterIconSJD.Attributes["style"] = "color: #fff;";
                }
            }

            var chkTrade = (CheckBoxList)EmployeeListView.FindControl("chkTrade");
            HtmlGenericControl filterIconTrade = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (chkTrade != null)
            {
                var selectedTrade = chkTrade.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedTrade.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedTrade.Contains(x.Dept_Trade_Section));
                    filterIconTrade.Attributes["style"] = "color: red;";
                }
                else
                {
                    filterIconTrade.Attributes["style"] = "color: #fff;";
                }
            }

            var chkPostGroup = (CheckBoxList)EmployeeListView.FindControl("chkPostGroup");
            HtmlGenericControl filterIconPostGroup = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (chkPostGroup != null)
            {
                var selectedPostGroup = chkPostGroup.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedPostGroup.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedPostGroup.Contains(x.Post_Group));
                    filterIconPostGroup.Attributes["style"] = "color: red;";
                }
                else
                {
                    filterIconPostGroup.Attributes["style"] = "color: #fff;";
                }
            }

            var PostGroup = (CheckBoxList)EmployeeListView.FindControl("PostGroup");
            HtmlGenericControl filterIconGPF = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (PostGroup != null)
            {
                var selectedGPF = PostGroup.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedGPF.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedGPF.Contains(x.GPF_PRAN_No));
                    filterIconGPF.Attributes["style"] = "color: red;";
                }
                else
                {
                    filterIconGPF.Attributes["style"] = "color: #fff;";
                }
            }

            var chkDOB = (CheckBoxList)EmployeeListView.FindControl("chkDOB");
            HtmlGenericControl filterIconDOB = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (chkDOB != null)
            {
                var selectedDOB = chkDOB.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedDOB.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedDOB.Contains(DateTime.Parse(x.Birth_Date.ToString()).ToString("d")));
                    filterIconDOB.Attributes["style"] = "color: red;";
                }
                else
                {
                    filterIconDOB.Attributes["style"] = "color: #fff;";
                }
            }

            var chkGender = (CheckBoxList)EmployeeListView.FindControl("chkGender");
            HtmlGenericControl filterIconGender = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (chkGender != null)
            {
                var selectedGender = chkGender.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedGender.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedGender.Contains(x.Gender));
                    filterIconGender.Attributes["style"] = "color: red;";
                }
                else
                {
                    filterIconGender.Attributes["style"] = "color: #fff;";
                }
            }

            var chkDOS = (CheckBoxList)EmployeeListView.FindControl("chkDOS");
            HtmlGenericControl filterIconDOS = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (chkDOS != null)
            {
                var selectedDOS = chkDOS.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedDOS.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedDOS.Contains(DateTime.Parse(x.D_O_J_Service.ToString()).ToString("d")));
                    filterIconDOS.Attributes["style"] = "color: red;";
                }
                else
                {
                    filterIconDOS.Attributes["style"] = "color: #fff;";
                }
            }

            var chkCategory = (CheckBoxList)EmployeeListView.FindControl("chkCategory");
            HtmlGenericControl filterIconCategory = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (chkCategory != null)
            {
                var selectedCategory = chkCategory.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedCategory.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedCategory.Contains(x.Category));
                    filterIconCategory.Attributes["style"] = "color: red;";
                }
                else
                {
                    filterIconCategory.Attributes["style"] = "color: #fff;";
                }
            }

            var chkJS = (CheckBoxList)EmployeeListView.FindControl("chkJS");
            HtmlGenericControl filterIconJS = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (chkJS != null)
            {
                var selectedJS = chkJS.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedJS.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedJS.Contains(x.Joining_Station));
                    filterIconJS.Attributes["style"] = "color: red;";
                }
                else
                {
                    filterIconJS.Attributes["style"] = "color: #fff;";
                }
            }

            var chkDOJ = (CheckBoxList)EmployeeListView.FindControl("chkDOJ");
            HtmlGenericControl filterIconDOJ = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (chkDOJ != null)
            {
                var selectedDOJ = chkDOJ.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedDOJ.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedDOJ.Contains(DateTime.Parse(x.D_O_J_Service.ToString()).ToString("d")));
                    filterIconDOJ.Attributes["style"] = "color: red;";
                }
                else
                {
                    filterIconDOJ.Attributes["style"] = "color: #fff;";
                }
            }

            var chkCurrentStation = (CheckBoxList)EmployeeListView.FindControl("chkCurrentStation");
            HtmlGenericControl filterIconCurrentStation = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (chkCurrentStation != null)
            {
                var selectedCurrentStation = chkCurrentStation.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedCurrentStation.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedCurrentStation.Contains(x.Current_Station));
                    filterIconCurrentStation.Attributes["style"] = "color: red;";
                }
                else
                {
                    filterIconCurrentStation.Attributes["style"] = "color: #fff;";
                }
            }

            var chkJoiningDesignation = (CheckBoxList)EmployeeListView.FindControl("chkJoiningDesignation");
            HtmlGenericControl filterIconJoiningDesignation = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (chkJoiningDesignation != null)
            {
                var selectedJoiningDesignation = chkJoiningDesignation.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedJoiningDesignation.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedJoiningDesignation.Contains(x.Service_Joining_Designation));
                    filterIconJoiningDesignation.Attributes["style"] = "color: red;";
                }
                else
                {
                    filterIconJoiningDesignation.Attributes["style"] = "color: #fff;";
                }
            }

            var chkBaseQualification = (CheckBoxList)EmployeeListView.FindControl("chkBaseQualification");
            HtmlGenericControl filterIconBaseQualification = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (chkBaseQualification != null)
            {
                var selectedBaseQualification = chkBaseQualification.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedBaseQualification.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedBaseQualification.Contains(x.Base_Qualification));
                    filterIconBaseQualification.Attributes["style"] = "color: red;";
                }
                else
                {
                    filterIconBaseQualification.Attributes["style"] = "color: #fff;";
                }
            }

            var chkBasicPay = (CheckBoxList)EmployeeListView.FindControl("chkBasicPay");
            HtmlGenericControl filterIconBasicPay = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (chkBasicPay != null)
            {
                var selectedBasicPay = chkBasicPay.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedBasicPay.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedBasicPay.Contains(x.Basic_Gr_Pay.ToString()));
                    filterIconBasicPay.Attributes["style"] = "color: red;";
                }
                else
                {
                    filterIconBasicPay.Attributes["style"] = "color: #fff;";
                }
            }

            var chkEmploymentStatus = (CheckBoxList)EmployeeListView.FindControl("chkEmploymentStatus");
            HtmlGenericControl filterIconEmploymentStatus = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (chkEmploymentStatus != null)
            {
                var selectedEmploymentStatus = chkEmploymentStatus.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedEmploymentStatus.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedEmploymentStatus.Contains(x.Employment_Status));
                    filterIconEmploymentStatus.Attributes["style"] = "color: red;";
                }
                else
                {
                    filterIconEmploymentStatus.Attributes["style"] = "color: #fff;";
                }
            }
            var chkDateofIncrement = (CheckBoxList)EmployeeListView.FindControl("chkDateofIncrement");
            HtmlGenericControl filterIconDateofIncrement = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (chkDateofIncrement != null)
            {
                var selectedDateofIncrement = chkDateofIncrement.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedDateofIncrement.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedDateofIncrement.Contains(x.Date_of_increment.ToString()));
                    filterIconDateofIncrement.Attributes["style"] = "color: red;";
                }
                else
                {
                    filterIconDateofIncrement.Attributes["style"] = "color: #fff;";
                }
            }
            var chkEmail = (CheckBoxList)EmployeeListView.FindControl("chkEmail");
            HtmlGenericControl filterIconchkEmail = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (chkEmail != null)
            {
                var selectedchkEmail = chkEmail.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedchkEmail.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedchkEmail.Contains(x.E_Mail));
                    filterIconchkEmail.Attributes["style"] = "color: red;";
                }
                else
                {
                    filterIconchkEmail.Attributes["style"] = "color: #fff;";
                }
            }

            var chkMACP = (CheckBoxList)EmployeeListView.FindControl("chkMACP");
            HtmlGenericControl filterIconMACP = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (chkMACP != null)
            {
                var selectedMACP = chkMACP.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedMACP.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedMACP.Contains(x.MACP_Status));
                    filterIconMACP.Attributes["style"] = "color: red;";
                }
                else
                {
                    filterIconMACP.Attributes["style"] = "color: #fff;";
                }
            }

            var chkEPIC = (CheckBoxList)EmployeeListView.FindControl("chkEPIC");
            HtmlGenericControl filterIconEPIC = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (chkEPIC != null)
            {
                var selectedEPIC = chkEPIC.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedEPIC.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedEPIC.Contains(x.EPIC_No));
                    filterIconEPIC.Attributes["style"] = "color: red;";
                }
                else
                {
                    filterIconEPIC.Attributes["style"] = "color: #fff;";
                }
            }

            var chkMobileNo = (CheckBoxList)EmployeeListView.FindControl("chkMobileNo");
            HtmlGenericControl filterIconMobileNo = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (chkMobileNo != null)
            {
                var selectedMobileNo = chkMobileNo.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedMobileNo.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedMobileNo.Contains(x.Mobile_Phone_No));
                    filterIconMobileNo.Attributes["style"] = "color: red;";
                }
                else
                {
                    filterIconMobileNo.Attributes["style"] = "color: #fff;";
                }
            }

            var chkPensionRemark = (CheckBoxList)EmployeeListView.FindControl("chkPensionRemark");
            HtmlGenericControl filterIconPensionRemark = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (chkPensionRemark != null)
            {
                var selectedPensionRemark = chkPensionRemark.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedPensionRemark.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedPensionRemark.Contains(x.Pension_Remark));
                    filterIconPensionRemark.Attributes["style"] = "color: red;";
                }
                else
                {
                    filterIconPensionRemark.Attributes["style"] = "color: #fff;";
                }
            }

            var chkAadhaarNo = (CheckBoxList)EmployeeListView.FindControl("chkAadhaarNo");
            HtmlGenericControl filterIconAadhaarNo = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (chkAadhaarNo != null)
            {
                var selectedAadhaarNo = chkAadhaarNo.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedAadhaarNo.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedAadhaarNo.Contains(x.Aadhaar_No));
                    filterIconAadhaarNo.Attributes["style"] = "color: red;";
                }
                else
                {
                    filterIconAadhaarNo.Attributes["style"] = "color: #fff;";
                }
            }

            var chkDesignationHRMS = (CheckBoxList)EmployeeListView.FindControl("chkDesignationHRMS");
            HtmlGenericControl filterIconDesignationHRMS = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (chkDesignationHRMS != null)
            {
                var selectedDesignationHRMS = chkDesignationHRMS.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedDesignationHRMS.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedDesignationHRMS.Contains(x.Designation_as_per_HRMS_Site));
                    filterIconDesignationHRMS.Attributes["style"] = "color: red;";
                }
                else
                {
                    filterIconDesignationHRMS.Attributes["style"] = "color: #fff;";
                }
            }

            var chkHomeDistHrms = (CheckBoxList)EmployeeListView.FindControl("chkHomeDistHrms");
            HtmlGenericControl filterIconHomeDIstHrms = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (chkHomeDistHrms != null)
            {
                var selectedHomeDIstHrms = chkHomeDistHrms.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedHomeDIstHrms.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedHomeDIstHrms.Contains(x.Home_Dist_as_per_HRMS_Site));
                    filterIconHomeDIstHrms.Attributes["style"] = "color: red;";
                }
                else
                {
                    filterIconHomeDIstHrms.Attributes["style"] = "color: #fff;";
                }
            }

           

            var chkHomeDist = (CheckBoxList)EmployeeListView.FindControl("chkHomeDist");
            HtmlGenericControl filterIconHomeDist = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (chkHomeDist != null)
            {
                var selectedHomeDist = chkHomeDist.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedHomeDist.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedHomeDist.Contains(x.Home_Dist_as_per_HRMS_Site));
                    filterIconHomeDist.Attributes["style"] = "color: red;";
                }
                else
                {
                    filterIconHomeDist.Attributes["style"] = "color: #fff;";
                }
            }

            var chkStatus = (CheckBoxList)EmployeeListView.FindControl("chkStatus");
            HtmlGenericControl filterIconStatus = (HtmlGenericControl)EmployeeListView.FindControl("filtericon");
            if (chkStatus != null)
            {
                var selectedStatus = chkStatus.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedStatus.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedStatus.Contains(x.Status));
                    filterIconStatus.Attributes["style"] = "color: red;";
                }
                else
                {
                    filterIconStatus.Attributes["style"] = "color: #fff;";
                }
            }
            BindListView(filteredData.ToList());
        }
        private void BindListView(IList<HRMSODATA.EmployeeList> data)
        {
            EmployeeListView.DataSource = data;
            EmployeeListView.DataBind();
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
                "Status"
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

        protected void btnFilterExport_Click(object sender, EventArgs e)
        {
            ExportListViewToExcel(EmployeeListView, "ExportEmployeeList.xls");

        }
        protected void btnApplyHrmsFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected void btnApplyFirstNameFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        protected void btnApplyBillGroupFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected void btnApplyAcTypeFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected void btnApplyBillTyeFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected void btnApplyDesinationFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected void btApplynSJDFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected void btnAppplyTradeFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected void btnApplyPostGroupFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected void btnApplyGpfFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected void btnApplyDOBFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected void btnApplyDOSFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected void btnApplyCategoryFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected void btnApplyJSFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected void btnApplyDOJFilteer_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected void btnApplyCurrentStationFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();

        }

        protected void btnApplyJoiningDesignationFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected void btnApplyBaseQualificationFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected void btnApplyBasicPayFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected void btnApplyEmploymentStatusFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected void btnApplyDateofIncrementFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected void btnApplyEmailFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected void btnApplyMACPFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected void btnApplyEPICFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected void btnApplyMobileNoFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected void btnApplyPensionRemarkFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected void btnApplyAadhaarNoFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected void btnApplyDesignationHRMSFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected void btnApplyHomeDistFilter_Click1(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected void btnApplyStatusFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected void btnApplyHomeDistHrmsFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }
    }

}