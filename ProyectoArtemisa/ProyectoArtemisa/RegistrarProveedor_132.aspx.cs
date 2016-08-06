using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using BaseDeDatos;

namespace ProyectoArtemisa
{
    public partial class RegistrarProveedor_132 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((PilaForms.pila.Peek().Equals("RegistrarProveedor_132.aspx")) || ((bool)Session["modificarProveedor"]))
                {
                    CargarUnObjetoEnElForm(ProveedorDao.ConsultarUnProveedor(int.Parse(Session["idProveedor"].ToString())));
                }
                else
                {
                    CargarComboProvincia();
                }

            }
        }


        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            //TENGO QUE PONER UNA LISTA DE EDITORIALES DE CADA PROVEEDOR
            if ((PilaForms.pila.Peek().Equals("ConsultarProveedor_134.aspx")) || ((bool)Session["modificarProveedor"]))
            {
                ProveedorEntidad proveedor = CrearUnObjetoDesdeElForm();
                proveedor.idProveedor = int.Parse(Session["idProveedor"].ToString());
                ProveedorEntidad.ModificarProveedor(proveedor);
                Session["idProveedor"] = null;
                Session["modificarProveedor"] = false;
                Response.Redirect(PilaForms.DevolverForm());
            }
            else
            {
                ProveedorDao.RegistrarProveedor(CrearUnObjetoDesdeElForm());
                Response.Redirect(PilaForms.DevolverForm());
            }

        }
        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Session["modificarProveedor"] = false;
            Response.Redirect(PilaForms.DevolverForm());
        }

        protected void CargarUnObjetoEnElForm(ProveedorEntidad proveedor)
        {
            txt_nombreProveedor.Text = proveedor.nombreProveedor;
            txt_nombreContacto.Text = proveedor.nombreContactoProveedor;
            txt_telefono.Text = proveedor.telefonoProveedor;
            txt_direccion.Text = proveedor.direccionProveedor;
            txt_email.Text = proveedor.emailProveedor;   
            //Combos         
            CargarComboProvincia();
            ddl_provincia.SelectedValue = CiudadDao.ConsultaridProvinciaDeLaCiudad(proveedor.idCiudadEditorial).ToString();
            CargarComboCiudad(Convert.ToInt32(ddl_provincia.SelectedValue));
            ddl_ciudad.SelectedValue = proveedor.idCiudadEditorial.ToString();
        }

        protected ProveedorEntidad CrearUnObjetoDesdeElForm()
        {
            ProveedorEntidad proveedor = new ProveedorEntidad();
            proveedor.nombreProveedor = txt_nombreProveedor.Text;
            proveedor.nombreContactoProveedor = txt_nombreContacto.Text;
            proveedor.telefonoProveedor = txt_telefono.Text;
            proveedor.emailProveedor = txt_email.Text;
            proveedor.direccionProveedor = txt_direccion.Text;
            proveedor.idCiudadEditorial = Convert.ToInt32(ddl_ciudad.SelectedValue);
            return proveedor;
        }

        protected void LimpiarForm()
        {
            txt_nombreProveedor.Text = "";
            txt_nombreContacto.Text = "";
            txt_email.Text = "";
            txt_direccion.Text = "";
            txt_telefono.Text = "";
            ddl_ciudad.SelectedIndex = 0;
            ddl_provincia.SelectedIndex = 0;
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

        protected void CargarGrillaEditoriales()
        {
            //Trae solamente el id y el nombre y muestra el nombre de la editorial
            dgv_grillaEditoriales.DataSource = EditorialDao.ConsultarEditorial();
            dgv_grillaEditoriales.DataKeyNames = new string[] { "idEditorial" };
            dgv_grillaEditoriales.DataBind();
        }

    }
}