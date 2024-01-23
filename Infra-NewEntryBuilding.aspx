<%@ Page Title="" Language="C#" MasterPageFile="~/Infrastructure.Master" AutoEventWireup="true" CodeBehind="Infra-NewEntryBuilding.aspx.cs" Inherits="HRMS.NewEntryBuilding" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.12.1/css/all.css" />

    <style>
        .summary-box {
            margin-top: 75px;
            height: auto;
            text-align: center;
            box-shadow: 0 3px 6px rgba(0, 0, 0, 0.16), 0 3px 6px rgba(0, 0, 0, 0.23);
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
            border-bottom: 3px solid black;
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
         .col-lg-12.col-md-12.summary-box {
    margin: 94px 10px 10px -113px;
}
    </style>

    <div class="container box" id="booggg">
        <div class="row">
            <div class="col-lg-3 col-md-2"></div>
            <%-- Master Data --%>
            <div class="col-lg-12 col-md-12  summary-box">
                <div class="col-lg-12 NewEntrydiv">
                    <p class="NewEntry">New Entry - Master Data On Building</p>
                </div>
                <div class="row">
                    <div class="card-body">
                        <div class="row md-12 marginx">
                            <div class="col-md-6 ">
                                <div class="row">
                                    <div class="col-md-6 ">
                                        <label for="exampleAccount">Type of Buliding </label>
                                    </div>
                                    <div class="col-md-5 ">
                                        <asp:DropDownList ID="ddlBuildingList" CssClass="form-control select" runat="server">
                                            <asp:ListItem Selected="True" Value="InstitutionalBuildings">Institutional Building</asp:ListItem>
                                            <asp:ListItem Value="HostelBuildings">Hostel Building</asp:ListItem>
                                            <asp:ListItem Value="StaffQuarters">Staff Quarter</asp:ListItem>
                                            <asp:ListItem Value="Auditoriums">Auditorium</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <%--<div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-6 ">
                                        <label for="exampleCtrl">Total Number of block Available</label>
                                    </div>
                                    <div class="col-md-5 ">
                                        <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>--%>
                            <!-- Institutional Building -->
                            <div class="col-md-12 show-hide InstitutionalBuildings" id="InstitutionalBuildings">
                                <div class="row">
                                    <div class="col-md-6 ">
                                        <div class="row">
                                            <div class="col-md-6 ">
                                                <i class="fal fa-plus-circle full"></i>
                                            </div>
                                            <div class="col-md-6 ">
                                                <input class="Addaditional" type="button" data-toggle="modal" data-target="#InstitutionalBuilding" value="Add Additional Institutional Building Block Details" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%-- Hostel Building --%>
                            <div class="col-md-12 show-hide HostelBuildings" id="HostelBuildings">
                                <div class="row">
                                    <div class="col-md-6 ">
                                        <div class="row">
                                            <div class="col-md-6 ">
                                                <i class="fal fa-plus-circle full"></i>
                                            </div>
                                            <div class="col-md-6 ">
                                                <input class="Addaditional" type="button" data-toggle="modal" data-target="#HostelBuilding" value="Add Additional Hostel Building Block Details" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%-- Staff Quarter --%>
                            <div class="col-md-12 show-hide StaffQuarters" id="StaffQuarters">
                                <div class="row">
                                    <div class="col-md-6 ">
                                        <div class="row">
                                            <div class="col-md-6 ">
                                                <i class="fal fa-plus-circle full"></i>
                                            </div>
                                            <div class="col-md-6 ">
                                                <input class="Addaditional" type="button" data-toggle="modal" data-target="#StaffQuarter" value="Add Additional Staff Quarter Block Details" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%-- Auditorium Quarter --%>
                            <div class="col-md-12 show-hide Auditoriums" id="Auditoriums">
                                <div class="row">
                                    <div class="col-md-6 ">
                                        <div class="row">
                                            <div class="col-md-6 ">
                                                <i class="fal fa-plus-circle full"></i>
                                            </div>
                                            <div class="col-md-6 ">
                                                <input class="Addaditional" type="button" data-toggle="modal" data-target="#Auditorium" value="Add Additional Auditorium Quarter Block Details" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <asp:Button ID="btnExport" OnClick="btnExport_Click" runat="server" CssClass="btn-s float-right submit btn-yellow" Text="Export" />
                            </div>
                        </div>
                    </div>

                </div>
                <div class="col-lg-3 col-md-2">
                </div>
            </div>
        </div>
        <!-- Institutional Building -->
        <div class="modal fade" id="InstitutionalBuilding" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="col-lg-12 NewEntrydiv">
                            <p class="NewEntry">New Entry - Master Data On Building</p>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>

                    </div>

                    <div class="modal-body">
                        <div class="row">
                            <div class="col-lg-3 col-md-2"></div>
                            <div class="col-lg-12 col-md-12 model-box">
                                <div class="row">
                                    <div class="card-body">
                                        <div class="row md-12 marginx">
                                            <div class="headerbox">
                                                <div class="col-md-6 Buliding">
                                                    <div class="row">
                                                        <div class="col-md-6 ">
                                                            <label for="exampleAccount">Type of Buliding </label>
                                                        </div>
                                                        <div class="col-md-6 ">
                                                            <asp:DropDownList ID="DropDownList2" CssClass="form-control select" runat="server">
                                                                <asp:ListItem Selected="True">Institutional Building</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <%--<div class="col-md-6 Buliding">
                                                    <div class="row">
                                                        <div class="col-md-6 ">
                                                            <label for="exampleCtrl">Total Number of block Available</label>
                                                        </div>
                                                        <div class="col-md-5 ">
                                                            <asp:TextBox ID="TextBox2" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>--%>
                                            </div>


                                            <div class="col-md-12">
                                                <div class="row">
                                                    <h3 class="hadingline">Enter Institutional Building Details Below</h3>
                                                    <div class="col-md-6 contact-info">
                                                        <div class="container">
                                                            <%--<div class="form-group">
                                                                <label for="exampleAccount">Buliding Block Code</label>
                                                                <asp:TextBox ID="txtInstituteBlockCode" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>--%>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Buliding Block Type <span>(if any)</span></label>
                                                                <asp:TextBox ID="txtInstituteBuildingBlock" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">No. of class room available</label>
                                                                <asp:TextBox ID="txtInstituteClassRoomNumber" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Total area of floor/s in sqft</label>
                                                                <asp:TextBox ID="txtInstituteTotalArea" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Width of the Building Block (in meter)</label>
                                                                <asp:TextBox ID="txtInstituteBreath" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Fire Safety Status</label>
                                                                <asp:DropDownList ID="IntituteFireSafetyDDList" CssClass="form-control select" runat="server">
                                                                    <asp:ListItem Selected="True" Value="CertificateObtained">Certificate Obtained</asp:ListItem>
                                                                    <asp:ListItem Value="NoCertificate">No Certificate</asp:ListItem>
                                                            </asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Building Layout Drawing Plan No.</label>
                                                                <asp:TextBox ID="txtInstituteDrawingPlan" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Electricity Supplier Agency </label>
                                                                <asp:TextBox ID="txtInstituteSupplyAgency" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Load in KW</label>
                                                                <asp:TextBox ID="txtInstituteLoad" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Water Supply Source</label>
                                                                <asp:DropDownList ID="InstituteWaterSupplyDDL" CssClass="form-control select" runat="server">
                                                                    <asp:ListItem Selected="True" Value="OwnSource">Own Source</asp:ListItem>
                                                                    <asp:ListItem Value="PHDSource">PHD Source</asp:ListItem>
                                                            </asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">PHD Consumer No.(If Any) </label>
                                                                <asp:TextBox ID="txtInstitutePHDConsumerNumber" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Year of Construction </label>
                                                                <asp:TextBox ID="txtYearOfConstruction" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Computer Lab Available </label>
                                                                <asp:DropDownList ID="ddlCompLabAvailable" CssClass="form-control select" runat="server">
                                                                    <asp:ListItem Selected="True" Value="Yes">Yes</asp:ListItem>
                                                                    <asp:ListItem Value="No">No</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>                                                           
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6 contact-info">
                                                        <div class="container">
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Buliding Block Name <span>(if any)</span></label>
                                                                <asp:TextBox ID="txtInstituteBlockName" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">No. of floor/s</label>
                                                                <asp:TextBox ID="txtInstituteFloorNumber" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Length of the Building Block(in meter)</label>
                                                                <asp:TextBox ID="txtInstituteBuildingLength" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Height of the Building Block (in meter)</label>
                                                                <asp:TextBox ID="txtInstituteBuildingHeight" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Fire Safety valid Up to</label>
                                                                <asp:TextBox ID="txtInstituteSafetyValidUpTo" Type="date" max="9999-12-31" CssClass="form-control ajax__calendar_body" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Building Approval Status</label>
                                                                <asp:DropDownList ID="InstituteBuildingApprovalDDList" CssClass="form-control select" runat="server">
                                                                    <asp:ListItem Selected="True" Value="ApprovalObtained">Approval Obtained</asp:ListItem>
                                                                    <asp:ListItem Value="ApprovalNotObtained">Approval Not Obtained</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Building in Book of Account</label>
                                                                <asp:DropDownList ID="InstituteBookOfAccountDDL" CssClass="form-control select" runat="server">
                                                                    <asp:ListItem Selected="True" Value="PWD">PWD</asp:ListItem>
                                                                    <asp:ListItem Value="IDCO">IDCO</asp:ListItem>
                                                                    <asp:ListItem Value="SOIC">SOIC</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Electicity Consumer No.</label>
                                                                <asp:TextBox ID="txtInstituteElcConsumerNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Transformer Type</label>
                                                                <asp:DropDownList ID="InstituteTransferTypeDDL" CssClass="form-control select" runat="server">
                                                                    <asp:ListItem Selected="True" Value="Own">Own</asp:ListItem>
                                                                    <asp:ListItem Value="Public">Public</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Building Safety Status</label>
                                                                <asp:DropDownList ID="InstituteSafetyStatusDDL" CssClass="form-control select" runat="server">
                                                                    <asp:ListItem Selected="True" Value="Safe">Safe</asp:ListItem>
                                                                    <asp:ListItem Value="Unsafe">Unsafe</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">No. of Smart Classes</label>
                                                                <asp:TextBox ID="txtNoOfSmartClasses" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">No. of RO Water Purifier </label>
                                                                <asp:TextBox ID="txtNoOfROPurifier" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                                            </div>
                                                             <div class="form-group">
                                                                <label for="exampleAccount">No. of Non-RO water purifier </label>
                                                                <asp:TextBox ID="txtNoOfNonROPurifier" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12">
                                                <asp:Button ID="InstituteSubmitBtn" runat="server" OnClick="InstituteSubmitBtn_Click" CssClass="btn-s float-right submit" type="submit" Text="Submit" />
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="col-lg-3 col-md-2">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%-- Hostel Building --%>

        <div class="modal fade" id="HostelBuilding" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="col-lg-12 NewEntrydiv">
                            <p class="NewEntry">New Entry - Master Data On Building</p>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-lg-3 col-md-2"></div>
                            <div class="col-lg-12 col-md-12 model-box">
                                <div class="row">
                                    <div class="card-body">
                                        <div class="row md-12 marginx">
                                            <div class="headerbox">
                                                <div class="col-md-6 Buliding">
                                                    <div class="row">
                                                        <div class="col-md-6 ">
                                                            <label for="exampleAccount">Type of Building </label>
                                                        </div>
                                                        <div class="col-md-6 ">
                                                            <asp:DropDownList ID="DropDownList7" CssClass="form-control select" runat="server">
                                                                <asp:ListItem Selected="True">Hostel Building</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <h3 class="hadingline">Enter Hostel Building Details Below</h3>
                                                    <div class="col-md-6 contact-info">
                                                        <div class="container">
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Hostel Buliding Block Type </label>
                                                                <asp:DropDownList ID="ddlHostelBlockType" CssClass="form-control select" runat="server">
                                                                    <asp:ListItem Selected="True" Value="Boys">Boys</asp:ListItem>
                                                                    <asp:ListItem Value="Girls">Girls</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>                                                            
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Total area of floor/s in sqft</label>
                                                                <asp:TextBox ID="txtHostelTotalFloorArea" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                             <div class="form-group">
                                                                <label for="exampleAccount">Fire Safety Status</label>
                                                                <asp:DropDownList ID="ddlHostelFireSafety" CssClass="form-control select" runat="server">
                                                                    <asp:ListItem Selected="True" Value="CertificateObtained">Certificate Obtained</asp:ListItem>
                                                                    <asp:ListItem Value="NoCertificate">No Certificate</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Width of the Building Block (in meter)</label>
                                                                <asp:TextBox ID="txtHostelBreath" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Height of the Building Block (in meter</label>
                                                                <asp:TextBox ID="txtHostelBuildingHeigth" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Building Layout Drawing Plan No.</label>
                                                                <asp:TextBox ID="txtHostelLayout" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>                                                           
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Electricity Supplier Agency </label>
                                                                <asp:TextBox ID="txtHostelSupplierAgency" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Load in KW</label>
                                                                <asp:TextBox ID="txtHostelLoadinKW" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Water Supply Source</label>
                                                               <asp:DropDownList ID="ddlHostelWaterSupply" CssClass="form-control select" runat="server">
                                                                    <asp:ListItem Selected="True" Value="OwnSource">Own Source</asp:ListItem>
                                                                    <asp:ListItem Value="PHDSource">PHD Source</asp:ListItem>
                                                            </asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">PHD Consumer No.(If Any) </label>
                                                                <asp:TextBox ID="txtPHDConsumerNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Year of Construction </label>
                                                                <asp:TextBox ID="txtHostelYearOfContruction" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                                            </div>
                                                             <div class="form-group">
                                                                <label for="exampleAccount">No. of RO Water Purifier </label>
                                                                <asp:TextBox ID="txtHostelNoOfROPurifier" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6 contact-info">
                                                        <div class="container">
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Buliding Block Name <span>(if any)</span></label>
                                                                <asp:TextBox ID="txtHostelBlockName" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">No. of room available</label>
                                                                <asp:TextBox ID="txtHostelRoomsAvailable" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Number of floor/s</label>
                                                                <asp:TextBox ID="txtHostelNumberOfFloors" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Capacity of the Hostel Building Block</label>
                                                                <asp:TextBox ID="txtHostelCapacity" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Length of the Building Block(in meter)</label>
                                                                <asp:TextBox ID="txtHostelBuildingBlockLength" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Fire Safety valid Up to</label>
                                                                <asp:TextBox ID="txtHostelFireSafetyValidUpTo" Type="date" max="9999-12-31" CssClass="form-control ajax__calendar_body" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Building Approval Status</label>
                                                                <asp:DropDownList ID="ddlHostelBuildingApproval" CssClass="form-control select" runat="server">
                                                                     <asp:ListItem Selected="True" Value="ApprovalObtained">Approval Obtained</asp:ListItem>
                                                                    <asp:ListItem Value="ApprovalNotObtained">Approval Not Obtained</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Building in Book of Account</label>
                                                                <asp:DropDownList ID="ddlHostelBookOfAccount" CssClass="form-control select" runat="server">
                                                                    <asp:ListItem Selected="True" Value="PWD">PWD</asp:ListItem>
                                                                    <asp:ListItem Value="IDCO">IDCO</asp:ListItem>
                                                                    <asp:ListItem Value="SOIC">SOIC</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Electicity Consumer No.</label>
                                                                <asp:TextBox ID="txtHostelElctricityConsumerNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Transformer Type</label>
                                                                <asp:DropDownList ID="ddlHostelTransformerType" CssClass="form-control select" runat="server">
                                                                    <asp:ListItem Selected="True" Value="Own">Own</asp:ListItem>
                                                                    <asp:ListItem Value="Public">Public</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Safety</label>
                                                                <asp:DropDownList ID="ddlHostelBuildingSafetyStatus" CssClass="form-control select" runat="server">
                                                                    <asp:ListItem Selected="True" Value="Safe">Safe</asp:ListItem>
                                                                    <asp:ListItem Value="Unsafe">Unsafe</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">No. of Non-RO water purifier </label>
                                                                <asp:TextBox ID="txtHostelNonROPurifier" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12">
                                                <asp:Button ID="btnHostelBuildingSubmit" runat="server" OnClick="btnHostelBuildingSubmit_Click" CssClass="btn-s float-right submit" type="submit" Text="Submit" />
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="col-lg-3 col-md-2">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%-- Staff Quarter --%>

        <div class="modal fade" id="StaffQuarter" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="col-lg-12 NewEntrydiv">
                            <p class="NewEntry">New Entry - Master Data On Building</p>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>

                    </div>

                    <div class="modal-body">
                        <div class="row">
                            <div class="col-lg-3 col-md-2"></div>
                            <div class="col-lg-12 col-md-12 model-box">
                                <div class="row">
                                    <div class="card-body">
                                        <div class="row md-12 marginx">
                                            <div class="headerbox">
                                                <div class="col-md-6 Buliding">
                                                    <div class="row">
                                                        <div class="col-md-6 ">
                                                            <label for="exampleAccount">Type of Building </label>
                                                        </div>
                                                        <div class="col-md-6 ">
                                                            <asp:DropDownList ID="DropDownList12" CssClass="form-control select" runat="server">
                                                                <asp:ListItem Selected="True">Staff Quarter</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <h3 class="hadingline">Enter Staff Quarters Details Below</h3>
                                                    <div class="col-md-6 contact-info">
                                                        <div class="container">
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Staff Quarter Block Type </label>
                                                                <asp:DropDownList ID="ddlStaffBlockType" CssClass="form-control select" runat="server">
                                                                    <asp:ListItem Selected="True" Value="A">A</asp:ListItem>
                                                                    <asp:ListItem Value="B">B</asp:ListItem>
                                                                    <asp:ListItem Value="C">C</asp:ListItem>
                                                                    <asp:ListItem Value="D">D</asp:ListItem>
                                                                    <asp:ListItem Value="E">E</asp:ListItem>
                                                                    <asp:ListItem Value="F">F</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Total area of floor/s in sqft</label>
                                                                <asp:TextBox ID="txtStaffFloorArea" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Width of the Building Block (in meter)</label>
                                                                <asp:TextBox ID="txtStaffBreath" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Height of the Building Block (in meter)</label>
                                                                <asp:TextBox ID="txtStaffHeight" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Building Layout Drawing Plan No.</label>
                                                                <asp:TextBox ID="txtStaffLayoutPlanNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Fire Safety Status</label>
                                                                <asp:DropDownList ID="ddlStaffFireSafetyStatus" CssClass="form-control select" runat="server">
                                                                    <asp:ListItem Selected="True" Value="CertificateObtained">Certificate Obtained</asp:ListItem>
                                                                    <asp:ListItem Value="NoCertificate">No Certificate</asp:ListItem>
                                                            </asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Electricity Supplier Agency </label>
                                                                <asp:TextBox ID="txtStaffSupplierAgency" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Load in KW</label>
                                                                <asp:TextBox ID="txtStaffLoadInKw" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Water Supply Source</label>
                                                                <asp:DropDownList ID="ddlStaffWaterSupplySource" CssClass="form-control select" runat="server">
                                                                    <asp:ListItem Selected="True" Value="OwnSource">Own Source</asp:ListItem>
                                                                    <asp:ListItem Value="PHDSource">PHD Source</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">PHD Consumer No.(If Any) </label>
                                                                <asp:TextBox ID="txtStaffPHDConsumerNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div> 
                                                             <div class="form-group">
                                                                <label for="exampleAccount">Year of Construction </label>
                                                                <asp:TextBox ID="txtStaffYearOfConstruction" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6 contact-info">
                                                        <div class="container">
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Staff Quarter Block Name <span>(if any)</span></label>
                                                                <asp:TextBox ID="txtStaffBlockName" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Number of floor/s</label>
                                                                <asp:TextBox ID="txtStaffNumberOfFloor" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">No. of rooms available</label>
                                                                <asp:TextBox ID="txtStaffHostelCapacity" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Length of the Building Block(in meter)</label>
                                                                <asp:TextBox ID="txtStaffLengthofBuilding" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Fire Safety valid Up to</label>
                                                                <asp:TextBox ID="txtStaffFireSafetyValidUpto" Type="date" max="9999-12-31" CssClass="form-control ajax__calendar_body" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Building Approval Status</label>
                                                                 <asp:DropDownList ID="ddlStaffBuildingApprovalStatus" CssClass="form-control select" runat="server">
                                                                    <asp:ListItem Selected="True" Value="ApprovalObtained">Approval Obtained</asp:ListItem>
                                                                    <asp:ListItem Value="ApprovalNotObtained">Approval Not Obtained</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Building in Book of Account</label>
                                                                 <asp:DropDownList ID="ddlStaffBookOfAccount" CssClass="form-control select" runat="server">
                                                                    <asp:ListItem Selected="True" Value="PWD">PWD</asp:ListItem>
                                                                    <asp:ListItem Value="IDCO">IDCO</asp:ListItem>
                                                                    <asp:ListItem Value="SOIC">SOIC</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Quarter Electricity Connection Status</label>
                                                                <asp:DropDownList ID="ddlStaffElectricityConnectionStatus" CssClass="form-control select" runat="server">
                                                                    <asp:ListItem Selected="True" Value="ELECTRIFIEDBYINSTITUTE">Electrified by Institute</asp:ListItem>
                                                                    <asp:ListItem Value="ELECTRIFIEDBYPOWERDISTRIBUTIONAGENCY">Electrified by power distribution agency</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Electicity Consumer No.</label>
                                                                <asp:TextBox ID="txtStaffElecticityCOnsumerNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Transformer Type</label>
                                                                <asp:DropDownList ID="ddlTransformerType" CssClass="form-control select" runat="server">
                                                                    <asp:ListItem Selected="True" Value="Own">Own</asp:ListItem>
                                                                    <asp:ListItem Value="Public">Public</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Safety</label>
                                                                <asp:DropDownList ID="ddlStaffSafetyStatus" CssClass="form-control select" runat="server">
                                                                    <asp:ListItem Selected="True" Value="Safe">Safe</asp:ListItem>
                                                                    <asp:ListItem Value="Unsafe">Unsafe</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div> 
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Occupancy Status</label>
                                                                <asp:DropDownList ID="ddlStaffOccupancyStatus" CssClass="form-control select" runat="server">
                                                                    <asp:ListItem Selected="True" Value="Occupied">Occupied</asp:ListItem>
                                                                    <asp:ListItem Value="Vacant">Vacant</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12">
                                                <asp:Button ID="btnStaffSubmit" runat="server" CssClass="btn-s float-right submit" OnClick="btnStaffSubmit_Click" type="submit" Text="Submit" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-2">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%-- Auditorium Quarter --%>

        <div class="modal fade" id="Auditorium" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="col-lg-12 NewEntrydiv">
                            <p class="NewEntry">New Entry - Master Data On Building</p>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-lg-3 col-md-2"></div>
                            <div class="col-lg-12 col-md-12 model-box">
                                <div class="row">
                                    <div class="card-body">
                                        <div class="row md-12 marginx">
                                            <div class="headerbox">
                                                <div class="col-md-6 Buliding">
                                                    <div class="row">
                                                        <div class="col-md-6 ">
                                                            <label for="exampleAccount">Type of Buliding </label>
                                                        </div>
                                                        <div class="col-md-5 ">
                                                            <asp:DropDownList ID="DropDownList17" CssClass="form-control select" runat="server">
                                                                <asp:ListItem Selected="True">Auditorium</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>                                               
                                            </div>
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <h3 class="hadingline">Enter Auditorium Building Details Below</h3>
                                                    <div class="col-md-6 contact-info">
                                                        <div class="container">
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Building Name</label>
                                                                <asp:TextBox ID="txtAudiBuildingName" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Sitting Capacity</label>
                                                                <asp:TextBox ID="txtAudiSittingCapacity" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Total area of floor/s in sqft</label>
                                                                <asp:TextBox ID="txtAudiTotalAreaOfFloor" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Width of the Building Block (in meter)</label>
                                                                <asp:TextBox ID="txtAudiTotalBreath" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Fire Safety Status</label>
                                                                 <asp:DropDownList ID="ddlAudiFireSafetyStatus" CssClass="form-control select" runat="server">
                                                                    <asp:ListItem Selected="True" Value="CertificateObtained">Certificate Obtained</asp:ListItem>
                                                                    <asp:ListItem Value="NoCertificate">No Certificate</asp:ListItem>
                                                            </asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Fire Safety valid Up to</label>
                                                                <asp:TextBox ID="txtAudiFireSafetyUpto" Type="date" max="9999-12-31" CssClass="form-control ajax__calendar_body" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Electricity Supplier Agency </label>
                                                                <asp:TextBox ID="txtAudiSuplierAgency" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                             <div class="form-group">
                                                                <label for="exampleAccount">Year of Construction </label>
                                                                <asp:TextBox ID="txtAudiYearOfConstruction" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6 contact-info">
                                                        <div class="container">
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Building Layout Drawing Plan No.</label>
                                                                <asp:TextBox ID="txtAudiLayoutPlanNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Length of the Building Block(in meter)</label>
                                                                <asp:TextBox ID="txtAudiTotalLength" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Height of the Building Block (in meter)</label>
                                                                <asp:TextBox ID="txtAudiTotalHeigth" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Building Approval Status</label>
                                                                <asp:DropDownList ID="ddlBuildingApporvalStatus" CssClass="form-control select" runat="server">
                                                                    <asp:ListItem Selected="True" Value="ApprovalObtained">Approval Obtained</asp:ListItem>
                                                                    <asp:ListItem Value="ApprovalNotObtained">Approval Not Obtained</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                            <label for="exampleAccount">Building in Book of Account</label>
                                                             <asp:DropDownList ID="ddlAudiBuildingBookOfAccount" CssClass="form-control select" runat="server">
                                                                    <asp:ListItem Selected="True" Value="PWD">PWD</asp:ListItem>
                                                                    <asp:ListItem Value="IDCO">IDCO</asp:ListItem>
                                                                    <asp:ListItem Value="SOIC">SOIC</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>                                                            
                                                        <div class="form-group">
                                                            <label for="exampleAccount">Electicity Consumer No.</label>
                                                            <asp:TextBox ID="txtElectricityConsumerNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="exampleAccount">Safety</label>
                                                             <asp:DropDownList ID="ddlAudiBuildingSafetyStatus" CssClass="form-control select" runat="server">
                                                                    <asp:ListItem Selected="True" Value="Safe">Safe</asp:ListItem>
                                                                    <asp:ListItem Value="Unsafe">Unsafe</asp:ListItem>
                                                                </asp:DropDownList>
                                                        </div>
                                                            <div class="form-group">
                                                                <label for="exampleAccount">Load in KW</label>
                                                                <asp:TextBox ID="txtAudiLoadInKW" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>                                                           
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12">
                                                <asp:Button ID="btnAudiSubmit" runat="server" OnClick="btnAudiSubmit_Click" CssClass="btn-s float-right submit" type="submit" Text="Submit" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-2">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    <script>
        $(document).ready(function () {
            $('.show-hide').hide();
            $('.InstitutionalBuildings').show();
        });
        $('select').change(function () {
        if ($(this).val() === "InstitutionalBuildings" || $(this).val() === "HostelBuildings" || $(this).val() === "StaffQuarters" || $(this).val() === "Auditoriums")
            {
                $('.show-hide').hide();
                $('.' + $(this).val()).show();
            }
        });
    </script>
    <script language="Javascript">
        function isDecimalNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
    </script>
</asp:Content>
