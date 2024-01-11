using HRMS.Common;
using HRMS.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        static string userName = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    if (string.IsNullOrEmpty(Session["SessionCompanyName"] as string))
            //    {
            //        string message = string.Format("Message: {0}\\n\\n", "Please select a company");
            //        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
            //        Response.Redirect("Default.aspx");
            //    }
            //}
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            lblmsg.Visible = false;
            var userData = ODataServices.GetUserAuthenticationList();
            var userdata = userData.FirstOrDefault(x => string.Equals(x.User_Name, userName.Trim(), StringComparison.OrdinalIgnoreCase)
                                                      && string.Equals(x.Password, txtCurrentPassword.Text.Trim(), StringComparison.Ordinal));

            if (userdata != null)
            {
                var obj = new WebServices.UserAuthenticationCardReference.UserAuthenticationCard

                {
                    User_Name = userdata.User_Name,
                    Password = txtresetPassword.Text
                };

                try
                {
                    SOAPServices.ResetUserPassword(obj, userdata.Company_Name);
                    lblmsg.Text = "Password reset successfully !";
                    lblmsg.ForeColor = System.Drawing.Color.White;
                    lblmsg.Visible = true;
                }
                catch (Exception ex)
                {
                    lblmsg.Text = ex.Message;
                }
            }
            else
            {
                lblmsg.Text = "Password you have entered does not match with any account";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Visible = true;
            }

        }

        protected void btnForgot_Click(object sender, EventArgs e)
        {
            var userData = ODataServices.GetUserAuthenticationList();
            var user = userData.FirstOrDefault(x => string.Equals(x.User_Name, txtEmailAddress.Text.Trim(), StringComparison.OrdinalIgnoreCase));
            userName = txtEmailAddress.Text.Trim();
            if (user != null)
            {
                forgotPassdiv.Visible = false;
                resetPassdiv.Visible = true;
            }

        }
    }
}