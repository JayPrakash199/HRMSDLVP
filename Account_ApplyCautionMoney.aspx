<%@ Page Title="" Language="C#" MasterPageFile="~/Fee.Master" AutoEventWireup="true" CodeBehind="Account_ApplyCautionMoney.aspx.cs" Inherits="HRMS.Account_ApplyCautionMoney" %>

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
    <div class="container box">
        <div class="row">
            <div class="col-lg-3 col-md-2"></div>
            <div class="col-lg-12 col-md-12 model-box">
                <div class="col-lg-12 col-md-12 summary-box">
                    <div class="col-lg-12 NewEntrydiv">
                        <p class="NewEntry">Apply Caution Money</p>
                    </div>
                    <div class="row">
                        <div class="card-body">
                            <div class="row md-12 marginx">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-6 contact-info">
                                            <div class="container">
                                                <div class="form-group">
                                                    <label for="exampleAccount">Academic Year</label>
                                                    <asp:DropDownList ID="ddlAcademicYear" CssClass="form-control ajax__calendar_body" runat="server">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfacademicyear" ClientIDMode="Static" ControlToValidate="ddlAcademicYear" InitialValue="0" ValidationGroup="CautionMoney"
                                                        runat="server" Style="color: red; font-size: 11px; visibility: visible; text-align: left; position: absolute; left: 7%;" ErrorMessage="Select academic year *"></asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6 contact-info">
                                            <div class="container">

                                                <div class="form-group">
                                                    <label>Student No</label>
                                                    <asp:DropDownList ID="ddlStudentNo" CssClass="form-control ajax__calendar_body" runat="server">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rqstudentNo" ClientIDMode="Static" ControlToValidate="ddlStudentNo" InitialValue="0" ValidationGroup="CautionMoney"
                                                        runat="server" Style="color: red; font-size: 11px; visibility: visible; text-align: left; position: absolute; left: 7%;"
                                                        ErrorMessage="Select a student *"></asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12" style="padding: 10px">
                                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" CssClass="btn-s float-right btn-primary" ValidationGroup="CautionMoney" Text="Apply" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- <script language="Javascript">        
        var yearsLength = 30;
        var currentYear = new Date().getFullYear();
        for (var i = 0; i < 10; i++) {
            var next = currentYear + 1;
            var year = currentYear + '-' + next.toString().slice(-2);
            $("#<%= ddlAcademicYear.ClientID %>").append(new Option(year, year)); 
            currentYear--;
        }
    </script>--%>
</asp:Content>
