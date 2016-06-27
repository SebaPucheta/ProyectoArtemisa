using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using BaseDeDatos;
using Entidades;
using Negocio;
namespace ProyectoArtemisa
{
    public partial class RegistrarMateria_6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((bool)Session["modificarMateria"])
                {
                    CargarUnMateriaEnElForm(MateriaDao.ConsultarMateria((int)Session["idMateria"]));
                }
                else
                {
                    CargarForm();
                }
                
                 
            }
        }

        
        protected void btn_registrarMateria_Click(object sender, EventArgs e)
        {
            
            
            if ((bool)Session["modificarMateria"])
            {
                MateriaEntidad materia = CargarMateriaDesdeForm();
                materia.idMateria = (int)Session["idMateria"];
                Session["modificarMateria"] = false;
                MateriaDao.ModificarMateria(materia);
            }
            else
            {
                MateriaDao.RegistrarMateria(CargarMateriaDesdeForm());    
            }
            Response.Redirect(PilaForms.DevolverForm());
        }
        
        protected void btn_cancelarMateria_Click(object sender, EventArgs e)
        {
            Session["modificarMateria"] = false;
            Response.Redirect(PilaForms.DevolverForm());
        }
        
        protected MateriaEntidad CargarMateriaDesdeForm()
        {
            MateriaEntidad materia = new MateriaEntidad();
            materia.descripcionMateria = txt_descripcionMateriaLibro.Text;
            materia.nivelCursado = Convert.ToInt32(txt_nivelCursadoMateria.Text);
            materia.nombreMateria = txt_nombreMateriaLibro.Text;
            materia.listaCarreras = CargarCarrera();

            return materia;

        }

        protected List<CarreraEntidad> CargarCarrera()
        {
            List<CarreraEntidad> listaCarrera = new List<CarreraEntidad>();

            foreach ( GridViewRow fila in ggv_grillaCarrerasMateria.Rows )
            {

                CheckBox seleccion = ((CheckBox)fila.FindControl("chk_seleccionado"));
                if(seleccion.Checked)
                {
                    CarreraEntidad carrera= new CarreraEntidad();
                    carrera.idCarrera = Convert.ToInt32(fila.Cells[0].Text);
                    carrera.nombreCarrera = fila.Cells[1].Text;
                    listaCarrera.Add(carrera);
                }
            }

            return listaCarrera;
        }

        protected void btn_registrarCarrera_onClick(object sender, EventArgs e)
        {
            PilaForms.AgregarForm("RegistrarMateria_6.aspx");
            Response.Redirect("RegistrarCarrera_10.aspx");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //Metodos para cargar los combos y grilla
        //Cargar combo Universidad
        protected void CargarComboUniversidad()
        {
            ddl_universidadMateria.DataSource = UniversidadDao.ConsultarUniversidad();
            ddl_universidadMateria.DataTextField = "nombreUniversidad";
            ddl_universidadMateria.DataValueField = "idUniversidad";
            ddl_universidadMateria.DataBind();
            ddl_universidadMateria.Items.Insert(0, new ListItem("(Universidad)", "0"));
            ddl_universidadMateria.SelectedIndex = 0;
        }

        //Cargar combo Facultad apartir de la universidad selecionada
        protected void CargarComboFacultad(int idUniversidad)
        {
            ddl_facultadMateria.DataSource = FacultadDao.ConsultarFacultadXUniversidad(idUniversidad);
            ddl_facultadMateria.DataTextField = "nombreFacultad";
            ddl_facultadMateria.DataValueField = "idFacultad";
            ddl_facultadMateria.DataBind();
            ddl_facultadMateria.Items.Insert(0, new ListItem("(Facultad)", "0"));
            ddl_facultadMateria.SelectedIndex = 0;
        }

        public void LimpiarForm()
        {
            txt_descripcionMateriaLibro.Text = "";
            txt_nivelCursadoMateria.Text = "";
            txt_nombreMateriaLibro.Text = "";
        }

        protected void CargarUnMateriaEnElForm(MateriaEntidad materia)
        {
            txt_descripcionMateriaLibro.Text = materia.descripcionMateria;
            txt_nivelCursadoMateria.Text = materia.nivelCursado.ToString();
            txt_nombreMateriaLibro.Text = materia.nombreMateria;
            CargarComboUniversidad();
            ddl_universidadMateria.SelectedValue=FacultadDao.ConsultarIdUniversidadDeUnaFacultad(MateriaDao.DevolverIdFacultadDeUnaMateria(materia.idMateria)).ToString();
            CargarComboFacultad(Convert.ToInt32(ddl_universidadMateria.SelectedValue));
            ddl_facultadMateria.SelectedValue = MateriaDao.DevolverIdFacultadDeUnaMateria(materia.idMateria).ToString();
            CargarGrilla();
        }

        public void CargarForm()
        {
            CargarComboUniversidad();
            if (Session["idUniversidad"] != null)
            {
                ddl_universidadMateria.SelectedValue = Session["idUniversidad"].ToString();
                CargarComboFacultad(Convert.ToInt32(ddl_universidadMateria.SelectedValue));
                if (Session["idFacultad"] != null)
                {
                    ddl_facultadMateria.SelectedValue= Session["idFacultad"].ToString();
                    CargarGrilla(); 
                }
            }
        }
        protected void btn_registrarUniversidad_onClick(object sender, EventArgs e)
        {
            PilaForms.AgregarForm("RegistrarMateria_6.aspx");
            Response.Redirect("RegistrarUniversidad_69.aspx");
        }

        protected void btn_modificarUniversidad_onClick(object sender, EventArgs e)
        {
            Session["idUniversidad"] = ddl_universidadMateria.SelectedValue;
            Session["modificarUniversidad"] = true;
            PilaForms.AgregarForm("RegistrarMateria_6.aspx");
            Response.Redirect("RegistrarUniversidad_69.aspx");
        }
        protected void btn_registrarFacultad_onClick(object sender, EventArgs e)
        {
            PilaForms.AgregarForm("RegistrarMateria_6.aspx");
            Response.Redirect("RegistrarFacultad_65.aspx");
        }

        protected void btn_modificarFacultad_onClick(object sender, EventArgs e)
        {
            Session["idFacultad"] = ddl_facultadMateria.SelectedValue;
            Session["modificarFacultad"] = true;
            PilaForms.AgregarForm("RegistrarMateria_6.aspx");
            Response.Redirect("RegistrarFacultad_65.aspx");
        }

        protected void ddl_universidadMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboFacultad(Convert.ToInt32(ddl_universidadMateria.SelectedValue));
        }

        protected void ddl_facultadMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrilla();
        }
        protected void CargarGrilla()
        {
            DataTable tabla = new DataTable();
            DataRow fila;

            //Creo las columnas de la tabla
            tabla.Columns.Add("df_idCarrera", typeof(int));
            tabla.Columns.Add("df_nombreCarrera", typeof(string));
            tabla.Columns.Add("df_chk_seleccionado", typeof(string));

            List<CarreraEntidad> listaCarrera = CarreraDao.ConsultarCarreraXFacultad(Convert.ToInt32(ddl_facultadMateria.SelectedValue));

            foreach (CarreraEntidad carrera in listaCarrera)
            {
                fila = tabla.NewRow();

                fila[0] = carrera.idCarrera;
                fila[1] = carrera.nombreCarrera;
                fila[2] = false;
                
                tabla.Rows.Add(fila);
            }

            DataView dataView = new DataView(tabla);

            ggv_grillaCarrerasMateria.DataSource = dataView;
            ggv_grillaCarrerasMateria.DataBind();
        }
    }
}