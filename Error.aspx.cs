﻿using System;

namespace HRMS
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LblError.Text = Request.QueryString["e"];
        }
    }
}