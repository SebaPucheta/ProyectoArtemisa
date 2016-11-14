using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Services;
using System.Web.Services;
using AjaxControlToolkit;
using BaseDeDatos;
using Entidades;
using Negocio;
using Spire.Pdf;
using Spire.Pdf.Security;



namespace ProyectoArtemisa
{
    public partial class RegistrarApunte_26 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (PilaForms.pila.Peek().Equals("ConsultarLibroApunte.aspx"))
                {
                    CargarUnApunteEnElForm(ApunteDao.ConsultarApunte((int)Session["idApunte"]));
                }
                else
                {
                    CargarForm();
                }
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //Metodos para cargar los combos y grilla
        //Cargar combo Universidad
        protected void CargarComboUniversidad()
        {
            ddl_universidadApunte.DataSource = UniversidadDao.ConsultarUniversidad();
            ddl_universidadApunte.DataTextField = "nombreUniversidad";
            ddl_universidadApunte.DataValueField = "idUniversidad";
            ddl_universidadApunte.DataBind();
            ddl_universidadApunte.Items.Insert(0, new ListItem("(Universidad)", "0"));
            ddl_universidadApunte.SelectedIndex = 0;

        }

        //Cargar combo Facultad apartir de la universidad selecionada
        protected void CargarComboFacultad(int idUniversidad)
        {
            ddl_facultadApunte.DataSource = FacultadDao.ConsultarFacultadXUniversidad(idUniversidad);
            ddl_facultadApunte.DataTextField = "nombreFacultad";
            ddl_facultadApunte.DataValueField = "idFacultad";
            ddl_facultadApunte.DataBind();
            ddl_facultadApunte.Items.Insert(0, new ListItem("(Facultad)", "0"));
            ddl_facultadApunte.SelectedIndex = 0;
        }

        //Cargar combo Materia apartir de la facultad seleccionada
        protected void CargarComboMateria(int idFacultad)
        {
            ddl_materiaApunte.DataSource = MateriaDao.DevolverMateriaXFacultad(idFacultad);
            ddl_materiaApunte.DataTextField = "nombreMateria";
            ddl_materiaApunte.DataValueField = "idMateria";
            ddl_materiaApunte.DataBind();
            ddl_materiaApunte.Items.Insert(0, new ListItem("(Materia)", "0"));
            ddl_materiaApunte.SelectedIndex = 0;
        }

        //Cargar combo Editorial
        protected void CargarComboEditorial()
        {
            ddl_editorialApunte.DataSource = EditorialDao.ConsultarEditorial();
            ddl_editorialApunte.DataTextField = "nombreEditorial";
            ddl_editorialApunte.DataValueField = "idEditorial";
            ddl_editorialApunte.DataBind();
            ddl_editorialApunte.Items.Insert(0, new ListItem("(Editorial)", "0"));
            ddl_editorialApunte.SelectedIndex = 0;
        }

        //Cargar combo Profesor apartir de la Materia selecionada
        protected void CargarComboProfesor(int idMateria)
        {
            ddl_profesorApunte.DataSource = ProfesorDao.DevolverProfesorXMateria(idMateria);
            ddl_profesorApunte.DataTextField = "nombreProfesor";
            ddl_profesorApunte.DataValueField = "idProfesor";
            ddl_profesorApunte.DataBind();
            ddl_profesorApunte.Items.Insert(0, new ListItem("(Profesor)", "0"));
            ddl_profesorApunte.SelectedIndex = 0;
        }

        //Cargar combo categoria
        protected void CargarComboCategoria()
        {
            ddl_categoriaApunte.DataSource = CategoriaDao.ConsultarCategoria();
            ddl_categoriaApunte.DataTextField = "nombreCategoria";
            ddl_categoriaApunte.DataValueField = "idCategoria";
            ddl_categoriaApunte.DataBind();
            ddl_categoriaApunte.Items.Insert(0, new ListItem("(Categoria)", "0"));
            ddl_categoriaApunte.SelectedIndex = 0;
        }

        //Cargar grilla carrera dependiendo la materia seleccionada
        protected void CargarGrilla(int idMateria)
        {
            dgv_carrera.DataSource = CarreraDao.ConsultarCarreraXMateria(idMateria);
            dgv_carrera.DataKeyNames = new string[] { "idCarrera" };
            dgv_carrera.DataBind();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //Metodos de eventos
        //Botones para regitrar y modificar...
        //Registrar nueva Universidad
        protected void btn_registrarUniversidad_onClick(object sender, EventArgs e)
        {
            GuardarForm();
            PilaForms.AgregarForm("RegistrarApunte_26.aspx");
            Response.Redirect("RegistrarUniversidad_69.aspx");
        }

        //Modificar una Universidad
        protected void btn_modificarUniversidad_onClick(object sender, EventArgs e)
        {
            Session["idUniversidad"] = Convert.ToInt32(ddl_universidadApunte.SelectedValue);
            Session["modificarUniversidad"] = true;
            GuardarForm();
            PilaForms.AgregarForm("RegistrarApunte_26.aspx");
            Response.Redirect("RegistrarUniversidad_69.aspx");
        }

        //Registrar nuevo Profesor
        protected void btn_registrarProfesor_onClick(object sender, EventArgs e)
        {
            GuardarForm();
            PilaForms.AgregarForm("RegistrarApunte_26.aspx");
            Response.Redirect("RegistrarProfesor_14.aspx");
        }

        //Modificar un Profesor
        protected void btn_modificarProfesor_onClick(object sender, EventArgs e)
        {
            Session["idProfesor"] = Convert.ToInt32(ddl_profesorApunte.SelectedValue);
            Session["modificarProfesor"] = true;
            GuardarForm();
            PilaForms.AgregarForm("RegistrarApunte_26.aspx");
            Response.Redirect("RegistrarProfesor_14.aspx");
        }

        //Registrar nueva Carrera
        protected void btn_registrarCarrera_onClick(object sender, EventArgs e)
        {
            GuardarForm();
            PilaForms.AgregarForm("RegistrarApunte_26.aspx");
            Response.Redirect("RegistrarCarrera_10.aspx");
        }

        //Registrar nueva Categoria
        protected void btn_registrarCategoria_onClick(object sender, EventArgs e)
        {
            GuardarForm();
            PilaForms.AgregarForm("RegistrarApunte_26.aspx");
            Response.Redirect("RegistrarCategoria_18.aspx");
        }

        //Modificar una Categoria
        protected void btn_modificarCategoria_onClick(object sender, EventArgs e)
        {
            Session["idCategoria"] = Convert.ToInt32(ddl_categoriaApunte.SelectedValue);
            Session["modificarCategoria"] = true;
            GuardarForm();
            PilaForms.AgregarForm("RegistrarApunte_26.aspx");
            Response.Redirect("RegistrarCategoria_18.aspx");
        }

        //Registrar nueva Materia
        protected void btn_registrarMateria_onClick(object sender, EventArgs e)
        {
            GuardarForm();
            PilaForms.AgregarForm("RegistrarApunte_26.aspx");
            Response.Redirect("RegistrarMateria_6.aspx");
        }

        //Modificar una Materia
        protected void btn_modificarMateria_onClick(object sender, EventArgs e)
        {
            Session["idMateria"] = Convert.ToInt32(ddl_materiaApunte.SelectedValue);
            Session["modificarMateria"] = true;
            GuardarForm();
            PilaForms.AgregarForm("RegistrarApunte_26.aspx");
            Response.Redirect("RegistrarMateria_6.aspx");
        }

        //Registrar nueva Editorial
        protected void btn_registrarEditorial_onClick(object sender, EventArgs e)
        {
            GuardarForm();
            PilaForms.AgregarForm("RegistrarApunte_26.aspx");
            Response.Redirect("RegistrarEditorial_22.aspx");
        }


        //Modificar una Editorial
        protected void btn_modificarEditorial_onClick(object sender, EventArgs e)
        {
            Session["idEditorial"] = Convert.ToInt32(ddl_editorialApunte.SelectedValue);
            Session["modificarEditorial"] = true;
            GuardarForm();
            PilaForms.AgregarForm("RegistrarApunte_26.aspx");
            Response.Redirect("RegistrarEditorial_22.aspx");
        }

        //Registrar nueva Facultad
        protected void btn_registrarFacultad_onClick(object sender, EventArgs e)
        {
            GuardarForm();
            PilaForms.AgregarForm("RegistrarApunte_26.aspx");
            Response.Redirect("RegistrarFacultad_65.aspx");
        }

        //Modificar una Facultad
        protected void btn_modificarFacultad_onClick(object sender, EventArgs e)
        {
            Session["idFacultad"] = Convert.ToInt32(ddl_facultadApunte.SelectedValue);
            Session["modificarFacultad"] = true;
            GuardarForm();
            PilaForms.AgregarForm("RegistrarApunte_26.aspx");
            Response.Redirect("RegistrarFacultad_65.aspx");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //Metodos de eventos
        //Metodo de evento de seleccion de un item de un combo
        //Seleccion de un item del combo Universidad
        protected void ddl_universidadApunte_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboFacultad(Convert.ToInt32(ddl_universidadApunte.SelectedValue));
        }

        //Seleccion de un item del combo Facultad
        protected void ddl_facultadApunte_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboMateria(Convert.ToInt32(ddl_facultadApunte.SelectedValue));
        }

        //Seleccion de un item del combo Materia
        protected void ddl_materiaApunte_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboProfesor(Convert.ToInt32(ddl_materiaApunte.SelectedValue));
            CargarGrilla(Convert.ToInt32(ddl_materiaApunte.SelectedValue));
            btn_registrarCarrera.Visible = true;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //Metodos de eventos
        //Metodo de evento de la grilla Carreras
        protected void btn_modificarCarrera_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Session["idCarrera"] = (int)dgv_carrera.SelectedDataKey.Value;
            Session["modificarCarrera"] = true;
            GuardarForm();
            PilaForms.AgregarForm("RegistrarApunte_26.aspx");
            Response.Redirect("RegistrarCarrera_10.aspx");
        }

        protected void btn_eliminarMateria_OnRowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            CarreraDao.EliminarCarreraXMateria(Convert.ToInt32(ddl_materiaApunte.SelectedValue), (int)dgv_carrera.DataKeys[e.RowIndex].Value);
            CargarGrilla(Convert.ToInt32(ddl_materiaApunte.SelectedValue));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //Metodos de eventos
        //Metodo de evento de check de checkbox
        //Check de checkbox Digital
        protected void chk_digital_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_digital.Checked)
            {
                txt_precioApunteDigital.Enabled = true;
                fu_subirArchivo.Enabled = true;
            }
            else
            {
                txt_precioApunteDigital.Enabled = false;
            }
        }

        //Check de checkbox Impreso
        protected void chk_impreso_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_impreso.Checked)
            {
                txt_precioXHoja.Enabled = true;
                txt_cantHojasApunte.Enabled = true;
                txt_codigoBarra.Enabled = true;
                txt_stock.Enabled = true;
            }
            else
            {
                txt_precioXHoja.Enabled = false;
                txt_cantHojasApunte.Enabled = false;
                txt_codigoBarra.Enabled = false;
                txt_stock.Enabled = false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //Metodos de eventos
        //Metodo de boton
        //Boton confirmar
        protected void btn_confirmar_Click(object sender, EventArgs e)
        {
            bool bandera = true;
            int idApunte = 0;
            if (Page.IsValid)
            {
                if ((chk_digital.Checked) || (chk_impreso.Checked))
                {
                    if (PilaForms.pila.Peek().Equals("Default.aspx"))
                    {
                        if (chk_digital.Checked)
                        { 
                            idApunte = RegistrarApunteDigital();
                            procesarPDF(idApunte.ToString());
                            procesarImagen(idApunte.ToString());
                            bandera = false;
                        }

                        if (chk_impreso.Checked)
                        {
                            RegistrarApunteImpreso();
                            if(bandera)
                            {
                                procesarImagen(idApunte.ToString());
                            }
                        }
                        LimpiarVariablesForm();
                        LimpiarForm();
                    }
                    else
                    {
                        if (chk_digital.Checked)
                        { ModificarApunteDigital(); }

                        if (chk_impreso.Checked)
                        { ModificarApunteImpreso(); }
                        Session["idApunte"] = null;
                        LimpiarVariablesForm();
                        Response.Redirect(PilaForms.DevolverForm());
                    }

                }
                else
                {
                    Response.Write("<script>window.alert('Debe seleccionar un tipo apunte');</script>");
                }
            }

        }

        //Boton Cancelar
        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Session["idApunte"] = null;
            LimpiarVariablesForm();
            Response.Redirect(PilaForms.DevolverForm());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //Metodos de eventos
        //Metodo de evento de cambio de texto del texbox de cantidad de hojas
        protected void txt_cantHojasApunte_TextChanged(object sender, EventArgs e)
        {
            int res;
            if (Int32.TryParse(txt_cantHojasApunte.Text, out res))
            {
                float precioXHoja = PrecioXHojaDao.ConsultarUltimoPrecioXHoja().precioHoja;
                txt_precioXHoja.Text = Convert.ToString(Convert.ToInt32(txt_cantHojasApunte.Text) * precioXHoja);
            }
        }
        protected void txt_codigoBarra_TextChanged(object sender, EventArgs e)
        {}
        
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
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //Metodos 
        /// <summary>
        /// Crea un objeto ApunteEntidad apartir de los datos que ya hay cargados en el form
        /// </summary>
        /// <returns>ApunteEntidad</returns>
        protected ApunteEntidad CargarApunteDesdeForm()
        {
            ApunteEntidad nuevoApunte = new ApunteEntidad();

            nuevoApunte.nombreApunte = txt_nombreApunte.Text;
            nuevoApunte.anoApunte = Convert.ToInt32(txt_ano.Text);
            nuevoApunte.cantHoja = Convert.ToInt32(txt_cantHojasApunte.Text);
            if (chk_digital.Checked)
            {
                nuevoApunte.stock = 0;
            }
            else
            {
                nuevoApunte.stock = Convert.ToInt32(txt_stock.Text);
            }
            nuevoApunte.descripcionApunte = txt_descripcion.Text;
            nuevoApunte.idCategoria = Convert.ToInt32(ddl_categoriaApunte.SelectedValue);
            nuevoApunte.idEditorial = Convert.ToInt32(ddl_editorialApunte.SelectedValue);
            nuevoApunte.idMateria = Convert.ToInt32(ddl_materiaApunte.SelectedValue);

            if (Convert.ToInt32(ddl_profesorApunte.SelectedValue) == 0)
            { nuevoApunte.idProfesor = null; }
            else
            {
                nuevoApunte.idProfesor = Convert.ToInt32(ddl_profesorApunte.SelectedValue);
            }
            //nuevoApunte.idEstado = null;

            return nuevoApunte;
        }

        /// <summary>
        /// Registrar un apunte en la base de datos, como un TipoApunte "Digital", setea el precio de hoja
        /// desde el txt_precioApunteDigital y setea el código de barra como null
        /// </summary>
        protected int RegistrarApunteDigital()
        {
            int idApunte = 0;
            if (txt_precioApunteDigital.Text != "")
            {
                ApunteEntidad nuevoApunte = CargarApunteDesdeForm();
                nuevoApunte.codigoBarraApunte = "";
                nuevoApunte.precioApunte = float.Parse(txt_precioApunteDigital.Text);
                nuevoApunte.idTipoApunte = 2; //Hace referencia a un apunte de tipo Digital
                nuevoApunte.idPrecioHoja = null;
                idApunte=ApunteDao.RegistrarApunte(nuevoApunte);
            }
            else
            {
                Response.Write("<script>window.alert('No se ha ingresado ningun precio para apuntes digitales');</script>");
            }
            return idApunte;
        }

        /// <summary>
        /// Registrar un apunte en la base de datos, como un TipoApunte "Impreso", setea el precio de hoja
        /// desde el txt_precioApunteImpreso y setea el código de barra desde el txt_codigoBarra
        /// </summary>
        protected void RegistrarApunteImpreso()
        {
            int idApunte = 0;
            if (txt_codigoBarra.Text != "")
            {
                if (ApunteDao.VerificarCodigoBarra(txt_codigoBarra.Text))
                {
                    ApunteEntidad nuevoApunte = CargarApunteDesdeForm();
                    nuevoApunte.codigoBarraApunte = txt_codigoBarra.Text;
                    nuevoApunte.precioApunte = float.Parse(txt_precioXHoja.Text);
                    nuevoApunte.idTipoApunte = 1;
                    nuevoApunte.stock = int.Parse(txt_stock.Text);
                    nuevoApunte.idPrecioHoja = PrecioXHojaDao.ConsultarUltimoPrecioXHoja().idPrecioHoja;
                    ApunteDao.RegistrarApunte(nuevoApunte);
                }
                else
                {
                    Response.Write("<script>window.alert('El código de barra ingresado ya esta cargado');</script>");
                }
            }
            else
            {
                Response.Write("<script>window.alert('No se ingreso ningun código de barra');</script>");
            }

        }

        /// <summary>
        /// Modifica un apunte en la base de datos, como un TipoApunte "Digital", setea el precio de hoja
        /// desde el txt_precioApunteDigital y setea el código de barra como null
        /// </summary>
        protected void ModificarApunteDigital()
        {
            ApunteEntidad nuevoApunte = CargarApunteDesdeForm();
            nuevoApunte.codigoBarraApunte = "";
            nuevoApunte.precioApunte = float.Parse(txt_precioApunteDigital.Text);
            nuevoApunte.idTipoApunte = 2; //Hace referencia a un apunte de tipo Digital
            nuevoApunte.idPrecioHoja = null;//ACA ESTABA NULL
            nuevoApunte.idApunte = (int)Session["idApunte"];
            ApunteDao.ModificarApunte(nuevoApunte);
        }

        /// <summary>
        /// Modifica un apunte en la base de datos, como un TipoApunte "Impreso", setea el precio de hoja
        /// desde el txt_precioApunteImpreso y setea el código de barra desde el txt_codigoBarra
        /// </summary>
        protected void ModificarApunteImpreso()
        {
            ApunteEntidad nuevoApunte = CargarApunteDesdeForm();
            nuevoApunte.codigoBarraApunte = txt_codigoBarra.Text;
            nuevoApunte.precioApunte = float.Parse(txt_precioXHoja.Text);
            nuevoApunte.idTipoApunte = 1;
            nuevoApunte.idPrecioHoja = PrecioXHojaDao.ConsultarUltimoPrecioXHoja().idPrecioHoja;
            nuevoApunte.idApunte = (int)Session["idApunte"];
            ApunteDao.ModificarApunte(nuevoApunte);
        }

        /// <summary>
        /// Inicializa el form
        /// </summary>
        protected void LimpiarForm()
        {
            txt_ano.Text = "";
            txt_cantHojasApunte.Text = "";
            txt_codigoBarra.Text = "";
            txt_codigoBarra.Enabled = false;
            txt_descripcion.Text = "";
            txt_nombreApunte.Text = "";
            txt_precioApunteDigital.Text = "";
            txt_precioApunteDigital.Enabled = false;
            txt_precioXHoja.Text = "";
            txt_precioXHoja.Enabled = false;
            txt_stock.Text = "";
            txt_stock.Enabled = false;
            CargarComboUniversidad();
            ddl_categoriaApunte.SelectedIndex = 0;
            ddl_editorialApunte.SelectedIndex = 0;
            ddl_facultadApunte.SelectedIndex = 0;
            ddl_materiaApunte.SelectedIndex = 0;
            ddl_profesorApunte.SelectedIndex = 0;
            chk_digital.Checked = false;
            chk_impreso.Checked = false;
            CargarGrilla(0);
        }

        /// <summary>
        /// Guardar el contenido del form en variables globales
        /// </summary>
        protected void GuardarForm()
        {
            Session["chk_Impreso"] = chk_impreso.Checked;
            Session["chk_Digital"] = chk_digital.Checked;
            Session["codigoBarra"] = txt_codigoBarra.Text;
            Session["nombreApunte"] = txt_nombreApunte.Text;
            Session["ano"] = txt_ano.Text;
            Session["idUniversidad"] = Convert.ToInt32(ddl_universidadApunte.SelectedValue);
            Session["idFacultad"] = Convert.ToInt32(ddl_facultadApunte.SelectedValue);
            Session["idMateria"] = Convert.ToInt32(ddl_materiaApunte.SelectedValue);
            Session["idEditorial"] = Convert.ToInt32(ddl_editorialApunte.SelectedValue);
            Session["cantidadHojas"] = txt_cantHojasApunte.Text;
            Session["stock"] = txt_stock.Text;
            Session["precionImpreso"] = txt_precioXHoja.Text;
            Session["precioDigital"] = txt_precioApunteDigital.Text;
            Session["idProfesor"] = Convert.ToInt32(ddl_profesorApunte.SelectedValue);
            Session["idCategoria"] = Convert.ToInt32(ddl_categoriaApunte.SelectedValue);
            Session["descripcion"] = txt_descripcion.Text;

        }

        /// <summary>
        /// Cargar los datos del form por defecto o que se encuentren guardados en varaibles globales
        /// </summary>
        protected void CargarForm()
        {
            chk_impreso.Checked = bool.Parse(Session["chk_Impreso"].ToString());
            if (chk_impreso.Checked)
            {
                txt_codigoBarra.Enabled = true;
                txt_codigoBarra.Text = Session["codigoBarra"].ToString();
                txt_precioXHoja.Enabled = true;
                txt_precioXHoja.Text = Session["precionImpreso"].ToString();
                txt_stock.Enabled = true;
                txt_stock.Text = Session["stock"].ToString();
                txt_stock.Enabled = false;

            }
            chk_digital.Checked = bool.Parse(Session["chk_Digital"].ToString());
            if (chk_digital.Checked)
            {
                txt_stock.Enabled = false;
                fu_subirArchivo.Enabled = true;
                txt_precioApunteDigital.Enabled = true;
                txt_precioApunteDigital.Text = Session["precioDigital"].ToString();
            }
            txt_nombreApunte.Text = Session["nombreApunte"].ToString();
            txt_ano.Text = Session["ano"].ToString();
            CargarComboUniversidad();
            if (Session["idUniversidad"] != null)
            {
                ddl_universidadApunte.SelectedValue = (Session["idUniversidad"].ToString());
                CargarComboFacultad(Convert.ToInt32(ddl_universidadApunte.SelectedValue));
                if (Session["idFacultad"] != null)
                {
                    ddl_facultadApunte.SelectedValue = (Session["idFacultad"].ToString());
                    CargarComboMateria(Convert.ToInt32(ddl_facultadApunte.SelectedValue));
                    if (Session["idMateria"] != null)
                    {
                        ddl_materiaApunte.SelectedValue = (Session["idMateria"].ToString());
                        CargarGrilla(Convert.ToInt32(ddl_materiaApunte.SelectedValue));
                        btn_registrarCarrera.Visible = true;
                        CargarComboProfesor(Convert.ToInt32(ddl_materiaApunte.SelectedValue));
                        if (Session["idProfesor"] != null)
                        { ddl_profesorApunte.SelectedValue = (Session["idProfesor"].ToString()); }
                    }
                    else
                    {
                        CargarComboProfesor(0);
                    }
                }
                else
                {
                    CargarComboMateria(0);
                    CargarComboProfesor(0);
                }
            }
            else
            {
                CargarComboFacultad(0);
                CargarComboMateria(0);
                CargarComboProfesor(0);
            }
            CargarComboEditorial();
            if (Session["idEditorial"] != null)
            { ddl_editorialApunte.SelectedValue = (Session["idEditorial"].ToString()); }
            txt_cantHojasApunte.Text = Session["cantidadHojas"].ToString();
            CargarComboCategoria();
            if (Session["idCategoria"] != null)
            { ddl_categoriaApunte.SelectedValue = (Session["idCategoria"].ToString()); }
            txt_descripcion.Text = Session["descripcion"].ToString();
        }

        /// <summary>
        /// Inicializa las variables globales
        /// </summary>
        protected void LimpiarVariablesForm()
        {
            Session["chk_Impreso"] = false;
            Session["chk_Digital"] = false;
            Session["codigoBarra"] = "";
            Session["nombreApunte"] = "";
            Session["ano"] = "";
            Session["idUniversidad"] = null;
            Session["idFacultad"] = null;
            Session["idMateria"] = null;
            Session["nombreAutor"] = "";
            Session["idEditorial"] = null;
            Session["cantidadHojas"] = "";
            Session["stock"] = "";
            Session["precionImpreso"] = "";
            Session["precioDigital"] = "";
            Session["idProfesor"] = null;
            Session["idCategoria"] = null;
            Session["descripcion"] = "";
        }

        /// <summary>
        /// Recibe un objeto ApunteEntidad por parametro y carga el form con
        /// los datos del mismo
        /// </summary>
        /// <param name="apunte"></param>
        protected void CargarUnApunteEnElForm(ApunteEntidad apunte)
        {
            txt_ano.Text = apunte.anoApunte.ToString();
            txt_cantHojasApunte.Text = apunte.cantHoja.ToString();
            txt_descripcion.Text = apunte.descripcionApunte;
            txt_nombreApunte.Text = apunte.nombreApunte;
            CargarComboUniversidad();
            ddl_universidadApunte.SelectedValue = FacultadDao.ConsultarIdUniversidadDeUnaFacultad(MateriaDao.DevolverIdFacultadDeUnaMateria(apunte.idMateria)).ToString();
            CargarComboCategoria();
            ddl_categoriaApunte.SelectedValue = apunte.idCategoria.ToString();
            CargarComboEditorial();
            ddl_editorialApunte.SelectedValue = apunte.idEditorial.ToString();
            CargarComboFacultad(Convert.ToInt32(ddl_universidadApunte.SelectedValue));
            ddl_facultadApunte.SelectedValue = MateriaDao.DevolverIdFacultadDeUnaMateria(apunte.idMateria).ToString();
            CargarComboMateria(Convert.ToInt32(ddl_facultadApunte.SelectedValue));
            ddl_materiaApunte.SelectedValue = apunte.idMateria.ToString();
            CargarGrilla(Convert.ToInt32(ddl_materiaApunte.SelectedValue));
            CargarComboProfesor(Convert.ToInt32(ddl_materiaApunte.SelectedValue));
            ddl_profesorApunte.SelectedValue = apunte.idProfesor.ToString();

            if (apunte.idTipoApunte == 1)
            {
                chk_impreso.Checked = true;
                txt_codigoBarra.Text = apunte.codigoBarraApunte;
                txt_codigoBarra.Enabled = true;
                txt_precioApunteDigital.Text = "";
                txt_stock.Enabled = true;
                txt_stock.Text = apunte.stock.ToString();
                txt_precioApunteDigital.Enabled = false;
                txt_precioXHoja.Text = apunte.precioApunte.ToString();
                txt_precioXHoja.Enabled = true;
            }
            else
            {
                chk_digital.Checked = true;
                txt_codigoBarra.Text = "";
                txt_codigoBarra.Enabled = false;
                txt_stock.Enabled = false;
                txt_stock.Text = "";
                txt_precioApunteDigital.Text = apunte.precioApunte.ToString();
                txt_precioApunteDigital.Enabled = true;
                txt_precioXHoja.Text = "";
                txt_precioXHoja.Enabled = false;
            }

        }
        //Cuando hacemos clic en el boton cargar se realiza la carga del documento en la ruta indicada
        protected void btn_cargarArchivo_Click(object sender, EventArgs e)
        {

        }
        protected void procesarImagen(string nombreImagen)
        {
            if (fu_subirImagen.HasFile)
            {
                try
                {
                    string rutaImagen = "C:\\Users\\Sebastián\\Documents\\GitHub\\ProyectoAndromeda\\ProyectoAndrómeda\\ProyectoAndrómeda\\imagenes\\apunte\\" + nombreImagen + ".jpg";
                    fu_subirImagen.PostedFile.SaveAs(rutaImagen);
                    
                }
                catch (Exception ex)
                {
                    Response.Write("<script>window.alert('La imagen no se pudo cargar.');</script>");
                }

            }
        }
        protected void procesarPDF(string nombreArchivo)
        {
            if (fu_subirArchivo.HasFile)
            {
                try
                {
                    //creo un nuevo pdf
                    PdfDocument pdf = new PdfDocument();
                    // Indico la ruta deseada donde quiero gurdar el archivo.
                    string rutaPDF = "C:\\Users\\Sebastián\\Documents\\GitHub\\ProyectoAndromeda\\ProyectoAndrómeda\\ProyectoAndrómeda\\Archivos\\Apuntes\\" + nombreArchivo + ".pdf";
                    //Guardo el archivo
                    fu_subirArchivo.SaveAs(rutaPDF);
                    //Selecciono donde guarde el archivo
                    pdf.LoadFromFile(rutaPDF);
                    //Aplico seguridad
                    pdf.Security.KeySize = PdfEncryptionKeySize.Key256Bit;
                    pdf.Security.OwnerPassword = "test";
                    //Por defecto se le quitan todos los permisos al PDF
                    //si quiero agregarle algun permiso tengo que descomentar las siguiente linea
                    pdf.Security.Permissions = PdfPermissionsFlags.None;
                    //en la pagina http://www.e-iceblue.com/Tutorials/Spire.PDF/Spire.PDF-Program-Guide/Security/How-to-Change-Security-Permission-of-PDF-Document-in-C-VB.NET.html
                    //nos muestran los tipos de seguridad que se le pueden colocar

                    //lo guardo en donde quiero, en este caso del string rutaPDF
                    pdf.SaveToFile(rutaPDF);
                    //indico que el archivo se cargo exitosamente.
                    
                }
                catch (Exception ex)
                {
                    Response.Write("<script>window.alert('El archivo no se pudo cargar.');</script>");
                }

            }

        }

        protected void CustomValidator7_ServerValidate(object source, ServerValidateEventArgs e)
        {
            if (chk_digital.Checked)
            {
                e.IsValid = true;
            }
            else
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
        }

        protected void cv_codBarra_ServerValidate(object source, ServerValidateEventArgs e)
        {
            if (e.ToString() == "")
            {
                e.IsValid = false;
            }
            else
            {
                e.IsValid = true;
            }
        }
    }
}