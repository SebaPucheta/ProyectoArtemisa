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
                if ((bool)Session["modificarProfesor"])
                {
                    CargarUnProfesorEnElForm(ProfesorDao.ConsultarUnProfesor((int)Session["idProfesor"]));
                }
                else
                {
                    CargarComboMateria();
                }
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

        protected void CargarUnProfesorEnElForm(ProfesorEntidad profesor)
        {
            txt_apellido.Text = profesor.apellidoProfesor;
            txt_nombre.Text = profesor.nombreProfesor;
            CargarComboMateria();
            ddl_materiaProfesor.SelectedValue = profesor.idMateria.ToString();
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
                
                if ((bool)Session["modificarProfesor"])
                {
                    prof.idProfesor = (int)Session["idProfesor"];
                    ProfesorDao.ModificarProfesor(prof);
                    Session["modificarProfesor"]= false;
                }
                else
                {
                    ProfesorDao.RegistrarProfesor(prof);
                }
                Response.Redirect(PilaForms.DevolverForm());
                //Agregar boton emergente
            }
            catch
            {
                //Agregar boton emergente
            }
        }

        protected void btn_salir_Click(object sender, EventArgs e)
        {
            Session["modificarProfesor"] = false;
            Response.Redirect(PilaForms.DevolverForm());
            //Response redirect al form anterior
        }

        protected void btn_registrarMateria_onClick(object sender, EventArgs e)
        {
            PilaForms.AgregarForm("RegistrarProfesor_14.aspx");
            Response.Redirect("RegistrarMateria_6.aspx");
            //Response redirect al form anterior
        }

        protected void btn_modificarMateria_onClick(object sender, EventArgs e)
        {
            Session["idMateria"] = ddl_materiaProfesor.SelectedValue;
            Session["modificarMateria"] = true;
            PilaForms.AgregarForm("RegistrarProfesor_14.aspx");
            Response.Redirect("RegistrarMateria_6.aspx");
            //Response redirect al form anterior
        }
    }
}