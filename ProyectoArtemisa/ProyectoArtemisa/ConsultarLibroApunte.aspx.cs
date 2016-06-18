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
    public partial class ConsultarLibroApunte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarComboCarrera();
            }
        }

        protected void ddl_carrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComboMateria();
        }

        protected void cargarComboCarrera()
        {
            //ddl_carrera.DataSource = CarreraDao.consultarCarreraXNombre(int.Parse(ddl_carrera.SelectedValue));
            ddl_carrera.DataTextField = "nombre";
            ddl_carrera.DataValueField = "idCarrera";
            ddl_carrera.DataBind();
            ddl_carrera.Items.Insert(0, new ListItem("(Carrera)", "0"));
        }

        protected void cargarComboMateria()
        {
            //ddl_materia.DataSource = MateriaDao.consultarMateriaXNombre(int.Parse(ddl_materia.SelectedValue));
            ddl_materia.DataTextField = "nombre";
            ddl_materia.DataValueField = "idCarrera";
            ddl_materia.DataBind();
            ddl_materia.Items.Insert(0, new ListItem("(Materia)", "0"));
        }


        protected void btn_consultar_Click(object sender, EventArgs e)
        {

        }
    }
}