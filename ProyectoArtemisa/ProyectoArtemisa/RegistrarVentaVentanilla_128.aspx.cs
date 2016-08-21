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
    public partial class RegistrarVentaVentanilla_128 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (bool.Parse(Session["agregarDetalle"].ToString()))
                {
                    CargarGrillaDetalles();
                    CargarNuevoDetalle();
                    CalcularTotal();
                    BorrarVariablesGlobales();
                }
                else
                {
                    inicializarVariableSessionTabla();
                }
            }
            lbl_total.Text = CalcularTotal().ToString();
        }

        //Cargar la Grilla que tiene un nuevo detalle
        protected void CargarNuevoDetalle()
        {
            dgv_nuevoDetalle.Visible = true;
            DataTable tabla = new DataTable();
            DataRow fila;

            //Creo las columnas de la tabla
            tabla.Columns.Add("idApunte", typeof(int));
            tabla.Columns.Add("nombreApunte", typeof(string));

            fila = tabla.NewRow();

            fila[0] = int.Parse(Session["idApunte"].ToString());
            fila[1] = Session["nombreApunte"].ToString();
            tabla.Rows.Add(fila);
            DataView dataView = new DataView(tabla);

            dgv_nuevoDetalle.DataKeyNames = new string[] { "idApunte" };
            dgv_nuevoDetalle.DataSource = dataView;
            dgv_nuevoDetalle.DataBind();

            ((TextBox)dgv_nuevoDetalle.Rows[0].Cells[1].FindControl("txt_precioUnitario")).Text = Session["precioUnitario"].ToString();
        }

        //Inicializa la variable de session que contiene la tabla con los detalles de factura
        protected void inicializarVariableSessionTabla()
        {
            DataTable tabla = new DataTable();

            //Creo las columnas de la tabla
            tabla.Columns.Add("idApunte", typeof(int));
            tabla.Columns.Add("nombre", typeof(string));
            tabla.Columns.Add("precioUnitario", typeof(float));
            tabla.Columns.Add("cantidad", typeof(int));
            tabla.Columns.Add("subtotal", typeof(float));
            
            Session["tablaDetalles"] = tabla;
        }

        //Pasa un detalle de la grilla de nuevos detalles a la grilla de detalles
        protected void CargarNuevoDetalleGrillaDetalle()
        {
            DataRow fila;

            fila = (Session["tablaDetalles"] as DataTable).NewRow();

            fila[0] = int.Parse(Session["idApunte"].ToString());
            fila[1] = Session["nombreApunte"].ToString();
            fila[2] = float.Parse(((TextBox)dgv_nuevoDetalle.Rows[0].Cells[1].FindControl("txt_precioUnitario")).Text);
            fila[3] = Convert.ToInt32(((TextBox)dgv_nuevoDetalle.Rows[0].Cells[2].FindControl("txt_cantidad")).Text);
            fila[4] = float.Parse(fila[2].ToString()) * float.Parse(fila[3].ToString());

            (Session["tablaDetalles"] as DataTable).Rows.Add(fila);

            CargarGrillaDetalles();
        }

        //Carga la grilla detalles con los detalles que contiene la variable session
        protected void CargarGrillaDetalles()
        {
            DataView dataView = new DataView(Session["tablaDetalles"] as DataTable);

            dgv_grillaDetalleFactura.DataKeyNames = new string[] { "idOrden" };
            dgv_grillaDetalleFactura.DataSource = dataView;
            dgv_grillaDetalleFactura.DataBind();
        }

        //Inicializa las variable globales
        protected void  BorrarVariablesGlobales()
        {
            Session["nombreApunte"] = "";
            Session["idApunte"] = null;
            Session["precioUnitario"] = null;
            Session["agregarDetalle"] = false;
        }

        protected double CalcularTotal()
        {
            double total=0;
            foreach(DataRow fila in (Session["tablaDetalles"] as DataTable).Rows )
            {
                total += Convert.ToDouble(fila[4]);
            }
            return total;
        }
        protected void btn_confirmar_Click(object sender, EventArgs e)
        {
            FacturaDao.RegistrarFactura(CrearFactura());
        }

        protected void btn_agregarDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarNuevoDetalleGrillaDetalle();
            dgv_nuevoDetalle.Visible = false;
        }

        protected void btn_limpiarGrilla_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            dgv_nuevoDetalle.Visible = false;
        }

        protected FacturaEntidad CrearFactura()
        {
            FacturaEntidad factura = new FacturaEntidad();
            List<DetalleFacturaEntidad> listaDetalles = new List<DetalleFacturaEntidad>(); 
            factura.fecha = Convert.ToDateTime(txt_fecha.Text);
            factura.total = float.Parse(txt_fecha.Text);
            foreach (DataRow fila in (Session["tablaDetalles"] as DataTable).Rows)
            {
                DetalleFacturaEntidad detalleFactura = new DetalleFacturaEntidad();
                detalleFactura.idItem = Convert.ToInt32(fila[0]);
                detalleFactura.cantidad = Convert.ToInt32(fila[3]);
                detalleFactura.subtotal = float.Parse(fila[4].ToString());
                listaDetalles.Add(detalleFactura);
            }

            factura.listaDetalleFactura = listaDetalles;
            return factura;
        }
        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(PilaForms.pila.Pop());
        }

        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            Session["agregarDetalle"] = true;
            PilaForms.AgregarForm("RegistrarVentaVentanilla_128.aspx");
            Response.Redirect("ConsultarLibroApunte.aspx");
        }

        protected void btn_consultarApunte_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["idApunte"] = OrdenImpresionDao.DevolverIdApunte((int)dgv_grillaDetalleFactura.SelectedDataKey.Value);
            PilaForms.AgregarForm("RegistrarVentaVentanilla_128.aspx");
            Response.Redirect("ConsultarLibroApunte.aspx");
        }

        protected void btn_eliminarDetalle_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            (Session["tablaDetalles"] as DataTable).Rows[e.RowIndex].Delete();
            CargarGrillaDetalles();
        }
    }
}