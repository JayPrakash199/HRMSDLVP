<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.Master" AutoEventWireup="true" CodeBehind="PromotionHistoryList.aspx.cs" Inherits="HRMS.PromotionHistoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .summary-box {
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
        }

        p.NewEntry {
            float: left;
            font-weight: 600;
            color: black;
        }

        .col-lg-12.NewEntrydiv {
            background-color: #eeeeee;
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
    </style>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.2/css/all.min.css" integrity="sha512-1sCRPdkRXhBV2PBLUdRb4tMg1w2YPf37qatUFeS7zlBy7jJI8Lf4VHwWfZZfpXtYSLy85pkm9GaYVYMfw5BC1A==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <contenttemplate>

        <div class="container box">
            <div class="row">
                <div class="col-lg-12 col-md-12 summary-box">
                    <div class="col-lg-12 NewEntrydiv">
                        <p class="NewEntry">Promotion History List</p>
                    </div>
                    <div class="tab-pane active" id="1">
                        <div class="right_col_bg">
                            <div class="right_col_content border-box label-responsive">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="table-responsive">
                                            <div id="exportto" style="height: 390px; overflow: visible">
                                                <asp:ListView ID="promotionHistoryListView" runat="server">
                                                    <LayoutTemplate>
                                                        <table runat="server" class="table table-bordered">
                                                            <tr class="FridgeHeader" runat="server">
                                                                <th runat="server">Entry No</th>
                                                                <th runat="server">HRMS ID</th>
                                                                <th runat="server">Employee Name</th>
                                                                <th runat="server">From Designation</th>
                                                                <th runat="server">Promoted To</th>
                                                                <th runat="server">Promotion Order Date</th>
                                                                <th runat="server">Letter No</th>
                                                                <th runat="server">Upload Promotion Order</th>
                                                                <th runat="server">Download File</th>
                                                            </tr>
                                                            <tr id="ItemPlaceholder" runat="server">
                                                            </tr>
                                                        </table>
                                                    </LayoutTemplate>
                                                    <ItemTemplate>
                                                        <tr class="TableData">
                                                            <td>
                                                                <asp:Label ID="lblEntryNo" runat="server" Text='<%# Eval("Entry_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblProjectCode" runat="server" Text='<%# Eval("HRMS_ID")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblProjectType" runat="server" Text='<%# Eval("Employee_Name")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("From_Designation")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("To_Designation")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label3" runat="server" Text='<%# DateTime.Parse(Eval("Promotion_Order_Date").ToString()).ToString("d") %>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("Letter_NO")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <div class="input-group">
                                                                    <label class="input-group-btn">
                                                                        <span class="custom-file-input btn">
                                                                            <asp:FileUpload ID="promotionHistorypdfUploader" runat="server" Style="display: none" accept=".pdf" />
                                                                            <asp:LinkButton ID="promotionHistoryUpload" OnClick="promotionHistoryUpload_Click" CssClass="btn btn-yellow" runat="server">Upload</asp:LinkButton>
                                                                        </span>
                                                                    </label>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="btnDownload" OnClick="btnDownload_Click" runat="server"><i class="fa-regular fa-file"></i></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:ListView>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 ExportFoot">
                                        <asp:Button ID="btnExport" OnClick="btnExport_Click" CssClass="exportcss btn-yellow" runat="server" Text="Export" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </contenttemplate>
</asp:Content>
