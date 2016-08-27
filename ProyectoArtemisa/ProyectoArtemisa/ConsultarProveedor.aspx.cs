using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseDeDatos;
using Entidades;

namespace ProyectoArtemisa
{
    public partial class ConsultarProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGrillaProveedores();
            }
        }

        protected void cargarGrillaProveedores()
        {
            dgv_grillaProveedores.DataSource = ProveedorDao.ConsultarProveedoresQuery();
            dgv_grillaProveedores.DataKeyNames = new string[] { "idProveedor" };
            dgv_grillaProveedores.DataBind();
        }

        protected void cargarGrillaEditoriales(int id)
        {
            dgv_grillaEditoriales.DataSource = ProveedorDao.ConsultarEditorialesDeUnProveedor(id);
            dgv_grillaEditoriales.DataKeyNames = new string[] { "idEditorial" };
            dgv_grillaEditoriales.DataBind();
        }

        //Ver editoriales en la otra grilla
        protected void btn_consultarEditoriales(object sender, EventArgs e)
        {
            int idSeleccionado;
            idSeleccionado = (int)dgv_grillaProveedores.SelectedDataKey.Value;
            cargarGrillaEditoriales(idSeleccionado);
        }
        protected void btn_modificarProveedor(object sender, EventArgs e)
        {
        }
    }
}