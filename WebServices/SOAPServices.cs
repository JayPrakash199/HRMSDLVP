using System;
using System.IO;
using System.Web.Configuration;

namespace WebServices
{
    public class SOAPServices
    {
        #region HRMS
        public static string CreateEmployee(EmplaoyeeReference.EmployeeCard obj, string companyName)
        {
            try
            {
                EmplaoyeeReference.EmployeeCard_Service _obj_Binding = (EmplaoyeeReference.EmployeeCard_Service)Configuration
                    .getNavService(new EmplaoyeeReference.EmployeeCard_Service(), "EmployeeCard", "Page", companyName);
                _obj_Binding.Create(ref obj);
                return ResultMessages.SuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string AddEmployeeAdditionalInfo(EmployeeAdditionalCardReference.EmployeeAdditionalInfoCard obj, string companyName)
        {
            try
            {
                EmployeeAdditionalCardReference.EmployeeAdditionalInfoCard_Service _obj_Binding = (EmployeeAdditionalCardReference.EmployeeAdditionalInfoCard_Service)Configuration
                    .getNavService(new EmployeeAdditionalCardReference.EmployeeAdditionalInfoCard_Service(), "EmployeeAdditionalInfoCard", "Page", companyName);
                _obj_Binding.Create(ref obj);

                HRMSCodeunitReference.HRMSCodeunit objhrms = new HRMSCodeunitReference.HRMSCodeunit();
                objhrms = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                    .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
                objhrms.UpdateAddEmpDetails(obj.HRMS_ID);

                return ResultMessages.SuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string UpdateEmployeeDetails(EmplaoyeeReference.EmployeeCard input, string companyName)
        {
            try
            {
                EmplaoyeeReference.EmployeeCard_Service _obj_Binding =
                    (EmplaoyeeReference.EmployeeCard_Service)Configuration
                    .getNavService(new EmplaoyeeReference.EmployeeCard_Service(), "EmployeeCard", "Page", companyName);
                EmplaoyeeReference.EmployeeCard obj = new EmplaoyeeReference.EmployeeCard();
                //IList<HRMSODATA.EmployeeList> objList = ODataServices.GetEmployeeList()
                //                                                        .Where(x => string.Equals(x.No, input.No, StringComparison.OrdinalIgnoreCase))
                //                                                        .ToList();

                obj = _obj_Binding.Read(input.No);

                obj.Employment_Status = input.Employment_Status;
                obj.Date_of_increment = input.Date_of_increment;
                obj.MACP_Status = input.MACP_Status;

                _obj_Binding.Update(ref obj);

                return ResultMessages.UpdateSuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string UpdateAdditionalEmployeeDetails(EmployeeAdditionalCardReference.EmployeeAdditionalInfoCard input, string companyName)
        {
            try
            {
                HRMSCodeunitReference.HRMSCodeunit objhrms = new HRMSCodeunitReference.HRMSCodeunit();
                objhrms = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                    .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
                objhrms.UpdateAddEmpDetailsLatest(input.HRMS_ID, input.Date_of_increment, (int)input.MACP_Status, (int)input.Employment_Status);

                return ResultMessages.UpdateSuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public static string AddFinancialUpgradationForm(FinancialUpgradeReference.FinancialUpgradeCard obj, string companyName)
        {
            try
            {
                FinancialUpgradeReference.FinancialUpgradeCard_Service _obj_Binding = (FinancialUpgradeReference.FinancialUpgradeCard_Service)Configuration
                    .getNavService(new FinancialUpgradeReference.FinancialUpgradeCard_Service(), "FinancialUpgradeCard", "Page", companyName);
                _obj_Binding.Create(ref obj);
                return ResultMessages.SuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string UpdateFinancialUpgradation(FinancialUpgradeReference.FinancialUpgradeCard input, string companyName)
        {
            try
            {
                FinancialUpgradeReference.FinancialUpgradeCard_Service _obj_Binding =
                    (FinancialUpgradeReference.FinancialUpgradeCard_Service)Configuration
                    .getNavService(new FinancialUpgradeReference.FinancialUpgradeCard_Service(), "FinancialUpgradeCard", "Page", companyName);
                FinancialUpgradeReference.FinancialUpgradeCard obj = new FinancialUpgradeReference.FinancialUpgradeCard();
                //IList<HRMSODATA.EmployeeAdditionalInfoList> objList = ODataServices.GetAdditionalEmployeeList()
                //                                                        .Where(x => string.Equals(x.HRMS_ID, input.HRMS_ID, StringComparison.OrdinalIgnoreCase))
                //                                                        .ToList();

                obj = _obj_Binding.Read(input.Entry_No, input.HRMS_ID);
                obj.Status = input.Status;

                _obj_Binding.Update(ref obj);

                return ResultMessages.UpdateSuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string AddEmployeeTransferAndPromotionRecord(EmployeeTransferHistoryReference.EmployeeTransferHistoryCard obj, string companyName)
        {
            try
            {
                EmployeeTransferHistoryReference.EmployeeTransferHistoryCard_Service _obj_Binding =
                    (EmployeeTransferHistoryReference.EmployeeTransferHistoryCard_Service)Configuration
                    .getNavService(new EmployeeTransferHistoryReference.EmployeeTransferHistoryCard_Service(), "EmployeeTransferHistoryCard", "Page", companyName);
                _obj_Binding.Create(ref obj);
                return ResultMessages.SuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string UpdateTransferEmployeeDetails(EmployeeTransferHistoryReference.EmployeeTransferHistoryCard input, string companyName)
        {
            try
            {
                EmployeeTransferHistoryReference.EmployeeTransferHistoryCard_Service _obj_Binding = (EmployeeTransferHistoryReference.EmployeeTransferHistoryCard_Service)Configuration
                    .getNavService(new EmployeeTransferHistoryReference.EmployeeTransferHistoryCard_Service(), "EmployeeTransferHistoryCard", "Page", companyName);
                EmployeeTransferHistoryReference.EmployeeTransferHistoryCard obj = new EmployeeTransferHistoryReference.EmployeeTransferHistoryCard();
                //List<HRMSODATA.EmployeeTransferHistoryList> objList = ODataServices.GetEmployeeTransferHistoryList().Where(x => string.Equals(x.HRMS_ID, input.HRMS_ID, StringComparison.OrdinalIgnoreCase)).ToList();

                obj = _obj_Binding.Read(input.Entry_No);
                obj.Joining_Date = input.Joining_Date;
                obj.Joining_Event = input.Joining_Event;
                _obj_Binding.Update(ref obj);

                return ResultMessages.UpdateSuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string AddEmployeePromotionHistoryRecord(EmployeePromotionHistoryReference.EmployeePromotionHistoryCard obj, string companyName)
        {
            try
            {
                EmployeePromotionHistoryReference.EmployeePromotionHistoryCard_Service _obj_Binding = (EmployeePromotionHistoryReference.EmployeePromotionHistoryCard_Service)Configuration
                    .getNavService(new EmployeePromotionHistoryReference.EmployeePromotionHistoryCard_Service(), "EmployeePromotionHistoryCard", "Page", companyName);
                _obj_Binding.Create(ref obj);


                HRMSCodeunitReference.HRMSCodeunit objHrms = new HRMSCodeunitReference.HRMSCodeunit();
                objHrms = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                    .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
                objHrms.UpdateDesignation(obj.HRMS_ID,obj.To_Designation);

                return ResultMessages.SuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string AddAnnualEstablishmentReviewRecord(AnnualEstablishmentReviewReference.AnnualEstablishmentReviewCard obj, string companyName)
        {
            try
            {
                AnnualEstablishmentReviewReference.AnnualEstablishmentReviewCard_Service _obj_Binding = (AnnualEstablishmentReviewReference.AnnualEstablishmentReviewCard_Service)Configuration
                    .getNavService(new AnnualEstablishmentReviewReference.AnnualEstablishmentReviewCard_Service(), "AnnualEstablishmentReviewCard", "Page", companyName);
                _obj_Binding.Create(ref obj);
                return ResultMessages.SuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string AddEmployeeTransferApplicationRecord(EmployeeTransferApplicationReference.EmployeeTransferApplicationCard obj, string companyName)
        {
            try
            {
                EmployeeTransferApplicationReference.EmployeeTransferApplicationCard_Service _obj_Binding = (EmployeeTransferApplicationReference.EmployeeTransferApplicationCard_Service)Configuration
                    .getNavService(new EmployeeTransferApplicationReference.EmployeeTransferApplicationCard_Service(), "EmployeeTransferApplicationCard", "Page", companyName);
                _obj_Binding.Create(ref obj);
                return ResultMessages.SuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string AddEmployeeAchvRecord(EmployeeAchvReference.EmployeeAchvCard obj, string companyName)
        {
            try
            {
                EmployeeAchvReference.EmployeeAchvCard_Service _obj_Binding = (EmployeeAchvReference.EmployeeAchvCard_Service)Configuration
                    .getNavService(new EmployeeAchvReference.EmployeeAchvCard_Service(), "EmployeeAchvCard", "Page", companyName);
                _obj_Binding.Create(ref obj);
                return ResultMessages.SuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string AddEmployeeDscpRecord(EmployeeDscpReference.EmployeeDscpCard obj, string companyName)
        {
            try
            {
                EmployeeDscpReference.EmployeeDscpCard_Service _obj_Binding = (EmployeeDscpReference.EmployeeDscpCard_Service)Configuration
                    .getNavService(new EmployeeDscpReference.EmployeeDscpCard_Service(), "EmployeeDscpCard", "Page", companyName);
                _obj_Binding.Create(ref obj);
                return ResultMessages.SuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string UpdateEmployeeDscpRecord(EmployeeDscpReference.EmployeeDscpCard input, string companyName)
        {
            try
            {
                EmployeeDscpReference.EmployeeDscpCard_Service _obj_Binding = (EmployeeDscpReference.EmployeeDscpCard_Service)Configuration
                    .getNavService(new EmployeeDscpReference.EmployeeDscpCard_Service(), "EmployeeDscpCard", "Page", companyName);
                EmployeeDscpReference.EmployeeDscpCard obj = new EmployeeDscpReference.EmployeeDscpCard();
                //List<HRMSODATA.EmployeeDscpList> objList = ODataServices.GetDisciplinaryList().Where(x => string.Equals(x.HRMS_ID, input.HRMS_ID, StringComparison.OrdinalIgnoreCase)).ToList();

                obj = _obj_Binding.Read(input.Entry_No);
                obj.Disciplinary_CasesStatus = input.Disciplinary_CasesStatus;
                obj.WhetherPlaced_under_suspension = input.WhetherPlaced_under_suspension;
                obj.Whether_reinstated = input.Whether_reinstated;
                _obj_Binding.Update(ref obj);

                return ResultMessages.UpdateSuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string AddEmployeeTrainingHistoryRecord(EmployeeTrainingHistoryReference.EmployeeTrainingHistoryCard obj, string companyName)
        {
            try
            {
                EmployeeTrainingHistoryReference.EmployeeTrainingHistoryCard_Service _obj_Binding = (EmployeeTrainingHistoryReference.EmployeeTrainingHistoryCard_Service)Configuration
                    .getNavService(new EmployeeTrainingHistoryReference.EmployeeTrainingHistoryCard_Service(), "EmployeeTrainingHistoryCard", "Page", companyName);
                _obj_Binding.Create(ref obj);
                return ResultMessages.SuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string AddAnnualPerformanceRecord(AnnualPerformanceReference.AnnualPerformanceCard obj, string companyName)
        {
            try
            {
                AnnualPerformanceReference.AnnualPerformanceCard_Service _obj_Binding = (AnnualPerformanceReference.AnnualPerformanceCard_Service)Configuration
                    .getNavService(new AnnualPerformanceReference.AnnualPerformanceCard_Service(), "AnnualPerformanceCard", "Page", companyName);
                _obj_Binding.Create(ref obj);
                return ResultMessages.SuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string AddCourtCaseRecord(CourtCaseReference.CourtCaseCard obj, string companyName)
        {
            try
            {
                CourtCaseReference.CourtCaseCard_Service _obj_Binding = (CourtCaseReference.CourtCaseCard_Service)Configuration
                    .getNavService(new CourtCaseReference.CourtCaseCard_Service(), "CourtCaseCard", "Page", companyName);
                _obj_Binding.Create(ref obj);
                return ResultMessages.SuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string AddRTIMonitoringRecord(RTIMonitoringReference.RTIMonitoringCard obj, string companyName)
        {
            try
            {
                RTIMonitoringReference.RTIMonitoringCard_Service _obj_Binding = (RTIMonitoringReference.RTIMonitoringCard_Service)Configuration
                    .getNavService(new RTIMonitoringReference.RTIMonitoringCard_Service(), "RTIMonitoringCard", "Page", companyName);
                _obj_Binding.Create(ref obj);
                return ResultMessages.SuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static void ImportHRMSDataImportFromGovtPortal(string filePath, string companyName)
        {
            HRMSCodeunitReference.HRMSCodeunit obj = new HRMSCodeunitReference.HRMSCodeunit();
            obj = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
            obj.HRMSDataImportFromGovtPortal(filePath);
        }

        public static void UploadFinancialUpgradationApplication(int entryNo, string hrmsID, string filePathWithName, string companyName)
        {
            HRMSCodeunitReference.HRMSCodeunit obj = new HRMSCodeunitReference.HRMSCodeunit();
            obj = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
            obj.Upload_Financial_Upgradation_Application(entryNo, hrmsID, Path.Combine(filePathWithName));
        }

        public static void Upload_Promotion_Order(int entryNo, string filePathWithName, string companyName)
        {
            HRMSCodeunitReference.HRMSCodeunit obj = new HRMSCodeunitReference.HRMSCodeunit();
            obj = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
            obj.Upload_Promotion_Order(entryNo, Path.Combine(filePathWithName));
        }

        public static void UploadEmployeeTrainingHistoryCertificate(int entryNo, string filePathWithName, string companyName)
        {
            HRMSCodeunitReference.HRMSCodeunit obj = new HRMSCodeunitReference.HRMSCodeunit();
            obj = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
            obj.Upload_Employee_Training_History_Certificate(entryNo, Path.Combine(filePathWithName));
        }
        #endregion

        #region Exporting to CSV
        public static string ExportEmployees(string companyName)
        {
            HRMSCodeunitReference.HRMSCodeunit obj = new HRMSCodeunitReference.HRMSCodeunit();
            obj = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
            return obj.ExportEmployeeList();
        }

        public static string ExportFinancialUpgrdations(string companyName)
        {
            HRMSCodeunitReference.HRMSCodeunit obj = new HRMSCodeunitReference.HRMSCodeunit();
            obj = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
            return obj.ExportFinancialUpgradationApplicationForm();
        }

        public static string ExportPromotionHistory(string companyName)
        {
            HRMSCodeunitReference.HRMSCodeunit obj = new HRMSCodeunitReference.HRMSCodeunit();
            obj = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
            return obj.ExportPromotionDetails();
        }

        public static string ExportAnnualEstablishmentPartA(string companyName)
        {
            HRMSCodeunitReference.HRMSCodeunit obj = new HRMSCodeunitReference.HRMSCodeunit();
            obj = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
            return obj.ExportAnnualEstablishmentPartA();
        }

        public static string ExportAnnualEstablishmentPartC(string companyName)
        {
            HRMSCodeunitReference.HRMSCodeunit obj = new HRMSCodeunitReference.HRMSCodeunit();
            obj = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
            return obj.ExportAnnualEstablishmentPartC();
        }

        public static string ExportAnnualEstablishmentPartE(string companyName)
        {
            HRMSCodeunitReference.HRMSCodeunit obj = new HRMSCodeunitReference.HRMSCodeunit();
            obj = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
            return obj.ExportAnnualEstablishmentPartE();
        }

        public static string ExportTransferConsolidatedList(string companyName)
        {
            HRMSCodeunitReference.HRMSCodeunit obj = new HRMSCodeunitReference.HRMSCodeunit();
            obj = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
            return obj.ExportTransferConsolidatedList();
        }

        public static string ExportDisciplinaryDetailsPreview(string companyName)
        {
            HRMSCodeunitReference.HRMSCodeunit obj = new HRMSCodeunitReference.HRMSCodeunit();
            obj = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
            return obj.ExportDisciplinaryDetailsPreview();
        }

        public static string ExportEmployeeTrainingDetails(string companyName)
        {
            HRMSCodeunitReference.HRMSCodeunit obj = new HRMSCodeunitReference.HRMSCodeunit();
            obj = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
            return obj.ExportEmployeeTrainingDetails();
        }

        public static string ExportAnnualInternalPerformance(string companyName)
        {
            HRMSCodeunitReference.HRMSCodeunit obj = new HRMSCodeunitReference.HRMSCodeunit();
            obj = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
            return obj.ExportAnnualInternalPerformance();
        }

        public static string ExportCourtCaseMonitoringDetails(string companyName)
        {
            HRMSCodeunitReference.HRMSCodeunit obj = new HRMSCodeunitReference.HRMSCodeunit();
            obj = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
            return obj.ExportCourtCaseMonitoringDetails();
        }

        public static string ExportRTIMonitoringDetails(string companyName)
        {
            HRMSCodeunitReference.HRMSCodeunit obj = new HRMSCodeunitReference.HRMSCodeunit();
            obj = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
            return obj.ExportRTIMonitoringDetails();
        }

        public static string ExportStaffAchivementDetails(string companyName)
        {
            HRMSCodeunitReference.HRMSCodeunit obj = new HRMSCodeunitReference.HRMSCodeunit();
            obj = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
            return obj.ExportStaffAchivementDetails();
        }

        public static string DownloadFinancialUpgradationApplication(int entryId, string hrmsID, string companyName)
        {
            HRMSCodeunitReference.HRMSCodeunit obj = new HRMSCodeunitReference.HRMSCodeunit();
            obj = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
            return obj.Download_Financial_Upgradation_Application(entryId, hrmsID);
        }

        public static string Download_Promotion_Order(int entryId, string companyName)
        {
            HRMSCodeunitReference.HRMSCodeunit obj = new HRMSCodeunitReference.HRMSCodeunit();
            obj = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
            return obj.Download_Promotion_Order(entryId);
        }

        public static string DownloadEmployeeTrainingHistoryCertificate(int entryId, string companyName)
        {
            HRMSCodeunitReference.HRMSCodeunit obj = new HRMSCodeunitReference.HRMSCodeunit();
            obj = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
            return obj.Download_Employee_Training_History_Certificate(entryId);
        }

        #endregion

        #region Fee Management
        public static string AddCourseFeeHeader(CourseFeeHeaderReference1.CourseFeeHeaderCard obj, string companyName)
        {
            try
            {
                CourseFeeHeaderReference1.CourseFeeHeaderCard_Service _obj_Binding = (CourseFeeHeaderReference1.CourseFeeHeaderCard_Service)Configuration
                    .getNavService(new CourseFeeHeaderReference1.CourseFeeHeaderCard_Service(), "CourseFeeHeaderCard", "Page", companyName);
                _obj_Binding.Create(ref obj);
                return ResultMessages.SuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string GetFeeDemand(string academicYear, string customerNo, string documentNo, string companyName)
        {
            FeeManagementCodeUnitReference2.FeeManagementCodeUnit obj = new FeeManagementCodeUnitReference2.FeeManagementCodeUnit();
            obj = (FeeManagementCodeUnitReference2.FeeManagementCodeUnit)Configuration
                .getNavService(new FeeManagementCodeUnitReference2.FeeManagementCodeUnit(), "FeeManagementCodeUnit", "Codeunit", companyName);
            var result = obj.FeeDemand(academicYear, customerNo, documentNo);
            return result;
        }

        public static string GetFeeGeneration(string academicYear, string semester, string feeClassification, string courseCode, string studentNo, string companyName)
        {
            try
            {
                FeeManagementCodeUnitReference2.FeeManagementCodeUnit obj = new FeeManagementCodeUnitReference2.FeeManagementCodeUnit();
                obj = (FeeManagementCodeUnitReference2.FeeManagementCodeUnit)Configuration
                    .getNavService(new FeeManagementCodeUnitReference2.FeeManagementCodeUnit(), "FeeManagementCodeUnit", "Codeunit", companyName);
                return obj.FeeGeneration(academicYear, semester, feeClassification, courseCode, studentNo);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string GetMoneyReceipt(string customerNo,  string companyName, string dcNo)
        {
            FeeManagementCodeUnitReference2.FeeManagementCodeUnit obj = new FeeManagementCodeUnitReference2.FeeManagementCodeUnit();
            obj = (FeeManagementCodeUnitReference2.FeeManagementCodeUnit)Configuration
                .getNavService(new FeeManagementCodeUnitReference2.FeeManagementCodeUnit(), "FeeManagementCodeUnit", "Codeunit", companyName);
            var result = obj.MoneyReceipt(customerNo, dcNo);
            return result;
        }

        public static string GetCustomerStatement(string customerNo,
                                                  string startDate,
                                                  string endDate,
                                                  bool showOverDueEntries,
                                                  bool includeAllCustomerWithLedgerEntry,
                                                  bool includeAllCustomerWithBalance,
                                                  bool includeReversedEntries,
                                                  bool includeUnappliedEntries,
                                                  bool includeAgingBand,
                                                  string periodLength,
                                                  int dateChoice,
                                                  bool logInteraction,
                                                  string companyName)
        {
            FeeManagementCodeUnitReference2.FeeManagementCodeUnit obj = new FeeManagementCodeUnitReference2.FeeManagementCodeUnit();
            obj = (FeeManagementCodeUnitReference2.FeeManagementCodeUnit)Configuration
                .getNavService(new FeeManagementCodeUnitReference2.FeeManagementCodeUnit(), "FeeManagementCodeUnit", "Codeunit", companyName);
            var result = obj.CustomerStatement(customerNo,
                                                   startDate,
                                                   endDate,
                                                   showOverDueEntries,
                                                   includeAllCustomerWithLedgerEntry,
                                                   includeAllCustomerWithBalance,
                                                   includeReversedEntries,
                                                   includeUnappliedEntries,
                                                   includeAgingBand,
                                                   periodLength,
                                                   dateChoice,
                                                   logInteraction);
            return result;
        }

        public static string GetAgingReport(string customerNo,
                                            string endDate,
                                            int agingBy,
                                            string periodLegth,
                                            bool printAmtInLCY,
                                            bool printDetails,
                                            int headingType,
                                            bool newPagePerCustomer,
                                            string companyName)
        {
            FeeManagementCodeUnitReference2.FeeManagementCodeUnit obj = new FeeManagementCodeUnitReference2.FeeManagementCodeUnit();
            obj = (FeeManagementCodeUnitReference2.FeeManagementCodeUnit)Configuration
                .getNavService(new FeeManagementCodeUnitReference2.FeeManagementCodeUnit(), "FeeManagementCodeUnit", "Codeunit", companyName);
            var result = obj.AgingReport(customerNo,
                                        endDate,
                                        agingBy,
                                        periodLegth,
                                        printAmtInLCY,
                                        printDetails,
                                        headingType,
                                        newPagePerCustomer);
            return result;
        }

        public static string GetCustomerTrialBalanceReport(string customerNo,
                                                    bool printAmountsInLCY,
                                                    bool printOnlyOnePerPage,
                                                    bool excludeBalanceOnly,
                                                    string companyName)
        {
            FeeManagementCodeUnitReference2.FeeManagementCodeUnit obj = new FeeManagementCodeUnitReference2.FeeManagementCodeUnit();
            obj = (FeeManagementCodeUnitReference2.FeeManagementCodeUnit)Configuration
                .getNavService(new FeeManagementCodeUnitReference2.FeeManagementCodeUnit(), "FeeManagementCodeUnit", "Codeunit", companyName);
            var result = obj.CustomerTrialBalance(customerNo, printAmountsInLCY, printOnlyOnePerPage, excludeBalanceOnly);
            return result;
        }

        public static string GetDayBookReport(bool lineNarration,
                                              bool voucherNaration,
                                              string documentNo,
                                              string fromDate,
                                              string toDate,
                                              string dimension1,
                                              string dimension2,
                                              string companyName)
        {
            FeeManagementCodeUnitReference2.FeeManagementCodeUnit obj = new FeeManagementCodeUnitReference2.FeeManagementCodeUnit();
            obj = (FeeManagementCodeUnitReference2.FeeManagementCodeUnit)Configuration
                .getNavService(new FeeManagementCodeUnitReference2.FeeManagementCodeUnit(), "FeeManagementCodeUnit", "Codeunit", companyName);
            var result = obj.DayBook(lineNarration, voucherNaration, documentNo, fromDate, toDate, dimension1, dimension2);
            return result;
        }
        public static string GetCashBookReport(bool printDetails,
                                            bool lineNarration,
                                            bool voucherNaration,
                                            string gLNo,
                                            string fromDate,
                                            string toDate,
                                            string dimension1,
                                            string dimension2,
                                            string companyName)
        {
            FeeManagementCodeUnitReference2.FeeManagementCodeUnit obj = new FeeManagementCodeUnitReference2.FeeManagementCodeUnit();
            obj = (FeeManagementCodeUnitReference2.FeeManagementCodeUnit)Configuration
                .getNavService(new FeeManagementCodeUnitReference2.FeeManagementCodeUnit(), "FeeManagementCodeUnit", "Codeunit", companyName);
            var result = obj.CashBook(printDetails, lineNarration, voucherNaration, gLNo, fromDate,toDate, dimension1, dimension2);
            return result;
        }
        public static string GetBankBookReport(bool printDetails,
                                            bool lineNarration,
                                            bool voucherNaration,
                                            string bankAccNo,
                                            string fromDate,
                                            string todate,
                                            string dimension1,
                                            string dimension2,
                                            string companyName)
        {
            FeeManagementCodeUnitReference2.FeeManagementCodeUnit obj = new FeeManagementCodeUnitReference2.FeeManagementCodeUnit();
            obj = (FeeManagementCodeUnitReference2.FeeManagementCodeUnit)Configuration
                .getNavService(new FeeManagementCodeUnitReference2.FeeManagementCodeUnit(), "FeeManagementCodeUnit", "Codeunit", companyName);
            var result = obj.BankBook(printDetails, lineNarration, voucherNaration, bankAccNo, fromDate,todate, dimension1, dimension2);
            return result;
        }

        #endregion

        #region Account Mangement
        public static void AddGeneralPayment(FeeGeneralPaymentReference.GeneralPayment obj, string companyName)
        {
            FeeGeneralPaymentReference.GeneralPayment_Service _obj_Binding = (FeeGeneralPaymentReference.GeneralPayment_Service)Configuration
                .getNavService(new FeeGeneralPaymentReference.GeneralPayment_Service(), "GeneralPayment", "Page", companyName);
            _obj_Binding.Create(ref obj);
        }

        public static void ApplyCautionMoney(string studentNo, string academicYear, string companyName)
        {
            AccountManagementReference.AccountManagement obj = new AccountManagementReference.AccountManagement();
            obj = (AccountManagementReference.AccountManagement)Configuration
                .getNavService(new AccountManagementReference.AccountManagement(), "AccountManagement", "Codeunit", companyName);
            obj.SubMitCautionMoney(studentNo, academicYear);
        }

        public static void GetLines(string refundSlNo, string academicYear, string companyName)
        {
            AccountManagementReference.AccountManagement obj = new AccountManagementReference.AccountManagement();
            obj = (AccountManagementReference.AccountManagement)Configuration
                .getNavService(new AccountManagementReference.AccountManagement(), "AccountManagement", "Codeunit", companyName);
            obj.GetLines(academicYear, refundSlNo);
        }

        public static string PostToJournal(String refundSlNo, string companyName)
        {
            FeeManagementCodeUnitReference2.FeeManagementCodeUnit objfm = new FeeManagementCodeUnitReference2.FeeManagementCodeUnit();
            objfm = (FeeManagementCodeUnitReference2.FeeManagementCodeUnit)Configuration
                .getNavService(new FeeManagementCodeUnitReference2.FeeManagementCodeUnit(), "FeeManagementCodeUnit", "Codeunit", companyName);
            return objfm.PostCautionRefundOrder(refundSlNo);
        }

        public static string UnpostedCautionMoneyReport(string refundSlNo, string companyName)
        {
            AccountManagementReference.AccountManagement obj = new AccountManagementReference.AccountManagement();
            obj = (AccountManagementReference.AccountManagement)Configuration
                .getNavService(new AccountManagementReference.AccountManagement(), "AccountManagement", "Codeunit", companyName);
            return obj.UnpostedCautionMoneyReport(refundSlNo);
        }

        public static string PostedCautionMoneyReport(string refundSlNo, string companyName)
        {
            AccountManagementReference.AccountManagement obj = new AccountManagementReference.AccountManagement();
            obj = (AccountManagementReference.AccountManagement)Configuration
                .getNavService(new AccountManagementReference.AccountManagement(), "AccountManagement", "Codeunit", companyName);
            return obj.PostedCautionMoneyReport(refundSlNo);
        }
        public static string CreateTransfer(TransferAccountReference.TransferAccount obj, string companyName)
        {
            try
            {
                TransferAccountReference.TransferAccount_Service _obj_Binding = (TransferAccountReference.TransferAccount_Service)Configuration
                .getNavService(new TransferAccountReference.TransferAccount_Service(), "TransferAccount", "Page", companyName);
                _obj_Binding.Create(ref obj);
                return ResultMessages.SuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string PostTransferAccount(string entryNo, string companyName)
        {
            try
            {
                AccountManagementReference.AccountManagement obj = new AccountManagementReference.AccountManagement();
                obj = (AccountManagementReference.AccountManagement)Configuration
                    .getNavService(new AccountManagementReference.AccountManagement(), "AccountManagement", "Codeunit", companyName);
                obj.PostTransferAccount(entryNo);
                return ResultMessages.SuccessfullMessage;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }


        public static void AddCautionRefundOrder(CautionRefundOrderReference.CautionRefundOrder obj, string companyName)
        {
            CautionRefundOrderReference.CautionRefundOrder_Service _obj_Binding = (CautionRefundOrderReference.CautionRefundOrder_Service)Configuration
                .getNavService(new CautionRefundOrderReference.CautionRefundOrder_Service(), "CautionRefundOrder", "Page", companyName);
            _obj_Binding.Create(ref obj);
        }

        public static void AddStudentFee(StudentFeeCollectionCardReference.StudentFeeCollectionCard obj, string companyName)
        {
            StudentFeeCollectionCardReference.StudentFeeCollectionCard_Service _obj_Binding = (StudentFeeCollectionCardReference.StudentFeeCollectionCard_Service)Configuration
                .getNavService(new StudentFeeCollectionCardReference.StudentFeeCollectionCard_Service(), "StudentFeeCollectionCard", "Page", companyName);
            _obj_Binding.Create(ref obj);
        }
        public static string PostingGeneralPayment(string paymentEntryNo, string companyName)
        {
            FeeManagementCodeUnitReference2.FeeManagementCodeUnit objfm = new FeeManagementCodeUnitReference2.FeeManagementCodeUnit();
            objfm = (FeeManagementCodeUnitReference2.FeeManagementCodeUnit)Configuration
                .getNavService(new FeeManagementCodeUnitReference2.FeeManagementCodeUnit(), "FeeManagementCodeUnit", "Codeunit", companyName);
            return objfm.PostGeneralPayment(paymentEntryNo);
        }
        public static String PostingStudentFeeCollection(string paymentEntryNo, string companyName)
        {
            FeeManagementCodeUnitReference2.FeeManagementCodeUnit objfm = new FeeManagementCodeUnitReference2.FeeManagementCodeUnit();
            objfm = (FeeManagementCodeUnitReference2.FeeManagementCodeUnit)Configuration
                .getNavService(new FeeManagementCodeUnitReference2.FeeManagementCodeUnit(), "FeeManagementCodeUnit", "Codeunit", companyName);
            return objfm.PostStudentFeeCollection(paymentEntryNo);
        }

        public static bool DeleteCautionRefundOrder(string refundSlNo, int lineNo, string companyName)
        {
            AccountManagementReference.AccountManagement obj = new AccountManagementReference.AccountManagement();
            obj = (AccountManagementReference.AccountManagement)Configuration
                .getNavService(new AccountManagementReference.AccountManagement(), "AccountManagement", "Codeunit", companyName);
            return obj.DeleteCautionRefundLine(refundSlNo, lineNo);
        }

        public static string UpdateCautionRefund(CautionRefundOrderReference.CautionRefundOrder input, string companyName)
        {
            CautionRefundOrderReference.CautionRefundOrder_Service _obj_Binding = (CautionRefundOrderReference.CautionRefundOrder_Service)Configuration
                .getNavService(new CautionRefundOrderReference.CautionRefundOrder_Service(), "CautionRefundOrder", "Page", companyName);
            CautionRefundOrderReference.CautionRefundOrder obj = new CautionRefundOrderReference.CautionRefundOrder();
            obj = _obj_Binding.Read(input.Refund_Sl_No);
            //obj.Book_Name = input.Book_Name;
            obj.Academic_Year = input.Academic_Year;
            obj.Posting_Date = input.Posting_Date;
            obj.Payment_Method = input.Payment_Method;

            _obj_Binding.Update(ref obj);
            return ResultMessages.UpdateSuccessfullMessage;
        }
        #endregion

        #region Library
        public static string UpdateBookDetails(BookCardReference1.BookCard input, string companyName)
        {
            BookCardReference1.BookCard_Service _obj_Binding = (BookCardReference1.BookCard_Service)Configuration
                .getNavService(new BookCardReference1.BookCard_Service(), "BookCard", "Page", companyName);
            BookCardReference1.BookCard obj = new BookCardReference1.BookCard();
            obj = _obj_Binding.Read(input.No);
            obj.Book_Name = input.Book_Name;
            obj.Author_Name = input.Author_Name;
            obj.Author_Name_2 = input.Author_Name_2;
            obj.Place__Publisher_Code = input.Place__Publisher_Code;
            obj.Book_Category_Code = input.Book_Category_Code;
            obj.No_of_Pages = input.No_of_Pages;
            obj.No_of_PagesSpecified = input.No_of_PagesSpecified;
            obj.Call_No = input.Call_No;
            obj.Shelf = input.Shelf;
            obj.Langauge = input.Langauge;
            obj.Book_Type = input.Book_Type;
            obj.Supplier_Name = input.Supplier_Name;
            obj.Unit_Cost = input.Unit_Cost;
            _obj_Binding.Update(ref obj);
            return ResultMessages.UpdateSuccessfullMessage;
        }
        public static void IssueBookcard(BookIssueCardReference.BookIssueCard obj, string companyName)
        {
            BookIssueCardReference.BookIssueCard_Service _obj_Binding = (BookIssueCardReference.BookIssueCard_Service)Configuration
                .getNavService(new BookIssueCardReference.BookIssueCard_Service(), "BookIssueCard", "Page", companyName);
            _obj_Binding.Create(ref obj);
        }

        public static void ReturnBook(string Entry_No, string companyName)
        {
            LibraryMgmtReference.LibraryMgmt _obj_Binding = new LibraryMgmtReference.LibraryMgmt();
            _obj_Binding = (LibraryMgmtReference.LibraryMgmt)Configuration
                .getNavService(new LibraryMgmtReference.LibraryMgmt(), "LibraryMgmt", "codeunit", companyName);
            _obj_Binding.Book_Return(Entry_No);
        }

        public static void ItemUpload(string fileName, string companyName)
        {
            LibraryMgmtReference.LibraryMgmt _obj_Binding = new LibraryMgmtReference.LibraryMgmt();
            _obj_Binding = (LibraryMgmtReference.LibraryMgmt)Configuration
                .getNavService(new LibraryMgmtReference.LibraryMgmt(), "LibraryMgmt", "codeunit", companyName);
            _obj_Binding.ItemUpload(fileName);
        }

        public static void CreateBookBatch(string itemCategory, string companyName)
        {
            LibraryMgmtReference.LibraryMgmt _obj_Binding = new LibraryMgmtReference.LibraryMgmt();
            _obj_Binding = (LibraryMgmtReference.LibraryMgmt)Configuration
                .getNavService(new LibraryMgmtReference.LibraryMgmt(), "LibraryMgmt", "codeunit", companyName);
            _obj_Binding.CreateBookBatch(itemCategory);
        }

        public static void ItemJournalBook(string filePath, string companyName)
        {
            LibraryMgmtReference.LibraryMgmt _obj_Binding = new LibraryMgmtReference.LibraryMgmt();
            _obj_Binding = (LibraryMgmtReference.LibraryMgmt)Configuration
                .getNavService(new LibraryMgmtReference.LibraryMgmt(), "LibraryMgmt", "codeunit", companyName);
            _obj_Binding.ItemJournalBook(filePath);
        }
        public static void BookRenewal(string Entry_No, string companyName)
        {
            LibraryMgmtReference.LibraryMgmt _obj_Binding = new LibraryMgmtReference.LibraryMgmt();
            _obj_Binding = (LibraryMgmtReference.LibraryMgmt)Configuration
                .getNavService(new LibraryMgmtReference.LibraryMgmt(), "LibraryMgmt", "codeunit", companyName);
            _obj_Binding.Book_Renewal(Entry_No);
        }
        public static void BookIssue(string Entry_No, string companyName)
        {
            LibraryMgmtReference.LibraryMgmt _obj_Binding = new LibraryMgmtReference.LibraryMgmt();
            _obj_Binding = (LibraryMgmtReference.LibraryMgmt)Configuration
                .getNavService(new LibraryMgmtReference.LibraryMgmt(), "LibraryMgmt", "codeunit", companyName);
            _obj_Binding.Book_Issue(Entry_No);
        }

        public static void AddBookToAccessionList(string bookNo, string companyName)
        {
            LibraryMgmtReference.LibraryMgmt _obj_Binding = new LibraryMgmtReference.LibraryMgmt();
            _obj_Binding = (LibraryMgmtReference.LibraryMgmt)Configuration
                .getNavService(new LibraryMgmtReference.LibraryMgmt(), "LibraryMgmt", "codeunit", companyName);
            _obj_Binding.AccessionList(bookNo);
        }

        public static void PostAccessionList(string bookNo, int lineNo, string companyName)
        {
            LibraryMgmtReference.LibraryMgmt _obj_Binding = new LibraryMgmtReference.LibraryMgmt();
            _obj_Binding = (LibraryMgmtReference.LibraryMgmt)Configuration
                .getNavService(new LibraryMgmtReference.LibraryMgmt(), "LibraryMgmt", "codeunit", companyName);
            _obj_Binding.AccessionPost(bookNo, lineNo);
        }


        public static string UpdateBookAccessionCard(BookAccessionReference.BookAccessionCard input, string companyName)
        {
            BookAccessionReference.BookAccessionCard_Service _obj_Binding = (BookAccessionReference.BookAccessionCard_Service)Configuration
                .getNavService(new BookAccessionReference.BookAccessionCard_Service(), "BookAccessionCard", "Page", companyName);
            BookAccessionReference.BookAccessionCard obj = new BookAccessionReference.BookAccessionCard();
            obj = _obj_Binding.Read(input.Book_No, input.Line_No);
            obj.Accession_No = input.Accession_No;
            obj.Location_Code = input.Location_Code;
            obj.Vendor_No = input.Vendor_No;
            _obj_Binding.Update(ref obj);
            return ResultMessages.UpdateSuccessfullMessage;
        }

        #endregion

        #region Infra
        public static void ImportLandFile(string filePathWithName, string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            obj.ImportLandFile(Path.Combine(filePathWithName));
        }

        public static string CreateLandRecord(InfraLandCardReference.LandCard obj, string companyName)
        {
            try
            {
                InfraLandCardReference.LandCard_Service _obj_Binding = (InfraLandCardReference.LandCard_Service)Configuration
                    .getNavService(new InfraLandCardReference.LandCard_Service(), "LandCard", "Page", companyName);
                _obj_Binding.Create(ref obj);
                return "Data Saved Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static void ImportPdfRoRFile(string khatianNumber, string filePath, string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            obj.Upload_Land_File(khatianNumber, filePath);
        }

        public static string ExportLandFile(string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            return obj.ExportLandDataDetails();
        }

        public static string ExportLandFileInPdf(string khatianNumber, string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            var returnValue = obj.Download_Land_File(khatianNumber);
            return returnValue;
        }

        public static string UpdateLandRecord(InfraLandCardReference.LandCard input, string companyName)
        {
            try
            {
                InfraLandCardReference.LandCard_Service _obj_Binding = (InfraLandCardReference.LandCard_Service)Configuration
                    .getNavService(new InfraLandCardReference.LandCard_Service(), "LandCard", "Page", companyName);
                InfraLandCardReference.LandCard obj = new InfraLandCardReference.LandCard();
                obj = _obj_Binding.Read(input.Khatian_Serial_No.ToString());

                obj.Land_Kisam = input.Land_Kisam;
                obj.Plot_No = input.Plot_No;
                obj.District = input.District;
                obj.Tahasil = input.Tahasil;
                obj.Village = input.Village;
                obj.RI_Circle = input.RI_Circle;
                obj.Land_Owner_Details = input.Land_Owner_Details;
                obj.Land_possessioner_Details = input.Land_possessioner_Details;
                obj.Land_Issue_Description = input.Land_Issue_Description;
                obj.Encroachment_Plot_No = input.Encroachment_Plot_No;
                obj.Encroachment_Plot_Area = input.Encroachment_Plot_Area;
                obj.Dispute_Plot_No = input.Dispute_Plot_No;
                obj.Dispute_Area = input.Dispute_Area;
                obj.CasePlot_No = input.CasePlot_No;

                _obj_Binding.Update(ref obj);
                return ResultMessages.UpdateSuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string Downlond_GeneralLand_Building_File(string primaryKey, string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            var returnValue = obj.Downlond_GeneralLand_Building_File(primaryKey);
            return returnValue;
        }

        public static void Upload_GB_Field_Photos(string filePath, string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            obj.Upload_GB_Field_Photos(filePath);
        }

        public static string Downlond_GB_Field_Photos(string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            var returnValue = obj.Downlond_GB_Field_Photos();
            return returnValue;
        }

        public static void Upload_GB_Sports_Court_photo(string filePath, string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            obj.Upload_GB_Sports_Court_photo(filePath);
        }

        public static string Downlond_GB_Sports_Court_photo(string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            var returnValue = obj.Downlond_GB_Sports_Court_photo();
            return returnValue;
        }

        public static void Upload_GB_Field_Gallery_photo(string filePath, string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            obj.Upload_GB_Field_Gallery_photo(filePath);
        }

        public static string Downlond_GB_Field_Gallery_photo(string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            var returnValue = obj.Downlond_GB_Field_Gallery_photo();
            return returnValue;
        }

        public static void Upload_GB_Conference_Room_photo(string filePath, string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            obj.Upload_GB_Conference_Room_photo(filePath);
        }

        public static string Downlond_GB_Conference_Room_photo(string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            var returnValue = obj.Downlond_GB_Conference_Room_photo();
            return returnValue;
        }

        public static void Upload_GB_Video_Conference_Room_photo(string filePath, string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            obj.Upload_GB_Video_Conference_Room_photo(filePath);
        }

        public static string Downlond_GB_Video_Conference_Room_photo(string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            var returnValue = obj.Downlond_GB_Video_Conference_Room_photo();
            return returnValue;
        }

        public static void Upload_GB_Library_Photos(string filePath, string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            obj.Upload_GB_Library_Photos(filePath);
        }

        public static string Downlond_GB_Library_Photos(string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            var returnValue = obj.Downlond_GB_Library_Photos();
            return returnValue;
        }

        public static void Upload_GB_Central_Library_Photos(string filePath, string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            obj.Upload_GB_Central_Library_Photos(filePath);
        }

        public static string Downlond_GB_Central_Library_Photos(string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            var returnValue = obj.Downlond_GB_Central_Library_Photos();
            return returnValue;
        }

        public static void Upload_GB_Main_Entrance_Photos(string filePath, string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            obj.Upload_GB_Main_Entrance_Photos(filePath);
        }

        public static string Downlond_GB_Main_Entrance_Photos(string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            var returnValue = obj.Downlond_GB_Main_Entrance_Photos();
            return returnValue;
        }

        public static void Upload_GB_Dispensary_Photos(string filePath, string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            obj.Upload_GB_Dispensary_Photos(filePath);
        }

        public static string Downlond_GB_Dispensary_Photos(string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            var returnValue = obj.Downlond_GB_Dispensary_Photos();
            return returnValue;
        }

        public static void Upload_GB_Staff_Common_Room_Photos(string filePath, string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            obj.Upload_GB_Staff_Common_Room_Photos(filePath);
        }

        public static string Downlond_GB_Staff_Common_Room_Photos(string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            var returnValue = obj.Downlond_GB_Staff_Common_Room_Photos();
            return returnValue;
        }

        public static void Upload_GB_Girls_Common_Room_Photos(string filePath, string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            obj.Upload_GB_Girls_Common_Room_Photos(filePath);
        }

        public static string Downlond_GB_Girls_Common_Room_Photos(string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            var returnValue = obj.Downlond_GB_Girls_Common_Room_Photos();
            return returnValue;
        }

        public static void Upload_GB_Boys_Common_Room_Photos(string filePath, string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            obj.Upload_GB_Boys_Common_Room_Photos(filePath);
        }

        public static string Downlond_GB_Boys_Common_Room_Photos(string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            var returnValue = obj.Downlond_GB_Boys_Common_Room_Photos();
            return returnValue;
        }

        public static void Upload_GB_Staff_Canteena47Cafeteria_Photos(string filePath, string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            obj.Upload_GB_Staff_Canteena47Cafeteria_Photos(filePath);
        }

        public static string Downlond_GB_Staff_Canteena47Cafeteria_Photos(string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            var returnValue = obj.Downlond_GB_Staff_Canteena47Cafeteria_Photos();
            return returnValue;
        }

        public static string CreateInstituteBuilding(InfraInstituteBuildingReference.InstituteBuildingCard obj, string companyName)
        {
            try
            {
                InfraInstituteBuildingReference.InstituteBuildingCard_Service _obj_Binding = (InfraInstituteBuildingReference.InstituteBuildingCard_Service)Configuration
                     .getNavService(new InfraInstituteBuildingReference.InstituteBuildingCard_Service(), "InstituteBuildingCard", "Page", companyName);
                _obj_Binding.Create(ref obj);
                return ResultMessages.SuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string CreateHostelBuilding(InfraHostelBuildingReference.HostelBuildingCard obj, string companyName)
        {
            try
            {
                InfraHostelBuildingReference.HostelBuildingCard_Service _obj_Binding = (InfraHostelBuildingReference.HostelBuildingCard_Service)Configuration
                    .getNavService(new InfraHostelBuildingReference.HostelBuildingCard_Service(), "HostelBuildingCard", "Page", companyName);
                _obj_Binding.Create(ref obj);
                return "Data Saved Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string CreateStaffQuarter(InfraStaffQuarterReference.StaffQuarterCard obj, string companyName)
        {
            try
            {
                InfraStaffQuarterReference.StaffQuarterCard_Service _obj_Binding = (InfraStaffQuarterReference.StaffQuarterCard_Service)Configuration
                    .getNavService(new InfraStaffQuarterReference.StaffQuarterCard_Service(), "StaffQuarterCard", "Page", companyName);
                _obj_Binding.Create(ref obj);
                return ResultMessages.SuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string CreateAuditorium(InfraAuditoriumBuildingReference.AuditoriumBuilding obj, string companyName)
        {
            try
            {
                InfraAuditoriumBuildingReference.AuditoriumBuilding_Service _obj_Binding = (InfraAuditoriumBuildingReference.AuditoriumBuilding_Service)Configuration
                    .getNavService(new InfraAuditoriumBuildingReference.AuditoriumBuilding_Service(), "AuditoriumBuilding", "Page", companyName);
                _obj_Binding.Create(ref obj);
                return ResultMessages.SuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string UpdateInstituteBuilding(InfraInstituteBuildingReference.InstituteBuildingCard input, string companyName)
        {
            try
            {
                InfraInstituteBuildingReference.InstituteBuildingCard_Service _obj_Binding = (InfraInstituteBuildingReference.InstituteBuildingCard_Service)Configuration
                    .getNavService(new InfraInstituteBuildingReference.InstituteBuildingCard_Service(), "InstituteBuildingCard", "Page", companyName);
                InfraInstituteBuildingReference.InstituteBuildingCard obj = new InfraInstituteBuildingReference.InstituteBuildingCard();

                obj = _obj_Binding.Read(input.Block_Code);

                obj.Block_Type_if_any = input.Block_Type_if_any;
                obj.No_Of_Class_Room = input.No_Of_Class_Room;
                obj.Total_Floor_Area_in_sqft = input.Total_Floor_Area_in_sqft;
                obj.Building_Width_in_meter = input.Building_Width_in_meter;
                obj.Fire_Safety_Status = input.Fire_Safety_Status;
                obj.Layout_Plan_No = input.Layout_Plan_No;
                obj.Electricity_Agency = input.Electricity_Agency;
                obj.Electricity_Load_in_KW = input.Electricity_Load_in_KW;
                obj.Source_Of_Water = input.Source_Of_Water;
                obj.PHD_Consumer_No = input.PHD_Consumer_No;
                obj.Block_Name_if_any = input.Block_Name_if_any;
                obj.No_Of_Floor = input.No_Of_Floor;
                obj.Building_Length_in_meter = input.Building_Length_in_meter;
                obj.Building_Height_in_meter = input.Building_Height_in_meter;
                obj.Fire_Safety_Valid_Upto = input.Fire_Safety_Valid_Upto;
                obj.Approval_Status = input.Approval_Status;
                obj.Book_Of_Account = input.Book_Of_Account;
                obj.Electricity_Consumer_No = input.Electricity_Consumer_No;
                obj.Transformer_Type = input.Transformer_Type;
                obj.Building_Safety_Status = input.Building_Safety_Status;
                _obj_Binding.Update(ref obj);
                return ResultMessages.UpdateSuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string UpdateHostelBuilding(InfraHostelBuildingReference.HostelBuildingCard input, string companyName)
        {
            try
            {
                InfraHostelBuildingReference.HostelBuildingCard_Service _obj_Binding = (InfraHostelBuildingReference.HostelBuildingCard_Service)Configuration
                    .getNavService(new InfraHostelBuildingReference.HostelBuildingCard_Service(), "HostelBuildingCard", "Page", companyName);
                InfraHostelBuildingReference.HostelBuildingCard obj = new InfraHostelBuildingReference.HostelBuildingCard();

                obj = _obj_Binding.Read(input.Block_Code);
                obj.Hostel_Type = input.Hostel_Type;
                obj.Block_Name = input.Block_Name;
                obj.No_Of_Room = input.No_Of_Room;
                obj.No_Of_Floor = input.No_Of_Floor;
                obj.Total_Capacity = input.Total_Capacity;
                obj.Building_Length = input.Building_Length;
                obj.Building_Breadth_in_meter = input.Building_Breadth_in_meter;
                obj.Building_Height = input.Building_Height;
                obj.Fire_Safety_Status = input.Fire_Safety_Status;
                obj.Fire_Safety_Valid_Upto = input.Fire_Safety_Valid_Upto;
                obj.Layout_Plan_No = input.Layout_Plan_No;
                obj.Approval_Status = input.Approval_Status;
                obj.Electricity_Agency = input.Electricity_Agency;
                obj.Book_Of_Account = input.Book_Of_Account;
                obj.Electricity_Load_in_KW = input.Electricity_Load_in_KW;
                obj.Electricity_Consumer_No = input.Electricity_Consumer_No;
                obj.Source_Of_Water = input.Source_Of_Water;
                obj.Transformer_Type = input.Transformer_Type;
                obj.PHD_Consumer_No = input.PHD_Consumer_No;
                obj.Building_Safety_Status = input.Building_Safety_Status;
                _obj_Binding.Update(ref obj);
                return ResultMessages.UpdateSuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string UpdateStaffQuarter(InfraStaffQuarterReference.StaffQuarterCard input, string companyName)
        {
            try
            {
                InfraStaffQuarterReference.StaffQuarterCard_Service _obj_Binding = (InfraStaffQuarterReference.StaffQuarterCard_Service)Configuration
                    .getNavService(new InfraStaffQuarterReference.StaffQuarterCard_Service(), "StaffQuarterCard", "Page", companyName);
                InfraStaffQuarterReference.StaffQuarterCard obj = new InfraStaffQuarterReference.StaffQuarterCard();

                obj = _obj_Binding.Read(input.Quarter_Code);
                obj.Quarter_Type = input.Quarter_Type;
                obj.Quarter_Block_Name = input.Quarter_Block_Name;
                obj.No_Of_Room = input.No_Of_Room;
                obj.No_Of_Floor = input.No_Of_Floor;
                obj.Total_Floor_Area_in_sqft = input.Total_Floor_Area_in_sqft;
                //obj.capacity = Convert.ToInt32(txtStaffHostelCapacity.Text),
                obj.Building_Length = input.Building_Length;
                obj.Building_Breadth_in_Meter = input.Building_Breadth_in_Meter;
                obj.Building_Height = input.Building_Height;
                obj.Fire_Safety_Status = input.Fire_Safety_Status;
                obj.Fire_Safety_Valid_Upto = input.Fire_Safety_Valid_Upto;
                obj.Electricity_Connection_Status = input.Electricity_Connection_Status;
                obj.Layout_Plan_No = input.Layout_Plan_No;
                obj.Approval_Status = input.Approval_Status;
                obj.Electricity_Agency = input.Electricity_Agency;
                obj.Book_Of_Account = input.Book_Of_Account;
                obj.Electricity_Load_in_KW = input.Electricity_Load_in_KW;
                obj.Electricity_Consumer_No = input.Electricity_Consumer_No;
                obj.Source_Of_Water = input.Source_Of_Water;
                obj.Transformer_Type = input.Transformer_Type;
                obj.PHD_Consumer_No = input.PHD_Consumer_No;
                obj.Building_Safety_Status = input.Building_Safety_Status;
                obj.Occupancy_Status = input.Occupancy_Status;

                _obj_Binding.Update(ref obj);
                return ResultMessages.UpdateSuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string UpdateAuditorium(InfraAuditoriumBuildingReference.AuditoriumBuilding input, string companyName)
        {
            try
            {
                InfraAuditoriumBuildingReference.AuditoriumBuilding_Service _obj_Binding = (InfraAuditoriumBuildingReference.AuditoriumBuilding_Service)Configuration
                    .getNavService(new InfraAuditoriumBuildingReference.AuditoriumBuilding_Service(), "AuditoriumBuilding", "Page", companyName);
                InfraAuditoriumBuildingReference.AuditoriumBuilding obj = new InfraAuditoriumBuildingReference.AuditoriumBuilding();

                obj = _obj_Binding.Read(input.Building_Code);

                obj.Total_Capacity = input.Total_Capacity;
                obj.Total_Floor_Area_in_sqft = input.Total_Floor_Area_in_sqft;
                obj.Building_Length = input.Building_Length;
                obj.Building_Breadth_in_Meter = input.Building_Breadth_in_Meter;
                obj.Building_Height = input.Building_Height;
                obj.Fire_Safety_Status = input.Fire_Safety_Status;
                obj.Fire_Safety_Valid_Upto = input.Fire_Safety_Valid_Upto;
                obj.Layout_Plan_No = input.Layout_Plan_No;
                obj.Approval_Status = input.Approval_Status;
                obj.Electricity_Agency = input.Electricity_Agency;
                obj.Book_Of_Account = input.Book_Of_Account;
                obj.Electricity_Load_in_KW = input.Electricity_Load_in_KW;
                obj.Electricity_Consumer_No = input.Electricity_Consumer_No;
                obj.Building_Safety_Status = input.Building_Safety_Status;

                _obj_Binding.Update(ref obj);
                return ResultMessages.UpdateSuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static void Upload_Hostel_Buliding_File(string blockCode, string fileName, string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            obj.Upload_Hostel_Buliding_File(blockCode, fileName);
        }

        public static string Download_Hostel_Building_File(string blockCode, string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            var returnValue = obj.Download_Hostel_Building_File(blockCode);
            return returnValue;
        }

        public static string Download_Auditorium_Building_File(string buildingCode, string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            var returnValue = obj.Download_Auditorium_Building_File(buildingCode);
            return returnValue;
        }

        public static void Upload_Auditorium_Buliding_File(string buildingCode, string fileName, string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            obj.Upload_Auditorium_Buliding_File(buildingCode, fileName);
        }

        public static void Upload_Institute_Buliding_File(string blockCode, string fileName, string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            obj.Upload_Institute_Buliding_File(blockCode, fileName);
        }
        public static string Download_Institutional_File(string blockCode, string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            var returnValue = obj.Download_Institutional_File(blockCode);
            return returnValue;
        }

        public static void Upload_Staff_Buliding_File(string quarterCode, string fileName, string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            obj.Upload_Staff_Buliding_File(quarterCode, fileName);
        }

        public static string Download_Staff_Building_File(string blockCode, string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            var returnValue = obj.Download_Staff_Building_File(blockCode);
            return returnValue;
        }

        public static string ExportInstitutionalBuilding(string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            return obj.ExportInstitutionalBuilding();
        }
        public static string ExportHostelBuilding(string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            return obj.ExportHostelBuilding();
        }
        public static string ExportStaffQuarter(string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            return obj.ExportStaffBuilding();
        }

        public static string ExportAuditoriumBuilding(string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            return obj.ExportAuditoriumBuilding();
        }

        public static string CreateImprovementProject(InfraImprovementprojectReference.Improvementprojectcard obj, string companyName)
        {
            try
            {
                InfraImprovementprojectReference.Improvementprojectcard_Service _obj_Binding = (InfraImprovementprojectReference.Improvementprojectcard_Service)Configuration
                    .getNavService(new InfraImprovementprojectReference.Improvementprojectcard_Service(), "Improvementprojectcard", "Page", companyName);
                _obj_Binding.Create(ref obj);
                return ResultMessages.SuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string CreateOngoingProject(InfraOngoingprojectReference.Ongoingprojectcard obj, string companyName)
        {
            try
            {
                InfraOngoingprojectReference.Ongoingprojectcard_Service _obj_Binding = (InfraOngoingprojectReference.Ongoingprojectcard_Service)Configuration
                    .getNavService(new InfraOngoingprojectReference.Ongoingprojectcard_Service(), "Ongoingprojectcard", "Page", companyName);
                _obj_Binding.Create(ref obj);
                return ResultMessages.SuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string CreateNewProject(InfraNewprojectReference.Newprojectcard obj, string companyName)
        {
            try
            {
                InfraNewprojectReference.Newprojectcard_Service _obj_Binding = (InfraNewprojectReference.Newprojectcard_Service)Configuration
                    .getNavService(new InfraNewprojectReference.Newprojectcard_Service(), "Newprojectcard", "Page", companyName);
                _obj_Binding.Create(ref obj);
                return ResultMessages.SuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string DownloadProjectFile(int projectType, string projectCode, string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            return obj.Download_Project_File(projectType, projectCode);
        }

        public static void UploadProjectFile(int projectType, string projectCode, string filePath, string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            obj.Upload_Project_File(projectType, projectCode, filePath);
        }

        public static string AddProjectProgressDeatils(InfraProjectprogressdetailsReference.Projectprogressdetailscard input, string companyName)
        {
            try
            {
                var result = string.Empty;
                return CreateProjectProgress(input, companyName);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string CreateProjectProgress(InfraProjectprogressdetailsReference.Projectprogressdetailscard obj, string companyName)
        {
            try
            {
                InfraProjectprogressdetailsReference.Projectprogressdetailscard_Service _obj_Binding =
                    (InfraProjectprogressdetailsReference.Projectprogressdetailscard_Service)Configuration
                    .getNavService(new InfraProjectprogressdetailsReference.Projectprogressdetailscard_Service(), "Projectprogressdetailscard", "Page", companyName);
                _obj_Binding.Create(ref obj);
                return ResultMessages.SuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string CreateProjectEstimate(InfraEstimatePrepReference.EstimatePrepCard obj, string companyName)
        {
            try
            {
                InfraEstimatePrepReference.EstimatePrepCard_Service _obj_Binding = (InfraEstimatePrepReference.EstimatePrepCard_Service)Configuration
                    .getNavService(new InfraEstimatePrepReference.EstimatePrepCard_Service(), "EstimatePrepCard", "Page", companyName);
                _obj_Binding.Create(ref obj);
                return ResultMessages.SuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string CreateSecurityService(InfraServiceReference.ServiceCard obj, string companyName)
        {
            try
            {
                InfraServiceReference.ServiceCard_Service _obj_Binding = (InfraServiceReference.ServiceCard_Service)Configuration
                    .getNavService(new InfraServiceReference.ServiceCard_Service(), "ServiceCard", "Page", companyName);
                _obj_Binding.Create(ref obj);
                return ResultMessages.SuccessfullMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string ExportSecurityFile(string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            return obj.ExportServiceMonitoring();
        }

        public static string CreateMaintainceAndAMC(InfraAMCReference.AMCCard obj, string companyName)
        {
            try
            {
                InfraAMCReference.AMCCard_Service _obj_Binding = (InfraAMCReference.AMCCard_Service)Configuration
                    .getNavService(new InfraAMCReference.AMCCard_Service(), "AMCCard", "Page", companyName);
                _obj_Binding.Create(ref obj);
                return "Data Saved Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string ExportAMCAndMaintenanceFile(string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            return obj.ExportMaintanenceAndAMC();
        }


        #endregion

        #region DTET Report services
        public static string ExportDTETEstimatePreparationMonitoring(string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            return obj.ExportDTETEstimatePreparationMonitoring();
        }

        public static string ExportDTETAuditoriumBuilding(string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            return obj.ExportDTETAuditoriumBuilding();
        }

        public static string ExportDTETHostelBuilding(string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            return obj.ExportDTETHostelBuilding();
        }

        public static string ExportDTETInstitutionalBuilding(string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            return obj.ExportDTETInstitutionalBuilding();
        }

        public static string ExportDTETStaffBuilding(string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            return obj.ExportDTETStaffBuilding();
        }

        public static string ExportDTETLandDataDetails(string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            return obj.ExportDTETLandDataDetails();
        }

        public static string ExportDTETMaintanenceAndAMC(string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            return obj.ExportDTETMaintanenceAndAMC();
        }

        public static string ExportDTETProjectProgressDetails(string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            return obj.ExportDTETProjectProgressDetails();
        }

        public static string ExportDtetServiceMonitoring(string companyName)
        {
            InfraCodeunitReference.InfraCodeunit obj = new InfraCodeunitReference.InfraCodeunit();
            obj = (InfraCodeunitReference.InfraCodeunit)Configuration
                .getNavService(new InfraCodeunitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit", companyName);
            return obj.ExportDTETServiceMonitoring();
        }




        #endregion

        #region HRMS report
        public static string ExportDtetEmployeeList(string companyName)
        {
            HRMSCodeunitReference.HRMSCodeunit obj = new HRMSCodeunitReference.HRMSCodeunit();
            obj = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
            return obj.ExportDTETEmployeeList();
        }

        public static string ExportDtetTransferDetails(string companyName)
        {
            HRMSCodeunitReference.HRMSCodeunit obj = new HRMSCodeunitReference.HRMSCodeunit();
            obj = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
            return obj.ExportDTETTransferDetails();
        }

        public static string ExportDtetPromotionDetails(string companyName)
        {
            HRMSCodeunitReference.HRMSCodeunit obj = new HRMSCodeunitReference.HRMSCodeunit();
            obj = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
            return obj.ExportDTETPromotionDetails();
        }
        public static string ExportDtetAnualEstPartA(string companyName)
        {
            HRMSCodeunitReference.HRMSCodeunit obj = new HRMSCodeunitReference.HRMSCodeunit();
            obj = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
            return obj.ExportDTETAnnualEstablishmentPartA();
        }

        public static string ExportDtetStafProfile(string companyName)
        {
            HRMSCodeunitReference.HRMSCodeunit obj = new HRMSCodeunitReference.HRMSCodeunit();
            obj = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
            return obj.ExportDTETStaffProfileDetails();
        }
        public static string ExportDtetAnualEstPartC(string companyName)
        {
            HRMSCodeunitReference.HRMSCodeunit obj = new HRMSCodeunitReference.HRMSCodeunit();
            obj = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
            return obj.ExportDTETAnnualEstablishmentPartC();
        }
        public static string ExportDtetAnualEstPartE(string companyName)
        {
            HRMSCodeunitReference.HRMSCodeunit obj = new HRMSCodeunitReference.HRMSCodeunit();
            obj = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
            return obj.ExportDTETAnnualEstablishmentPartE();
        }
        public static string ExportDtetAnualPerformance(string companyName)
        {
            HRMSCodeunitReference.HRMSCodeunit obj = new HRMSCodeunitReference.HRMSCodeunit();
            obj = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
            return obj.ExportDTETAnnualPerformanceDetails();
        }
        public static string ExportDtetFinanceUpgrade(string companyName)
        {
            HRMSCodeunitReference.HRMSCodeunit obj = new HRMSCodeunitReference.HRMSCodeunit();
            obj = (HRMSCodeunitReference.HRMSCodeunit)Configuration
                .getNavService(new HRMSCodeunitReference.HRMSCodeunit(), "HRMSCodeunit", "Codeunit", companyName);
            return obj.ExportDTETFinancialUpgradationDetails();
        }
        #endregion



        public static string ExportLibrary(string companyName)
        {
            LibraryCodeunitReference.LibraryCodeunit obj = new LibraryCodeunitReference.LibraryCodeunit();
            obj = (LibraryCodeunitReference.LibraryCodeunit)Configuration
                .getNavService(new LibraryCodeunitReference.LibraryCodeunit(), "LibraryCodeunit", "Codeunit", companyName);
            return obj.DTETBookDetails();
        }
        public static string ResetUserPassword(UserAuthenticationCardReference.UserAuthenticationCard input, string companyName)
        {
            UserAuthenticationCardReference.UserAuthenticationCard_Service _obj_Binding = (UserAuthenticationCardReference.UserAuthenticationCard_Service)Configuration
                .getNavService(new UserAuthenticationCardReference.UserAuthenticationCard_Service(), "UserAuthenticationCard", "Page", companyName);
            UserAuthenticationCardReference.UserAuthenticationCard obj = new UserAuthenticationCardReference.UserAuthenticationCard();
            obj = _obj_Binding.Read(input.User_Name);
            //obj.Book_Name = input.Book_Name;
            obj.Password = input.Password;

            _obj_Binding.Update(ref obj);
            return ResultMessages.UpdateSuccessfullMessage;
        }

        public static void LogSessionData(string userId, string sessionId, DateTime loginTime, string companyName)
        {
            PortalFunctionReference.PortalFunction obj = new PortalFunctionReference.PortalFunction();
            obj = (PortalFunctionReference.PortalFunction)Configuration
                .getNavService(new PortalFunctionReference.PortalFunction(), "PortalFunction", "Codeunit", companyName);
            obj.CreateLoginRegister(userId, sessionId, loginTime);
        }

        public static void UpdateSessionData(string userId, string sessionId, DateTime logOutTime, string companyName)
        {
            PortalFunctionReference.PortalFunction obj = new PortalFunctionReference.PortalFunction();
            obj = (PortalFunctionReference.PortalFunction)Configuration
                .getNavService(new PortalFunctionReference.PortalFunction(), "PortalFunction", "Codeunit", companyName);
            obj.UpdateLoginRegister(userId, sessionId, logOutTime);
        }
    }
}
