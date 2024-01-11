using HRMS.Common;
using InfrastructureManagement.Common;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class LandRecordCard : System.Web.UI.Page
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
                ddlDistrict.DataSource = ODataServices.Getdistricts(Session["SessionCompanyName"] as string);
                ddlDistrict.DataTextField = "Name";
                ddlDistrict.DataValueField = "Code";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("Select District", "0"));
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var obj = new WebServices.InfraLandCardReference.LandCard
            {
                Land_KisamSpecified = true,
                Dispute_AreaSpecified = true,
                Encroachment_Plot_AreaSpecified = true,

                Khatian_Serial_No = txtKhatian_Serial_No.Text,
                Land_Kisam = ddlLandKisam.SelectedValue == "Abadi_Irrigated_Two_Crops" ? WebServices.InfraLandCardReference.Land_Kisam.Abadi_Irrigated_Two_Crops
                : ddlLandKisam.SelectedValue == "Abadi_Irrigated_One_crop" ? WebServices.InfraLandCardReference.Land_Kisam.Abadi_Irrigated_One_crop
                : ddlLandKisam.SelectedValue == "Abadi_Non_irrigated_Rainfed" ? WebServices.InfraLandCardReference.Land_Kisam.Abadi_Non_irrigated_Rainfed
                : ddlLandKisam.SelectedValue == "Abadi_Orchards_Bagayat" ? WebServices.InfraLandCardReference.Land_Kisam.Abadi_Orchards_Bagayat
                : ddlLandKisam.SelectedValue == "Abadi_Water_bodies_Jalashaya" ? WebServices.InfraLandCardReference.Land_Kisam.Abadi_Water_bodies_Jalashaya
                : ddlLandKisam.SelectedValue == "Abadi_Homestead_Gharabari" ? WebServices.InfraLandCardReference.Land_Kisam.Abadi_Homestead_Gharabari
                : ddlLandKisam.SelectedValue == "Abadi_Commercial_Byabasaika" ? WebServices.InfraLandCardReference.Land_Kisam.Abadi_Commercial_Byabasaika
                : ddlLandKisam.SelectedValue == "Abadi_Industrial_Shilpabhttika" ? WebServices.InfraLandCardReference.Land_Kisam.Abadi_Industrial_Shilpabhttika
                : ddlLandKisam.SelectedValue == "Abadi_Forest_Jungle" ? WebServices.InfraLandCardReference.Land_Kisam.Abadi_Forest_Jungle
                : ddlLandKisam.SelectedValue == "Abadi_Institutional_Anushthan" ? WebServices.InfraLandCardReference.Land_Kisam.Abadi_Institutional_Anushthan
                : ddlLandKisam.SelectedValue == "Abadi_Mine_Khani_Khadan__x0026__Others" ? WebServices.InfraLandCardReference.Land_Kisam.Abadi_Mine_Khani_Khadan__x0026__Others
                : ddlLandKisam.SelectedValue == "Abada_Jogya_Anabadi" ? WebServices.InfraLandCardReference.Land_Kisam.Abada_Jogya_Anabadi
                : ddlLandKisam.SelectedValue == "Abada_Ajogya_Anabadi" ? WebServices.InfraLandCardReference.Land_Kisam.Abada_Ajogya_Anabadi
                : ddlLandKisam.SelectedValue == "Rakhit" ? WebServices.InfraLandCardReference.Land_Kisam.Rakhit
                : ddlLandKisam.SelectedValue == "Sarbasadharana" ? WebServices.InfraLandCardReference.Land_Kisam.Sarbasadharana
                : WebServices.InfraLandCardReference.Land_Kisam._blank_,
                Plot_No = txtPlot_No.Text,
                District = ddlDistrict.SelectedItem.Text,
                Tahasil = txtTahasil.Text,
                Village = txtVillage.Text,
                RI_Circle = txtRI_Circle.Text,
                Land_Owner_Details = txtLand_Owner_Details.Text,
                Land_possessioner_Details = txtLand_possessioner_Details.Text,
                Land_Issue_Description = txtLand_Issue_Description.Text,
                Encroachment_Plot_Area = NumericHandler.ConvertToDecimal(txtEncroachment_Plot_Area.Text),
                Encroachment_Plot_No = txtEncroachment_Plot_No.Text,
                Dispute_Plot_No = txtDispute_Plot_No.Text,
                Dispute_Area = NumericHandler.ConvertToDecimal(txtDispute_Area.Text),
                CasePlot_No = txtCasePlot_No.Text
            };
            var result = SOAPServices.UpdateLandRecord(obj, Session["SessionCompanyName"] as string);
            if (result == ResultMessages.UpdateSuccessfullMessage)
            {
                Alert.ShowAlert(this, "s", result);
            }
            else
            {
                Alert.ShowAlert(this, "e", result);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var result = ODataServices.GetLandDetailList(Session["SessionCompanyName"] as string);
            var filteredResult = result.Where(x => x.Khatian_Serial_No == txtSearch.Text).FirstOrDefault();
            if (filteredResult != null)
            {
                txtKhatian_Serial_No.Text = filteredResult.Khatian_Serial_No;
                ddlLandKisam.SelectedValue = Convert.ToString(filteredResult.Land_Kisam) == "Abadi - Irrigated Two Crops" ? "Abadi_Irrigated_Two_Crops"
                    : Convert.ToString(filteredResult.Land_Kisam) == "Abadi - Irrigated One crop" ? "Abadi_Irrigated_One_crop"
                    : Convert.ToString(filteredResult.Land_Kisam) == "Abadi - Non irrigated (Rainfed)" ? "Abadi_Non_irrigated_Rainfed"
                    : Convert.ToString(filteredResult.Land_Kisam) == "Abadi - Orchards (Bagayat)" ? "Abadi_Orchards_Bagayat"
                    : Convert.ToString(filteredResult.Land_Kisam) == "Abadi - Water bodies (Jalashaya)" ? "Abadi_Water_bodies_Jalashaya"
                    : Convert.ToString(filteredResult.Land_Kisam) == "Abadi - Homestead (Gharabari)" ? "Abadi_Homestead_Gharabari"
                    : Convert.ToString(filteredResult.Land_Kisam) == "Abadi - Commercial (Byabasaika)" ? "Abadi_Commercial_Byabasaika"
                    : Convert.ToString(filteredResult.Land_Kisam) == "Abadi - Industrial (Shilpabhttika)" ? "Abadi_Industrial_Shilpabhttika"
                    : Convert.ToString(filteredResult.Land_Kisam) == "Abadi - Forest (Jungle)" ? "Abadi_Forest_Jungle"
                    : Convert.ToString(filteredResult.Land_Kisam) == "Abadi - Institutional (Anushthan)" ? "Abadi_Institutional_Anushthan"
                    : Convert.ToString(filteredResult.Land_Kisam) == "Abadi - Mine (Khani Khadan) & Others" ? "Abadi_Mine_Khani_Khadan__x0026__Others"
                    : Convert.ToString(filteredResult.Land_Kisam) == "Abada Jogya Anabadi" ? "Abada_Jogya_Anabadi"
                    : Convert.ToString(filteredResult.Land_Kisam) == "Abada Ajogya Anabadi" ? "Abada_Ajogya_Anabadi"
                    : Convert.ToString(filteredResult.Land_Kisam) == "Rakhit" ? "Rakhit"
                    : Convert.ToString(filteredResult.Land_Kisam) == "Sarbasadharana" ? "Sarbasadharana"
                    : "";
                txtPlot_No.Text = filteredResult.Plot_No;
                ddlDistrict.SelectedItem.Text = filteredResult.District;
                txtTahasil.Text = filteredResult.Tahasil;
                txtVillage.Text = filteredResult.Village;
                txtRI_Circle.Text = filteredResult.RI_Circle;
                txtLand_Owner_Details.Text = filteredResult.Land_Owner_Details;
                txtLand_possessioner_Details.Text = filteredResult.Land_possessioner_Details;
                txtLand_Issue_Description.Text = filteredResult.Land_Issue_Description;
                txtEncroachment_Plot_No.Text = filteredResult.Encroachment_Plot_No;
                txtEncroachment_Plot_Area.Text = Convert.ToString(filteredResult.Encroachment_Plot_Area);
                txtDispute_Plot_No.Text = filteredResult.Dispute_Plot_No;
                txtDispute_Area.Text = Convert.ToString(filteredResult.Dispute_Area);
                txtCasePlot_No.Text = filteredResult.CasePlot_No;
                LblMessage.Text = string.Empty;
            }
            else
            {
                txtKhatian_Serial_No.Text = string.Empty;
                ddlLandKisam.SelectedValue = string.Empty;
                txtPlot_No.Text = string.Empty;
                ddlDistrict.SelectedItem.Text = string.Empty;
                txtTahasil.Text = string.Empty;
                txtVillage.Text = string.Empty;
                txtRI_Circle.Text = string.Empty;
                txtLand_Owner_Details.Text = string.Empty;
                txtLand_possessioner_Details.Text = string.Empty;
                txtLand_Issue_Description.Text = string.Empty;
                txtEncroachment_Plot_No.Text = string.Empty;
                txtEncroachment_Plot_Area.Text = string.Empty;
                txtDispute_Plot_No.Text = string.Empty;
                txtDispute_Area.Text = string.Empty;
                txtCasePlot_No.Text = string.Empty;
                LblMessage.Text = "No record found. Please try with valid Khatian Serial No.";
            }
        }
    }
}