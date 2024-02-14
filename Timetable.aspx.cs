using HRMS.Dto;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class Timetable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //IList<HRMSODATA.TimeTable> lstTimeTable = ODataServices.GetTimeTableData(Session["SessionCompanyName"] as string);
            //lstTimeTable = lstTimeTable.Where(x => x.Date.ToString() == "2024-01-01").ToList();
            //List<TimetableModel> objTimetable = new List<TimetableModel>();
            //TimetableModel.objTimetable= lstTimeTable;
           
        }
    }
}