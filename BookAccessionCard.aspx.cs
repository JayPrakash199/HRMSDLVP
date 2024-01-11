using HRMS.Common;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class BookAccessionCard : System.Web.UI.Page
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
                BindLocationDropDown();
                var bookNo = Request.QueryString["BOOKNO"];
                if (bookNo != null && !string.IsNullOrEmpty(bookNo))
                {
                    var bookAccessionCard = ODataServices.GetBookAccessionList(Session["SessionCompanyName"] as string)
                                                .Where(x => String.Equals(x.Book_No, bookNo, StringComparison.OrdinalIgnoreCase))
                                                .FirstOrDefault();
                    BindVendorDropdown();
                    if (bookAccessionCard != null)
                    {
                        txtBookNo.Text = bookAccessionCard.Book_No;
                        txtAccessionNo.Text = bookAccessionCard.Accession_No;
                        txtBookName.Text = bookAccessionCard.Book_Name;
                        txtCurrentStatus.Text = bookAccessionCard.Book_Current_Status;
                        ddlLocationCode.SelectedValue = bookAccessionCard.Location_Code;
                        txtCondition.Text = bookAccessionCard.Condition;
                        txtUnitCost.Text = Convert.ToString(bookAccessionCard.Unit_Cost);
                        txtDateOfPurchase.Text = DateTimeParser.ConvertDateTimeToText(bookAccessionCard.Date_of_Purchase);
                        txtBillNo.Text = bookAccessionCard.Bill_No;
                        txtBillDate.Text = DateTimeParser.ConvertDateTimeToText(bookAccessionCard.Bill_Date);

                        if (!string.IsNullOrEmpty(bookAccessionCard.Book_Source))
                            ddlBookSource.SelectedValue = bookAccessionCard.Book_Source;
                        txtSourceBy.Text = bookAccessionCard.Source_By;
                        txtISBN.Text = bookAccessionCard.ISBN;
                        txtISSN.Text = bookAccessionCard.ISSN;
                        hdnLineNo.Value = Convert.ToString(bookAccessionCard.Line_No);

                        if (!string.IsNullOrEmpty(bookAccessionCard.Vendor_No))
                        {
                            ddlVendor.SelectedValue = bookAccessionCard.Vendor_No;
                        }
                    }
                }
            }
        }

        private void BindLocationDropDown()
        {
            ddlLocationCode.DataSource = ODataServices.GetLocationsList(Session["SessionCompanyName"] as string);
            ddlLocationCode.DataTextField = "Code";
            ddlLocationCode.DataValueField = "Code";
            ddlLocationCode.DataBind();
            ddlLocationCode.Items.Insert(0, new ListItem("Select", "NA"));
        }

        protected void btnBookAccessionCardUpdate_Click(object sender, EventArgs e)
        {
            var obj = new WebServices.BookAccessionReference.BookAccessionCard
            {
                Accession_No = txtAccessionNo.Text,
                Location_Code = ddlLocationCode.SelectedValue,
                Vendor_No = ddlVendor.SelectedValue,
                Book_No = txtBookNo.Text,
                Line_No = Convert.ToInt32(hdnLineNo.Value)
            };
            var resultMessage = SOAPServices.UpdateBookAccessionCard(obj, Session["SessionCompanyName"] as string);
            if (resultMessage == ResultMessages.UpdateSuccessfullMessage)
            {
                Alert.ShowAlert(this, "s", resultMessage);
            }
            else
            {
                Alert.ShowAlert(this, "e", resultMessage);
            }
        }

        protected void btnAccessionPost_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBookNo.Text) && !string.IsNullOrEmpty(hdnLineNo.Value))
            {
                try
                {
                    SOAPServices.PostAccessionList(txtBookNo.Text, Convert.ToInt32(hdnLineNo.Value), Session["SessionCompanyName"] as string);
                    Alert.ShowAlert(this, "s", "Posted Successfully.");
                }
                catch (Exception ex)
                {
                    string message = string.Format("Message: {0}\\n\\n", ex.Message);
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
                }
            }
        }

        private void BindVendorDropdown()
        {
            ddlVendor.DataSource = ODataServices.GetVendorList(Session["SessionCompanyName"] as string);
            ddlVendor.DataTextField = "Name";
            ddlVendor.DataValueField = "No";
            ddlVendor.DataBind();
            ddlVendor.Items.Insert(0, new ListItem("Select", "NA"));
        }
    }
}