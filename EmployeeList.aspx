<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.Master" AutoEventWireup="true" CodeBehind="EmployeeList.aspx.cs" Inherits="HRMS.EmployeeList" %>

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
            margin-bottom: 5%;
        }

        p.NewEntry {
            float: left;
            font-weight: 600;
            color: black;
        }

        .col-lg-12.NewEntrydiv {
            background-color: #fff;
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
                        <p class="NewEntry">Employee List</p>
                    </div>
                    <div class="tab-pane active" id="1">
                        <div class="right_col_bg">
                            <div class="right_col_content border-box label-responsive">
                                <div class="row">
                                    <div class="col-md-12">
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
                                                                <th runat="server">Date of Increment</th>
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
                                    <div class="col-lg-12 ExportFoot">
                                        <asp:Button Style="margin:1%" ID="btnExport" OnClick="btnExport_Click" CssClass="exportcss btn-yellow" runat="server" Text="Export" />
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
