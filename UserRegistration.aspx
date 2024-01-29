<%@ Page Title="" Language="C#" MasterPageFile="~/UserRegistration.Master" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="HRMS.UserRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container px-4">
        <div class="row gx-5">
            <div class="col" style="line-height: 0.6rem;">
                <div class="mb-3">
                    <label for="exampleFormControlInput1" class="form-label">UserName</label>
                    <asp:TextBox ID="txtUserName" CssClass="form-control border-3" placeholder="name" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Father's Name</label>
                    <asp:TextBox ID="txtfatherName" CssClass="form-control border-3" placeholder="name" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Mothr's Name</label>
                    <asp:TextBox ID="txtmotherName" CssClass="form-control border-3" placeholder="name" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Adhar No</label>
                    <asp:TextBox ID="txtAdharNo" TextMode="Number" CssClass="form-control border-3" placeholder="name" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Pan No</label>
                    <asp:TextBox ID="txtPanNo" CssClass="form-control border-3" placeholder="name" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">PermanentAddress</label>
                    <asp:TextBox ID="txtpermanentAddress" TextMode="MultiLine"  CssClass="form-control border-3" placeholder="name" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">PresentAddress</label>
                    <asp:TextBox ID="txtPresentAddress" TextMode="MultiLine" CssClass="form-control border-3" placeholder="name" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Email address</label>
                    <asp:TextBox ID="txtEmail" TextMode="Email" CssClass="form-control border-3" placeholder="name@example.com" type="email" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Company Name</label>
                    <asp:TextBox ID="txtCompanyName" CssClass="form-control border-3" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Mobile No</label>
                    <asp:TextBox ID="txtMobileNo" CssClass="form-control border-3" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Alternative Mobile No</label>
                    <asp:TextBox ID="txtaltMobileNo" CssClass="form-control border-3" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col">
                <div class="form-check">
                    <asp:CheckBox runat="server" Text="Infrastructure Management" CssClass="form-control border-0" ID="chkInfra" />
                </div>
                <div class="form-check">
                    <asp:CheckBox runat="server" Text="HRMS" CssClass="form-control border-0" ID="chkHRMS" />
                </div>
                <div class="form-check">
                    <asp:CheckBox runat="server" Text="SLCM" CssClass="form-control border-0" ID="chkSLCM" />
                </div>
                <div class="form-check">
                    <asp:CheckBox runat="server" Text="LibraryManagement" CssClass="form-control border-0" ID="chkLibraryManagement" />
                </div>
                <div class="form-check">
                    <asp:CheckBox runat="server" Text="Fee Management" CssClass="form-control border-0" ID="chkFeeManagement" />
                </div>
                <div class="form-check">
                    <asp:CheckBox runat="server" Text="Account Management" CssClass="form-control border-0" ID="chkAccountManagement" />
                </div>
                <div class="form-check">
                    <asp:CheckBox runat="server" Text="Stock And Store" CssClass="form-control border-0" ID="chkStockAndStore" />
                </div>
                <div class="form-check">
                    <asp:CheckBox runat="server" Text="Placement" CssClass="form-control border-0" ID="chkPlacement" />
                </div>
            </div>
        </div>
        <div>
            <asp:RegularExpressionValidator ID="rev" runat="server" ErrorMessage="The PhoneNumber is not a valid phone number." ControlToValidate="txtMobileNo" ValidationExpression="^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$"></asp:RegularExpressionValidator>
            <asp:Button runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" Text="Submit" CssClass="btn btn-primary" />
        </div>
        <div runat="server" id="toster" visible="false" class="alert alert-warning alert-dismissible fade show" role="alert">
            <strong>
                <asp:Label runat="server" ID="lbluserName"></asp:Label></strong>
            <asp:Label runat="server" ID="lblMessage"></asp:Label>
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
    </div>
</asp:Content>
