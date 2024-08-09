<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportManagement.aspx.cs" Inherits="HRMS.ReportManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Report Management</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="assets/vendor/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="assets/vendor/css/common.css" rel="stylesheet" />
    <link href="assets/vendor/css/style.css" rel="stylesheet" />
    <link href="assets/vendor/css/font-awesome.min.css" rel="stylesheet" />
    <link href="assets/vendor/css/ch-pie-line.css" rel="stylesheet" />
    <link href="assets/vendor/css/bootstrap-multiselect.css" rel="stylesheet" />
    <script src="assets/vendor/js/jsapi.js"></script>
    <link rel="stylesheet" href="assets/toastr/toastr.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <link rel="stylesheet" href="assets/toastr/toastr.min.css" />
    <script src="assets/plugins/jquery-ui/jquery-ui-1.10.2.custom.min.js"></script>
    <script src="assets/toastr/toastr.min.js"></script>

    <style>
        .summary-box {
            margin: 4%;
            height: auto;
            text-align: center;
            box-shadow: 0 3px 6px rgba(0, 0, 0, 0.16), 0 3px 6px rgba(0, 0, 0, 0.23);
            border: 1px solid;
        }

        p.Introduction {
            float: left;
            color: black;
            padding: 23px;
            text-transform: uppercase;
            font-weight: 700;
        }

        .row.md-12.marginx {
            margin-left: 3%;
            margin-right: 2%;
            margin-bottom: 7%;
            padding-bottom: 47px;
            border-bottom: 3px solid black;
        }

        i.fal.fa-plus-circle.full {
            font-size: 52px;
            float: right;
            margin: 6px;
        }


        .btn-s.float-right {
            float: right;
            background: white;
            width: 72px;
            height: 31px;
        }

        .form-control {
            height: 33px;
            margin: 2px 0;
            font-size: 13px;
            background-color: white;
            color: #000;
            font-weight: 700;
            border: 1px solid #7f7e7e;
        }

        select.form-control {
            background-color: white;
        }

        .col-md-6.Buliding {
            border-bottom: 1px solid;
            padding: 20px;
        }

        h3.hadingline {
            color: black;
            font-size: 20px;
        }

        .btn-s.float-right.submit {
            background: black;
            color: white;
        }

        .col-lg-12.col-md-12.summary-box {
            margin: 94px 10px 10px -113px;
        }

        div.containerList {
            text-align: center;
        }

        ul.myUL {
            display: inline-block;
            text-align: left;
            float: left;
            line-height: 2.5rem;
            font-weight: 600;
            padding: 2%;
        }

        .modal-dialog {
            width: 100%;
            height: 420px;
            margin: 0;
            padding: 0;
            padding: 4%;
        }

        .modal-content {
            height: auto;
            min-height: 420px;
            border-radius: 0;
        }

        .modal-body {
            overflow-y: scroll;
            overflow-x: scroll;
            height: 400px;
        }

        .modal-header {
            height: 39px !important;
            text-align: center;
            vertical-align: middle;
            padding: 5px !important;
        }

        .modal-footer {
            padding: 5px !important;
        }
    </style>
    <script>
        function customAlert(msgType, txtMSG) {
            msgType = msgType.toUpperCase()

            if (msgType == "S") {
                showSuccess(txtMSG);
                return false;
            }

            if (msgType == "W") {
                showWarning(txtMSG);
                return false;
            }

            if (msgType == "E") {
                showError(txtMSG);
                return false;
            }

            if (msgType == "I") {
                showInfo(txtMSG);
                return false;
            }
        }

        //Tostr Notification implementation Start !!!!
        //Success!!!
        function showSuccess(msg) {
            toastr.options = {
                "closeButton": true,
                "progressBar": true,
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut",
                "positionClass": "toast-top-right"
            }
            toastr.success(msg, "Success");
            return false;
        }

        //Information!!!
        function showInfo(msg) {
            toastr.options = {
                "closeButton": true,
                "progressBar": true,
                "positionClass": "toast-top-right",
                "closeDuration": "60000"
            }
            toastr.info(msg, "Information");
            return false;
        }

        //Warning!!!
        function showWarning(msg) {
            toastr.options = {
                "closeButton": true,
                "progressBar": true,
                "positionClass": "toast-top-right"
            }
            toastr.warning(msg, "Warning");
            return false;
        }

        //Error!!!
        function showError(msg) {
            toastr.options = {
                "closeButton": true,
                "progressBar": true,
                "positionClass": "toast-top-right"
            }
            toastr.error(msg, "Error");
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">


        <div class="container">

            <div class="row">
                <div style="float: right; padding: 15px">
                    <asp:LinkButton ID="btnHome" CssClass="fa fa-arrow-left fa-3x btn btn-primary hBack float-right " OnClick="btnHome_OnClick" runat="server"> Back</asp:LinkButton>
                </div>
                <div class="summary-box">

                    <p class="NewEntry">Report Management</p>
                    <div class="row">

                        <ul class="nav nav-tabs" style="margin-left: 2%; margin-right: 2%; font-size: 15px; font-weight: 700;">
                            <li class="nav-item active"><a data-toggle="tab" href="#InfraReport">Infra Report</a></li>
                            <li class="nav-item"><a data-toggle="tab" href="#HRMSReport">HRMS Report</a></li>
                            <li class="nav-item"><a data-toggle="tab" href="#LibraryReport">Library Report</a></li>
                            <li class="nav-item"><a data-toggle="tab" href="#DtetReport">DTE&T Accounts Report</a></li>
                        </ul>

                        <div class="tab-content">
                            <div id="InfraReport" class="tab-pane fade in active">
                                <div class="row md-12 marginx">
                                    <div class="containerList">
                                        <ul class="myUL">
                                            <li>
                                                <asp:LinkButton ID="LinkButton1" OnClick="btnEstimatePreparation_Click" runat="server">Download DTET Estimate Preparation Monitoring Report</asp:LinkButton>
                                                <i class="fa fa-download" aria-hidden="true" style="font-size: 16px; color: #105be6;"></i>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton2" OnClick="btnAuditoriumBuilding_Click" runat="server">Download DTET Auditorium Building Report</asp:LinkButton>
                                                <i class="fa fa-download" aria-hidden="true" style="font-size: 16px; color: #105be6;"></i></li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton3" OnClick="btnHostelBuilding_Click" runat="server">Download DTET Hostel Building Report</asp:LinkButton>
                                                <i class="fa fa-download" aria-hidden="true" style="font-size: 16px; color: #105be6;"></i></li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton4" OnClick="btnInstitutionalBuilding_Click" runat="server">Download DTET Institutional Building Report</asp:LinkButton>
                                                <i class="fa fa-download" aria-hidden="true" style="font-size: 16px; color: #105be6;"></i></li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton5" OnClick="btnStaffBuilding_Click" runat="server">Download DTET Staff Building Report</asp:LinkButton>
                                                <i class="fa fa-download" aria-hidden="true" style="font-size: 16px; color: #105be6;"></i></li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton6" OnClick="btnLandDataDetail_Click" runat="server">Download DTET Land Data Details Report</asp:LinkButton>
                                                <i class="fa fa-download" aria-hidden="true" style="font-size: 16px; color: #105be6;"></i></li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton7" OnClick="btnMaintanenceAndAMC_Click" runat="server">Download DTET Maintanence And AMC Report</asp:LinkButton>
                                                <i class="fa fa-download" aria-hidden="true" style="font-size: 16px; color: #105be6;"></i></li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton8" OnClick="btnProjectProgressDetail_Click" runat="server">Download DTET Project Progress Details Report</asp:LinkButton>
                                                <i class="fa fa-download" aria-hidden="true" style="font-size: 16px; color: #105be6;"></i></li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton9" OnClick="btnServiceMonitoring_Click" runat="server">Download DTET Service Monitoring Report</asp:LinkButton>
                                                <i class="fa fa-download" aria-hidden="true" style="font-size: 16px; color: #105be6;"></i></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>

                            <div id="HRMSReport" class="tab-pane fade">
                                <div class="row md-12 marginx">
                                    <div class="containerList">
                                        <ul class="myUL">
                                            <li>
                                                <asp:LinkButton ID="btnEmployeLst" OnClick="btnEmployeLst_OnClick" runat="server">Download DTET Employee List Report
                                                </asp:LinkButton>
                                                <i class="fa fa-download" aria-hidden="true" style="font-size: 16px; color: #105be6; display: inline-block !important"></i>

                                                <button runat="server" id="btnViewEmployeLst" class="btn btn-mini" onserverclick="btnViewEmployeLst_ServerClick" title="Search">
                                                    <i class="fa fa-eye" aria-hidden="true" style="font-size: 16px; color: #105be6; display: inline-block !important"></i>
                                                </button>

                                            </li>
                                            <li>
                                                <asp:LinkButton ID="btnStafProfile" OnClick="btnStafProfile_OnClick" runat="server">Download DTET Staff Profile Details
                                                    Report</asp:LinkButton>
                                                <i class="fa fa-download" aria-hidden="true" style="font-size: 16px; color: #105be6;"></i></li>
                                            <li>
                                                <asp:LinkButton ID="btnAnualEstA" OnClick="btnAnualEstA_OnClick" runat="server">Download DTET Annual Est. Part A
                                                    Report</asp:LinkButton>
                                                <i class="fa fa-download" aria-hidden="true" style="font-size: 16px; color: #105be6;"></i></li>
                                            <li>
                                                <asp:LinkButton ID="btnAnualEstC" OnClick="btnAnualEstC_OnClick" runat="server">Download DTET Annual Est. Part C
                                                    Report</asp:LinkButton>
                                                <i class="fa fa-download" aria-hidden="true" style="font-size: 16px; color: #105be6;"></i></li>
                                            <li>
                                                <asp:LinkButton ID="btnAnualEstE" OnClick="btnAnualEstE_OnClick" runat="server">Download DTET Annual Est. Part E Report</asp:LinkButton>
                                                <i class="fa fa-download" aria-hidden="true" style="font-size: 16px; color: #105be6;"></i></li>
                                            <li>
                                                <asp:LinkButton ID="btnAnualPerformnc" OnClick="btnAnualPerformnc_OnClick" runat="server">Download DTET Annual Performance Details
                                                    Report</asp:LinkButton>
                                                <i class="fa fa-download" aria-hidden="true" style="font-size: 16px; color: #105be6;"></i></li>
                                            <li>
                                                <asp:LinkButton ID="btnEmpTransfr" OnClick="btnEmpTransfr_OnClick" runat="server">Download DTET Employee Transfer Application details
                                                    Report</asp:LinkButton>
                                                <i class="fa fa-download" aria-hidden="true" style="font-size: 16px; color: #105be6;"></i></li>
                                            <li>
                                                <asp:LinkButton ID="btnEmpPromotion" OnClick="btnEmpPromotion_OnClick" runat="server">Download DTET Employee Promotion details
                                                    Report</asp:LinkButton>
                                                <i class="fa fa-download" aria-hidden="true" style="font-size: 16px; color: #105be6;"></i></li>
                                            <li>
                                                <asp:LinkButton ID="btnFinanceUpgrade" OnClick="btnFinanceUpgrade_OnClick" runat="server">Download DTET Financial Upgradation details Report</asp:LinkButton>
                                                <i class="fa fa-download" aria-hidden="true" style="font-size: 16px; color: #105be6;"></i></li>
                                             <li>
                                                <asp:LinkButton ID="lbEmployeeList" OnClick="lbEmployeeList_Click" runat="server">DTE&T HRMS Employees Query page</asp:LinkButton>
                                                <i class="fa fa-download" aria-hidden="true" style="font-size: 16px; color: #105be6;"></i></li>

                                        </ul>
                                    </div>
                                </div>
                            </div>


                            <div id="LibraryReport" class="tab-pane fade">
                                <div class="row md-12 marginx">
                                    <div class="containerList">
                                        <ul class="myUL">
                                            <li>
                                                <asp:LinkButton ID="lbLibrary" OnClick="lbLibrary_Click" runat="server">Download Library List Report
                                                </asp:LinkButton>
                                                <i class="fa fa-download" aria-hidden="true" style="font-size: 16px; color: #105be6;"></i>
                                            </li>


                                        </ul>
                                    </div>
                                </div>
                            </div>

                            <div id="DtetReport" class="tab-pane fade">
                                <div class="row md-12 marginx">
                                    <div class="containerList">
                                        <ul class="myUL">
                                            <li>
                                                <asp:LinkButton ID="lbdaybookdtet" OnClick="lbdaybookdtet_Click" runat="server">Download Day Book Report
                                                </asp:LinkButton>
                                                <i class="fa fa-download" aria-hidden="true" style="font-size: 16px; color: #105be6;"></i>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lbdailyreceiptdtet" OnClick="lbdailyreceiptdtet_Click" runat="server">Download Receipts Report
                                                </asp:LinkButton>
                                                <i class="fa fa-download" aria-hidden="true" style="font-size: 16px; color: #105be6;"></i>
                                            </li>

                                            <li>
                                                <asp:LinkButton ID="lbdailypaymentdtet" OnClick="lbdailypaymentdtet_Click" runat="server">Download Payments Report
                                                </asp:LinkButton>
                                                <i class="fa fa-download" aria-hidden="true" style="font-size: 16px; color: #105be6;"></i>
                                            </li>



                                        </ul>
                                    </div>
                                </div>
                            </div>



                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade modal-fullscreen" id="myModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Report</h5>
                    </div>
                    <div class="modal-body">
                        <asp:GridView ID="GridView1" CssClass="myGridClass" runat="server">

                            <AlternatingRowStyle BackColor="HighlightText" />
                        </asp:GridView>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
