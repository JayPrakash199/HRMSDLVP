using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Script.Services;
using System.Web.UI.WebControls;
using BotDetect.C5;
using WebServices;
using WebServices.BookIssueCardReference;
using static System.Collections.Specialized.BitVector32;
using System.Web;
using HRMS.Common;

namespace HRMS
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Services.WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false)]
        public static void SetCompanyForDirector(String companyName)
        {
            HttpContext.Current.Session["SessionCompanyName"] = HttpUtility.UrlPathEncode(companyName);
            string sessionId = System.Web.HttpContext.Current.Session.SessionID;
            SOAPServices.LogSessionData(Helper.UserName, sessionId, System.DateTime.Now, HttpContext.Current.Session["SessionCompanyName"] as string);

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmailAddress.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                bool isHuman = captchaBox.Validate(txtCaptch.Text);
                var userData = ODataServices.GetUserAuthenticationList();
                var user = userData.FirstOrDefault(x => string.Equals(x.User_Name, txtEmailAddress.Text.Trim(), StringComparison.OrdinalIgnoreCase)
                                                        && string.Equals(x.Password, txtPassword.Text.Trim(), StringComparison.Ordinal));
                if (!isHuman)
                {
                    captchMsg.Visible = true;
                    return;
                }
                else
                {
                    captchMsg.Visible = false;
                }
                if (user != null)
                {
                    string apiURL = ConfigurationManager.AppSettings["ExternalAPI"].ToString();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(apiURL);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        //GET Method
                        HttpResponseMessage response = client.GetAsync(string.Format("User/Getdata?userName={0}", txtEmailAddress.Text.Trim())).Result;

                        if (response.IsSuccessStatusCode)
                        {
                            var jsonResult = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
                            Session["UserData"] = jsonResult.ToString();
                            if (user.Director != null && (bool)user.Director)
                            {
                                Session["directorLogin"] = (bool)user.Director;
                                var companyList = ODataServices.GetCompanyList();
                                ddlCompany.DataSource = companyList;
                                ddlCompany.DataTextField = "Name";
                                ddlCompany.DataValueField = "Name";
                                ddlCompany.DataBind();
                                ddlCompany.Items.Insert(0, new ListItem("Select company", "0"));
                                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#CompanyPopup').modal('show')", true);
                            }
                            else
                            {
                                Session["SessionCompanyName"] = System.Web.HttpUtility.UrlPathEncode(user.Company_Name);
                                string sessionId = System.Web.HttpContext.Current.Session.SessionID;
                                SOAPServices.LogSessionData(Helper.UserName, sessionId, System.DateTime.Now, Session["SessionCompanyName"] as string);
                                Response.Redirect("Default.aspx");
                            }
                        }
                    }
                }
                else
                {
                    alertMsg.Visible = true;
                }
            }
            else
            {
                alertMsg.Visible = true;
            }
        }


    }
}