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
    public partial class RegistrarApunte_26 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ddl_universidadApunte.DataSource = UniversidadDao.ConsultarUniversidad();
                ddl_universidadApunte.DataTextField = "nombreUniversidad";
                ddl_universidadApunte.DataValueField = "idUniversidad";
                ddl_universidadApunte.DataBind();
            }
            
        }

        protected void ddl_universidadApunte_OnSelectedIndexChanged(object sender,System.EventArgs e)
        {
            ddl_facultadApunte.DataSource= FacultadDao.Consultar    
        }


    }
}