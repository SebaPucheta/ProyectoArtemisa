using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using BaseDeDatos;
using Negocio;

namespace ProyectoArtemisa
{
    public partial class ConsultarPrecioPorHoja_77 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        protected void CargarGrilla()
        {
            dgv_grillaPrecio.DataSource = PrecioXHojaDao.ConsultarPrecioXHoja();
            dgv_grillaPrecio.DataBind();
        }
    }
}