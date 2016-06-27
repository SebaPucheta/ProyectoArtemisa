using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseDeDatos;
using Negocio;
using Entidades;

namespace ProyectoArtemisa
{
    public partial class RegistrarCiudad_101 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarComboProvincia();
                if ((bool)Session["modificarCiudad"])
                {
                    ddl_provincia.SelectedIndex =CiudadDao.ConsultaridProvinciaDeLaCiudad((int)Session["idCiudad"]);
                    txt_nombreCiudad.Text = CiudadDao.ConsultarCiudad((int)Session["idCiudad"]).nombreCiudad;
                }
                else 
                {
                    if (Session["idProvincia"] != null)
                    {
                        ddl_provincia.SelectedValue = Session["idProvincia"].ToString();
                    }
                }
                
                
            }
            
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

        protected void LimpiarForm()
        {
            CargarComboProvincia();
            txt_nombreCiudad.Text = "";
        }

        protected CiudadEntidad CargarCiudadDesdeForm()
        {
            CiudadEntidad ciudad = new CiudadEntidad();
            ciudad.idProvincia =Convert.ToInt32(ddl_provincia.SelectedValue);
            ciudad.nombreCiudad = txt_nombreCiudad.Text;
            return ciudad;

        }
        protected void btn_registrar_Click(object sender, EventArgs e)
        {
            
            if ((bool)Session["modificarCiudad"])
            {
                CiudadEntidad ciudad = CargarCiudadDesdeForm();
                ciudad.idCiudad = (int)Session["idCiudad"];
                CiudadDao.ModificarCiudad(ciudad);
                Session["modificarCiudad"] = false;
            }
            else
            {
                CiudadDao.RegistrarCiudad(CargarCiudadDesdeForm());
            }
            Response.Redirect(PilaForms.DevolverForm());
        }

        protected void btn_salir_Click(object sender, EventArgs e)
        {
            Session["modificarCiudad"] = false;
            Response.Redirect(PilaForms.DevolverForm());
        }

        protected void btn_registrarProvincia_onClick(object sender, EventArgs e)
        {
            PilaForms.AgregarForm("RegistrarCiudad_101.aspx");
            Response.Redirect("RegistrarProvincia_105.aspx");
        }

        protected void btn_modificarProvincia_onClick(object sender, EventArgs e)
        {
            Session["idProvincia"] = ddl_provincia.SelectedValue;
            Session["modificarProvincia"] = true;
            PilaForms.AgregarForm("RegistrarCiudad_101.aspx");
            Response.Redirect("RegistrarProvincia_105.aspx");
        }


    }
}