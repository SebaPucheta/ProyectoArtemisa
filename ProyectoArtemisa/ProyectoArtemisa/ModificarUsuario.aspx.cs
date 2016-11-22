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
    public partial class ModificarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_contrasenaActual.Visible = false;
        }

        private bool VerificarValidezContrasenaActual()
        {
            int idUsuario = int.Parse(Session["idUsuario"].ToString());
            string pass = txt_pass.Text;
            return UsuarioDao.ExisteUsuario(idUsuario, pass);
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            if(VerificarValidezContrasenaActual())
            {
                UsuarioDao.ModificarContrasena(int.Parse(Session["idUsuario"].ToString()), txt_pass.Text);
            }
            else
            {
                lbl_contrasenaActual.Visible = true;
            }
        }

        
    }

}