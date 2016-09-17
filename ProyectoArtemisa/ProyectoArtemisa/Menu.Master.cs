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
            Page.MaintainScrollPositionOnPostBack = true;

            if (HttpContext.Current.User.IsInRole("administrador"))
            {
                btn_usuario.Text = "[" + HttpContext.Current.User.Identity.Name.ToString() + "]";

                btn_registrarApunte.Visible = true;
                btn_registrarLibro.Visible = true;
                btn_modificarPrecioHoja.Visible = true;
                btn_consultarItem.Visible = true;
                btn_registrarEditorial.Visible = true;
                btn_consultarPrecioXHoja.Visible = true;
                btn_ventaXVentanilla.Visible = true;
                btn_consultarHistorialFactura.Visible = true;
                btn_consultarOrdenImpresion.Visible = true;
                btn_consultarHistorialOrdenImpresion.Visible = true;
                btn_registrarProveedor.Visible = true;
                btn_registrarUsuario.Visible = true;
                btn_registrarProveedor.Visible = true;
            }
            else if (HttpContext.Current.User.IsInRole("alumno"))
            {
                btn_usuario.Text = "[" + HttpContext.Current.User.Identity.Name.ToString() + "]";

                btn_registrarApunte.Visible = false;
                btn_registrarLibro.Visible = false;
                btn_modificarPrecioHoja.Visible = false;
                btn_consultarItem.Visible = true;
                btn_registrarEditorial.Visible = true;
                btn_consultarPrecioXHoja.Visible = false;
                btn_ventaXVentanilla.Visible = false;
                btn_consultarHistorialFactura.Visible = false;
                btn_consultarOrdenImpresion.Visible = false;
                btn_consultarHistorialOrdenImpresion.Visible = false;
                btn_registrarProveedor.Visible = false;
                btn_registrarUsuario.Visible = true;
                btn_registrarProveedor.Visible = false;
            }
            else
            {
                btn_usuario.Text = "[" + "]";

                btn_registrarApunte.Visible = false;
                btn_registrarLibro.Visible = false;
                btn_modificarPrecioHoja.Visible = false;
                btn_consultarItem.Visible = true;
                btn_registrarEditorial.Visible = true;
                btn_consultarPrecioXHoja.Visible = false;
                btn_ventaXVentanilla.Visible = false;
                btn_consultarHistorialFactura.Visible = false;
                btn_consultarOrdenImpresion.Visible = false;
                btn_consultarHistorialOrdenImpresion.Visible = false;
                btn_registrarProveedor.Visible = false;
                btn_registrarUsuario.Visible = true;
                btn_registrarProveedor.Visible = false;
            }
        }

        protected void btn_usuario_OnClick(Object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("Login.aspx");
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
            Response.Redirect("RegistrarProveedor.aspx");
        }

        protected void btn_consultarProveedor_OnClick(Object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("ConsultarProveedor.aspx");
        }

        protected void btn_registrarUsuario_OnClick(Object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("RegistrarUsuario.aspx");
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