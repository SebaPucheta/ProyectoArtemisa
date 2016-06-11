using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using BaseDeDatos;

namespace ProyectoArtemisa
{
    public partial class RegistrarPrecioXHoja_74 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txt_fecha.Text = DateTime.Today.ToShortDateString();
            }
            else
            {
                txt_fecha.Text = DateTime.Today.ToShortDateString();
            }
        }

        protected void limpiarForm()
        {
            txt_fecha.Text = DateTime.Today.ToShortDateString();
            txt_precio.Text = string.Empty;
        }

        protected void btn_registrar_Click(object sender, EventArgs e)
        {
            try
            {
                PrecioXHojaEntidad pxh = new PrecioXHojaEntidad();
                pxh.precio = float.Parse(txt_precio.Text);
                pxh.fecha = DateTime.Parse(txt_fecha.Text);
                PrecioXHojaDao.RegistrarPrecioXHoja(pxh);
                limpiarForm();
                //Cosito de confirmar
            }
            catch
            {
                //Cosito para el mensaje
            }


        }

        protected void btn_salir_Click(object sender, EventArgs e)
        {
            //Volver al menu anterior
        }
    }
}