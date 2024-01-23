<%@ Page Title="" Language="C#" MasterPageFile="~/Infrastructure.Master" AutoEventWireup="true" CodeBehind="Infra-NewLandRecord.aspx.cs" Inherits="HRMS.NewLandRecord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/material-design-icons/3.0.1/iconfont/material-icons.min.css" />
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
        .input#ContentPlaceHolder1_pdfUploader {
           width: 160px;
            height: 34px;
            left: 36px;
            top: 0px;
        }
    </style>
    <div class="container box">
        <div class="row">
            <div class="col-lg-3 col-md-2"></div>
            <div class="col-lg-12 col-md-12 model-box">

                <div class="col-lg-12 col-md-12 summary-box">
                    <div class="col-lg-12 NewEntrydiv">
                        <p class="NewEntry">New Land Record</p>
                    </div>
                    <div class="row">
                        <div class="card-body">
                            <div class="row md-12 marginx">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-6 contact-info">
                                            <div class="container">
                                                <div class="form-group">
                                                    <label for="exampleAccount">Khatian Serial No</label>
                                                    <asp:TextBox ID="txtKhatian_Serial_No" CssClass="form-control" runat="server"></asp:TextBox>
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
                                                    <label for="exampleAccount">Land Owner Name</label>
                                                    <asp:TextBox ID="txtLand_Owner_Details" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label for="exampleAccount">Encroachment Plot Area</label>
                                                    <asp:TextBox ID="txtEncroachment_Plot_Area" onkeypress="return isDecimalNumberKey(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label for="exampleAccount">Dispute Plot Area</label>
                                                    <asp:TextBox ID="txtDispute_Area" onkeypress="return isDecimalNumberKey(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label for="exampleAccount">Upload file</label>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <div class='file'>
                                                                    <label for='input-file'>
                                                                        <i class="material-icons">cloud_queue
                                                                        </i>Max PDF file size 2MB
                                                                    </label>
                                                                    <asp:FileUpload ID="pdfUploader" accept="application/pdf" style="width:160px;height: 34px;" runat="server" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" CssClass="btn-s float-right submit" type="submit" Text="Submit" />
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
