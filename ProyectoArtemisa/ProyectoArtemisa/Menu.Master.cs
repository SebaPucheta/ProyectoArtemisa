﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoArtemisa
{
	public partial class Menu : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void btn_registrarApunte_OnClick(Object sender, EventArgs e)
        {
            Response.Redirect("RegistrarApunte_26.aspx");
        }
	}
}