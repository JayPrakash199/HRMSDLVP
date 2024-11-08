﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Fee.Master" AutoEventWireup="true" CodeBehind="FeeGeneration.aspx.cs" EnableEventValidation="false" Inherits="HRMS.FeeGeneration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/material-design-icons/3.0.1/iconfont/material-icons.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/material-design-icons/3.0.1/iconfont/material-icons.min.css" />
    <style>
        .summary-box {
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
            margin: 4%;
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
            width: auto;
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
            width: auto;
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

        .col-lg-12.col-md-12.model-box {
            margin: 34px 10px 10px -113px;
        }

        input#ContentPlaceHolder1_txtHRMSIDSearch {
            text-align: right;
        }
    </style>
    <div class="container box">
        <div class="row">
            <div class="col-lg-3 col-md-2"></div>
            <div class="col-lg-12 col-md-12 model-box">
                <div class="col-lg-12 col-md-12 summary-box">
                    <div class="col-lg-12 NewEntrydiv">
                        <p class="NewEntry">Fee Generation</p>
                    </div>
                    <div class="row">
                        <div class="card-body">
                            <div class="row md-12 marginx">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-6 contact-info">
                                            <div class="container">
                                                <div class="form-group">
                                                    <div class="col-sm-12">
                                                        <label for="exampleAccount">Select Academic Year</label>
                                                    </div>
                                                    <div class="col-sm-10">
                                                        <asp:DropDownList ID="ddlacademicYear" CssClass="form-control" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-sm-2" style="position: relative; margin-top: 6px">
                                                        <asp:RequiredFieldValidator ID="rqAcademicyear" ControlToValidate="ddlacademicYear" InitialValue="0" ValidationGroup="FeeGeneration"
                                                            runat="server" Font-Bold="true" ForeColor="Red" Font-Size="Larger" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="col-sm-12">
                                                        <label for="exampleAccount">Select Semester</label>
                                                    </div>
                                                    <div class="col-sm-10">
                                                        <asp:DropDownList ID="ddlSemester" CssClass="form-control" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-sm-2" style="position: relative; margin-top: 6px">
                                                        <asp:RequiredFieldValidator ID="rqsemester" ControlToValidate="ddlSemester" InitialValue="0" ValidationGroup="FeeGeneration"
                                                            runat="server" Font-Bold="true" ForeColor="Red" Font-Size="Larger" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="col-sm-12">
                                                        <label for="exampleAccount">Select Fee Classification</label>
                                                    </div>
                                                    <div class="col-sm-10">
                                                        <asp:DropDownList ID="ddlFeeClassification" CssClass="form-control" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-sm-2" style="position: relative; margin-top: 6px">
                                                        <asp:RequiredFieldValidator ID="rfFeeClasification" ControlToValidate="ddlFeeClassification" InitialValue="0" ValidationGroup="FeeGeneration"
                                                            runat="server" Font-Bold="true" ForeColor="Red" Font-Size="Larger" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                        <div class="col-md-6 contact-info">
                                            <div class="form-group">
                                                <div class="col-sm-12">
                                                    <label for="exampleAccount">Select Course</label>
                                                </div>
                                                <div class="col-sm-10">
                                                    <asp:DropDownList ID="ddlCourseCode" CssClass="form-control" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-2" style="position: relative; margin-top: 6px">
                                                    <asp:RequiredFieldValidator ID="rqCourse" ControlToValidate="ddlCourseCode" InitialValue="0" ValidationGroup="FeeGeneration"
                                                        runat="server" Font-Bold="true" ForeColor="Red" Font-Size="Larger" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-sm-12">
                                                    <label for="exampleAccount">Select Student</label>
                                                </div>
                                                <div class="col-sm-10">
                                                    <asp:DropDownList ID="ddlStudentNo" CssClass="form-control" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-2" style="position: relative; margin-top: 6px">
                                                    <asp:RequiredFieldValidator ID="rfStudent" ControlToValidate="ddlStudentNo" InitialValue="0" ValidationGroup="FeeGeneration"
                                                        runat="server" Font-Bold="true" ForeColor="Red" Font-Size="Larger" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                        </div>

                    </div>
                    <div class="col-md-12" style="padding: 1%">
                        <asp:Button ID="btnExport" OnClick="btnExport_Click" runat="server"  CssClass="btn-s float-right submit" Text="Generate Fees" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
    </div>
</asp:Content>
