<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="HRMS.ForgotPassword" %>

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

    <div class="container">

        <div id="forgotPassdiv" runat="server" class="row d-flex justify-content-center align-items-center" style="height: auto; padding-top: 8%">
            <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                <div class="card text-white" style="border-radius: 1rem; background-color: darkslateblue; box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);">
                    <div class="card-body p-5 text-center">
                        <div class="mb-md-3">
                            <h2 class=" mb-2 ">Forgot Your password?</h2>
                            <p class="text-white-50">Please enter your Username!</p>
                            <div class="form-outline form-white mb-4">
                                <asp:TextBox  style="box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)" ID="txtEmailAddress" runat="server" class="form-control form-control-lg" placeholder="User Name"></asp:TextBox>
                            </div>
                            <asp:Button runat="server" ID="btnForgot" OnClick="btnForgot_Click"
                                Style="box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19); border-color: #f4ecce; "
                                class="btn btn-outline-light btn-lg px-5" Text="Submit" />
                            <br />
                            <br />
                            <div >
                                <asp:HyperLink runat="server" ID="btnLogin" ForeColor="Blue" NavigateUrl="~/Login.aspx" Text="Back to login?" />
                            </div>
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
        <div id="resetPassdiv" visible="false" runat="server" class="row d-flex justify-content-center align-items-center" style="height: auto; padding-top: 2%">
            <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                <div class="card text-white" style="border-radius: 1rem; background-color: darkslateblue; box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);">
                    <div class="card-body p-5 text-center">
                        <div class="mb-md-3">
                            <h2 class=" mb-2 ">Reset Your password !</h2>
                            <p class="text-white-50">Please enter your new password!</p>
                            <div class="form-outline form-white mb-4">
                                <asp:TextBox style="box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)" ID="txtCurrentPassword" runat="server" class="form-control form-control-lg" placeholder="Old Password"></asp:TextBox>
                            </div>
                            <div class="form-outline form-white mb-4">
                                <asp:TextBox style="box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)" ID="txtresetPassword" runat="server" type="password" class="form-control form-control-lg" placeholder="New Password"></asp:TextBox>
                            </div>
                            <div class="form-outline form-white mb-4">
                                <asp:TextBox style="box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)" ID="txtConfirmresetPassword" type="password" runat="server" class="form-control form-control-lg" placeholder="Confirm New Password"></asp:TextBox>
                            </div>
                            <asp:CompareValidator ID="passwordCompareValidator" runat="server" ControlToCompare="txtresetPassword"
                                ControlToValidate="txtConfirmresetPassword" Display="Dynamic" ErrorMessage="Ensure both password should be same!" ForeColor="Red"
                                Operator="Equal" Type="String"></asp:CompareValidator>
                            <asp:Button runat="server" ID="btnReset" OnClick="btnReset_Click" class="btn btn-outline-light btn-lg px-5"
                                Style="box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19); border-color: #f4ecce; "
                                Text="Set password" />
                            <br />
                            <div>
                                <asp:HyperLink runat="server" ID="HyperLink1" ForeColor="Blue" NavigateUrl="~/Login.aspx" Text="Back to login?" />
                            </div>
                        </div>
                        <div runat="server" id="Div1" visible="false" class="alert alert-danger" role="alert">
                            You have entered an invalid username or password!
                        </div>
                        <br />
                        <asp:Label ID="lblmsg" Style="text-shadow: 2px 2px 4px #000000;" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>


    </div>

</asp:Content>
