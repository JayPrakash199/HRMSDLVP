<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.Master" AutoEventWireup="true" CodeBehind="EmployeeCard.aspx.cs" Inherits="HRMS.EmployeeCard" %>
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

        .row.md-12.marginx {
            margin: 69px;
            padding-bottom: 36px;
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
            border-bottom: 1px solid;
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

        .col-lg-12.col-md-12.summary-box {
            margin: 94px 10px 10px -113px;
        }
    </style>
    <div class="container box">
        <div class="row">
            <div class="col-lg-3 col-md-2"></div>
            <div class="col-lg-12 col-md-12 model-box">

                <div class="col-lg-12 col-md-12 summary-box">
                    <div class="col-lg-12 NewEntrydiv">
                        <p class="NewEntry">Employee Card</p>
                    </div>
                    <div class="row">
                        <div class="card-body">
                            <div class="row md-12 marginx">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-6 contact-info">
                                            <div class="container">
                                                <div class="form-group">
                                                    <label for="exampleAccount">HRMSID</label>
                                                    <asp:TextBox ID="txtid" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label for="exampleAccount">Bill Group</label>
                                                    <asp:TextBox ID="doj" CssClass="form-control" type="date" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label for="exampleAccount">Bill Type</label>
                                                     <asp:TextBox ID="TextBox14" CssClass="form-control"  runat="server"></asp:TextBox>
                                                </div>
                                                 <div class="form-group">
                                                    <label for="exampleAccount">Dept./Trade/Section</label>
                                                   <asp:TextBox ID="TextBox2" CssClass="form-control"  runat="server"></asp:TextBox>
                                                </div>
                                                 <div class="form-group">
                                                    <label for="exampleAccount">GPF/PRAN No</label>
                                                   <asp:TextBox ID="TextBox3" CssClass="form-control"  runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label for="exampleAccount">Gender</label>
                                                   <asp:TextBox ID="TextBox6" CssClass="form-control"  runat="server"></asp:TextBox>
                                                </div>
                                                 <div class="form-group">
                                                    <label for="exampleAccount">Category</label>
                                                   <asp:TextBox ID="TextBox5" CssClass="form-control"  runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label for="exampleAccount">D.O.J (Service)</label>
                                                   <asp:TextBox ID="TextBox7" CssClass="form-control" type="date" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label for="exampleAccount">Joining Designation</label>
                                                   <asp:TextBox ID="TextBox8" CssClass="form-control"  runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label for="exampleAccount">Home Dist</label>
                                                   <asp:TextBox ID="TextBox9" CssClass="form-control"  runat="server"></asp:TextBox>
                                                </div>

                                                 <div class="form-group">
                                                    <label for="exampleAccount">Status</label>
                                                   <asp:TextBox ID="TextBox10" CssClass="form-control"  runat="server"></asp:TextBox>
                                                </div>

                                                  <div class="form-group">
                                                    <label for="exampleAccount">Email ID</label>
                                                   <asp:TextBox ID="TextBox11" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>

                                                 <div class="form-group">
                                                    <label for="exampleAccount">EPIC NO</label>
                                                   <asp:TextBox ID="TextBox12" CssClass="form-control"  runat="server"></asp:TextBox>
                                                </div>

                                                 <div class="form-group">
                                                    <label for="exampleAccount">Pension Remark</label>
                                                   <asp:TextBox ID="TextBox13" CssClass="form-control"  runat="server"></asp:TextBox>
                                                </div>




                                            </div>
                                        </div>
                                        <div class="col-md-6 contact-info">
                                            <div class="container">
                                                <div class="form-group">
                                                    <label for="exampleAccount">Name of the Staff</label>
                                                    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label for="exampleAccount">Account Type</label>
                                                    <asp:TextBox ID="TextBox4" CssClass="form-control" type="date" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label for="exampleAccount">Designation</label>
                                                     <asp:TextBox ID="TextBox15" CssClass="form-control"  runat="server"></asp:TextBox>
                                                </div>
                                                 <div class="form-group">
                                                    <label for="exampleAccount">Post Group</label>
                                                   <asp:TextBox ID="TextBox16" CssClass="form-control"  runat="server"></asp:TextBox>
                                                </div>
                                                 <div class="form-group">
                                                    <label for="exampleAccount">D.O.B</label>
                                                   <asp:TextBox ID="TextBox17" CssClass="form-control" type="date"  runat="server"></asp:TextBox>
                                                </div>
                                                 <div class="form-group">
                                                    <label for="exampleAccount">D.O.S</label>
                                                   <asp:TextBox ID="TextBox27" CssClass="form-control" type="date" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label for="exampleAccount">Joining Station</label>
                                                   <asp:TextBox ID="TextBox18" CssClass="form-control"  runat="server"></asp:TextBox>
                                                </div>
                                                
                                                <div class="form-group">
                                                    <label for="exampleAccount">Current Station</label>
                                                   <asp:TextBox ID="TextBox22" CssClass="form-control"  runat="server"></asp:TextBox>
                                                </div>

                                                 <div class="form-group">
                                                    <label for="exampleAccount">Base Qualification</label>
                                                   <asp:TextBox ID="TextBox23" CssClass="form-control"  runat="server"></asp:TextBox>
                                                </div>

                                                  <div class="form-group">
                                                    <label for="exampleAccount">Basic Gr. Pay:</label>
                                                   <asp:TextBox ID="TextBox24" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>

                                                 <div class="form-group">
                                                    <label for="exampleAccount">Date of increment</label>
                                                   <asp:TextBox ID="TextBox25" CssClass="form-control"  runat="server"></asp:TextBox>
                                                </div>

                                                 <div class="form-group">
                                                    <label for="exampleAccount">MACP Status</label>
                                                   <asp:TextBox ID="TextBox26" CssClass="form-control"  runat="server"></asp:TextBox>
                                                </div>
                                                 <div class="form-group">
                                                    <label for="exampleAccount">Mobile no</label>
                                                   <asp:TextBox ID="TextBox28" CssClass="form-control"  runat="server"></asp:TextBox>
                                                </div>
                                                 <div class="form-group">
                                                    <label for="exampleAccount">Aadhaar No</label>
                                                   <asp:TextBox ID="TextBox29" CssClass="form-control"  runat="server"></asp:TextBox>
                                                </div>



                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <asp:Button ID="btnEstimateSubmit" runat="server" CssClass="btn-s float-right submit" type="submit" Text="Print" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-2">
                    </div>
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
    </script>
</asp:Content>
