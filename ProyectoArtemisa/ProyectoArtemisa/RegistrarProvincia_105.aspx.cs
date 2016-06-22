using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using BaseDeDatos;
namespace ProyectoArtemisa
{
    public partial class RegistrarProvincia_105 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_registrar_Click(object sender, EventArgs e)
        {
            ProvinciaEntidad provincia = new ProvinciaEntidad();
            provincia.nombreProvincia = txt_nombreProvincia.Text;
            ProvinciaDao.RegistrarProvincia(provincia);
            if (PilaForms.pila.Peek().Equals("Default.aspx"))
            {
                LimpiarForm();
            }
            else
            {
                Response.Redirect(PilaForms.DevolverForm());
            }
        }

        protected void btn_salir_Click(object sender, EventArgs e)
        {
            Response.Redirect(PilaForms.DevolverForm());
        }

        protected void LimpiarForm()
        {
            txt_nombreProvincia.Text = "";
        }

        
        
    }
}