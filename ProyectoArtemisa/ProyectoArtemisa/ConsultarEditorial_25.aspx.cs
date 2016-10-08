using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseDeDatos;
using Entidades;
using Negocio;
using System.Data;
using BaseDeDatos;

namespace ProyectoArtemisa
{
    public partial class ConsultarEditorial_25 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarEditorialEnGrilla();
            }
        }


        protected void CargarEditorialEnGrilla()
        {
            dgv_grillaEditorial.DataSource = EditorialDao.ConsultarEditorial();
            dgv_grillaEditorial.DataKeyNames = new string[] { "idEditorial" };
            dgv_grillaEditorial.DataBind();
        }

        
    }
}