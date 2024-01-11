<%@ Page Title="" Language="C#" MasterPageFile="~/Infrastructure.Master" AutoEventWireup="true" CodeBehind="Infra-GeneralLandBuilding.aspx.cs" Inherits="HRMS.Infra_GeneralLandBuilding" %>
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

        .blockInputClass {
            pointer-events: none;
        }
    </style>

    <div class="container box">

        <div class="card">
            <div class="card-body">
                <div class="row">
                    <div class="col-lg-3 col-md-2"></div>
                    <div class="col-lg-12 col-md-12">
                        <div class="row">
                            <div class="card-body">
                                <div class="row md-12 marginx">
                                    <div class="headerbox">
                                        <h1 class="NewEntry"></h1>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="row">
                                            <h3 class="hadingline">General Land/Building Detail Card</h3>
                                            <div class="col-md-6 contact-info">
                                                <div class="container">
                                                    <div class="form-group">
                                                        <label for="exampleAccount">Year of Establishment</label>
                                                        <asp:TextBox ID="txtYear_of_Establis_of_institute" CssClass="form-control blockInputClass" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">
                                                            Field Available
                                                            <asp:CheckBox runat="server" ID="chkFieldAvailable" CssClass="blockInputClass" /></label>
                                                        <div class="input-group">
                                                            <label class="input-group-btn">
                                                                <span class="custom-file-input btn" id="fieldAvailableSpan" style="display: none">
                                                                    <asp:FileUpload ID="FileAvailablepdfUploader" runat="server" Style="display: none" accept=".pdf" />
                                                                    <asp:LinkButton ID="fileAvailableUpload" OnClick="fileAvailableUpload_Click" CssClass="btn btn-yellow" runat="server">Upload</asp:LinkButton>
                                                                    <asp:LinkButton ID="btnFileAvailableDownload" OnClick="btnFileAvailableDownload_Click" CssClass="btn btn-link" runat="server">Download File</asp:LinkButton>
                                                                </span>
                                                            </label>
                                                        </div>
                                                        <%--<span class="custom-file-input btn" id="fieldAvailableSpan" style="display: none">
                                                            <asp:FileUpload ID="FileAvailablepdfUploader" runat="server" accept=".pdf" />
                                                            <asp:LinkButton ID="fileAvailableUpload" OnClick="fileAvailableUpload_Click" CssClass="btn btn-yellow" runat="server">Upload</asp:LinkButton>
                                                            <asp:LinkButton ID="btnFileAvailableDownload" OnClick="btnFileAvailableDownload_Click" CssClass="btn btn-link" runat="server">Download File</asp:LinkButton>
                                                        </span>--%>
                                                    </div>
                                                    <div class="form-group" id="divFieldArea" style="display: none">
                                                        <label for="exampleAccount">Field Area (in Acres)</label>
                                                        <asp:TextBox ID="txtField_Area_in_Acres" onkeypress="return isDecimalNumberKey(event)" CssClass="form-control blockInputClass" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">
                                                            Sport's Court Available
                                                            <asp:CheckBox runat="server" ID="chkSportCourt" CssClass="blockInputClass" /></label>
                                                        <div class="input-group">
                                                            <label class="input-group-btn">
                                                                <span class="custom-file-input btn" id="sportsCourtSpan" style="display: none">
                                                                    <asp:FileUpload ID="SportCourtFileUploader" runat="server" Style="display: none" accept=".pdf" />
                                                                    <asp:LinkButton ID="SportCourtFileUploadButton" OnClick="SportCourtFileUploadButton_Click" CssClass="btn btn-yellow" runat="server">Upload</asp:LinkButton>
                                                                    <asp:LinkButton ID="SportCourtDownloadButton" OnClick="SportCourtDownloadButton_Click" CssClass="btn btn-link" runat="server">Download File</asp:LinkButton>
                                                                </span>
                                                            </label>
                                                        </div>
                                                    </div>
                                                    <div class="form-group" id="divSportCourt" style="display: none">
                                                        <label for="exampleAccount">Sports Court Area (in Sqft)</label>
                                                        <asp:TextBox ID="txtSports_Court_Area_in_Sqft" onkeypress="return isDecimalNumberKey(event)" CssClass="form-control blockInputClass" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">
                                                            Field Gallery Available
                                                            <asp:CheckBox runat="server" ID="chkFieldGalleryAvailable" CssClass="blockInputClass" /></label>
                                                        <div class="input-group">
                                                            <label class="input-group-btn">
                                                                <span class="custom-file-input btn" id="fieldGallerySpan" style="display: none">
                                                                    <asp:FileUpload ID="fieldGalleryFileUploader" runat="server" Style="display: none" accept=".pdf" />
                                                                    <asp:LinkButton ID="fieldGalleryFileUploadButton" OnClick="fieldGalleryFileUploadButton_Click" CssClass="btn btn-yellow" runat="server">Upload</asp:LinkButton>
                                                                    <asp:LinkButton ID="fieldGalleryDownloadButton" OnClick="fieldGalleryDownloadButton_Click" CssClass="btn btn-link" runat="server">Download File</asp:LinkButton>
                                                                </span>
                                                            </label>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">
                                                            Conference Room Available
                                                            <asp:CheckBox runat="server" ID="chkConferenceRoomAvailable" CssClass="blockInputClass" /></label>
                                                        <div class="input-group">
                                                            <label class="input-group-btn">
                                                                <span class="custom-file-input btn" id="conferenceRoomSpan" style="display: none">
                                                                    <asp:FileUpload ID="conferenceRoomFileUploader" runat="server" Style="display: none" accept=".pdf" />
                                                                    <asp:LinkButton ID="conferenceRoomUploadButton" OnClick="conferenceRoomUploadButton_Click" CssClass="btn btn-yellow" runat="server">Upload</asp:LinkButton>
                                                                    <asp:LinkButton ID="conferenceRoomDownloadButton" OnClick="conferenceRoomDownloadButton_Click" CssClass="btn btn-link" runat="server">Download File</asp:LinkButton>
                                                                </span>
                                                            </label>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">
                                                            Video Conference Room Available
                                                            <asp:CheckBox runat="server" ID="chkVideo_Conference_Room_Avail" CssClass="blockInputClass" /></label>
                                                        <div class="input-group">
                                                            <label class="input-group-btn">
                                                                <span class="custom-file-input btn" id="spanVideoConferenceRoom" style="display: none">
                                                                    <asp:FileUpload ID="VideoConferenceRoomUploader" runat="server" Style="display: none" accept=".pdf" />
                                                                    <asp:LinkButton ID="videoConferenceRoomUploadButton" OnClick="videoConferenceRoomUploadButton_Click" CssClass="btn btn-yellow" runat="server">Upload</asp:LinkButton>
                                                                    <asp:LinkButton ID="VideoConferenceRoomDownloadButton" OnClick="VideoConferenceRoomDownloadButton_Click" CssClass="btn btn-link" runat="server">Download File</asp:LinkButton>
                                                                </span>
                                                            </label>
                                                        </div>
                                                    </div>
                                                    <div class="form-group" id="divVideoConferenceRoom" style="display: none">
                                                        <label for="exampleAccount">Floor size of the Video conference room (in sqft)</label>
                                                        <asp:TextBox ID="txtFloor_size_of_the_Video_conf" onkeypress="return isDecimalNumberKey(event)" CssClass="form-control blockInputClass" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group" id="divVideoConferenceRoomCapacity" style="display: none">
                                                        <label for="exampleAccount">Video Conference Room Capacity</label>
                                                        <asp:TextBox ID="txtVideo_Conference_Room_Capacity" onkeypress="return isDecimalNumberKey(event)" CssClass="form-control blockInputClass" runat="server"></asp:TextBox>
                                                    </div>

                                                    <div class="form-group" id="divVideoConferenceRoomLocation" style="display: none">
                                                        <label for="exampleAccount">Video Conference Room Location</label>
                                                        <asp:TextBox ID="txtVideo_Conference_Room_Location" CssClass="form-control blockInputClass" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">
                                                            Library Available
                                                            <asp:CheckBox runat="server" ID="chkLibrary_Available" CssClass="blockInputClass" /></label>
                                                        <div class="input-group">
                                                            <label class="input-group-btn">
                                                                <span class="custom-file-input btn" id="spanLibraryAvailable" style="display: none">
                                                                    <asp:FileUpload ID="Library_AvailableFileUploader" runat="server" Style="display: none" accept=".pdf" />
                                                                    <asp:LinkButton ID="Library_AvailableUploadButton" OnClick="Library_AvailableUploadButton_Click" CssClass="btn btn-yellow" runat="server">Upload</asp:LinkButton>
                                                                    <asp:LinkButton ID="Library_AvailableDownloadButton" OnClick="Library_AvailableDownloadButton_Click" CssClass="btn btn-link" runat="server">Download File</asp:LinkButton>
                                                                </span>
                                                            </label>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">
                                                            Central Library Available
                                                            <asp:CheckBox runat="server" ID="chkCentralLibraryAvailable" CssClass="blockInputClass" /></label>
                                                        <div class="input-group">
                                                            <label class="input-group-btn">
                                                                <span class="custom-file-input btn" id="spanCentralLibraryAvailable" style="display: none">
                                                                    <asp:FileUpload ID="CentralLibraryFileUploader" runat="server" Style="display: none" accept=".pdf" />
                                                                    <asp:LinkButton ID="CentralLibraryUploadButton" OnClick="CentralLibraryUploadButton_Click" CssClass="btn btn-yellow" runat="server">Upload</asp:LinkButton>
                                                                    <asp:LinkButton ID="CentralLibraryDowloadButton" OnClick="CentralLibraryDowloadButton_Click" CssClass="btn btn-link" runat="server">Download File</asp:LinkButton>
                                                                </span>
                                                            </label>
                                                        </div>
                                                    </div>

                                                    <div class="form-group">
                                                        <label for="exampleAccount">Main Entrance Photo</label>
                                                        <div class="input-group">
                                                            <label class="input-group-btn">
                                                                <span class="custom-file-input btn">
                                                                    <asp:FileUpload ID="mainEntranceUploader" runat="server" Style="display: none" accept=".pdf" />
                                                                    <asp:LinkButton ID="mainEntranceUploadButton" OnClick="mainEntranceUploadButton_Click" CssClass="btn btn-yellow" runat="server">Upload</asp:LinkButton>
                                                                    <asp:LinkButton ID="mainEntranceDownButton" OnClick="mainEntranceDownButton_Click" CssClass="btn btn-link" runat="server">Download File</asp:LinkButton>
                                                                </span>
                                                            </label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6 contact-info">
                                                <div class="container">
                                                    <div class="form-group">
                                                        <label for="exampleAccount">
                                                            Dispensary Available
                                                            <asp:CheckBox runat="server" ID="chkDispensary_Available" CssClass="blockInputClass" /></label>
                                                        <div class="input-group">
                                                            <label class="input-group-btn">
                                                                <span class="custom-file-input btn" id="spanDispensaryAvailable" style="display: none">
                                                                    <asp:FileUpload ID="DispensaryAvailableUploader" runat="server" Style="display: none" accept=".pdf" />
                                                                    <asp:LinkButton ID="DispensaryAvailableUploadButton" OnClick="DispensaryAvailableUploadButton_Click" CssClass="btn btn-yellow" runat="server">Upload</asp:LinkButton>
                                                                    <asp:LinkButton ID="DispensaryAvailableDownloadButton" OnClick="DispensaryAvailableDownloadButton_Click" CssClass="btn btn-link" runat="server">Download File</asp:LinkButton>
                                                                </span>
                                                            </label>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">
                                                            COE Program Available
                                                            <asp:CheckBox runat="server" ID="chkCoE_Program_Available" CssClass="blockInputClass" /></label>

                                                    </div>
                                                    <div class="form-group" id="divCOEProgramDetails" style="display: none">
                                                        <label for="exampleAccount">COE Program Details</label>
                                                        <asp:TextBox ID="txtCoE_Program_Details" CssClass="form-control blockInputClass" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">
                                                            CSR Activities Available
                                                            <asp:CheckBox runat="server" ID="chkCSR_Activities_Available" CssClass="blockInputClass" /></label>
                                                    </div>
                                                    <div class="form-group" id="divCSRActivity" style="display: none">
                                                        <label for="exampleAccount">CSR Activity Details</label>
                                                        <asp:TextBox ID="txtCSR_Activity_Details" CssClass="form-control blockInputClass" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">
                                                            Staff Common Room Available
                                                            <asp:CheckBox runat="server" ID="chkStaff_Common_Room_Available" CssClass="blockInputClass" /></label>
                                                        <div class="input-group">
                                                            <label class="input-group-btn">
                                                                <span class="custom-file-input btn" id="spanStaffCommonRoomAvailable" style="display: none">
                                                                    <asp:FileUpload ID="StaffCommonRoomAvailableUploader" runat="server" Style="display: none" accept=".pdf" />
                                                                    <asp:LinkButton ID="StaffCommonRoomUploadButton" OnClick="StaffCommonRoomUploadButton_Click" CssClass="btn btn-yellow" runat="server">Upload</asp:LinkButton>
                                                                    <asp:LinkButton ID="StaffCommonRoomAvailableDownloadButton" OnClick="StaffCommonRoomAvailableDownloadButton_Click" CssClass="btn btn-link" runat="server">Download File</asp:LinkButton>
                                                                </span>
                                                            </label>
                                                        </div>
                                                    </div>
                                                    <div class="form-group" id="divStaffCommonRoom" style="display: none">
                                                        <label for="exampleAccount">Staff Common Room Details</label>
                                                        <asp:TextBox ID="txtStaff_Common_Room_Details" CssClass="form-control blockInputClass" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">
                                                            Girls Common Room Available
                                                            <asp:CheckBox runat="server" ID="chkGirls_Common_Room_Available" CssClass="blockInputClass" /></label>
                                                        <div class="input-group">
                                                            <label class="input-group-btn">
                                                                <span class="custom-file-input btn" id="spanGirlsCommonRoomAvailable" style="display: none">
                                                                    <asp:FileUpload ID="girlsCommonRoomAvailableUploader" runat="server" Style="display: none" accept=".pdf" />
                                                                    <asp:LinkButton ID="girlsCommonRoomUploadButton" OnClick="girlsCommonRoomUploadButton_Click" CssClass="btn btn-yellow" runat="server">Upload</asp:LinkButton>
                                                                    <asp:LinkButton ID="girlsCommonRoomAvailableDownloadButton" OnClick="girlsCommonRoomAvailableDownloadButton_Click" CssClass="btn btn-link" runat="server">Download File</asp:LinkButton>
                                                                </span>
                                                            </label>
                                                        </div>
                                                    </div>
                                                    <div class="form-group" id="divgirlsCommonRoomAvailable" style="display: none">
                                                        <label for="exampleAccount">Girls Common Room Details</label>
                                                        <asp:TextBox ID="txtGirls_Common_Room_Details" CssClass="form-control blockInputClass" runat="server"></asp:TextBox>
                                                    </div>

                                                    <div class="form-group">
                                                        <label for="exampleAccount">
                                                            Boys Common Room Available
                                                            <asp:CheckBox runat="server" ID="chkBoys_Common_Room_Available" CssClass="blockInputClass" /></label>
                                                        <div class="input-group">
                                                            <label class="input-group-btn">
                                                                <span class="custom-file-input btn" id="spanboysCommonRoomAvailable" style="display: none">
                                                                    <asp:FileUpload ID="Boys_Common_RoomUploader" runat="server" Style="display: none" accept=".pdf" />
                                                                    <asp:LinkButton ID="BoysCommonRoomUploadButton" OnClick="BoysCommonRoomUploadButton_Click" CssClass="btn btn-yellow" runat="server">Upload</asp:LinkButton>
                                                                    <asp:LinkButton ID="Boys_Common_RoomDownloadButton" OnClick="Boys_Common_RoomDownloadButton_Click" CssClass="btn btn-link" runat="server">Download File</asp:LinkButton>
                                                                </span>
                                                            </label>
                                                        </div>
                                                    </div>
                                                    <div class="form-group" id="divboysCommonRoomAvailable" style="display: none">
                                                        <label for="exampleAccount">Boys Common Room Details</label>
                                                        <asp:TextBox ID="txtBoys_Common_Room_Details" CssClass="form-control blockInputClass" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">
                                                            Roof Top Solar Panel Available
                                                            <asp:CheckBox runat="server" ID="chkRoof_Top_Solar_Panel_Available" CssClass="blockInputClass" /></label>

                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">
                                                            Rain Water Harvesting Available
                                                            <asp:CheckBox runat="server" ID="chkRain_Water_Harvesting_Avail" CssClass="blockInputClass" /></label>

                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">
                                                            Sewage Treatment Plant Available
                                                            <asp:CheckBox runat="server" ID="chkSewage_Treatment_Plant_Avail" CssClass="blockInputClass" /></label>

                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">
                                                            Internet Connection Available
                                                            <asp:CheckBox runat="server" ID="chkInternet_Connection_Available" CssClass="blockInputClass" /></label>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">
                                                            Digital Library Available
                                                            <asp:CheckBox runat="server" ID="chkDigitalLibraryAvailable" CssClass="blockInputClass" /></label>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">
                                                            Canteen/Cafeteria for Staff Avail.
                                                            <asp:CheckBox runat="server" ID="chkCanteen_Caf_for_Staffs_Avail" CssClass="blockInputClass" /></label>
                                                        <div class="input-group">
                                                            <label class="input-group-btn">
                                                                <span class="custom-file-input btn" id="spanCanteen_Caf_for_Staffs_Avail" style="display: none">
                                                                    <asp:FileUpload ID="Canteen_CafUploader" runat="server" Style="display: none" accept=".pdf" />
                                                                    <asp:LinkButton ID="Canteen_CafUploadButton" OnClick="Canteen_CafUploadButton_Click" CssClass="btn btn-yellow" runat="server">Upload</asp:LinkButton>
                                                                    <asp:LinkButton ID="Canteen_CafDownloadButton" OnClick="Canteen_CafDownloadButton_Click" CssClass="btn btn-link" runat="server">Download File</asp:LinkButton>
                                                                </span>
                                                            </label>
                                                        </div>
                                                    </div>
                                                    <div class="form-group" id="divCanteenCapacity" style="display: none">
                                                        <label for="exampleAccount">Canteen/Cafeteria Capacity</label>
                                                        <asp:TextBox ID="txtCanteen_Cafeteria_Capacity" onkeypress="return isDecimalNumberKey(event)" CssClass="form-control blockInputClass" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <asp:HiddenField ID="hdnKey" runat="server" />
                                </div>
                            </div>

                        </div>
                        <div class="col-lg-3 col-md-2">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    <script language="Javascript">
        function isDecimalNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

        //function fieldAvailableChanged() {
        if ($("#<%= chkFieldAvailable.ClientID %>").is(":checked")) {
            $("#fieldAvailableSpan").show();
            $("#divFieldArea").show();
        }
        else {
            $("#fieldAvailableSpan").hide();
            $("#divFieldArea").hide();
        }
        //}
        //function sportsCourtChanged() {
        if ($("#<%= chkSportCourt.ClientID %>").is(":checked")) {
            $("#sportsCourtSpan").show();
            $("#divSportCourt").show();
        }
        else {
            $("#sportsCourtSpan").hide();
            $("#divSportCourt").hide();
        }
        //}

        //function fieldGalleryChanged() {
        if ($("#<%= chkFieldGalleryAvailable.ClientID %>").is(":checked")) {
            $("#fieldGallerySpan").show();
        }
        else {
            $("#fieldGallerySpan").hide();
        }
        //}
        //function conferenceRoomChanged() {
        if ($("#<%= chkConferenceRoomAvailable.ClientID %>").is(":checked")) {
            $("#conferenceRoomSpan").show();
        }
        else {
            $("#conferenceRoomSpan").hide();
        }
        //}
        //function videoConferenceRoomChanged() {
        if ($("#<%= chkVideo_Conference_Room_Avail.ClientID %>").is(":checked")) {
            $("#spanVideoConferenceRoom").show();
            $("#divVideoConferenceRoom").show();
            $("#divVideoConferenceRoomCapacity").show();
            $("#divVideoConferenceRoomLocation").show();
        }
        else {
            $("#spanVideoConferenceRoom").hide();
            $("#divVideoConferenceRoom").hide();
            $("#divVideoConferenceRoomCapacity").hide();
            $("#divVideoConferenceRoomLocation").hide();
        }
        //}

        //function libraryAvailableChanged() {
        if ($("#<%= chkLibrary_Available.ClientID %>").is(":checked")) {
            $("#spanLibraryAvailable").show();
        }
        else {
            $("#spanLibraryAvailable").hide();
        }
        //}
        //function centralLibraryAvailableChanged() {
        if ($("#<%= chkCentralLibraryAvailable.ClientID %>").is(":checked")) {
            $("#spanCentralLibraryAvailable").show();
        }
        else {
            $("#spanCentralLibraryAvailable").hide();
        }
        //}
        //function canteenCafeteriaChanged() {
        if ($("#<%= chkCanteen_Caf_for_Staffs_Avail.ClientID %>").is(":checked")) {
            $("#spanCanteen_Caf_for_Staffs_Avail").show();
            $("#divCanteenCapacity").show();
        }
        else {
            $("#spanCanteen_Caf_for_Staffs_Avail ").hide();
            $("#divCanteenCapacity").hide();
        }
        //}
        //function dispensaryAvailableChanged() {
        if ($("#<%= chkDispensary_Available.ClientID %>").is(":checked")) {
            $("#spanDispensaryAvailable").show();
        }
        else {
            $("#spanDispensaryAvailable  ").hide();
        }
        //}
        //function COEProgramAvailableChanged() {
        if ($("#<%= chkCoE_Program_Available.ClientID %>").is(":checked")) {
            $("#divCOEProgramDetails").show();
        }
        else {
            $("#divCOEProgramDetails").hide();
        }
        //}
        //function CSRActivitiesChanged() {
        if ($("#<%= chkCSR_Activities_Available.ClientID %>").is(":checked")) {
            $("#divCSRActivity").show();
        }
        else {
            $("#divCSRActivity").hide();
        }
        //}
        //function staffCommonRoomAvailableChanged() {
        if ($("#<%= chkStaff_Common_Room_Available.ClientID %>").is(":checked")) {
            $("#spanStaffCommonRoomAvailable").show();
            $("#divStaffCommonRoom").show();
        }
        else {
            $("#spanStaffCommonRoomAvailable").hide();
            $("#divStaffCommonRoom").hide();
        }
        //}
        //function girlsCommonRoomAvailableChanged() {
        if ($("#<%= chkGirls_Common_Room_Available.ClientID %>").is(":checked")) {
            $("#spanGirlsCommonRoomAvailable").show();
            $("#divgirlsCommonRoomAvailable").show();
        }
        else {
            $("#spanGirlsCommonRoomAvailable").hide();
            $("#divgirlsCommonRoomAvailable").hide();
        }
        //}
        //function boysCommonRoomAvailableChanged() {
        if ($("#<%= chkBoys_Common_Room_Available.ClientID %>").is(":checked")) {
            $("#spanboysCommonRoomAvailable").show();
            $("#divboysCommonRoomAvailable").show();
        }
        else {
            $("#spanboysCommonRoomAvailable").hide();
            $("#divboysCommonRoomAvailable").hide();
        }
        //}
    </script>
</asp:Content>
