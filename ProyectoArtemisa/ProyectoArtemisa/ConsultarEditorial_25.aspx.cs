using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseDeDatos;
using Entidades;
using Negocio;
using System.Data;

namespace ProyectoArtemisa
{
    public partial class ConsultarEditorial_25 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarComboProvincia();
            }
        }
        

        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            CargarEditorialEnGrilla(BuscarListaEditorialXFiltro());
        }

        protected void btn_modificarEditorial_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["idEditorial"] = (int)dgv_grillaEditorial.SelectedDataKey.Value;
            PilaForms.AgregarForm("ConsultarEditorial_25.aspx");
            Response.Redirect("RegistrarEditorial_22.aspx");
        }

        protected void btn_eliminarEditorial_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            EditorialDao.EliminarEditorial((int)dgv_grillaEditorial.DataKeys[e.RowIndex].Value);
        }

        private void CargarEditorialEnGrilla(Func<List<EditorialEntidadQuery>> BuscarListaEditorialXFiltro)
        {
            throw new NotImplementedException();
        }

        protected void ddl_provincia_SelectedIndexChanged(object sender, EventArgs e)
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

        protected List<EditorialEntidadQuery> BuscarListaEditorialXFiltro()
        {
            string nombreEditorial = txt_nombreEditorial.Text;
            string nombreContacto = txt_nombreContacto.Text; 
            string provincia = "";
            string ciudad = ""; 

            if (Convert.ToInt32(ddl_provincia.SelectedIndex) != 0)
            {
                provincia = ddl_provincia.SelectedValue;
            }

            if (Convert.ToInt32(ddl_ciudad.SelectedIndex) != 0)
            {
                ciudad = ddl_ciudad.SelectedValue;
            }

            return EditorialDao.ConsultarEditorialXFiltro(ciudad, provincia, nombreContacto, nombreEditorial);
        }


        protected void CargarEditorialEnGrilla(List<EditorialEntidadQuery> listaEditorialFiltrados)
        {
            DataTable tabla = new DataTable();
            DataRow fila;

            //Creo las columnas de la tabla
            tabla.Columns.Add("idEditorial", typeof(int));
            tabla.Columns.Add("nombreEditorial", typeof(string));
            tabla.Columns.Add("nombreContacto", typeof(string));
            tabla.Columns.Add("telefono", typeof(string));
            tabla.Columns.Add("nombreCiudadEditorial", typeof(string));
            tabla.Columns.Add("direccion", typeof(string));
            tabla.Columns.Add("email", typeof(string));

            foreach (EditorialEntidadQuery editorial in listaEditorialFiltrados)
            {
                fila = tabla.NewRow();

                fila[0] = editorial.idEditorial;
                fila[1] = editorial.nombreEditorial;
                fila[2] = editorial.nombreContacto;
                fila[3] = editorial.telefono;
                fila[4] = editorial.nombreCiudadEditorial + ", " + editorial.nombreProvinciaEditorial;
                fila[5] = editorial.direccion;
                fila[6] = editorial.email;

                tabla.Rows.Add(fila);
            }

            DataView dataView = new DataView(tabla);

            dgv_grillaEditorial.DataSource = dataView;
            dgv_grillaEditorial.DataKeyNames = new string[] { "idEditorial" };
            dgv_grillaEditorial.DataBind();
        }

        
    }
}