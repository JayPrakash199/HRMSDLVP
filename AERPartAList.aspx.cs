using HRMS.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using WebServices;

namespace HRMS
{
    public partial class AERPartAList : System.Web.UI.Page
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

                List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
                var role = lstUserRole
                    .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                     string.Equals(x.Page_Name.Trim(), "Regular List", StringComparison.OrdinalIgnoreCase)
                                         && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));
                if (role == null)
                {
                    BindListView();
                }
                else
                {
                    if (!Convert.ToBoolean(role.Read))
                    {
                        Alert.ShowAlert(this, "W",
                            "You do not have permission to read the data. Kindly contact the system administrator.");
                        return;
                    }
                    BindListView();
                }
            }
        }

        private void BindListView()
        {
            var annualEstablishmentReviewList =
                ODataServices.GetAnnualEstablishmentReviewList(Session["SessionCompanyName"] as string);
            AnnualEstablishmentReviewListView.DataSource = annualEstablishmentReviewList
                .Where(x => x.Establishment_Type == "Part – A (Regular Establishment)");
            AnnualEstablishmentReviewListView.DataBind();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            var servicePath = SOAPServices.ExportAnnualEstablishmentPartA(Session["SessionCompanyName"] as string);
            var FileName = "AnnualEstablishmentPartA.XLS";
            string exportedFilePath = ConfigurationManager.AppSettings["ExportFilePath"].ToString() + StringHelper.GetFileNameFromURL(servicePath);
            WebClient wc = new WebClient();
            byte[] buffer = wc.DownloadData(exportedFilePath);
            var fileName = "attachment; filename=" + FileName;
            base.Response.ClearContent();
            base.Response.AddHeader("content-disposition", fileName);
            base.Response.ContentType = "application/vnd.ms-excel";
            base.Response.BinaryWrite(buffer);
            base.Response.End();
        }
    }
}