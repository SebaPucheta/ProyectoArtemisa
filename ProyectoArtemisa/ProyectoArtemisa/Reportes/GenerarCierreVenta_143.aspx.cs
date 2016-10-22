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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                DataTable dt = getData(DateTime.Parse(txt_fechaDesde.Text), DateTime.Parse(txt_fechaHasta.Text));
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                ReportViewer1.LocalReport.DataSources.Add(rds);
                ReportViewer1.LocalReport.ReportPath = "Reportes/GenerarCierreVenta_143.rdlc";

                ReportParameter[] param = new ReportParameter[]{ 
            new ReportParameter("fechaDesde", txt_fechaDesde.Text),
            new ReportParameter("fechaHasta", txt_fechaHasta.Text)
            };

                ReportViewer1.LocalReport.SetParameters(param);
                ReportViewer1.LocalReport.Refresh();
            }
            catch(Exception e)
            {
                Response.Write("Este es el error apliado segun pucho " + e.ToString());
            }
                        }

        private DataTable getData(DateTime fechaDesde, DateTime fechaHasta)
        {
            DataTable dt = new DataTable();
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["ProyectoArtemisaConnectionString"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand("sp_ventaXdia", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                // tener cuidado cual es el parametro, es el de la bd
                cmd.Parameters.Add("@fechaDesde", SqlDbType.DateTime).Value = fechaDesde;
                cmd.Parameters.Add("@fechaHasta", SqlDbType.DateTime).Value = fechaHasta;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            return dt;
        }
    }
}