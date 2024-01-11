using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class CategoryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IList<HRMSODATA.ItemCategories> BookIssueList = ODataServices.GetItemCategoriesList();

                if (BookIssueList != null)
                {
                    ItemCategoryListVew.DataSource = BookIssueList;
                    ItemCategoryListVew.DataBind();
                }
            }
        }

        protected void btnItemcategorySearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtItemCategorySearch.Text))
            {
                var ItemCategoryList = ODataServices.GetFilterItemCategoriesList(txtItemCategorySearch.Text);
                if (ItemCategoryList != null)
                {
                    ItemCategoryListVew.DataSource = ItemCategoryList;
                    ItemCategoryListVew.DataBind();
                }
            }
        }
    }
}