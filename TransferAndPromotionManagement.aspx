<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.Master" AutoEventWireup="true" CodeBehind="TransferAndPromotionManagement.aspx.cs" Inherits="HRMS.TransferAndPromotionManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/material-design-icons/3.0.1/iconfont/material-icons.min.css" />
    <style>
        .summary-box {
            height: auto;
            text-align: center;
            box-shadow: 0 3px 6px rgb(0 0 0 / 16%), 0 3px 6px rgb(0 0 0 / 23%);
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
            height: 36px;
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
        /*Files Button*/
        .file {
            position: relative;
            display: flex;
            justify-content: center;
            align-items: center;
        }

            .file > input[type='file'] {
                font-size: 100px;
                position: absolute;
                left: 0;
                top: 0;
                opacity: 0;
            }

            .file > label {
                font-size: 1rem;
                font-weight: 300;
                cursor: pointer;
                outline: 0;
                user-select: none;
                border-color: rgb(216, 216, 216) rgb(209, 209, 209) rgb(186, 186, 186);
                border-style: solid;
                border-radius: 4px;
                border-width: 1px;
                background-color: hsl(0, 0%, 100%);
                color: hsl(0, 0%, 29%);
                padding-left: 16px;
                padding-right: 16px;
                padding-top: 16px;
                padding-bottom: 16px;
                display: flex;
                justify-content: center;
                align-items: center;
            }

                .file > label:hover {
                    border-color: hsl(0, 0%, 21%);
                }

                .file > label:active {
                    background-color: hsl(0, 0%, 96%);
                }

                .file > label > i {
                    padding-right: 5px;
                }

            .file.float-left {
                float: left;
                margin: 16px;
            }

        .btn-upload.float-right {
            float: right;
            margin: 16px;
            width: 72px;
            height: 31px;
        }

        .btn-upload.float-left {
            float: right;
            width: auto;
            height: 31px;
        }

        .textalline {
            float: left;
            font-size: 10px;
            width: 203px;
            text-align: justify;
        }

        .row.ab {
            border-bottom: 1px solid;
            padding: 0px 0px 52px 0px
        }

        .row.ac {
            padding: 23px 0px 24px 0px;
        }

        i.fa.fa-search.icon {
            position: absolute;
            padding: 10px;
            display: block;
        }

        .blockInputClass {
            pointer-events: none;
        }
    </style>
    <div class="container box">
        <div class="row">
            <div class="col-lg-12 col-md-12 model-box">

                <div class="col-lg-12 col-md-12 summary-box">
                    <div class="col-lg-12 NewEntrydiv">
                        <p class="NewEntry">Transfer Event Record</p>
                    </div>
                    <div class="row">
                        <div class="card-body">
                            <div class="row md-12 marginx">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="row ab">
                                            <div class="col-md-6 contact-info">
                                                <div class="container">
                                                    <div class="form-group border ab">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <label for="exampleAccount">HRMS ID: </label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding-right: 10px">
                                                                    <i class="fa fa-search icon"></i>
                                                                    <asp:TextBox ID="txtHRMSID" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="btnSearch" CssClass="btn-s float-right submit btn-yellow" OnClick="btnSearch_Click" Text="Search" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div class="col-md-7" style="padding-top: 0.5%;">
                                                        <asp:Label CssClass="message" ID="LblMessage" runat="server"></asp:Label>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-6 contact-info">
                                                <div class="container">
                                                    <div class="form-group border ab">
                                                        <label for="exampleAccount">Employee Name</label>
                                                        <asp:TextBox ID="txtEmployeeName" CssClass="form-control blockInputClass" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group border ab">
                                                        <label for="exampleAccount">Designation</label>
                                                        <asp:TextBox ID="txtDesignation" CssClass="form-control blockInputClass" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group border ab">
                                                        <label for="exampleAccount">Current Station</label>
                                                        <asp:TextBox ID="txtCurrentStation" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row ac">
                                            <div class="col-md-6 contact-info">
                                                <div class="container">
                                                    <div class="form-group">
                                                        <label for="exampleAccount">Relieving Event</label>
                                                        <asp:DropDownList ID="ddlRelievingEvent" CssClass="form-control" runat="server">
                                                            <asp:ListItem>Select</asp:ListItem>
                                                            <asp:ListItem>Routine Transfer</asp:ListItem>
                                                            <asp:ListItem>Promotion Transfer</asp:ListItem>
                                                            <asp:ListItem>Correction Transfer</asp:ListItem>
                                                            <asp:ListItem>Other Reason</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">Relief Order No.</label>
                                                        <asp:TextBox ID="txtReliefOrderNo" type="" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">From Station</label>
                                                        <asp:DropDownList ID="ddlFromStation" CssClass="form-control" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">Transfer Order Date</label>
                                                        <asp:TextBox ID="txtTransferOrderDate" type="date" CssClass="form-control ajax__calendar_body" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label id="lblPromotionOrderDate" style="display: none" for="exampleAccount">Promotion Order Date</label>
                                                        <asp:TextBox ID="txtPromotionOrderDate" Style="display: none" type="date" CssClass="form-control ajax__calendar_body" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label id="lblPromotionLetterNo" style="display: none" for="exampleAccount">Promotion Letter No</label>
                                                        <asp:TextBox ID="txtPromotionLetterNo" Style="display: none" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6 contact-info">
                                                <div class="container">
                                                    <div class="form-group">
                                                        <label for="exampleAccount">Relief Order Date</label>
                                                        <asp:TextBox ID="txtReliefOrderDate" type="date" CssClass="form-control ajax__calendar_body" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">Transfer Letter No</label>
                                                        <asp:TextBox ID="txtLetterNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">To Station</label>
                                                        <asp:DropDownList ID="ddlToStation" CssClass="form-control" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <%--<div class="form-group">
                                                        <label for="exampleAccount">Transfer Order Date</label>
                                                        <asp:TextBox ID="txtTransferOrderDate" type="date" CssClass="form-control ajax__calendar_body" runat="server"></asp:TextBox>
                                                    </div>--%>
                                                    <div class="form-group">
                                                        <label id="lblToDesignation" style="display: none" for="exampleAccount">To Designation</label>
                                                        <%--<asp:TextBox ID="txtToDesignation" style="display:none" CssClass="form-control" runat="server"></asp:TextBox>--%>
                                                        <asp:DropDownList ID="ddlDesignation" Style="display: none" CssClass="form-control" runat="server">
                                                            <asp:ListItem>Select</asp:ListItem>
                                                            <asp:ListItem>Principal</asp:ListItem>
                                                            <asp:ListItem>Senior Lecturer</asp:ListItem>
                                                            <asp:ListItem>Lecturer</asp:ListItem>
                                                            <asp:ListItem>ATO</asp:ListItem>
                                                            <asp:ListItem>TO</asp:ListItem>
                                                            <asp:ListItem>Training Superintendent</asp:ListItem>
                                                            <asp:ListItem>Section Officer</asp:ListItem>
                                                            <asp:ListItem>Assistant Section Officer</asp:ListItem>
                                                            <asp:ListItem>Laboratory Assistant</asp:ListItem>
                                                            <asp:ListItem>Librarian</asp:ListItem>
                                                            <asp:ListItem>Junior Assistant</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <label for="exampleAccount" class="appuploadlabel">Upload Transfer Order</label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div class='file'>
                                                                        <label for='input-file'>
                                                                            <i class="material-icons">cloud_queue
                                                                            </i>Max PDF file size 2MB
                                                                        </label>
                                                                        <asp:FileUpload ID="pdfUploader" accept="application/pdf" runat="server" />
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <asp:Button ID="btntransferSubmit" OnClick="btntransferSubmit_Click" runat="server" CssClass="btn-s float-right submit btn-yellow" type="submit" Text="Relief" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-2">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script language="Javascript">
        function isDecimalNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
        $(document).ready(function () {
            $('#<%= ddlRelievingEvent.ClientID %>').change(function () {
                if ($(this).val() === "Promotion Transfer") {
                    $("#<%= txtPromotionLetterNo.ClientID %>").show();
                    $("#lblPromotionLetterNo").show();
                    $("#<%= txtPromotionOrderDate.ClientID %>").show();
                    $("#lblPromotionOrderDate").show();
                    $("#<%= ddlDesignation.ClientID %>").show();
                    $("#lblToDesignation").show();
                }
                else {
                    $("#<%= txtPromotionLetterNo.ClientID %>").hide();
                    $("#lblPromotionLetterNo").hide();
                    $("#<%= txtPromotionOrderDate.ClientID %>").hide();
                    $("#lblPromotionOrderDate").hide();
                    $("#<%= ddlDesignation.ClientID %>").hide();
                    $("#lblToDesignation").hide();
                }
            });
        });
    </script>
</asp:Content>
