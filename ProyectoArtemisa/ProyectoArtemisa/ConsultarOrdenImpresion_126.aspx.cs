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
                }
                else
                {
                    InicializarColeccion();
                }
            }
        }

        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            Session["agregarOrden"] = true;
            PilaForms.AgregarForm("ConsultarOrdenImpresion_126.aspx");
            Response.Redirect("ConsultarLibroApunte.aspx");
        }
        
        protected void CargarNuevaOrden()
        {
            OrdenImpresionEntidadQuery nuevaOrden = new OrdenImpresionEntidadQuery();
            nuevaOrden.idApunte = int.Parse(Session["idApunte"].ToString());
            nuevaOrden.idEstadoOrden= 1;
            nuevaOrden.nombreApunte = Session["nombreApunte"].ToString();
            nuevaOrden.nombreEstadoOrdenImpresion = EstadoOrdenImpresionDao.DevolverNombreEstado(1);
            nuevaOrden.fecha = DateTime.Now;
            nuevaOrden.idOrdenImpresion = OrdenImpresionDao.RegistrarOrdenImpresion(nuevaOrden);
            ColeccionOrdenImpresion.GuardarOrdenImpresion(nuevaOrden);
            CargarOrdenEnGrilla();
            BorrarVariablesGlobales();
        }

        protected void BorrarVariablesGlobales()
        {
            Session["agregarOrden"] = false;
            Session["nombreApunte"] = "";
            Session["idApunte"] = null;
        }

        //Inicializar la coleccion de ordenes de impresion y carga la grilla
        protected void InicializarColeccion()
        {
            ColeccionOrdenImpresion.Inicializar(OrdenImpresionDao.ListarOrdenApuntePendientes());
            CargarOrdenEnGrilla();
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

            foreach (OrdenImpresionEntidadQuery orden in ColeccionOrdenImpresion.OrdenesImpresion)
            {
                fila = tabla.NewRow();

                fila[0] = orden.idOrdenImpresion;
                fila[1] = orden.nombreApunte;
                fila[2] = orden.cantidad;

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

            dgv_grillaOrdenesImpresion.DataSource = dataView;
            dgv_grillaOrdenesImpresion.DataKeyNames = new string[] { "idOrden" };
            dgv_grillaOrdenesImpresion.DataBind();
        }
        protected void btn_eliminarOrden_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            OrdenImpresionDao.EliminarOrdenImpresion((int)dgv_grillaOrdenesImpresion.DataKeys[e.RowIndex].Value);
            ColeccionOrdenImpresion.EliminarOrdenImpresion((int)dgv_grillaOrdenesImpresion.DataKeys[e.RowIndex].Value);
            CargarOrdenEnGrilla();
        }

        protected void btn_consultarApunte_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["idApunte"] = OrdenImpresionDao.DevolverIdApunte((int)dgv_grillaOrdenesImpresion.SelectedDataKey.Value);
            PilaForms.AgregarForm("ConsultarOrdenImpresion_126.aspx");
            Response.Redirect("ConsultarOrdenImpresion_126.aspx");
        }

        protected void chk_impreso_OnCheckedChanged(EventArgs e)
        {
            OrdenImpresionDao.CambiarEstadoImpreso((int)dgv_grillaOrdenesImpresion.SelectedDataKey.Value);

        }

        protected void chk_enLocal_OnCheckedChanged(EventArgs e)
        {
            OrdenImpresionDao.CambiarEstadoEnLocal((int)dgv_grillaOrdenesImpresion.SelectedDataKey.Value);
        }


    }
}