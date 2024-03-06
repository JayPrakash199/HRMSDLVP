using Microsoft.OData.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace WebServices
{
    public class ODataServices
    {

        public static IList<HRMSODATA.CompanyList> GetCompanyList()
        {
            string serviceUrl = GetOdataURL();
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.CompanyList> lstCompany = container.CreateQuery<HRMSODATA.CompanyList>("CompanyList").ToList();
            return lstCompany;

        }
        #region HRMS
        public static IList<HRMSODATA.EmployeeList> GetEmployeeList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.EmployeeList> q = container.CreateQuery<HRMSODATA.EmployeeList>("EmployeeList").ToList();

            return q;
        }
        public static IList<HRMSODATA.EmployeeLeaveList> GetEmployeeLeaveList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.EmployeeLeaveList> lstLeave = container.CreateQuery<HRMSODATA.EmployeeLeaveList>("EmployeeLeaveList").ToList();
            return lstLeave;
        }

        public static IList<HRMSODATA.EmployeeAdditionalInfoList> GetAdditionalEmployeeList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.EmployeeAdditionalInfoList> q = container.CreateQuery<HRMSODATA.EmployeeAdditionalInfoList>("EmployeeAdditionalInfoList").ToList();

            return q;
        }

        public static HRMSODATA.EmployeeList GetEmployeeInfo(string hrmsId, string companyName)
        {
            var additionalEmployee = GetEmployeeList(companyName).Where(x => string.Equals(x.No, hrmsId, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            return additionalEmployee;
        }

        public static HRMSODATA.EmployeeAdditionalInfoList GetAdditionalEmployeeInfo(string hrmsId, string companyName)
        {
            var additionalEmployee = GetAdditionalEmployeeList(companyName).Where(x => string.Equals(x.HRMS_ID, hrmsId, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            return additionalEmployee;
        }

        public static IList<HRMSODATA.Districtlist> Getdistricts(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.Districtlist> q = container.CreateQuery<HRMSODATA.Districtlist>("Districtlist").ToList();

            return q;
        }

        public static IList<HRMSODATA.DepartmentList> GetDepartmentTradeSections(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.DepartmentList> q = container.CreateQuery<HRMSODATA.DepartmentList>("DepartmentList").ToList();

            return q;
        }

        public static IList<HRMSODATA.Institutelist> GetStationList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.Institutelist> q = container.CreateQuery<HRMSODATA.Institutelist>("Institutelist").ToList();

            return q;
        }

        public static IList<HRMSODATA.FinancialUpgradeList> GetFinancialUpgradeList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.FinancialUpgradeList> q = container.CreateQuery<HRMSODATA.FinancialUpgradeList>("FinancialUpgradeList").ToList();

            return q;
        }

        public static IList<HRMSODATA.EmployeeTransferHistoryList> GetEmployeeTransferHistoryList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.EmployeeTransferHistoryList> q = container.CreateQuery<HRMSODATA.EmployeeTransferHistoryList>("EmployeeTransferHistoryList").ToList();

            return q;
        }

        public static HRMSODATA.EmployeeTransferHistoryList FindEmployeeTransferHistory(string hrmsID, string companyName)
        {
            //EmployeeTransferHistoryReference.EmployeeTransferHistoryCard_Service _obj_Binding = (EmployeeTransferHistoryReference.EmployeeTransferHistoryCard_Service)Configuration
            //    .getNavService(new EmployeeTransferHistoryReference.EmployeeTransferHistoryCard_Service(), "EmployeeTransferHistoryCard", "Page");
            EmployeeTransferHistoryReference.EmployeeTransferHistoryCard obj = new EmployeeTransferHistoryReference.EmployeeTransferHistoryCard();
            List<HRMSODATA.EmployeeTransferHistoryList> objList = GetEmployeeTransferHistoryList(companyName).Where(x => string.Equals(x.HRMS_ID, hrmsID, StringComparison.OrdinalIgnoreCase)).ToList();
            return objList.FirstOrDefault();
        }

        public static IList<HRMSODATA.EmployeePromotionHistoryList> GetPromotionHistoryList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.EmployeePromotionHistoryList> q = container.CreateQuery<HRMSODATA.EmployeePromotionHistoryList>("EmployeePromotionHistoryList").ToList();

            return q;
        }

        public static IList<HRMSODATA.AnnualEstablishmentReviewList> GetAnnualEstablishmentReviewList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.AnnualEstablishmentReviewList> q = container.CreateQuery<HRMSODATA.AnnualEstablishmentReviewList>("AnnualEstablishmentReviewList").ToList();

            return q;
        }

        public static IList<HRMSODATA.EmployeeTransferApplicationList> GetEmployeeTransferApplicationList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.EmployeeTransferApplicationList> q = container.CreateQuery<HRMSODATA.EmployeeTransferApplicationList>("EmployeeTransferApplicationList").ToList();

            return q;
        }

        public static IList<HRMSODATA.EmployeeDscpList> GetDisciplinaryList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.EmployeeDscpList> q = container.CreateQuery<HRMSODATA.EmployeeDscpList>("EmployeeDscpList").ToList();

            return q;
        }

        public static IList<HRMSODATA.EmployeeDscpList> GetDisciplinaryListByHRMSID(string HRMSID, string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.EmployeeDscpList> q = container.CreateQuery<HRMSODATA.EmployeeDscpList>("EmployeeDscpList").ToList();

            return q.Where(x => x.HRMS_ID == HRMSID).ToList();
        }

        public static IList<HRMSODATA.RTIMonitoringList> GetRTIMonitoringList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.RTIMonitoringList> q = container.CreateQuery<HRMSODATA.RTIMonitoringList>("RTIMonitoringList").ToList();

            return q;
        }

        public static IList<HRMSODATA.CourtCaseList> GetCourtCaseList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.CourtCaseList> q = container.CreateQuery<HRMSODATA.CourtCaseList>("CourtCaseList").ToList();

            return q;
        }

        public static IList<HRMSODATA.AnnualPerformanceList> GetAnnualPerformanceList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.AnnualPerformanceList> q = container.CreateQuery<HRMSODATA.AnnualPerformanceList>("AnnualPerformanceList").ToList();

            return q;
        }

        public static IList<HRMSODATA.EmployeeTrainingHistoryList> GetEmployeeTrainingHistoryList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.EmployeeTrainingHistoryList> q = container.CreateQuery<HRMSODATA.EmployeeTrainingHistoryList>("EmployeeTrainingHistoryList").ToList();

            return q;
        }

        public static IList<HRMSODATA.EmployeeAchvList> GetEmployeeAchvList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.EmployeeAchvList> q = container.CreateQuery<HRMSODATA.EmployeeAchvList>("EmployeeAchvList").ToList();

            return q;
        }

        public static IList<HRMSODATA.DesignationList> GetDesignation(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.DesignationList> lstDesignation = container.CreateQuery<HRMSODATA.DesignationList>("DesignationList").ToList();

            return lstDesignation;
        }



        public static IList<HRMSODATA.FinancialYearList> GetFinancialYearList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.FinancialYearList> lstFy = container.CreateQuery<HRMSODATA.FinancialYearList>("FinancialYearList").ToList();

            return lstFy;
        }
        public static IList<HRMSODATA.Districtlist> GetHomeDist(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.Districtlist> lstDist = container.CreateQuery<HRMSODATA.Districtlist>("Districtlist").ToList();
            return lstDist;
        }
        #endregion

        #region Library
        public static IList<HRMSODATA.BookList> GetBookList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.BookList> q = container.CreateQuery<HRMSODATA.BookList>("BookList").ToList();
            return q;
        }

        public static IList<HRMSODATA.BookIssueList> GetBookIssueList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.BookIssueList> q = container.CreateQuery<HRMSODATA.BookIssueList>("BookIssueList").ToList();
            return q;
        }

        public static IList<HRMSODATA.BookReturnList> GetBookReturnList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.BookReturnList> Bookreturndata = container.CreateQuery<HRMSODATA.BookReturnList>("BookReturnList").ToList();
            return Bookreturndata;
        }
        public static IList<HRMSODATA.BookRenewalList> GetBookRenewalList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.BookRenewalList> BookRenewaData = container.CreateQuery<HRMSODATA.BookRenewalList>("BookRenewalList").ToList();

            return BookRenewaData;
        }

        public static IList<HRMSODATA.AdvanceBookingList> GeAdvncedtBookList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.AdvanceBookingList> advancedilst = container.CreateQuery<HRMSODATA.AdvanceBookingList>("AdvanceBookingList").ToList();
            return advancedilst;
        }

        public static IList<HRMSODATA.StudentList> GetStudentList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.StudentList> studentList = container.CreateQuery<HRMSODATA.StudentList>("StudentList").ToList();
            return studentList;
        }
        public static IList<HRMSODATA.StudentList> GetStudentListByNo(String No, string companyName)
        {
            List<HRMSODATA.StudentList> studentList = GetStudentList(companyName).Where(x => x.No == No).ToList();
            return studentList;
        }


        public static IList<HRMSODATA.AccessionList> GetAccessionList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.AccessionList> accessionList = container.CreateQuery<HRMSODATA.AccessionList>("AccessionList").ToList();
            return accessionList;
        }

        public static IList<HRMSODATA.Locations> GetLocationsList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.Locations> locationList = container.CreateQuery<HRMSODATA.Locations>("Locations").ToList();
            return locationList;
        }

        public static IList<HRMSODATA.ItemCategories> GetItemCategoriesList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.ItemCategories> itemCategories = container.CreateQuery<HRMSODATA.ItemCategories>("ItemCategories").ToList();
            return itemCategories;
        }

        public static IList<HRMSODATA.ItemJournalTemplateList> GetItemJournalTemplateList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.ItemJournalTemplateList> itemJournalTemplateList = container.CreateQuery<HRMSODATA.ItemJournalTemplateList>("ItemJournalTemplateList").ToList();
            return itemJournalTemplateList;
        }
        public static IList<HRMSODATA.ItemJournalBatches> GetItemJournalBatches(String templateName, string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.ItemJournalBatches> itemJournalBatches = container.CreateQuery<HRMSODATA.ItemJournalBatches>("ItemJournalBatches").ToList()
                .Where(x => x.Journal_Template_Name == templateName).ToList();
            return itemJournalBatches;
        }

        public static IList<HRMSODATA.BookList> GetFilterBookList(string inputVal, string companyName)
        {
            if (!string.IsNullOrEmpty(inputVal))
            {
                var filterBookList = GetBookList(companyName).Where(x => x.Book_Name.IndexOf(inputVal, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                return filterBookList;
            }
            else
                return GetBookList(companyName);
        }
        public static IList<HRMSODATA.BookIssueList> GetFilterBookIssueList(string inputVal, string companyName)
        {
            if (!string.IsNullOrEmpty(inputVal))
            {
                var filterBookIssueList = GetBookIssueList(companyName).Where(x => x.Entry_No == inputVal |
                                                            x.User_Type == inputVal |
                                                            x.No == inputVal |
                                                            x.Name == inputVal |
                                                            x.Book_No == inputVal |
                                                            x.Book_Name == inputVal |
                                                            x.Accession_No == inputVal |
                                                            x.Location_Code == inputVal |
                                                            x.User_ID == inputVal |
                                                            x.Portal_ID == inputVal |
                                                            x.Transaction_Entry_Type == inputVal).ToList();

                return filterBookIssueList;
            }
            else
                return GetBookIssueList(companyName);
        }
        public static IList<HRMSODATA.BookIssueList> GetBookIssueListByNo(string No, string companyName)
        {
            var filterBookIssueList = GetBookIssueList(companyName).Where(x => x.No == No && x.User_Type == "Student").ToList().OrderByDescending(s => s.Entry_No).ToList();

            return filterBookIssueList;
        }
        public static IList<HRMSODATA.BookIssueList> GetBookIssueListByAccessNo(string AccessNo, string companyName)
        {
            var filterBookIssueList = GetBookIssueList(companyName).Where(x => x.Accession_No == AccessNo).ToList();

            return filterBookIssueList;
        }
        public static IList<HRMSODATA.BookReturnList> GetFilterBookreturnList(string inputVal, string companyName)
        {
            if (!string.IsNullOrEmpty(inputVal))
            {
                var filterBookreturnList = GetBookReturnList(companyName).Where(x => x.Entry_No == inputVal |
                                                                 x.Accession_No == inputVal |
                                                                 x.Book_No == inputVal |
                                                                 x.Book_Name == inputVal |
                                                                 x.Name == inputVal |
                                                                 x.Transaction_Entry_Type == inputVal |
                                                                 x.Class_Code == inputVal |
                                                                 x.No == inputVal).ToList();

                return filterBookreturnList;
            }
            else
                return GetBookReturnList(companyName);
        }
        public static IList<HRMSODATA.BookRenewalList> GetFilterBookRenewalList(string inputVal, string companyName)
        {
            if (!string.IsNullOrEmpty(inputVal))
            {
                var filterBookRenewalList = GetBookRenewalList(companyName).Where(x => x.Entry_No == inputVal |
                                                                   x.User_Type == inputVal |
                                                                   x.Accession_No == inputVal |
                                                                   x.Book_No == inputVal |
                                                                   x.Book_Name == inputVal |
                                                                   x.Name == inputVal |
                                                                   x.No == inputVal).ToList();
                return filterBookRenewalList;
            }
            else
                return GetBookRenewalList(companyName);
        }
        public static IList<HRMSODATA.AdvanceBookingList> GetFilterAdvanceBookingList(string inputVal, string companyName)
        {
            if (!string.IsNullOrEmpty(inputVal))
            {
                var filterAdvanceBookingList = GeAdvncedtBookList(companyName).Where(x => x.Booking_No == inputVal |
                                                                   x.Type == inputVal |
                                                                   x.No == inputVal |
                                                                   x.Book_No == inputVal |
                                                                   x.Book_Name == inputVal |
                                                                   x.Name == inputVal).ToList();

                return filterAdvanceBookingList;
            }
            else
                return GeAdvncedtBookList(companyName);
        }
        public static IList<HRMSODATA.Locations> GetFilterLocationsList(string inputVal, string companyName)
        {
            if (!string.IsNullOrEmpty(inputVal))
            {
                var locationList = GetLocationsList(companyName).Where(x => x.Code == inputVal | x.Name == inputVal).ToList();
                return locationList;
            }
            else
                return GetLocationsList(companyName);
        }
        public static IList<HRMSODATA.ItemCategories> GetFilterItemCategoriesList(string inputVal, string companyName)
        {
            if (!string.IsNullOrEmpty(inputVal))
            {
                var CatagoryList = GetItemCategoriesList(companyName).Where(x => x.Code == inputVal | x.Description == inputVal).ToList();
                return CatagoryList;
            }
            else
                return GetItemCategoriesList(companyName);
        }
        public static IList<HRMSODATA.ItemJournalTemplateList> GetFilterItemJournalTemplateList(string inputVal, string companyName)
        {
            if (!string.IsNullOrEmpty(inputVal))
            {
                var CatagoryList = GetItemJournalTemplateList(companyName).Where(x => x.Name == inputVal | x.Reason_Code == inputVal | x.Source_Code == inputVal).ToList();
                return CatagoryList;
            }
            else
                return GetItemJournalTemplateList(companyName);
        }

        public static IList<HRMSODATA.PostedBookAccessionList> GetPostedBookAccessionList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.PostedBookAccessionList> locationList = container.CreateQuery<HRMSODATA.PostedBookAccessionList>("PostedBookAccessionList").ToList();
            return locationList;
        }

        public static object GetBookTypes(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.BookType> booktypelist = container.CreateQuery<HRMSODATA.BookType>("BookType").ToList();
            return booktypelist;
        }

        #endregion

        #region Fee Management
        public static IList<HRMSODATA.FeeComponentList> GetFeeComponentList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.FeeComponentList> q = container.CreateQuery<HRMSODATA.FeeComponentList>("FeeComponentList").ToList();

            return q;
        }

        public static IList<HRMSODATA.CourseFeeHeaderList> GetCourseFeeHeaderList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.CourseFeeHeaderList> q = container.CreateQuery<HRMSODATA.CourseFeeHeaderList>("CourseFeeHeaderList").ToList();

            return q;
        }

        public static IList<HRMSODATA.CourseFeeDetailLine> GetCourseFeeLines(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.CourseFeeDetailLine> q = container.CreateQuery<HRMSODATA.CourseFeeDetailLine>("CourseFeeDetailLine").ToList();

            return q;
        }

        public static IList<HRMSODATA.StudentType> GetFeeClassificationList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.StudentType> q = container.CreateQuery<HRMSODATA.StudentType>("StudentType").ToList();

            return q;
        }

        public static IList<HRMSODATA.CustomerList> GetCustomerList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.CustomerList> q = container.CreateQuery<HRMSODATA.CustomerList>("CustomerList").ToList();

            return q;
        }

        public static IList<HRMSODATA.SemisterList> GetSemisterList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.SemisterList> q = container.CreateQuery<HRMSODATA.SemisterList>("SemisterList").ToList();

            return q;
        }

        public static IList<HRMSODATA.CourseList> GetCourseList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.CourseList> q = container.CreateQuery<HRMSODATA.CourseList>("CourseList").ToList();

            return q;
        }

        public static IList<HRMSODATA.FeeCollection> GetFeeCollectionList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.FeeCollection> q = container.CreateQuery<HRMSODATA.FeeCollection>("FeeCollection").ToList();

            return q;
        }

        public static IList<HRMSODATA.StudentFeeCollection> GetStudentFeeCollectionList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.StudentFeeCollection> q = container.CreateQuery<HRMSODATA.StudentFeeCollection>("StudentFeeCollection").ToList();

            return q;
        }

        public static IList<HRMSODATA.GeneralPaymentList> GetGeneralPaymentList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.GeneralPaymentList> q = container.CreateQuery<HRMSODATA.GeneralPaymentList>("GeneralPaymentList").ToList();

            return q;
        }

        public static IList<HRMSODATA.FeeClassification> GetFeeClassifications(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.FeeClassification> q = container.CreateQuery<HRMSODATA.FeeClassification>("FeeClassification").ToList();

            return q;
        }

        public static IList<HRMSODATA.BookAccessionList> GetBookAccessionList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.BookAccessionList> q = container.CreateQuery<HRMSODATA.BookAccessionList>("BookAccessionList").ToList();

            return q;
        }

        public static IList<HRMSODATA.Language> GetLanguageList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.Language> q = container.CreateQuery<HRMSODATA.Language>("Language").ToList();

            return q;
        }

        public static IList<HRMSODATA.BookCategoryList> GetBookCategoryList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.BookCategoryList> q = container.CreateQuery<HRMSODATA.BookCategoryList>("BookCategoryList").ToList();

            return q;
        }

        public static IList<HRMSODATA.PublisherName> GetPublisherNames(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.PublisherName> q = container.CreateQuery<HRMSODATA.PublisherName>("PublisherName").ToList();

            return q;
        }

        //public static IList<HRMSODATA.BookTypes> GetBookTypes(string companyName)
        //{
        //    string serviceUrl = GetOdataURL(companyName);
        //    Uri uri = new Uri(serviceUrl);
        //    var container = new HRMSODATA.NAV(uri);
        //    container.BuildingRequest += Context_BuildingRequest;
        //    List<HRMSODATA.BookTypes> q = container.CreateQuery<HRMSODATA.BookTypes>("BookTypes").ToList();

        //    return q;
        //}

        //public static IList<HRMSODATA.VendorList> GetVendorsList(string companyName)
        //{
        //    string serviceUrl = GetOdataURL(companyName);
        //    Uri uri = new Uri(serviceUrl);
        //    var container = new HRMSODATA.NAV(uri);
        //    container.BuildingRequest += Context_BuildingRequest;
        //    List<HRMSODATA.VendorList> q = container.CreateQuery<HRMSODATA.VendorList>("VendorList").ToList();

        //    return q;
        //}
        #endregion

        #region
        public static List<HRMSODATA.LandDetailList> GetLandDetailList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.LandDetailList> q = container.CreateQuery<HRMSODATA.LandDetailList>("LandDetailList").ToList();

            return q;
        }

        public static IList<HRMSODATA.GeneralLandBuildingList> GetGeneralLandBuildingList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.GeneralLandBuildingList> q = container.CreateQuery<HRMSODATA.GeneralLandBuildingList>("GeneralLandBuildingList").ToList();

            return q;
        }

        public static List<HRMSODATA.InstituteBuildingsList> GetInstituteBuildings(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.InstituteBuildingsList> q = container.CreateQuery<HRMSODATA.InstituteBuildingsList>("InstituteBuildingsList").ToList();

            return q;
        }

        public static List<HRMSODATA.HostelBuildingsList> GetHostelBuildings(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.HostelBuildingsList> q = container.CreateQuery<HRMSODATA.HostelBuildingsList>("HostelBuildingsList").ToList();

            return q;
        }

        public static List<HRMSODATA.StaffQuartersList> GetStaffQuarters(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.StaffQuartersList> q = container.CreateQuery<HRMSODATA.StaffQuartersList>("StaffQuartersList").ToList();

            return q;
        }

        public static List<HRMSODATA.AuditoriumBuilding> GetAuditoriumList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.AuditoriumBuilding> q = container.CreateQuery<HRMSODATA.AuditoriumBuilding>("AuditoriumBuilding").ToList();

            return q;
        }

        public static List<HRMSODATA.Institutelist> GetAllInstitutes(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.Institutelist> q = container.CreateQuery<HRMSODATA.Institutelist>("Institutelist").ToList();

            return q;
        }

        public static List<HRMSODATA.AllProjectList> GetAllProjectDetails(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.AllProjectList> q = container.CreateQuery<HRMSODATA.AllProjectList>("AllProjectList").ToList();

            return q;
        }

        public static List<HRMSODATA.Ongoingprojectcard> GetOnGoingTypeProjectDetails(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.Ongoingprojectcard> q = container.CreateQuery<HRMSODATA.Ongoingprojectcard>("Ongoingprojectcard").ToList();

            return q;
        }

        public static List<HRMSODATA.Improvementprojectcard> GetImprovementTypeProjectDetails(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.Improvementprojectcard> q = container.CreateQuery<HRMSODATA.Improvementprojectcard>("Improvementprojectcard").ToList();

            return q;
        }

        public static List<HRMSODATA.VendorList> GetVendorList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.VendorList> q = container.CreateQuery<HRMSODATA.VendorList>("VendorList").ToList();

            return q;
        }

        public static List<HRMSODATA.ServiceList> GetSecurityServiceList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.ServiceList> q = container.CreateQuery<HRMSODATA.ServiceList>("ServiceList").ToList();

            return q;
        }

        public static List<HRMSODATA.ItemList> GetItemList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.ItemList> q = container.CreateQuery<HRMSODATA.ItemList>("ItemList").ToList();

            return q;
        }

        public static List<HRMSODATA.AMCList> GetAMCList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.AMCList> q = container.CreateQuery<HRMSODATA.AMCList>("AMCList").ToList();

            return q;
        }

        #endregion

        #region User Management
        public static List<HRMSODATA.UserAuthenticationList> GetUserAuthenticationList()
        {
            string serviceUrl = GetOdataURL();
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.UserAuthenticationList> q = container.CreateQuery<HRMSODATA.UserAuthenticationList>("UserAuthenticationList").ToList();

            return q;
        }
        public static List<HRMSODATA.UserAuthorizationList> GetUserAuthorizationList()
        {
            string serviceUrl = GetOdataURL();
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.UserAuthorizationList> authList = container.CreateQuery<HRMSODATA.UserAuthorizationList>("UserAuthorizationList").ToList();
            return authList;
        }

        #endregion

        #region Account Management

        public static IList<HRMSODATA.CautionMoneyApplicationList> GetCautionMoneyApplicationList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.CautionMoneyApplicationList> q = container.CreateQuery<HRMSODATA.CautionMoneyApplicationList>("CautionMoneyApplicationList").ToList();

            return q;
        }
        public static IList<HRMSODATA.CautionRefundOrder> GetCautionRefundOrder(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.CautionRefundOrder> q = container.CreateQuery<HRMSODATA.CautionRefundOrder>("CautionRefundOrder").ToList();

            return q;
        }

        public static IList<HRMSODATA.CautionRefundOrderSubform> GetCautionRefundOrderSubform(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.CautionRefundOrderSubform> q = container.CreateQuery<HRMSODATA.CautionRefundOrderSubform>("CautionRefundOrderSubform").ToList();

            return q;
        }

        public static IList<HRMSODATA.CautionRefundOrderCautionLines> GetRefundOrderCautionLines(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.CautionRefundOrderCautionLines> q = container.CreateQuery<HRMSODATA.CautionRefundOrderCautionLines>("CautionRefundOrderCautionLines").ToList();

            return q;
        }

        public static IList<HRMSODATA.CautionRefundOrderList> GetCautionRefundOrderList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.CautionRefundOrderList> q = container.CreateQuery<HRMSODATA.CautionRefundOrderList>("CautionRefundOrderList").ToList();

            return q;
        }


        public static IList<HRMSODATA.Chart_of_Accounts> GetChartofAccounts(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.Chart_of_Accounts> q = container.CreateQuery<HRMSODATA.Chart_of_Accounts>("Chart_of_Accounts").ToList();

            return q;
        }

        public static IList<HRMSODATA.BankAccountList> GetBankAccountList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.BankAccountList> q = container.CreateQuery<HRMSODATA.BankAccountList>("BankAccountList").ToList();

            return q;
        }

        public static IList<HRMSODATA.GraduationList> GetGraduationList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.GraduationList> lstGrad = container.CreateQuery<HRMSODATA.GraduationList>("GraduationList").ToList();

            return lstGrad;
        }


        public static IList<HRMSODATA.DimValueList> GetDimentionList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.DimValueList> dmlist = container.CreateQuery<HRMSODATA.DimValueList>("DimValueList").ToList();

            return dmlist;
        }

        public static IList<HRMSODATA.TransferAccountList> GetTransferAccountList(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.TransferAccountList> AcTransferLst = container.CreateQuery<HRMSODATA.TransferAccountList>("TransferAccountList").ToList();
            return AcTransferLst;
        }





        #endregion

        #region Odata Connection Manager
        private static void Context_BuildingRequest(object sender, BuildingRequestEventArgs e)
        {
            string authKey = ConfigurationManager.AppSettings["AuthKey"].ToString();
            if (!string.IsNullOrEmpty(authKey))
            {
                e.Headers.Add("Authorization", authKey);
            }
        }

        private static string GetOdataURL(string companyName = "GOVT%20POLYTECHNIC%20ANGUL")
        {
            return string.Format(Configuration.ODataServiceUrl()) + "('" + companyName + "')/";
        }

        public static IList<HRMSODATA.CustomerDocumentList> GetDocumentData(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.CustomerDocumentList> lst = container.CreateQuery<HRMSODATA.CustomerDocumentList>("CustomerDocumentList").ToList();
            return lst;
        }
        #endregion

        #region MyRegion
        public static IList<HRMSODATA.TimeTable> GetTimeTableData(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.TimeTable> lstTimeTable = container.CreateQuery<HRMSODATA.TimeTable>("TimeTable").ToList();
            return lstTimeTable;
        }
        public static IList<HRMSODATA.StudentList> GetStudenteData(string companyName)
        {
            string serviceUrl = GetOdataURL(companyName);
            Uri uri = new Uri(serviceUrl);
            var container = new HRMSODATA.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<HRMSODATA.StudentList> lstStudentData = container.CreateQuery<HRMSODATA.StudentList>("StudentList").ToList();
            return lstStudentData;
        }
        #endregion
    }
}
