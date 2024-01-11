<%@ Page Title="" Language="C#" MasterPageFile="~/LibraryManagement.Master" AutoEventWireup="true" CodeBehind="LibraryBookSearch.aspx.cs" Inherits="HRMS.LibraryBookSearch" %>

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

        input#ContentPlaceHolder1_txtbookSearch {
            text-align: right;
        }
    </style>
    <script type="text/javascript">
        function ShowPopup(title) {
            $("#MyPopup .modal-title").html(title);
            $("#MyPopup").modal("show");
        }
        function showLoader() {
            $('#loader').show();
        };
        function HideLoader() {
            $('#loader').hide();
        };
        function LoadPublisherCode() {
            debugger;
            showLoader();
            var publishcode = $("#ContentPlaceHolder1_ddlPublisherCode option:selected").text();
            $.ajax({
                type: "POST",
                url: "LibraryBookSearch.aspx/LoadPublisherCode",
                data: "{'publishcode':'" + publishcode + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    HideLoader();
                    alert(response.responseText);
                },
                error: function (d) {
                    HideLoader();
                    alert(d.responseText);
                }
            });
        }
        function OnSuccess(data) {
            
            let txtPublish = document.getElementById('ContentPlaceHolder1_txtPublisherName');
            txtPublish.value = data.d;
            HideLoader();
        }
    </script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.2/css/all.min.css" integrity="sha512-1sCRPdkRXhBV2PBLUdRb4tMg1w2YPf37qatUFeS7zlBy7jJI8Lf4VHwWfZZfpXtYSLy85pkm9GaYVYMfw5BC1A==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <contenttemplate>

        <div class="container box">
            <div class="row">
                <div class="col-lg-12 col-md-12 summary-box">
                    <div class="col-lg-12 NewEntrydiv">
                        <p class="NewEntry">Library Book List</p>
                    </div>

                    <div class="col-lg-12" style="padding: 15px">
                        <div class="container">
                            <div class="form-group">
                                <div class="col-md-3" style="padding-left: 0px;">
                                    <i class="fa fa-search icon"></i>
                                    <asp:TextBox ID="txtbookSearch" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Button ID="btnLibraryBookSearch" OnClientClick="showLoader();" OnClick="btnLibraryBookSearch_Click" CssClass="btn-s float-right submit btn-yellow form-control" Text="Search" runat="server" />
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
                                                <asp:ListView OnItemDataBound="LibrarySearchListView_ItemDataBound" ID="LibrarySearchListView" runat="server"
                                                    OnItemEditing="LibrarySearchListView_ItemEditing">
                                                    <LayoutTemplate>
                                                        <table runat="server" class="table table-bordered">
                                                            <tr runat="server">
                                                                <th runat="server">Item No</th>
                                                                <th runat="server">Book Name</th>
                                                                <th runat="server">Author Name</th>
                                                                <th runat="server">Author Name 2</th>
                                                                <th runat="server">Inventory</th>
                                                                <th runat="server">Available Count</th>
                                                                <th runat="server">Publisher Code</th>
                                                                <th runat="server">Publisher Name</th>
                                                                <th runat="server">User ID</th>
                                                                <th runat="server">Portal ID</th>
                                                                <th runat="server">Book Category Code</th>
                                                                <th runat="server">Language</th>
                                                                <th runat="server">Location Code</th>
                                                                <th runat="server">Book Type</th>
                                                                <th runat="server">No. Of Pages</th>
                                                                <th runat="server">Call No</th>
                                                                <th runat="server">Shelf</th>
                                                                <th runat="server">Suplier Name</th>
                                                                <th runat="server">Unit Cost</th>
                                                                <th runat="server">Edit</th>
                                                            </tr>
                                                            <tr id="ItemPlaceholder" runat="server">
                                                            </tr>
                                                        </table>
                                                    </LayoutTemplate>
                                                    <ItemTemplate>
                                                        <tr class="TableData">
                                                            <td>
                                                                <asp:Label ID="lblNo" runat="server" Text='<%# Eval("No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblBookName" runat="server" Text='<%# Eval("Book_Name")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblAuthorName" runat="server" Text='<%# Eval("Author_Name")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblAuthorName2" runat="server" Text='<%# Eval("Author_Name_2")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblInventory" runat="server" Text='<%# Eval("Inventory")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblAvailableCount" runat="server" Text='<%# Eval("Available_Count")%>'> </asp:Label>
                                                            </td>
                                                             <td>
                                                                <asp:Label ID="lblPublisherCode" runat="server" Text='<%# Eval("Place__x0026__Publisher_Name")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblPublisherName" runat="server" Text='<%# Eval("_Publisher_Name")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblUserId" runat="server" Text='<%# Eval("User_ID")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblPortalId" runat="server" Text='<%# Eval("Portal_ID")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("Book_Category_Code")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblLanguage" runat="server" Text='<%# Eval("Langauge")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblLocationCode" runat="server" Text='<%# Eval("Location_Code")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblBookType" runat="server" Text='<%# Eval("Book_Type")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblNoOfPages" runat="server" Text='<%# Eval("No_of_Pages")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblCallNo" runat="server" Text='<%# Eval("Call_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblShelf" runat="server" Text='<%# Eval("Shelf")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblSupplierName" runat="server" Text='<%# Eval("Supplier_Name")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblUnit_Cost" runat="server" Text='<%# Eval("Unit_Cost")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnEdit" CssClass="exportcss btn" runat="server" Text='Edit' CommandName="Edit" />
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <%-- <EditItemTemplate>
                                                        <td>
                                                            <asp:TextBox ID="txtslNo" runat="server" Text='<%# Eval("No")%>'> </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtBookName" runat="server" Text='<%# Eval("Book_Name")%>'> </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtAuthorName" runat="server" Text='<%# Eval("Author_Name")%>'> </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtInventory" runat="server" Text='<%# Eval("Inventory")%>'> </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtAvailableCount" runat="server" Text='<%# Eval("Available_Count")%>'> </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPublisherName" runat="server" Text='<%# Eval("Place__x0026__Publisher_Name")%>'> </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtUserId" runat="server" Text='<%# Eval("User_ID")%>'> </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPortalId" runat="server" Text='<%# Eval("Portal_ID")%>'> </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDateTime" runat="server" Text='<%# Eval("Document_Date_Time")%>'> </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnEdit" CssClass="exportcss btn" runat="server" Text='Update' CommandName="Update" />
                                                            <asp:Button ID="btnCancel" CssClass="exportcss btn" runat="server" Text='Cancel' CommandName="Cancel" />
                                                        </td>
                                                    </EditItemTemplate>--%>
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

        <div id="MyPopup" class="modal fade" role="dialog">
            <div class="modal-dialog" style="width: 800px">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">
                            &times;</button>
                        <h4 class="modal-title">Library Book card</h4>
                    </div>
                    <div class="modal-body">
                        <div class="container box">
                            <div class="row">
                                <div class="col-lg-3 col-md-2"></div>
                                <div class="col-lg-12 col-md-12 model-box">
                                    <div class="loader" style="position: absolute" id="loader">
                                        <div class="loader-img"><i class="fa fa-spinner fa-spin"></i></div>
                                    </div>
                                    <div class="col-lg-12 col-md-12 ">

                                        <div class="row">
                                            <div class="card-body">
                                                <div class="row md-12 marginx">

                                                    <div class="col-md-12">
                                                        <div class="row">
                                                            <div class="col-md-6 contact-info">
                                                                <div class="container">
                                                                    <div class="form-group" style="display: none">
                                                                        <asp:Label runat="server" Text="Book Name"></asp:Label>
                                                                        <asp:TextBox ID="txtno" CssClass="form-control" runat="server"> </asp:TextBox>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label runat="server" Text="Book Name"></asp:Label>
                                                                        <asp:TextBox ID="txtmdBookName" CssClass="form-control" runat="server"> </asp:TextBox>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label runat="server" Text="Author Name"></asp:Label>
                                                                        <asp:TextBox ID="txtmdAuthorName" CssClass="form-control" runat="server"> </asp:TextBox>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label runat="server" Text="Author Name 2"></asp:Label>
                                                                        <asp:TextBox ID="txtmdAuthorName2" CssClass="form-control" runat="server"> </asp:TextBox>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label runat="server" Text="Publisher Code"></asp:Label>
                                                                        <asp:DropDownList ID="ddlPublisherCode" onchange="LoadPublisherCode();" AutoPostBack="false" CssClass="form-control" runat="server">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label runat="server" Text="Publisher Name"></asp:Label>
                                                                        <asp:TextBox ID="txtPublisherName" CssClass="form-control" runat="server">
                                                                        </asp:TextBox>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label runat="server" Text="Book Category Code"></asp:Label>
                                                                        <asp:DropDownList ID="ddlBookcategoryCode" CssClass="form-control" runat="server">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label runat="server" Text="No. Of Pages"></asp:Label>
                                                                        <asp:TextBox ID="txtNoOfpages" CssClass="form-control" runat="server"> </asp:TextBox>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label runat="server" Text="Unit Cost"></asp:Label>
                                                                        <asp:TextBox ID="txtUnitCost" CssClass="form-control" runat="server"> </asp:TextBox>
                                                                    </div>

                                                                </div>
                                                            </div>
                                                            <div class="col-md-6 contact-info">
                                                                <div class="container">
                                                                    <div class="form-group">
                                                                        <asp:Label runat="server" Text="Call No"></asp:Label>
                                                                        <asp:TextBox ID="txtCallNo" CssClass="form-control" runat="server"> </asp:TextBox>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label runat="server" Text="Shelf"></asp:Label>
                                                                        <asp:TextBox ID="txtShelf" CssClass="form-control" runat="server"> </asp:TextBox>
                                                                    </div>

                                                                    <div class="form-group">
                                                                        <asp:Label runat="server" Text="Language"></asp:Label>
                                                                        <asp:DropDownList ID="ddllanguage" AutoPostBack="false" CssClass="form-control" runat="server">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label runat="server" Text="Location Code"></asp:Label>
                                                                        <asp:DropDownList ID="ddlLocationCode" AutoPostBack="false" CssClass="form-control" runat="server">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label runat="server" Text="Book Type"></asp:Label>
                                                                        <asp:DropDownList ID="ddlBookType" AutoPostBack="false" CssClass="form-control" runat="server">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label runat="server" Text="Suplier Name"></asp:Label>
                                                                        <asp:TextBox ID="txtSuplierName" CssClass="form-control" runat="server"> </asp:TextBox>
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
                            </div>
                        </div>

                    </div>
                    <div class="form-group" style="margin: 0; position: absolute; bottom: 10%; right: 2%;">
                        <div>
                            <asp:Button runat="server" ID="btnAccession" Text="Accession" OnClick="btnAccession_Click" class="btn btn-yellow"></asp:Button>

                            <asp:Button runat="server" ID="BtnUpdate" Text="Update" OnClick="BtnUpdate_Click" class="btn btn-success"></asp:Button>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">
                            Close</button>
                    </div>
                </div>
            </div>
        </div>
    </contenttemplate>
</asp:Content>
