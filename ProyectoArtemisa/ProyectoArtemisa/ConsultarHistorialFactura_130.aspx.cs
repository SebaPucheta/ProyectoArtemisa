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
                
            }
            txt_codigoBarra.Focus();
            if(dgv_grillaOrdenesImpresion.Rows.Count>0)
            {
                lbl_nombreGrilla.Visible = true;
            }
            else
            {
                lbl_nombreGrilla.Visible = false;
            }

        }
        protected void SumarTotal()
        {
            double total = 0;
            foreach (GridViewRow fila in dgv_grillaOrdenesImpresion.Rows)
            {
                total += Convert.ToDouble(fila.Cells[6].Text.Substring(1));
            }
            txt_total.Text = total.ToString("N2");
        }
        protected void btn_consultarFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idFactura = int.Parse(dgv_grillaOrdenesImpresion.SelectedDataKey.Value.ToString());
            Session["idFactura"]= idFactura;
            cargarGrillaDetalleFactura(FacturaDao.DevolverDetalleFactura(idFactura));
            lbl_grillaDetalleFactura.Visible = true;
            if(dgv_grillaOrdenesImpresion.SelectedRow.Cells[5].Text.Equals("Aprobado"))
            { btn_entrega.Visible = true; }
        }

        protected void dgv_grilla_OnPageIndexChanging(Object sender, GridViewPageEventArgs e)
        {
            dgv_grillaOrdenesImpresion.PageIndex = e.NewPageIndex;
            cargarGrillaFactura(FacturaDao.ListarFacturas(txt_fechaDesde.Text, txt_fechaHasta.Text));
        }
        

        protected void cargarGrillaFactura(List<FacturaEntidadQuery> listaFacturas)
        {
            DataTable tabla = new DataTable();
            DataRow fila;

            //Creo las columnas de la tabla
            tabla.Columns.Add("idFactura", typeof(int));//key name
            tabla.Columns.Add("fecha", typeof(DateTime));
            tabla.Columns.Add("total", typeof(string));
            tabla.Columns.Add("nombreCompletoEmpleado", typeof(string));
            tabla.Columns.Add("nombreCompletoCliente", typeof(string));
            tabla.Columns.Add("tipoPago", typeof(string));
            tabla.Columns.Add("estadoPago", typeof(string));
            foreach (FacturaEntidadQuery factura in listaFacturas)
            {
                fila = tabla.NewRow();

                fila[0] = factura.idFactura;
                fila[1] = factura.fecha;
                fila[2] = "$" + factura.total.ToString("N2");
                fila[3] = factura.nombreCompletoEmpleado;
                fila[4] = factura.nombreCompletoCliente;
                fila[5] = factura.descripcionTipoPago;
                fila[6] = factura.descripcionEstadoPago;
                tabla.Rows.Add(fila);
            }

            DataView dataView = new DataView(tabla);

            dgv_grillaOrdenesImpresion.DataSource = dataView;
            dgv_grillaOrdenesImpresion.DataKeyNames = new string[] { "idFactura" };
            dgv_grillaOrdenesImpresion.DataBind();
        }
        protected void cargarGrillaDetalleFactura(List<DetalleFacturaEntidadQuery> listaDetalleFacturas)
        {
            DataTable tabla = new DataTable();
            DataRow fila;

            //Creo las columnas de la tabla
            tabla.Columns.Add("idDetalleFactura", typeof(int));//key name
            tabla.Columns.Add("nombreItem", typeof(string));
            tabla.Columns.Add("nombreTipoItem", typeof(string));
            tabla.Columns.Add("tipoApunte", typeof(string));
            tabla.Columns.Add("cantidad", typeof(string));
            tabla.Columns.Add("subtotal", typeof(string));
            foreach (DetalleFacturaEntidadQuery detalleFactura in listaDetalleFacturas)
            {
                fila = tabla.NewRow();

                fila[0] = detalleFactura.idDetalleFactura;
                fila[2] = detalleFactura.nombreItem;
                if (detalleFactura.item is ApunteEntidad)
                {
                    ApunteEntidadQuery apunte = (ApunteEntidadQuery)detalleFactura.item;
                    fila[1] = apunte.nombreApunte;
                    fila[3] = apunte.nombreTipoApunte;
                }
                else
                {
                    LibroEntidadQuery libro = (LibroEntidadQuery)detalleFactura.item;
                    fila[1] = libro.nombreLibro;
                    fila[3] = "Impreso";
                }
                fila[4] = detalleFactura.cantidad;
                fila[5] = "$" + detalleFactura.subtotal.ToString("N2");
                tabla.Rows.Add(fila);
            }

            DataView dataView = new DataView(tabla);

            dgv_detalleFactura.DataSource = dataView;
            dgv_detalleFactura.DataKeyNames = new string[] { "idDetalleFactura" };
            dgv_detalleFactura.DataBind();
        }

        ///Comentado por Pucho, es un metodo de Martin
        //protected void cargarGrillaHistorialFactura()
        //{
        //    dgv_grillaOrdenesImpresion.DataSource = FacturaDao.ListarFacturas(txt_fechaDesde.Text, txt_fechaHasta.Text);
        //    dgv_grillaOrdenesImpresion.DataKeyNames = new string[] { "idFactura" };
        //    dgv_grillaOrdenesImpresion.DataBind();
        //}


        /// <summary>
        /// Autor: Martin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            cargarGrillaFactura(FacturaDao.ListarFacturas(txt_fechaDesde.Text, txt_fechaHasta.Text));
            SumarTotal();
            lbl_nombreGrilla.Visible = true;
            btn_entrega.Visible = false;
            //Saco la grilla de abajo
            lbl_grillaDetalleFactura.Visible = false;
            dgv_detalleFactura.DataSource = null;
            dgv_detalleFactura.DataBind();
        }
        protected void btn_entregado_Click(object sender, EventArgs e)
        {
            FacturaDao.ActualizarEstado(int.Parse(Session["idFactura"].ToString()), 4);
            Response.Redirect("ConsultarHistorialFactura_130.aspx");
        }

        protected void txt_codiboBarra_OnTextChanged(object sender, EventArgs e)
        {
            if(!txt_codigoBarra.Text.Equals(""))
            {
                cargarGrillaFactura(FacturaDao.ListarFacturasPorCodigoBarra(double.Parse(txt_codigoBarra.Text)));
                SumarTotal();
                lbl_nombreGrilla.Visible = true;
                Session["frenarEnter"] = true;
                //Limpio el texto
                txt_codigoBarra.Text = "";
                //Saco la grilla de abajo
                lbl_grillaDetalleFactura.Visible = false;
                dgv_detalleFactura.DataSource = null;
                dgv_detalleFactura.DataBind();
            }
            
        }
    }
}