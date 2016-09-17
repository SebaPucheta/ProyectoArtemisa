using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using Negocio;

namespace ProyectoArtemisa
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            PilaForms.Inicializar();
            PilaForms.AgregarForm("Default.aspx");
            
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //IDs
            Session["idApunte"] = null;
            Session["idLibro"] = null;
            Session["idCiudad"] = null;
            Session["idProvincia"] = null;
            Session["idCarrera"] = null;
            Session["idProveedor"] = null;

            //Banderas de Modificar
            Session["modificarUniversidad"] = false;
            Session["modificarFacultad"] = false;
            Session["modificarMateria"] = false;
            Session["modificarCarrera"] = false;
            Session["modificarProvincia"] = false;
            Session["modificarCiudad"] = false;
            Session["modificarEditorial"] = false;
            Session["modificarCategoria"] = false;
            Session["modificarProfesor"] = false;
            Session["modificarProveedor"] = false;
            
            
            //Banderas de orden de impresion
            Session["agregarOrden"] = false;

            //Bandera de venta por ventanilla
            Session["agregarDetalle"] = false;
            Session["precioUnitario"] = null;
            Session["tablaDetalles"] = null;
            Session["fecha"] = "";

            //Form Apunte
            Session["chk_Impreso"] = false;
            Session["chk_Digital"] = false;
            Session["codigoBarra"] = "";
            Session["nombreApunte"] = "";
            Session["ano"] = "";
            Session["idUniversidad"] = null;
            Session["idFacultad"] = null;
            Session["idMateria"] = null;
            Session["idEditorial"] = null;
            Session["cantidadHojas"] = "";
            Session["precionImpreso"] = "";
            Session["precioDigital"] = "";
            Session["idProfesor"] = null;
            Session["idCategoria"] = null;
            Session["descripcion"] = "";
            Session["stock"] = "";

            Session["objetoApunteEntidad"] = "";
            Session["objetoLibroEntidad"] = "";
            
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}