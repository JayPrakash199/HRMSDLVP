using BotDetect.C5;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServices;

namespace HRMS.Dto
{
    public class TimetableModel
    {
        //private static List<TimetableModel> obj = null;
        //public static List<TimetableModel> objTimetable 
        //{
        //    get { return obj; }   // get method
        //    set { obj  = ODataServices.GetTimeTableData(Session["SessionCompanyName"] as string); ; }  // set method 
        //}
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string RoomNo{ get; set; }
        public string Section { get; set; }
        public string SubjectType { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string Semester { get; set; }
    }
}