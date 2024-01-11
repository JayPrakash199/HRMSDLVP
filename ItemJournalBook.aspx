<%@ Page Title="" Language="C#" MasterPageFile="~/LibraryManagement.Master" AutoEventWireup="true" CodeBehind="ItemJournalBook.aspx.cs" Inherits="HRMS.ItemJournalBook" %>

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

        p.NewEntry {
            float: left;
            font-weight: 600;
            color: black;
        }

        .col-lg-12.NewEntrydiv {
            background-color: #eeeeee;
        }

        .right_col_content.border-box.label-responsive {
            border: none;
        }

        i.fa-solid.fa-file {
            font-size: 35px;
        }

        .col-lg-12.col-md-12.summary-box {
            margin: 94px 10px 10px -113px;
        }

        i.fa.fa-search.icon {
            position: absolute;
            padding: 10px;
            display: block;
        }

        .btn-s.float-left {
            float: left;
            background: white;
            width: 75px;
        }
    </style>
    <contenttemplate>
        <div class="messagealert" id="alert_container"></div>
        <div class="container box">
            <div class="row">
                <div class="col-lg-12 col-md-12 summary-box">
                    <div class="col-lg-12 NewEntrydiv">
                        <p class="NewEntry">Item Journal</p>
                    </div>

                    <div class="col-lg-12" style="padding: 15px">
                        <div class="container">
                            <div class="form-group">
                                <%--<div class="col-md-3" style="padding-left: 0px;">
                                    <label>Journal Template</label>
                                    <asp:DropDownList ID="ddlTemplate" AutoPostBack="true" OnSelectedIndexChanged="ddlTemplate_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="col-md-3" style="padding-left: 0px;">
                                    <label>Journal Template Batch</label>
                                    <asp:DropDownList ID="ddlBatch" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="col-md-3" style="padding-left: 0px;">
                                    <label>Location</label>
                                    <asp:DropDownList ID="ddllLocation" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>--%>
                                <div class="col-md-3" style="padding-left: 0px;">
                                    <label class="file-upload">Upload csv file.</label>
                                    <asp:FileUpload ID="ItemFileUploader" runat="server" accept=".csv, application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/vnd.ms-excel" />
                                </div>
                                <div class="col-md-1">
                                    <asp:Button ID="btnSubmitCategory" OnClientClick="showLoader();" OnClick="btnSubmitCategory_Click" Style="margin: 35px" CssClass="btn-s float-left submit btn-yellow form-control" Text="Submit" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </contenttemplate>
</asp:Content>
