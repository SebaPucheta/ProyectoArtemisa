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
    public class RegistrarCategoria_18 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            CategoriaEntidad categoria = new CategoriaEntidad();
            categoria.nombre = txt_nombreCategoria.Text;

            CategoriaDao.registrarCategoria(categoria);
        }
    }
}