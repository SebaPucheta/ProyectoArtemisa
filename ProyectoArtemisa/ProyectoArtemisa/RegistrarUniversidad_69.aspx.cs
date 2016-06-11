using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using BaseDeDatos;

namespace ProyectoArtemisa
{
    public partial class RegistrarUniversidad_69 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void limpiarForm()
        {
            txt_nombre.Text = string.Empty;
        }

        protected void btn_registrar_Click(object sender, EventArgs e)
        {
            try
            {
                UniversidadEntidad uni = new UniversidadEntidad();
                uni.nombreUniversidad = txt_nombre.Text;
                UniversidadDao.RegistrarUniversidad(uni);
                limpiarForm();
                //Confiracion
            }
            catch
            {
                //Mensaje
            }

        }

        protected void btn_salir_Click(object sender, EventArgs e)
        {
            //Volver al form anterior
        }
    }
}