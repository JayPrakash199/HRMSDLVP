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

        table {
            width: 100%;
            border-collapse: collapse;
        }

        th {
            text-align: left !important;
        }

        .filter-dropdown1 {
            position: absolute;
            background: #fff;
            border: 1px solid #ddd;
            padding: 10px;
            z-index: 1000;
            display: none; /* Hide by default */
            max-height: 200px; /* Fixed height */
            overflow-y: auto; /* Scrollable */
            color: black;
        }

        .filter-dropdown {
            position: absolute;
            background: #fff;
            border: 1px solid #ddd;
            padding: 10px;
            z-index: 1000;
            display: none; /* Hide by default */
            width: auto; /* Adjust width as needed */
            max-height: 300px; /* Adjust height as needed */
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
            border-radius: 4px; /* Rounded corners */
            color: black;
            box-shadow: rgba(0, 0, 0, 0.19) 0px 10px 20px, rgba(0, 0, 0, 0.23) 0px 6px 6px;
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

        label {
            display: inline-block !important;
            vertical-align: unset !important;
            margin-left: 7% !important;
            height: 20px !important;
        }

        .search-container {
            position: relative;
            margin-bottom: 10px;
        }

            .search-container .fa-search {
                position: absolute;
                left: 10px;
                top: 50%;
                transform: translateY(-50%);
                color: #aaa;
            }

            .search-container .form-control {
                padding-left: 30px; /* Ensure there's space for the icon */
                width: calc(100% - 20px); /* Ensure full width with padding */
                margin: 0 auto; /* Center the text box */
                box-sizing: border-box;
            }

        .scrollable-content {
            max-height: 200px; /* Adjust height as needed */
            overflow-y: auto; /* Make content scrollable */
            margin-bottom: 5px; /* Space for the footer */
        }

        .filter-footer {
            background: #fff; /* Ensure background color matches */
            text-align: center
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
                                                                <th runat="server">HRMS ID
                                                                    <a href="#" onclick="toggleFilter('divHRMSFilter')"><i id="filtericon" runat="server" class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="divHRMSFilter" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtHrmsFilter" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkHrmsFilter', 'ContentPlaceHolder1_EmployeeListView_txtHrmsFilter')" placeholder="Enter text to filter" Class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkHrmsFilter" CssClass="chkbox" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btnApplyHrmsFilter" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnApplyHrmsFilter_Click" />
                                                                            <asp:Button ID="btnCancelHrmsFilter" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('ContentPlaceHolder1_EmployeeListView_divHRMSFilter'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">Name Of the Staff
                                                                     <a href="#" onclick="toggleFilter('firstNameFilter')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="firstNameFilter" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtFirstNameFilter" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkFirstName', 'ContentPlaceHolder1_EmployeeListView_txtFirstNameFilter')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkFirstName" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btnApplyFirstNameFilter" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnApplyFirstNameFilter_Click" />
                                                                            <asp:Button ID="btnCancelFirstNameFilter" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('ContentPlaceHolder1_EmployeeListView_chkFirstName'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">Bill Group
                                                                     <a href="#" onclick="toggleFilter('DivbillGroupFilter')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="DivbillGroupFilter" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtBilGroup" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkBillGroup', 'ContentPlaceHolder1_EmployeeListView_txtBilGroup')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkBillGroup" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btnApplyBillGroupFilter" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnApplyBillGroupFilter_Click" />
                                                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('DivbillGroupFilter'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">Account Type
                                                                     <a href="#" onclick="toggleFilter('DivAcTypeFilter')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="DivAcTypeFilter" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtAcType" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkAcType', 'ContentPlaceHolder1_EmployeeListView_txtAcType')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkAcType" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btnApplyAcTypeFilter" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnApplyAcTypeFilter_Click" />
                                                                            <asp:Button ID="Button4" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('DivAcTypeFilter'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">Bill Type
                                                                     <a href="#" onclick="toggleFilter('divBillTypeFilter')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="divBillTypeFilter" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtBillType" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkBillType', 'ContentPlaceHolder1_EmployeeListView_txtBillType')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkBillType" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btnApplyBillTyeFilter" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnApplyBillTyeFilter_Click" />
                                                                            <asp:Button ID="Button6" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('divBillTypeFilter'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">Designation
                                                                     <a href="#" onclick="toggleFilter('divDesignation')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="divDesignation" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtDesignation" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkDesignation', 'ContentPlaceHolder1_EmployeeListView_txtDesignation')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkDesignation" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btnApplyDesinationFilter" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnApplyDesinationFilter_Click" />
                                                                            <asp:Button ID="Button8" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('divDesignation'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">Service Joining Designation
                                                                     <a href="#" onclick="toggleFilter('divSJD')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="divSJD" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtSJD" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkSJD', 'ContentPlaceHolder1_EmployeeListView_txtSJD')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkSJD" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btApplynSJDFilter" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btApplynSJDFilter_Click" />
                                                                            <asp:Button ID="Button10" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('divSJD'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">Dept./Trade/Section
                                                                     <a href="#" onclick="toggleFilter('divTrade')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="divTrade" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtTrade" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkTrade', 'ContentPlaceHolder1_EmployeeListView_txtTrade')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkTrade" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btnAppplyTradeFilter" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnAppplyTradeFilter_Click" />
                                                                            <asp:Button ID="Button12" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('divTrade'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">Post Group
                                                                     <a href="#" onclick="toggleFilter('divPostGroup')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="divPostGroup" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtPostGroup" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkPostGroup', 'ContentPlaceHolder1_EmployeeListView_txtPostGroup')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkPostGroup" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btnApplyPostGroupFilter" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnApplyPostGroupFilter_Click" />
                                                                            <asp:Button ID="Button14" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('divPostGroup'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">GPF/PRAN No.
                                                                     <a href="#" onclick="toggleFilter('divGPF')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="divGPF" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtGPF" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkGPF', 'ContentPlaceHolder1_EmployeeListView_txtGPF')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkGPF" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btnApplyGpfFilter" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnApplyGpfFilter_Click" />
                                                                            <asp:Button ID="Button16" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('divGPF'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">D.O.B <a href="#" onclick="toggleFilter('divDOB')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="divDOB" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtDOB" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkDOB', 'ContentPlaceHolder1_EmployeeListView_txtDOB')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkDOB" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btnApplyDOBFilter" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnApplyDOBFilter_Click" />
                                                                            <asp:Button ID="Button18" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('divDOB'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">Gender
                                                                     <a href="#" onclick="toggleFilter('divGender')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="divGender" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtGender" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkGender', 'ContentPlaceHolder1_EmployeeListView_txtGender')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkGender" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="Button19" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnApplyFirstNameFilter_Click" />
                                                                            <asp:Button ID="Button20" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('divGender'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">D.O.S
                                                                     <a href="#" onclick="toggleFilter('divDOS')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="divDOS" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtDOS" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkDOS', 'ContentPlaceHolder1_EmployeeListView_txtDOS')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkDOS" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btnApplyDOSFilter" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnApplyDOSFilter_Click" />
                                                                            <asp:Button ID="Button22" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('divDOS'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">Category
                                                                     <a href="#" onclick="toggleFilter('divCategory')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="divCategory" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtCategory" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkCategory', 'ContentPlaceHolder1_EmployeeListView_txtCategory')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkCategory" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btnApplyCategoryFilter" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnApplyCategoryFilter_Click" />
                                                                            <asp:Button ID="Button24" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('divCategory'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">Joining Station
                                                                     <a href="#" onclick="toggleFilter('divJS')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="divJS" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtJS" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkJS', 'ContentPlaceHolder1_EmployeeListView_txtJS')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkJS" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btnApplyJSFilter" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnApplyJSFilter_Click" />
                                                                            <asp:Button ID="Button26" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('divJS'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">D.O.J(Service)
                                                                     <a href="#" onclick="toggleFilter('DIVDOJ')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="DIVDOJ" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtDOJ" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkDOJ', 'ContentPlaceHolder1_EmployeeListView_txtDOJ')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkDOJ" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btnApplyDOJFilteer" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnApplyDOJFilteer_Click" />
                                                                            <asp:Button ID="Button28" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('DIVDOJ'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">Current Station
                                                                     <a href="#" onclick="toggleFilter('divCurrentStation')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="divCurrentStation" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtCurrentStation" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkCurrentStation', 'ContentPlaceHolder1_EmployeeListView_txtCurrentStation')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkCurrentStation" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btnApplyCurrentStationFilter" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnApplyCurrentStationFilter_Click" />
                                                                            <asp:Button ID="Button30" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('divCurrentStation'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">Joining Designation
                                                                     <a href="#" onclick="toggleFilter('divJoiningDesignation')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="divJoiningDesignation" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtJoiningDesignation" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkJoiningDesignation', 'ContentPlaceHolder1_EmployeeListView_txtJoiningDesignation')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkJoiningDesignation" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btnApplyJoiningDesignationFilter" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnApplyJoiningDesignationFilter_Click" />
                                                                            <asp:Button ID="Button32" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('divJoiningDesignation'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">Base Qualification
                                                                     <a href="#" onclick="toggleFilter('divBaseQualification')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="divBaseQualification" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtBaseQualification" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkBaseQualification', 'ContentPlaceHolder1_EmployeeListView_txtBaseQualification')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkBaseQualification" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btnApplyBaseQualificationFilter" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnApplyBaseQualificationFilter_Click" />
                                                                            <asp:Button ID="Button34" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('divBaseQualification'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">Basic Gr. Pay
                                                                     <a href="#" onclick="toggleFilter('divBasicPay')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="divBasicPay" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtBasicPay" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkBasicPay', 'ContentPlaceHolder1_EmployeeListView_txtBasicPay')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkBasicPay" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btnApplyBasicPayFilter" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnApplyBasicPayFilter_Click" />
                                                                            <asp:Button ID="Button36" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('divBasicPay'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">Employment Status
                                                                     <a href="#" onclick="toggleFilter('divEmploymentStatus')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="divEmploymentStatus" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtEmploymentStatus" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkEmploymentStatus', 'ContentPlaceHolder1_EmployeeListView_txtEmploymentStatus')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkEmploymentStatus" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btnApplyEmploymentStatusFilter" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnApplyEmploymentStatusFilter_Click" />
                                                                            <asp:Button ID="Button38" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('divEmploymentStatus'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">Date of Increment
                                                                     <a href="#" onclick="toggleFilter('divDateofIncrement')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="divDateofIncrement" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtDateofIncrement" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkDateofIncrement', 'ContentPlaceHolder1_EmployeeListView_txtDateofIncrement')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkDateofIncrement" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btnApplyDateofIncrementFilter" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnApplyDateofIncrementFilter_Click" />
                                                                            <asp:Button ID="Button40" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('divDateofIncrement'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">Email ID
                                                                     <a href="#" onclick="toggleFilter('divEmail')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="divEmail" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtEmail" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkEmail', 'ContentPlaceHolder1_EmployeeListView_txtEmail')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkEmail" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btnApplyEmailFilter" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnApplyEmailFilter_Click" />
                                                                            <asp:Button ID="Button42" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('divEmail'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">MACP Status
                                                                     <a href="#" onclick="toggleFilter('divMACP')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="divMACP" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtMACP" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkMACP', 'ContentPlaceHolder1_EmployeeListView_txtMACP')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkMACP" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btnApplyMACPFilter" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnApplyMACPFilter_Click" />
                                                                            <asp:Button ID="Button44" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('diMACP'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">EPIC No.
                                                                     <a href="#" onclick="toggleFilter('divEPIC')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="divEPIC" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtEPIC" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkEPIC', 'ContentPlaceHolder1_EmployeeListView_txtEPIC')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkEPIC" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btnApplyEPICFilter" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnApplyEPICFilter_Click" />
                                                                            <asp:Button ID="Button46" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('divEPIC'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">Mobile No.
                                                                     <a href="#" onclick="toggleFilter('divMobileNo')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="divMobileNo" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtMobileNo" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkMobileNo', 'ContentPlaceHolder1_EmployeeListView_txtMobileNo')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkMobileNo" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btnApplyMobileNoFilter" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnApplyMobileNoFilter_Click" />
                                                                            <asp:Button ID="Button48" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('divMobileNo'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">Pension Remark
                                                                     <a href="#" onclick="toggleFilter('divPensionRemark')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="divPensionRemark" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtPensionRemark" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkPensionRemark', 'ContentPlaceHolder1_EmployeeListView_txtPensionRemark')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkPensionRemark" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btnApplyPensionRemarkFilter" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnApplyPensionRemarkFilter_Click" />
                                                                            <asp:Button ID="Button50" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('divPensionRemark'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">Aadhaar No.
                                                                     <a href="#" onclick="toggleFilter('divAadhaarNo')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="divAadhaarNo" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtAadhaarNo" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkAadhaarNo', 'ContentPlaceHolder1_EmployeeListView_txtAadhaarNo')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkAadhaarNo" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btnApplyAadhaarNoFilter" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnApplyAadhaarNoFilter_Click" />
                                                                            <asp:Button ID="Button52" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('divAadhaarNo'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">Designation as per HRMS Site
                                                                     <a href="#" onclick="toggleFilter('divDesignationHRMS')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="divDesignationHRMS" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtDesignationHRMS" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkDesignationHRMS', 'ContentPlaceHolder1_EmployeeListView_txtDesignationHRMS')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkDesignationHRMS" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btnApplyDesignationHRMSFilter" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnApplyDesignationHRMSFilter_Click" />
                                                                            <asp:Button ID="Button54" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('divDesignationHRMS'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">Home Dist as per HRMS Site
                                                                     <a href="#" onclick="toggleFilter('divHomeDistHrms')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="divHomeDistHrms" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtHomeDistHrms" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkHomeDistHrms', 'ContentPlaceHolder1_EmployeeListView_txtHomeDistHrms')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkHomeDistHrms" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btnApplyHomeDistHrmsFilter" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnApplyHomeDistHrmsFilter_Click" />
                                                                            <asp:Button ID="Button56" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('divHomeDIst'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">Home Dist
                                                                     <a href="#" onclick="toggleFilter('divHomeDist')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="divHomeDist" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtHomeDist" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkHomeDist', 'ContentPlaceHolder1_EmployeeListView_txtHomeDist')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkHomeDist" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btnApplyHomeDistFilter" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnApplyHomeDistFilter_Click1" />
                                                                            <asp:Button ID="Button58" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('divHomeDist'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">Status
                                                                     <a href="#" onclick="toggleFilter('divStatus')"><i class="fa fa-filter" aria-hidden="true"></i></a>
                                                                    <div id="divStatus" class="filter-dropdown" style="display: none;">
                                                                        <div class="search-container">
                                                                            <i class="fa fa-search icon"></i>
                                                                            <asp:TextBox ID="txtStatus" runat="server" onkeyup="filterCheckboxList('ContentPlaceHolder1_EmployeeListView_chkStatus', 'ContentPlaceHolder1_EmployeeListView_txtStatus')" Class="form-control" placeholder="Enter text to filter"></asp:TextBox>
                                                                        </div>
                                                                        <div class="scrollable-content">
                                                                            <asp:CheckBoxList ID="chkStatus" runat="server"></asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="filter-footer">
                                                                            <asp:Button ID="btnApplyStatusFilter" runat="server" Text="OK" CssClass="btn-s float-right submit" OnClick="btnApplyStatusFilter_Click" />
                                                                            <asp:Button ID="Button60" runat="server" Text="Cancel" CssClass="btn-s float-right submit" OnClientClick="closeFilter('divStatus'); return false;" />
                                                                        </div>
                                                                    </div>
                                                                </th>
                                                                <th runat="server">Deployment Start Date
                                                                </th>
                                                                <th runat="server">Deployment End Date
                                                                </th>
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
                                                            <td>
                                                                <asp:Label ID="Label31" runat="server" Text='<%# Eval("Deployment_Start_Date")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label32" runat="server" Text='<%# Eval("Deployment_End_Date")%>'> </asp:Label>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:ListView>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 ExportFoot">
                                        <asp:Button Style="margin: 1%" ID="btnExport" OnClick="btnExport_Click" CssClass="exportcss btn-yellow" runat="server" Text="Export All" />
                                        <asp:Button Style="margin: 1%" ID="btnFilterExport" OnClick="btnFilterExport_Click" CssClass="exportcss btn-yellow" runat="server" Text="Export" />

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </contenttemplate>
    <script type="text/javascript">
        function toggleFilter(filterId) {
            var filterDiv = document.getElementById(filterId);
            if (filterDiv.style.display === "none") {
                filterDiv.style.display = "block";
            } else {
                filterDiv.style.display = "none";
            }
        }


        function filterCheckboxList(filterId, textboxId) {
            var filterText = document.getElementById(textboxId).value.toLowerCase();
            var checkBoxList = document.getElementById(filterId).getElementsByTagName('input');
            for (var i = 0; i < checkBoxList.length; i++) {
                var listItem = checkBoxList[i].parentNode;
                var text = listItem.innerText.toLowerCase();
                listItem.style.display = text.includes(filterText) ? '' : 'none';
            }
        }

        function closeFilter(filterId) {
            document.getElementById(filterId).style.display = 'none';
        }

    </script>
</asp:Content>
