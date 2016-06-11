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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            CarreraEntidad carrera = new CarreraEntidad();
            carrera.nombre = txt_nombreCarrera.Text;

            CarreraDao.registrarCarrera(carrera);
        }
    }
}