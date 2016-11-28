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
    public partial class RegistrarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarComboRol();
                CargarComboTipoDNI();
            }
        }

        private void CargarComboRol()
        {
            ddl_rol.DataSource = UsuarioDao.ConsultarRoles();
            ddl_rol.DataTextField = "nombreRol";
            ddl_rol.DataValueField = "idRol";
            ddl_rol.DataBind();
        }

        private void CargarComboTipoDNI()
        {
            ddl_tipoDNI.DataSource = UsuarioDao.DevolverTipDNI();
            ddl_tipoDNI.DataTextField = "nombreTipoDNI";
            ddl_tipoDNI.DataValueField = "idTipoDNI";
            ddl_tipoDNI.DataBind();
        }

        protected bool verificarUsuarioYEmailExistente(string nombreUsuario, string email)
        {
            if (UsuarioDao.VerificarUsuarioYEmailExistente(nombreUsuario, email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       protected bool VerificarIgualdadContrasena()
       {
           return txt_pass.Equals(txt_pass2.ToString());
       }

        protected void btn_guardar_Click (Object sender, EventArgs e)
        {
            if(!VerificarIgualdadContrasena())
            {
                UsuarioDao.RegistrarUsuarioEmpleado(CargarUsuario(), CargarEmpleado());
                Limpiar();
            }
        }

        protected void btn_cancelar_Click(Object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            txt_apellido.Text = "";
            txt_dni.Text = "";
            txt_email.Text = "";
            txt_nombre.Text = "";
            txt_nombreUsuario.Text = "";
            txt_pass.Text = "";
            txt_pass2.Text = "";
        }

        private EmpleadoEntidad CargarEmpleado()
        {
            EmpleadoEntidad empleado = new EmpleadoEntidad();
            empleado.nombreEmpleado = txt_nombre.Text;
            empleado.apellidoEmpleado = txt_apellido.Text;
            empleado.dni = int.Parse(txt_dni.Text);
            empleado.tipoDNI = int.Parse(ddl_tipoDNI.SelectedValue.ToString());
            empleado.email = txt_email.ToString();
            return empleado;
        }

        private UsuarioEntidad CargarUsuario()
        {
            UsuarioEntidad usuario = new UsuarioEntidad();
            usuario.nombreUsuario = txt_nombreUsuario.Text;
            usuario.contrasena = txt_pass.Text;
            usuario.idRol=int.Parse(ddl_rol.SelectedValue.ToString());
            return usuario;
        }

    }
}
