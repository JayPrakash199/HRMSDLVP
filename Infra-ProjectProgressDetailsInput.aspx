<%@ Page Title="" Language="C#" MasterPageFile="~/Infrastructure.Master" AutoEventWireup="true" CodeBehind="Infra-ProjectProgressDetailsInput.aspx.cs" Inherits="HRMS.Infra_ProjectProgressDetailsInput" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/material-design-icons/3.0.1/iconfont/material-icons.min.css" />
    <style>
        .summary-box {
            margin-top: 75px;
            height: auto;
            text-align: center;
            box-shadow: 0 3px 6px rgb(0 0 0 / 16%), 0 3px 6px rgb(0 0 0 / 23%);
            border: 1px solid;
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

        .row.md-12.marginx {
            margin: 69px;
            padding-bottom: 36px;
            border-bottom: 1px solid;
        }

        i.fal.fa-plus-circle.full {
            font-size: 52px;
            float: right;
            margin: 6px;
        }

        .Addaditional {
            border: solid 1px black;
            background-color: white;
            width: auto;
            height: 43px;
            margin: 10px;
            float: left;
        }

        .btn-s.float-right {
            float: right;
            background: white;
            width: 72px;
            height: 31px;
        }

        .form-control {
            height: 33px;
            margin: 2px 0;
            font-size: 13px;
            background-color: white;
            color: #000;
            font-weight: 700;
            border: 1px solid #7f7e7e;
        }

        select.form-control {
            background-color: white;
        }
        /*Modal Control*/
        .modal-dialog {
            width: 978px;
            margin: 30px auto;
        }

        .modal-header {
            background-color: white;
            font-size: 16px;
            line-height: 28px;
            padding: 10px 15px;
            display: inline-block;
            color: #f5f5f5;
            border-top: none;
            width: 100%;
        }

            .modalExtender-heading .close, .modal-header .close {
                margin: 6px;
            }

        .col-md-6.Buliding {
            padding: 20px;
        }

        h3.hadingline {
            color: black;
            font-size: 20px;
        }

        .btn-s.float-right.submit {
            background: black;
            color: white;
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

        .textalline {
            float: left;
            font-size: 10px;
            width: 203px;
            text-align: justify;
        }

        .col-md-6.space label {
            font-size: 8px;
            float: left;
            height: 12px;
        }

        i.fa.fa-search.icon {
            position: absolute;
            padding: 10px;
            display: block;
        }

        .col-lg-12.col-md-12.model-box {
            margin: 34px 10px 10px -113px;
        }
        input#ContentPlaceHolder1_txtProjectSearch {
    text-align: right;
}
    </style>

    <div class="container box">
        <div class="row">
            <div class="col-lg-3 col-md-2"></div>
            <div class="col-lg-12 col-md-12 model-box">                
                <div class="col-lg-12 col-md-12 summary-box">
                    <div class="col-lg-12 NewEntrydiv">
                        <p class="NewEntry">Project Progress Details Input(For Ongoing & Improvement Projects)</p>
                    </div>
                    <div class="row">
                        <div class="card-body">
                            <div class="row md-12 marginx">
                                <div class="headerbox">
                                    <div class="col-md-6 Buliding">
                                        <div class="row">
                                            <div class="col-md-3 ">
                                                <label for="exampleAccount">Project Code </label>
                                            </div>
                                            <div class="col-md-5 input-icons">
                                                <i class="fa fa-search icon"></i>
                                                <asp:TextBox ID="txtProjectSearch" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3 input-icons">
                                                <asp:Button ID="btnSearch" OnClientClick="showLoader();" OnClick="btnSearch_Click" CssClass="btn-s float-right submit" Text="Search" runat="server" />
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-8" style="padding-top: 0.5%;">
                                                 <asp:Label CssClass="message" ID="LblMessage" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6 Buliding">
                                        <div class="row">
                                            <div class="col-md-12 space">
                                                <div class="row">
                                                    <div class="col-md-12 ">
                                                        <label runat="server" id="Label1" for="exampleAccount">Distict - </label>
                                                        <label runat="server" id="lblDistrict" for="exampleAccount"></label>
                                                    </div>
                                                    <div class="col-md-12 ">
                                                        <label runat="server" id="Label2" for="exampleAccount">Name Of the Institute - </label>
                                                        <label runat="server" id="lblInstitute" for="exampleAccount"></label>
                                                    </div>
                                                    <div class="col-md-12 ">
                                                         <label runat="server" id="Label3" for="exampleAccount">Project Type - </label>
                                                        <label runat="server" id="lblProjectType" for="exampleAccount"></label>
                                                    </div>
                                                    <div class="col-md-12 ">
                                                         <label runat="server" id="Label4" for="exampleAccount">Building Id (for Improvement type Projects only) - </label>
                                                        <label runat="server" id="lblBuildingId" for="exampleAccount"></label>
                                                    </div>
                                                    <div class="col-md-12 ">
                                                         <label runat="server" id="Label5" for="exampleAccount">Name of the Project - </label>
                                                        <label runat="server" id="lblProjectName" for="exampleAccount"></label>
                                                    </div>
                                                    <div class="col-md-12 ">
                                                         <label runat="server" id="Label6" for="exampleAccount">Name of the Agency -</label>
                                                        <label runat="server" id="lblAgencyName" for="exampleAccount"></label>
                                                    </div>
                                                    <div class="col-md-12 ">
                                                        <label runat="server" id="Label7" for="exampleAccount">Type of the Work -</label>
                                                        <label runat="server" id="lblWorkType" for="exampleAccount"></label>
                                                    </div>
                                                    <div class="col-md-12 ">
                                                        <label runat="server" id="Label8" for="exampleAccount">Mode of the Work - </label>
                                                        <label runat="server" id="lblWorkMode" for="exampleAccount"></label>
                                                    </div>
                                                    <div class="col-md-12 ">
                                                        <label runat="server" id="Label9" for="exampleAccount">Date of Commencement as per agreement -</label>
                                                        <label runat="server" id="lblCommencementDate" for="exampleAccount"></label>
                                                    </div>
                                                    <div class="col-md-12 ">
                                                        <label runat="server" id="Label10" for="exampleAccount">Date of Completion as per agreement -</label>
                                                        <label runat="server" id="lblCompletionDate" for="exampleAccount"></label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="row">
                                    <h3 class="hadingline">Enter Project Progress Details Below</h3>
                                    <div class="col-md-6 contact-info">
                                        <div class="container">
                                            <div class="form-group">
                                                <asp:HiddenField ID="hiddenFiledProjectCode" runat="server" />
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleAccount">AA no.</label>
                                                <asp:TextBox ID="txtAANo" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label for="exampleAccount">Amount of AA accorded (Rs In Lakh)</label>
                                                <asp:TextBox ID="txtAmountOfAA" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleAccount">Running Financial Year (yyyy-yy)</label>
                                                <asp:TextBox ID="txtRunningFinanacialYear" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleAccount">Running FY expenditure In lakh</label>
                                                <asp:TextBox ID="txtRunningExp" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleAccount">Balance fund required for commencement of work in Running FY in Lakh</label>
                                                <asp:TextBox ID="txtCommencementBalanceWork" onkeypress="return isDecimalNumberKey(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleAccount">Present Status</label>
                                                <asp:TextBox ID="txtPresentStatus" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleAccount">Reason for delay, if delayed</label>
                                                <asp:TextBox ID="txtDelayReason" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleAccount">% of work completion</label>
                                                <asp:TextBox ID="txtWorkCompletionPercentage" onkeypress="return isDecimalNumberKey(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>                                            
                                        </div>
                                    </div>
                                    <div class="col-md-6 contact-info">
                                        <div class="container">
                                            <div class="form-group">
                                                <label for="exampleAccount">AA Date</label>
                                                <asp:TextBox ID="txtAADate" type="date" max="9999-12-31" CssClass="form-control ajax__calendar_body" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleAccount">Aggrement value with GST (Rs In Lakh)</label>
                                                <asp:TextBox ID="txtAgreementValue" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleAccount">Expenditure made as on 31 march of Last FY in lakh</label>
                                                <asp:TextBox ID="txtExpenditureMade" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleAccount">Balance fund required for completion of work in Running FY in Lakh</label>
                                                <asp:TextBox ID="txtCompletionBalanceFund" CssClass="form-control" onkeypress="return isDecimalNumberKey(event)" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label for="exampleAccount">Expected/Target date for completion </label>
                                                <asp:TextBox ID="txtExpectedDate" type="date" max="9999-12-31" CssClass="form-control ajax__calendar_body" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleAccount">Tender Variation</label>
                                                <asp:DropDownList ID="ddlTenderVariation" CssClass="form-control select" runat="server">
                                                    <asp:ListItem Value="Excess">Excess</asp:ListItem>
                                                    <asp:ListItem Value="Less">Less</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleAccount">Fund now proposed for release in Running FY in Lakh</label>
                                                <asp:TextBox ID="txtFundNow" onkeypress="return isDecimalNumberKey(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleAccount">UC status</label>
                                                <asp:DropDownList ID="ddlUCStatus" CssClass="form-control select" runat="server">
                                                    <asp:ListItem Value="blank"></asp:ListItem>
                                                    <asp:ListItem Value="Submitted">Submitted</asp:ListItem>
                                                    <asp:ListItem Value="ToBeSubmitted">ToBeSubmitted</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <asp:Button ID="ProjectProgressSubmit" runat="server" OnClick="ProjectProgressSubmit_Click" CssClass="btn-s float-right submit" type="submit" Text="Submit" />
                            </div>
                        </div>
                    </div>

                </div>
                <div class="col-lg-3 col-md-2">
                </div>
            </div>
        </div>
    </div>
     <script language="Javascript">
        function isDecimalNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57))
                return false;

            return true;
         }
         function showLoader() {
             $('#loader').show();
         };
         function hideLoader() {
             $('#loader').hide();
         };
     </script>

</asp:Content>
