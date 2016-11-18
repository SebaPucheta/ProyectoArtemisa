using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using BaseDeDatos;
using System.Data;
namespace ProyectoArtemisa
{
    public partial class ConsultarHistorialIngresoLibro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime hoy = DateTime.Now;
                txt_fechaHasta.Text = hoy.AddDays(1).ToString("dd/MM/yyyy");
                txt_fechaDesde.Text = "01/01/1900";
                CargarComboProveedor();
            }
        }

        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            CargarGrillaIngresoLibro(IngresoLibroDao.DevolverIngresoLibroPorFiltro(txt_fechaDesde.Text,txt_fechaHasta.Text,txt_usuario.Text, ddl_proveedores.SelectedValue));
            SumarTotal();
        }

        protected void SumarTotal()
        {
            double total = 0;
            foreach ( GridViewRow fila in dgv_grillaIngresoLibros.Rows)
            {
                total = total + double.Parse( fila.Cells[3].Text.Substring(1));
            }
            lbl_total.Text = total.ToString("N2");
        }

        protected void CargarComboProveedor()
        {
            ddl_proveedores.DataSource = ProveedorDao.ConsultarProveedores();
            ddl_proveedores.DataTextField = "nombreProveedor";
            ddl_proveedores.DataValueField = "idProveedor";
            ddl_proveedores.DataBind();
            ddl_proveedores.Items.Insert(0, new ListItem("Todos", "0"));
            ddl_proveedores.SelectedIndex = 0;
        }
        protected void btn_reporte_Click(object sender, EventArgs e)
        {
            string url = "";
            if(!ddl_proveedores.SelectedItem.Text.Equals("Todos"))
            {
                url = "Reportes/GenerarIngresoStockLibros_151.aspx?desde=" + txt_fechaDesde.Text + "&hasta=" + txt_fechaHasta.Text + "&proveedor=" + ddl_proveedores.SelectedItem.Text + "&apellido=" + txt_usuario.Text + "&nombre=" + txt_usuario.Text;
            }
            else
            {
                url = "Reportes/GenerarIngresoStockLibros_151.aspx?desde=" + txt_fechaDesde.Text + "&hasta=" + txt_fechaHasta.Text + "&proveedor=&apellido=" + txt_usuario.Text + "&nombre=" + txt_usuario.Text;
            }
            Response.Redirect(url);
        }
        
        protected void CargarGrillaIngresoLibro(List<IngresoLibroEntidadQuery> listaIngresoLibro)
        {
            DataTable tabla = new DataTable();
            DataRow fila;

            //Creo las columnas de la tabla
            tabla.Columns.Add("idIngresoLibro", typeof(int));
            tabla.Columns.Add("fecha", typeof(string));//key name
            tabla.Columns.Add("proveedor", typeof(string));
            tabla.Columns.Add("usuario", typeof(string));
            tabla.Columns.Add("total", typeof(string));

            foreach (IngresoLibroEntidadQuery ingresoLibro in listaIngresoLibro)
            {
                fila = tabla.NewRow();

                fila[0] = ingresoLibro.idIngresoLibro;
                fila[1] = ingresoLibro.fecha;
                fila[2] = ingresoLibro.nombreProveedor;
                fila[3] = ingresoLibro.nombreCliente + " " + ingresoLibro.apellidoCliente ;
                fila[4] = "$" + ingresoLibro.total.ToString("N2");
                tabla.Rows.Add(fila);
            }

            DataView dataView = new DataView(tabla);

            dgv_grillaIngresoLibros.DataSource = dataView;
            dgv_grillaIngresoLibros.DataKeyNames = new string[] { "idIngresoLibro" };
            dgv_grillaIngresoLibros.DataBind();
        }
        protected void dgv_grilla_OnPageIndexChanging(Object sender, GridViewPageEventArgs e)
        {
            dgv_grillaIngresoLibros.PageIndex = e.NewPageIndex;
            CargarGrillaIngresoLibro(IngresoLibroDao.DevolverIngresoLibroPorFiltro(txt_fechaDesde.Text, txt_fechaHasta.Text, txt_usuario.Text, ddl_proveedores.SelectedValue));
        }

        protected void CargarGrillaDetalleIngresoLibro(List<DetalleIngresoLibroEntidadQuery> listaIngresoLibro)
        {
            DataTable tabla = new DataTable();
            DataRow fila;

            //Creo las columnas de la tabla
            tabla.Columns.Add("idDetalleIngresoLibro", typeof(int));
            tabla.Columns.Add("nombreLibro", typeof(string));//key name
            tabla.Columns.Add("cantidad", typeof(string));
            tabla.Columns.Add("precio", typeof(string));
            tabla.Columns.Add("total", typeof(string));

            foreach (DetalleIngresoLibroEntidadQuery DetalleIngresoLibro in listaIngresoLibro)
            {
                fila = tabla.NewRow();

                fila[0] = DetalleIngresoLibro.idDetalleIngresoLibro;
                fila[1] = DetalleIngresoLibro.nombreLibro;
                fila[2] = DetalleIngresoLibro.cantidad + " Unidades";
                fila[3] = "$" + DetalleIngresoLibro.precioUnitario;
                fila[4] = "$" + (DetalleIngresoLibro.cantidad * DetalleIngresoLibro.precioUnitario).ToString();
                tabla.Rows.Add(fila);
            }

            DataView dataView = new DataView(tabla);

            dgv_grillaDetalleIngresoLibro.DataSource = dataView;
            dgv_grillaDetalleIngresoLibro.DataKeyNames = new string[] { "idDetalleIngresoLibro" };
            dgv_grillaDetalleIngresoLibro.DataBind();
        }

        protected void btn_consultarFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = dgv_grillaIngresoLibros.SelectedDataKey.Value.ToString();
                CargarGrillaDetalleIngresoLibro(IngresoLibroDao.DevolverDetalleIngresoLibroPorId(int.Parse(key)));
        }
    }
}