<%@ Page Title="" Language="C#" MasterPageFile="~/Infrastructure.Master" AutoEventWireup="true" CodeBehind="Infra-LandRecordCard.aspx.cs" Inherits="HRMS.LandRecordCard" %>
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
        .blockInputClass {
            pointer-events: none;
        }
    </style>

    <div class="container box" id="booggg">
        <div class="row">
            <div class="col-lg-3 col-md-2"></div>
            <%-- Master Data --%>
            <div class="col-lg-12 col-md-12 summary-box">
                <div class="col-lg-12 NewEntrydiv">
                    <p class="NewEntry">Update Land Record</p>
                </div>                
                <div class="row">
                    <div id="LandRecordSearch" class="card-body" runat="server">
                        <div class="row md-12 marginx">
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-4 ">
                                        <label for="exampleCtrl">Search Land Record.</label>
                                    </div>
                                    <div class="col-md-4 ">
                                        <asp:TextBox ID="txtSearch" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2 ">
                                        <asp:Button ID="btnSearch" OnClientClick="showLoader();" OnClick="btnSearch_Click" runat="server" CssClass="btn-s float-right submit" type="submit" Text="Search" />
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Button ID="btnEdit" runat="server" CssClass="btn-s float-right submit btn-yellow" Visible="false" type="submit" Text="Edit" />
                                    </div>
                                </div>
                                <div class="col-md-7" style="padding-top: 0.5%;">
                                    <asp:Label CssClass="message" ID="LblMessage" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-6 contact-info">
                                        <div class="container">
                                            <div class="form-group">
                                                <label for="exampleAccount">Khatian Serial No</label>
                                                <asp:TextBox ID="txtKhatian_Serial_No" CssClass="form-control blockInputClass" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleAccount">Plot No</label>
                                                <asp:TextBox ID="txtPlot_No" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleAccount">Tahasil</label>
                                                <asp:TextBox ID="txtTahasil" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleAccount">RI Circle</label>
                                                <asp:TextBox ID="txtRI_Circle" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleAccount">Land Possessioner Details</label>
                                                <asp:TextBox ID="txtLand_possessioner_Details" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleAccount">Encroachment Plot No</label>
                                                <asp:TextBox ID="txtEncroachment_Plot_No" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleAccount">Dispute Plot No</label>
                                                <asp:TextBox ID="txtDispute_Plot_No" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleAccount">CasePlot No</label>
                                                <asp:TextBox ID="txtCasePlot_No" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6 contact-info">
                                        <div class="container">
                                            <div class="form-group">
                                                <label for="exampleAccount">Land Kisam</label>
                                                <asp:DropDownList ID="ddlLandKisam" CssClass="form-control" runat="server">
                                                    <asp:ListItem>Select</asp:ListItem>
                                                    <asp:ListItem Value="Abadi_Irrigated_Two_Crops">Irrigated Two Crops</asp:ListItem>
                                                    <asp:ListItem Value="Abadi_Irrigated_One_crop">Irrigated One crop</asp:ListItem> 
                                                    <asp:ListItem Value="Abadi_Non_irrigated_Rainfed">Non irrigated Rainfed</asp:ListItem>
                                                    <asp:ListItem Value="Abadi_Orchards_Bagayat">Orchards Bagayat</asp:ListItem>
                                                    <asp:ListItem Value="Abadi_Water_bodies_Jalashaya">Water bodies Jalashaya</asp:ListItem>
                                                    <asp:ListItem Value="Abadi_Homestead_Gharabari">Homestead Gharabari</asp:ListItem>
                                                    <asp:ListItem Value="Abadi_Commercial_Byabasaika">Commercial Byabasaika</asp:ListItem>
                                                    <asp:ListItem Value="Abadi_Industrial_Shilpabhttika">Industrial Shilpabhttika</asp:ListItem>
                                                    <asp:ListItem Value="Abadi_Forest_Jungle">Forest Jungle</asp:ListItem>
                                                    <asp:ListItem Value="Abadi_Institutional_Anushthan">Institutional Anushthan</asp:ListItem>
                                                    <asp:ListItem Value="Abadi_Mine_Khani_Khadan__x0026__Others">Mine Khani Khadan Others</asp:ListItem>
                                                    <asp:ListItem Value="Abada_Jogya_Anabadi">Jogya Anabadi</asp:ListItem>
                                                    <asp:ListItem Value="Abada_Ajogya_Anabadi">Ajogya Anabadi</asp:ListItem>
                                                    <asp:ListItem Value="Rakhit">Rakhit</asp:ListItem>
                                                    <asp:ListItem Value="Sarbasadharana">Sarbasadharana</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleAccount">District</label>
                                                <asp:DropDownList ID="ddlDistrict" CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleAccount">Village</label>
                                                <asp:TextBox ID="txtVillage" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleAccount">Land Owner Details</label>
                                                <asp:TextBox ID="txtLand_Owner_Details" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleAccount">Land Issue Description</label>
                                                <asp:TextBox ID="txtLand_Issue_Description" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleAccount">Encroachment Plot Area</label>
                                                <asp:TextBox ID="txtEncroachment_Plot_Area" onkeypress="return isDecimalNumberKey(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleAccount">Dispute Area</label>
                                                <asp:TextBox ID="txtDispute_Area" onkeypress="return isDecimalNumberKey(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" CssClass="btn-s float-right submit" type="submit" Text="Submit" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-2">
                </div>
            </div>
        </div>
    </div>
    <script language="Javascript">        
        function showLoader() {
            $('#loader').show();
        };

        function isDecimalNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
    </script>
</asp:Content>
