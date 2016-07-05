using System;
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
    public partial class RegistrarUniversidad_69 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["modificarUniversidad"])
            {
                txt_nombre.Text = UniversidadDao.ConsultarUnaUniversidad(int.Parse(Session["idUniversidad"].ToString())).nombreUniversidad;
            }
        }


        protected void limpiarForm()
        {
            txt_nombre.Text = string.Empty;
        }

        protected void btn_registrar_Click(object sender, EventArgs e)
        {
            
                UniversidadEntidad uni = new UniversidadEntidad();
                uni.nombreUniversidad = txt_nombre.Text;
                
                if ((bool)Session["modificarUniversidad"])
                {
                    uni.idUniversidad = int.Parse(Session["idUniversidad"].ToString());
                    UniversidadDao.ModificarUniversidad(uni);
                    Session["modificarUniversidad"] = false;
                }
                else
                {
                    UniversidadDao.RegistrarUniversidad(uni);
                }
                Response.Redirect(PilaForms.DevolverForm());
               // UniversidadDao.RegistrarUniversidad(uni);
                
                //Confiracion
            
            

        }

        protected void btn_salir_Click(object sender, EventArgs e)
        {
            Session["modificarUniversidad"] = false;
            Response.Redirect(PilaForms.DevolverForm());
            //Volver al form anterior
        }
    }
}