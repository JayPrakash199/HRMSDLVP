﻿<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.Master" AutoEventWireup="true" CodeBehind="EmployeeReportList.aspx.cs" Inherits="HRMS.EmployeeReportList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .summary-box {
            height: auto;
            text-align: center;
            box-shadow: 0 3px 6px rgb(0 0 0 / 16%), 0 3px 6px rgb(0 0 0 / 23%);
            border: 1px solid;
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
            border-bottom: 1px solid;
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

        .col-md-6.space label {
            font-size: 8px;
            float: left;
            height: 12px;
        }

        i.fa.fa-search.icon {
            position: absolute;
            padding: 10px;
            display: block;
        }

        input#ContentPlaceHolder1_txtHRMSIDSearch {
            text-align: right;
        }
    </style>
    <div class="container box">
        <div class="row">
            <div class="col-lg-12 col-md-12 model-box">
                <div class="col-lg-12 col-md-12 summary-box">
                    <div class="col-lg-12 NewEntrydiv">
                        <p class="NewEntry">DTE&T HRMS EMPLOYEES QUERY PAGE</p>
                    </div>
                    <div class="row">
                        <div class="card-body">
                            <div class="row md-12 marginx">

                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-6 contact-info">
                                            <div class="container">
                                                <div class="form-group">
                                                    <label>Institute Name</label>
                                                    <asp:DropDownList ID="ddlInstituteType" CssClass="form-control" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label>Date of Service Joiing To</label>
                                                    <asp:TextBox ID="txtdosjto" CssClass="form-control ajax__calendar_body" type="date" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>HRMS ID</label>
                                                    <asp:TextBox ID="txtHrmsId" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>Designation</label>
                                                    <asp:DropDownList ID="ddlDesignation" CssClass="form-control" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label>Dept./Trade/Section</label>
                                                    <asp:DropDownList ID="ddlTrade" CssClass="form-control" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label>Post Group</label>
                                                    <asp:DropDownList ID="ddlPostGroup" CssClass="form-control" runat="server">
                                                        <asp:ListItem Selected="True">Select</asp:ListItem>
                                                        <asp:ListItem>A</asp:ListItem>
                                                        <asp:ListItem>B</asp:ListItem>
                                                        <asp:ListItem>C</asp:ListItem>
                                                        <asp:ListItem>D</asp:ListItem>
                                                    </asp:DropDownList>

                                                </div>
                                                <div class="form-group">
                                                    <label>Gross Pay Salary</label>
                                                    <asp:TextBox ID="txtGrossPay" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>Pension Remark</label>
                                                    <asp:DropDownList ID="ddlPensionRemark" CssClass="form-control" runat="server">
                                                        <asp:ListItem>Select</asp:ListItem>
                                                        <asp:ListItem>Regular</asp:ListItem>
                                                        <asp:ListItem>NPS</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6 contact-info">
                                            <div class="container">
                                                <div class="form-group">
                                                    <label>Institute Type</label>
                                                    <asp:TextBox ID="txtInstituteName" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>Date of Service Joiing From</label>
                                                    <asp:TextBox ID="txtDosjfrom" CssClass="form-control ajax__calendar_body" type="date" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>Account Type</label>
                                                    <asp:DropDownList ID="ddlAccountType" CssClass="form-control" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label>Service Joining Designation</label>
                                                    <asp:DropDownList ID="ddlServiceJoiningDesignation" CssClass="form-control" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label>Gender</label>
                                                    <asp:DropDownList ID="ddlGender" CssClass="form-control" runat="server">
                                                        <asp:ListItem>Select</asp:ListItem>
                                                        <asp:ListItem>Male</asp:ListItem>
                                                        <asp:ListItem>Female</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label>Current Station</label>
                                                    <asp:DropDownList ID="ddlCurrentStation" CssClass="form-control" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label>Employment Status</label>
                                                    <asp:DropDownList ID="ddlEmplyomentStatus" CssClass="form-control" runat="server">
                                                        <asp:ListItem>Select</asp:ListItem>
                                                        <asp:ListItem Value="Ad_hoc">Ad hoc</asp:ListItem>
                                                        <asp:ListItem Value="Temporary_status">Temporary status</asp:ListItem>
                                                        <asp:ListItem Value="Initial_appointee">Initial appointee</asp:ListItem>
                                                        <asp:ListItem Value="Regular">Regular</asp:ListItem>
                                                        <asp:ListItem Value="Inactive">Inactive</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label>MACP Status</label>
                                                    <asp:DropDownList ID="ddlMACPStatus" CssClass="form-control" runat="server">
                                                        <asp:ListItem Value="Nil">Nil</asp:ListItem>
                                                        <asp:ListItem Value="1st">1st</asp:ListItem>
                                                        <asp:ListItem Value="2nd">2nd</asp:ListItem>
                                                        <asp:ListItem Value="3rd">3rd</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <asp:Button ID="btnEmployeeFilter" OnClick="btnEmployeeFilter_Click" runat="server" CssClass="btn-s float-right submit" Text="Submit" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-2">
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12" style="margin-top:4%">
                        <div class="table-responsive">
                            <div id="exportto" style="height: 390px; overflow: visible">
                                <asp:ListView ID="EmployeeListView" runat="server">
                                    <LayoutTemplate>
                                        <table runat="server" class="table table-bordered">
                                            <tr runat="server" class="FridgeHeader">
                                                <th runat="server">HRMS ID</th>
                                                <th runat="server">Name Of the Staff</th>
                                                <th runat="server">Bill Group</th>
                                                <th runat="server">Account Type</th>
                                                <th runat="server">Bill Type</th>
                                                <th runat="server">Designation</th>
                                                <th runat="server">Service Joining Designation</th>
                                                <th runat="server">Dept./Trade/Section</th>
                                                <th runat="server">Post Group</th>
                                                <th runat="server">GPF/PRAN No.</th>
                                                <th runat="server">D.O.B</th>
                                                <th runat="server">Gender</th>
                                                <th runat="server">D.O.S</th>
                                                <th runat="server">Category</th>
                                                <th runat="server">Joining Station</th>
                                                <th runat="server">D.O.J(Service)</th>
                                                <th runat="server">Current Station</th>
                                                <th runat="server">Joining Designation</th>
                                                <th runat="server">Base Qualification</th>
                                                <th runat="server">Basic Gr. Pay</th>
                                                <th runat="server">Employment Status</th>
                                                <th runat="server">Date ofIncrement</th>
                                                <th runat="server">Email ID</th>
                                                <th runat="server">MACP Status</th>
                                                <th runat="server">EPIC No.</th>
                                                <th runat="server">Mobile No.</th>
                                                <th runat="server">Pension Remark</th>
                                                <th runat="server">Aadhaar No.</th>
                                                <th runat="server">Designation as per HRMS Site</th>
                                                <th runat="server">Home Dist as per HRMS Site</th>
                                                <th runat="server">Home Dist</th>
                                                <th runat="server">Status</th>
                                            </tr>
                                            <tr id="ItemPlaceholder" runat="server">
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <tr class="TableData">
                                            <td>
                                                <asp:Label ID="lblProjectCode" runat="server" Text='<%# Eval("No")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblProjectType" runat="server" Text='<%# Eval("First_Name")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Bill_Group")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Account_Type")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Bill_Type")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("Designation")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label27" runat="server" Text='<%# Eval("Service_Joining_Designation")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("Dept_Trade_Section")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label26" runat="server" Text='<%# Eval("Post_Group")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("GPF_PRAN_No")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label7" runat="server" Text='<%# DateTime.Parse(Eval("Birth_Date").ToString()).ToString("d") %>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label9" runat="server" Text='<%# Eval("Gender")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label10" runat="server" Text='<%# DateTime.Parse(Eval("D_O_S").ToString()).ToString("d") %>'> </asp:Label>

                                            </td>
                                            <td>
                                                <asp:Label ID="Label11" runat="server" Text='<%# Eval("Category")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label12" runat="server" Text='<%# Eval("Joining_Station")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label13" runat="server" Text='<%# DateTime.Parse(Eval("D_O_J_Service").ToString()).ToString("d") %>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label14" runat="server" Text='<%# Eval("Current_Station")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label15" runat="server" Text='<%# Eval("Service_Joining_Designation")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label16" runat="server" Text='<%# Eval("Base_Qualification")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label18" runat="server" Text='<%# Eval("Basic_Gr_Pay")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label19" runat="server" Text='<%# Eval("Employment_Status")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label8" runat="server" Text='<%# DateTime.Parse(Eval("Date_of_increment").ToString()).ToString("d") %>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label20" runat="server" Text='<%# Eval("E_Mail")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label21" runat="server" Text='<%# Eval("MACP_Status")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label22" runat="server" Text='<%# Eval("EPIC_No")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label23" runat="server" Text='<%# Eval("Mobile_Phone_No")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label24" runat="server" Text='<%# Eval("Pension_Remark")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label25" runat="server" Text='<%# Eval("Aadhaar_No")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label28" runat="server" Text='<%# Eval("Designation_as_per_HRMS_Site")%>'> </asp:Label>
                                            </td>

                                            <td>
                                                <asp:Label ID="Label29" runat="server" Text='<%# Eval("Home_Dist_as_per_HRMS_Site")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label30" runat="server" Text='<%# Eval("Home_Dist")%>'> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label17" runat="server" Text='<%# Eval("Status")%>'> </asp:Label>
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
</asp:Content>