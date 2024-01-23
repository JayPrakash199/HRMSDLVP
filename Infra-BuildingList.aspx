<%@ Page Title="" Language="C#" MasterPageFile="~/Infrastructure.Master" AutoEventWireup="true" CodeBehind="Infra-BuildingList.aspx.cs" Inherits="HRMS.InfraBuildingList" %>
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
    </style>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.2/css/all.min.css" integrity="sha512-1sCRPdkRXhBV2PBLUdRb4tMg1w2YPf37qatUFeS7zlBy7jJI8Lf4VHwWfZZfpXtYSLy85pkm9GaYVYMfw5BC1A==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <contenttemplate>

        <div class="container box">
            <div class="row">
                <div class="col-lg-3 col-md-2"></div>
                <div class="col-lg-12 col-md-12 summary-box">
                    <div class="col-lg-12 NewEntrydiv">
                        <p class="NewEntry">Building List</p>
                    </div>
                    <div class="tab-pane active" id="1">
                        <div class="right_col_bg">
                            <div class="right_col_content border-box label-responsive">
                                <div class="row">
                                    <div class="col-md-3 contact-info">
                                        <div class="form-group">
                                            <label for="exampleAccount">Type of Building</label>
                                            <asp:DropDownList ID="ddlBuldingType" AutoPostBack="True" CssClass="form-control select" runat="server">
                                                <asp:ListItem>Select Bulding Type</asp:ListItem>
                                                <asp:ListItem>Hostel</asp:ListItem>
                                                <asp:ListItem>Institute</asp:ListItem>
                                                <asp:ListItem>StaffQuarter</asp:ListItem>
                                                <asp:ListItem>Auditorium</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="table-responsive">
                                            <div id="exportto">
                                                <asp:ListView ID="HostelBuildingListView" runat="server">
                                                    <EmptyDataTemplate>
                                                        There are no records
                                                    </EmptyDataTemplate>
                                                    <LayoutTemplate>
                                                        <table runat="server" class="table table-bordered">
                                                            <tr runat="server">
                                                                <th runat="server">Block Code</th>
                                                                <th runat="server">Block Name</th>
                                                                <th runat="server">Hostel Type</th>
                                                                <th runat="server">No Of Room</th>
                                                                <th runat="server">No Of Floor</th>
                                                                <th runat="server">Total Floor Area in sqft</th>
                                                                <th runat="server">Total Capacity</th>
                                                                <th runat="server">Building Length</th>
                                                                <th runat="server">Building Width</th>
                                                                <th runat="server">Building Height</th>
                                                                <th runat="server">Fire Safety Status</th>
                                                                <th runat="server">Fire Safety Valid Upto</th>
                                                                <th runat="server">Layout Plan No</th>
                                                                <th runat="server">Approval Status</th>
                                                                <th runat="server">Electricity Agency</th>
                                                                <th runat="server">Book Of Account</th>
                                                                <th runat="server">Electricity Load in KW</th>
                                                                <th runat="server">Electricity Consumer No</th>
                                                                <th runat="server">Transformer Type</th>
                                                                <th runat="server">Source Of Water</th>
                                                                <th runat="server">PHD Consumer No</th>
                                                                <th runat="server">Building Safety Status</th>
                                                                <th runat="server">Year of Construction</th>
                                                                <th runat="server">No of RO Water Purifier</th>
                                                                <th runat="server">No of Non RO Water Purifier</th>
                                                                <th runat="server">Download Master Plan File</th>
                                                                <th runat="server">Upload Master Plan File</th>
                                                            </tr>
                                                            <tr id="ItemPlaceholder" runat="server">
                                                            </tr>
                                                        </table>
                                                    </LayoutTemplate>
                                                    <ItemTemplate>
                                                        <tr class="TableData">
                                                            <td>
                                                                <asp:Label ID="lblHostelBlockCode" runat="server" Text='<%# Eval("Block_Code")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblProjectType" runat="server" Text='<%# Eval("Block_Name")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Hostel_Type")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("No_Of_Room")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("No_Of_Floor")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label40" runat="server" Text='<%# Eval("Total_Floor_Area_in_sqft")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label41" runat="server" Text='<%# Eval("Total_Capacity")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label42" runat="server" Text='<%# Eval("Building_Length")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label43" runat="server" Text='<%# Eval("Building_Breadth_in_meter")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label44" runat="server" Text='<%# Eval("Building_Height")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label45" runat="server" Text='<%# Eval("Fire_Safety_Status")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label46" runat="server" Text='<%# DateTime.Parse(Eval("Fire_Safety_Valid_Upto").ToString()).ToString("d") %>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label47" runat="server" Text='<%# Eval("Layout_Plan_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label48" runat="server" Text='<%# Eval("Approval_Status")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label49" runat="server" Text='<%# Eval("Electricity_Agency")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label50" runat="server" Text='<%# Eval("Book_Of_Account")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label51" runat="server" Text='<%# Eval("Electricity_Load_in_KW")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label52" runat="server" Text='<%# Eval("Electricity_Consumer_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label53" runat="server" Text='<%# Eval("Transformer_Type")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label54" runat="server" Text='<%# Eval("Source_Of_Water")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label55" runat="server" Text='<%# Eval("PHD_Consumer_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label56" runat="server" Text='<%# Eval("Building_Safety_Status")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label57" runat="server" Text='<%# Eval("Year_of_Construction")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label58" runat="server" Text='<%# Eval("No_of_RO_Water_Purifier")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label59" runat="server" Text='<%# Eval("No_of_Non_RO_Water_Purifier")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="btnHostelDownload" runat="server" OnClick="btnHostelDownload_Click"><i class="fa-regular fa-file"></i></asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <div class="input-group">
                                                                    <label class="input-group-btn">
                                                                        <span class="custom-file-input btn">
                                                                            <asp:FileUpload ID="hostelBuildingpdfUploader" runat="server" Style="display: none" accept=".pdf" />
                                                                            <asp:LinkButton ID="hostelBuildingUpload" CssClass="btn btn-yellow" OnClick="hostelBuildingUpload_Click" runat="server">Upload</asp:LinkButton>
                                                                        </span>
                                                                    </label>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:ListView>
                                                <asp:ListView ID="AuditoriumListView" runat="server">
                                                    <EmptyDataTemplate>
                                                        There are no records
                                                    </EmptyDataTemplate>
                                                    <LayoutTemplate>
                                                        <table runat="server" class="table table-bordered">
                                                            <tr runat="server">
                                                                <th runat="server">Building Code</th>
                                                                <th runat="server">Building Name</th>
                                                                <th runat="server">Total Capacity</th>
                                                                <th runat="server">Total Floor Area in sqft</th>
                                                                <th runat="server">Building Length</th>
                                                                <th runat="server">Building Width</th>
                                                                <th runat="server">Building Height</th>
                                                                <th runat="server">Fire Safety Status</th>
                                                                <th runat="server">Fire Safety Valid Upto</th>
                                                                <th runat="server">Layout Plan No</th>
                                                                <th runat="server">Approval Status</th>
                                                                <th runat="server">Electricity Agency</th>
                                                                <th runat="server">Book Of Account</th>
                                                                <th runat="server">Electricity Load in KW</th>
                                                                <th runat="server">Electricity Consumer No</th>
                                                                <th runat="server">Building Safety Status</th>
                                                                <th runat="server">Year of Construction</th>
                                                                <th runat="server">Download Master Plan File</th>
                                                                <th runat="server">Upload Master Plan File</th>
                                                            </tr>
                                                            <tr id="ItemPlaceholder" runat="server">
                                                            </tr>
                                                        </table>
                                                    </LayoutTemplate>
                                                    <ItemTemplate>
                                                        <tr class="TableData">
                                                            <td>
                                                                <asp:Label ID="lblAuditoriumBuildingCode" runat="server" Text='<%# Eval("Building_Code")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblProjectType" runat="server" Text='<%# Eval("Building_Name")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Total_Capacity")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("Total_Floor_Area_in_sqft")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Building_Length")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Building_Breadth_in_Meter")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label60" runat="server" Text='<%# Eval("Building_Height")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label24" runat="server" Text='<%# DateTime.Parse(Eval("Fire_Safety_Valid_Upto").ToString()).ToString("d") %>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label62" runat="server" Text='<%# Eval("Fire_Safety_Valid_Upto")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label63" runat="server" Text='<%# Eval("Layout_Plan_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label64" runat="server" Text='<%# Eval("Approval_Status")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label65" runat="server" Text='<%# Eval("Electricity_Agency")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label66" runat="server" Text='<%# Eval("Book_Of_Account")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label67" runat="server" Text='<%# Eval("Electricity_Load_in_KW")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label68" runat="server" Text='<%# Eval("Electricity_Consumer_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label69" runat="server" Text='<%# Eval("Building_Safety_Status")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label70" runat="server" Text='<%# Eval("Year_of_Construction")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="btnAuditoriumDownload" runat="server" OnClick="btnAuditoriumDownload_Click"><i class="fa-regular fa-file"></i></asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <div class="input-group">
                                                                    <label class="input-group-btn">
                                                                        <span class="custom-file-input btn">
                                                                            <asp:FileUpload ID="auditoriumpdfUploader" runat="server" Style="display: none" accept=".pdf" />
                                                                            <asp:LinkButton ID="auditoriumUpload" CssClass="btn btn-yellow" OnClick="auditoriumUpload_Click" runat="server">Upload</asp:LinkButton>
                                                                        </span>
                                                                    </label>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:ListView>
                                                <asp:ListView ID="InstituteListView" runat="server">
                                                    <EmptyDataTemplate>
                                                        There are no records
                                                    </EmptyDataTemplate>
                                                    <LayoutTemplate>
                                                        <table runat="server" class="table table-bordered">
                                                            <tr runat="server">
                                                                <th runat="server">Block Code</th>
                                                                <th runat="server">Block Name</th>
                                                                <th runat="server">Block Type</th>
                                                                <th runat="server">No Of Class Room</th>
                                                                <th runat="server">No Of Floor</th>
                                                                <th runat="server">Total Floor Area in sqft</th>
                                                                <th runat="server">Building Length in meter</th>
                                                                <th runat="server">Building Width in meter</th>
                                                                <th runat="server">Building Height in meter</th>
                                                                <th runat="server">Fire Safety Status</th>
                                                                <th runat="server">Fire Safety Valid Upto</th>
                                                                <th runat="server">Layout Plan No</th>
                                                                <th runat="server">Approval Status</th>
                                                                <th runat="server">Electricity Agency</th>
                                                                <th runat="server">Book Of Account</th>
                                                                <th runat="server">Electricity Load in KW</th>
                                                                <th runat="server">Electricity Consumer No</th>
                                                                <th runat="server">Transformer Type</th>
                                                                <th runat="server">Source Of Water</th>
                                                                <th runat="server">PHD Consumer No</th>
                                                                <th runat="server">Building Safety Status</th>
                                                                <th runat="server">Year of Construction</th>
                                                                <th runat="server">No of Smart Classes</th>
                                                                <th runat="server">Computer Lab Available</th>
                                                                <th runat="server">No of RO Water Purifier</th>
                                                                <th runat="server">No of Non RO Water Purifier</th>
                                                                <th runat="server">Download Master Plan File</th>
                                                                <th runat="server">Upload Master Plan File</th>
                                                            </tr>
                                                            <tr id="ItemPlaceholder" runat="server">
                                                            </tr>
                                                        </table>
                                                    </LayoutTemplate>
                                                    <ItemTemplate>
                                                        <tr class="TableData">
                                                            <td>
                                                                <asp:Label ID="lblInstituteBlockCode" runat="server" Text='<%# Eval("Block_Code")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblProjectType" runat="server" Text='<%# Eval("Block_Name_if_any")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Block_Type_if_any")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("No_Of_Class_Room")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("No_Of_Floor")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label19" runat="server" Text='<%# Eval("Total_Floor_Area_in_sqft")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label20" runat="server" Text='<%# Eval("Building_Length_in_meter")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label21" runat="server" Text='<%# Eval("Building_Width_in_meter")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label22" runat="server" Text='<%# Eval("Building_Height_in_meter")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label23" runat="server" Text='<%# Eval("Fire_Safety_Status")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label24" runat="server" Text='<%# DateTime.Parse(Eval("Fire_Safety_Valid_Upto").ToString()).ToString("d") %>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label25" runat="server" Text='<%# Eval("Layout_Plan_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label26" runat="server" Text='<%# Eval("Approval_Status")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label27" runat="server" Text='<%# Eval("Electricity_Agency")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label28" runat="server" Text='<%# Eval("Book_Of_Account")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label29" runat="server" Text='<%# Eval("Electricity_Load_in_KW")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label30" runat="server" Text='<%# Eval("Electricity_Consumer_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label31" runat="server" Text='<%# Eval("Transformer_Type")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label32" runat="server" Text='<%# Eval("Source_Of_Water")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label33" runat="server" Text='<%# Eval("PHD_Consumer_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label34" runat="server" Text='<%# Eval("Building_Safety_Status")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label35" runat="server" Text='<%# Eval("Year_of_Construction")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label36" runat="server" Text='<%# Eval("No_of_Smart_Classes")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label37" runat="server" Text='<%# Eval("Computer_Lab_Available")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label38" runat="server" Text='<%# Eval("No_of_RO_Water_Purifier")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label39" runat="server" Text='<%# Eval("No_of_Non_RO_Water_Purifier")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="btnInstituteDownload" runat="server" OnClick="btnInstituteDownload_Click"><i class="fa-regular fa-file"></i></asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <div class="input-group">
                                                                    <label class="input-group-btn">
                                                                        <span class="custom-file-input btn">
                                                                            <asp:FileUpload ID="InstitutepdfUploader" runat="server" Style="display: none" accept=".pdf" />
                                                                            <asp:LinkButton ID="InstituteUpload" CssClass="btn btn-yellow" OnClick="InstituteUpload_Click" runat="server">Upload</asp:LinkButton>
                                                                        </span>
                                                                    </label>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:ListView>
                                                <asp:ListView ID="StaffQuarterListView" runat="server">
                                                    <EmptyDataTemplate>
                                                        There are no records
                                                    </EmptyDataTemplate>
                                                    <LayoutTemplate>
                                                        <table runat="server" class="table table-bordered">
                                                            <tr runat="server">
                                                                <th runat="server">Quarter Code</th>
                                                                <th runat="server">Quarter Block Name </th>
                                                                <th runat="server">Quarter Type </th>
                                                                <th runat="server">Occupancy Status</th>
                                                                <th runat="server">Fire Safety Valid Upto</th>
                                                                <th runat="server">Book Of Account</th>
                                                                <th runat="server">No Of Floor</th>
                                                                <th runat="server">No Of Room</th>
                                                                <th runat="server">Layout Plan No</th>
                                                                <th runat="server">Year of Construction</th>
                                                                <th runat="server">Electricity Agency</th>
                                                                <th runat="server">Electricity Connection Status</th>
                                                                <th runat="server">Electricity Consumer No</th>
                                                                <th runat="server">Electricity Load in KW</th>
                                                                <th runat="server">Approval Status</th>
                                                                <th runat="server">Building Width </th>
                                                                <th runat="server">Building Height</th>
                                                                <th runat="server">Building Length</th>
                                                                <th runat="server">Building Safety Status</th>
                                                                <th runat="server">Download Master Plan File</th>
                                                                <th runat="server">Upload Master Plan File</th>
                                                            </tr>
                                                            <tr id="ItemPlaceholder" runat="server">
                                                            </tr>
                                                        </table>
                                                    </LayoutTemplate>
                                                    <ItemTemplate>
                                                        <tr class="TableData">
                                                            <td>
                                                                <asp:Label ID="lblStaffQuarterCode" runat="server" Text='<%# Eval("Quarter_Code")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblProjectType" runat="server" Text='<%# Eval("Quarter_Block_Name")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Quarter_Type")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Occupancy_Status")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label4" runat="server" Text='<%# DateTime.Parse(Eval("Fire_Safety_Valid_Upto").ToString()).ToString("d") %>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Book_Of_Account")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("No_Of_Floor")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label7" runat="server" Text='<%# Eval("No_Of_Room")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label8" runat="server" Text='<%# Eval("Layout_Plan_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label9" runat="server" Text='<%# Eval("Year_of_Construction")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label10" runat="server" Text='<%# Eval("Electricity_Agency")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label11" runat="server" Text='<%# Eval("Electricity_Connection_Status")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label12" runat="server" Text='<%# Eval("Electricity_Consumer_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label13" runat="server" Text='<%# Eval("Electricity_Load_in_KW")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label14" runat="server" Text='<%# Eval("Approval_Status")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label15" runat="server" Text='<%# Eval("Building_Breadth_in_Meter")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label16" runat="server" Text='<%# Eval("Building_Height")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label17" runat="server" Text='<%# Eval("Building_Length")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label18" runat="server" Text='<%# Eval("Building_Safety_Status")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="btnStaffQuarterDownload" runat="server" OnClick="btnStaffQuarterDownload_Click"><i class="fa-regular fa-file"></i></asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <div class="input-group">
                                                                    <label class="input-group-btn">
                                                                        <span class="custom-file-input btn">
                                                                            <asp:FileUpload ID="StaffQuarterpdfUploader" runat="server" Style="display: none" accept=".pdf" />
                                                                            <asp:LinkButton ID="StaffQuarterUpload" CssClass="btn btn-yellow" OnClick="StaffQuarterUpload_Click" runat="server">Upload</asp:LinkButton>
                                                                        </span>
                                                                    </label>
                                                                </div>
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

