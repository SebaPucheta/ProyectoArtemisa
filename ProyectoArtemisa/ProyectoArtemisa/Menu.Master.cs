using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
namespace ProyectoArtemisa
{
	public partial class Menu : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void btn_registrarApunte_OnClick(Object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("RegistrarApunte_26.aspx");
        }

        protected void btn_registrarLibro_OnClick(Object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("RegistrarLibro_2.aspx");
        }

        protected void btn_modificarPrecioHoja_OnClick(Object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("RegistrarPrecioXHoja_74.aspx");
        }

        protected void LimpiarVariablesGlobales()
        {
            Session["chk_Impreso"] = false;
            Session["chk_Digital"] = false;
            Session["codigoBarra"] = "";
            Session["nombreApunte"] = "";
            Session["ano"] = "";
            Session["idUniversidad"] = null;
            Session["idFacultad"] = null;
            Session["idMateria"] = null;
            Session["nombreAutor"] = "";
            Session["idEditorial"] = null;
            Session["cantidadHojas"] = "";
            Session["precionImpreso"] = "";
            Session["precioDigital"] = "";
            Session["idProfesor"] = null;
            Session["idCategoria"] = null;
            Session["descripcion"] = "";
        }
	}
}