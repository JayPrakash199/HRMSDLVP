using System;
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

        protected void btnSearch_Click(object sender, EventArgs e)
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
    }
}