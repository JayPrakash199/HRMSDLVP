<%@ Page Title="" Language="C#" MasterPageFile="~/Infrastructure.Master" AutoEventWireup="true" CodeBehind="Infra-UpdateAuditorium.aspx.cs" Inherits="HRMS.Infra_UpdateAuditorium" %>
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

    <div id="Auditorium" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle">
        <div class="modal-dialog" role="document">
            <div class="modal-content">

                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-3 col-md-2"></div>
                        <div class="col-lg-12 col-md-12 model-box">
                            <div class="row">
                                <div class="card-body">
                                    <div class="row md-12 marginx">
                                        <div class="col-md-12">
                                            <div class="row">
                                                <h3 class="hadingline"></h3>
                                                <div class="col-md-6 contact-info">
                                                    <div class="container">
                                                        <div class="form-group">
                                                            <label for="exampleAccount">Edit Auditorium Building for Building Code No.</label>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="exampleAccount">Building Name</label>
                                                            <asp:TextBox ID="txtBuildingName" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="exampleAccount">Building Layout Drawing Plan No.</label>
                                                            <asp:TextBox ID="txtAudiLayoutPlanNo" CssClass="form-control" runat="server"></asp:TextBox>
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
                                                            <label for="exampleAccount">Breath of the Building Block (in meter)</label>
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
                                                    </div>
                                                </div>
                                                <div class="col-md-6 contact-info">
                                                    <div class="container">
                                                        <div class="form-group">
                                                            <asp:Label ID="lblAuditoriumBuildingCode" CssClass="Labels" for="exampleAccount" runat="server"></asp:Label>
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
                                                            <label for="exampleAccount">Building in Book of Account of</label>
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
                                                            <label for="exampleAccount">Building Safety Status</label>
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
</asp:Content>
