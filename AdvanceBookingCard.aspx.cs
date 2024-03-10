//using HRMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices;
using WebServices.BookIssueCardReference;

namespace HRMS
{
    public partial class AdvanceBookingCard : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Session["SessionCompanyName"] as string))
                {
                    string message = string.Format("Message: {0}\\n\\n", "Please select company");
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
                    Response.Redirect("Default.aspx");
                }
                LoadBookNoDropDown(Session["SessionCompanyName"] as string);
            }
        }
        private void LoadUserTypeDropDown()
        {
            ddlType.DataSource = Enum.GetNames(typeof(User_Type));
            ddlType.DataBind();
        }
        private void LoadBookNoDropDown(string companyName)
        {
            IList<HRMSODATA.BookList> lstBookList = ODataServices.GetBookList(companyName);
            var lstbook = lstBookList.Select(x => new
            {
                No = x.No,
                Book_Name = x.Book_Name
            }).ToList();
            if (lstbook != null && lstbook.Count > 0)
            {
                ddlBookNo.DataSource = lstbook;
                ddlBookNo.DataTextField = "No";
                ddlBookNo.DataValueField = "Book_Name";
                ddlBookNo.DataBind();
                ddlBookNo.Items.Insert(0, new ListItem("Select Book No", "0"));

            }
        }

        private void LoadStudentNoDropDown()
        {
            IList<HRMSODATA.StudentList> lst = ODataServices.GetStudentList(Session["SessionCompanyName"] as string);

            var lst1 = lst.Select(x => new
            {
                No = x.No,
                Name = x.Name_as_on_Certificate
            }).ToList();

            ddlNo.DataSource = lst1;
            ddlNo.DataTextField = "No";
            ddlNo.DataValueField = "Name";
            ddlNo.DataBind();
            ddlNo.Items.Insert(0, new ListItem("Select Student No", "0"));
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlType.SelectedItem.Text == "Student")
                LoadStudentNoDropDown();
        }

        protected void ddlNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStudentInfo(ddlNo.SelectedItem.Text.ToString());
        }

        private void LoadStudentInfo(string No)
        {

            if (No != "Select")
            {
                IList<HRMSODATA.StudentList> lstStudent = ODataServices.GetStudentListByNo(No, Session["SessionCompanyName"] as string);
                txtName.Text = lstStudent[0].Student_Name;
                txtuserId.Text = lstStudent[0].User_ID;
            }
        }

        protected void ddlBookNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBookNo.SelectedValue != "0")
            {
                string BookNo = ddlBookNo.SelectedItem.Text.ToString();

                List<HRMSODATA.BookList> lstStudent = ODataServices.GetBookList(Session["SessionCompanyName"] as string).Where(x => x.No == BookNo).ToList();
                if (lstStudent != null && lstStudent.Count > 0)
                {
                    txtBookName.Text = lstStudent[0].Book_Name;
                }
                txtDate.Text = System.DateTime.Now.ToShortDateString();
            }
        }

        protected void btnAdvanceBookCardSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}