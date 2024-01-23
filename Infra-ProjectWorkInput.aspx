<%@ Page Title="" Language="C#" MasterPageFile="~/Infrastructure.Master" AutoEventWireup="true" CodeBehind="Infra-ProjectWorkInput.aspx.cs" Inherits="HRMS.Infra_ProjectWorkInput" %>
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

        .col-lg-12.col-md-12.model-box {
            margin: 34px 10px 10px -113px;
        }
    </style>

    <div class="container box">
        <div class="row">
            <div class="col-lg-3 col-md-2"></div>
            <div class="col-lg-12 col-md-12 model-box">

                <div class="col-lg-12 col-md-12 summary-box">
                    <div class="col-lg-12 NewEntrydiv">
                        <p class="NewEntry">
                            <label id="lblHeader"></label>
                        </p>
                    </div>
                    <div class="row">
                        <div class="card-body">
                            <div class="row md-12 marginx">
                                <div class="headerbox">
                                    <div class="col-md-6 Buliding">
                                        <div class="row">
                                            <div class="col-md-6 ">
                                                <label for="exampleAccount">Project Type </label>
                                            </div>
                                            <div class="col-md-5 ">
                                                <asp:DropDownList ID="ddlProjectType" CssClass="form-control select" runat="server">
                                                    <asp:ListItem Selected="True">Improvement</asp:ListItem>
                                                    <asp:ListItem>Ongoing</asp:ListItem>
                                                    <asp:ListItem>New</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" runat="server" id="divBuilding">
                                        <div class="col-md-6 Buliding">
                                            <div class="col-md-6 ">
                                                <label for="exampleCtrl" runat="server" id="lblbuilding">Building ID</label>
                                            </div>
                                            <div class="col-md-5 ">
                                                <asp:TextBox ID="txtBuildingId" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12" id="Improvement">
                                    <div class="row">
                                        <h3 class="hadingline">Enter Project Details Below</h3>
                                        <div class="col-md-6 contact-info">
                                            <div class="container">
                                                <div class="form-group">
                                                    <label for="exampleAccount">Name of the Institute</label>
                                                    <asp:DropDownList ID="ddlInstituteName" CssClass="form-control select" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label for="exampleAccount">Name of the Project</label>
                                                    <asp:TextBox ID="txtProjectName" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label for="exampleAccount">Name of the Agency</label>
                                                    <asp:DropDownList ID="ddlNameOfAgency" CssClass="form-control select" runat="server">
                                                        <asp:ListItem>R&B</asp:ListItem>
                                                        <asp:ListItem>GPHD</asp:ListItem>
                                                        <asp:ListItem>PHD</asp:ListItem>
                                                        <asp:ListItem>IDCO</asp:ListItem>
                                                        <asp:ListItem>OSPH&WC</asp:ListItem>
                                                        <asp:ListItem>OSIC</asp:ListItem>
                                                        <asp:ListItem>GEMSat principal level</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label for="exampleAccount">Date of Commencement</label>
                                                    <asp:TextBox ID="txtCommencementDate" type="date" max="9999-12-31" CssClass="form-control ajax__calendar_body" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6 contact-info">
                                            <div class="container">
                                                <div class="form-group">
                                                    <label for="exampleAccount">District</label>
                                                    <asp:DropDownList ID="ddlDistrict" CssClass="form-control select" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label for="exampleAccount">Type of work</label>
                                                    <asp:DropDownList ID="ddlTypeOfWork" CssClass="form-control select" runat="server">
                                                        <asp:ListItem>Civil</asp:ListItem>
                                                        <asp:ListItem>Electrical</asp:ListItem>
                                                        <asp:ListItem>PH</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label for="exampleAccount">Mode of work</label>
                                                    <asp:DropDownList ID="ddlModeOfWork" CssClass="form-control select" runat="server">
                                                        <asp:ListItem>iOTMS</asp:ListItem>
                                                        <asp:ListItem>Works Module</asp:ListItem>
                                                        <asp:ListItem>Deposit mode at principal level referring to the AA issued from DTE&T/Govt.</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label for="exampleAccount">Date of Completion as per agreement</label>
                                                    <asp:TextBox ID="txtCompletionPerAgreement" type="date" max="9999-12-31" CssClass="form-control ajax__calendar_body" runat="server"></asp:TextBox>
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
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    <script>
        $(document).ready(function () {
            var dropDownValue = $('select').val();
            if (dropDownValue == 'Ongoing') {
                $("#lblHeader").text('Add Ongoing Project Progress Details');
            }
            else {
                $("#lblHeader").text('Project Work Input');
            }
            if (dropDownValue == 'Ongoing' || dropDownValue == 'New') {
                $("#<%= divBuilding.ClientID %>").hide();
            }
            if (dropDownValue == 'Improvement') {
                $("#<%= divBuilding.ClientID %>").show();
            }
        });
        $('select').change(function () { //on change do stuff
            if ($(this).val() == 'Ongoing') {
                $("#lblHeader").text('Add Ongoing Project Progress Details');
            }
            else {
                $("#lblHeader").text('Project Work Input');
            }
            if ($(this).val() == 'Ongoing' || $(this).val() == 'New') {
                $("#<%= divBuilding.ClientID %>").hide();
            }
            if ($(this).val() == 'Improvement') {
                $("#<%= divBuilding.ClientID %>").show();
            }
        });
    </script>
</asp:Content>
