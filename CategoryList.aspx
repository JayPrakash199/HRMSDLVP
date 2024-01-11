<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.Master" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="HRMS.CategoryList" %>

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

        .btn-s.float-right {
            float: right;
            background: white;
            width: 72px;
            height: 31px;
        }

        input#ContentPlaceHolder1_txtItemCategorySearch {
            text-align: right;
        }
    </style>

    <contenttemplate>
        <div class="messagealert" id="alert_container"></div>
        <div class="container box">
            <div class="row">
                <div class="col-lg-12 col-md-12 summary-box">
                    <div class="col-lg-12 NewEntrydiv">
                        <p class="NewEntry">Location List</p>
                    </div>

                    <div class="col-lg-12" style="padding: 15px">
                        <div class="container">
                            <div class="form-group">
                                <div class="col-md-3" style="padding-left: 0px;">
                                    <i class="fa fa-search icon"></i>
                                    <asp:TextBox ID="txtItemCategorySearch" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Button ID="btnItemcategorySearch" OnClientClick="showLoader();" OnClick="btnItemcategorySearch_Click" CssClass="btn-s float-right submit btn-yellow form-control" Text="Search" runat="server" />
                                </div>
                                <div class="col-md-7" style="padding-top: 0.5%;">
                                    <asp:Label CssClass="message" ID="LblMessage" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="tab-pane active" id="1">
                        <div class="right_col_bg">
                            <div class="right_col_content border-box label-responsive">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="table-responsive">
                                            <div id="exportto" style="height: 390px; overflow: visible">
                                                <asp:ListView ID="ItemCategoryListVew" runat="server">
                                                    <layouttemplate>
                                                        <table runat="server" class="table table-bordered">
                                                            <tr runat="server">
                                                                <th style="text-align:center" runat="server">Code</th>
                                                                <th style="text-align:center" runat="server">Description</th>
                                                            </tr>
                                                            <tr id="ItemPlaceholder" runat="server">
                                                            </tr>
                                                        </table>
                                                    </layouttemplate>
                                                    <itemtemplate>
                                                        <tr class="TableData">
                                                            <td>
                                                                <asp:Label ID="lblCode" runat="server" Text='<%# Eval("Code")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description")%>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </itemtemplate>
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
</asp:Content>
