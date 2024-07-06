using HRMSODATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS
{
    public partial class ListViewWithHeaderFilter : System.Web.UI.Page
    {
        private static List<MyData> DataSource = new List<MyData>
        {
            new MyData { CompanyName = "japan", Country = "Germany", City = "Berlin", UnitPrice = 50, Quantity = 5, Discount = 0.05, Total = 250 },
            new MyData { CompanyName = "America", Country = "Germany1", City = "Berlin1", UnitPrice = 501, Quantity = 51, Discount = 0.051, Total = 2510 },
             new MyData { CompanyName = "Adstadam ", Country = "Germany", City = "Berlin", UnitPrice = 50, Quantity = 5, Discount = 0.05, Total = 250 },
            new MyData { CompanyName = "United Kingdom", Country = "Germany1", City = "Berlin1", UnitPrice = 501, Quantity = 51, Discount = 0.051, Total = 2510 },
 new MyData { CompanyName = "turkee", Country = "Germany", City = "Berlin", UnitPrice = 50, Quantity = 5, Discount = 0.05, Total = 250 },
            new MyData { CompanyName = "Pakistan ", Country = "Germany1", City = "Berlin1", UnitPrice = 501, Quantity = 51, Discount = 0.051, Total = 2510 },
 new MyData { CompanyName = "Florida", Country = "Germany", City = "Berlin", UnitPrice = 50, Quantity = 5, Discount = 0.05, Total = 250 },
            new MyData { CompanyName = "alabama ", Country = "Germany1", City = "Berlin1", UnitPrice = 501, Quantity = 51, Discount = 0.051, Total = 2510 },
 new MyData { CompanyName = "Finland", Country = "Germany", City = "Berlin", UnitPrice = 50, Quantity = 5, Discount = 0.05, Total = 250 },
            new MyData { CompanyName = "Afganistan ", Country = "Germany1", City = "Berlin1", UnitPrice = 501, Quantity = 51, Discount = 0.051, Total = 2510 },
 new MyData { CompanyName = "Srilanka", Country = "Germany", City = "Berlin", UnitPrice = 50, Quantity = 5, Discount = 0.05, Total = 250 },
            new MyData { CompanyName = " England", Country = "Germany1", City = "Berlin1", UnitPrice = 501, Quantity = 51, Discount = 0.051, Total = 2510 },

            // Add more sample data here
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindListView(DataSource);
                BindFilters();
            }
        }

        private void BindListView(List<MyData> data)
        {
            lvData.DataSource = data;
            lvData.DataBind();
        }

        private void BindFilters()
        {
            var companyList = DataSource.Select(x => x.CompanyName).Distinct().ToList();


            var chkCompanyFilter = (CheckBoxList)lvData.FindControl("chkCompanyFilter");
            if (chkCompanyFilter != null)
            {
                chkCompanyFilter.DataSource = companyList;
                chkCompanyFilter.DataBind();
            }

            // Bind Country Filter
            var countryList = DataSource.Select(x => x.Country).Distinct().ToList();
            var chkCountryFilter = (CheckBoxList)lvData.FindControl("chkCountryFilter");
            if (chkCountryFilter != null)
            {
                chkCountryFilter.DataSource = countryList;
                chkCountryFilter.DataBind();
            }

        }

        protected void btnApplyCompanyFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected void btnApplyCountryFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            var filteredData = DataSource.AsQueryable();

            // Apply Company Filter
            var chkCompanyFilter = (CheckBoxList)lvData.FindControl("chkCompanyFilter");
            if (chkCompanyFilter != null)
            {
                var selectedCompanies = chkCompanyFilter.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedCompanies.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedCompanies.Contains(x.CompanyName));
                }
            }

            // Apply Country Filter
            var chkCountryFilter = (CheckBoxList)lvData.FindControl("chkCountryFilter");
            if (chkCountryFilter != null)
            {
                var selectedCountries = chkCountryFilter.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();
                if (selectedCountries.Count > 0)
                {
                    filteredData = filteredData.Where(x => selectedCountries.Contains(x.Country));
                }
            }

            BindListView(filteredData.ToList());
        }
    }

    public class MyData
    {
        public string CompanyName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
        public decimal Total { get; set; }
    }
}
