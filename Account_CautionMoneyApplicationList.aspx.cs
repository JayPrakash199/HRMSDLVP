using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class Account_CautionMoneyApplicationList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var applicationList = ODataServices.GetCautionMoneyApplicationList(Session["SessionCompanyName"] as string);
                if (applicationList.Any())
                {
                    CautionMoneyApplicationListView.DataSource = applicationList;
                    CautionMoneyApplicationListView.DataBind();
                }
            }
        }
    }
}