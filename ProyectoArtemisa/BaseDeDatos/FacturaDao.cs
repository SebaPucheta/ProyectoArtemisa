using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using Entidades;

namespace BaseDeDatos
{
    public class FacturaDao : Conexion
    {
        /// <summary>
        /// devuelve una lista de facturas
        /// 
        /// </summary> Gumer
        /// <returns></returns>
        /// Autor: Modificado por Martin 03-09-16
        public static List<FacturaEntidadQuery> ListarFacturas(string fechaDesde, string fechaHasta)
        {
            string query = @"SELECT f.idFactura, f.fecha, f.total, tp.descripcion
                            FROM Factura f INNER JOIN TipoPago tp ON f.idTipoPago = tp.idTipoPago
                            WHERE f.fecha BETWEEN convert(date, @fechaDesde, 103) AND convert(date, @fechaHasta, 103)";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());

            if (fechaDesde == "")
            {
                string FECHA = DateTime.Now.ToShortDateString();
                cmd.Parameters.AddWithValue(@"fechaDesde", "01/01/1900");
                cmd.Parameters.AddWithValue(@"fechaHasta", DateTime.Now.ToShortDateString());
            }
            else
            {
                cmd.Parameters.AddWithValue(@"fechaDesde", fechaDesde);
                cmd.Parameters.AddWithValue(@"fechaHasta", fechaHasta);

            }

            SqlDataReader dr = cmd.ExecuteReader();
            List<FacturaEntidadQuery> lista = new List<FacturaEntidadQuery>();
            while (dr.Read())
            {
                FacturaEntidadQuery factura = new FacturaEntidadQuery();
                factura.idFactura = int.Parse(dr["idFactura"].ToString());
                factura.fecha = DateTime.Parse(dr["fecha"].ToString());
                factura.total = float.Parse(dr["total"].ToString());
                factura.nombreTipoPago = dr["descripcion"].ToString();
                lista.Add(factura);
            }
            dr.Close();
            cmd.Connection.Close();
            return lista;
        }

        /// <summary>
        ///
        /// Tipo 1-Libro
        /// Tipo 2-Apunte
        /// </summary> Gumer
        /// <param name="factura"></param>
        public static void RegistrarFactura(FacturaEntidad factura)
        {
            SqlConnection cnn= obtenerBD();
            SqlTransaction trans = cnn.BeginTransaction();
            
            try
            {

                string query1 = "INSERT INTO Factura(fecha, total) VALUES (@fecha, @total); select scope_identity()";
                SqlCommand cmd1 = new SqlCommand(query1, cnn,trans);
                cmd1.Parameters.AddWithValue(@"fecha", factura.fecha);
                cmd1.Parameters.AddWithValue(@"total", factura.total);
                int idFactura = int.Parse(cmd1.ExecuteScalar().ToString());

                foreach (DetalleFacturaEntidad detalleFactura in factura.listaDetalleFactura)
                {
                    string query2 = "INSERT INTO DetalleFactura (idItem, cantidad, subtotal, idFactura, idTipoItem) VALUES (@idItem, @cantidad, @subtotal, @idFactura, @idTipoItem)";
                    SqlCommand cmd2 = new SqlCommand(query2, cnn, trans);
                    cmd2.Parameters.AddWithValue(@"cantidad", detalleFactura.cantidad);
                    cmd2.Parameters.AddWithValue(@"subtotal", detalleFactura.subtotal);
                    cmd2.Parameters.AddWithValue(@"idFactura", idFactura);

                    if (detalleFactura.item is ApunteEntidad )//Apunte
                    {
                        cmd2.Parameters.AddWithValue(@"idTipoItem", 2);
                        cmd2.Parameters.AddWithValue(@"idItem", ((ApunteEntidad)(detalleFactura.item)).idApunte);
                        cmd2.ExecuteNonQuery();
                        //Restar la cantidad de stock al apunte
                        string query3 = "UPDATE Apunte SET stock = stock - @cantidad";
                        SqlCommand cmd3 = new SqlCommand(query3, cnn, trans);
                        cmd3.Parameters.AddWithValue(@"cantidad", detalleFactura.cantidad);
                        cmd3.ExecuteNonQuery();
                    }
                    else//Libro
                    {
                        cmd2.Parameters.AddWithValue(@"idTipoItem", 1);
                        cmd2.Parameters.AddWithValue(@"idItem", ((LibroEntidad)(detalleFactura.item)).idLibro);
                        cmd2.ExecuteNonQuery();
                        //Restar la cantidad de stock al libro
                        string query3 = "UPDATE Libro SET stock = stock - @cantidad";
                        SqlCommand cmd3 = new SqlCommand(query3, cnn, trans);
                        cmd3.Parameters.AddWithValue(@"cantidad", detalleFactura.cantidad);
                        cmd3.ExecuteNonQuery();
                    }
                    
                }
                //--- Commit
                trans.Commit();
            }
            catch (Exception)
            {
                trans.Rollback();
            }
            finally { cnn.Close(); }
        }
    }
}
