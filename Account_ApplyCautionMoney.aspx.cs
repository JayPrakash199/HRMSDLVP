using HRMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class Account_ApplyCautionMoney : System.Web.UI.Page
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
                var studentList = ODataServices.GetStudentList(Session["SessionCompanyName"] as string);
                var finalStudentList = new List<CommonList>();
                foreach (var student in studentList)
                {
                    finalStudentList.Add(new HRMS.CommonList { No = student.No, Name = student.No + "_" + student.Student_Name });
                }
                ddlStudentNo.DataSource = finalStudentList;
                ddlStudentNo.DataTextField = "Name";
                ddlStudentNo.DataValueField = "No";
                ddlStudentNo.DataBind();
                ddlStudentNo.Items.Insert(0, new ListItem("Select Student", "0"));
                BindFianacialYear();
            }
        }
        public void BindFianacialYear()
        {
            var FyList = ODataServices.GetFinancialYearList(Session["SessionCompanyName"] as string);

            ddlAcademicYear.DataSource = FyList;
            ddlAcademicYear.DataTextField = "Financial_Code";
            ddlAcademicYear.DataValueField = "Financial_Code";
            ddlAcademicYear.DataBind();
            ddlAcademicYear.Items.Insert(0, new ListItem("Select Year", "0"));
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!((Fee)this.Master).IsPageRefresh)
            {
                List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();

                if (lstUserRole != null)
                {

                    var role = lstUserRole.FirstOrDefault(x =>
                        string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                        string.Equals(x.Page_Name.Trim(), "Apply Caution Money", StringComparison.OrdinalIgnoreCase) &&
                        string.Equals(x.Module_Name.Trim(), "Accounts", StringComparison.OrdinalIgnoreCase));


                    if (role == null || Convert.ToBoolean(role.Insert))
                    {

                        try
                        {
                            SOAPServices.ApplyCautionMoney(ddlStudentNo.SelectedValue, ddlAcademicYear.SelectedItem.Text, Session["SessionCompanyName"] as string);
                            ClearControl();
                            Alert.ShowAlert(this, "s", "Applied successfully.");
                        }
                        catch (Exception ex)
                        {
                            Alert.ShowAlert(this, "e", "Exception occured:" + ex.Message);
                        }
                    }
                    else
                    {
                        Alert.ShowAlert(this, "W", "You do not have permission to apply to the content. Kindly contact the system administrator.");

                    }
                }
            }
            else
            {
                ClearControl();
            }
        }

        private void ClearControl()
        {
            ddlAcademicYear.ClearSelection();
            ddlAcademicYear.Items.FindByValue("0").Selected = true;

            ddlStudentNo.ClearSelection();
            ddlStudentNo.Items.FindByValue("0").Selected = true;


        }
    }

    public class CommonList
    {
        public string No { get; set; }
        public string Name { get; set; }
    }
}