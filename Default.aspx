<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Login.Master" CodeBehind="Default.aspx.cs" Inherits="HRMS.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" style="" runat="server">
    <link href="assets/vendor/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Bootstrap theme -->
    <link href="assets/vendor/css/bootstrap-theme.min.css" rel="stylesheet" />
    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <link href="assets/vendor/css/ie10-viewport-bug-workaround.css" rel="stylesheet" />
    <!-- Custom styles for this template -->
    <link href="assets/vendor/css/common.css" rel="stylesheet" />
    <link href="assets/vendor/css/style.css" rel="stylesheet" />
    <link href="assets/vendor/css/header-style.css" rel="stylesheet" />
    <link href="assets/vendor/css/responsive.css" rel="stylesheet" />
    <link href="assets/vendor/css/font-awesome.min.css" rel="stylesheet" />
    <!--[if lt IE 9]><script src="js/ie8-responsive-file-warning.js"></script><![endif]-->
    <script src="assets/vendor/js/ie-emulation-modes-warning.js"></script>

    <link href="assets/vendor/css/ch-pie-line.css" rel="stylesheet" />
    <link href="assets/vendor/css/bootstrap-multiselect.css" rel="stylesheet" />
    <script src="assets/vendor/js/jsapi.js"></script>

    <link rel="stylesheet" href="assets/css/Ajaxcal.css" />
    <link rel="stylesheet" href="assets/toastr/toastr.min.css" />

    <style>
        /*Bootstrap Datepicker END!*/

        @media (min-width: 768px) {
            .bg-after-heading1 {
                display: inline-block;
            }

            .bg-after-heading {
                display: none;
            }
        }

        @media (min-width: 1024px) {
            .bg-after-heading1 {
                display: inline-block;
            }

            .bg-after-heading {
                display: none;
            }
        }

        @media (min-width: 1200px) {
            .bg-after-heading1 {
                display: inline-block;
            }

            .bg-after-heading {
                display: none;
            }
        }

        @media (max-width: 767px) {
            .bg-after-heading1 {
                display: none;
            }

            .bg-after-heading {
                background: #d08426;
                display: block;
            }
        }

        input#ContentPlaceHolder1_txtid {
            text-align: right;
        }

        i.fa.fa-search.icon {
            position: absolute;
            padding: 10px;
            display: block;
        }

        .btn-s.float-right {
            float: right;
            background: white;
            width: 72px;
            height: 36px !important;
        }

        .gradient-custom {
            height: 100%;
        }

        .footer {
            position: absolute;
            bottom: 0;
            height: 60px;
        }

        .service-page {
            padding: 1%;
        }

        .itServicePadding {
            padding: 5%;
            box-shadow: inset 0px 5px 10px 0px rgba(0, 0, 0, 0.5);
            border-radius: 50px;
            background-image: linear-gradient( 95.2deg, rgb(44 71 127) 26.8%, rgb(46 123 148) 64% );
        }

            .itServicePadding:Hover {
                background-color: #ffff;
                cursor: pointer;
                text-shadow: 2px 3px #5a5954;
            }

                .itServicePadding:Hover .content-box {
                    color: #ffff;
                }

                .itServicePadding:Hover a {
                    color: #43baff;
                }

        .icon-box-s2 {
            transition: all 0.3s linear;
            -webkit-transition: all 0.3s linear;
            -moz-transition: all 0.3s linear;
            -o-transition: all 0.3s linear;
            -ms-transition: all 0.3s linear;
        }

            .icon-box-s2.s1 .icon-main, .icon-box-s2.s3 .icon-main {
                transition: all 0.3s linear;
                -webkit-transition: all 0.3s linear;
                -moz-transition: all 0.3s linear;
                -o-transition: all 0.3s linear;
                -ms-transition: all 0.3s linear;
                float: left;
                text-align: center;
                line-height: 1;
                color: #43baff;
                padding: 5px;
            }

                .icon-box-s2.s1 .icon-main i, .icon-box-s2.s1 .icon-main span:before, .icon-box-s2.s3 .icon-main i, .icon-box-s2.s3 .icon-main span:before {
                    font-size: 45px;
                }

                .icon-box-s2.s1 .icon-main span, .icon-box-s2.s3 .icon-main span {
                    display: block;
                }

                .icon-box-s2.s1 .icon-main img, .icon-box-s2.s3 .icon-main img {
                    width: 45px;
                }

            .icon-box-s2.s1 .content-box {
                text-align: center;
            }

        .Contenta {
            text-decoration: none;
            font-size: 30px;
            font-weight: 900;
            color: #d9f7ffe8;
            text-shadow: #bbb 0 0 1px, #3d55863b 0 -1px 2px, #000000d6 0 6px 10px, rgb(226 218 218 / 23%) 0 30px 25px;
            transition: margin-left 0.3s cubic-bezier(0, 1, 0, 1);
            text-transform: uppercase;
        }

        .pb-4 {
            padding-bottom: 4%
        }

        header {
            position: unset !important;
        }

        .blur {
            /*filter: blur(2px);*/
            /*pointer-events: none;*/
            opacity: 0.4;
        }

        .tooltipp {
            position: relative;
            border-bottom: 1px dotted black;
        }

            .tooltipp .tooltiptext {
                visibility: hidden;
                width: auto;
                background-color: #f80c0c;
                color: #eee7e7;
                text-align: center;
                position: absolute;
                bottom: 16%;
                left: 4%;
                border-radius: 50px;
                padding: 4%;
                font-weight: 700;
            }

                .tooltipp .tooltiptext::after {
                    content: "";
                    position: absolute;
                    top: 100%;
                    left: 50%;
                    margin-left: -5px;
                    border-width: 5px;
                    border-style: solid;
                    border-color: black transparent transparent transparent;
                }

            .tooltipp:hover .tooltiptext {
                visibility: visible !important;
                text-shadow: none !important;
            }
    </style>

 <script type="text/javascript">
        function ShowPopup(title) {
            $("#PowerBiPopup .modal-title").html(title);
            $("#PowerBiPopup").modal("show");
        }
        function showLoader() {
            $('#loader').show();
        };
        function HideLoader() {
            $('#loader').hide();
     };
 </script>

    <link rel="shortcut icon" href="images/favicon.ico" />
    <script src="assets/plugins/jQuery-lib/2.0.3/jquery.min.js"></script>
    <script src="assets/plugins/jquery-ui/jquery-ui-1.10.2.custom.min.js"></script>
    <script src="assets/plugins/bootstrap/js/bootstrap.min.js"></script>
    <script src="assets/toastr/toastr.min.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" style="background-color: red" runat="server">

    <div class="wrapper">
        <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="hdnMainMenuClass" runat="server" Value="lblMainTst" />
        <asp:HiddenField ID="hdnSubMenuClass" runat="server" Value="lblTSTSub" />
        <header>
            <div class="top_header_ber">
                <div class="container">
                    <div class="pull-right current-user-name">
                        <asp:Button runat="server" ID="btnLogOut" OnClick="btnLogOut_Click" Style="background-color: #f4ecce;" CssClass="btn btnColor pull-right" Text="LogOut" />
                    </div>
                </div>
            </div>
        </header>
        <div class="gradient-custom">
            <div class="container" style="padding: 2%;">
                <div class="row">
                    <div class=" col-md-6 col-sm-6 pb-4">
                        <div class="icon-box-s2 s1 itServicePadding blur tooltipp" id="divinfra" runat="server">
                            <span class="tooltiptext" style="visibility: hidden">You don't have permission for Infra Module kindly contact Admin !</span>

                            <div class="content-box">
                                <a class="Contenta" role="button" runat="server" id="btnInfraa">Infra</a>
                            </div>
                        </div>
                    </div>
                    <div class=" col-md-6 col-sm-6 pb-4">
                        <div class="icon-box-s2 s1 itServicePadding tooltipp  blur" id="divHrms" runat="server">
                            <span class="tooltiptext" style="visibility: hidden">You don't have permission for HRMS Module kindly contact Admin !</span>
                            <div class="content-box">
                                <a class="Contenta" role="button" runat="server" id="btnHRMS">HRMS</a>
                            </div>
                        </div>
                    </div>
                    <div class=" col-md-6 col-sm-6 pb-4 ">
                        <div class="icon-box-s2 s1  itServicePadding blur tooltipp" id="divlibrary" runat="server">
                            <span class="tooltiptext" style="visibility: hidden">You don't have permission for Library Module kindly contact Admin !</span>
                            <div class="content-box">
                                <a class="Contenta" role="button" runat="server" id="btnLibraryMgmntt">Library Management</a>
                            </div>
                        </div>
                    </div>

                    <div class=" col-md-6 col-sm-6 pb-4" id="divreport" runat="server">
                        <div class="icon-box-s2 s1 itServicePadding blur tooltipp" id="divreports" runat="server">
                            <span class="tooltiptext" style="visibility: hidden">You don't have permission for Report Module kindly contact Admin !</span>

                            <div class="content-box">
                                <a class="Contenta" href="ReportManagement.aspx" role="button" runat="server" id="btnReport">Report</a>
                            </div>
                        </div>
                    </div>
                    <div class=" col-md-6 col-sm-6 pb-4" id="divslcm" runat="server">
                        <div class="icon-box-s2 s1 itServicePadding blur tooltipp" id="divslcs" runat="server">
                            <span class="tooltiptext" style="visibility: hidden">You don't have permission for SLCM Module kindly contact Admin !</span>

                            <div class="content-box">
                                <a class="Contenta" href="Timetable.aspx" role="button" runat="server" id="btnslcm">SLCM</a>
                            </div>
                        </div>
                    </div>
                    <div class=" col-md-6 col-sm-6 pb-4" id="div1" runat="server">
                        <div class="icon-box-s2 s1 itServicePadding blur tooltipp" id="divstock" runat="server">
                            <span class="tooltiptext" style="visibility: hidden">You don't have permission for Stock & Store Module kindly contact Admin !</span>

                            <div class="content-box">
                                <asp:LinkButton class="Contenta" ID="btnStockStore" Text="Stock and Store" OnClick="btnStockStore_Click" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class=" col-md-6 col-sm-6   pb-4">
                        <div class="icon-box-s2 s1  itServicePadding blur tooltipp" id="divlibrry" runat="server">
                            <span class="tooltiptext" style="visibility: hidden">You don't have permission for Accounts Module kindly contact Admin !</span>
                            <div class="content-box">
                                <a class="Contenta" href="FeeClassificationList.aspx" role="button" runat="server" id="btnFeeMgmntt">Accounts and Fee Management</a>
                            </div>
                        </div>
                    </div>

                     <div class=" col-md-6 col-sm-6   pb-4">
                        <div class="icon-box-s2 s1  itServicePadding" id="divPowerBi" runat="server">
<%--                            <span class="tooltiptext" >You don't have permission for Accounts Module kindly contact Admin !</span>--%>
                            <div class="content-box">
                                <asp:LinkButton class="Contenta" role="button" OnClick="btnPowerBi_Click1" runat="server" Text="Power BI" id="btnPowerBi"></asp:LinkButton>
                            </div>
                        </div>
                    </div>

                    <div class=" col-md-6 col-sm-6 pb-4" id="divPlacement" visible="true" runat="server">
                        <div class="icon-box-s2 s1 itServicePadding" visible="false" id="innerDivPlacement" runat="server">
                            <div class="content-box">
                                <asp:LinkButton class="Contenta" ID="btnPlacement" Text="Placement" OnClick="btnPlacement_Click" runat="server" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
            <div class="btn-group btn-group-lg" role="group" aria-label="Large button group">
            </div>

        </div>
        <div style="position: fixed; bottom: 30px;">
            <asp:DropDownList Visible="False" ID="ddlCompany" AutoPostBack="true" OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged"
                Style="cursor: pointer; appearance: auto !important; width: auto" CssClass="form-control" runat="server">
            </asp:DropDownList>
            <a class="nav-link active" id="anchrCompanyName" runat="server" aria-current="page" href="#">Company Name :
                <asp:Label runat="server" ID="lblcompanyName"></asp:Label></a>
        </div>

        <div id="footer">
            <footer class="p-10">©<asp:Label runat="server" ID="Label1"></asp:Label></footer>
        </div>
    </div>
      <div id="PowerBiPopup" class="modal fade" role="dialog">
        <div class="modal-dialog" style="width: 800px">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        &times;</button>
                    <h4 class="modal-title"></h4>
                </div>
                <div class="modal-body">
                    <div class="container box">
                        <div class="row">
                            <div class="col-lg-3 col-md-2"></div>
                            <div class="col-lg-12 col-md-12 model-box">
                               <%-- <div class="loader"  style="position:absolute" id="loader">
                                    <div class="loader-img"><i class="fa fa-spinner fa-spin"></i></div>
                                </div>--%>
                                <div class="col-lg-12 col-md-12 ">
                                    
                                    <div class="row">
                                        <div class="card-body">
                                            <div class="row md-12 marginx">
                                                <div class="col-md-12">
                                                    <div class="row">
                                                        <div class="col-md-12 contact-info">
                                                            <div class="container">
                                                                <div class="form-group">
                                                                    <a class="Contenta" style="text-shadow: 0 0 black !important;color:black;font-size:20px" href="https://app.powerbi.com/links/ryQDNW88U_?ctid=078e93f7-11f8-4a74-b8a6-c57c997e3146&pbi_source=linkShare" id="bankDetails"> 1 .Bank Details</a>
                                                                </div>
                                                                <div class="form-group">
                                                                      <a class="Contenta" style="text-shadow: 0 0 black !important;color:black;font-size:20px" href="https://app.powerbi.com/links/r_Zy4WUMq2?ctid=078e93f7-11f8-4a74-b8a6-c57c997e3146&pbi_source=linkShare" id="empSummery"> 2 .Employee Summary</a>
                                                                </div>
                                                                <div class="form-group">
                                                                      <a class="Contenta" style="text-shadow: 0 0 black !important;color:black;font-size:20px" href="https://app.powerbi.com/links/ket2b94ygJ?ctid=078e93f7-11f8-4a74-b8a6-c57c997e3146&pbi_source=linkShare" id="portalAnalysys">3 .GemsPortalAnalysis </a>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
                
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">
                        Close</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
