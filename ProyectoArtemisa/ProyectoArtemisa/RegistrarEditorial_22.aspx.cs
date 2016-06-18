using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseDeDatos;
using Entidades;

namespace ProyectoArtemisa
{
    public partial class RegistrarEditorial_22 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            //    int idEditorial
            //string nombre
            //string telefono
            //string direccion
            //string email
            //string nombreContacto

            EditorialEntidad editorial = new EditorialEntidad();
            editorial.nombreEditorial = txt_nombreEditorial.Text;
            editorial.nombreContacto = txt_nombreContacto.Text;
            editorial.telefono = txt_telefono.Text;
            editorial.email = txt_email.Text;
            editorial.direccion = txt_direccion.Text;
            //Falta crear el metodo para registrar la editorial.
            //EditorialDao.registrarEditorial(editorial);

        }
    }
}