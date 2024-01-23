<%@ Page Title="" Language="C#" MasterPageFile="~/Infrastructure.Master" AutoEventWireup="true" CodeBehind="Infra-Reports.aspx.cs" Inherits="HRMS.Infra_Reports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.12.1/css/all.css" />

    <style>
        .summary-box {
            margin-top: 75px;
            height: auto;
            text-align: center;
            box-shadow: 0 3px 6px rgba(0, 0, 0, 0.16), 0 3px 6px rgba(0, 0, 0, 0.23);
            border: 1px solid;
        }

        .container.box {
            margin-top: 61px;
            margin-bottom: 26px;
        }

        p.Introduction {
            float: left;
            color: black;
            padding: 23px;
            text-transform: uppercase;
            font-weight: 700;
        }

        .row.md-12.marginx {
            margin: 69px;
            padding-bottom: 36px;
            border-bottom: 3px solid black;
        }

        i.fal.fa-plus-circle.full {
            font-size: 52px;
            float: right;
            margin: 6px;
        }

        .Addaditional {
            border: solid 1px black;
            background-color: white;
            width: auto;
            height: 43px;
            margin: 10px;
            float: left;
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
        /*Modal Control*/
        .modal-dialog {
            width: 978px;
            margin: 30px auto;
        }

        .modal-header {
            background-color: white;
            font-size: 16px;
            line-height: 28px;
            padding: 10px 15px;
            display: inline-block;
            color: #f5f5f5;
            border-top: none;
            width: 100%;
        }

            .modalExtender-heading .close, .modal-header .close {
                margin: 6px;
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
        }
    </style>

    <div class="container box">
        <div class="row">
            <div class="col-lg-3 col-md-2"></div>
            <div class="col-lg-12 col-md-12 model-box">

                <div class="col-lg-12 col-md-12 summary-box">
                    <div class="col-lg-12 NewEntrydiv">
                        <p class="NewEntry">Reports</p>
                    </div>
                    <div class="row">
                        <%--<asp:LinkButton ID="btnHome" CssClass="btn-link float-right" OnClick="btnHome_Click" runat="server">Home</asp:LinkButton>--%>
                        <div class="row md-12 marginx">
                            <div class="containerList">
                                <ul class="myUL">
                                    <li>
                                        <asp:LinkButton ID="LinkButton1" OnClick="btnEstimatePreparation_Click" runat="server">Download DTET Estimate Preparation Monitoring Report</asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="LinkButton2" OnClick="btnAuditoriumBuilding_Click" runat="server">Download DTET Auditorium Building Report</asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="LinkButton3" OnClick="btnHostelBuilding_Click" runat="server">Download DTET Hostel Building Report</asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="LinkButton4" OnClick="btnInstitutionalBuilding_Click" runat="server">Download DTET Institutional Building Report</asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="LinkButton5" OnClick="btnStaffBuilding_Click" runat="server">Download DTET Staff Building Report</asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="LinkButton6" OnClick="btnLandDataDetail_Click" runat="server">Download DTET Land Data Details Report</asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="LinkButton7" OnClick="btnMaintanenceAndAMC_Click" runat="server">Download DTET Maintanence And AMC Report</asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="LinkButton8" OnClick="btnProjectProgressDetail_Click" runat="server">Download DTET Project Progress Details Report</asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="LinkButton9" OnClick="btnServiceMonitoring_Click" runat="server">Download DTET Service Monitoring Report</asp:LinkButton></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-2">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

