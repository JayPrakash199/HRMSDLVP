<%@ Page Title="" Language="C#" MasterPageFile="~/Fee.Master" AutoEventWireup="true" CodeBehind="Fee-StudentFeeCollectionCard.aspx.cs" Inherits="HRMS.Fee_StudentFeeCollectionCard" %>

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

        .row.md-12.marginx {
            margin: 4%;
            padding-bottom: 36px;
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
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.2/css/all.min.css" integrity="sha512-1sCRPdkRXhBV2PBLUdRb4tMg1w2YPf37qatUFeS7zlBy7jJI8Lf4VHwWfZZfpXtYSLy85pkm9GaYVYMfw5BC1A==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <div class="container box">
        <div class="row">
            <div class="col-lg-3 col-md-2"></div>
            <div class="col-lg-12 col-md-12 model-box">
                <div class="col-lg-12 col-md-12 summary-box">
                    <div class="col-lg-12 NewEntrydiv">
                        <p class="NewEntry">Student Fee Collection Card</p>
                    </div>
                    <div class="row">
                        <div class="card-body">
                            <div class="row md-12 marginx">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-6 contact-info">
                                            <div class="container">
                                                <div class="form-group">
                                                    <div class="col-sm-12">
                                                        <label for="exampleAccount">Type</label>
                                                    </div>
                                                    <div class="col-sm-10">
                                                        <asp:DropDownList ID="ddlType" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" CssClass="form-control" runat="server">
                                                            <asp:ListItem>Select</asp:ListItem>
                                                            <asp:ListItem Value="StudentFee">Student Fee</asp:ListItem>
                                                            <asp:ListItem Value="OtherIncome">Other Income</asp:ListItem>
                                                            <asp:ListItem Value="InternalTransfer">Internal Transfer</asp:ListItem>
                                                            <asp:ListItem Value="AdvancePayment">Advance Payment</asp:ListItem>
                                                            <asp:ListItem Value="StaffAdvanceRefund">Staff Advance Refund</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-sm-2" style="position: relative; margin-top: 6px">
                                                        <asp:RequiredFieldValidator ID="rdType" ClientIDMode="Static" ControlToValidate="ddlType" InitialValue="Select" ValidationGroup="Payment" runat="server" ForeColor="Red" Font-Size="20px" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </div>

                                                </div>
                                                <div class="form-group" runat="server" id="divCustomerNo">
                                                    <div class="col-sm-12">
                                                        <label for="exampleAccount">Student No</label>
                                                    </div>
                                                    <div class="col-sm-10">
                                                        <asp:DropDownList ID="ddlCustomerNo" CssClass="form-control" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-sm-2" style="position: relative; margin-top: 6px">
                                                        <asp:RequiredFieldValidator ID="rdStudentNo" ClientIDMode="Static" ControlToValidate="ddlCustomerNo" InitialValue="" ValidationGroup="Payment" runat="server" ForeColor="Red" Font-Size="20px" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </div>

                                                </div>
                                                <div class="form-group" runat="server" id="divEmployeeNo" visible="false">
                                                    <div class="col-sm-12">
                                                        <label for="exampleAccount">Employee No</label>
                                                    </div>
                                                    <div class="col-sm-10">
                                                        <asp:DropDownList ID="ddlEmployeeNo" CssClass="form-control" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-sm-2" style="position: relative; margin-top: 6px">
                                                        <asp:RequiredFieldValidator ID="rdEmpNo" ClientIDMode="Static" ControlToValidate="ddlEmployeeNo" InitialValue="0" ValidationGroup="Payment" runat="server" ForeColor="Red" Font-Size="20px" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </div>

                                                </div>

                                                <div class="form-group" runat="server" id="divExDocNo">
                                                    <div class="col-sm-12">
                                                        <label for="exampleAccount">Ext. Doc. No.</label>
                                                    </div>
                                                    <div class="col-sm-10">
                                                        <asp:TextBox ID="txtExDocNo" CssClass="form-control" runat="server">
                                                        </asp:TextBox>
                                                    </div>
                                                    <%--<div class="col-sm-2" style="position: relative; margin-top: 6px">
                                                        <asp:RequiredFieldValidator ID="rdExternalDocNo" ClientIDMode="Static" ControlToValidate="txtExDocNo" ValidationGroup="Payment" runat="server" ForeColor="Red" Font-Size="20px" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </div>--%>

                                                </div>
                                                <div class="form-group" runat="server" id="divNarration">

                                                    <div class="col-sm-12">
                                                        <label for="exampleAccount">Narration</label>

                                                    </div>
                                                    <div class="col-sm-10">
                                                        <asp:TextBox ID="txtNarration" CssClass="form-control" runat="server">
                                                        </asp:TextBox>
                                                    </div>
                                                    <div class="col-sm-2" style="position: relative; margin-top: 6px">
                                                        <asp:RequiredFieldValidator ID="rdNaration" ClientIDMode="Static" ControlToValidate="txtNarration" ValidationGroup="Payment" runat="server" ForeColor="Red" Font-Size="20px" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </div>

                                                </div>
                                                <div class="form-group">
                                                    <div class="col-sm-12">
                                                        <label>Posting Date</label>
                                                    </div>
                                                    <div class="col-sm-10">
                                                        <asp:TextBox ID="txtPostingDate" type="date" CssClass="form-control ajax__calendar_body" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="col-sm-2" style="position: relative; margin-top: 6px">
                                                        <asp:RequiredFieldValidator ID="rdPostingdte" ClientIDMode="Static" ControlToValidate="txtPostingDate" ValidationGroup="Payment" runat="server" ForeColor="Red" Font-Size="20px" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6 contact-info">
                                            <div class="container">
                                                <div class="form-group">
                                                    <div class="col-sm-12">
                                                        <label>Amount</label>
                                                    </div>
                                                    <div class="col-sm-10">
                                                        <asp:TextBox ID="txtAmount" CssClass="form-control" runat="server"></asp:TextBox>

                                                    </div>
                                                    <div class="col-sm-2" style="position: relative; margin-top: 6px">
                                                        <asp:RequiredFieldValidator ID="rfAmount" ClientIDMode="Static" ControlToValidate="txtAmount" ValidationGroup="Payment" runat="server" ForeColor="Red" Font-Size="20px" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="col-sm-12">
                                                        <label>Payment Type</label>
                                                    </div>
                                                    <div class="col-sm-10">
                                                        <asp:DropDownList ID="ddlPaymentType" AutoPostBack="true" OnSelectedIndexChanged="ddlPaymentType_SelectedIndexChanged" CssClass="form-control" runat="server">
                                                            <asp:ListItem Selected="True">Select</asp:ListItem>
                                                            <asp:ListItem>CASH</asp:ListItem>
                                                            <asp:ListItem>BANK</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-sm-2" style="position: relative; margin-top: 6px">
                                                        <asp:RequiredFieldValidator ID="rdPaymentType" ClientIDMode="Static" ControlToValidate="ddlPaymentType" InitialValue="Select" ValidationGroup="Payment" runat="server" ForeColor="Red" Font-Size="20px" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </div>

                                                </div>
                                                <div class="form-group" runat="server" id="divGLNo" visible="false">
                                                    <div class="col-sm-12">
                                                        <label>GL Account No</label>
                                                    </div>
                                                    <div class="col-sm-10">
                                                        <asp:DropDownList ID="ddlGLNo" CssClass="form-control" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-sm-2" style="position: relative; margin-top: 6px">
                                                        <asp:RequiredFieldValidator ID="rfGlNo" ClientIDMode="Static" ControlToValidate="ddlGLNo" InitialValue="0" ValidationGroup="Payment" runat="server" ForeColor="Red" Font-Size="20px" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </div>

                                                </div>
                                                <div class="form-group" runat="server" id="divCashGLAccount" visible="false">
                                                    <div class="col-sm-12">
                                                        <label>Cash GL Account No</label>

                                                    </div>
                                                    <div class="col-sm-10">
                                                        <asp:DropDownList ID="ddlCashGLAccountNo" CssClass="form-control" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-sm-2" style="position: relative; margin-top: 6px">
                                                        <asp:RequiredFieldValidator ID="rdCashGl" ClientIDMode="Static" ControlToValidate="ddlCashGLAccountNo" InitialValue="0" ValidationGroup="Payment" runat="server" ForeColor="Red" Font-Size="20px" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </div>

                                                </div>
                                                <div class="form-group" runat="server" id="divBankAccountNo" visible="false">
                                                    <div class="col-sm-12">
                                                        <label>Bank Account No</label>

                                                    </div>
                                                    <div class="col-sm-10">
                                                        <asp:DropDownList ID="ddlBankAccountNo" CssClass="form-control" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-sm-2" style="position: relative; margin-top: 6px">
                                                        <asp:RequiredFieldValidator ID="rfbankAccNo" ClientIDMode="Static" ControlToValidate="ddlBankAccountNo" InitialValue="0" ValidationGroup="Payment" runat="server" ForeColor="Red" Font-Size="20px" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </div>

                                                </div>
                                                <div class="form-group" runat="server" id="divTranNo" visible="false">
                                                    <div class="col-sm-12">
                                                        <label for="exampleAccount">Transcation No.</label>
                                                    </div>
                                                    <div class="col-sm-10">
                                                        <asp:TextBox ID="txtTranNo" CssClass="form-control" runat="server">
                                                        </asp:TextBox>
                                                    </div>
                                                    <%-- <div class="col-sm-2" Style="position: relative;margin-top: 6px">
                                                        <asp:RequiredFieldValidator ID="rftranNo" ClientIDMode="Static" ControlToValidate="txtTranNo"  ValidationGroup="Payment" runat="server" ForeColor="Red" Font-Size="20px" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </div>--%>
                                                </div>
                                                <div class="form-group" runat="server" id="divTranDate" visible="false">
                                                    <div class="col-sm-12">
                                                        <label for="exampleAccount">Transcation Date</label>
                                                    </div>
                                                    <div class="col-sm-10">
                                                        <asp:TextBox ID="txtTranDate" CssClass="form-control ajax__calendar_body" type="date" runat="server"></asp:TextBox>
                                                    </div>
                                                    <%--  <div class="col-sm-2" style="position: relative; margin-top: 6px">
                                                        <asp:RequiredFieldValidator ID="rfTranDate" ClientIDMode="Static" ControlToValidate="txtTranDate" ValidationGroup="Payment" runat="server" ForeColor="Red" Font-Size="20px" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </div>--%>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="dvdimension" visible="false" runat="server">
                                            <p style="border-bottom: 1px solid black; width: 96%; float: left; margin-left: 2%; font-weight: 700; font-size: larger;">
                                                Dimension
                                            </p>
                                            <div class="col-md-6 contact-info">
                                                <div class="container">
                                                    <div class="form-group">
                                                        <div class="col-sm-12">
                                                            <label for="InstiuteCode">Instiute Code</label>
                                                        </div>
                                                        <div class="col-sm-10">
                                                            <asp:DropDownList ID="ddlInstiuteCode" AutoPostBack="true" CssClass="form-control" runat="server">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-sm-2" style="position: relative; margin-top: 6px">
                                                            <asp:RequiredFieldValidator ID="rfInstituteCode" ClientIDMode="Static" ControlToValidate="ddlInstiuteCode" InitialValue="0" ValidationGroup="Payment" runat="server" ForeColor="Red" Font-Size="20px" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        </div>

                                                    </div>
                                                    <div class="form-group" runat="server">
                                                        <div class="col-sm-12">
                                                            <label for="exampleAccount">Department Code</label>
                                                        </div>
                                                        <div class="col-sm-10">
                                                            <asp:DropDownList ID="ddlDepartmentCode" CssClass="form-control" runat="server">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-sm-2" style="position: relative; margin-top: 6px">
                                                            <asp:RequiredFieldValidator ID="rfDepartment" ClientIDMode="Static" ControlToValidate="ddlDepartmentCode" InitialValue="0" ValidationGroup="Payment" runat="server" ForeColor="Red" Font-Size="20px" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        </div>

                                                    </div>


                                                </div>
                                            </div>
                                            <div class="col-md-6 contact-info">
                                                <div class="container">
                                                    <div class="form-group" runat="server" id="divEmpCode">
                                                        <div class="col-sm-12">
                                                            <label for="exampleAccount">Employee Code</label>
                                                        </div>
                                                        <div class="col-sm-10">
                                                            <asp:DropDownList ID="ddlEmployeeCode" CssClass="form-control" runat="server">
                                                            </asp:DropDownList>
                                                        </div>
                                                     <%--   <div class="col-sm-2" style="position: relative; margin-top: 6px">
                                                            <asp:RequiredFieldValidator ID="rfEmpCode" ClientIDMode="Static" ControlToValidate="ddlEmployeeCode" InitialValue="0" ValidationGroup="Payment" runat="server" ForeColor="Red" Font-Size="20px" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        </div>--%>


                                                    </div>
                                                    <div class="form-group" id="divfunding" runat="server">
                                                        <div class="col-sm-12">
                                                            <label for="exampleAccount">Funding source Code</label>
                                                        </div>
                                                        <div class="col-sm-10">
                                                            <asp:DropDownList ID="ddlFundingsourceCode" CssClass="form-control" runat="server">
                                                            </asp:DropDownList>
                                                        </div>
                                                       <%-- <div class="col-sm-2" style="position: relative; margin-top: 6px">
                                                            <asp:RequiredFieldValidator ID="rfFundingSource" ClientIDMode="Static" ControlToValidate="ddlFundingsourceCode" InitialValue="0" ValidationGroup="Payment" runat="server" ForeColor="Red" Font-Size="20px" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        </div>--%>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-12">
                            <asp:Button ID="btnSubmit" Style="margin: 2%" ValidationGroup="Payment" runat="server" OnClick="btnSubmit_Click" CssClass="btn-s float-right submit" Text="Submit" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
