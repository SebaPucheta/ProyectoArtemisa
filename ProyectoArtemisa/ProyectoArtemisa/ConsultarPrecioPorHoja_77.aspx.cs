using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using BaseDeDatos;
using Negocio;
using System.Data;
namespace ProyectoArtemisa
{
    public partial class ConsultarPrecioPorHoja_77 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        protected void CargarGrilla()
        {
            DataTable tabla = new DataTable();
            DataRow fila;

            //Creo las columnas de la tabla
            tabla.Columns.Add("precioHoja", typeof(string));
            tabla.Columns.Add("fecha", typeof(string));
            
            foreach ( PrecioXHojaEntidad pxh in PrecioXHojaDao.ConsultarPrecioXHoja() )
            {
                fila = tabla.NewRow();

                fila[0] =  "$" + pxh.precioHoja.ToString("N2") ;
                fila[1] =  pxh.fecha.ToShortDateString() ;
                tabla.Rows.Add(fila);
            }
                
            DataView dataView = new DataView(tabla);

            dgv_grillaPrecio.DataSource = dataView;
            dgv_grillaPrecio.DataBind();
        }
    }
}