using HRMS.Common;
using System;
using System.IO;
using System.Linq;
using WebServices;
using System.Configuration;
namespace HRMS
{
    public partial class BookUpload : System.Web.UI.Page
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

        protected void uploadBtn_Click(object sender, EventArgs e)
        {
            if (this.csvBookUploader.HasFile)
            {
                string fileExtention = Path.GetExtension(this.csvBookUploader.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(new string(csvBookUploader.FileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;

                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    this.csvBookUploader.SaveAs(path);
                }
                string servicePath = ConfigurationManager.AppSettings["PdfPath"].ToString() + finalFileName;
                try
                {
                    SOAPServices.ItemUpload(servicePath, Session["SessionCompanyName"] as string);
                    Alert.ShowAlert(this, "s", "File uploaded Successfully");
                }
                catch (Exception ex)
                {
                    string message = string.Format("Message: {0}\\n\\n", ex.Message);
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
                }
            }
        }
    }
}