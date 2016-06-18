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
                cargarComboUniversidad();
                cargarComboEditorial();
            }
        }

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

        protected void cargarComboUniversidad()
        {
            ddl_universidadesLibro.DataSource = UniversidadDao.ConsultarUniversidad();
            ddl_universidadesLibro.DataTextField = "nombreUniversidad";
            ddl_universidadesLibro.DataValueField = "idUniversidad";
            ddl_universidadesLibro.DataBind();
            ddl_universidadesLibro.Items.Insert(0, new ListItem("(Universidad)", "0"));
            ddl_universidadesLibro.SelectedIndex = 0;
        }

        protected void cargarComboFacultad(int idUniversidad)
        {
            ddl_facultadesLibro.DataSource = FacultadDao.ConsultarFacultadXUniversidad(idUniversidad);
            ddl_facultadesLibro.DataTextField = "nombreFacultad";
            ddl_facultadesLibro.DataValueField = "idFacultad";
            ddl_facultadesLibro.DataBind();
            ddl_facultadesLibro.Items.Insert(0, new ListItem("(Facultad)", "0"));
            ddl_facultadesLibro.SelectedIndex = 0;
        }

        protected void cargarComboEditorial()
        {
            ddl_editorialLibro.DataSource = EditorialDao.ConsultarEditorial();
            ddl_editorialLibro.DataTextField = "nombreEditorial";
            ddl_editorialLibro.DataValueField = "idEditorial";
            ddl_editorialLibro.DataBind();
            ddl_editorialLibro.Items.Insert(0, new ListItem("(Editorial)", "0"));
            ddl_editorialLibro.SelectedIndex = 0;
        }

        protected void cargarComboMaterias(int idFacultad)
        {
            ddl_materiasLibro.DataSource = MateriaDao.DevolverMateriaXFacultad(idFacultad);
            ddl_materiasLibro.DataTextField = "nombreMateria";
            ddl_materiasLibro.DataValueField = "idMateria";
            ddl_materiasLibro.DataBind();
            ddl_materiasLibro.Items.Insert(0, new ListItem("(Materia)", "0"));
            ddl_materiasLibro.SelectedIndex = 0;
        }


        protected LibroEntidad CrearObjetoLibro()
        {
            LibroEntidad libro = new LibroEntidad();
            libro.nombreLibro = txt_nombreDelLibro.Text;
            libro.autorLibro = txt_nombreAutorLibro.Text;
            //Descripcion no esta
            libro.cantidadHojas = int.Parse(txt_cantidadHojasLibro.Text);
            libro.codigoBarraLibro = txt_codgoBarra.Text;
            libro.idEditorial = int.Parse(ddl_editorialLibro.SelectedValue.ToString());
            //Estado no esta
            libro.precioLibro = float.Parse(txt_precioLibro.Text);
            //Stock no esta

            return libro;
        }


        protected void btn_confirmar_Click(object sender, EventArgs e)
        {
            LibroDao.RegistrarLibro(CrearObjetoLibro());
        }

        protected void ddl_universidadesLibro_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComboFacultad(int.Parse(ddl_universidadesLibro.SelectedValue.ToString()));
        }

        protected void ddl_facultadesLibro_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComboMaterias(int.Parse(ddl_facultadesLibro.SelectedValue.ToString()));
        }

    }
}