using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entidades;
using BaseDeDatos;
using Negocio;
namespace ProyectoArtemisa
{
    public partial class IngresoLibro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CargarComboProveedor();
                lbl_usuario.Text = Session["nombreApellidoUsuario"].ToString();
                if (bool.Parse(Session["agregarDetalle"].ToString()))
                {
                    lbl_fecha.Text = Session["fecha"].ToString();
                    ddl_proveedores.SelectedValue= Session["proveedor"].ToString();
                    
                    CargarGrillaDetalles();
                    if (Session["objetoLibroEntidad"].ToString() != "")
                    {
                        CargarNuevoDetalle(Session["objetoLibroEntidad"] as LibroEntidad);
                    }
                    BorrarVariablesGlobales();
                }
                else
                {
                    lbl_fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    InicializarVariableSessionTabla();
                }
            }
            btn_codigoBarra.Focus();
        }

        protected void CargarComboProveedor()
        {
            ddl_proveedores.DataSource = ProveedorDao.ConsultarProveedores();
            ddl_proveedores.DataTextField = "nombreProveedor";
            ddl_proveedores.DataValueField = "idProveedor";
            ddl_proveedores.DataBind();
       }

        //Cargar la Grilla que tiene un nuevo detalle
        protected void CargarNuevoDetalle(LibroEntidad libro)
        {
            
                dgv_nuevoIngresoStockDetalle.Visible = true;
                DataTable tabla = new DataTable();
                DataRow fila;


                //Creo las columnas de la tabla
                tabla.Columns.Add("idLibro", typeof(int));
                tabla.Columns.Add("nombreLibro", typeof(string));
                

                fila = tabla.NewRow();
                
                fila[0] = libro.idLibro;
                fila[1] = libro.nombreLibro;
                
                tabla.Rows.Add(fila);
                DataView dataView = new DataView(tabla);

                dgv_nuevoIngresoStockDetalle.DataKeyNames = new string[] { "idLibro" };
                dgv_nuevoIngresoStockDetalle.DataSource = dataView;
                dgv_nuevoIngresoStockDetalle.DataBind();

                ((TextBox)dgv_nuevoIngresoStockDetalle.Rows[0].Cells[2].FindControl("txt_precioUnitario")).Text = libro.precioLibro.ToString();
            }

        protected void dgv_grilla_OnPageIndexChanging(Object sender, GridViewPageEventArgs e)
        {
            dgv_grillaIngresoStockDetalle.PageIndex = e.NewPageIndex;
            CargarGrillaDetalles();
        }
        //Inicializa la variable de session que contiene la tabla con los detalles de factura
        protected void InicializarVariableSessionTabla()
        {
            DataTable tabla = new DataTable();

            //Creo las columnas de la tabla
            tabla.Columns.Add("idLibro", typeof(int));
            tabla.Columns.Add("nombreLibro", typeof(string));
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
            int cantidad=int.Parse(((TextBox)dgv_nuevoIngresoStockDetalle.Rows[0].Cells[3].FindControl("txt_cantidad")).Text);
            float precio = float.Parse(((TextBox)dgv_nuevoIngresoStockDetalle.Rows[0].Cells[2].FindControl("txt_precioUnitario")).Text);
            fila[0] = dgv_nuevoIngresoStockDetalle.DataKeys[0].Value;
            fila[1] = Page.Server.HtmlDecode(dgv_nuevoIngresoStockDetalle.Rows[0].Cells[0].Text);
            fila[2] = "$" + precio.ToString();
            fila[3] = cantidad.ToString() + " Unidades";
            float subtotal = precio * cantidad;
            fila[4] = "$" + (subtotal).ToString() ;

            (Session["tablaDetalles"] as DataTable).Rows.Add(fila);

            CargarGrillaDetalles();
        }

        //Carga la grilla detalles con los detalles que contiene la variable session
        protected void CargarGrillaDetalles()
        {
            DataView dataView = new DataView(Session["tablaDetalles"] as DataTable);

            dgv_grillaIngresoStockDetalle.DataKeyNames = new string[] { "idLibro" };
            dgv_grillaIngresoStockDetalle.DataSource = dataView;
            dgv_grillaIngresoStockDetalle.DataBind();
            lbl_total.Text = CalcularTotal().ToString();
        }

        //Inicializa las variable globales
        protected void  BorrarVariablesGlobales()
        {
            Session["nombreLibro"] = "";
            Session["idItem"] = null;
            Session["precioUnitario"] = null;
            Session["agregarDetalle"] = false;
            Session["objetoApunteEntidad"] = "";
            Session["objetoLibroEntidad"] = "";
            Session["objetoLibroEntidad"] = "";
            Session["proveedor"] = "";
        }

        protected double CalcularTotal()
        {
            double total=0;
            foreach(DataRow fila in (Session["tablaDetalles"] as DataTable).Rows )
            {
                total += Convert.ToDouble(fila[4].ToString().Substring(1));
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
                LibroDao.RegistrarIngresoLibro(CrearIngresoStock());
                InicializarVariableSessionTabla();
                dgv_grillaIngresoStockDetalle.Visible = false;
                lbl_total.Text = "";
            }
        }

        protected void btn_agregarDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarNuevoDetalleGrillaDetalle();
            dgv_nuevoIngresoStockDetalle.Visible = false;
            lbl_total.Text = CalcularTotal().ToString();
            lbl_info.Text = "";
        }

        protected bool ValidarStock()
        {
            int cantidad = Convert.ToInt32(((TextBox)dgv_nuevoIngresoStockDetalle.Rows[0].Cells[3].FindControl("txt_cantidad")).Text);

            return ConsultarStockItem() >= cantidad;
        }
        protected int ConsultarStockItem()
        {
            int stock = (LibroDao.ConsultarLibro((int)(dgv_nuevoIngresoStockDetalle.DataKeys[0].Value))).stock;
            return stock;
        }
        protected void btn_limpiarGrilla_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            dgv_nuevoIngresoStockDetalle.Visible = false;
        }

        //Modificar
        protected IngresoLibroEntidad CrearIngresoStock()
        {
            IngresoLibroEntidad ingresoLibro = new IngresoLibroEntidad();
            List<DetalleIngresoLibroEntidad> listaDetalles = new List<DetalleIngresoLibroEntidad>(); 
            ingresoLibro.fecha = Convert.ToDateTime(lbl_fecha.Text);
            ingresoLibro.total = float.Parse(lbl_total.Text);
            ingresoLibro.idUsuario = int.Parse(Session["idUsuario"].ToString());
            ingresoLibro.idProveedor = Convert.ToInt32( ddl_proveedores.SelectedValue);
            foreach (DataRow fila in (Session["tablaDetalles"] as DataTable).Rows)
            {
                DetalleIngresoLibroEntidad detalleIngreso = new DetalleIngresoLibroEntidad();

                detalleIngreso.idLibro = Convert.ToInt32(fila[0]); 
                string cantidad=fila[3].ToString().Replace('n', ' ').Replace('U', ' ').Replace('i', ' ').Replace('d', ' ').Replace('a', ' ').Replace('e', ' ').Replace('s', ' ');
                detalleIngreso.cantidad = Convert.ToInt32(cantidad.Trim());
                detalleIngreso.precioUnitario = float.Parse(fila[2].ToString().Substring(1));
                
                listaDetalles.Add(detalleIngreso);
            }

            ingresoLibro.listaDetalleIngresoLibro = listaDetalles;
            return ingresoLibro;
        }
        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(PilaForms.pila.Pop());
        }

        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            lbl_info.Text = "";
            Session["fecha"] = lbl_fecha.Text;
            Session["proveedor"] = ddl_proveedores.SelectedValue;
            Session["agregarDetalle"] = true;
            PilaForms.AgregarForm("IngresoLibro.aspx");
            Response.Redirect("ConsultarLibroApunte.aspx");
        }

        protected void btn_consultarApunte_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["fecha"] = lbl_fecha.Text;
            Session["proveedor"] = ddl_proveedores.SelectedValue;
            
            int idApunte = (int)dgv_grillaIngresoStockDetalle.SelectedDataKey.Value;
            int indice = (int)dgv_grillaIngresoStockDetalle.SelectedIndex;
            Session["idItem"] = (int)dgv_grillaIngresoStockDetalle.SelectedDataKey.Value;
            Session["idTipo"] = "Libro";
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
            List<LibroEntidadQuery> libro = LibroDao.ConsultarLibroXCodigoBarra(btn_codigoBarra.Text);
             if(libro.Count > 0)
             {
                CargarNuevoDetalle(libro[0]);
             }
             else
             {
                 Response.Write("<script>window.alert('Código de barra inexistente o no pertenece a un libro');</script>");
             }
             btn_codigoBarra.Text = "";
        }
    }
    
}