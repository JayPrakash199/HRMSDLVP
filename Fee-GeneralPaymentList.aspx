<%@ Page Title="" Language="C#" MasterPageFile="~/Fee.Master" AutoEventWireup="true" CodeBehind="Fee-GeneralPaymentList.aspx.cs" Inherits="HRMS.Fee_GeneralPaymentList" %>

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
    </style>
    <script language="Javascript">
        function showLoader() {
            $(".loader").fadeOut("slow");
        };
        $('#GeneralPaymentListView').Scrollable({
            ScrollHeight: 300
        });
    </script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.2/css/all.min.css" integrity="sha512-1sCRPdkRXhBV2PBLUdRb4tMg1w2YPf37qatUFeS7zlBy7jJI8Lf4VHwWfZZfpXtYSLy85pkm9GaYVYMfw5BC1A==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <contenttemplate>

        <div class="container box">
            <div class="row">
                <div class="col-lg-3 col-md-2"></div>
                <div class="col-lg-12 col-md-12 summary-box">
                    <div class="col-lg-12 NewEntrydiv">
                        <p class="NewEntry">General Payment List</p>
                    </div>
                    <div class="tab-pane active" id="1">
                        <div class="right_col_bg">
                            <div class="right_col_content border-box label-responsive">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="table-responsive">
                                            <div id="exportto" style="height: 390px; overflow: visible">
                                                <asp:ListView ID="GeneralPaymentListView" runat="server">
                                                    <EmptyDataTemplate>
                                                        There are no records
                                                    </EmptyDataTemplate>
                                                    <LayoutTemplate>
                                                        <table runat="server" class="table table-bordered" cellpadding="1" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                                                            <tr style="background-color: #E5E5FE" runat="server">
                                                                <th runat="server">Entry No</th>
                                                                <th runat="server">Type</th>
                                                                <th runat="server">Vendor No</th>
                                                                <th runat="server">Vendor Name</th>
                                                                <th runat="server">Status</th>
                                                                <th runat="server">Employee No</th>
                                                                <th runat="server">Employee Name</th>
                                                                <th runat="server">Posting Date</th>
                                                                <th runat="server">Payment Type Collection Method</th>
                                                                <th runat="server">GL No</th>
                                                                <th runat="server">Cash GL Account No</th>
                                                                <th runat="server">Bank Account No</th>
                                                                <th runat="server">External Document No</th>
                                                                <th runat="server">Amount</th>
                                                                <th runat="server">No Series</th>
                                                                <th runat="server">Cheque No DD</th>
                                                                <th runat="server">Cheque Date</th>
                                                                <th runat="server">Narration</th>
                                                                <th runat="server">Post</th>
                                                            </tr>
                                                            <tr id="ItemPlaceholder" runat="server">
                                                            </tr>
                                                        </table>
                                                    </LayoutTemplate>
                                                    <ItemTemplate>
                                                        <tr class="TableData">
                                                            <td>
                                                                <a href="#">
                                                                    <asp:Label ID="lblEntryNo" runat="server" Text='<%# Eval("Entry_No")%>'> </asp:Label>
                                                                </a>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblProjectType" runat="server" Text='<%# Eval("Type")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Vendor_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Vendor_Name")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label15" runat="server" Text='<%# Eval("Status")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label16" runat="server" Text='<%# Eval("Employee_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label17" runat="server" Text='<%# Eval("Employee_Name")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label3" runat="server" Text='<%# DateTime.Parse(Eval("Posting_Date").ToString()).ToString("d") %>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("Payment_Type_Collection_Method")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("G_L_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("Cash_G_L_Account_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label7" runat="server" Text='<%# Eval("Bank_Account_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label8" runat="server" Text='<%# Eval("External_Document_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label9" runat="server" Text='<%# Eval("Amount")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label11" runat="server" Text='<%# Eval("No_Series")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label12" runat="server" Text='<%# Eval("Cheque_No_DD")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label13" runat="server" Text='<%# DateTime.Parse(Eval("Cheque_Date").ToString()).ToString("d") %>'> </asp:Label>

                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label14" runat="server" Text='<%# Eval("Narration")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="btnPost" OnClientClick="showLoader();" class="btn btn-primary" runat="server" OnClick="btnPost_Click">Release & Post</asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:ListView>
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
    </contenttemplate>
</asp:Content>
