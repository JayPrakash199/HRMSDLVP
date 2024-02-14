using HRMS.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using WebServices;

namespace MIT_Latest
{
    /// <summary>
    /// Summary description for JsonResponse
    /// </summary>
    public class JsonResponse : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            //Added by Ranjani on 11/03/2021 to generate time table
            string academicYear = context.Request.QueryString["nYear"];

            List<int> idList = new List<int>();

            List<CalendarEvent> tasksList = new List<CalendarEvent>();

            if (string.IsNullOrEmpty(academicYear))
            {
                //Generate JSON serializable event


                foreach (HRMSODATA.TimeTable cevent in ODataServices.GetTimeTableData(context.Session["SessionCompanyName"] as string))
                {
                    DateTime Startdate = new DateTime(Convert.ToInt32(cevent.Date.ToString().Split('-')[0]),
                        Convert.ToInt32(cevent.Date.ToString().Split('-')[1]),
                        Convert.ToInt32(cevent.Date.ToString().Split('-')[2]),
                        Convert.ToInt32(cevent.Start_Time.ToString().Split(':')[0]),
                        Convert.ToInt32(cevent.Start_Time.ToString().Split(':')[1]),
                        Convert.ToInt32(cevent.Start_Time.ToString().Split(':')[2]));
                    DateTime Enddate = new DateTime(Convert.ToInt32(cevent.Date.ToString().Split('-')[0]),
                        Convert.ToInt32(cevent.Date.ToString().Split('-')[1]),
                        Convert.ToInt32(cevent.Date.ToString().Split('-')[2]),
                        Convert.ToInt32(cevent.End_Time.ToString().Split(':')[0]),
                        Convert.ToInt32(cevent.End_Time.ToString().Split(':')[1]),
                        Convert.ToInt32(cevent.End_Time.ToString().Split(':')[2]));

                    tasksList.Add(new CalendarEvent
                    {
                        id = cevent.S_No,
                        title = string.Format("Course:{0}, Subject:{1}, Section:{2}, Semester:{3}, Room No:{4}, Subject Type:{5}",
                        cevent.Course_Name, cevent.Subject_Name, cevent.Section, cevent.Semester, cevent.Room_No, cevent.Subject_Class),
                        start = String.Format("{0:s}", Startdate),
                        end = String.Format("{0:s}", Enddate),
                        description = String.Format("{0},<br /><b>Room No:</b> {1},<br /> Subject Type:{2}", cevent.Subject_Name, cevent.Room_No, cevent.Subject_Class),
                        allDay = false
                    });
                    idList.Add(cevent.S_No);
                }
            }
            //else
            //{

            //    foreach (ComDL.CalendarEvent cevent in EventDAOComDL.getEventsForGenerateTT(start, end, Convert.ToString(HttpContext.Current.Session["uid"]), Convert.ToString(HttpContext.Current.Session["UserGroup"]), "", course, academicYear, section, semester, Convert.ToString(HttpContext.Current.Session["GlobalDimension1Code"]), drive, Convert.ToString(HttpContext.Current.Session["uid"]), Convert.ToString(HttpContext.Current.Session["AllTimeTable"])))
            //    {
            //        tasksList.Add(new ImproperCalendarEvent
            //        {
            //            id = cevent.id,
            //            title = cevent.title,
            //            start = String.Format("{0:s}", cevent.start),
            //            end = String.Format("{0:s}", cevent.end),
            //            description = cevent.description,
            //            allDay = cevent.allDay,
            //            className = cevent.className
            //        });
            //        idList.Add(cevent.id);
            //    }
            //}

            context.Session["idList"] = idList;

            //Serialize events to string
            System.Web.Script.Serialization.JavaScriptSerializer oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string sJSON = oSerializer.Serialize(tasksList);

            //Write JSON to response object
            context.Response.Write(sJSON);
        }


        //public void ProcessRequest(HttpContext context)
        //{
        //    context.Response.ContentType = "text/plain";
        //    DateTime start = Convert.ToDateTime(context.Request.QueryString["nstart"]);
        //    DateTime end = Convert.ToDateTime(context.Request.QueryString["nend"]);

        //    //DateTime start = Convert.ToDateTime("2017-04-09 08:0:00.000");
        //    //DateTime end = Convert.ToDateTime("2017-04-16 18:00:00.000");

        //    List<int> idList = new List<int>();

        //    List<ImproperCalendarEvent> tasksList = new List<ImproperCalendarEvent>();

        //    //Generate JSON serializable events


        //    foreach (ComDL.CalendarEvent cevent in EventDAOComDL.getEvents(start, end, Convert.ToString(HttpContext.Current.Session["uid"]), Convert.ToString(HttpContext.Current.Session["UserGroup"]), Convert.ToString(HttpContext.Current.Session["Batch"]), Convert.ToString(HttpContext.Current.Session["CourseCode"]), Convert.ToString(HttpContext.Current.Session["AcademicYear"]), Convert.ToString(HttpContext.Current.Session["Section"]), Convert.ToString(HttpContext.Current.Session["Semester"]), Convert.ToString(HttpContext.Current.Session["GlobalDimension1Code"]), Convert.ToString(HttpContext.Current.Session["uid"]), Convert.ToString(HttpContext.Current.Session["AllTimeTable"])))
        //    {
        //        tasksList.Add(new ImproperCalendarEvent
        //        {
        //            id = cevent.id,
        //            title = cevent.title,
        //            start = String.Format("{0:s}", cevent.start),
        //            end = String.Format("{0:s}", cevent.end),
        //            description = cevent.description,
        //            allDay = cevent.allDay,
        //            className = cevent.className
        //        });
        //        idList.Add(cevent.id);
        //    }

        //    context.Session["idList"] = idList;

        //    //Serialize events to string
        //    System.Web.Script.Serialization.JavaScriptSerializer oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        //    string sJSON = oSerializer.Serialize(tasksList);

        //    //Write JSON to response object
        //    context.Response.Write(sJSON);
        //}

        public bool IsReusable
        {
            get { return false; }
        }
    }
}