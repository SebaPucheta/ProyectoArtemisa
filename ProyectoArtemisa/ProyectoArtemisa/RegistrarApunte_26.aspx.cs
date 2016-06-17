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
               
            }
            
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        protected List<string> DevolverUniversidadXParametro(string parametro, int count)
        {
            List<string> nombreUniversidades = new List<string>();
            foreach ( UniversidadEntidad universidades in UniversidadDao.ConsultarUniversidadXParametro(parametro))
            {
                nombreUniversidades.Add(universidades.nombreUniversidad);
            }

            return nombreUniversidades;
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

        protected void CargarGrilla(string  nombreMateria)
        {
            dgv_carrera.DataSource = CarreraDao.ConsultarCarreraXMateria(MateriaDao.ConsultarMateriaXNombre(nombreMateria));
            dgv_carrera.DataKeyNames = new string[] { "idMateria" };
            dgv_carrera.DataBind();
        }

        protected ApunteEntidad CargarApunteDesdeForm()
        {
            ApunteEntidad nuevoApunte = new ApunteEntidad();

            nuevoApunte.nombre = txt_nombreApunte.Text;
            nuevoApunte.ano = Convert.ToInt32(txt_ano.Text);
            nuevoApunte.cantHoja = Convert.ToInt32(txt_cantHojasApunte.Text);
            nuevoApunte.codigoBarraApunte = txt_codigoBarra.Text;
            nuevoApunte.descripcion = txt_descripcion.Text;
            nuevoApunte.idCategoria = Convert.ToInt32( ddl_categoriaApunte.SelectedValue);
            nuevoApunte.idEditorial = Convert.ToInt32( ddl_editorialApunte.SelectedValue);
            nuevoApunte.idMateria = Convert.ToInt32( ddl_materiaApunte.SelectedValue);
            nuevoApunte.idProfesor = Convert.ToInt32( ddl_profesorApunte.SelectedValue);

            return nuevoApunte;
        }   
          
        
        protected void btn_confirmar_Click(object sender, EventArgs e)
        {
            if(ApunteDao.VerificarCodigoBarra(txt_codigoBarra.Text))
            {
                if ((chk_digital.Checked) || (chk_impreso.Checked))
                {
                    ApunteEntidad nuevoApunte = CargarApunteDesdeForm();

                    if(chk_digital.Checked)
                    {
                        nuevoApunte.idPrecioHoja =Convert.ToInt32(txt_precioApunteDigital.Text);
                        ApunteDao.RegistrarApunte(nuevoApunte);

                        if(chk_impreso.Checked)
                        {
                            nuevoApunte.precio = Convert.ToInt32(txt_precioXHoja.Text);
                            ApunteDao.RegistrarApunte(nuevoApunte);
                        }
                    }
                    else
                    {
                        nuevoApunte.precio = Convert.ToInt32(txt_precioXHoja.Text);
                        ApunteDao.RegistrarApunte(nuevoApunte);
                    }
                }
                else 
                {
                    Response.Write("<script>window.alert('Deve seleccionar un tipo apunte');</script>");
                }
            }
            else
            {
                Response.Write("<script>window.alert('El código de barra ingresado ya esta cargado');</script>");
            }
        }

        protected void ddl_materiaApunte_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrilla(ddl_materiaApunte.Items[Convert.ToInt32(ddl_materiaApunte.SelectedItem) - 1].Text);
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void txt_cantHojasApunte_TextChanged(object sender, EventArgs e)
        {
            txt_precioXHoja.Text = Convert.ToInt32(txt_cantHojasApunte.Text) * ConsultarPrecioXHoja();
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
            }
            else
            {
                txt_precioXHoja.Enabled = false;
                txt_cantHojasApunte.Enabled = false;
            }
        }
        
       

        
    }
}