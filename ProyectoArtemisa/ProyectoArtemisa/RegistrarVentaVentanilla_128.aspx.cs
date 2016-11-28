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
            lbl_usuario.Text = Session["nombreApellidoUsuario"].ToString();
            btn_codigoBarra.Focus();
            if(dgv_grillaDetalleFactura.Rows.Count > 0)
            {
                lbl_nombreGrilla.Visible = true;
            }
            else
            {
                lbl_nombreGrilla.Visible = false;
            }
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
            tabla.Columns.Add("precioUnitario", typeof(string));
            tabla.Columns.Add("cantidad", typeof(string));
            tabla.Columns.Add("subtotal", typeof(string));
            
            Session["tablaDetalles"] = tabla;
        }

        //Pasa un detalle de la grilla de nuevos detalles a la grilla de detalles
        protected void CargarNuevoDetalleGrillaDetalle()
        {
            DataRow fila;

            fila = (Session["tablaDetalles"] as DataTable).NewRow();
            int cantidad=int.Parse(((TextBox)dgv_nuevoDetalle.Rows[0].Cells[3].FindControl("txt_cantidad")).Text);
            float precio = float.Parse(((TextBox)dgv_nuevoDetalle.Rows[0].Cells[2].FindControl("txt_precioUnitario")).Text);
            fila[0] = dgv_nuevoDetalle.DataKeys[0].Value;
            fila[1] = Page.Server.HtmlDecode(dgv_nuevoDetalle.Rows[0].Cells[0].Text);
            fila[2] = Page.Server.HtmlDecode(dgv_nuevoDetalle.Rows[0].Cells[1].Text);
            fila[3] = "$" + precio.ToString("N2");
            fila[4] = cantidad.ToString() + " Unidades";
            float subtotal = precio * cantidad;
            fila[5] = "$" + (subtotal).ToString("N2") ;

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
            lbl_total.Text = CalcularTotal().ToString("N2");
            lbl_nombreGrilla.Visible = true;
            
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
                total += Convert.ToDouble(fila[5].ToString().Substring(1));
            }
            
            return total;
        }
        protected void btn_confirmar_Click(object sender, EventArgs e)
        {
            if(float.Parse(lbl_total.Text) <=0)
            {
                Response.Write("<script>window.alert('No a ingresado ningun articulo');</script>");
            }
            else
            {
                int idFactura = FacturaDao.RegistrarFactura(CrearFactura());
                InicializarVariableSessionTabla();
                CargarGrillaDetalles();
                dgv_grillaDetalleFactura.Visible = true;
                lbl_total.Text = "";

                string url = "GenerarComprobanteDeVenta_149.aspx?id=" + idFactura;
                Response.Redirect(url);
                //Response.Write("<script>window.open('" + url +"','Popup','width=1000,height=700')</script>");
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
            factura.idUsuarioEmpleado = int.Parse(Session["idUsuario"].ToString());
            factura.idTipoPago = 1;
            factura.idEstadoPago = 1;
            foreach (DataRow fila in (Session["tablaDetalles"] as DataTable).Rows)
            {
                DetalleFacturaEntidad detalleFactura = new DetalleFacturaEntidad();

                if(fila[2].ToString().Equals("Apunte"))
                { detalleFactura.item = ApunteDao.ConsultarApunte(Convert.ToInt32(fila[0])); }
                else
                { detalleFactura.item = LibroDao.ConsultarLibro(Convert.ToInt32(fila[0])); }
                string cantidad=fila[4].ToString().Replace('n', ' ').Replace('U', ' ').Replace('i', ' ').Replace('d', ' ').Replace('a', ' ').Replace('e', ' ').Replace('s', ' ');
                detalleFactura.cantidad = Convert.ToInt32(cantidad.Trim());
                detalleFactura.subtotal = float.Parse(fila[5].ToString().Substring(1));
                
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
         protected void btn_codigoBarra_TextChanged(object sender, EventArgs e)
        {
            DataTable tabla = FacturaDao.DevolverItemPorCodigoBarra(btn_codigoBarra.Text);
             if(tabla.Rows.Count > 0)
             {
                 CargarNuevoDetalleGrillaDetalleDesdeDataTable(tabla);
             }
             else
             {
                 Response.Write("<script>window.alert('Código de barra inexistente');</script>");
             }
             btn_codigoBarra.Text = "";
        }

         protected void CargarNuevoDetalleDesdeDataTable(DataTable tablaItem)
         {
             dgv_nuevoDetalle.Visible = true;
             DataTable tabla = new DataTable();
             DataRow fila;


             //Creo las columnas de la tabla
             tabla.Columns.Add("idItem", typeof(int));
             tabla.Columns.Add("nombreApunte", typeof(string));
             tabla.Columns.Add("tipoApunte", typeof(string));

             fila = tabla.NewRow();
             DataRow filaItem = tablaItem.Rows[0];
             fila[0] = int.Parse( filaItem["idItem"].ToString() );
             fila[1] = filaItem["nombre"].ToString();
             fila[2] = filaItem["tipoItem"].ToString();

             tabla.Rows.Add(fila);
             DataView dataView = new DataView(tabla);

             dgv_nuevoDetalle.DataKeyNames = new string[] { "idItem" };
             dgv_nuevoDetalle.DataSource = dataView;
             dgv_nuevoDetalle.DataBind();

             ((TextBox)dgv_nuevoDetalle.Rows[0].Cells[2].FindControl("txt_precioUnitario")).Text = filaItem["precio"].ToString();
           
         }

         protected void CargarNuevoDetalleGrillaDetalleDesdeDataTable(DataTable tablaItem)
         {
             DataRow fila;
             DataRow filaItem = tablaItem.Rows[0];

             fila = (Session["tablaDetalles"] as DataTable).NewRow();
             int cantidad = 1;
             float precio = float.Parse(filaItem["precio"].ToString());
             fila[0] = int.Parse(filaItem["idItem"].ToString());
             fila[1] = filaItem["nombre"].ToString();
             fila[2] = filaItem["tipoItem"].ToString();
             fila[3] = "$" + precio.ToString();
             fila[4] = cantidad.ToString() + " Unidades";
             float subtotal = precio * cantidad;
             fila[5] = "$" + (subtotal).ToString();

             (Session["tablaDetalles"] as DataTable).Rows.Add(fila);

             CargarGrillaDetalles();
         }

         protected void dgv_grillaDetalleFactura_RowCommand(Object sender, GridViewCommandEventArgs e)
         {
             int indice = ((GridViewRow)(e.CommandSource as LinkButton).Parent.Parent).RowIndex;

             if (e.CommandName == "modificar")
             {
                 ModificarDetalle(indice);
                 (Session["tablaDetalles"] as DataTable).Rows[indice].Delete();
                 CargarGrillaDetalles();
             }
         }

         protected void ModificarDetalle(int Indice)
         {
             dgv_nuevoDetalle.Visible = true;
             DataTable tabla = new DataTable();
             DataRow fila;


             //Creo las columnas de la tabla
             tabla.Columns.Add("idItem", typeof(int));
             tabla.Columns.Add("nombreApunte", typeof(string));
             tabla.Columns.Add("tipoApunte", typeof(string));

             fila = tabla.NewRow();
             
             fila[0] = int.Parse(dgv_grillaDetalleFactura.DataKeys[Indice].Value.ToString());
             fila[1] = Page.Server.HtmlDecode(dgv_grillaDetalleFactura.Rows[Indice].Cells[0].Text);
             fila[2] = Page.Server.HtmlDecode(dgv_grillaDetalleFactura.Rows[Indice].Cells[1].Text);

             tabla.Rows.Add(fila);
             DataView dataView = new DataView(tabla);

             dgv_nuevoDetalle.DataKeyNames = new string[] { "idItem" };
             dgv_nuevoDetalle.DataSource = dataView;
             dgv_nuevoDetalle.DataBind();

             ((TextBox)dgv_nuevoDetalle.Rows[0].Cells[2].FindControl("txt_precioUnitario")).Text = (dgv_grillaDetalleFactura.Rows[Indice].Cells[2].Text.Substring(1));
             ((TextBox)dgv_nuevoDetalle.Rows[0].Cells[3].FindControl("txt_cantidad")).Text = (dgv_grillaDetalleFactura.Rows[Indice].Cells[3].Text.Replace('n', ' ').Replace('U', ' ').Replace('i', ' ').Replace('d', ' ').Replace('a', ' ').Replace('e', ' ').Replace('s', ' '));
         }
    }
}