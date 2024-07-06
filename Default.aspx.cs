using HRMS.Dto;
using HRMSODATA;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices;
using static System.Net.WebRequestMethods;

namespace HRMS
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            //...
            var userobj = Session["UserData"] as string;
            if (string.IsNullOrEmpty(userobj))
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //var urlList = new List<LicenesingModel>();
                var userobj = Session["UserData"] as string;
                if (!string.IsNullOrEmpty(userobj))
                {
                    var userData = JObject.Parse(userobj.ToString());
                    var isInfra = Convert.ToBoolean(userData["InfrastructureManagement"]);
                    var isHRMS = Convert.ToBoolean(userData["HRMS"]);
                    var isSLCM = Convert.ToBoolean(userData["SLCM"]);
                    var isLibraryMgmnt = Convert.ToBoolean(userData["LibraryManagement"]);
                    var isFeeMgmnt = Convert.ToBoolean(userData["FeeManagement"]);
                    var isAccountMgmnt = Convert.ToBoolean(userData["AccountManagement"]);
                    var isStockNStore = Convert.ToBoolean(userData["StockAndStore"]);
                    var isPlacement = Convert.ToBoolean(userData["Placement"]);

                    var directorLogin = Session["directorLogin"] != null && Convert.ToBoolean(Session["directorLogin"]);
                    if (directorLogin)
                    {
                        divreports.Attributes.Add("class", divreports.Attributes["class"].ToString().Replace("blur", ""));
                        divreports.Attributes.Add("class", divreports.Attributes["class"].ToString().Replace("tooltipp", ""));
                        btnReport.HRef = "ReportManagement.aspx";
                        ddlCompany.Visible = true;
                        BindCompany();
                        ddlCompany.SelectedItem.Text = HttpUtility.UrlDecode(Convert.ToString(Session["SessionCompanyName"]));
                        lblcompanyName.Visible = false;
                        anchrCompanyName.Visible = false;
                    }
                    if (isInfra)
                    {
                        divinfra.Attributes.Add("class", divinfra.Attributes["class"].ToString().Replace("blur", ""));
                        divinfra.Attributes.Add("class", divinfra.Attributes["class"].ToString().Replace("tooltipp", ""));
                        btnInfraa.HRef = "Infra-MasterData.aspx";
                    }
                    if (isHRMS)
                    {
                        
                        divHrms.Attributes.Add("class", divinfra.Attributes["class"].ToString().Replace("blur", ""));
                        divHrms.Attributes.Add("class", divinfra.Attributes["class"].ToString().Replace("tooltipp", ""));
                        btnHRMS.HRef = "RecruitmentsAndRetirements.aspx";
                    }
                    if (isSLCM)
                    {
                        divslcs.Attributes.Add("class", divslcs.Attributes["class"].ToString().Replace("blur", ""));
                        divslcs.Attributes.Add("class", divslcs.Attributes["class"].ToString().Replace("tooltipp", ""));
                        btnslcm.HRef = "Timetable.aspx";
                    }
                    if (isLibraryMgmnt)
                    {
                        divlibrary.Attributes.Add("class", divlibrary.Attributes["class"].ToString().Replace("blur", ""));
                        divlibrary.Attributes.Add("class", divlibrary.Attributes["class"].ToString().Replace("tooltipp", ""));
                        btnLibraryMgmntt.HRef = "LibraryBookSearch.aspx";

                    }
                    if (isFeeMgmnt || isAccountMgmnt)
                    {
                        divlibrry.Attributes.Add("class", divlibrry.Attributes["class"].ToString().Replace("blur", ""));
                        divlibrry.Attributes.Add("class", divlibrry.Attributes["class"].ToString().Replace("tooltipp", ""));
                        btnFeeMgmntt.HRef = "FeeClassificationList.aspx";

                    }
                    if (isStockNStore)
                    {
                        divstock.Attributes.Add("class", divstock.Attributes["class"].ToString().Replace("blur", ""));
                        divstock.Attributes.Add("class", divstock.Attributes["class"].ToString().Replace("tooltipp", ""));
                    }
                    if (!isInfra && !isHRMS && !isSLCM && !isLibraryMgmnt && !isAccountMgmnt && !isFeeMgmnt && !isStockNStore)
                    {
                        Response.Redirect("Login.aspx");
                    }
                    
                    lblcompanyName.Text = HttpUtility.UrlDecode(Convert.ToString(Session["SessionCompanyName"]));
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
        private void BindCompany()
        {
            var companyList = ODataServices.GetCompanyList();
            ddlCompany.DataSource = companyList;
            ddlCompany.DataTextField = "Name";
            ddlCompany.DataValueField = "Name";
            ddlCompany.DataBind();
            ddlCompany.Items.Insert(0, new ListItem("Select company", "0"));
        }

        protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["SessionCompanyName"] = System.Web.HttpUtility.UrlPathEncode(ddlCompany.SelectedItem.Text);
        }

        protected void btnStockStore_Click(object sender, EventArgs e)
        {
            var userobj = Session["UserData"] as string;
            var userData = JObject.Parse(userobj.ToString());
            var userName = userData["UserName"];
            string url = string.Format("{0}{1}{2}{3}{4}", ConfigurationManager.AppSettings["StockandStoreURL"].ToString(), "/Account/Login?id=", userName, "&Company=", Session["SessionCompanyName"].ToString());
            Response.Redirect(url);
        }
    }

    public class company
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}