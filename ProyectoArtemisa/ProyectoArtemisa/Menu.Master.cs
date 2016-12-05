using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using BaseDeDatos;
namespace ProyectoArtemisa
{
    public partial class Menu : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["nickUsuario"] = HttpContext.Current.User.Identity.Name.ToString();
                UsuarioEntidadQuery usuario = UsuarioDao.ConsultarUnUsuarioPorNick(HttpContext.Current.User.Identity.Name.ToString());
                Session["idUsuario"] = usuario.idUsuario;
                string nombreUsuario = usuario.empleadoQuery.nombreEmpleado;
                string apellidoUsuario = usuario.empleadoQuery.apellidoEmpleado;
                Session["nombreApellidoUsuario"] = nombreUsuario + " " + apellidoUsuario;
                Page.MaintainScrollPositionOnPostBack = true;
            }
            catch(Exception)
            {
                Response.Redirect("Login.aspx");
            }

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
                btn_consultarOrdenImpresion.Visible = false;
                btn_registrarOrdenImpresion.Visible = true;
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
            else if (HttpContext.Current.User.IsInRole("encargado de imprenta"))
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
                btn_consultarOrdenImpresion.Visible = true;
                btn_consultarHistorialOrdenImpresion.Visible = false;
                btn_registrarProveedor.Visible = false;
                btn_registrarUsuario.Visible = true;
                btn_registrarProveedor.Visible = false;
                btn_registrarOrdenImpresion.Visible = false;
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
            if (Session["frenarEnter"] == null)
            {
                LimpiarVariablesGlobales();
                PilaForms.AgregarForm("Default.aspx");
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (!bool.Parse(Session["frenarEnter"].ToString()))
                {
                    LimpiarVariablesGlobales();
                    PilaForms.AgregarForm("Default.aspx");
                    Response.Redirect("Login.aspx");
                }
            }
            Session["frenarEnter"] = false;
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

        protected void btn_registrarCarrera_Click(object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("RegistrarCarrera_10.aspx");
        }

        protected void btn_registrarCategoria_Click(object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("RegistrarCategoria_18.aspx");
        }

        protected void btn_registrarCiudad_Click(object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("RegistrarCiudad_101.aspx");
        }

        protected void btn_registrarFacultad_Click(object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("RegistrarFacultad_65.aspx");
        }

        protected void btn_registrarMateria_Click(object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("RegistrarMateria_6.aspx");
        }

       

        protected void btn_registrarProfesor_Click(object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("RegistrarProfesor_14.aspx");
        }

        protected void btn_registrarProvincia_Click(object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("RegistrarProvincia_105.aspx");
        }

        protected void btn_registrarUniversidad_Click(object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("RegistrarUniversidad_69.aspx");
        }
              

        protected void btn_consultarEditorial_Click(object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("ConsultarEditorial_25.aspx");
        }

        protected void btn_registrarIngrsoLibro_OnClick(object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("~/IngresoLibro.aspx");
        }

        protected void btn_andromeda_Click(object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("http://localhost:8264/Home.aspx");
        }
        protected void btn_consultarIngresoLibro_OnClick(object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("ConsultarHistorialIngresoLibro.aspx");
        }


        //Reportes
        protected void btn_GenerarCierreVenta_143_OnClick(object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("GenerarCierreVenta_143.aspx");
        }

        protected void btn_GenerarComprobanteDeVenta_149_OnClick(object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("GenerarComprobanteDeVenta_149.aspx");
        }

        protected void btn_GenerarIngresoStockLibros_151_OnClick(object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("GenerarIngresoStockLibros_151.aspx");
        }

        protected void btn_GenerarReporteResmasUtilizadas_146_OnClick(object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("GenerarReporteResmasUtilizadas_146.aspx");
        }

        protected void btn_cambiarPass_OnClick(object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("ModificarUsuario.aspx");
        }

        protected void btn_GenerarEstadisticaDeVentas_Click(object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("GenerarEstadisticaDeVenta.aspx");
        }
        protected void btn_registrarOrdenImpresion_OnClick(object sender, EventArgs e)
        {
            LimpiarVariablesGlobales();
            PilaForms.AgregarForm("Default.aspx");
            Response.Redirect("ConsultarOrdenImpresion_126.aspx");
        }





    }
}