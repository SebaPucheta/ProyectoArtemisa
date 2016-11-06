using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
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
            lbl_fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            if(!IsPostBack)
            {
                if(bool.Parse(Session["agregarOrden"].ToString()))
                {
                    CargarApunteGrillaOrdenNueva((Session["objetoApunteEntidad"] as ApunteEntidad));
                    CargarOrdenesEnGrilla();
                    BorrarVariablesGlobales();
                }
                else
                {
                    CargarOrdenesEnGrilla();
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
        protected void RegistrarNuevaOrden(int idApunte, int cantidadImprimir)
        {
            OrdenImpresionEntidadQuery nuevaOrden = new OrdenImpresionEntidadQuery();
            //nuevaOrden.idApunte = int.Parse(Session["idApunte"].ToString());
            nuevaOrden.idApunte = idApunte;
            nuevaOrden.cantidad = cantidadImprimir;
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
        protected void CargarOrdenesEnGrilla()
        {
            DataTable tabla = new DataTable();
            DataRow fila;

            //Creo las columnas de la tabla
            tabla.Columns.Add("idOrden", typeof(int));
            tabla.Columns.Add("fecha", typeof(DateTime));
            tabla.Columns.Add("nombre", typeof(string));
            tabla.Columns.Add("cantidad", typeof(string));
            tabla.Columns.Add("chk_impreso", typeof(bool));

            foreach (OrdenImpresionEntidadQuery orden in OrdenImpresionDao.ListarOrdenApuntePendientes())
            {
                fila = tabla.NewRow();

                fila[0] = orden.idOrdenImpresion;
                fila[1] = orden.fecha;
                fila[2] = orden.nombreApunte;
                fila[3] = orden.cantidad + " Unidades";
                
                //No toma los valores true o false el checkbox
                if (orden.nombreEstadoOrdenImpresion.Equals("Impreso"))
                {
                    fila[4] = true;
                }
                else
                {
                    fila[4] = false;
                }
                
                tabla.Rows.Add(fila);
            }

            DataView dataView = new DataView(tabla);
            
            dgv_grillaOrdenesImpresion.DataKeyNames = new string[] { "idOrden" };
            dgv_grillaOrdenesImpresion.DataSource = dataView;
            dgv_grillaOrdenesImpresion.DataBind();
        }
       
        //Carga el apunte que trajo del otro form en la grilla dgv_ordenNueva, en donde se setea la cantidad y luego se al acer click en registrar se crea
        //la una nueva orden de impresion y pasa a la otra grilla
       
        protected void CargarApunteGrillaOrdenNueva(ApunteEntidad apunte)
        {
            dgv_ordenNueva.Visible = true;
            DataTable tabla = new DataTable();
            DataRow fila;

            //Creo las columnas de la tabla
            tabla.Columns.Add("idApunte", typeof(int));
            tabla.Columns.Add("nombreApunte", typeof(string));

            fila = tabla.NewRow();
            
            fila[0] = apunte.idApunte;
            fila[1] = apunte.nombreApunte;
            tabla.Rows.Add(fila);
            DataView dataView = new DataView(tabla);

            dgv_ordenNueva.DataKeyNames = new string[] { "idApunte" };
            dgv_ordenNueva.DataSource = dataView;
            dgv_ordenNueva.DataBind();
        }
        
        protected void btn_eliminarOrden_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            OrdenImpresionDao.EliminarOrdenImpresion((int)dgv_grillaOrdenesImpresion.DataKeys[e.RowIndex].Value);
            CargarOrdenesEnGrilla();
        }

        protected void btn_consultarApunte_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["idApunte"] = OrdenImpresionDao.DevolverIdApunte((int)dgv_grillaOrdenesImpresion.SelectedDataKey.Value);
            PilaForms.AgregarForm("ConsultarOrdenImpresion_126.aspx");
            Response.Redirect("ConsultarLibroApunte.aspx");
        }

        protected void ApunteImpreso(int idOrdenImpresion)
        {
            if (OrdenImpresionDao.DevolverEstadoOrdenImpresion(idOrdenImpresion) == 1)
            { OrdenImpresionDao.CambiarEstadoImpreso(idOrdenImpresion); }
            else
            { OrdenImpresionDao.CambiarEstadoPendiente(idOrdenImpresion); }
            
        }

        protected void ApunteEnLocal(int idOrdenImpresion)
        {
           OrdenImpresionDao.CambiarEstadoEnLocal(idOrdenImpresion); 
        }

        protected void ModificarStockApunte(int idOrdenImpresion, int cantidadImpresa)
        {
            ApunteDao.AgregarStockApunte(OrdenImpresionDao.DevolverIdApunte(idOrdenImpresion), cantidadImpresa);
        }

        protected void dgv_grillaApunte_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int indice = ((GridViewRow)(e.CommandSource as LinkButton).Parent.Parent).RowIndex;
            int idOrdenImpresion = (int)dgv_grillaOrdenesImpresion.DataKeys[indice].Value;
            int cantidadImpresa = Convert.ToInt32(dgv_grillaOrdenesImpresion.Rows[indice].Cells[1].Text);
            if (e.CommandName == "impreso")
            { ApunteImpreso(idOrdenImpresion); }
            if(e.CommandName == "enLocal")
            { 
                if (MessageBox.Show("¿Estas seguro?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ApunteEnLocal(idOrdenImpresion);
                    ModificarStockApunte(idOrdenImpresion, cantidadImpresa);
                }
            }
            CargarOrdenesEnGrilla();
        }

        protected void btn_limpiarGrilla_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            dgv_ordenNueva.Visible = false;
        }

        protected void btn_registrarOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
             RegistrarNuevaOrden((int)dgv_ordenNueva.SelectedDataKey.Value, Convert.ToInt32(((System.Web.UI.WebControls.TextBox)(dgv_ordenNueva.SelectedRow.Cells[1].FindControl("txt_cantidadImprimir"))).Text));
             dgv_ordenNueva.Visible = false;
             CargarOrdenesEnGrilla();
       }

        protected void btn_codigoBarra_TextChanged(object sender, EventArgs e)
        {
            List<ApunteEntidadQuery> apunte = ApunteDao.ConsultarApunteXCodigoBarra(btn_codigoBarra.Text);
            if (apunte.Count > 0)
            {
                CargarApunteGrillaOrdenNueva(apunte[0]);
            }
            else
            {
                Response.Write("<script>window.alert('Código de barra inexistente o no pertenece a un apunte');</script>");
            }
            btn_codigoBarra.Text = "";


        }
     }
}