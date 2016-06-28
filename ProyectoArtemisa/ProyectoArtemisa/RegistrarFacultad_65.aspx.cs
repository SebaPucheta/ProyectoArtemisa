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
    public partial class RegistrarFacultad_65 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if ((bool)Session["modificarFacultad"])
                {
                    CargarUnaFacultadEnElForm(FacultadDao.ConsultarUnaFacultad((int)Session["idFacultad"]));
                }
                else
                {
                    CargarComboUniversidad();
                    CargarComboProvincia();
                    if (Session["idUniversidad"] != null)
                    {
                        ddl_universidadFacultad.SelectedValue = Session["idUniversidad"].ToString();
                    }
                }
            }
        }

        protected void CargarComboUniversidad()
        {
            ddl_universidadFacultad.DataSource = UniversidadDao.ConsultarUniversidad();
            ddl_universidadFacultad.DataTextField = "nombreUniversidad";
            ddl_universidadFacultad.DataValueField = "idUniversidad";
            ddl_universidadFacultad.DataBind();
            ddl_universidadFacultad.Items.Insert(0, new ListItem("(Universidad)", "0"));
            ddl_universidadFacultad.SelectedIndex = 0;
        }

        protected void CargarComboProvincia()
        {
            ddl_provincia.DataSource = ProvinciaDao.ConsultarProvincias();
            ddl_provincia.DataTextField = "nombreProvincia";
            ddl_provincia.DataValueField = "idProvincia";
            ddl_provincia.DataBind();
            ddl_provincia.Items.Insert(0, new ListItem("(Provincia)", "0"));
            ddl_provincia.SelectedIndex = 0;
        }

        protected void CargarComboCiudad(int idProvincia)
        {
            ddl_ciudad.DataSource = CiudadDao.ConsultarCiudad(idProvincia);
            ddl_ciudad.DataTextField = "nombreciudad";
            ddl_ciudad.DataValueField = "idCiudad";
            ddl_ciudad.DataBind();
            ddl_ciudad.Items.Insert(0, new ListItem("(Ciudad)", "0"));
            ddl_ciudad.SelectedIndex = 0;
        }
        protected void ddl_provinciaApunte_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboCiudad(Convert.ToInt32(ddl_provincia.SelectedValue));
        }

        protected  FacultadEntidad CargarFacultadDesdeForm()
        {
            FacultadEntidad facultad = new FacultadEntidad();
            facultad.idCiudad =Convert.ToInt32(ddl_ciudad.SelectedValue);
            facultad.idUniversidad = Convert.ToInt32(ddl_universidadFacultad.SelectedValue);
            facultad.nombreFacultad = txt_nombre.Text;
            return facultad;
        }

        protected void LimpiarForm()
        {
            txt_nombre.Text = "";
            CargarComboUniversidad();
            CargarComboProvincia();
            ddl_ciudad.SelectedIndex = 0;
        }

        protected void CargarUnaFacultadEnElForm(FacultadEntidad facultad)
        {
            txt_nombre.Text = facultad.nombreFacultad;
            CargarComboUniversidad();
            ddl_universidadFacultad.SelectedValue = facultad.idUniversidad.ToString();
            CargarComboProvincia();
            ddl_provincia.SelectedValue = CiudadDao.ConsultaridProvinciaDeLaCiudad(facultad.idCiudad).ToString();
            CargarComboCiudad(Convert.ToInt32(ddl_provincia.SelectedValue));
            ddl_provincia.SelectedValue = facultad.idCiudad.ToString();
        }
        protected void btn_registrar_Click(object sender, EventArgs e)
        {

            if ((bool)Session["modificarFacultad"])
            {
                FacultadEntidad facultad = CargarFacultadDesdeForm();
                facultad.idFacultad =(int)Session["idFacultad"];
                FacultadDao.ModificarFacultad(facultad);
                Session["modificarFacultad"]=false;
            }
            else
            {
                FacultadDao.RegistrarFacultad(CargarFacultadDesdeForm());
            }
            Response.Redirect(PilaForms.DevolverForm());
        }

        protected void btn_salir_Click(object sender, EventArgs e)
        {
            Session["modificarFacultad"] = false;
            Response.Redirect(PilaForms.DevolverForm());
        }
        
            protected void btn_registrarUniversidad_onClick(object sender, EventArgs e)
        {
            PilaForms.AgregarForm("RegistrarFacultad_65.aspx");
            Response.Redirect("RegistrarUniversidad_69.aspx");
        }

            
            protected void btn_modificarUniversidad_onClick(object sender, EventArgs e)
            {
                Session["idUniversidad"] = ddl_universidadFacultad.SelectedValue;
                Session["modificarUniversidad"] = true;
                PilaForms.AgregarForm("RegistrarFacultad_65.aspx");
                Response.Redirect("RegistrarUniversidad_69.aspx");
            }
            protected void btn_registrarProvincia_onClick(object sender, EventArgs e)
            {
                PilaForms.AgregarForm("RegistrarFacultad_65.aspx");
                Response.Redirect("RegistrarProvincia_105.aspx");
            }

            protected void btn_modificarProvincia_onClick(object sender, EventArgs e)
            {
                Session["idProvincia"] = ddl_provincia.SelectedValue;
                Session["modificarProvincia"] = true;
                PilaForms.AgregarForm("RegistrarFacultad_65.aspx");
                Response.Redirect("RegistrarProvincia_105.aspx");
            }
            protected void btn_registrarCiudad_onClick(object sender, EventArgs e)
            {
                PilaForms.AgregarForm("RegistrarFacultad_65.aspx");
                Response.Redirect("RegistrarCiudad_101.aspx");
            }
            protected void btn_modificarCiudad_onClick(object sender, EventArgs e)
            {
                Session["idCiudad"] = ddl_ciudad.SelectedValue;
                Session["modificarCiudad"] = true;
                PilaForms.AgregarForm("RegistrarFacultad_65.aspx");
                Response.Redirect("RegistrarCiudad_101.aspx");
            }
    }
}