using HRMS.Common;
using InfrastructureManagement.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class Infra_MaintenanceAndAMC : System.Web.UI.Page
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
                var vendorList = ODataServices.GetVendorList(Session["SessionCompanyName"] as string).Where(x => x.Name != string.Empty);
                ddlAgencyName.DataSource = vendorList;
                ddlAgencyName.DataTextField = "Name";
                ddlAgencyName.DataValueField = "No";
                ddlAgencyName.DataBind();
                ddlAgencyName.Items.Insert(0, new ListItem("Select Agency", "0"));

                var items = ODataServices.GetItemList(Session["SessionCompanyName"] as string);
                ddlItemNo.DataSource = items;
                ddlItemNo.DataTextField = "Description";
                ddlItemNo.DataValueField = "No";
                ddlItemNo.DataBind();
                ddlItemNo.Items.Insert(0, new ListItem("Select Item", "0"));
            }

        }

        protected void btnAMCSubmit_Click(object sender, EventArgs e)
        {
            var obj = new WebServices.InfraAMCReference.AMCCard
            {
                DurationSpecified = true,
                Date_of_ExpirySpecified = true,
                Annual_Cost_of_AMCSpecified = true,

                Agency_No = ddlAgencyName.SelectedItem.Value,
                Type_of_equipment_under_AMC = txtTypeOfEquipment.Text,
                Duration = NumericHandler.ConvertToInteger(txtDuration.Text),
                Date_of_Expiry = DateTimeParser.ParseDateTime(txtDateOfExpiry.Text),
                Annual_Cost_of_AMC = NumericHandler.ConvertToDecimal(txtAnnualAMCCost.Text),
                Payment_Status = ddlPaymentStatus.SelectedItem.Text == "Already Paid" ? WebServices.InfraAMCReference.Payment_Status.Paid : WebServices.InfraAMCReference.Payment_Status.To_be_paid,
                Item_No = ddlItemNo.SelectedItem.Value,
                Equipment_Id = txtEquipmentId.Text
                //Item_Name = txtItemDescription.Text
            };
            var result = SOAPServices.CreateMaintainceAndAMC(obj, Session["SessionCompanyName"] as string);
            if (result == ResultMessages.SuccessfullMessage)
            {
                Alert.ShowAlert(this, "s", result);
                ddlAgencyName.SelectedIndex = 0;
                ddlItemNo.SelectedIndex = 0;
                ddlPaymentStatus.ClearSelection();
                txtTypeOfEquipment.Text = string.Empty;
                txtDuration.Text = string.Empty;
                txtAnnualAMCCost.Text = string.Empty;
                txtEquipmentId.Text = string.Empty;
            }
            else
            {
                Alert.ShowAlert(this, "e", result);
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            string FileName = "AMCAndMaintenance.XLS";
            string bcPath = SOAPServices.ExportAMCAndMaintenanceFile(Session["SessionCompanyName"] as string);
            if (!string.IsNullOrEmpty(bcPath))
            {
                string exportedFilePath = ConfigurationManager.AppSettings["ExportFilePath"].ToString() + StringHelper.GetFileNameFromURL(bcPath);
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
                Alert.ShowAlert(this, "e", "No file found.");
            }
        }

    }
}