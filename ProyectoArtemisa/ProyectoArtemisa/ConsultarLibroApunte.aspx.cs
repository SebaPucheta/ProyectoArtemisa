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
                CargarComboTipoItem();
                if ((PilaForms.pila.Peek().Equals("ConsultarOrdenImpresion_126.aspx") || PilaForms.pila.Peek().Equals("RegistrarVentaVentanilla_128.aspx")) && ((Session["idItem"] != null)))
                {
                    if (Session["idTipo"].ToString() == "Apunte")
                    {
                        int idApunte = int.Parse(Session["idItem"].ToString());
                        CargarUnApunteEnGrilla(ApunteDao.ConsultarApunteQuery(idApunte));

                    }
                    else
                    {
                        CargarUnLibroEnGrilla(LibroDao.ConsultarLibroQuery(int.Parse(Session["idItem"].ToString())));
                    }
                }
                btn_codigoBarra.Focus();
            }
            //Toma los metodos ejecutados en JavaScript en el HTML
            //if(IsPostBack)
            //{
            //    string eventTarget;
            //    string eventArgument;

            //    if (Request["__EVENTARGUMENT"] == null) 
            //    {eventTarget = string.Empty;}
            //    else
            //    { eventTarget = Request["__EVENTTARGET"];}
            //    if (Request["__EVENTARGUMENT"] == null) 
            //    { eventArgument = string.Empty; }
            //    else
            //    { eventArgument = Request["__EVENTARGUMENT"]; }

            //    if (eventTarget == "CrearOrdenImpresion")
            //    {
            //        string valuePassed  = eventArgument;
            //        CrearOrdenImpresion();
            //    }

            //    string parameter = Request["__EVENTARGUMENT"];
            //}
        }


        protected void ddl_universidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboFacultad(Convert.ToInt32(ddl_universidad.SelectedValue));
        }
        protected void ddl_facultad_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboMateria(Convert.ToInt32(ddl_facultad.SelectedValue));
            CargarComboCarrera(Convert.ToInt32(ddl_facultad.SelectedValue));
        }
        protected void dgv_grillaApunte_OnPageIndexChanging(Object sender, GridViewPageEventArgs e)
        {
            dgv_grillaApunte.PageIndex = e.NewPageIndex;
            RecargarGrillaApunte();
        }
        protected void dgv_grillaLibro_OnPageIndexChanging(Object sender, GridViewPageEventArgs e)
        {
            dgv_grillaLibro.PageIndex = e.NewPageIndex;
            RecargarGrillaLibro();
        }
        protected void ddl_carrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_carrera.SelectedIndex == 0)
            {
                ddl_materia.Enabled = true;
            }
            else
            {
                ddl_materia.Enabled = false;
            }
        }
        protected void ddl_materia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_materia.SelectedIndex == 0)
            {
                ddl_carrera.Enabled = true;
            }
            else
            {
                ddl_carrera.Enabled = false;
            }
        }
        protected void ddl_tipoItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboUniversidad();

            if (ddl_tipoItem.SelectedIndex == 1)
            {
                lbl_tipoApunte.Visible = true;
                lbl_apunteDigital.Visible = true;
                lbl_apunteImpreso.Visible = true;

            }
            else
            {
                lbl_tipoApunte.Visible = false;
                lbl_apunteDigital.Visible = false;
                lbl_apunteImpreso.Visible = false;
            }
        }

        protected void CargarComboUniversidad()
        {
            ddl_universidad.DataSource = UniversidadDao.ConsultarUniversidad();
            ddl_universidad.DataTextField = "nombreUniversidad";
            ddl_universidad.DataValueField = "idUniversidad";
            ddl_universidad.DataBind();
            ddl_universidad.Items.Insert(0, new ListItem("(Universidad)", "0"));
            ddl_universidad.SelectedIndex = 0;
        }

        //Cargar combo Facultad apartir de la universidad selecionada
        protected void CargarComboFacultad(int idUniversidad)
        {
            ddl_facultad.DataSource = FacultadDao.ConsultarFacultadXUniversidad(idUniversidad);
            ddl_facultad.DataTextField = "nombreFacultad";
            ddl_facultad.DataValueField = "idFacultad";
            ddl_facultad.DataBind();
            ddl_facultad.Items.Insert(0, new ListItem("(Facultad)", "0"));
            ddl_facultad.SelectedIndex = 0;
        }

        //Cargar combo Materia apartir de la facultad seleccionada
        protected void CargarComboMateria(int idFacultad)
        {
            ddl_materia.DataSource = MateriaDao.DevolverMateriaXFacultad(idFacultad);
            ddl_materia.DataTextField = "nombreMateria";
            ddl_materia.DataValueField = "idMateria";
            ddl_materia.DataBind();
            ddl_materia.Items.Insert(0, new ListItem("(Materia)", "0"));
            ddl_materia.SelectedIndex = 0;
        }

        protected void CargarComboCarrera(int idFacultad)
        {
            ddl_carrera.DataSource = CarreraDao.ConsultarCarreraXFacultad(idFacultad);
            ddl_carrera.DataTextField = "nombreCarrera";
            ddl_carrera.DataValueField = "idCarrera";
            ddl_carrera.DataBind();
            ddl_carrera.Items.Insert(0, new ListItem("(Carrera)", "0"));
            ddl_carrera.SelectedIndex = 0;
        }

        protected void CargarComboTipoItem()
        {
            ddl_tipoItem.Items.Insert(0, new ListItem("(Tipo Apunte)", "0"));
            ddl_tipoItem.Items.Insert(1, new ListItem("Apunte", "1"));
            ddl_tipoItem.Items.Insert(2, new ListItem("Libro", "2"));
            ddl_tipoItem.SelectedIndex = 0;
        }

        protected void btn_eliminarApunte_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            ApunteDao.EliminarApunte((int)dgv_grillaApunte.DataKeys[e.RowIndex].Value);
            CargarApunteEnGrilla(BuscarListaApunteXfiltro());
            dgv_grillaLibro.Visible = false;
            dgv_grillaApunte.Visible = true;
        }

        protected void btn_modificarApunte_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["idApunte"] = (int)dgv_grillaApunte.SelectedDataKey.Value;
            PilaForms.AgregarForm("ConsultarLibroApunte.aspx");
            Response.Redirect("RegistrarApunte_26.aspx");
        }

        protected void btn_eliminarLibro_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            LibroDao.EliminarLibro((int)dgv_grillaLibro.DataKeys[e.RowIndex].Value);
            CargarLibroEnGrilla(BuscarListaLibroXfiltro());
            dgv_grillaApunte.Visible = false;
            dgv_grillaLibro.Visible = true;
        }

        protected void btn_modificarLibro_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["idLibro"] = (int)dgv_grillaLibro.SelectedDataKey.Value;
            PilaForms.AgregarForm("ConsultarLibroApunte.aspx");
            Response.Redirect("RegistarLibro_2.aspx");
        }

        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            if (ddl_tipoItem.SelectedIndex == 0)
            {
                Response.Write("<script>window.alert('Se debe seleccionar un tipo de item');</script>");
            }
            else
            {
                if (ddl_tipoItem.SelectedIndex == 1)
                {
                    CargarApunteEnGrilla(BuscarListaApunteXfiltro());
                    dgv_grillaLibro.Visible = false;
                    dgv_grillaApunte.Visible = true;
                }
                else
                {
                    CargarLibroEnGrilla(BuscarListaLibroXfiltro());
                    dgv_grillaApunte.Visible = false;
                    dgv_grillaLibro.Visible = true;
                }
            }

        }
        protected void btn_salir_Click(object sender, EventArgs e)
        {
            Response.Redirect(PilaForms.pila.Pop());
        }


        protected List<ApunteEntidadQuery> BuscarListaApunteXfiltro()
        {
            List<ApunteEntidadQuery> listaApunte;
            string tipoApunte = "";
            string universidad = "";
            string facultad = "";
            string materia = "";
            string carrera = "";
            string nombreApunte = txt_nombreItem.Text;

            if (!((chk_apunteDigital.Checked) && (chk_apunteImpreso.Checked)))
            {
                if ((chk_apunteDigital.Checked) || (chk_apunteImpreso.Checked))
                {
                    if (chk_apunteDigital.Checked)
                    { tipoApunte = "2"; }
                    else
                    { tipoApunte = "1"; }
                }
            }

            if (Convert.ToInt32(ddl_universidad.SelectedIndex) != 0)
            {
                universidad = ddl_universidad.SelectedValue;
            }

            if (Convert.ToInt32(ddl_facultad.SelectedIndex) != 0)
            {
                facultad = ddl_facultad.SelectedValue;
            }

            if (Convert.ToInt32(ddl_materia.SelectedIndex) != 0)
            {
                materia = ddl_materia.SelectedValue;
                listaApunte = ApunteDao.ConsultarApunteXFiltroMateria(tipoApunte, nombreApunte, universidad, facultad, materia);
            }
            else
            {
                if (Convert.ToInt32(ddl_carrera.SelectedIndex) != 0)
                {
                    carrera = ddl_carrera.SelectedValue;
                    listaApunte = ApunteDao.ConsultarApunteXFiltroCarrera(tipoApunte, nombreApunte, universidad, facultad, carrera);
                }
                listaApunte = ApunteDao.ConsultarApunteXFiltroCarrera(tipoApunte, nombreApunte, universidad, facultad, carrera);
            }




            return listaApunte;
        }

        protected List<LibroEntidadQuery> BuscarListaLibroXfiltro()
        {
            List<LibroEntidadQuery> listaLibro;
            string nombreLibro = txt_nombreItem.Text;
            string universidad = "";
            string facultad = "";
            string materia = "";
            string carrera = "";

            if (Convert.ToInt32(ddl_universidad.SelectedIndex) != 0)
            {
                universidad = ddl_universidad.SelectedValue;
            }

            if (Convert.ToInt32(ddl_facultad.SelectedIndex) != 0)
            {
                facultad = ddl_facultad.SelectedValue;
            }

            if (Convert.ToInt32(ddl_materia.SelectedIndex) != 0)
            {
                materia = ddl_materia.SelectedValue;
                listaLibro = LibroDao.ConsultarLibroXFiltroMateria(nombreLibro, universidad, facultad, materia);
            }
            else
            {
                if (Convert.ToInt32(ddl_carrera.SelectedIndex) != 0)
                {
                    carrera = ddl_carrera.SelectedValue;
                }
                listaLibro = LibroDao.ConsultarLibroXFiltroCarrera(nombreLibro, universidad, facultad, carrera);
            }

            return listaLibro;
        }



        //Creo una tabla para luego cargarla en el GridView
        protected void CargarUnApunteEnGrilla(ApunteEntidadQuery apunte)
        {
            DataTable tabla = new DataTable();
            DataRow fila;

            //Creo las columnas de la tabla
            tabla.Columns.Add("idApunte", typeof(int));
            tabla.Columns.Add("nombre", typeof(string));
            tabla.Columns.Add("precio", typeof(string));
            tabla.Columns.Add("stock", typeof(string));
            tabla.Columns.Add("carrera", typeof(string));
            tabla.Columns.Add("materia", typeof(string));
            tabla.Columns.Add("editorial", typeof(string));
            tabla.Columns.Add("profesor", typeof(string));
            tabla.Columns.Add("tipoApunte", typeof(string));


            fila = tabla.NewRow();

            fila[0] = apunte.idApunte;
            fila[1] = apunte.nombreApunte;
            fila[2] = "$" + apunte.precioApunte;
            fila[3] = apunte.stock + " Unidades";

            List<CarreraEntidad> listaCarrera = apunte.listaCarreras;
            string carreras = listaCarrera[0].nombreCarrera;
            for (int i = 1; i < listaCarrera.Count; i++)
            {
                carreras = carreras + ", " + listaCarrera[i].nombreCarrera;
            }

            fila[4] = carreras;
            fila[5] = apunte.nombreMateria;
            fila[6] = apunte.nombreEditorial;
            fila[7] = apunte.apellidoProfesor + ", " + apunte.nombreProfesor;
            fila[8] = apunte.nombreTipoApunte;

            tabla.Rows.Add(fila);


            DataView dataView = new DataView(tabla);

            
            dgv_grillaApunte.DataKeyNames = new string[] { "idApunte" };
            dgv_grillaApunte.DataSource = dataView;
            dgv_grillaApunte.DataBind();
        }

        //Creo una tabla para luego cargarla en el GridView

        protected void CargarApunteEnGrilla(List<ApunteEntidadQuery> listaApunteFiltrados)
        {
            DataTable tabla = new DataTable();
            DataRow fila;

            //Creo las columnas de la tabla
            tabla.Columns.Add("idApunte", typeof(int));
            tabla.Columns.Add("nombre", typeof(string));
            tabla.Columns.Add("precio", typeof(string));
            tabla.Columns.Add("stock", typeof(string));
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
                fila[2] = "$" + apunte.precioApunte;
                fila[3] = apunte.stock + " Unidades";

                List<CarreraEntidad> listaCarrera = apunte.listaCarreras;
                string carreras = listaCarrera[0].nombreCarrera;
                for (int i = 1; i < listaCarrera.Count; i++)
                {
                    carreras = carreras + ", " + listaCarrera[i].nombreCarrera;
                }

                fila[4] = carreras;
                fila[5] = apunte.nombreMateria;
                fila[6] = apunte.nombreEditorial;
                fila[7] = apunte.apellidoProfesor + ", " + apunte.nombreProfesor;
                fila[8] = apunte.nombreTipoApunte;

                tabla.Rows.Add(fila);
            }

            DataView dataView = new DataView(tabla);

            Session["dataViewApunte"] = dataView;
            dgv_grillaApunte.DataKeyNames = new string[] { "idApunte" };
            dgv_grillaApunte.DataSource = dataView;
            dgv_grillaApunte.DataBind();
        }

        protected void CargarLibroEnGrilla(List<LibroEntidadQuery> listalibroFiltrados)
        {
            DataTable tabla = new DataTable();
            DataRow fila;

            //Creo las columnas de la tabla
            tabla.Columns.Add("idLibro", typeof(int));
            tabla.Columns.Add("nombre", typeof(string));
            tabla.Columns.Add("precio", typeof(string));
            tabla.Columns.Add("stock", typeof(string));
            tabla.Columns.Add("carrera", typeof(string));
            tabla.Columns.Add("materia", typeof(string));
            tabla.Columns.Add("editorial", typeof(string));
            tabla.Columns.Add("autor", typeof(string));

            foreach (LibroEntidadQuery libro in listalibroFiltrados)
            {
                fila = tabla.NewRow();

                fila[0] = libro.idLibro;
                fila[1] = libro.nombreLibro;
                fila[2] = "$" + libro.precioLibro;
                fila[3] = libro.stock + " Unidades";

                List<CarreraEntidad> listaCarrera = libro.listaCarreras;
                string carreras = listaCarrera[0].nombreCarrera;
                for (int i = 1; i < listaCarrera.Count; i++)
                {
                    carreras = carreras + ", " + listaCarrera[i].nombreCarrera;
                }

                fila[4] = carreras;
                fila[5] = libro.nombreMateria;
                fila[6] = libro.nombreEditorial;
                fila[7] = libro.autorLibro;

                tabla.Rows.Add(fila);
            }

            DataView dataView = new DataView(tabla);
            Session["dataViewLibro"] = dataView;
            dgv_grillaLibro.DataSource = dataView;
            dgv_grillaLibro.DataKeyNames = new string[] { "idLibro" };
            dgv_grillaLibro.DataBind();
        }
        private void RecargarGrillaLibro()
        {
             
            dgv_grillaLibro.DataSource = (Session["dataViewLibro"] as DataView);
            dgv_grillaLibro.DataKeyNames = new string[] { "idLibro" };
            dgv_grillaLibro.DataBind();
        }

        private void RecargarGrillaApunte()
        {

            dgv_grillaApunte.DataSource = (Session["dataViewApunte"] as DataView);
            dgv_grillaApunte.DataKeyNames = new string[] { "idApunte" };
            dgv_grillaApunte.DataBind();
        }
        protected void CargarUnLibroEnGrilla(LibroEntidadQuery libro)
        {
            DataTable tabla = new DataTable();
            DataRow fila;

            //Creo las columnas de la tabla
            tabla.Columns.Add("idLibro", typeof(int));
            tabla.Columns.Add("nombre", typeof(string));
            tabla.Columns.Add("precio", typeof(string));
            tabla.Columns.Add("stock", typeof(string));
            tabla.Columns.Add("carrera", typeof(string));
            tabla.Columns.Add("materia", typeof(string));
            tabla.Columns.Add("editorial", typeof(string));
            tabla.Columns.Add("autor", typeof(string));

            fila = tabla.NewRow();

            fila[0] = libro.idLibro;
            fila[1] = libro.nombreLibro;
            fila[2] = "$" + libro.precioLibro;
            fila[3] = libro.stock + "Unidades";

            List<CarreraEntidad> listaCarrera = libro.listaCarreras;
            string carreras = listaCarrera[0].nombreCarrera;
            for (int i = 1; i < listaCarrera.Count; i++)
            {
                carreras = carreras + ", " + listaCarrera[i].nombreCarrera;
            }

            fila[4] = carreras;
            fila[5] = libro.nombreMateria;
            fila[6] = libro.nombreEditorial;
            fila[7] = libro.autorLibro;

            tabla.Rows.Add(fila);


            DataView dataView = new DataView(tabla);

            dgv_grillaLibro.DataSource = dataView;
            dgv_grillaLibro.DataKeyNames = new string[] { "idLibro" };
            dgv_grillaLibro.DataBind();
        }

        protected void RedirigirForm()
        {
            if (PilaForms.pila.Peek().Equals("RegistrarVentaVentanilla_128.aspx"))
            {
                Response.Redirect(PilaForms.DevolverForm());
            }
            if (PilaForms.pila.Peek().Equals("ConsultarOrdenImpresion_126.aspx"))
            {
                Response.Redirect(PilaForms.DevolverForm());
            }
            if (PilaForms.pila.Peek().Equals("IngresoLibro.aspx"))
            {
                Response.Redirect(PilaForms.DevolverForm());
            }
            else
            {
                PilaForms.AgregarForm("ConsultarLibroApunte.aspx");
                Response.Redirect("ConsultarOrdenImpresion_126.aspx");
            }

        }
        protected void dgv_grillaApunte_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName != "Sort" && e.CommandName!="Page")
            {
                int indice = ((GridViewRow)(e.CommandSource as LinkButton).Parent.Parent).RowIndex;

                if (e.CommandName == "imprimir")
                {
                    CargarVariablesSesion(indice);
                    RedirigirForm();
                }
            }
            
        }

        protected void dgv_grillaLibro_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName != "Sort" && e.CommandName!="Page")
            {
                int indice = ((GridViewRow)(e.CommandSource as LinkButton).Parent.Parent).RowIndex;

                if (e.CommandName == "imprimir")
                {
                    CargarVariablesSesion(indice);
                    RedirigirForm();
                }
            }
        }

        protected void CargarVariablesSesion(int indice)
        {
            if (Convert.ToInt32(ddl_tipoItem.SelectedValue) == 1)
            {
                string tipoApunte = Page.Server.HtmlDecode(dgv_grillaApunte.Rows[indice].Cells[7].Text);
                if (tipoApunte.Equals("Digital"))
                {
                    Response.Write("<script>window.alert('No puede vender por ventanilla un apunte digital');</script>");
                }
                else
                {
                    ApunteEntidad apunteSeleccionado = new ApunteEntidad();
                    apunteSeleccionado.idApunte = (Int32)dgv_grillaApunte.DataKeys[indice].Value;
                    apunteSeleccionado.nombreApunte = Page.Server.HtmlDecode(dgv_grillaApunte.Rows[indice].Cells[0].Text);
                    apunteSeleccionado.precioApunte = float.Parse(dgv_grillaApunte.Rows[indice].Cells[1].Text.Substring(1));
                    Session["objetoApunteEntidad"] = apunteSeleccionado;
                }



            }
            else
            {
                LibroEntidad libroSeleccionado = new LibroEntidad();
                libroSeleccionado.idLibro = (Int32)dgv_grillaLibro.DataKeys[indice].Value;
                libroSeleccionado.nombreLibro = Page.Server.HtmlDecode(dgv_grillaLibro.Rows[indice].Cells[0].Text);
                libroSeleccionado.precioLibro = float.Parse(dgv_grillaLibro.Rows[indice].Cells[1].Text.Substring(1));
                Session["objetoLibroEntidad"] = libroSeleccionado;
            }
        }

        protected void btn_codigoBarra_TextChanged(object sender, EventArgs e)
        {
            dgv_grillaApunte.DataSource = null;
            dgv_grillaApunte.DataBind();
            dgv_grillaLibro.DataSource = null;
            dgv_grillaLibro.DataBind();

            dgv_grillaApunte.Visible = false;
            dgv_grillaLibro.Visible = false;


            List<ApunteEntidadQuery> ap = new List<ApunteEntidadQuery>();
            ap = ApunteDao.ConsultarApunteXCodigoBarra(btn_codigoBarra.Text);

            if (ap.Count != 0)
            {
                dgv_grillaApunte.Visible = true;
                DataTable tabla = new DataTable();
                DataRow fila;

                //Creo las columnas de la tabla
                tabla.Columns.Add("idApunte", typeof(int));
                tabla.Columns.Add("nombre", typeof(string));
                tabla.Columns.Add("precio", typeof(string));
                tabla.Columns.Add("stock", typeof(string));
                tabla.Columns.Add("carrera", typeof(string));
                tabla.Columns.Add("materia", typeof(string));
                tabla.Columns.Add("editorial", typeof(string));
                tabla.Columns.Add("profesor", typeof(string));
                tabla.Columns.Add("tipoApunte", typeof(string));

                foreach (ApunteEntidadQuery apunte in ap)
                {
                    fila = tabla.NewRow();

                    fila[0] = apunte.idApunte;
                    fila[1] = apunte.nombreApunte;
                    fila[2] = "$" + apunte.precioApunte;
                    fila[3] = apunte.stock + " Unidades";

                    List<CarreraEntidad> listaCarrera = apunte.listaCarreras;
                    string carreras = listaCarrera[0].nombreCarrera;
                    for (int i = 1; i < listaCarrera.Count; i++)
                    {
                        carreras = carreras + ", " + listaCarrera[i].nombreCarrera;
                    }

                    fila[4] = carreras;
                    fila[5] = apunte.nombreMateria;
                    fila[6] = apunte.nombreEditorial;
                    fila[7] = apunte.apellidoProfesor + ", " + apunte.nombreProfesor;
                    fila[8] = apunte.nombreTipoApunte;

                    tabla.Rows.Add(fila);
                }

                DataView dataView = new DataView(tabla);



                dgv_grillaApunte.DataKeyNames = new string[] { "idApunte" };
                dgv_grillaApunte.DataSource = dataView;
                dgv_grillaApunte.DataBind();
            }
            else
            {
                List<LibroEntidadQuery> lp = new List<LibroEntidadQuery>();
                lp = LibroDao.ConsultarLibroXCodigoBarra(btn_codigoBarra.Text);
                //si hay algo en la lista me carga la grilla
                if (lp.Count != 0)
                {
                    dgv_grillaLibro.Visible = true;
                    DataTable tabla = new DataTable();
                    DataRow fila;

                    //Creo las columnas de la tabla
                    tabla.Columns.Add("idLibro", typeof(int));
                    tabla.Columns.Add("nombre", typeof(string));
                    tabla.Columns.Add("precio", typeof(string));
                    tabla.Columns.Add("stock", typeof(string));
                    tabla.Columns.Add("carrera", typeof(string));
                    tabla.Columns.Add("materia", typeof(string));
                    tabla.Columns.Add("editorial", typeof(string));
                    tabla.Columns.Add("autor", typeof(string));

                    foreach (LibroEntidadQuery libro in lp)
                    {
                        fila = tabla.NewRow();

                        fila[0] = libro.idLibro;
                        fila[1] = libro.nombreLibro;
                        fila[2] = "$" + libro.precioLibro;
                        fila[3] = libro.stock + " Unidades";

                        List<CarreraEntidad> listaCarrera = libro.listaCarreras;
                        string carreras = listaCarrera[0].nombreCarrera;
                        for (int i = 1; i < listaCarrera.Count; i++)
                        {
                            carreras = carreras + ", " + listaCarrera[i].nombreCarrera;
                        }

                        fila[4] = carreras;
                        fila[5] = libro.nombreMateria;
                        fila[6] = libro.nombreEditorial;
                        fila[7] = libro.autorLibro;

                        tabla.Rows.Add(fila);
                    }

                    DataView dataView = new DataView(tabla);

                    dgv_grillaLibro.DataSource = dataView;
                    dgv_grillaLibro.DataKeyNames = new string[] { "idLibro" };
                    dgv_grillaLibro.DataBind();
                }
                else
                {
                    Response.Write("<script>window.alert('Código de barra inexistente');</script>");
                }
            }
            btn_codigoBarra.Text = "";
        }

    }
}