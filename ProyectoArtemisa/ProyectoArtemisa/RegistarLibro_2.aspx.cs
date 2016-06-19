using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using BaseDeDatos;
namespace ProyectoArtemisa
{
    public partial class RegistarLibro_2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //cargarComboUniversidad();
                //cargarComboEditorial();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Metodos para cargar combos
        //Cargar combo Universiada
        protected void cargarComboUniversidad()
        {
            ddl_universidadesLibro.DataSource = UniversidadDao.ConsultarUniversidad();
            ddl_universidadesLibro.DataTextField = "nombreUniversidad";
            ddl_universidadesLibro.DataValueField = "idUniversidad";
            ddl_universidadesLibro.DataBind();
            ddl_universidadesLibro.Items.Insert(0, new ListItem("(Universidad)", "0"));
            ddl_universidadesLibro.SelectedIndex = 0;
        }

        //Cargar combo Facultad
        protected void cargarComboFacultad(int idUniversidad)
        {
            ddl_facultadesLibro.DataSource = FacultadDao.ConsultarFacultadXUniversidad(idUniversidad);
            ddl_facultadesLibro.DataTextField = "nombreFacultad";
            ddl_facultadesLibro.DataValueField = "idFacultad";
            ddl_facultadesLibro.DataBind();
            ddl_facultadesLibro.Items.Insert(0, new ListItem("(Facultad)", "0"));
            ddl_facultadesLibro.SelectedIndex = 0;
        }

        //Cargar combo Editorial
        protected void cargarComboEditorial()
        {
            ddl_editorialLibro.DataSource = EditorialDao.ConsultarEditorial();
            ddl_editorialLibro.DataTextField = "nombreEditorial";
            ddl_editorialLibro.DataValueField = "idEditorial";
            ddl_editorialLibro.DataBind();
            ddl_editorialLibro.Items.Insert(0, new ListItem("(Editorial)", "0"));
            ddl_editorialLibro.SelectedIndex = 0;
        }

        //Cargar combo Materia
        protected void cargarComboMaterias(int idFacultad)
        {
            ddl_materiasLibro.DataSource = MateriaDao.DevolverMateriaXFacultad(idFacultad);
            ddl_materiasLibro.DataTextField = "nombreMateria";
            ddl_materiasLibro.DataValueField = "idMateria";
            ddl_materiasLibro.DataBind();
            ddl_materiasLibro.Items.Insert(0, new ListItem("(Materia)", "0"));
            ddl_materiasLibro.SelectedIndex = 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Metodos de Eventos
        //Metodos de eventos de seleccion de item de un combo
        //Seleccion de item del combo Universidad
        protected void ddl_universidadesLibro_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComboFacultad(int.Parse(ddl_universidadesLibro.SelectedValue.ToString()));
        }

        //Seleccion de item del combo Universidad
        protected void ddl_facultadesLibro_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComboMaterias(int.Parse(ddl_facultadesLibro.SelectedValue.ToString()));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Metodos de Eventos
        //Metodos de eventos valida que se halla seleccionado de los combos un valor
        protected void ddl_customValidator(object sender, ServerValidateEventArgs e)
        {
            if (int.Parse(e.Value.ToString()) != 0)
            {
                e.IsValid = true;
            }
            else
            {
                e.IsValid = false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Metodos de Eventos
        //Metodos de eventos de botones
        //Boton Confirmar
        protected void btn_confirmar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                LibroDao.RegistrarLibro(CrearObjetoLibro());
            }

        }

        //Registrar nueva Universidad
        protected void btn_registrarUniversidad_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarUniversidad_69.aspx");
        }

        //Registrar nueva Facultad
        protected void btn_registrarFacultad_Click(object sender, EventArgs e)
        {

            UniversidadEntidad universidad = new UniversidadEntidad();
            universidad.idUniversidad = Convert.ToInt32(ddl_universidadesLibro.SelectedValue);
            Session["Universidad"] = universidad;
            Response.Redirect("RegistrarFacultad_65.aspx");
        }

        //Registrar nueva Materia
        protected void btn_registrarMateria_Click(object sender, EventArgs e)
        {

            UniversidadEntidad universidad = new UniversidadEntidad();
            universidad.idUniversidad = Convert.ToInt32(ddl_materiasLibro.SelectedValue);
            Session["Universidad"] = universidad;
            FacultadEntidad facultad = new FacultadEntidad();
            facultad.idFacultad = Convert.ToInt32(ddl_facultadesLibro.SelectedValue);
            Session["Facultad"] = facultad;
            Response.Redirect("RegistrarMateria_6.aspx");
        }

        //Registrar nueva Carrera
        protected void btn_registrarCarrera_onClick(object sender, EventArgs e)
        {
            ApunteEntidad nuevoApunte = new ApunteEntidad();
            nuevoApunte.idMateria = Convert.ToInt32(ddl_materiasLibro.SelectedValue);
            Session["Apunte"] = nuevoApunte;
            Response.Redirect("RegistrarCarrera_10.aspx");
        }

        //Registrar nueva Editorial
        protected void btn_registrarEditorial_onClick(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarEditorial_22.aspx");
        }

        //Boton cancelar
        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
      
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Metodos 
        /// <summary>
        /// Crea un objeto LibroEntidad apartir de los datos que ya hay cargados en el form
        /// </summary>
        /// <returns>LibroEntidad</returns>
        protected LibroEntidad CrearObjetoLibro()
        {
            LibroEntidad libro = new LibroEntidad();
            libro.nombreLibro = txt_nombreDelLibro.Text;
            libro.autorLibro = txt_nombreAutorLibro.Text;
            //Descripcion no esta
            libro.cantidadHojasLibro = int.Parse(txt_cantidadHojasLibro.Text);
            libro.codigoBarraLibro = txt_codgoBarra.Text;
            libro.idEditorial = int.Parse(ddl_editorialLibro.SelectedValue.ToString());
            //Estado no esta
            libro.precioLibro = float.Parse(txt_precioLibro.Text);
            //Stock no esta

            return libro;
        }





        
        

    }
}