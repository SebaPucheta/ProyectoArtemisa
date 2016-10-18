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
                    lbl_fecha.Text = Session["fecha"].ToString();
                    CargarGrillaDetalles();
                    CargarNuevoDetalle();
                    BorrarVariablesGlobales();
                }
                else
                {
                    lbl_fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    InicializarVariableSessionTabla();
                }
            }
            lbl_total.Text = CalcularTotal().ToString();
        }

        //Cargar la Grilla que tiene un nuevo detalle
        protected void CargarNuevoDetalle()
        {
            if (Session["objetoApunteEntidad"].ToString() != "" || Session["objetoLibroEntidad"].ToString() != "")
            {
                dgv_nuevoDetalle.Visible = true;
                DataTable tabla = new DataTable();
                DataRow fila;


                //Creo las columnas de la tabla
                tabla.Columns.Add("idItem", typeof(int));
                tabla.Columns.Add("nombreApunte", typeof(string));
                tabla.Columns.Add("tipoApunte", typeof(string));

                fila = tabla.NewRow();
                if (Session["objetoApunteEntidad"].ToString() != "")
                {
                    fila[0] = (Session["objetoApunteEntidad"] as ApunteEntidad).idApunte;
                    fila[1] = (Session["objetoApunteEntidad"] as ApunteEntidad).nombreApunte;
                    fila[2] = "Apunte";
                }
                else
                {
                    fila[0] = (Session["objetoLibroEntidad"] as LibroEntidad).idLibro;
                    fila[1] = (Session["objetoLibroEntidad"] as LibroEntidad).nombreLibro;
                    fila[2] = "Libro";
                }
                tabla.Rows.Add(fila);
                DataView dataView = new DataView(tabla);

                dgv_nuevoDetalle.DataKeyNames = new string[] { "idItem" };
                dgv_nuevoDetalle.DataSource = dataView;
                dgv_nuevoDetalle.DataBind();

                if (Session["objetoApunteEntidad"].ToString() != "")
                {
                    ((TextBox)dgv_nuevoDetalle.Rows[0].Cells[2].FindControl("txt_precioUnitario")).Text = (Session["objetoApunteEntidad"] as ApunteEntidad).precioApunte.ToString();
                }
                else
                {
                    ((TextBox)dgv_nuevoDetalle.Rows[0].Cells[2].FindControl("txt_precioUnitario")).Text = (Session["objetoLibroEntidad"] as LibroEntidad).precioLibro.ToString();
                }
            }
        }

        //Inicializa la variable de session que contiene la tabla con los detalles de factura
        protected void InicializarVariableSessionTabla()
        {
            DataTable tabla = new DataTable();

            //Creo las columnas de la tabla
            tabla.Columns.Add("idItem", typeof(int));
            tabla.Columns.Add("nombre", typeof(string));
            tabla.Columns.Add("tipoApunte", typeof(string));
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

            fila[0] = dgv_nuevoDetalle.DataKeys[0].Value;
            fila[1] = Page.Server.HtmlDecode(dgv_nuevoDetalle.Rows[0].Cells[0].Text);
            fila[2] = Page.Server.HtmlDecode(dgv_nuevoDetalle.Rows[0].Cells[1].Text);
            fila[3] = float.Parse(((TextBox)dgv_nuevoDetalle.Rows[0].Cells[2].FindControl("txt_precioUnitario")).Text);
            fila[4] = Convert.ToInt32(((TextBox)dgv_nuevoDetalle.Rows[0].Cells[3].FindControl("txt_cantidad")).Text);
            fila[5] = float.Parse(fila[3].ToString()) * float.Parse(fila[4].ToString());

            (Session["tablaDetalles"] as DataTable).Rows.Add(fila);

            CargarGrillaDetalles();
        }

        //Carga la grilla detalles con los detalles que contiene la variable session
        protected void CargarGrillaDetalles()
        {
            DataView dataView = new DataView(Session["tablaDetalles"] as DataTable);

            dgv_grillaDetalleFactura.DataKeyNames = new string[] { "idItem" };
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
            Session["objetoApunteEntidad"] = "";
            Session["objetoLibroEntidad"] = "";
        }

        protected double CalcularTotal()
        {
            double total=0;
            foreach(DataRow fila in (Session["tablaDetalles"] as DataTable).Rows )
            {
                total += Convert.ToDouble(fila[5]);
            }
            return total;
        }
        protected void btn_confirmar_Click(object sender, EventArgs e)
        {
            if(int.Parse(lbl_total.Text) == 0)
            {
                Response.Write("<script>window.alert('No a ingresado ningun articulo');</script>");
            }
            else
            {
                FacturaDao.RegistrarFactura(CrearFactura());
                InicializarVariableSessionTabla();
                dgv_grillaDetalleFactura.Visible = false;
                lbl_total.Text = "";
            }
            
            
        }

        protected void btn_agregarDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                 
            if(ValidarStock())
            {
                CargarNuevoDetalleGrillaDetalle();
                dgv_nuevoDetalle.Visible = false;
                lbl_total.Text = CalcularTotal().ToString();
                lbl_info.Text = "";
            }
            else
            {
                lbl_info.Text="La cantidad ingresada es mayor a la cantidad de stock. Stock:" + ConsultarStockItem();
            }
            
        }

        protected bool ValidarStock()
        {
            int cantidad = Convert.ToInt32(((TextBox)dgv_nuevoDetalle.Rows[0].Cells[3].FindControl("txt_cantidad")).Text);

            return ConsultarStockItem() >= cantidad;
        }
        protected int ConsultarStockItem()
        {
            int stock = 0;
            if (Page.Server.HtmlDecode(dgv_nuevoDetalle.Rows[0].Cells[1].Text).Equals("Apunte"))
            {
                stock = (ApunteDao.ConsultarApunte((int)(dgv_nuevoDetalle.DataKeys[0].Value))).stock;
            }
            else
            {
                stock = (LibroDao.ConsultarLibro((int)(dgv_nuevoDetalle.DataKeys[0].Value))).stock;
            }
            return stock;
        }
        protected void btn_limpiarGrilla_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            dgv_nuevoDetalle.Visible = false;
        }

        protected FacturaEntidad CrearFactura()
        {
            FacturaEntidad factura = new FacturaEntidad();
            List<DetalleFacturaEntidad> listaDetalles = new List<DetalleFacturaEntidad>(); 
            factura.fecha = Convert.ToDateTime(lbl_fecha.Text);
            factura.total = float.Parse(lbl_total.Text);
            foreach (DataRow fila in (Session["tablaDetalles"] as DataTable).Rows)
            {
                DetalleFacturaEntidad detalleFactura = new DetalleFacturaEntidad();

                if(fila[2].ToString().Equals("Apunte"))
                { detalleFactura.item = ApunteDao.ConsultarApunte(Convert.ToInt32(fila[0])); }
                else
                { detalleFactura.item = LibroDao.ConsultarLibro(Convert.ToInt32(fila[0])); }
                detalleFactura.cantidad = Convert.ToInt32(fila[4]);
                detalleFactura.subtotal = float.Parse(fila[5].ToString());
                
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
            lbl_info.Text = "";
            Session["fecha"] = lbl_fecha.Text;
            Session["agregarDetalle"] = true;
            PilaForms.AgregarForm("RegistrarVentaVentanilla_128.aspx");
            Response.Redirect("ConsultarLibroApunte.aspx");
        }

        protected void btn_consultarApunte_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["fecha"] = lbl_fecha.Text;
            
            int idApunte = (int)dgv_grillaDetalleFactura.SelectedDataKey.Value;
            int indice = (int)dgv_grillaDetalleFactura.SelectedIndex;
            string idTipoApunte =dgv_grillaDetalleFactura.Rows[indice].Cells[1].Text;
            Session["idItem"] = (int)dgv_grillaDetalleFactura.SelectedDataKey.Value;
            Session["idTipo"] = idTipoApunte;
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