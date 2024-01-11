<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.Master" AutoEventWireup="true" CodeBehind="RecruitmentsAndRetirements.aspx.cs" Inherits="HRMS.RecruitmentsAndRetirements" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/material-design-icons/3.0.1/iconfont/material-icons.min.css" />
    <style>
        .summary-box {
            margin-top: 100px;
            height: auto;
            text-align: center;
            box-shadow: 0 3px 6px rgba(0, 0, 0, 0.16), 0 3px 6px rgba(0, 0, 0, 0.23);
            border: 1px solid;
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
            background-color: #eeeeee;
        }

        p.Introduction {
            float: left;
            color: black;
            padding: 23px;
            text-transform: uppercase;
            font-weight: 700;
        }

        li.sub-list {
            list-style-type: none;
            float: left;
        }

        ul.box list {
            float: left;
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

        .col-lg-12.col-md-12.summary-box {
            margin: 94px 10px 10px -113px;
        }

        i.fa.fa-search.icon {
            position: absolute;
            padding: 10px;
            display: block;
        }
    </style>

    <div class="container box">
        <div class="row">
            <div class="col-lg-3 col-md-2"></div>
            <div class="col-lg-6 col-md-8 summary-box">
                <div class="col-lg-12 NewEntrydiv">
                    <p class="NewEntry">Part – A (Data Import from Govt. of Odisha HRMS Website)</p>
                </div>

                <div class="col-lg-12 Introduction">
                    <p class="Introduction">Instruction :</p>
                </div>

                <div class="col-lg-12 sub-summary">
                    <div class="col-lg-12 summary">
                        <ul class="box list">
                            <li class="sub-list">
                                <table>
                                    <tr>
                                        <td>1. Download the template csv file.</td>
                                    </tr>
                                </table>
                            </li>
                            <br />
                            <li class="sub-list">
                                <table>
                                    <tr>
                                        <td>2. Take data from ‘Employee List’ table from Government of Odisha HRMS website.</td>
                                    </tr>
                                </table>
                            </li>
                            <br />
                            <li class="sub-list">
                                <table>
                                    <tr>
                                        <td>3. Fill the downloaded template with the same data.</td>
                                    </tr>
                                </table>
                            </li>
                            <br />
                            <li class="sub-list">
                                <table>
                                    <tr>
                                        <td>4. Upload the filled template CSV file.</td>
                                    </tr>
                                </table>
                            </li>
                        </ul>
                    </div>
                    <div class="row">
                        <div class="col-lg-6 col-md-6">
                            <table>
                                <tr>
                                    <td>
                                        <div class='file'>
                                            <asp:Button ID="downloadTemplateCSVBtn" OnClick="downloadTemplateCSVBtn_Click" CssClass="btn-upload float-left" runat="server" Text="Download Template CSV" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>

                        <div class="col-lg-6">

                            <div class="mb-3">
                                <asp:FileUpload ID="pdfUploader" Width="205px" CssClass="form-control form-control-sm" accept=".csv, application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/vnd.ms-excel" runat="server" />
                            </div>
                            <div class="mb-3" style="padding">
                                <asp:LinkButton OnClick="btnUpload_Click" ID="btnUpload" CssClass="btn btn-file-upload" runat="server">Upload</asp:LinkButton>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

