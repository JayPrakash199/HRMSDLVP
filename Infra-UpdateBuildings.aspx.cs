using HRMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using WebServices;

namespace HRMS
{
    public partial class Infra_UpdateBuildings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["SessionCompanyName"] as string))
            {
                string message = string.Format("Message: {0}\\n\\n", "Please select a company");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Update Building", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Infra", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Modify))
                {
                    if (ddlBuildings.SelectedValue == "InstitutionalBuildings")
                    {
                        Response.Redirect("Infra-UpdateInstituteBuilding.aspx?BlockCode=" + txtSearch.Text);
                    }
                    else if (ddlBuildings.SelectedValue == "HostelBuildings")
                    {
                        Response.Redirect("Infra-UpdateHostelBuilding.aspx?BlockCode=" + txtSearch.Text);
                    }
                    else if (ddlBuildings.SelectedValue == "StaffQuarters")
                    {
                        Response.Redirect("Infra-UpdateStaffQuarter.aspx?QuarterCode=" + txtSearch.Text);
                    }
                    else
                    {
                        Response.Redirect("Infra-UpdateAuditorium.aspx?BuildingCode=" + txtSearch.Text);
                    }
                }
                else
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to Modify the content. Kindly contact the system administrator.");
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Update Building", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Infra", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Read))
                {
                    ddlBuildings.SelectedValue = ddlBuildings.SelectedValue;
                    btnEdit.Visible = false;
                    if (ddlBuildings.SelectedValue == "InstitutionalBuildings")
                    {
                        var data = ODataServices.GetInstituteBuildings(Session["SessionCompanyName"] as string).FirstOrDefault(x => string.Equals(x.Block_Code, txtSearch.Text, StringComparison.OrdinalIgnoreCase));
                        if (data != null && !string.IsNullOrEmpty(data.Block_Code))
                        {
                            btnEdit.Visible = true;
                        }
                    }
                    else if (ddlBuildings.SelectedValue == "HostelBuildings")
                    {
                        var data = ODataServices.GetHostelBuildings(Session["SessionCompanyName"] as string).FirstOrDefault(x => string.Equals(x.Block_Code, txtSearch.Text, StringComparison.OrdinalIgnoreCase));
                        if (data != null && !string.IsNullOrEmpty(data.Block_Code))
                        {
                            btnEdit.Visible = true;
                        }
                    }
                    else if (ddlBuildings.SelectedValue == "StaffQuarters")
                    {
                        var data = ODataServices.GetStaffQuarters(Session["SessionCompanyName"] as string).FirstOrDefault(x => string.Equals(x.Quarter_Code, txtSearch.Text, StringComparison.OrdinalIgnoreCase));
                        if (data != null && !string.IsNullOrEmpty(data.Quarter_Code))
                        {
                            btnEdit.Visible = true;
                        }
                    }
                    else
                    {
                        var data = ODataServices.GetAuditoriumList(Session["SessionCompanyName"] as string).FirstOrDefault(x => string.Equals(x.Building_Code, txtSearch.Text, StringComparison.OrdinalIgnoreCase));
                        if (data != null && !string.IsNullOrEmpty(data.Building_Code))
                        {
                            btnEdit.Visible = true;
                        }
                    }
                    if (!btnEdit.Visible)
                    {
                        LblMessage.Text = "No record found. Please try with valid Building No.";
                    }
                    else
                    {
                        LblMessage.Text = string.Empty;
                    }
                }
                else
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to Search the content. Kindly contact the system administrator.");
                }
            }
        }
    }
}