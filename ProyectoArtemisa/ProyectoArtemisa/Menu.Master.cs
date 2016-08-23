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

        protected void btn_consultarItem_OnClick(Object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("ConsultarLibroApunte.aspx");
        }
        protected void btn_consultarEditorial_OnClick(Object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("RegistrarEditorial_22.aspx");
        }
        protected void btn_registrarLibro_OnClick(Object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("RegistarLibro_2.aspx");
        }

        protected void btn_modificarPrecioHoja_OnClick(Object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("RegistrarPrecioXHoja_74.aspx");
        }

        protected void btn_consultarPrecioXHoja_OnClick(Object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("ConsultarPrecioPorHoja_77.aspx");
        }

        protected void btn_ventaXVentanilla_OnClick(Object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("RegistrarVentaVentanilla_128.aspx");
        }

        protected void btn_consultarHistorialFactura_OnClick(Object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("ConsultarHistorialFactura_130.aspx");
        }

        protected void btn_consultarOrdenImpresion_OnClick(Object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("ConsultarOrdenImpresion_126.aspx");
        }

        protected void btn_consultarHistorialOrdenImpresion_OnClick(Object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("ConsultarHistorialOrdenImpresion_129.aspx");
        }

        protected void btn_registrarProveedor_OnClick(Object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("RegistrarProveedor_132.aspx");
        }

        protected void btn_consultarProveedor_OnClick(Object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("ConsultarProveedor_134.aspx");
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