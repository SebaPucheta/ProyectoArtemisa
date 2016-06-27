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
    public partial class RegistrarCategoria_18 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["modificarCategoria"])
            {
                txt_nombreCategoria.Text = CategoriaDao.ConsultarUnaCategoria((int)Session["idCategoria"]).nombreCategoria;
            }
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            CategoriaEntidad categoria = new CategoriaEntidad();
            categoria.nombreCategoria = txt_nombreCategoria.Text;

            if ((bool)Session["modificarCategoria"])
            {
                categoria.idCategoria = (int)Session["idCategoria"];
                CategoriaDao.ModificarCategoria(categoria);
                Session["modificarCategoria"] = false;
            }
            else
            {
                CategoriaDao.RegistrarCategoria(categoria);
            }
            Response.Redirect(PilaForms.DevolverForm());
        }
        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Session["modificarCategoria"] = false;
            Response.Redirect(PilaForms.DevolverForm());
        }
        

        protected void LimpiarForm()
        {
            txt_nombreCategoria.Text = ""; 
        }

    }
}