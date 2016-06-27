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
                if((bool)Session["modificarCarrera"])
                { CargarUnaCarreraEnElForm(CarreraDao.ConsultarUnaCarrera((int)Session["idCarrera"])); }
                CargarForm();
            }
        }

        //Registrar un nueva Universidad
        protected void btn_registrarUniversidad_onClick(object sender, EventArgs e)
        {
            PilaForms.AgregarForm("RegistrarCarrera_10.aspx");
            Response.Redirect("RegistrarUniversidad_69.aspx");
        }

        //Modificar un Universidad
        protected void btn_modificarUniversidad_onClick(object sender, EventArgs e)
        {
            Session["idUniversidad"] = ddl_universidad.SelectedValue;
            Session["modificarUniversidad"] = true;
            PilaForms.AgregarForm("RegistrarCarrera_10.aspx");
            Response.Redirect("RegistrarUniversidad_69.aspx");
        }

        //Registrar una nueva Facultad
        protected void btn_registrarFacultad_onClick(object sender, EventArgs e)
        {
            PilaForms.AgregarForm("RegistrarCarrera_10.aspx");
            Response.Redirect("RegistrarFacultad_65.aspx");
        }

        //Modificar una Facultad
        protected void btn_modificarFacultad_onClick(object sender, EventArgs e)
        {
            Session["idFacultad"] = ddl_facultad.SelectedValue;
            Session["modificarFacultad"] = true;
            PilaForms.AgregarForm("RegistrarCarrera_10.aspx");
            Response.Redirect("RegistrarFacultad_65.aspx");
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            if((bool)Session["modificarCarrera"])
            {
                CarreraEntidad carrera = CrearCarreraDelForm();
                carrera.idCarrera = (int)Session["idCarrera"];
                CarreraDao.ModificarCarrera(CrearCarreraDelForm());
                Session["modificarCarrera"] = false;
            }
            else
            {
                CarreraDao.RegistrarCarrera(CrearCarreraDelForm());
            }
            Response.Redirect(PilaForms.DevolverForm());
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Session["modificarCarrera"] = false;
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
        
        protected void CargarUnaCarreraEnElForm(CarreraEntidad carrera)
        {
            txt_nombreCarrera.Text = carrera.nombreCarrera;
            cargarComboUniversidad();
            ddl_universidad.SelectedValue = FacultadDao.ConsultarIdUniversidadDeUnaFacultad(carrera.idFacultad).ToString();
            cargarComboFacultad(Convert.ToInt32(ddl_universidad.SelectedValue));
            ddl_facultad.SelectedValue = carrera.idFacultad.ToString();

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

        protected CarreraEntidad CrearCarreraDelForm()
        {
            CarreraEntidad carrera = new CarreraEntidad();
            carrera.nombreCarrera = txt_nombreCarrera.Text;
            carrera.idFacultad = Convert.ToInt32(ddl_facultad.SelectedValue);
            return carrera;
        }
}
}