using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using BaseDeDatos;
using Entidades;
using System.Web.Script.Services;
using System.Web.Services;

namespace ProyectoArtemisa
{
    public partial class RegistrarApunte_26 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
               
            }
            
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        protected List<string> DevolverUniversidadXParametro(string parametro, int count)
        {
            List<string> nombreUniversidades = new List<string>();
            foreach ( UniversidadEntidad universidades in UniversidadDao.ConsultarUniversidadXParametro(parametro))
            {
                nombreUniversidades.Add(universidades.nombreUniversidad);
            }

            return nombreUniversidades;
        }

        protected void btn_registrarUniversidad_onClick(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarUniversidad_69.aspx");
        }

        protected void btn_registrarProfesor_onClick(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarProfesor_14.aspx");
        }

        protected void btn_registrarCarrera_onClick(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarCarrera_10.aspx");
        }

        protected void btn_registrarCategoria_onClick(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarCategoria_18.aspx");
        }
        protected void btn_registrarMateria_onClick(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarMateria_6.aspx");
        }
    }
}