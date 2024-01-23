<%@ Page Title="" Language="C#" MasterPageFile="~/Infrastructure.Master" AutoEventWireup="true" CodeBehind="Infra-LandRecord.aspx.cs" Inherits="HRMS.LandRecord" %>
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
                        <p class="NewEntry">Master Data On Land(RoR)</p>
                    </div>

                    <div class="col-lg-12 Introduction">
                        <%--<p class="Introduction">Name of the Institute :</p>--%>
                    </div>
                    <div class="tab-pane active" id="1">
                        <%--<h2 class="right_col_heading text-center m-0">Auditorium Building List</h2>--%>
                        <div class="right_col_bg">
                            <div class="right_col_content border-box label-responsive">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="table-responsive">
                                            <div id="exportto">
                                                <asp:ListView ID="LandRecordList" runat="server">
                                                    <EmptyDataTemplate>
                                                        There are no records
                                                    </EmptyDataTemplate>
                                                    <LayoutTemplate>
                                                        <table runat="server" class="table table-bordered">
                                                            <tr runat="server">
                                                                <th runat="server">Khatian No.</th>
                                                                <th runat="server">Kisam</th>
                                                                <th runat="server">Plot Number/s</th>
                                                                <th runat="server">District</th>
                                                                <th runat="server">Tahasil</th>
                                                                <th runat="server">Village</th>
                                                                <th runat="server">RI Circle</th>
                                                                <th runat="server">Land Owner Name</th>
                                                                <th runat="server">Land Possessioner Name</th>
                                                                <th runat="server">Encroachment affected areas (in acres)</th>
                                                                <th runat="server">Encroachment affected plot no./s</th>
                                                                <th runat="server">Disputed areas other than encroachment (in acres)</th>
                                                                <th runat="server">Dispute Plot No. (Other Than Encroachment)</th>
                                                                <th runat="server">Plot under Court Case</th>
                                                                <th runat="server">Download RoR File</th>
                                                                <th runat="server">Upload RoR File</th>
                                                            </tr>
                                                            <tr id="ItemPlaceholder" runat="server">
                                                            </tr>
                                                            <tr runat="server">
                                                                <td runat="server" colspan="2"></td>
                                                            </tr>
                                                        </table>
                                                    </LayoutTemplate>
                                                    <ItemTemplate>
                                                        <tr class="TableData">
                                                            <td>
                                                                <asp:Label ID="lblKhatianNo" runat="server" Text='<%# Eval("Khatian_Serial_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label12" runat="server" Text='<%# Eval("Land_Kisam")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblPlotNo" runat="server" Text='<%# Eval("Plot_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("District")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Tahasil")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Village")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("RI_Circle")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("Land_Owner_Details")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("Land_possessioner_Details")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label7" runat="server" Text='<%# Eval("Encroachment_Plot_Area")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label8" runat="server" Text='<%# Eval("Encroachment_Plot_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label9" runat="server" Text='<%# Eval("Dispute_Area")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label10" runat="server" Text='<%# Eval("Dispute_Plot_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label11" runat="server" Text='<%# Eval("CasePlot_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="btnDownload" runat="server" OnClick="btnDownload_Click"><i class="fa-regular fa-file"></i></asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <div class="input-group">
                                                                    <label class="input-group-btn">
                                                                        <span class="custom-file-input btn">
                                                                            <asp:FileUpload ID="LandpdfUploader" runat="server" Style="display: none" accept=".pdf" />
                                                                            <asp:LinkButton ID="btnUpload" CssClass="btn btn-yellow" OnClick="btnUpload_Click" runat="server">Upload</asp:LinkButton>
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
                                    <div class="col-lg-12 ExportFoot">
                                        <asp:Button ID="btnExport" CssClass="exportcss btn-yellow" OnClick="btnExport_Click" runat="server" Text="Export" />
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
