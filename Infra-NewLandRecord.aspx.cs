using HRMS.Common;
using InfrastructureManagement.Common;
using System;
using System.IO;
using System.Web.UI.WebControls;
using WebServices;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
namespace HRMS
{
    public partial class NewLandRecord : System.Web.UI.Page
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
                    string.Equals(x.Page_Name.Trim(), "Add Land Record", StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Module_Name.Trim(), "Infra", StringComparison.OrdinalIgnoreCase));

                    if (role == null || Convert.ToBoolean(role.Read))
                    {
                        ddlDistrict.DataSource = ODataServices.Getdistricts(Session["SessionCompanyName"] as string);
                        ddlDistrict.DataTextField = "Name";
                        ddlDistrict.DataValueField = "Code";
                        ddlDistrict.DataBind();
                        ddlDistrict.Items.Insert(0, new ListItem("Select District", "0"));
                    }
                    else
                    {
                        Alert.ShowAlert(this, "W", "You do not have permission to Read the content. Kindly contact the system administrator.");
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            if (lstUserRole != null)
            {
                var role = lstUserRole.FirstOrDefault(x =>
                string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Add Land Record", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Module_Name.Trim(), "Infra", StringComparison.OrdinalIgnoreCase));

                if (role == null || Convert.ToBoolean(role.Insert))
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
                        //Land_Issue_Description = txtLand_Issue_Description.Text,
                        Encroachment_Plot_Area = NumericHandler.ConvertToDecimal(txtEncroachment_Plot_Area.Text),
                        Encroachment_Plot_No = txtEncroachment_Plot_No.Text,
                        Dispute_Plot_No = txtDispute_Plot_No.Text,
                        Dispute_Area = NumericHandler.ConvertToDecimal(txtDispute_Area.Text),
                        CasePlot_No = txtCasePlot_No.Text
                    };
                    var result = SOAPServices.CreateLandRecord(obj, Session["SessionCompanyName"] as string);
                    if (result == ResultMessages.SuccessfullMessage)
                    {
                        txtKhatian_Serial_No.Text = string.Empty;
                        ddlLandKisam.SelectedValue = "Select";
                        txtPlot_No.Text = string.Empty;
                        ddlDistrict.SelectedValue = "0";
                        txtTahasil.Text = string.Empty;
                        txtVillage.Text = string.Empty;
                        txtRI_Circle.Text = string.Empty;
                        txtLand_Owner_Details.Text = string.Empty;
                        txtLand_possessioner_Details.Text = string.Empty;
                        //txtLand_Issue_Description.Text = string.Empty;
                        txtEncroachment_Plot_No.Text = string.Empty;
                        txtEncroachment_Plot_Area.Text = string.Empty;
                        txtDispute_Plot_No.Text = string.Empty;
                        txtDispute_Area.Text = string.Empty;
                        txtCasePlot_No.Text = string.Empty;
                        if (pdfUploader.HasFile)
                        {
                            string fileExtention = Path.GetExtension(pdfUploader.FileName);
                            string finalFileName = Path.GetFileNameWithoutExtension(pdfUploader.FileName.Substring(0, 10)) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                            string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                            if (!Directory.Exists(path))
                                Directory.CreateDirectory(path);
                            if (Directory.Exists(path))
                            {
                                path = Path.Combine(path, finalFileName);
                                pdfUploader.SaveAs(path);
                            }
                            string servicePath = ConfigurationManager.AppSettings["PdfPath"].ToString() + finalFileName;
                            SOAPServices.ImportPdfRoRFile(obj.Khatian_Serial_No, servicePath, Session["SessionCompanyName"] as string);
                        }

                        Alert.ShowAlert(this, "s", result);
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
    }
}