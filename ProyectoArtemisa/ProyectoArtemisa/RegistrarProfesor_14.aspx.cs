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
    public partial class RegistrarProfesor_14 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                limpiarForm();
            }
        }

        protected void limpiarForm()
        {
            txt_apellido.Text = string.Empty;
            txt_nombre.Text = string.Empty;
        }

        //Eventos del form
        protected void btn_registrar_Click(object sender, EventArgs e)
        {
            try
            {
                ProfesorEntidad prof = new ProfesorEntidad();
                prof.apellido = txt_apellido.Text;
                prof.nombre = txt_nombre.Text;
                ProfesorDao.RegistrarProfesor(prof);
                limpiarForm();
                //Agregar boton emergente
            }
            catch
            {
                //Agregar boton emergente
            }
        }

        protected void btn_salir_Click(object sender, EventArgs e)
        {
            //Response redirect al form anterior
        }
    }
}