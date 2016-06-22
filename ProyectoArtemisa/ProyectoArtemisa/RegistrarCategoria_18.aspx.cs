﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using BaseDeDatos;
using Negocio;

namespace ProyectoArtemisa
{
    public partial class RegistrarCategoria_18 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            CategoriaEntidad categoria = new CategoriaEntidad();
            categoria.nombreCategoria = txt_nombreCategoria.Text;
            CategoriaDao.RegistrarCategoria(categoria);
            if (PilaForms.pila.Peek().Equals("Default.aspx"))
            {
                LimpiarForm();
            }
            else
            {
                Response.Redirect(PilaForms.DevolverForm());
            }
        }
        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(PilaForms.DevolverForm());
        }
        

        protected void LimpiarForm()
        {
            txt_nombreCategoria.Text = ""; 
        }

    }
}