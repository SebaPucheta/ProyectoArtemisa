using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseDeDatos;
using Entidades;
using Negocio;

namespace ProyectoArtemisa
{
    public partial class RegistrarEditorial_22 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((PilaForms.pila.Peek().Equals("ConsultarEditorial_25.aspx")) || ((bool)Session["modificarEditorial"]))
                {
                    CargarUnObjetoEnElForm(EditorialDao.ConsultarUnaEditorial((int)Session["idEditorial"]));
                }
                else
                {
                    CargarComboProvincia();
                }

            }
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            if ((PilaForms.pila.Peek().Equals("ConsultarEditorial_25.aspx")) || ((bool)Session["modificarEditorial"]))
            {
                EditorialEntidad editorial = CrearUnObjetoDesdeElForm();
                editorial.idEditorial = (int)Session["idEditorial"];
                EditorialDao.ModificarEditorial(editorial);
                LimpiarForm();
                Session["idEditorial"] = null;
                Session["modificarEditorial"] = false;
            }
            else
            {
                EditorialDao.RegistrarEditorial(CrearUnObjetoDesdeElForm());
                Response.Redirect(PilaForms.DevolverForm());
            }

        }
        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Session["modificarEditorial"] = false;
            Response.Redirect(PilaForms.DevolverForm());
        }

        protected void CargarUnObjetoEnElForm(EditorialEntidad editorial)
        {
            txt_direccion.Text = editorial.direccion;
            txt_email.Text = editorial.email;
            txt_nombreContacto.Text = editorial.nombreContacto;
            txt_nombreEditorial.Text = editorial.nombreEditorial;
            txt_telefono.Text = editorial.telefono;
            CargarComboProvincia();
            ddl_provincia.SelectedValue = CiudadDao.ConsultaridProvinciaDeLaCiudad(editorial.idCiudadEditorial).ToString();
            CargarComboCiudad(Convert.ToInt32(ddl_provincia.SelectedValue));
            ddl_ciudad.SelectedValue = editorial.idCiudadEditorial.ToString();
        }

        protected EditorialEntidad CrearUnObjetoDesdeElForm()
        {
            EditorialEntidad editorial = new EditorialEntidad();
            editorial.nombreEditorial = txt_nombreEditorial.Text;
            editorial.nombreContacto = txt_nombreContacto.Text;
            editorial.telefono = txt_telefono.Text;
            editorial.email = txt_email.Text;
            editorial.direccion = txt_direccion.Text;
            editorial.idCiudadEditorial = Convert.ToInt32(ddl_ciudad.SelectedValue);
            return editorial;
        }
        protected void LimpiarForm()
        {
            txt_direccion.Text = "";
            txt_email.Text = "";
            txt_nombreContacto.Text = "";
            txt_nombreEditorial.Text = "";
            txt_telefono.Text = "";
        }
        protected void btn_registrarProvincia_onClick(object sender, EventArgs e)
        {
            PilaForms.AgregarForm("RegistrarEditorial_22.aspx");
            Response.Redirect("RegistrarProvincia_105.aspx");
        }
        protected void btn_modificarProvincia_onClick(object sender, EventArgs e)
        {
            Session["idProvincia"] = ddl_provincia.SelectedValue;
            Session["modificarProvincia"] = true;
            PilaForms.AgregarForm("RegistrarEditorial_22.aspx");
            Response.Redirect("RegistrarProvincia_105.aspx");
        }

        protected void btn_registrarCiudad_onClick(object sender, EventArgs e)
        {
            PilaForms.AgregarForm("RegistrarEditorial_22.aspx");
            Response.Redirect("RegistrarCiudad_101.aspx");
        }

        protected void btn_modificarCiudad_onClick(object sender, EventArgs e)
        {
            Session["idCiudad"] = ddl_ciudad.SelectedValue;
            Session["modificarCiudad"] = true;
            PilaForms.AgregarForm("RegistrarEditorial_22.aspx");
            Response.Redirect("RegistrarCiudad_101.aspx");
        }

        protected void ddl_provinciaApunte_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboCiudad(Convert.ToInt32(ddl_provincia.SelectedValue));
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
            ddl_ciudad.DataSource = CiudadDao.ConsultarCiudadXProvincia(idProvincia);
            ddl_ciudad.DataTextField = "nombreciudad";
            ddl_ciudad.DataValueField = "idCiudad";
            ddl_ciudad.DataBind();
            ddl_ciudad.Items.Insert(0, new ListItem("(Ciudad)", "0"));
            ddl_ciudad.SelectedIndex = 0;
        }
    }
}