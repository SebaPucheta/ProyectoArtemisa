using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BaseDeDatos;
using System.Data;
using Entidades;
using Negocio;

namespace ProyectoArtemisa
{
    public partial class ConsultarOrdenImpresion_126 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(bool.Parse(Session["agregarOrden"].ToString()))
                {
                    CargarNuevaOrden();
                    CargarOrdenEnGrilla();
                    BorrarVariablesGlobales();
                }
                else
                {
                    CargarOrdenEnGrilla();
                }
            }
        }

        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            Session["agregarOrden"] = true;
            PilaForms.AgregarForm("ConsultarOrdenImpresion_126.aspx");
            Response.Redirect("ConsultarLibroApunte.aspx");
        }
        
        //Registra una orden de impresion.
        protected void CargarNuevaOrden()
        {
            OrdenImpresionEntidadQuery nuevaOrden = new OrdenImpresionEntidadQuery();
            nuevaOrden.idApunte = int.Parse(Session["idApunte"].ToString());
            nuevaOrden.idEstadoOrden= 1;
            nuevaOrden.nombreApunte = Session["nombreApunte"].ToString();
            nuevaOrden.nombreEstadoOrdenImpresion = EstadoOrdenImpresionDao.DevolverNombreEstado(1);
            nuevaOrden.fecha = DateTime.Now;
            nuevaOrden.idOrdenImpresion = OrdenImpresionDao.RegistrarOrdenImpresion(nuevaOrden);
        }

        protected void BorrarVariablesGlobales()
        {
            Session["agregarOrden"] = false;
            Session["nombreApunte"] = "";
            Session["idApunte"] = null;
        }
    
        //Creo una tabla para luego cargarla en el GridView
        protected void CargarOrdenEnGrilla()
        {
            DataTable tabla = new DataTable();
            DataRow fila;

            //Creo las columnas de la tabla
            tabla.Columns.Add("idOrden", typeof(int));
            tabla.Columns.Add("nombre", typeof(string));
            tabla.Columns.Add("cantidad", typeof(int));
            tabla.Columns.Add("chk_impreso", typeof(bool));

            foreach (OrdenImpresionEntidadQuery orden in OrdenImpresionDao.ListarOrdenApuntePendientes())
            {
                fila = tabla.NewRow();

                fila[0] = orden.idOrdenImpresion;
                fila[1] = orden.nombreApunte;
                fila[2] = orden.cantidad;

                //No toma los valores true o false el checkbox
                if (orden.nombreEstadoOrdenImpresion.Equals("Impreso"))
                {
                    fila[3] = true;
                }
                else
                {
                    fila[3] = false;
                }

                
                tabla.Rows.Add(fila);
            }

            DataView dataView = new DataView(tabla);
            
            dgv_grillaOrdenesImpresion.DataKeyNames = new string[] { "idOrden" };
            dgv_grillaOrdenesImpresion.DataSource = dataView;
            dgv_grillaOrdenesImpresion.DataBind();
        }
        protected void btn_eliminarOrden_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            OrdenImpresionDao.EliminarOrdenImpresion((int)dgv_grillaOrdenesImpresion.DataKeys[e.RowIndex].Value);
            CargarOrdenEnGrilla();
        }

        protected void btn_consultarApunte_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["idApunte"] = OrdenImpresionDao.DevolverIdApunte((int)dgv_grillaOrdenesImpresion.SelectedDataKey.Value);
            PilaForms.AgregarForm("ConsultarOrdenImpresion_126.aspx");
            Response.Redirect("ConsultarOrdenImpresion_126.aspx");
        }

        protected void chk_impreso_OnCheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)sender;
            int indice = ((GridViewRow)((DataControlFieldCell)check.Parent).Parent).RowIndex;
            if(check.Checked)
            { OrdenImpresionDao.CambiarEstadoImpreso((int)dgv_grillaOrdenesImpresion.DataKeys[indice].Value); }
            else
            { OrdenImpresionDao.CambiarEstadoPendiente((int)dgv_grillaOrdenesImpresion.DataKeys[indice].Value); }
            
        }

        protected void chk_enLocal_OnCheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)sender;
            int indice = ((GridViewRow)((DataControlFieldCell)check.Parent).Parent).RowIndex;
            if (check.Checked)
            { OrdenImpresionDao.CambiarEstadoEnLocal((int)dgv_grillaOrdenesImpresion.DataKeys[indice].Value); }
            else
            { OrdenImpresionDao.CambiarEstadoImpreso((int)dgv_grillaOrdenesImpresion.DataKeys[indice].Value); }
            
            
        }


    }
}