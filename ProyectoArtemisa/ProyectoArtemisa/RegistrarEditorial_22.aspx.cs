using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseDeDatos;
using Entidades;
using Negocio;

namespace ProyectoArtemisa
{
    public partial class RegistrarEditorial_22 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((PilaForms.pila.Peek().Equals("ConsultarEditorial_25.aspx")) || ((bool)Session["modificarEditorial"]))
                {
                    CargarUnObjetoEnElForm(EditorialDao.ConsultarUnaEditorial(int.Parse(Session["idEditorial"].ToString())));
                }
                else
                {
                   
                }

            }
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            if ((PilaForms.pila.Peek().Equals("ConsultarEditorial_25.aspx")) || ((bool)Session["modificarEditorial"]))
            {
                EditorialEntidad editorial = CrearUnObjetoDesdeElForm();
                editorial.idEditorial = int.Parse(Session["idEditorial"].ToString());
                EditorialDao.ModificarEditorial(editorial);
                Session["idEditorial"] = null;
                Session["modificarEditorial"] = false;
                Response.Redirect(PilaForms.DevolverForm());
            }
            else
            {
                EditorialDao.RegistrarEditorial(CrearUnObjetoDesdeElForm());
                Response.Redirect(PilaForms.DevolverForm());
            }

        }
        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Session["modificarEditorial"] = false;
            Response.Redirect(PilaForms.DevolverForm());
        }

        protected void CargarUnObjetoEnElForm(EditorialEntidad editorial)
        {
            txt_nombreEditorial.Text = editorial.nombreEditorial;
        }

        protected EditorialEntidad CrearUnObjetoDesdeElForm()
        {
            EditorialEntidad editorial = new EditorialEntidad();
            editorial.nombreEditorial = txt_nombreEditorial.Text;
            return editorial;
        }
        protected void LimpiarForm()
        {
            txt_nombreEditorial.Text = ""; 
        }
       
    }
}