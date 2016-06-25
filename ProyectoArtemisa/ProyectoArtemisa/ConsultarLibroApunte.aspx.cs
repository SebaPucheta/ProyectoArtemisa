using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseDeDatos;
using Entidades;
using Negocio;
using System.Data;


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

        protected void ddl_materia_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComboMateria();
        }
        protected void ddl_universidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComboMateria();
        }
        protected void ddl_facultad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComboMateria();
        }
        protected void ddl_carrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComboMateria();
        }
        protected void ddl_tipoItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComboMateria();
        }

        protected void btn_buscar_Click(object sender, EventArgs e)
        {
           
        }

        //protected List<ApunteEntidad> BuscarListaApunteXfiltro()
        //{
        //    string tipoApunte = "";
        //    string universidad = "";
        //    string facultad = "";
        //    string materia = "";
        //    string carrera = "";

        //    if (!((chk_apunteDigital.Checked) && (chk_apunteImpreso.Checked)))
        //    {
        //        if((chk_apunteDigital.Checked) || (chk_apunteImpreso.Checked))
        //        {
        //            if(chk_apunteDigital.Checked)
        //            { tipoApunte = "2"; }
        //            else
        //            { tipoApunte = "1"; }
        //        }
        //    }
            
        //    if (Convert.ToInt32(ddl_universidad.SelectedIndex) != 0)
        //    {
        //        universidad = ddl_universidad.SelectedValue;
        //    }

        //    if (Convert.ToInt32(ddl_facultad.SelectedIndex) != 0)
        //    {
        //        facultad = ddl_facultad.SelectedValue;
        //    }

        //    if (Convert.ToInt32(ddl_materia.SelectedIndex) != 0)
        //    {
        //        materia = ddl_materia.SelectedValue;
        //    }

        //    if (Convert.ToInt32(ddl_carrera.SelectedIndex) != 0)
        //    {
        //        universidad = ddl_carrera.SelectedValue;
        //    }

        //    List<ApunteEntidadQuery> listaApunte = new List<ApunteEntidadQuery>();
        //    return listaApunte;
        //}


        protected void cargarComboCarrera()
        {

        }

        protected void cargarComboMateria()
        {
            
        }

        //Creo una tabla para luego cargarla en el GridView
        protected void CargarApunteEnGrilla(List<ApunteEntidadQuery> listaApunteFiltrados)
        {
            DataTable tabla = new DataTable();
            DataRow fila;

            //Creo las columnas de la tabla
            tabla.Columns.Add("idApunte", typeof(int));
            tabla.Columns.Add("nombre", typeof(string));
            tabla.Columns.Add("precio", typeof(float));
            tabla.Columns.Add("stock", typeof(int));
            tabla.Columns.Add("carrera", typeof(string));
            tabla.Columns.Add("materia", typeof(string));
            tabla.Columns.Add("editorial", typeof(string));
            tabla.Columns.Add("profesor", typeof(string));
            tabla.Columns.Add("tipoApunte", typeof(string));

            foreach (ApunteEntidadQuery apunte in listaApunteFiltrados)
            {
                fila = tabla.NewRow();

                fila[0] = apunte.idApunte;
                fila[1] = apunte.nombreApunte;
                fila[2] = apunte.precioApunte;
                fila[3] = apunte.stock;
                
                List<CarreraEntidad> listaCarrera = CarreraDao.ConsultarCarreraXMateria(apunte.idMateria);
                string carreras = listaCarrera[0].nombreCarrera;
                for(int i =1; i<listaCarrera.Count;i++)
                {
                    carreras = carreras + ", " + listaCarrera[i].nombreCarrera;
                }

                fila[4] = carreras;
                fila[5] = apunte.nombreMateria;
                fila[6] = apunte.nombreEditorial;
                fila[7] = apunte.nombreProfesor;
                fila[8] = apunte.nombreTipoApunte;

                tabla.Rows.Add(fila);
            }

            DataView dataView = new DataView(tabla);

            dgv_grillaItem.DataSource = dataView;
            dgv_grillaItem.DataKeyNames = new string[] {"idApunte"};
            dgv_grillaItem.DataBind();
        }


    }
}