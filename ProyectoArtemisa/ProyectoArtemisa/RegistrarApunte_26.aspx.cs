using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using BaseDeDatos;
using Entidades;
using System.Web.Script.Services;
using System.Web.Services;

namespace ProyectoArtemisa
{
    public partial class RegistrarApunte_26 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
               //CargarComboUniversidad();        
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
            ddl_universidadApunte.Items.Insert(0, new ListItem("(Universidad)", "0"));
            ddl_universidadApunte.SelectedIndex = 0;
        }

        //Cargar combo Facultad apartir de la universidad selecionada
        protected void CargarComboFacultad(int idUniversidad)
        {
            ddl_facultadApunte.DataSource = FacultadDao.ConsultarFacultadXUniversidad(idUniversidad);
            ddl_facultadApunte.DataTextField = "nombreFacultad";
            ddl_facultadApunte.DataValueField = "idFacultad";
            ddl_facultadApunte.Items.Insert(0, new ListItem("(Facultad)", "0"));
            ddl_facultadApunte.SelectedIndex = 0;
        }

        //Cargar combo Materia apartir de la facultad seleccionada
        protected void CargarComboMateria(int idFacultad)
        {
            ddl_materiaApunte.DataSource = MateriaDao.DevolverMateriaXFacultad(idFacultad);
            ddl_materiaApunte.DataTextField = "nombreMateria";
            ddl_materiaApunte.DataValueField = "idMateria";
            ddl_materiaApunte.Items.Insert(0, new ListItem("(Materia)", "0"));
            ddl_materiaApunte.SelectedIndex = 0;
        }

        //Cargar combo Editorial
        protected void CargarComboEditorial()
        {
            ddl_editorialApunte.DataSource = EditorialDao.ConsultarEditorial();
            ddl_editorialApunte.DataTextField = "nombreEditorial";
            ddl_editorialApunte.DataValueField = "idEditorial";
            ddl_editorialApunte.Items.Insert(0, new ListItem("(Editorial)", "0"));
            ddl_editorialApunte.SelectedIndex = 0;
        }

        //Cargar combo Profesor apartir de la Materia selecionada
        protected void CargarComboProfesor(int idMateria)
        {
            ddl_profesorApunte.DataSource = ProfesorDao.DevolverProfesorXMateria(idMateria);
            ddl_profesorApunte.DataTextField = "nombreProfesor";
            ddl_profesorApunte.DataValueField = "idProfesor";
            ddl_profesorApunte.Items.Insert(0, new ListItem("(Profesor)", "0"));
            ddl_profesorApunte.SelectedIndex = 0;
        }

        //Cargar combo categoria
        protected void CargarComboCategoria()
        {
            ddl_categoriaApunte.DataSource = CategoriaDao.ConsultarCategoria();
            ddl_categoriaApunte.DataTextField = "nombreCategoria";
            ddl_categoriaApunte.DataValueField = "idCategoria";
            ddl_categoriaApunte.Items.Insert(0, new ListItem("(Categoria)", "0"));
            ddl_categoriaApunte.SelectedIndex = 0;
        }

        //Cargar grilla carrera dependiendo la materia seleccionada
        protected void CargarGrilla(int idMateria)
        {
            dgv_carrera.DataSource = CarreraDao.ConsultarCarreraXMateria(idMateria);
            dgv_carrera.DataKeyNames = new string[] { "idMateria" };
            dgv_carrera.DataBind();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //Metodos de eventos
        //Botones para regitrar nueva/o...
        //Registrar nueva Universidad
        protected void btn_registrarUniversidad_onClick(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarUniversidad_69.aspx");
        }

        //Registrar nuevo Profesor
        protected void btn_registrarProfesor_onClick(object sender, EventArgs e)
        {
            ApunteEntidad nuevoApunte = new ApunteEntidad();
            nuevoApunte.idMateria = Convert.ToInt32(ddl_materiaApunte.SelectedValue);
            Session["Apunte"] = nuevoApunte;
            Response.Redirect("RegistrarProfesor_14.aspx");
        }

        //Registrar nueva Carrera
        protected void btn_registrarCarrera_onClick(object sender, EventArgs e)
        {
            ApunteEntidad nuevoApunte = new ApunteEntidad();
            nuevoApunte.idMateria =Convert.ToInt32(ddl_materiaApunte.SelectedValue);
            Session["Apunte"] = nuevoApunte;
            Response.Redirect("RegistrarCarrera_10.aspx");
        }

        //Registrar nueva Categoria
        protected void btn_registrarCategoria_onClick(object sender, EventArgs e)
        {
            ApunteEntidad nuevoApunte = new ApunteEntidad();
            nuevoApunte.idMateria = Convert.ToInt32(ddl_materiaApunte.SelectedValue);
            Session["Apunte"] = nuevoApunte;
            Response.Redirect("RegistrarCategoria_18.aspx");
        }

        //Registrar nueva Materia
        protected void btn_registrarMateria_onClick(object sender, EventArgs e)
        {
            UniversidadEntidad universidad = new UniversidadEntidad();
            universidad.idUniversidad =Convert.ToInt32(ddl_materiaApunte.SelectedValue);
            Session["Universidad"] = universidad;
            FacultadEntidad facultad = new FacultadEntidad();
            facultad.idFacultad =Convert.ToInt32(ddl_facultadApunte.SelectedValue);
            Session["Facultad"] = facultad;
            Response.Redirect("RegistrarMateria_6.aspx");
        }

        //Registrar nueva Editorial
        protected void btn_registrarEditorial_onClick(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarEditorial_22.aspx");
        }

        //Registrar nueva Facultad
        protected void btn_registrarFacultad_onClick(object sender, EventArgs e)
        {
            UniversidadEntidad universidad = new UniversidadEntidad();
            universidad.idUniversidad =Convert.ToInt32(ddl_universidadApunte.SelectedValue);
            Session["Universidad"] = universidad;
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
            CargarGrilla(Convert.ToInt32(ddl_materiaApunte.SelectedValue));
            btn_registrarCarrera.Visible = true;
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
            }
            else
            {
                txt_precioApunteDigital.Enabled = false;
            }
        }

        //Check de checkbox Impreso
        protected void chk_impreso_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_digital.Checked)
            {
                txt_precioXHoja.Enabled = true;
                txt_cantHojasApunte.Enabled = true;
                txt_codigoBarra.Enabled = true;
            }
            else
            {
                txt_precioXHoja.Enabled = false;
                txt_cantHojasApunte.Enabled = false;
                txt_codigoBarra.Enabled = false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //Metodos de eventos
        //Metodo de boton
        //Boton confirmar
        protected void btn_confirmar_Click(object sender, EventArgs e)
        {
            if ((chk_digital.Checked) || (chk_impreso.Checked))
            {
                if (chk_digital.Checked)
                { RegistrarApunteDigital(); }

                if (chk_impreso.Checked)
                { RegistrarApunteImpreso(); }
            }
            else
            {
                Response.Write("<script>window.alert('Deve seleccionar un tipo apunte');</script>");
            }
        }

        //Boton Cancelar
        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //Metodos de eventos
        //Metodo de evento de cambio de texto del texbox de cantidad de hojas
        protected void txt_cantHojasApunte_TextChanged(object sender, EventArgs e)
        {
            List<PrecioXHojaEntidad> listaPrecio = PrecioXHojaDao.ConsultarPrecioXHoja();
            float precioXHoja = listaPrecio[(listaPrecio.Count) - 1].precioHoja;
            txt_precioXHoja.Text = Convert.ToString(Convert.ToInt32(txt_cantHojasApunte.Text) * precioXHoja);
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
            nuevoApunte.descripcionApunte = txt_descripcion.Text;
            nuevoApunte.idCategoria = Convert.ToInt32( ddl_categoriaApunte.SelectedValue);
            nuevoApunte.idEditorial = Convert.ToInt32( ddl_editorialApunte.SelectedValue);
            nuevoApunte.idMateria = Convert.ToInt32( ddl_materiaApunte.SelectedValue);
            nuevoApunte.idProfesor = Convert.ToInt32( ddl_profesorApunte.SelectedValue);

            return nuevoApunte;
        }   
          
        /// <summary>
        /// Registrar un apunte en la base de datos, como un TipoApunte "Digital", setea el precio de hoja
        /// desde el txt_precioApunteDigital y setea el código de barra como null
        /// </summary>
        protected void RegistrarApunteDigital()
        {
            ApunteEntidad nuevoApunte = CargarApunteDesdeForm();
            nuevoApunte.idPrecioHoja = Convert.ToInt32(txt_precioApunteDigital.Text);
            nuevoApunte.idTipoApunte = 2; //Hace referencia a un apunte de tipo Digital
            ApunteDao.RegistrarApunte(nuevoApunte);
        }

        /// <summary>
        /// Registrar un apunte en la base de datos, como un TipoApunte "Impreso", setea el precio de hoja
        /// desde el txt_precioApunteImpreso y setea el código de barra desde el txt_codigoBarra
        /// </summary>
        protected void RegistrarApunteImpreso()
        {
            
            if (ApunteDao.VerificarCodigoBarra(txt_codigoBarra.Text))
            {
                ApunteEntidad nuevoApunte = CargarApunteDesdeForm();
                nuevoApunte.codigoBarraApunte = txt_codigoBarra.Text;
                nuevoApunte.precioApunte = Convert.ToInt32(txt_precioXHoja.Text);
                nuevoApunte.idTipoApunte = 1;
                ApunteDao.RegistrarApunte(nuevoApunte);
            }
            else
            {
                Response.Write("<script>window.alert('El código de barra ingresado ya esta cargado');</script>");
            }
        }
    }
}