using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using BaseDeDatos;
using Negocio;
namespace ProyectoArtemisa
{
    public partial class RegistarLibro_2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarForm();
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

        //Cargar grilla carrera dependiendo la materia seleccionada
        protected void CargarGrilla(int idMateria)
        {
            dgv_carrerasLibro.DataSource = CarreraDao.ConsultarCarreraXMateria(idMateria);
            dgv_carrerasLibro.DataKeyNames = new string[] { "idCarrera" };
            dgv_carrerasLibro.DataBind();
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

        //Seleccion de item combo Materia
        protected void ddl_materiasLibro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrilla(Convert.ToInt32(ddl_materiasLibro.SelectedValue));
            btn_registrarCarrera.Visible = true;
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
            if (LibroDao.VerificarCodigoBarra(txt_codgoBarra.Text))
            {
                if (Page.IsValid)
                {
                    if (PilaForms.pila.Peek().Equals("Default.aspx"))
                    {
                        LibroDao.RegistrarLibro(CrearObjetoLibro());
                        LimpiarForm();
                    }
                    else
                    {
                        LibroDao.ModificarLibro(CrearObjetoLibro());
                        Response.Redirect(PilaForms.DevolverForm());
                    }
                }
            }
            else
            {
                Response.Write("<script>window.alert('El código de barra ingresado ya esta cargado');</script>");
            }

        }

        //Registrar nueva Universidad
        protected void btn_registrarUniversidad_Click(object sender, EventArgs e)
        {
            GuardarForm();
            PilaForms.AgregarForm("RegistarLibro_2.aspx");
            Response.Redirect("RegistrarUniversidad_69.aspx");
        }

        //Registrar nueva Facultad
        protected void btn_registrarFacultad_Click(object sender, EventArgs e)
        {
            GuardarForm();
            PilaForms.AgregarForm("RegistarLibro_2.aspx");
            Response.Redirect("RegistrarFacultad_65.aspx");
        }

        //Registrar nueva Materia
        protected void btn_registrarMateria_Click(object sender, EventArgs e)
        {
            GuardarForm();
            PilaForms.AgregarForm("RegistarLibro_2.aspx");
            Response.Redirect("RegistrarMateria_6.aspx");
        }

        //Registrar nueva Carrera
        protected void btn_registrarCarrera_onClick(object sender, EventArgs e)
        {
            GuardarForm();
            PilaForms.AgregarForm("RegistarLibro_2.aspx");
            Response.Redirect("RegistrarCarrera_10.aspx");
        }

        //Registrar nueva Editorial
        protected void btn_registrarEditorial_onClick(object sender, EventArgs e)
        {
            GuardarForm();
            PilaForms.AgregarForm("RegistarLibro_2.aspx");
            Response.Redirect("RegistrarEditorial_22.aspx");
        }

        //Boton cancelar
        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            LimpiarVariablesForm();
            Response.Redirect(PilaForms.DevolverForm());
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
            libro.descripcionLibro = txt_descripcionLibro.Text;
            libro.cantidadHojasLibro = int.Parse(txt_cantidadHojasLibro.Text);
            libro.codigoBarraLibro = txt_codgoBarra.Text;
            libro.idEditorial = int.Parse(ddl_editorialLibro.SelectedValue.ToString());
            //Estado no esta, se inicializa en null por defecto
            libro.precioLibro = float.Parse(txt_precioLibro.Text);
            //Stock no esta, se inicializa en 0 por defecto

            return libro;
        }

        /// <summary>
        /// Inicializa el form
        /// </summary>
        protected void LimpiarForm()
        {
            txt_cantidadHojasLibro.Text = "";
            txt_codgoBarra.Text = "";
            txt_descripcionLibro.Text = "";
            txt_nombreAutorLibro.Text = "";
            txt_nombreDelLibro.Text = "";
            txt_precioLibro.Text = "";
            cargarComboUniversidad();
            cargarComboEditorial();
            ddl_facultadesLibro.SelectedIndex = 0;
            ddl_materiasLibro.SelectedIndex = 0;
        }

        /// <summary>
        /// Guardar el contenido del form en variables globales
        /// </summary>
        protected void GuardarForm()
        {
            Session["codigoBarra"] = txt_codgoBarra.Text;
            Session["nombreApunte"] = txt_nombreDelLibro.Text;
            Session["idUniversidad"] = ddl_universidadesLibro.SelectedIndex;
            Session["idFacultad"] = ddl_facultadesLibro.SelectedIndex;
            Session["idMateria"] = ddl_materiasLibro.SelectedIndex;
            Session["nombreAutor"] = txt_nombreAutorLibro.Text;
            Session["idEditorial"] = ddl_editorialLibro.SelectedIndex;
            Session["cantidadHojas"] = txt_cantidadHojasLibro.Text;
            Session["precionImpreso"] = txt_precioLibro.Text;
            Session["descripcion"] = txt_descripcionLibro.Text;
        }

        /// <summary>
        /// Cargar los datos del form por defecto o que se encuentren guardados en varaibles globales
        /// </summary>
        protected void CargarForm()
        {
            txt_nombreDelLibro.Text = Session["nombreApunte"].ToString();
            cargarComboUniversidad();
            if (Session["idUniversidad"] != null)
            {
                ddl_universidadesLibro.SelectedIndex = int.Parse(Session["idUniversidad"].ToString());
                cargarComboFacultad(Convert.ToInt32(ddl_universidadesLibro.SelectedValue));
                if (Session["idFacultad"] != null)
                {
                    ddl_facultadesLibro.SelectedIndex = int.Parse(Session["idFacultad"].ToString());
                    cargarComboMaterias(Convert.ToInt32(ddl_facultadesLibro.SelectedValue));
                    if (Session["idMateria"] != null)
                    {
                        ddl_materiasLibro.SelectedIndex = int.Parse(Session["idMateria"].ToString());
                        CargarGrilla(Convert.ToInt32(ddl_materiasLibro.SelectedValue));
                        btn_registrarCarrera.Visible = true;
                    }
                }
            }
            txt_nombreAutorLibro.Text = Session["nombreAutor"].ToString();
            cargarComboEditorial();
            if (Session["idEditorial"] != null)
            { ddl_editorialLibro.SelectedIndex = int.Parse(Session["idEditorial"].ToString()); }
            txt_cantidadHojasLibro.Text = Session["cantidadHojas"].ToString();
           txt_descripcionLibro.Text = Session["descripcion"].ToString();
        }

        /// <summary>
        /// Inicializa las variables globales
        /// </summary>
        protected void LimpiarVariablesForm()
        {
            Session["codigoBarra"] = "";
            Session["nombreApunte"] = "";
            Session["idUniversidad"] = null;
            Session["idFacultad"] = null;
            Session["idMateria"] = null;
            Session["nombreAutor"] = "";
            Session["idEditorial"] = null;
            Session["cantidadHojas"] = "";
            Session["precionImpreso"] = "";
            Session["descripcion"] = "";
        }




        
        

    }
}