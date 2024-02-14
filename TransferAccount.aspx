<%@ Page Title="" Language="C#" MasterPageFile="~/Fee.Master" AutoEventWireup="true" CodeBehind="TransferAccount.aspx.cs" Inherits="HRMS.TransferAccount" %>

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
    <contenttemplate>
        <div class="container box">
            <div class="row">
                <div class="col-lg-12 col-md-12 summary-box">
                    <div class="col-lg-12 NewEntrydiv">
                        <p class="NewEntry">Transfer Account List</p>
                    </div>
                    <div class="tab-pane active" id="1">
                        <div class="right_col_bg">
                            <div class="right_col_content border-box label-responsive">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="table-responsive">
                                            <div id="exportto" style="height: 390px; overflow: visible">
                                                <asp:ListView ID="TransferAccountListView" runat="server">
                                                    <EmptyDataTemplate>
                                                        There are no records
                                                    </EmptyDataTemplate>
                                                    <LayoutTemplate>
                                                        <table runat="server" class="table table-bordered" cellpadding="1" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                                                            <tr style="background-color: #E5E5FE" runat="server">
                                                                <th runat="server">Entry No</th>
                                                                <th runat="server">Type</th>
                                                                <th runat="server">Payment Type</th>
                                                                <th runat="server">GL A/C No</th>
                                                                <th runat="server">GL A/C Name</th>
                                                                <th runat="server">Bank A/C No Name</th>
                                                                <th runat="server">Bank A/C Name</th>
                                                                <th runat="server">Transfering GL A/C No</th>
                                                                <th runat="server">Transfering GL A/C Name</th>
                                                                <th runat="server">Transfering Bank A/C No</th>
                                                                <th runat="server">Transfering Bank A/C Name</th>
                                                                <th runat="server">Transcation No</th>
                                                                <th runat="server">Transcation Date</th>
                                                                <th runat="server">Amount</th>
                                                                <th runat="server">Status</th>
                                                                <th runat="server">Posting Date</th>
                                                                <th runat="server">Action</th>
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
                                                                <asp:Label ID="lblType" runat="server" Text='<%# Eval("Type")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblPaymentType" runat="server" Text='<%# Eval("Payment_Type")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="LblAccountNo" runat="server" Text='<%# Eval("G_L_account_no")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblglAccountName" runat="server" Text='<%# Eval("G_L_account_name")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblbankAccountNo" runat="server" Text='<%# Eval("Bank_account_no")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblBankAccountName" runat="server" Text='<%# Eval("Bank_account_name")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbltransferGlAcNo" runat="server" Text='<%# Eval("Transferring_G_L_Account_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbltransferGlAcName" runat="server" Text='<%# Eval("Transferring_G_L_Account_Name")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbltransferBankAcNo" runat="server" Text='<%# Eval("Transferring_Bank_Account_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbltransferBankAcName" runat="server" Text='<%# Eval("Transferring_Bank_Account_Name")%>'> </asp:Label>
                                                            </td>
                                                             <td>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Transcation_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# DateTime.Parse(Eval("Transcation_Date").ToString()).ToString("d")=="01-01-0001"?"":DateTime.Parse(Eval("Transcation_Date").ToString()).ToString("d") %>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblPostingDate" runat="server" Text='<%# DateTime.Parse(Eval("Posting_Date").ToString()).ToString("d") %>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                 <%--<a href="TransferAccountCard.aspx?Entry_No=<%# Eval("Entry_No")%>" class="btn btn-primary">Post Transfer</a>--%>
                                                                <asp:Button ID="btnPost" OnClick="btnPost_Click" class="btn btn-primary" Text="Post Transfer Account" runat="server"></asp:Button>
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
