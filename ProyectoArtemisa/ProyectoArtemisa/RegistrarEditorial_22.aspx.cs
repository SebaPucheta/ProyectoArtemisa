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
            if(!IsPostBack)
            {
                CargarComboProvincia();
            }
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            //    int idEditorial
            //string nombre
            //string telefono
            //string direccion
            //string email
            //string nombreContacto

            EditorialEntidad editorial = new EditorialEntidad();
            editorial.nombreEditorial = txt_nombreEditorial.Text;
            editorial.nombreContacto = txt_nombreContacto.Text;
            editorial.telefono = txt_telefono.Text;
            editorial.email = txt_email.Text;
            editorial.direccion = txt_direccion.Text;
            editorial.idCiudadEditorial = Convert.ToInt32(ddl_ciudad.SelectedValue);
            EditorialDao.RegistrarEditorial(editorial);

            if (PilaForms.pila.Peek().Equals("Default.aspx"))
            {
                LimpiarForm();
            }
            else
            {
                Response.Redirect(PilaForms.DevolverForm());
            }

        }
        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(PilaForms.DevolverForm());
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
            PilaForms.AgregarForm("RegistrarFacultad_65.aspx");
            Response.Redirect("RegistrarProvincia_105.aspx");
        }
        protected void btn_registrarCiudad_onClick(object sender, EventArgs e)
        {
            PilaForms.AgregarForm("RegistrarFacultad_65.aspx");
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
            ddl_ciudad.DataSource = CiudadDao.ConsultarCiudad(idProvincia);
            ddl_ciudad.DataTextField = "nombreciudad";
            ddl_ciudad.DataValueField = "idCiudad";
            ddl_ciudad.DataBind();
            ddl_ciudad.Items.Insert(0, new ListItem("(Ciudad)", "0"));
            ddl_ciudad.SelectedIndex = 0;
        }
    }
}