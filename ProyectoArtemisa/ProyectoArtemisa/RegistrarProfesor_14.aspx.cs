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
    public partial class RegistrarProfesor_14 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarComboMateria();
            }
        }

        protected void CargarComboMateria()
        {
            ddl_materiaProfesor.DataSource = MateriaDao.ConsultarMateria();
            ddl_materiaProfesor.DataTextField = "nombreMateria";
            ddl_materiaProfesor.DataValueField = "idMateria";
            ddl_materiaProfesor.DataBind();
            ddl_materiaProfesor.Items.Insert(0, new ListItem("(Materia)", "0"));
            ddl_materiaProfesor.SelectedIndex = 0;
        }

        protected void limpiarForm()
        {
            txt_apellido.Text = string.Empty;
            txt_nombre.Text = string.Empty;
        }

        //Eventos del form
        protected void btn_registrar_Click(object sender, EventArgs e)
        {
            try
            {
                ProfesorEntidad prof = new ProfesorEntidad();
                prof.apellidoProfesor = txt_apellido.Text;
                prof.nombreProfesor = txt_nombre.Text;
                prof.idMateria =Convert.ToInt32(ddl_materiaProfesor.SelectedValue);
                ProfesorDao.RegistrarProfesor(prof);
                if (PilaForms.pila.Peek().Equals("Default.aspx"))
                {
                    limpiarForm();
                }
                else
                {
                    Response.Redirect(PilaForms.DevolverForm());
                }
                //Agregar boton emergente
            }
            catch
            {
                //Agregar boton emergente
            }
        }

        protected void btn_salir_Click(object sender, EventArgs e)
        {
            Response.Redirect(PilaForms.DevolverForm());
            //Response redirect al form anterior
        }

        protected void btn_registrarMateria_onClick(object sender, EventArgs e)
        {
            PilaForms.AgregarForm("RegistrarProfesor_14.aspx");
            Response.Redirect("RegistrarMateria_6.aspx");
            //Response redirect al form anterior
        }
    }
}