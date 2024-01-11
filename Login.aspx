<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HRMS.Login1" %>

<%@ Register Assembly="BotDetect" Namespace="BotDetect.Web.UI" TagPrefix="BotDetect" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="Scripts/jquery-3.6.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <style type="text/css">
        .gradient-custom {
            /* fallback for old browsers */
            background: #6a11cb;
            /* Chrome 10-25, Safari 5.1-6 */
            background: -webkit-linear-gradient(to right, rgba(106, 17, 203, 1), rgba(37, 117, 252, 1));
            /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
            background: linear-gradient(to right, rgba(106, 17, 203, 1), rgba(37, 117, 252, 1))
        }
    </style>
    <script type="text/javascript">
        function ShowPopup(title) {
            $("#MyPopup .modal-title").html(title);
            $("#MyPopup").modal("show");
        }
        function redirectOnSuccess() {
            debugger;
            var cmpnyName = document.getElementById('ContentPlaceHolder1_ddlCompany').value;
            $.ajax({
                type: "POST",
                url: "Login.aspx/SetCompanyForDirector",
                data: "{'companyName':'" + cmpnyName + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (d) {
                    alert(d.responseText);
                }
            });
        }
        function OnSuccess(data) {
            var delayInMilliseconds = 1000;
            setTimeout(function () {
            }, delayInMilliseconds);
            window.location.href = "Default.aspx";
        }

    </script>
    <div class="container">
        <section class="">

            <div class="row d-flex justify-content-center align-items-center" style="height: auto; padding-top: 2%">
                <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                    <div class="card text-white" style="border-radius: 1rem; background-color: darkslateblue; box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);">
                        <div class="card-body p-5 text-center">
                            <div class="mb-md-3">
                                <h2 class="fw-bold mb-2 text-uppercase">Login</h2>
                                <p class="text-white-50">Please enter your login and password!</p>
                                <div class="form-outline form-white mb-4">
                                    <asp:TextBox ID="txtEmailAddress" runat="server" class="form-control form-control-lg" placeholder="User Name"></asp:TextBox>
                                </div>
                                <div class="form-outline form-white mb-4">
                                    <asp:TextBox ID="txtPassword" type="password" runat="server" class="form-control form-control-lg" placeholder="Password"></asp:TextBox>
                                </div>
                                <div class="form-floating form-white mb-4">
                                    <div class="container text-center">
                                        <div class="row">
                                            <div class="col order-last" style="margin-top: 1rem">
                                                <asp:TextBox ID="txtCaptch" runat="server" Style="width: 70%" class="form-control form-control-lg" placeholder="Captch"></asp:TextBox>
                                            </div>
                                            <div>
                                                <botdetect:webformscaptcha id="captchaBox" runat="server"></botdetect:webformscaptcha>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <asp:Button runat="server" ID="btnLogin" OnClick="btnLogin_Click" class="btn btn-outline-light btn-lg px-5" Text="Login" />
                                <br />
                                <br />
                                <asp:HyperLink runat="server" ID="Button1" NavigateUrl="~/ForgotPassword.aspx" Text="Forget Password?" />
                            </div>
                            <div runat="server" id="alertMsg" visible="false" class="alert alert-danger" role="alert">
                                You have entered an invalid username or password!
                            </div>
                            <div runat="server" id="captchMsg" visible="false" class="alert alert-danger" role="alert">
                                Please enter valid captch.
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>


    </div>

    <div id="CompanyPopup" class="modal fade" role="dialog">
        <div class="modal-dialog" style="width: 800px">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" style="background-color: darkslateblue">
                    <button type="button" style="background-color: darkslateblue !important" class="close" data-dismiss="modal">
                        &times;</button>
                    <h4 class="modal-title"></h4>
                </div>
                <div class="modal-body" style="height: 170px">
                    <div class="container box">
                        <div class="row">
                            <div class="col-lg-12 col-md-12 model-box">
                                <div class="loader" style="position: absolute" id="loader">
                                    <div class="loader-img"><i class="fa fa-spinner fa-spin"></i></div>
                                </div>

                                <div class="card-body">
                                    <div class="col-md-9">
                                        <div class="row">
                                            <div class="container">
                                                <div class="form-group">
                                                    <asp:Label runat="server" Text="Company"></asp:Label>
                                                    <asp:DropDownList ID="ddlCompany" Style="cursor: pointer; margin-top: 5%" CssClass="form-control" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="form-group" style="margin: 0; position: absolute; bottom: 10%; right: 5%;">
                    <div>
                        <asp:Button runat="server" style="background-color: darkslateblue !important" ID="btnOkay" Text="Submit" OnClientClick="redirectOnSuccess(); return false;" class="btn btn-success"></asp:Button>
                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
