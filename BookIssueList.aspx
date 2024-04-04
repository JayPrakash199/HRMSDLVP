<%@ Page Title="" Language="C#" MasterPageFile="~/LibraryManagement.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="BookIssueList.aspx.cs" Inherits="HRMS.BookIssueList" %>

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

        input#ContentPlaceHolder1_txtbookIssueSearch {
            text-align: right;
        }

        .Background {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .Popup {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 400px;
            height: 350px;
        }

        .lbl {
            font-size: 16px;
            font-style: italic;
            font-weight: bold;
        }

        .DivReadonly {
            padding: 6px 12px !important;
            background-color: rgb(229, 231, 233) !important;
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

        function LoadUserType() {
            showLoader();
            $.ajax({
                type: "POST",
                url: "BookIssueList.aspx/LoadStudentNoDropDown",
                data: '{}',
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
            myResult = JSON.parse(data.d);
            let dropdown = document.getElementById('ContentPlaceHolder1_ddlNo');

            option = document.createElement('option');
            option.text = 'Select';
            option.value = 0;
            dropdown.add(option);
            for (let i = 0; i < myResult.length; i++) {
                option = document.createElement('option');
                option.text = myResult[i].No;
                option.value = myResult[i].Name;
                dropdown.add(option);
            }
            HideLoader();
        }

        function LoadStudentInfo() {
            showLoader();
            var No = $("#ContentPlaceHolder1_ddlNo option:selected").text();

            $.ajax({
                type: "POST",
                url: "BookIssueList.aspx/LoadStudentInfo",
                data: "{'No':'" + No + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessData,
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
        function OnSuccessData(data) {
            debugger;
            let name = document.getElementById('ContentPlaceHolder1_txtmdName');
            //let classcode = document.getElementById('ContentPlaceHolder1_txtmdClassCode');
            //let DOI = document.getElementById('ContentPlaceHolder1_txtmdDateofIssue');
            //let DOR = document.getElementById('ContentPlaceHolder1_txtmdDateofReturn');

            if (data.d == '') {
                name.value = '';
                //classcode.value = '';

                //DOI.value = '';
                //DOR.value = '';
            }
            else {
                myResult = JSON.parse(data.d);
                for (let i = 0; i < myResult.StudentList.length; i++) {
                    name.value = myResult.StudentList[i].FirstName;
                    //classcode.value = myResult.StudentList[i].CourseCode;
                }
                //for (let i = 0; i < myResult.BookIssueList.length; i++) {
                //    DOI.value = myResult.BookIssueList.DateofIssue;
                //    DOR.value = myResult.BookIssueList.DateofReturn;
                //}
            }
            HideLoader();
        }

        function LoadStudentAccessInfo() {
            showLoader();
            var AccessNo = document.getElementById('ContentPlaceHolder1_ddlAccessNo').value;

            $.ajax({
                type: "POST",
                url: "BookIssueList.aspx/LoadStudentAccessInfo",
                data: "{'AccessNo':'" + AccessNo + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessDataResponse,
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
        function OnSuccessDataResponse(data) {

            let Bookname = document.getElementById('ContentPlaceHolder1_txtmdBookName');
            let BookNo = document.getElementById('ContentPlaceHolder1_txtmdBookNo');
            let AvlQty = document.getElementById('ContentPlaceHolder1_txtmdQuantity');
            if (data.d == '') {
                Bookname.value = '';
                BookNo.value = '';
                AvlQty.value = '';
            }
            else {
                myResult = JSON.parse(data.d);
                let Bookname = document.getElementById('ContentPlaceHolder1_txtmdBookName');
                let BookNo = document.getElementById('ContentPlaceHolder1_txtmdBookNo');
                let AvlQty = document.getElementById('ContentPlaceHolder1_txtmdQuantity');

                for (let i = 0; i < myResult.length; i++) {

                    Bookname.value = myResult[i].BookName;
                    BookNo.value = myResult[i].BookNo;
                    AvlQty.value = myResult[i].AvlQty;
                }
            }
            HideLoader();
        }
        function IssueBook() {
            showLoader();
            var UserType = $("#ContentPlaceHolder1_ddlmdUserType option:selected").text();
            var No = $("#ContentPlaceHolder1_ddlNo option:selected").text();
            var Name = document.getElementById('ContentPlaceHolder1_txtmdName').value;
            var AccessNo = document.getElementById('ContentPlaceHolder1_ddlAccessNo').value;
            var Bookname = document.getElementById('ContentPlaceHolder1_txtmdBookName').value;
            //var DOI = document.getElementById('ContentPlaceHolder1_txtmdDateofIssue').value;
            //var DOR = document.getElementById('ContentPlaceHolder1_txtmdDateofReturn').value;
            var BookNo = document.getElementById('ContentPlaceHolder1_txtmdBookNo').value;
            var AvlQty = document.getElementById('ContentPlaceHolder1_txtmdQuantity').value;
            //var classcode = document.getElementById('ContentPlaceHolder1_txtmdClassCode').value;

            $.ajax({
                type: "POST",
                url: "BookIssueList.aspx/IssueBookData",
                data: "{'UserType':'" + UserType + "','No':'" + No + "','Name':'" + Name + "','AccessNo':'"
                    + AccessNo + "','Bookname': '" + Bookname + "', 'BookNo': '"
                    + BookNo + "', 'AvlQty': '" + AvlQty + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessIssueBook,
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
        function OnSuccessIssueBook(data) {
            var BookIssueList = data.d;
            var row = $("[id*=tblBook] tr:last-child").clone(true);
            $("[id*=tblBook] tr").not($("[id*=tblBook] tr:first-child")).remove();

            for (let i = 0; i < BookIssueList.length; i++) {
                var booklist = BookIssueList[i];
                $(".Entry_No", row).html(booklist.Entry_No);
                $(".User_Type", row).html(booklist.User_Type);
                $(".No", row).html(booklist.No);
                $(".Name", row).html(booklist.Name);
                $(".Book_No", row).html(booklist.Book_No);
                $(".Book_Name", row).html(booklist.Book_Name);
                $(".Accession_No", row).html(booklist.Accession_No);
                var DOI = [booklist.Date_of_Issue.Day, booklist.Date_of_Issue.Month, booklist.Date_of_Issue.Year].join('-');
                var DOR = [booklist.Date_of_Return.Day, booklist.Date_of_Return.Month, booklist.Date_of_Return.Year].join('-');
                $(".Date_of_Issue", row).html(DOI);
                $(".Date_of_Return", row).html(DOR);
                $(".Location_Code", row).html(booklist.Location_Code);
                $(".Avl_Qty", row).html(booklist.Avl_Qty);
                $("[id*=tblBook]").append(row);
                row = $("[id*=tblBook] tr:last-child").clone(true);
            }
            HideLoader();
            $('#MyPopup').modal('hide');
        }


        function LoadListView() {
            var AccessNo = document.getElementById('ContentPlaceHolder1_ddlAccessNo').value;

            $.ajax({
                type: "POST",
                url: "BookIssueList.aspx/GetListViewData",
                data: "{'AccessNo':'" + AccessNo + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessLoadListView,
                failure: function (response) {
                    alert('fail');
                    alert(response.responseText);
                },
                error: function (d) {
                    alert('error');
                    alert(d.responseText);
                }
            });
        }
        function OnSuccessLoadListView(data) {
            var BookIssueList = data.d;
            var row = $("[id*=tblBook] tr:last-child").clone(true);
            $("[id*=tblBook] tr").not($("[id*=tblBook] tr:first-child")).remove();


            $(BookIssueList).each(function () {
                var booklist = $(this)[0];
                $(".Entry_No", row).html(booklist.ContactName);
                $(".User_Type", row).html(booklist.ContactName);
                $(".No", row).html(booklist.No);
                $(".Name", row).html(booklist.Name);
                $(".Book_No", row).html(booklist.Book_No);
                $(".Book_Name", row).html(booklist.Book_Name);
                $(".Accession_No", row).html(booklist.Accession_No);
                $(".Date_of_Issue", row).html(booklist.Date_of_Issue);
                $(".Date_of_Return", row).html(booklist.Date_of_Return);
                $(".Location_Code", row).html(booklist.Location_Code);
                $(".Avl_Qty", row).html(booklist.Avl_Qty);
                $("[id*=tblBook]").append(row);
                row = $("[id*=tblBook] tr:last-child").clone(true);
            });

        }


    </script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.2/css/all.min.css" integrity="sha512-1sCRPdkRXhBV2PBLUdRb4tMg1w2YPf37qatUFeS7zlBy7jJI8Lf4VHwWfZZfpXtYSLy85pkm9GaYVYMfw5BC1A==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <contenttemplate>
        <div class="container box">
            <div class="row">
                <div class="col-lg-12 col-md-12 summary-box">
                    <div class="col-lg-12 NewEntrydiv">
                        <p class="NewEntry">Book Issue List</p>
                    </div>

                    <div class="col-lg-12" style="padding: 15px">
                        <div class="container">
                            <div class="form-group">
                                <div class="col-md-3" style="padding-left: 0px;">
                                    <i class="fa fa-search icon"></i>
                                    <asp:TextBox ID="txtbookIssueSearch" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Button ID="btnSearchBookIssuedata" OnClientClick="showLoader();" OnClick="btnSearchBookIssuedata_Click" CssClass="btn-s float-right submit btn-yellow form-control" Text="Search" runat="server" />
                                </div>
                                <div class="col-md-7" style="padding-top: 0.5%;">
                                    <asp:Button ID="btnIssueNewBook" OnClick="btnIssueNewBook_Click" CssClass="btn-s float-right submit btn-yellow form-control" Text="Add" runat="server" />
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
                                                <asp:ListView ID="BookIssueListView" runat="server" OnItemCommand="BookReturnListView_ItemCommand">
                                                    <LayoutTemplate>
                                                        <table runat="server" id="tblBook" class="table table-bordered">
                                                            <tr runat="server">
                                                                <th>Entry No</th>
                                                                <th>Type</th>
                                                                <th>No</th>
                                                                <th>Name</th>
                                                                <th>Book No</th>
                                                                <th>Book Name</th>
                                                                <th>Accession No</th>
                                                                <th>Date of Issue</th>
                                                                <th>Date of Return</th>
                                                                <th>Location Code</th>
                                                                <th>Available Qty</th>
                                                                <th>Action</th>
                                                            </tr>
                                                            <tr id="ItemPlaceholder" runat="server">
                                                            </tr>
                                                        </table>
                                                    </LayoutTemplate>
                                                    <ItemTemplate>
                                                        <tr class="TableData">
                                                            <td class="Entry_No">
                                                                <asp:Label ID="lblEntry_No" runat="server" Text='<%# Eval("Entry_No")%>'> </asp:Label>
                                                            </td>
                                                            <td class="User_Type">
                                                                <asp:Label ID="lblUser_Type" runat="server" Text='<%# Eval("User_Type")%>'> </asp:Label>
                                                            </td>
                                                            <td class="No">
                                                                <asp:Label ID="lblNo" runat="server" Text='<%# Eval("No")%>'> </asp:Label>
                                                            </td>
                                                            <td class="Name">
                                                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name")%>'> </asp:Label>
                                                            </td>
                                                            <td class="Book_No">
                                                                <asp:Label ID="lblBook_No" runat="server" Text='<%# Eval("Book_No")%>'> </asp:Label>
                                                            </td>
                                                            <td class="Book_Name">
                                                                <asp:Label ID="lblBook_Name" runat="server" Text='<%# Eval("Book_Name")%>'> </asp:Label>
                                                            </td>
                                                            <td class="Accession_No">
                                                                <asp:Label ID="lblAccession_No" runat="server" Text='<%# Eval("Accession_No")%>'> </asp:Label>
                                                            </td>
                                                            <td class="Date_of_Issue">
                                                                <asp:Label ID="lblDate_of_Issue" runat="server" Text='<%# DateTime.Parse(Eval("Date_of_Issue").ToString()).ToString("d") %>'>  </asp:Label>
                                                            </td>
                                                            <td class="Date_of_Return">
                                                                <asp:Label ID="lblDate_of_Return" runat="server" Text='<%# DateTime.Parse(Eval("Date_of_Return").ToString()).ToString("d") %>'> </asp:Label>
                                                            </td>
                                                            <td class="Location_Code">
                                                                <asp:Label ID="lblLocation_Code" runat="server" Text='<%# Eval("Location_Code")%>'> </asp:Label>
                                                            </td>
                                                            <td class="Avl_Qty">
                                                                <asp:Label ID="lblAvl_Qty" runat="server" Text='<%# Eval("Avl_Qty")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnIssue" CssClass="exportcss btn" runat="server" Text='Issue' CommandArgument='<%#Eval("Entry_No")%>' CommandName="Issue" />
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>

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

    </contenttemplate>
    <div id="MyPopup" class="modal fade" role="dialog">
        <div class="modal-dialog" style="width: 800px">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        &times;</button>
                    <h4 class="modal-title"></h4>
                </div>
                <div class="modal-body">
                    <div class="container box">
                        <div class="row">
                            <div class="col-lg-3 col-md-2"></div>
                            <div class="col-lg-12 col-md-12 model-box">
                                <div class="loader"  style="position:absolute" id="loader">
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
                                                                <div class="form-group">
                                                                    <asp:Label runat="server" Text="User Type"></asp:Label>
                                                                    <asp:DropDownList ID="ddlmdUserType" onchange="LoadUserType();" AutoPostBack="false" CssClass="form-control" runat="server">
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:Label runat="server" Text="No"></asp:Label>
                                                                    <asp:DropDownList ID="ddlNo" onchange="LoadStudentInfo();" AutoPostBack="false" CssClass="form-control" runat="server">
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:Label runat="server" Text="Name"></asp:Label>
                                                                    <asp:TextBox ID="txtmdName" ReadOnly="true" CssClass="DivReadonly form-control" runat="server"> </asp:TextBox>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:Label runat="server" Text="Accession No"></asp:Label>
                                                                    <asp:DropDownList ID="ddlAccessNo" onchange="LoadStudentAccessInfo();" AutoPostBack="false" CssClass="form-control" runat="server">
                                                                    </asp:DropDownList>
                                                                </div>
                                                               
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6 contact-info">
                                                            <div class="container">
                                                                 <div class="form-group">
                                                                    <asp:Label runat="server" Text="Book Name"></asp:Label>
                                                                    <asp:TextBox ID="txtmdBookName" ReadOnly="true" CssClass="DivReadonly form-control" runat="server"> </asp:TextBox>
                                                                </div>
                                                               <%-- <div class="form-group">
                                                                    <asp:Label runat="server" Text="Date of Issue"></asp:Label>
                                                                    <asp:TextBox ID="txtmdDateofIssue" ReadOnly="true" CssClass="DivReadonly form-control" runat="server"> </asp:TextBox>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:Label runat="server" Text="Date of Return"></asp:Label>
                                                                    <asp:TextBox ID="txtmdDateofReturn" ReadOnly="true" CssClass="DivReadonly form-control" runat="server"> </asp:TextBox>
                                                                </div>--%>
                                                                <div class="form-group">
                                                                    <asp:Label runat="server" Text="Book No"></asp:Label>
                                                                    <asp:TextBox ID="txtmdBookNo" ReadOnly="true" CssClass="DivReadonly form-control" runat="server"> </asp:TextBox>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:Label runat="server" Text="Avl Quantity"></asp:Label>
                                                                    <asp:TextBox ID="txtmdQuantity" ReadOnly="true" CssClass="DivReadonly form-control" runat="server"> </asp:TextBox>
                                                                </div>
                                                                <%--<div class="form-group">
                                                                    <asp:Label runat="server" Text="ClassCode"></asp:Label>
                                                                    <asp:TextBox ID="txtmdClassCode" ReadOnly="true" CssClass="DivReadonly form-control" runat="server"> </asp:TextBox>
                                                                </div>--%>
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
                <div class="form-group" style="margin: 0; position: absolute; bottom: 13%; right: 2%;">
                    <div>
                        <asp:Button runat="server" ID="btnAdd" Text="Issue" OnClientClick="IssueBook(); return false;"   class="btn btn-success"></asp:Button>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">
                        Close</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
