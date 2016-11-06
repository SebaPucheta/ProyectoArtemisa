using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using Entidades;
using System.Data;

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
            string query = @"SELECT f.idFactura, f.fecha, f.total, ISNULL(f.idUsuario,0) AS idUsuario ,  ISNULL(C.nombreCliente,'') + ' ' +  ISNULL(C.apellidoCliente,'') AS nombreCompleto
                            FROM Factura f LEFT join Usuario u
											on u.idUsuario = f.idUsuario
											LEFT join Cliente C
											ON C.idCliente = U.idCliente
							WHERE f.fecha >= convert(date, @fechaDesde, 103) AND f.fecha <= convert(date, @fechaHasta, 103)";
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
                factura.idUsuario = int.Parse(dr["idUsuario"].ToString());
                factura.nombreCompletoEmpleado = dr["nombreCompleto"].ToString();
                //factura.nombreTipoPago = dr["descripcion"].ToString();
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

                string query1 = "INSERT INTO Factura(fecha, total, idUsuario) VALUES (@fecha, @total, @idUsuario); select scope_identity()";
                SqlCommand cmd1 = new SqlCommand(query1, cnn,trans);
                cmd1.Parameters.AddWithValue(@"fecha", DateTime.Now);
                cmd1.Parameters.AddWithValue(@"total", factura.total);
                cmd1.Parameters.AddWithValue(@"idUsuario", factura.idUsuario);
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

        public static DataTable DevolverItemPorCodigoBarra(string codigo)
        {
            string query = @"(SELECT A.idApunte AS idItem, A.nombreApunte as nombre, 'Apunte' as tipoItem, A.precioApunte as precio FROM Apunte A WHERE A.codigoBarraApunte like @codigo AND baja = 0 )
                                union all
                             (SELECT l.idLibro AS idItem, l.nombreLibro as nombre, 'Libro' as tipoItem, l.precioLibro as precio FROM Libro L WHERE L.codigoBarraLibro like @codigo AND Baja = 0 )";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"codigo", codigo);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(reader);
            return tabla;
        }
        
    }
}
