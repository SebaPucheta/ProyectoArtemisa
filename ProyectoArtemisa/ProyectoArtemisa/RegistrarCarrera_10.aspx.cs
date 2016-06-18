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
    public partial class RegistrarCarrera_101 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarComboUniversidad();
            }
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            CarreraEntidad carrera = new CarreraEntidad();
            carrera.nombreCarrera = txt_nombreCarrera.Text;           

            CarreraDao.RegistrarCarrera(carrera);


        }

        protected void cargarComboUniversidad()
        {
            ddl_universidad.DataSource = UniversidadDao.ConsultarUniversidad();
            ddl_universidad.DataValueField = "idUniversidad";
            ddl_universidad.DataTextField = "nombreUniversidad";
            ddl_universidad.DataBind();
            ddl_universidad.Items.Insert(0, new ListItem("(Universidad)", "0"));
            ddl_universidad.SelectedIndex = 0;

        }

        protected void cargarComboFacultad()
        {
            ddl_facultad.DataSource = FacultadDao.ConsultarFacultad();
            ddl_facultad.DataValueField = "idFacultad";
            ddl_facultad.DataTextField = "nombreFacultad";
            ddl_facultad.DataBind();
            ddl_facultad.Items.Insert(0, new ListItem("(Facultad)", "0"));
            ddl_facultad.SelectedIndex = 0;
        }

        protected void ddl_universidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComboFacultad();
        }
}
}