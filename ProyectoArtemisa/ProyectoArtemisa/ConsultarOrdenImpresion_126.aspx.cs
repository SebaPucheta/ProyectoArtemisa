using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                InicializarColeccion();
            }
        }

        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            OrdenImpresionEntidadQuery nuevaOrden = new OrdenImpresionEntidadQuery();
            nuevaOrden.idApunte = 
        }

        //Inicializar la coleccion de ordenes de impresion
        protected void InicializarColeccion()
        {
            ColeccionOrdenImpresion.Inicializar(OrdenesImpresionDao.ListarOrdenApuntePendientes());
        }

        //Creo una tabla para luego cargarla en el GridView
        protected void CargarApunteEnGrilla()
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

                if (orden.nombreOrdenImpresion.Equals("Impreso"))
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
           
        }

        protected void btn_consultarApunte_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


    }
}