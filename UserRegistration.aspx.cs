using HRMS.Dto;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace HRMS
{
    public partial class UserRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtUserName.Text) && !string.IsNullOrEmpty(txtMobileNo.Text))
                {
                    var obj = new UserDto
                    {
                        UserId = 1,
                        UserName = txtUserName.Text.Trim(),
                        Email = txtEmail.Text,
                        MobileNo = Convert.ToInt64(txtMobileNo.Text),
                        CompanyName = txtCompanyName.Text,
                        InfrastructureManagement = chkInfra.Checked,
                        HRMS = chkHRMS.Checked,
                        SLCM = chkSLCM.Checked,
                        LibraryManagement = chkLibraryManagement.Checked,
                        FeeManagement = chkFeeManagement.Checked,
                        AccountManagement = chkAccountManagement.Checked,
                        StockAndStore = chkStockAndStore.Checked,
                        Placement = chkPlacement.Checked,
                        FatherName = txtfatherName.Text.Trim(),
                        MotherName = txtmotherName.Text.Trim(),
                        AdharNo = txtAdharNo.Text.Trim(),
                        PanNO = txtPanNo.Text.Trim(),
                        PresentAdddress = txtPresentAddress.Text.Trim(),
                        PermanentAddress = txtpermanentAddress.Text.Trim(),
                        AlternativeMobileNo = Convert.ToInt64(txtaltMobileNo.Text)
                    };
                    string apiBaseURL = ConfigurationManager.AppSettings["ExternalAPI"].ToString();

                    var company = JsonConvert.SerializeObject(obj, Formatting.Indented);

                    var requestContent = new StringContent(company, Encoding.UTF8, "application/json");

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(apiBaseURL);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        HttpResponseMessage response = client.PostAsync("User/SaveUserData", requestContent).Result;

                        if (response.IsSuccessStatusCode)
                        {
                            var content = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
                            lbluserName.Text = txtUserName.Text;

                            if (Convert.ToString(content) != "null")
                            {
                                lblMessage.Text = "added successfully.";
                            }
                            else
                            {
                                lblMessage.Text = "already exist.";
                            }
                            toster.Visible = true;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}