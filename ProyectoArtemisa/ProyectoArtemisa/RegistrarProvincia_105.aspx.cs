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
            if (!IsPostBack)
            {
                if ((bool)Session["modificarProvincia"])
                { txt_nombreProvincia.Text = ProvinciaDao.ConsultarProvincia((int)Session["idProvincia"]).nombreProvincia; }
            }
        }

        protected void btn_registrar_Click(object sender, EventArgs e)
        {
            ProvinciaEntidad provincia = new ProvinciaEntidad();
            provincia.nombreProvincia = txt_nombreProvincia.Text;
            ;
            if ((bool)Session["modificarProvincia"])
            {
                provincia.idProvincia = (int)Session["idProvincia"];
                ProvinciaDao.ModificarProvincia(provincia);
                Session["modificarProvincia"] = false;
            }
            else
            {
                ProvinciaDao.RegistrarProvincia(provincia);
            }
            Response.Redirect(PilaForms.DevolverForm());
        }

        protected void btn_salir_Click(object sender, EventArgs e)
        {
            Session["modificarProvincia"] = false;
            Response.Redirect(PilaForms.DevolverForm());
        }

        protected void LimpiarForm()
        {
            txt_nombreProvincia.Text = "";
        }

        
        
    }
}