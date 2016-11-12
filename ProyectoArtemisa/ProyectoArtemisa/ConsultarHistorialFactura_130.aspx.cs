using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using System.Data;
using BaseDeDatos;


namespace ProyectoArtemisa
{
    public partial class ConsultarHistorialFactura_130 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbl_total.Visible = false;
                txt_total.Visible = false;
                
            }

        }
        protected void SumarTotal()
        {
            double total = 0;
            foreach (GridViewRow fila in dgv_grillaOrdenesImpresion.Rows)
            {
                total += Convert.ToDouble(fila.Cells[3].Text);
            }
            txt_total.Text = total.ToString();
        }
        protected void btn_consultarFactura_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgv_grilla_OnPageIndexChanging(Object sender, GridViewPageEventArgs e)
        {
            dgv_grillaOrdenesImpresion.PageIndex = e.NewPageIndex;
            cargarGrillaHistorialFactura();
        }
        ///Comentado por Martin, es un metodo de Puchi

        //protected void cargarGrillaFactura(List<FacturaEntidadQuery> listaFacturas)
        //{
        //    DataTable tabla = new DataTable();
        //    DataRow fila;

        //    //Creo las columnas de la tabla
        //    tabla.Columns.Add("idFactura", typeof(int));//key name
        //    tabla.Columns.Add("fecha", typeof(DateTime));
        //    tabla.Columns.Add("total", typeof(float));
        //    tabla.Columns.Add("tipoPago", typeof(string));

        //    foreach (FacturaEntidadQuery factura in listaFacturas)
        //    {
        //        fila = tabla.NewRow();

        //        fila[0] = factura.idFactura;
        //        fila[1] = factura.fecha;
        //        fila[2] = factura.total;
        //        fila[3] = factura.nombreTipoPago;
        //        tabla.Rows.Add(fila);
        //    }

        //    DataView dataView = new DataView(tabla);

        //    dgv_grillaOrdenesImpresion.DataSource = dataView;
        //    dgv_grillaOrdenesImpresion.DataKeyNames = new string[] { "idFactura" };
        //    dgv_grillaOrdenesImpresion.DataBind();
        //}

        protected void cargarGrillaHistorialFactura()
        {
            dgv_grillaOrdenesImpresion.DataSource = FacturaDao.ListarFacturas(txt_fechaDesde.Text, txt_fechaHasta.Text);
            dgv_grillaOrdenesImpresion.DataKeyNames = new string[] { "idFactura" };
            dgv_grillaOrdenesImpresion.DataBind();
        }


        /// <summary>
        /// Autor: Martin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            lbl_total.Visible = true;
            txt_total.Visible = true;
            cargarGrillaHistorialFactura();
            SumarTotal();
             
        }
    }
}