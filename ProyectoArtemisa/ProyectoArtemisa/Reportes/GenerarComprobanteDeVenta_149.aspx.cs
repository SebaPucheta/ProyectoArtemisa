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
    public partial class GenerarComprobanteDeVenta_149 : System.Web.UI.Page
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
                DataTable dt = getData(int.Parse(txt_idFactura.Text));
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                ReportViewer1.LocalReport.DataSources.Add(rds);
                ReportViewer1.LocalReport.ReportPath = "Reportes/GenerarComprobanteDeVenta_149.rdlc";

                ReportParameter[] param = new ReportParameter[]{ 
            new ReportParameter("idFactura", txt_idFactura.Text),
            
            };

                ReportViewer1.LocalReport.SetParameters(param);
                ReportViewer1.LocalReport.Refresh();
            }
            catch (Exception e)
            {
                Response.Write("ERROR" + e.ToString());
            }
        }

        private DataTable getData(int idFactura)
        {
            DataTable dt = new DataTable();
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["ProyectoArtemisaConnectionString"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand("sp_facturaXIdFactura", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                // tener cuidado cual es el parametro, es el de la bd
                cmd.Parameters.Add("@idFactura", SqlDbType.Int).Value = idFactura;              

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            return dt;
        }
    }
}