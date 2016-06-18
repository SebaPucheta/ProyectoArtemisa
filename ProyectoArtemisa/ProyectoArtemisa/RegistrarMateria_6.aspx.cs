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
    public partial class RegistrarMateria_6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_registrarMateria_Click(object sender, EventArgs e)
        {
            MateriaEntidad mat = new MateriaEntidad();
            mat.nombreMateria = txt_nombreMateriaLibro.Text;
            mat.nivelCursado = int.Parse(txt_nivelCursadoMateria.Text);
            mat.descripcionMateria = txt_descripcionMateriaLibro.Text;

            MateriaDao.RegistrarMateria(mat);
        }

        public void cargarComboUniversidad()
        {

        }
    }
}