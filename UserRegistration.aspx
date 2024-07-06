<%@ Page Title="" Language="C#" MasterPageFile="~/UserRegistration.Master" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="HRMS.UserRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        label[for="ContentPlaceHolder1_chkInfra"] {
            vertical-align: unset !important;
            display: contents;
        }

        label[for="ContentPlaceHolder1_chkHRMS"] {
            vertical-align: unset !important;
            display: contents;
        }

        label[for="ContentPlaceHolder1_chkSLCM"] {
            vertical-align: unset !important;
            display: contents;
        }

        label[for="ContentPlaceHolder1_chkLibraryManagement"] {
            vertical-align: unset !important;
            display: contents;
        }

        label[for="ContentPlaceHolder1_chkFeeManagement"] {
            vertical-align: unset !important;
            display: contents;
        }

        label[for="ContentPlaceHolder1_chkAccountManagement"] {
            vertical-align: unset !important;
            display: contents;
        }

        label[for="ContentPlaceHolder1_chkStockAndStore"] {
            vertical-align: unset !important;
            display: contents;
        }

        label[for="ContentPlaceHolder1_chkPlacement"] {
            vertical-align: unset !important;
            display: contents;
        }

        label {
            color: navajowhite !important;
        }
    </style>
    <link href="assets/vendor/css/style.css" rel="stylesheet" />
    <div class="container px-4" style="background-color: darkslateblue">
        <div class="row gx-5">
            <div class="col" style="line-height: 0.6rem;">
                <div>
                    <label for="exampleFormControlInput1" class="form-label">UserName</label>
                    <asp:TextBox ID="txtUserName" CssClass="form-control border-3" placeholder="User name" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label class="form-label">Father's Name</label>
                    <asp:TextBox ID="txtfatherName" CssClass="form-control border-3" placeholder="Father's name" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label class="form-label">Mothr's Name</label>
                    <asp:TextBox ID="txtmotherName" CssClass="form-control border-3" placeholder="Mothr's Name" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label class="form-label">Adhar No</label>
                    <asp:TextBox ID="txtAdharNo" TextMode="Number" CssClass="form-control border-3" placeholder="Adhar No" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label class="form-label">Pan No</label>
                    <asp:TextBox ID="txtPanNo" CssClass="form-control border-3" placeholder="Pan No" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label class="form-label">Permanent Address</label>
                    <asp:TextBox ID="txtpermanentAddress" TextMode="MultiLine" CssClass="form-control border-3" placeholder="Permanent Address" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label class="form-label">Present Address</label>
                    <asp:TextBox ID="txtPresentAddress" TextMode="MultiLine" CssClass="form-control border-3" placeholder="Present Address" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label class="form-label">Email address</label>
                    <asp:TextBox ID="txtEmail" TextMode="Email" CssClass="form-control border-3" placeholder="name@example.com" type="email" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label class="form-label">Company Name</label>
                    <asp:TextBox ID="txtCompanyName" CssClass="form-control border-3" placeholder="Company Name" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label class="form-label">Mobile No</label>
                    <asp:TextBox ID="txtMobileNo" CssClass="form-control border-3" placeholder="Mobile No" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label class="form-label">Alternative Mobile No</label>
                    <asp:TextBox ID="txtaltMobileNo" CssClass="form-control border-3" placeholder="Alt Mobile No" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col" style="margin-top: 3%">
                <div class="form-check" style="line-height: 2rem;">
                    <asp:CheckBox runat="server" Text="Infrastructure Management" Style="vertical-align: unset;" ID="chkInfra" />
                </div>
                <div class="form-check" style="line-height: 2rem;">
                    <asp:CheckBox runat="server" Text="HRMS" ID="chkHRMS" />
                </div>
                <div class="form-check" style="line-height: 2rem;">
                    <asp:CheckBox runat="server" Text="SLCM" ID="chkSLCM" />
                </div>
                <div class="form-check" style="line-height: 2rem;">
                    <asp:CheckBox runat="server" Text="LibraryManagement" ID="chkLibraryManagement" />
                </div>
                <div class="form-check" style="line-height: 2rem;">
                    <asp:CheckBox runat="server" Text="Fee Management" ID="chkFeeManagement" />
                </div>
                <div class="form-check" style="line-height: 2rem;">
                    <asp:CheckBox runat="server" Text="Account Management" ID="chkAccountManagement" />
                </div>
                <div class="form-check" style="line-height: 2rem;">
                    <asp:CheckBox runat="server" Text="Stock And Store" ID="chkStockAndStore" />
                </div>
                <div class="form-check" style="line-height: 2rem;">
                    <asp:CheckBox runat="server" Text="Placement" ID="chkPlacement" />
                </div>
            </div>
        </div>
        <div class="row gx-5" style="text-align:center">
            <asp:RegularExpressionValidator ID="rev" runat="server" ErrorMessage="The PhoneNumber is not a valid phone number." ControlToValidate="txtMobileNo" ValidationExpression="^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$"></asp:RegularExpressionValidator>
            <asp:Button runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" Text="Submit" Style="color: darkslateblue; background-color: #f2eacc; font-weight: 700;"
                CssClass="btn btn-primary" />
        </div>
        <div runat="server" id="toster" visible="false" class="alert alert-warning alert-dismissible fade show" role="alert">
            <strong>
                <asp:Label runat="server" ID="lbluserName"></asp:Label></strong>
            <asp:Label runat="server" ID="lblMessage"></asp:Label>
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
    </div>
</asp:Content>
