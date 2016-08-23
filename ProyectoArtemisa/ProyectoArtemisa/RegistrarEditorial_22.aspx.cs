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
                if (Session["idEditorial"] != null)
                {
                    //Vengo del boton modificar
                    CargarUnObjetoEnElForm(EditorialDao.ConsultarUnaEditorial(int.Parse(Session["idEditorial"].ToString())));
                }
                else
                {
                    //Vengo sin el modificar

                }

                //Cargar editoriales desde un inicio
                CargarEditorialEnGrilla();


            }
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {

            //No existe el nombre
            if (Session["idEditorial"] != null)
            {
                //Modificacion
                EditorialEntidad editorial = CrearUnObjetoDesdeElForm();
                editorial.idEditorial = int.Parse(Session["idEditorial"].ToString());
                EditorialDao.ModificarEditorial(editorial);
            }
            else
            {
                //Nuevo
                EditorialDao.RegistrarEditorial(CrearUnObjetoDesdeElForm());
            }
            Session["idEditorial"] = null;
            LimpiarForm();

        }
        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Session["idEditorial"] = null;
            LimpiarForm();
            CargarEditorialEnGrilla();
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
            CargarEditorialEnGrilla();
        }

        //Cargar grilla
        protected void CargarEditorialEnGrilla()
        {
            dgv_grillaEditorial.DataSource = EditorialDao.ConsultarEditorial();
            dgv_grillaEditorial.DataKeyNames = new string[] { "idEditorial" };
            dgv_grillaEditorial.DataBind();
        }

        //Eliminar editorial de la grilla
        protected void btn_eliminarEditorial_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            EditorialDao.EliminarEditorial((int)dgv_grillaEditorial.DataKeys[e.RowIndex].Value);
            LimpiarForm();
            Session["idEditorial"] = null;
        }

        //Modificar editorial de la grilla
        protected void btn_modificarEditorial_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["idEditorial"] = (int)dgv_grillaEditorial.SelectedDataKey.Value;
            Response.Redirect("RegistrarEditorial_22.aspx");
        }

    }
}