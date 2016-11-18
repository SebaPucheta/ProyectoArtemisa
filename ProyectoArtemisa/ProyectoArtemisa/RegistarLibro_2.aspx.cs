using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using BaseDeDatos;
using Negocio;
using System.Data;
namespace ProyectoArtemisa
{
    public partial class RegistarLibro_2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (PilaForms.pila.Peek().Equals("ConsultarLibroApunte.aspx"))
                {
                    CargarUnLibroEnElForm(LibroDao.ConsultarLibro((int)Session["idLibro"]));
                }
                else
                {
                    CargarForm();
                }
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

        //Seleccion de item del combo Facultad
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
           
                if (Page.IsValid)
                {
                    if (PilaForms.pila.Peek().Equals("Default.aspx"))
                    {
                        if (LibroDao.VerificarCodigoBarra(txt_codgoBarra.Text))
                        {
                            int idLibro = LibroDao.RegistrarLibro(CrearObjetoLibro());
                            if(idLibro!=0)
                            { procesarImagen(idLibro.ToString()); }
                            LimpiarForm();
                        }
                        else
                        {
                            Response.Write("<script>window.alert('El código de barra ingresado ya esta cargado');</script>");
                        }

                    }
                    else
                    {
                        LibroEntidad libro = CrearObjetoLibro();
                        libro.idLibro = (int)Session["idLibro"];
                        LibroDao.ModificarLibro(libro);
                        Response.Redirect(PilaForms.DevolverForm());
                    }
                }
           
        }

        //Boton cancelar
        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            LimpiarVariablesForm();
            Response.Redirect(PilaForms.DevolverForm());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //Metodos de eventos
        //Botones para regitrar y modificar...
        //Registrar nueva Universidad
        protected void btn_registrarUniversidad_Click(object sender, EventArgs e)
        {
            GuardarForm();
            PilaForms.AgregarForm("RegistarLibro_2.aspx");
            Response.Redirect("RegistrarUniversidad_69.aspx");
        }

        //Modificar una Universidad
        protected void btn_modificarUniversidad_Click(object sender, EventArgs e)
        {
            Session["idUniversidad"] = Convert.ToInt32(ddl_universidadesLibro.SelectedValue);
            Session["modificarUniversidad"] = true;
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

        //Modificar una Facultad
        protected void btn_modificarFacultad_Click(object sender, EventArgs e)
        {
            Session["idFacultad"] =Convert.ToInt32(ddl_facultadesLibro.SelectedValue);
            Session["modificarFacultad"] = true;
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

        //Modificar una Materia
        protected void btn_modificarMateria_Click(object sender, EventArgs e)
        {
            Session["idMateria"] = Convert.ToInt32(ddl_materiasLibro.SelectedValue);
            Session["modificarMateria"] = true;
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

        //Modificar una Editorial
        protected void btn_modificarEditorial_onClick(object sender, EventArgs e)
        {
            Session["idEditorial"] = Convert.ToInt32(ddl_editorialLibro.SelectedValue);
            Session["modificarEditorial"] = true;
            GuardarForm();
            PilaForms.AgregarForm("RegistarLibro_2.aspx");
            Response.Redirect("RegistrarEditorial_22.aspx");
        }
        protected void txt_codigoBarra_TextChanged(object sender, EventArgs e)
        { }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //Metodos de eventos
        //Eventos de la grilla
        //Modificar Carrera
        protected void btn_modificarCarrera_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Session["idCarrera"] = (int)dgv_carrerasLibro.SelectedDataKey.Value;
            Session["modificarCarrera"] = true;
            GuardarForm();
            PilaForms.AgregarForm("RegistarLibro_2.aspx");
            Response.Redirect("RegistrarCarrera_10.aspx");
        }

        protected void btn_eliminarMateria_OnRowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            CarreraDao.EliminarCarrera((int)dgv_carrerasLibro.DataKeys[e.RowIndex].Value);
            CargarGrilla(Convert.ToInt32(ddl_materiasLibro.SelectedValue));
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
            libro.idMateria = Convert.ToInt32(ddl_materiasLibro.SelectedValue);
            //Estado no esta, se inicializa en null por defecto
            libro.precioLibro = float.Parse((Math.Round(float.Parse(txt_precioLibro.Text), 2)).ToString());
            libro.stock = int.Parse(txt_stock.Text);

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
            txt_stock.Text = "";
            cargarComboUniversidad();
            cargarComboEditorial();
            ddl_facultadesLibro.SelectedIndex = 0;
            ddl_materiasLibro.SelectedIndex = 0;
            CargarGrilla(0);
        }

        /// <summary>
        /// Guardar el contenido del form en variables globales
        /// </summary>
        protected void GuardarForm()
        {
            Session["codigoBarra"] = txt_codgoBarra.Text;
            Session["nombreApunte"] = txt_nombreDelLibro.Text;
            Session["idUniversidad"] = ddl_universidadesLibro.SelectedValue;
            Session["idFacultad"] = ddl_facultadesLibro.SelectedValue;
            Session["idMateria"] = ddl_materiasLibro.SelectedValue;
            Session["nombreAutor"] = txt_nombreAutorLibro.Text;
            Session["idEditorial"] = ddl_editorialLibro.SelectedValue;
            Session["cantidadHojas"] = txt_cantidadHojasLibro.Text;
            Session["precionImpreso"] = txt_precioLibro.Text;
            Session["descripcion"] = txt_descripcionLibro.Text;
            Session["stock"] = txt_stock.Text;
        }

        /// <summary>
        /// Cargar los datos del form por defecto o que se encuentren guardados en varaibles globales
        /// </summary>
        protected void CargarForm()
        {
            txt_nombreDelLibro.Text = Session["nombreApunte"].ToString();
            txt_codgoBarra.Text = Session["codigoBarra"].ToString();
            txt_stock.Text = Session["stock"].ToString();
            cargarComboUniversidad();
            if (Session["idUniversidad"] != null)
            {
                ddl_universidadesLibro.SelectedValue = Session["idUniversidad"].ToString();
                cargarComboFacultad(Convert.ToInt32(ddl_universidadesLibro.SelectedValue));
                if (Session["idFacultad"] != null)
                {
                    ddl_facultadesLibro.SelectedValue = Session["idFacultad"].ToString();
                    cargarComboMaterias(Convert.ToInt32(ddl_facultadesLibro.SelectedValue));
                    if (Session["idMateria"] != null)
                    {
                        ddl_materiasLibro.SelectedValue = Session["idMateria"].ToString();
                        CargarGrilla(Convert.ToInt32(ddl_materiasLibro.SelectedValue));
                        btn_registrarCarrera.Visible = true;
                    }
                }
                else
                {
                    cargarComboMaterias(0);
                }
            }
            else
            {
                cargarComboFacultad(0);
                cargarComboMaterias(0);
            }
            txt_nombreAutorLibro.Text = Session["nombreAutor"].ToString();
            cargarComboEditorial();
            if (Session["idEditorial"] != null)
            { ddl_editorialLibro.SelectedValue = Session["idEditorial"].ToString(); }
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
            Session["stock"] = "";
        }

        /// <summary>
        /// Recibe un objeto LibroEntidad y con sus datos carga el form
        /// </summary>
        /// <param name="libro"></param>
        protected void CargarUnLibroEnElForm(LibroEntidad libro)
        {
            txt_cantidadHojasLibro.Text = libro.cantidadHojasLibro.ToString();
            txt_codgoBarra.Text = libro.codigoBarraLibro.ToString();
            txt_descripcionLibro.Text = libro.descripcionLibro;
            txt_nombreAutorLibro.Text = libro.autorLibro;
            txt_nombreDelLibro.Text = libro.nombreLibro;
            txt_precioLibro.Text = libro.precioLibro.ToString();
            txt_stock.Text = libro.stock.ToString();
            cargarComboUniversidad();
            ddl_universidadesLibro.SelectedValue = FacultadDao.ConsultarIdUniversidadDeUnaFacultad(MateriaDao.DevolverIdFacultadDeUnaMateria(libro.idMateria)).ToString();
            cargarComboFacultad(Convert.ToInt32(ddl_universidadesLibro.SelectedValue));
            ddl_facultadesLibro.SelectedValue=MateriaDao.DevolverIdFacultadDeUnaMateria(libro.idMateria).ToString();
            cargarComboMaterias(Convert.ToInt32(ddl_facultadesLibro.SelectedValue));
            ddl_materiasLibro.SelectedValue= libro.idMateria.ToString();
            cargarComboEditorial();
            ddl_editorialLibro.SelectedValue = libro.idEditorial.ToString();
        }

        protected void procesarImagen(string nombreImagen)
        {
            if (fu_subirImagen.HasFile)
            {
                try
                {
                    string rutaImagen = "C:\\Users\\Sebastián\\Documents\\GitHub\\ProyectoAndromeda\\ProyectoAndrómeda\\ProyectoAndrómeda\\imagenes\\libro\\" + nombreImagen + ".jpg";
                    fu_subirImagen.PostedFile.SaveAs(rutaImagen);
                    
                }
                catch (Exception ex)
                {
                    Response.Write("<script>window.alert('La imagen no se pudo cargar.');</script>");
                }

            }
        }
    }
}