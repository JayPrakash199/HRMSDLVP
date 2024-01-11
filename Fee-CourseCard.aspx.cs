using BotDetect;
using HRMSODATA;
using Microsoft.Ajax.Utilities;
using Microsoft.OData.Client;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class Fee_CourseCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Session["SessionCompanyName"] as string))
                {
                    string message = string.Format("Message: {0}\\n\\n", "Please select a company");
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
                    Response.Redirect("Default.aspx");
                }
                var studentType = ODataServices.GetFeeClassificationList(Session["SessionCompanyName"] as string);
                ddlFeeClassification.DataSource = studentType;
                ddlFeeClassification.DataTextField = "Description";
                ddlFeeClassification.DataValueField = "Code";
                ddlFeeClassification.DataBind();
                ddlFeeClassification.Items.Insert(0, new ListItem("Select Fee Classification", "0"));


                var semisterList = ODataServices.GetSemisterList(Session["SessionCompanyName"] as string);
                ddlSemester.DataSource = semisterList;
                ddlSemester.DataTextField = "Description";
                ddlSemester.DataValueField = "Code";
                ddlSemester.DataBind();
                ddlSemester.Items.Insert(0, new ListItem("Select Semister", "0"));


                var coursesList = ODataServices.GetCourseList(Session["SessionCompanyName"] as string);
                var Filteredcourselist = new List<CommonList>();

                foreach (var course in coursesList)
                {
                    Filteredcourselist.Add(new HRMS.CommonList { No = course.Code, Name = course.Code + "_" + course.Description });
                }


                ddlProgramCode.DataSource = Filteredcourselist;
                ddlProgramCode.DataTextField = "Name";
                ddlProgramCode.DataValueField = "No";
                ddlProgramCode.DataBind();
                ddlProgramCode.Items.Insert(0, new ListItem("Select Course Code", "0"));



                var glList = ODataServices.GetGraduationList(Session["SessionCompanyName"] as string);
                ddlGraduation.DataSource = glList;
                ddlGraduation.DataTextField = "Description";
                ddlGraduation.DataValueField = "Code";
                ddlGraduation.DataBind();
                ddlGraduation.Items.Insert(0, new ListItem("Select Graduation", "0"));


                var number = Request.QueryString["No"];
                if (!string.IsNullOrEmpty(number))
                {
                    var courseFeeHeader = ODataServices.GetCourseFeeHeaderList(Session["SessionCompanyName"] as string)
                        .Where(x => String.Equals(x.No, number, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                    if (courseFeeHeader != null)
                    {
                        txtNo.Text = courseFeeHeader.No;
                        if (!string.IsNullOrEmpty(courseFeeHeader.Program)) ddlGraduation.Items.FindByValue(courseFeeHeader.Program).Selected = true;
                        if (!string.IsNullOrEmpty(courseFeeHeader.Program_Code)) ddlProgramCode.Items.FindByValue(courseFeeHeader.Program_Code).Selected = true;
                        txtProgramName.Text = courseFeeHeader.Program_Name;
                        ddlYear.SelectedValue = courseFeeHeader.Year;
                        txtAdmittedYear.Text = courseFeeHeader.Admitted_Year;
                        txtAcademicYear.Text = courseFeeHeader.Academic_Year;
                        ddlFeeClassification.SelectedValue = courseFeeHeader.Fee_Classification;
                        txtInstituteCode.Text = courseFeeHeader.Global_Dimension_1_Code;
                        txtDepartmentCode.Text = courseFeeHeader.Global_Dimension_2_Code;
                        txtTotalAmount.Text = Convert.ToString(courseFeeHeader.Total_Amount);
                        if (!string.IsNullOrEmpty(courseFeeHeader.Semester)) ddlSemester.Items.FindByValue(courseFeeHeader.Semester).Selected = true;
                        ddlStatus.Items.FindByText(courseFeeHeader.Status).Selected = true;
                    }
                }
                var feeLine = ODataServices.GetCourseFeeLines(Session["SessionCompanyName"] as string).Where(x => String.Equals(x.Document_No, number, StringComparison.OrdinalIgnoreCase));
                if (feeLine != null)
                {
                    CourseFeeLineListView.DataSource = feeLine;
                    CourseFeeLineListView.DataBind();
                }
            }
        }

        protected void ddlProgramCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(ddlProgramCode.SelectedValue)))
            {
                int index = ddlProgramCode.SelectedItem.Text.IndexOf('_');
                if (index > -1)
                {
                    txtProgramName.Text = ddlProgramCode.SelectedItem.Text.Split('_')[1];
                }
            }
        }
    }
}