using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;

namespace ProyectoArtemisa.Reportes
{
    public partial class GenerarIngresoStockLibros_151 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txt_fechaDesde.Text = Request.QueryString["desde"];
                txt_fechaHasta.Text = Request.QueryString["hasta"];
                txt_nomProveedor.Text = Request.QueryString["proveedor"];
                txt_apellidoCliente.Text = Request.QueryString["nombre"];
                txt_nombreCliente.Text = Request.QueryString["apellido"];
                showReport();
            }
        }

        protected void btn_generar_Click(object sender, EventArgs e)
        {
              showReport();
        }

        protected void showReport()
        {
            try
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.Reset();


                string fechadesde = txt_fechaDesde.Text;
                string fechahasta = txt_fechaHasta.Text;
                if (fechadesde == "")
                {
                    fechadesde = (Convert.ToDateTime("01/01/1900")).ToString();
                }

                if (fechahasta == "")
                {
                    fechahasta = (Convert.ToDateTime("31/12/9999")).ToShortDateString();
                }
                DataTable dt = getData(DateTime.Parse(fechadesde), DateTime.Parse(fechahasta), txt_nombreCliente.Text, txt_apellidoCliente.Text, txt_nomProveedor.Text);
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                ReportViewer1.LocalReport.DataSources.Add(rds);
                ReportViewer1.LocalReport.ReportPath = "Reportes/GenerarIngresoStockLibros_151.rdlc";               
                
                string nomCliente = txt_nombreCliente.Text;
                string apeCliente = txt_apellidoCliente.Text;
                string nomProveedor = txt_nomProveedor.Text;
                
               


                if(nomCliente == "")
                { nomCliente = "*"; }
                if (apeCliente == "")
                { apeCliente = "*"; }
                if (nomProveedor == "")
                { nomProveedor = "*"; }

                ReportParameter[] param = new ReportParameter[]{ 
            new ReportParameter("fechaDesde", fechadesde),
            new ReportParameter("fechaHasta", fechahasta),
            new ReportParameter("NOMBREUSUARIO", nomCliente),
            new ReportParameter("APELLIDOUSUARIO", apeCliente),
            new ReportParameter("nombreProveedor", nomProveedor)
            };

                ReportViewer1.LocalReport.SetParameters(param);
                ReportViewer1.LocalReport.Refresh();
            }
            catch(Exception e)
            {
                Response.Write("ERROR:  " + e.ToString());
            }
                        }

        private DataTable getData(DateTime fechaDesde, DateTime fechaHasta, string nombreCliente, string apellidoCliente, string nombreProveedor)
        {      

            DataTable dt = new DataTable();
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["ProyectoArtemisaConnectionString"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand("sp_ingresoLibros", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                // tener cuidado cual es el parametro, es el de la bd
                cmd.Parameters.Add("@fechaDesde", SqlDbType.DateTime).Value = fechaDesde;
                cmd.Parameters.Add("@fechaHasta", SqlDbType.DateTime).Value = fechaHasta;
                cmd.Parameters.Add("@NOMBREUSUARIO", SqlDbType.VarChar).Value = nombreCliente;
                cmd.Parameters.Add("@nombreProveedor", SqlDbType.VarChar).Value = nombreProveedor;
                cmd.Parameters.Add("@APELLIDOUSUARIO", SqlDbType.VarChar).Value = apellidoCliente;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            return dt;
        }
        
    }
}