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
                txt_fechaHasta.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        protected void cargarGrillaFactura(List<IngresoLibroEntidad> listaIngresoLibro)
        {
            DataTable tabla = new DataTable();
            DataRow fila;

            //Creo las columnas de la tabla
            tabla.Columns.Add("idIngresoLibro", typeof(int));
            tabla.Columns.Add("fecha", typeof(string));//key name
            tabla.Columns.Add("proveedor", typeof(string));
            tabla.Columns.Add("usuario", typeof(string));
            tabla.Columns.Add("total", typeof(string));

            foreach (IngresoLibroEntidad ingresoLibro in listaIngresoLibro)
            {
                fila = tabla.NewRow();

                fila[0] = ingresoLibro.idIngresoLibro;
                fila[1] = ingresoLibro.fecha;
                fila[2] = ingresoLibro.idProveedor;
                fila[3] = ingresoLibro.total;
                tabla.Rows.Add(fila);
            }

            DataView dataView = new DataView(tabla);

            dgv_grillaIngresoLibros.DataSource = dataView;
            dgv_grillaIngresoLibros.DataKeyNames = new string[] { "idIngresoLibro" };
            dgv_grillaIngresoLibros.DataBind();
        }
    }
}