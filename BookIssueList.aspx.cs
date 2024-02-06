using HRMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices;
using WebServices.BookIssueCardReference;

namespace HRMS
{
    public partial class BookIssueList : System.Web.UI.Page
    {
        public static string CompanyName;
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
                CompanyName = Session["SessionCompanyName"] as string;

                List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
                if (lstUserRole != null)
                {
                    var role = lstUserRole
                        .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                        string.Equals(x.Page_Name.Trim(), "Book Issue List", StringComparison.OrdinalIgnoreCase) &&
                        string.Equals(x.Module_Name.Trim(), "Library", StringComparison.OrdinalIgnoreCase));
                    if (role == null)
                    {
                        BindListView();
                    }
                    else
                    {
                        if (!Convert.ToBoolean(role.Read))
                        {
                            Alert.ShowAlert(this, "W", "You do not have permission to read the content. Kindly contact the system administrator.");
                            return;
                        }
                        BindListView();
                    }
                }

                BindListView();
            }
        }
        protected override void Render(HtmlTextWriter writer)
        {
            ClientScript.RegisterForEventValidation(ddlNo.UniqueID.ToString());
            ClientScript.RegisterForEventValidation(ddlAccessNo.UniqueID.ToString());
            ClientScript.RegisterForEventValidation(btnAdd.UniqueID.ToString());
            base.Render(writer);
        }


        private void BindListView()
        {
            IList<HRMSODATA.BookIssueList> BookIssueList = ODataServices.GetBookIssueList(CompanyName);

            if (BookIssueList != null)
            {
                BookIssueListView.DataSource = BookIssueList;
                BookIssueListView.DataBind();
            }
        }
        //protected void btnSearchBookIssuedata_Click(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(txtbookIssueSearch.Text))
        //    {
        //        var LibrarySearchList = ODataServices.GetFilterBookIssueList(txtbookIssueSearch.Text, CompanyName);
        //        if (LibrarySearchList != null)
        //        {
        //            BookIssueListView.DataSource = LibrarySearchList;
        //            BookIssueListView.DataBind();
        //        }
        //    }
        //}

        //Added By Deshpande
        protected void btnSearchBookIssuedata_Click(object sender, EventArgs e)
        {
            var lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Book Issue List", StringComparison.OrdinalIgnoreCase)
                                     && string.Equals(x.Module_Name.Trim(), "Library", StringComparison.OrdinalIgnoreCase));

            if (role == null || Convert.ToBoolean(role.Read))
            {
                if (!string.IsNullOrEmpty(txtbookIssueSearch.Text))
                {
                    var LibrarySearchList = ODataServices.GetFilterBookIssueList(txtbookIssueSearch.Text, CompanyName);
                    if (LibrarySearchList != null)
                    {
                        BookIssueListView.DataSource = LibrarySearchList;
                        BookIssueListView.DataBind();
                    }
                    else
                    {
                        
                    }
                }
                else
                {
                    
                    //BindListView();
                }

                //BookIssueListView.DataBind();
            }
            else
            {
                Alert.ShowAlert(this, "W", "You do not have permission to read the content. Kindly contact the system administrator.");
            }
        }


        //Added by Deshpande(02-02-2024)
        protected void btnIssueNewBook_Click(object sender, EventArgs e)
        {
            var lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase)&&
               string.Equals (x.Page_Name.Trim(), "Book Issue List", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Library", StringComparison.OrdinalIgnoreCase));
            if (role == null || Convert.ToBoolean(role.Read))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#MyPopup').modal('show')", true);
                LoadUserTypeDropDown();
                LoadAccessnoDropdown();
            }
            else
            {
                Alert.ShowAlert(this, "W", "You do not have permission to read the content. Kindly contact the system administrator.");
                return;
            }
        }

        protected void BookReturnListView_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {

                case ("Issue"):
                    string Entry_No = e.CommandArgument.ToString();
                    try
                    {
                        SOAPServices.BookIssue(Entry_No, CompanyName);
                        Alert.ShowAlert(this, "s", "Book issued successfully.");
                    }
                    catch(Exception ex)
                    {
                        Alert.ShowAlert(this, "e", ex.Message);
                    }                        
                    break;
            }
        }



        #region Web Method
        [System.Web.Services.WebMethod]
        [ScriptMethod(UseHttpGet = false)]
        public static IList<HRMSODATA.BookIssueList> GetListViewData()
        {
            IList<HRMSODATA.BookIssueList> BookIssueList = ODataServices.GetBookIssueList(CompanyName);
            if (BookIssueList != null)
            {
                return BookIssueList;
            }
            return BookIssueList;
        }


        [System.Web.Services.WebMethod]
        [ScriptMethod(UseHttpGet = false)]
        public static IList<HRMSODATA.BookIssueList> IssueBookData(String UserType, String No, String Name, String AccessNo, String Bookname, String DOI, String DOR, String BookNo, String AvlQty, String classcode)
        {
            User_Type Type = (User_Type)Enum.Parse(typeof(User_Type), UserType);
            var updateObj = new WebServices.BookIssueCardReference.BookIssueCard
            {
                User_Type=  Type,
                No=No,
                Accession_No=AccessNo,
                User_TypeSpecified=IsUserTypeSpecified(UserType)
            };

            SOAPServices.IssueBookcard(updateObj, CompanyName);
            IList<HRMSODATA.BookIssueList> BookIssueList = ODataServices.GetBookIssueList(CompanyName);
            if (BookIssueList != null)
            {
                return BookIssueList;
            }
            return BookIssueList;
        }


        [System.Web.Services.WebMethod]
        [ScriptMethod(UseHttpGet = false)]
        public static string LoadStudentNoDropDown()
        {
            IList<HRMSODATA.StudentList> lst = ODataServices.GetStudentList(CompanyName);

            var lst1 = lst.Select(x => new
            {
                No = x.No,
                Name = x.Name_as_on_Certificate
            }).ToList();

            string myJsonString = (new JavaScriptSerializer()).Serialize(lst1);
            return myJsonString;
        }

        [System.Web.Services.WebMethod]
        [ScriptMethod(UseHttpGet = false)]
        public static string LoadStudentInfo(string No)
        {
            string jsonData = "";
            string jsonData1 = "";
            dynamic lststnd = "";
            dynamic lstBook = "";
            if (No!="Select")
            {
                IList<HRMSODATA.StudentList> lstStudent = ODataServices.GetStudentListByNo(No, CompanyName);
                if (lstStudent!=null && lstStudent.Count>0)
                {
                    lststnd = lstStudent.Select(x => new
                    {
                        FirstName = x.First_Name,
                        CourseCode = x.Course_Code
                    }).ToList();
                    jsonData=(new JavaScriptSerializer()).Serialize(lststnd);
                }

                IList<HRMSODATA.BookIssueList> bookIssueListByNo = ODataServices.GetBookIssueListByNo(No, CompanyName);
                if (bookIssueListByNo!=null && bookIssueListByNo.Count>0)
                {
                    lstBook = bookIssueListByNo.Select(x => new
                    {
                        DateofIssue = DateTimeParser.ConvertDateTimeMMDDYYYY(x.Date_of_Issue),
                        DateofReturn = DateTimeParser.ConvertDateTimeMMDDYYYY(x.Date_of_Return)
                    }).FirstOrDefault();
                    jsonData1 = (new JavaScriptSerializer()).Serialize(lstBook);
                }

                var objects = new { StudentList = lststnd, BookIssueList = lstBook };
                string result = new JavaScriptSerializer().Serialize(objects);


                return result;
            }

            return "";
        }


        [System.Web.Services.WebMethod]
        [ScriptMethod(UseHttpGet = false)]
        public static string LoadStudentAccessInfo(string AccessNo)
        {
            if (AccessNo!="select")
            {
                string jsonData = "";
                IList<HRMSODATA.BookIssueList> lstStudent = ODataServices.GetBookIssueListByAccessNo(AccessNo, CompanyName);

                if (lstStudent!=null && lstStudent.Count>0)
                {
                    var lstStudentAccession = lstStudent.Select(x => new
                    {
                        BookName = x.Book_Name,
                        BookNo = x.Book_No,
                        AvlQty = x.Avl_Qty
                    }).ToList();
                    jsonData=(new JavaScriptSerializer()).Serialize(lstStudentAccession);
                }


                return jsonData;
            }
            return "";
        } 
        #endregion

        private void LoadUserTypeDropDown()
        {
            ddlmdUserType.DataSource = Enum.GetNames(typeof(User_Type));
            ddlmdUserType.DataBind();
        }


      
        public static bool IsUserTypeSpecified(string userType)
        {
            User_Type Type = (User_Type)Enum.Parse(typeof(User_Type), userType);
            if (Type==User_Type.Student || Type==User_Type.Staff)
            {
                return true;
            }
            return false;
        }
        private void LoadAccessnoDropdown()
        {
            ddlAccessNo.DataSource=ODataServices.GetAccessionList(CompanyName);
            ddlAccessNo.DataTextField="Accession_No";
            ddlAccessNo.DataValueField="Accession_No";
            ddlAccessNo.DataBind();
            ddlAccessNo.Items.Insert(0, new ListItem("Select", "NA"));
        }




    }
}