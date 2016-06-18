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
                CargarComboUniversidad();        
            }
            
        }
        
        protected void CargarComboUniversidad()
        {
            ddl_universidadApunte.DataSource = UniversidadDao.ConsultarUniversidad();
            ddl_universidadApunte.DataTextField = "nombreUniversidad";
            ddl_universidadApunte.DataValueField = "idUniversidad";
        }
        protected void CargarComboFacultad(int idUniversidad)
        {
            ddl_facultadApunte.DataSource = FacultadDao.ConsultarFacultadXUniversidad(idUniversidad);
            ddl_facultadApunte.DataTextField = "nombreFacultad";
            ddl_facultadApunte.DataValueField = "idFacultad";
        }
        protected void CargarComboMateria(int idFacultad)
        {
            ddl_materiaApunte.DataSource = MateriaDao.DevolverMateriaXFacultad(idFacultad);
            ddl_materiaApunte.DataTextField = "nombreMateria";
            ddl_materiaApunte.DataValueField = "idMateria";
        }
        protected void CargarComboEditorial()
        {
            ddl_editorialApunte.DataSource = EditorialDao.ConsultarEditorial();
            ddl_editorialApunte.DataTextField = "nombreEditorial";
            ddl_editorialApunte.DataValueField = "idEditorial";
        }
        protected void CargarComboProfesor(int idMateria)
        {
            ddl_profesorApunte.DataSource = ProfesorDao.DevolverProfesorXMateria(idMateria);
            ddl_profesorApunte.DataTextField = "nombreProfesor";
            ddl_profesorApunte.DataValueField = "idProfesor";
        }
        protected void CargarComboCategoria()
        {
            ddl_categoriaApunte.DataSource = CategoriaDao.ConsultarCategoria();
            ddl_categoriaApunte.DataTextField = "nombreCategoria";
            ddl_categoriaApunte.DataValueField = "idCategoria";
        }

        protected void btn_registrarUniversidad_onClick(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarUniversidad_69.aspx");
        }

        protected void btn_registrarProfesor_onClick(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarProfesor_14.aspx");
        }

        protected void btn_registrarCarrera_onClick(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarCarrera_10.aspx");
        }

        protected void btn_registrarCategoria_onClick(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarCategoria_18.aspx");
        }
        protected void btn_registrarMateria_onClick(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarMateria_6.aspx");
        }

        protected void CargarGrilla(int  idMateria)
        {
            dgv_carrera.DataSource = CarreraDao.ConsultarCarreraXMateria(idMateria);
            dgv_carrera.DataKeyNames = new string[] { "idMateria" };
            dgv_carrera.DataBind();
        }

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
          
        
        protected void btn_confirmar_Click(object sender, EventArgs e)
        {   
            if ((chk_digital.Checked) || (chk_impreso.Checked))
            {
                 if (chk_digital.Checked)
                 { RegistrarApunteDigital(); }

                 if(chk_impreso.Checked)
                 { RegistrarApunteImpreso(); }
            }
            else
            {
                Response.Write("<script>window.alert('Deve seleccionar un tipo apunte');</script>");
            }
        }

        
        protected void RegistrarApunteDigital()
        {
            ApunteEntidad nuevoApunte = CargarApunteDesdeForm();
            nuevoApunte.idPrecioHoja = Convert.ToInt32(txt_precioApunteDigital.Text);
            nuevoApunte.idTipoApunte = 2; //Hace referencia a un apunte de tipo Digital
            ApunteDao.RegistrarApunte(nuevoApunte);
        }

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

        protected void ddl_materiaApunte_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrilla(Convert.ToInt32(ddl_materiaApunte.SelectedValue));
            btn_registrarCarrera.Visible = true;
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void txt_cantHojasApunte_TextChanged(object sender, EventArgs e)
        {
            List<PrecioXHojaEntidad> listaPrecio = PrecioXHojaDao.ConsultarPrecioXHoja(); 
            float precioXHoja = listaPrecio[(listaPrecio.Count) - 1].precioHoja;
            txt_precioXHoja.Text = Convert.ToString(Convert.ToInt32(txt_cantHojasApunte.Text) * precioXHoja);
        }

        protected void chk_digital_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_digital.Checked)
            {
                txt_precioApunteDigital.Enabled = true;
            }
            else
            {
                txt_precioApunteDigital.Enabled = false;
            }
        }

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

        protected void ddl_universidadApunte_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboFacultad(Convert.ToInt32(ddl_universidadApunte.SelectedValue));
        }

        protected void ddl_facultadApunte_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboMateria(Convert.ToInt32(ddl_facultadApunte.SelectedValue));
        }
        
       

        
    }
}