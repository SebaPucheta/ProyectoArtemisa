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


        }



        protected ClienteEntidad crearObjetoCliente()
        {
            ClienteEntidad cli = new ClienteEntidad();
            cli.nombreCliente = txt_nombre.Text;
            cli.apellidoCliente = txt_apellido.Text;
            cli.nroDni = int.Parse(txt_dni.Text);
            //cli.idTipoDNI = int.Parse(ddl_tipoDNI.SelectedValue);
            return cli;
        }

        protected UsuarioEntidad crearObjetoUsuario()
        {
            UsuarioEntidad user = new UsuarioEntidad();
            user.nombreUsuario = txt_nombreUsuario.Text;
            user.contrasena = txt_pass.Text;
            return user;
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

        protected void btn_guardar_Click (Object sender, EventArgs e)
        {

        }

        protected void btn_cancelar_Click(Object sender, EventArgs e)
        {

        }


    }
}
