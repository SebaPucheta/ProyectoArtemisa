using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseDeDatos;
using Entidades;
using Negocio;
namespace ProyectoArtemisa
{
    public partial class RegistrarCarrera_101 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarForm();
            }
        }
        protected void btn_registrarUniversidad_onClick(object sender, EventArgs e)
        {
            PilaForms.AgregarForm("RegistrarCarrera_10.aspx");
            Response.Redirect("RegistrarUniversidad_69.aspx");
        }

        protected void btn_registrarFacultad_onClick(object sender, EventArgs e)
        {
            PilaForms.AgregarForm("RegistrarCarrera_10.aspx");
            Response.Redirect("RegistrarFacultad_65.aspx");
        }
        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            CarreraEntidad carrera = new CarreraEntidad();
            carrera.nombreCarrera = txt_nombreCarrera.Text;
            carrera.idFacultad =Convert.ToInt32(ddl_facultad.SelectedValue);
            CarreraDao.RegistrarCarrera(carrera);
            if (PilaForms.pila.Peek().Equals("Default.aspx")) 
            {
                LimpiarForm();
            }
            else
            {
                Response.Redirect(PilaForms.DevolverForm());
            }
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(PilaForms.DevolverForm());
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

        protected void cargarComboFacultad(int idUniversidad)
        {
            ddl_facultad.DataSource = FacultadDao.ConsultarFacultadXUniversidad(idUniversidad);
            ddl_facultad.DataValueField = "idFacultad";
            ddl_facultad.DataTextField = "nombreFacultad";
            ddl_facultad.DataBind();
            ddl_facultad.Items.Insert(0, new ListItem("(Facultad)", "0"));
            ddl_facultad.SelectedIndex = 0;
        }

        protected void LimpiarForm()
        {
            txt_nombreCarrera.Text = "";
            ddl_facultad.SelectedIndex = 0;
            cargarComboUniversidad();
        }
        protected void ddl_universidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComboFacultad(Convert.ToInt32(ddl_universidad.SelectedValue));
        }

        protected void CargarForm()
        {
            cargarComboUniversidad();
            if (Session["idUniversidad"]!=null)
            {
                ddl_universidad.SelectedValue = Session["idUniversidad"].ToString();
                cargarComboFacultad(Convert.ToInt32(ddl_universidad.SelectedValue));
                if (Session["idFacultad"] != null)
                { ddl_facultad.SelectedValue = Session["idFacultad"].ToString(); }
            }
        }
}
}