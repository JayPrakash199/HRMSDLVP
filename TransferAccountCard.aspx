<%@ Page Title="" Language="C#" MasterPageFile="~/Fee.Master" AutoEventWireup="true" CodeBehind="TransferAccountCard.aspx.cs" Inherits="HRMS.TransferAccountCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .summary-box {
            margin-top: 75px;
            height: auto;
            text-align: center;
            box-shadow: 0 3px 6px rgba(0, 0, 0, 0.16), 0 3px 6px rgba(0, 0, 0, 0.23);
            border: 1px solid;
        }

        table thead tr th, .table > tbody > tr > th {
            border-top: none !important;
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

        .right_col_content.border-box.label-responsive {
            border: none;
        }

        .exportcss {
            float: left;
            border: solid 1px black;
            background-color: white;
        }

        .printcss {
            float: right;
            border: solid 1px black;
            background-color: white;
        }

        i.fa-solid.fa-file {
            font-size: 35px;
        }

        .col-lg-12.col-md-12.summary-box {
            margin: 94px 10px 10px -113px;
        }

        .custom-file-input::-webkit-file-upload-button {
            visibility: hidden;
        }

        .custom-file-input::before {
            content: 'Choose File';
            display: inline-block;
            background: linear-gradient(top, #f9f9f9, #e3e3e3);
            border: 1px solid #999;
            border-radius: 3px;
            padding: 5px 8px;
            outline: none;
            white-space: nowrap;
            -webkit-user-select: none;
            cursor: pointer;
            text-shadow: 1px 1px #fff;
            font-weight: 700;
            font-size: 10pt;
        }

        .custom-file-input:hover::before {
            border-color: black;
        }

        .custom-file-input:active::before {
            background: -webkit-linear-gradient(top, #e3e3e3, #f9f9f9);
        }

        .readonly {
            background-color: #6262629e !important;
            cursor: not-allowed !important;
            padding: 6px 12px !important;
            font-size: 13px !important;
        }
    </style>
    <div class="container box">
        <div class="row">
            <div class="col-lg-12 col-md-12 summary-box">
                <div class="col-lg-12 NewEntrydiv">
                    <p class="NewEntry">Transfer Account</p>
                </div>
                <div class="tab-pane active">
                    <div class="right_col_bg">
                        <div class="right_col_content border-box label-responsive">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-6 contact-info">
                                            <div class="container">
                                                <div class="form-group">
                                                    <label for="exampleAccount">Type</label>
                                                    <asp:DropDownList ID="ddlType" CssClass="form-control" runat="server">
                                                        <asp:ListItem Value="Transfer">Transfer</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label>Posting Date</label>
                                                    <asp:TextBox ID="txtPostingDate" type="date" CssClass="form-control ajax__calendar_body" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label for="exampleAccount">Payment Type</label>
                                                    <asp:DropDownList ID="ddlPaymentType" AutoPostBack="true" OnSelectedIndexChanged="ddlPaymentType_SelectedIndexChanged" CssClass="form-control" runat="server">
                                                        <asp:ListItem Value="Select Payment Type">Select Payment Type</asp:ListItem>
                                                        <asp:ListItem Value="CASH">CASH</asp:ListItem>
                                                        <asp:ListItem Value="BANK">BANK</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div id="divGLac" visible="false" runat="server" class="form-group">
                                                    <label for="exampleAccount">G/L account name</label>
                                                    <asp:DropDownList ID="ddlglAcName" OnSelectedIndexChanged="ddlglAcName_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                                <div id="divGLacNo" visible="false" runat="server" class="form-group">
                                                    <label for="exampleAccount">G/L account no</label>
                                                    <asp:TextBox ID="txtGlAcNo" Enabled="false" CssClass="form-control readonly" runat="server">
                                                    </asp:TextBox>
                                                </div>
                                                <div id="divBankAcName" visible="false" runat="server" class="form-group">
                                                    <label for="exampleAccount">Bank account Name</label>
                                                    <asp:DropDownList ID="ddlbankAcName" OnSelectedIndexChanged="ddlbankAcName_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                                <div id="divBankAcNo" visible="false" runat="server" class="form-group">
                                                    <label for="exampleAccount">Bank account no</label>
                                                    <asp:TextBox ID="txtBnkAcNo" Enabled="false" CssClass="form-control readonly" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6 contact-info">
                                            <div class="container">
                                                
                                                <div class="form-group">
                                                    <label for="exampleAccount">Transfer G/L account name</label>
                                                    <asp:DropDownList ID="ddlTransferGlaccountname" OnSelectedIndexChanged="ddlTransferGlaccountname_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label for="exampleAccount">Transfer G/L account no</label>
                                                    <asp:TextBox ID="txtTransferGlaccountNo" Enabled="false" CssClass="form-control readonly" runat="server">
                                                    </asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label for="exampleAccount">Transfer Bank account name</label>
                                                    <asp:DropDownList ID="ddlTransferBankaccountname" OnSelectedIndexChanged="ddlTransferBankaccountname_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label for="exampleAccount">Transfer Bank account no</label>
                                                    <asp:TextBox ID="txtTransferBankaccountno" Enabled="false" CssClass="form-control readonly" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label for="exampleAccount">Amount</label>
                                                    <asp:TextBox ID="txtTotalAmount" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group" style="display: none">
                                                    <label for="exampleAccount">Status</label>
                                                    <asp:DropDownList ID="ddlStatus" Enabled="false" CssClass="form-control readonly" runat="server">
                                                        <asp:ListItem Value="Open">Open</asp:ListItem>
                                                        <asp:ListItem Value="Released">Released</asp:ListItem>
                                                        <asp:ListItem Value="Posted">Posted</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>

                                            </div>
                                        </div>
                                        <div id="dvdimension" runat="server">
                                            <p style="border-bottom: 1px solid black; width: 96%; text-align: left; margin-left: 2%; margin-top: 2%; font-weight: 700; font-size: 20px;">
                                                Dimension
                                            </p>
                                            <div class="col-md-6 contact-info">
                                                <div class="container">
                                                    <div class="form-group">
                                                        <label for="InstiuteCode">Instiute Code</label>
                                                        <asp:DropDownList ID="ddlInstiuteCode" CssClass="form-control" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group" runat="server">
                                                        <label for="exampleAccount">Department Code</label>
                                                        <asp:DropDownList ID="ddlDepartmentCode" CssClass="form-control" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group" runat="server">
                                                        <label for="exampleAccount">Funding source Code</label>
                                                        <asp:DropDownList ID="ddlFundingsourceCode" CssClass="form-control" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6 contact-info">
                                                <div class="container">
                                                    <div class="form-group">
                                                        <label for="InstiuteCode">Narration</label>
                                                        <asp:TextBox ID="txtNaration" CssClass="form-control" runat="server">
                                                        </asp:TextBox>
                                                    </div>
                                                    <div class="form-group" runat="server" id="divTranNo">
                                                        <label for="exampleAccount">Transcation No.</label>
                                                        <asp:TextBox ID="txtTranNo" CssClass="form-control" runat="server">
                                                        </asp:TextBox>
                                                    </div>
                                                    <div class="form-group" runat="server" id="divTranDate">
                                                        <label for="exampleAccount">Transcation Date</label>
                                                        <asp:TextBox ID="txtTranDate" CssClass="form-control ajax__calendar_body" type="date" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <asp:Button ID="btnPostTransferAccount" OnClick="btnPostTransferAccount_Click" runat="server" class="btn btn-primary float-right" Style="float: right; height: 36px !important;" Text="Submit Transfer Account" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


            </div>
        </div>

    </div>
</asp:Content>
