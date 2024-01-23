<%@ Page Title="" Language="C#" MasterPageFile="~/Fee.Master" AutoEventWireup="true" CodeBehind="Account_CautionRefundOrder.aspx.cs" Inherits="HRMS.Account_CautionRefundOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/material-design-icons/3.0.1/iconfont/material-icons.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>

    <style>
        .summary-box {
            margin-top: 75px;
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
            padding-bottom: 36px;
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

        .col-lg-12.col-md-12.summary-box {
            margin: 94px 10px 10px -113px;
        }
    </style>
    <script type="text/javascript">
        function showLoader() {
            $('#loader').show();
        };
        function HideLoader() {
            $('#loader').hide();
        };

        $(document).ready(function () {
            debugger;
            $('.selectall').on('click', function () {
                debugger;
                if (this.checked) {
                    $('.selectone').each(function () {
                        this.checked = true;
                    });
                } else {
                    $('.selectone').each(function () {
                        this.checked = false;
                    });
                }
            });

            $('.selectone').on('click', function () {
                if ($('.selectone:checked').length == $('.selectone').length) {
                    $('.selectall').prop('checked', true);
                } else {
                    $('.selectall').prop('checked', false);
                }
            });
        });
    </script>
    <div class="container box">
        <div class="row">
            <div class="col-lg-3 col-md-2"></div>
            <div class="col-lg-12 col-md-12 model-box">

                <div class="col-lg-12 col-md-12 summary-box">
                    <div class="col-lg-12 NewEntrydiv">
                        <p class="NewEntry">
                            <asp:Label runat="server" ID="lblRefundOrderSerialNo"></asp:Label>
                        </p>
                        <div class="btn-group" role="group" aria-label="Basic example">
                            <asp:Button Style="background-image: linear-gradient(to bottom,#337ab7 0,#265a88 100%);" runat="server" ID="btnGetLines" OnClick="btnGetLines_Click" Text="Get Lines" CssClass="btn btn-primary" />
                            <asp:Button Style="background-image: linear-gradient(to bottom,#337ab7 0,#265a88 100%);" runat="server" ID="btnPostToJournal" OnClick="btnPostToJournal_Click" Text="Post To Journal" CssClass="btn btn-primary" />
                            <asp:Button Style="background-image: linear-gradient(to bottom,#337ab7 0,#265a88 100%);" runat="server" ID="btnPostedCautionMoneyReport" OnClick="btnPostedCautionMoneyReport_Click" Text="PostedCautionMoneyReport" CssClass="btn btn-primary" />
                            <asp:Button Style="background-image: linear-gradient(to bottom,#337ab7 0,#265a88 100%);" runat="server" ID="btnUnpostedCautionMoneyReport" OnClick="btnUnpostedCautionMoneyReport_Click" Text="Unposted Caution Money Report" CssClass="btn btn-primary" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-6 contact-info">
                                    <div class="container">
                                        <div class="form-group">
                                            <label for="exampleAccount">Academic Year</label>
                                            <asp:DropDownList ID="ddlAcademicYear" CssClass="ajax__calendar_body form-control" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label>Posting Date</label>
                                            <asp:TextBox ID="txtPostingDate" type="date" CssClass="form-control ajax__calendar_body" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label for="exampleAccount">Payment Method</label>
                                            <asp:DropDownList ID="ddlPaymentMethod" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPaymentMethod_SelectedIndexChanged" runat="server">
                                                <asp:ListItem>Select</asp:ListItem>
                                                <asp:ListItem Value="Bank">Bank</asp:ListItem>
                                                <asp:ListItem Value="Cash">Cash</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label for="exampleAccount">Account No</label>
                                            <asp:DropDownList ID="ddlAccountNo" CssClass="form-control" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label for="exampleAccount">Posted</label>
                                            <asp:CheckBox ID="chkPosted" Style="float:left;display: grid; width:25px;height:25px" runat="server">
                                            </asp:CheckBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6 contact-info">
                                    <div class="container">
                                        <div class="form-group">
                                            <label>Cheque No</label>
                                            <asp:TextBox ID="txtChequeNo" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Cheque Date</label>
                                            <asp:TextBox ID="txtChequeDate" type="date" CssClass="ajax__calendar_body form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>External Document No</label>
                                            <asp:TextBox ID="txtExternalDocumentNo" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Naration</label>
                                            <asp:TextBox ID="txtNaration" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <asp:Button runat="server" ID="btnCautionRefundUpdate" OnClick="btnCautionRefundUpdate_Click" Text="Update" CssClass="btn-s float-right submit" />
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12 NewEntrydiv">
                        <p class="NewEntry">Caution Refund Subform</p>
                    </div>
                    <div class="tab-pane active">
                        <div class="right_col_bg">
                            <div class="right_col_content label-responsive">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div id="exportto" style="overflow: visible">
                                            <asp:ListView ID="CautionMoneySubFormListView" runat="server">
                                                <LayoutTemplate>
                                                    <table runat="server" class="table table-bordered">
                                                        <tr runat="server">
                                                            <th style="text-align: center" runat="server">
                                                                <input type="checkbox" class="selectall" /></th>
                                                            <th style="text-align: center" runat="server">Refund Document No</th>
                                                            <th style="text-align: center" runat="server">Line No</th>
                                                            <th style="text-align: center" runat="server">Student No</th>
                                                            <th style="text-align: center" runat="server">Student Name</th>
                                                            <th style="text-align: center" runat="server">Amount</th>
                                                            <th style="text-align: center" runat="server">Action</th>
                                                        </tr>
                                                        <tr id="ItemPlaceholder" runat="server">
                                                        </tr>
                                                    </table>
                                                </LayoutTemplate>
                                                <ItemTemplate>
                                                    <tr class="TableData">
                                                        <td>
                                                            <input type="checkbox" id="chkitem" runat="server" class="selectone" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRefundDocNo" runat="server" Text='<%# Eval("Refund_Document_No")%>'> </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblLineNo" runat="server" Text='<%# Eval("Line_No")%>'> </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblStudentNo" runat="server" Text='<%# Eval("Student_No")%>'> </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Student_Name")%>'> </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount")%>'> </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click">Delete</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:ListView>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <asp:Button runat="server" ID="btndeleteall" OnClick="btndeleteall_Click" Text="Delete" CssClass="btn-s float-right submit" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
