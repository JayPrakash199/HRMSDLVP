<%@ Page Title="" Language="C#" MasterPageFile="~/SLCM.Master" AutoEventWireup="true" CodeBehind="Timetable.aspx.cs" Inherits="HRMS.Timetable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
        .summary-box {
            height: auto;
            text-align: center;
            box-shadow: 0 3px 6px rgba(0, 0, 0, 0.16), 0 3px 6px rgba(0, 0, 0, 0.23);
            border: 1px solid;
        }

        table thead tr th, .table > tbody > tr > th {
            border-top: none !important;
        }

        .container.box {
            margin-bottom: 5%;
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
     .cssAttendance {
            background-color: #3d9400 !important;
        }

        .box-attandance {
            width: 16px;
            height: 16px;
            border-radius: 3px;
            display: inline-block;
            background: #3d9400;
            position: relative;
            top: 3px;
            margin-right: 6px;
        }

        .cssReschedule {
            background-color: #820c0c !important;
        }

        .cssInterval {
            background-color: #148f77 !important;
        }

        .box-reschedule {
            width: 16px;
            height: 16px;
            border-radius: 3px;
            display: inline-block;
            background: #820c0c;
            position: relative;
            top: 3px;
            margin-right: 6px;
        }

        .right_col_bg .right_col_content {
            background-color: rgba(255, 255, 255, 0.92);
            color: #000;
            padding: 15px;
            min-height: 200px;
        }
        /*Fullcalendar Custom Css Start!*/
        #calendar .fc-toolbar .fc-left {
            float: left;
            width: 30%;
        }

        #calendar .fc-state-down, #calendar .fc-state-active {
            box-shadow: none !important;
            outline: 0 none;
            background-color: rgb(245, 130, 32) !important;
            border-color: rgb(245, 130, 32) !important;
            color: #FFFFFF !important;
        }

        #calendar .fc-head {
            background: #f5f5f5 !important;
        }

        #calendar .fc-day-header.fc-widget-header {
            padding: 5px !important;
        }

        #calendar .fc-toolbar h2 {
            font-size: 21px !important;
        }

        #calendar .fc-divider.fc-widget-header {
            background: #eee;
            margin: 0px;
            padding: 0px;
        }

        .fc-scroller.fc-time-grid-container {
            height: 70em !important;
            /*height: 51.8em !important;*/
            overflow-y: auto !important;
        }

        button:focus {
            outline: 0;
        }

        .fc-time-grid .fc-slats td {
            height: 3.4em !important;
            /*height: 2.5em !important;*/
            border-bottom: 0;
        }

        @media screen and (max-width: 768px) and (min-width: 320px) {
            .fc-time-grid-event .fc-time, .fc-time-grid-event .fc-title {
                font-size: 9px !important;
            }
        }

        /*full calendor css*/
        #calendar .fc-event {
            background-color: #004b83;
            border: 1px solid rgb(255, 255, 255) !important;
            padding: 2px;
            cursor: pointer;
        }

            #calendar .fc-event:nth-child(2n+1) {
                background: #735656;
                border: 1px solid rgb(255, 255, 255) !important;
            }

        .select-month-cal {
            max-width: 65px;
            width: 100%;
            padding: 3px 0;
            border-radius: 3px;
            margin-right: 2px;
            display: inline-block;
        }

        .select-year-cal {
            max-width: 65px;
            width: 100%;
            padding: 3px 0;
            border-radius: 3px;
            margin-right: 2px;
            display: inline-block;
        }

        .fc button {
            box-sizing: border-box;
            margin: 0;
            height: 2.1em;
            padding: 0 .6em;
            font-size: 1em;
            white-space: nowrap;
            cursor: pointer;
            text-transform: capitalize;
        }

        @media screen and (max-width:991px) and (min-width:768px) {
            .fc-time-grid-event .fc-time, .fc-time-grid-event .fc-title {
                font-size: 11px;
            }
        }

        @media screen and (max-width:767px) {
            #calendar .fc-view-container {
                overflow-x: auto !important;
            }

            .fc-view-container .fc-view.fc-agendaWeek-view.fc-agenda-view table {
                min-width: 900px !important;
            }

            .fc-time-grid-event .fc-time, .fc-time-grid-event .fc-title {
                font-size: 11px;
            }
        }

        @media screen and (min-width:768px) {
            .fc-toolbar .fc-right {
                width: 33%;
            }


            .fc-right .fc-button-group {
                float: right !important;
            }
        }

        @media screen and (max-width:532px) and (min-width:481px) {
            #calendar .fc-toolbar .fc-left {
                float: left;
                width: 60%;
            }
        }

        @media screen and (max-width:480px) {
            #calendar .fc-toolbar .fc-left {
                float: left;
                width: 60%;
            }

            #calendar .fc-state-down, #calendar .fc-state-active {
                text-shadow: none;
            }
        }

        .ui-widget.ui-widget-content {
            border: 1px solid #ffcc00;
        }

        .ui-widget-header {
            border: none;
            background: none;
        }

        .ui-draggable .ui-dialog-titlebar {
            border: none !important;
            background: rgba(90, 89, 84, 0.89) !important;
            border-top: 5px solid #ffcc00 !important;
        }

        .ui-corner-all, .ui-corner-bottom, .ui-corner-right, .ui-corner-br {
            border-bottom-right-radius: 0px !important;
        }

        .ui-corner-all, .ui-corner-bottom, .ui-corner-left, .ui-corner-bl {
            border-bottom-left-radius: 0px !important;
        }

        .ui-corner-all, .ui-corner-top, .ui-corner-right, .ui-corner-tr {
            border-top-right-radius: 0px !important;
        }

        .ui-corner-all, .ui-corner-top, .ui-corner-left, .ui-corner-tl {
            border-top-left-radius: 0px !important;
        }

        .ui-widget-content {
            background: #fff !important;
            color: #362b36;
            padding: 0px !important;
        }

        .ui-dialog .ui-dialog-content {
            padding: .5em 1em !important;
            text-align: center;
        }

            .ui-dialog .ui-dialog-content label {
                display: inline-block;
                height: auto;
            }

        .ui-widget.ui-widget-content {
            border: transparent !important;
            box-shadow: 0px 4px 16px 0px #000;
        }

        .ui-dialog .ui-dialog-title {
            color: #fff;
            font-weight: 300 !important;
        }

        .ui-dialog .ui-dialog-titlebar-close {
            background: none !important;
            border: none !important;
        }

        .ui-button .ui-icon {
            background-image: none !important;
            position: absolute;
            right: 32px;
            top: 32px;
            width: 32px;
            height: 32px;
            opacity: 1;
        }

            .ui-button .ui-icon:hover {
                opacity: 0.8;
            }

            .ui-button .ui-icon:before, .ui-button .ui-icon:after {
                position: absolute;
                left: 7px;
                content: ' ';
                height: 18px;
                width: 2px;
                background-color: #fff !important;
            }

            .ui-button .ui-icon:before {
                transform: rotate(45deg);
            }

            .ui-button .ui-icon:after {
                transform: rotate(-45deg);
            }
        /*  Custom Week and Day Date Css in Header    */
        .fc-day-header.fc-widget-header > div > div {
            padding: 0 5px;
            text-transform: capitalize !important;
        }
    </style>

    <link href="assets/vendor/plugins/jquery-ui/jquery-ui.min.css" rel="stylesheet" />
    <link href="assets/vendor/plugins/FullCalendar/jquery.qtip.min.css" rel="stylesheet" />
    <link href="assets/vendor/plugins/FullCalendar/fullcalendar.css" rel="stylesheet" />
    <div class="tab-pane active">
        <div class="right_col_bg">
            <div class="right_col_content border-box">
                <div class="row">
                    <div class="col-sm-12">
                        <asp:HiddenField ID="hdnUserGroup" runat="server" />
                        <asp:HiddenField ID="hdnChkAll" runat="server" />
                        <div class="table-responsive1">
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-sm-3 form-group">
                                        <select class="form-control" id='filterCalendarMonth'>
                                            <option value=''>-- Select Month --</option>
                                            <option value='1'>January</option>
                                            <option value='2'>February</option>
                                            <option value='3'>March</option>
                                            <option value='4'>April</option>
                                            <option value='5'>May</option>
                                            <option value='6'>June</option>
                                            <option value='7'>July</option>
                                            <option value='8'>August</option>
                                            <option value='9'>September</option>
                                            <option value='10'>October</option>
                                            <option value='11'>November</option>
                                            <option value='12'>December</option>
                                        </select>
                                    </div>
                                    <div class="col-sm-3">
                                        <select class="form-control" id="filterCalendarYear">
                                            <option value=''>-- Select Year --</option>
                                        </select>
                                    </div>
                                    
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                            <div id="calendar"></div>
                        </div>
                        <div id="updatedialog" name="updatedialog" style="display: none;">
                            <table class="style1" style="display: none;">
                                <tr>
                                    <td class="alignRight">Name:</td>
                                    <td class="alignLeft">
                                        <input id="eventName" type="text" size="33" /><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="alignRight">Description:</td>
                                    <td class="alignLeft">
                                        <textarea id="eventDesc" cols="30" rows="3"></textarea></td>
                                </tr>
                                <tr>
                                    <td class="alignRight">Start:</td>
                                    <td class="alignLeft">
                                        <span id="eventStart"></span></td>
                                </tr>
                                <tr>
                                    <td class="alignRight">End: </td>
                                    <td class="alignLeft">
                                        <span id="eventEnd"></span>
                                        <input type="hidden" id="eventId" /></td>
                                </tr>
                            </table>
                            <button style="" id="btnAttendance" type="button" class="btn btn-success mt-10" onclick="return funRedirectForAttendance();">Attendance</button>
                            <button id="btnCancel" disabled="disabled" type="button" class="btn btn-danger mt-10" onclick="return CancelAlert();">Cancel Class</button> 
                            <button style="display: none;" disabled="disabled" id="btnResedule" type="button" class="btn btn-success mt-10" onclick="return Resedule();">Reschedule</button> 
                            <label style="display: none;" id="lblMsgForAttendance" class="alert alert-success mt-10"><b>Attendance is already marked</b></label>
                            <label style="display: none;" id="lblCancelled" class="alert alert-danger mt-10"><b>Attendance has been cancelled</b></label>

                            <button style="display: none;" id="btnEditAttendance" type="button" class="btn btn-success mt-10" onclick="return EditAttendance();">Edit Attendance</button>
                        </div>

                        <div id="addDialog"  style="font: 70% 'Trebuchet MS', sans-serif; margin: 10px 0; display: none;" title="Create Time Table">

                            <div>
                                <div class="">
                                    <div class="col-sm-12 text-center">
                                        <label>Start Date :</label>
                                        <span id="startDate" style="font-size: 16px;"></span>
                                    </div>
                                </div>
                                <div class="clearfix">
                                    <div class="col-xs-6">
                                        <label>Start Time :</label>
                                        <span id="startTime" style="font-size: 14px;"></span>
                                    </div>
                                    <div class="col-xs-6">
                                        <label>End Time :</label>
                                        <span id="endTime" style="font-size: 14px;"></span>
                                    </div>
                                </div>
                               
                            </div>

                            <table class="style1" style="display: none;">
                                <tr>
                                    <td class="alignRight">Name:</td>
                                    <td class="alignLeft">
                                        <input id="addEventName" type="text" size="33" /><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="alignRight">Description:</td>
                                    <td class="alignLeft">

                                        <textarea id="addEventDesc" cols="30" rows="3"></textarea></td>
                                </tr>
                                <tr>
                                    <td class="alignRight">Start:</td>
                                    <td class="alignLeft">
                                        <span id="addEventStartDate"></span></td>
                                </tr>
                                <tr>
                                    <td class="alignRight">End:</td>
                                    <td class="alignLeft">
                                        <span id="addEventEndDate"></span></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="assets/vendor/plugins/jquery-ui/moment.min.js"></script>
    <script src="assets/vendor/plugins/jquery-ui/jquery-ui.min.js"></script>
    <script src="assets/vendor/plugins/FullCalendar/fullcalendar.js"></script>
    <script src="assets/vendor/plugins/FullCalendar/jquery.qtip.min.js"></script>
    <script src="assets/js/calendarscript.js"></script>
    <script>
        $(function () {
            var d = new Date();
            var n = d.getFullYear();
            var startCalYear = n + 7;
            var endCalYear = n - 7;
            var calendarOptions = "";
            for (endCalYear; endCalYear < startCalYear; endCalYear++) {
                calendarOptions += "<option value='" + endCalYear + "'>" + endCalYear + "</option>";
            }
            $("#filterCalendarYear").append(calendarOptions);
            var d = new Date();
            var vCurrentYear = d.getFullYear();
            $("#filterCalendarYear").val(vCurrentYear);
            var vcurrentMonth = d.getMonth();
            vcurrentMonth = vcurrentMonth + 1;
            $("#filterCalendarMonth").val(vcurrentMonth);
        });

    </script>
</asp:Content>
