using HRMS.Common;
using InfrastructureManagement.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class Infra_SecurityServices : System.Web.UI.Page
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
                if (lstUserRole != null)
                {
                    var role = lstUserRole.FirstOrDefault(x =>
                    string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Page_Name.Trim(), "Add Services", StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Module_Name.Trim(), "Infra", StringComparison.OrdinalIgnoreCase));

                    if (role == null || Convert.ToBoolean(role.Read))
                    {
                        var vendorList = ODataServices.GetVendorList(Session["SessionCompanyName"] as string).Where(x => x.Name != string.Empty);
                        ddlAgencyName.DataSource = vendorList;
                        ddlAgencyName.DataTextField = "Name";
                        ddlAgencyName.DataValueField = "No";
                        ddlAgencyName.DataBind();
                        ddlAgencyName.Items.Insert(0, new ListItem("Select Agency", "0"));
                    }
                    else
                    {
                        Alert.ShowAlert(this, "W", "You do not have permission to Read the content. Kindly contact the system administrator.");
                    }
                }
            }

        }

        protected void btnSecurityServiceSubmit_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Add Services", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Infra", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Insert))
                {
                    var obj = new WebServices.InfraServiceReference.ServiceCard
                    {
                        No_of_person_engagedSpecified = true,
                        No_of_person_sanctionedSpecified = true,
                        Type_of_serviceSpecified = true,
                        Agency_Code = ddlAgencyName.SelectedItem.Value,
                        No_of_person_engaged = NumericHandler.ConvertToInteger(txtNumberOfPersonEngaged.Text),
                        Type_of_service = ddlTypeOfService.SelectedItem.Text == "Security" ?
                WebServices.InfraServiceReference.Type_of_service.Security : ddlTypeOfService.SelectedItem.Text == "Sweeper" ?
                WebServices.InfraServiceReference.Type_of_service.Sweeper : ddlTypeOfService.SelectedItem.Text == "Driver" ?
                WebServices.InfraServiceReference.Type_of_service.Driver : WebServices.InfraServiceReference.Type_of_service.Others,
                        No_of_person_sanctioned = NumericHandler.ConvertToInteger(txtNumberOfPersonSanctioned.Text)
                    };
                    var result = SOAPServices.CreateSecurityService(obj, Session["SessionCompanyName"] as string);
                    if (result == ResultMessages.SuccessfullMessage)
                    {
                        Alert.ShowAlert(this, "s", result);
                        ddlAgencyName.SelectedIndex = 0;
                        ddlTypeOfService.ClearSelection();
                        txtNumberOfPersonEngaged.Text = string.Empty;
                        txtNumberOfPersonSanctioned.Text = string.Empty;
                    }
                    else
                    {
                        Alert.ShowAlert(this, "e", result);
                    }
                }
                else
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to Submit the content. Kindly contact the system administrator.");
                }
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Add Services", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Infra", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Read))
                {
                    string FileName = "ServiceMonitoring.XLS";
                    string exportedFilePath = ConfigurationManager.AppSettings["ExportFilePath"].ToString() + StringHelper.GetFileNameFromURL(SOAPServices.ExportSecurityFile(Session["SessionCompanyName"] as string));
                    WebClient wc = new WebClient();
                    byte[] buffer = wc.DownloadData(exportedFilePath);

                    var fileName = "attachment; filename=" + FileName;
                    base.Response.ClearContent();
                    base.Response.AddHeader("content-disposition", fileName);
                    base.Response.ContentType = "application/vnd.ms-excel";
                    base.Response.BinaryWrite(buffer);
                    base.Response.End();
                }
                else
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to Export the content. Kindly contact the system administrator.");
                }
            }
        }

    }
}