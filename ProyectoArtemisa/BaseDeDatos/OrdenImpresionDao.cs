using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace BaseDeDatos
{
    public class OrdenImpresionDao : Conexion
    {
        /// <summary>
        /// Lista todas las ordenes de impresion
        /// </summary>
        /// <returns></returns>
        /// Autor: Gumer Modificado por: Puchi
        public static List<OrdenImpresionEntidadQuery> ListarOrdenesImpresion(string fechaDesde, string fechaHasta)
        {
            List<OrdenImpresionEntidadQuery> lista = new List<OrdenImpresionEntidadQuery>();
            //idOrdenImpresion
            //idApunte
            //cantidad
            //idEstadoOrdenImpresion
            //fecha

            string query = @"SELECT o.idOrdenImpresion, a.nombreApunte, o.cantidad, eo.nombreEstadoOrdenImpresion, o.fecha
                             FROM OrdenImpresion o INNER JOIN EstadoOrdenImpresion eo ON o.idEstadoOrdenImpresion = eo.idEstadoOrdenImpresion
					                               INNER JOIN Apunte a ON o.idApunte = a.idApunte
                             WHERE o.fecha BETWEEN convert(date, @fechaDesde, 103) AND convert(date, @fechaHasta, 103)";
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
            while (dr.Read())
            {
                OrdenImpresionEntidadQuery orden = new OrdenImpresionEntidadQuery();
                orden.idOrdenImpresion = int.Parse(dr["idOrdenImpresion"].ToString());
                orden.nombreApunte = dr["nombreApunte"].ToString();
                orden.cantidad = int.Parse(dr["cantidad"].ToString());
                orden.nombreEstadoOrdenImpresion = dr["nombreEstadoOrdenImpresion"].ToString();
                orden.fecha = DateTime.Parse(dr["fecha"].ToString());
                lista.Add(orden);
            }

            dr.Close();
            cmd.Connection.Close();
            return lista;
        }

        //Verificar que las ordenes esten en estado pendiente o impreso
        //Estados orden de impresion: 1-Pendiente, 2-Impreso, 3-En Local, 4-Cancelada
        public static List<OrdenImpresionEntidadQuery> ListarOrdenApuntePendientes()
        {
            List<OrdenImpresionEntidadQuery> lista = new List<OrdenImpresionEntidadQuery>();
            string query = @"SELECT o.idOrdenImpresion, a.nombreApunte, o.cantidad, eo.nombreEstadoOrdenImpresion, o.fecha
                             FROM OrdenImpresion o INNER JOIN EstadoOrdenImpresion eo ON o.idEstadoOrdenImpresion = eo.idEstadoOrdenImpresion
					                               INNER JOIN Apunte a ON o.idApunte = a.idApunte
                             WHERE o.idEstadoOrdenImpresion = 1 OR o.idEstadoOrdenImpresion = 2";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                OrdenImpresionEntidadQuery orden = new OrdenImpresionEntidadQuery();
                orden.idOrdenImpresion = int.Parse(dr["idOrdenImpresion"].ToString());
                orden.nombreApunte = dr["nombreApunte"].ToString();
                orden.cantidad = int.Parse(dr["cantidad"].ToString());
                orden.nombreEstadoOrdenImpresion = dr["nombreEstadoOrdenImpresion"].ToString();
                orden.fecha = DateTime.Parse(dr["fecha"].ToString());
                lista.Add(orden);
            }
            dr.Close();
            cmd.Connection.Close();
            return lista;
        }

        //Recibe una nueva orden de impresion y devuelve el id de la misma
        public static int RegistrarOrdenImpresion(OrdenImpresionEntidadQuery nuevaOrden)
        {
            string query = @"INSERT INTO OrdenImpresion (idApunte, cantidad, idEstadoOrdenImpresion, fecha)
			                 VALUES (@idApunte, @cantidad, @idEstado, @fecha); SELECT SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue("@idApunte", nuevaOrden.idApunte);
            cmd.Parameters.AddWithValue("@cantidad", nuevaOrden.cantidad);
            cmd.Parameters.AddWithValue("@idEstado", nuevaOrden.idEstadoOrden);
            cmd.Parameters.AddWithValue("@fecha", DateTime.Now );
            int ordenRegistrada = int.Parse(cmd.ExecuteScalar().ToString());
            cmd.Connection.Close();
            return ordenRegistrada;
        }


        //Recibe un id de orden de Impresion y lo borra de la base de datos
        public static void EliminarOrdenImpresion(int idOrdenImpresion)
        {
            string query = @"UPDATE OrdenImpresion SET idEstadoOrdenImpresion = 4 WHERE idOrdenImpresion = @id";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", idOrdenImpresion);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //Se ingresa un id de un orden de impresion y devuelve el id del apunte de la orden
        public static int DevolverIdApunte(int idOrdenImpresion)
        {
            string query = @"SELECT idOrdenImpresion, idApunte FROM OrdenImpresion WHERE idOrdenImpresion = @id";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", idOrdenImpresion);
            SqlDataReader dr = cmd.ExecuteReader();
            int id = 0;
            while (dr.Read())
            {
                id = int.Parse(dr["idApunte"].ToString());
            }
            dr.Close();
            cmd.Connection.Close();
            return id;
        }

        //Se ingresa un id de un orden de impresion y cambia el estado de la orden de impresion a "Impreso" osea el 2
        public static void CambiarEstadoImpreso(int idOrdenImpresion)
        {
            string query = @"UPDATE OrdenImpresion SET idEstadoOrdenImpresion = 2 WHERE idOrdenImpresion = @id";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", idOrdenImpresion);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //Se ingresa un id de un orden de impresion y cambia el estado de la orden de impresion a "Pendiente" osea el 2
        public static void CambiarEstadoPendiente(int idOrdenImpresion)
        {
            string query = @"UPDATE OrdenImpresion SET idEstadoOrdenImpresion = 1 WHERE idOrdenImpresion = @id";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", idOrdenImpresion);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //Se ingresa un id de un orden de impresion y cambia el estado de la orden de impresion a "En local" osea el 3
        public static void CambiarEstadoEnLocal(int idOrdenImpresion)
        {
            SqlConnection cnn = obtenerBD();
            SqlTransaction trans = cnn.BeginTransaction();

            try
            {
                string query1 = @"UPDATE OrdenImpresion SET idEstadoOrdenImpresion = 3 WHERE idOrdenImpresion = @id";
                SqlCommand cmd1 = new SqlCommand(query1, obtenerBD(), trans);
                cmd1.Parameters.AddWithValue(@"id", idOrdenImpresion);
                cmd1.ExecuteNonQuery();

                //creamos el objeto ordenImpresion con el metodo devolverUnaOrdenImpresion
                OrdenImpresionEntidad ordenImpresion = DevolverUnaOrdenImpresion(idOrdenImpresion);

                string query2 = @"UPDATE Apunte SET stock = stock + @cantidad WHERE idApunte = @id";
                SqlCommand cmd2 = new SqlCommand(query2, obtenerBD(), trans);
                cmd2.Parameters.AddWithValue(@"cantidad", ordenImpresion.cantidad);
                cmd2.Parameters.AddWithValue(@"id", ordenImpresion.idApunte);
                cmd2.ExecuteNonQuery();
                //--- Commit
                trans.Commit();
            }
            catch (Exception)
            {
                trans.Rollback();
            }
            finally
            {
                cnn.Close();
            }

        }
        /// <summary>
        /// devuelve una orden de impresion
        /// </summary> Gumer
        /// <param name="idOrdenImpresion"></param>
        /// <returns></returns>
        public static OrdenImpresionEntidad DevolverUnaOrdenImpresion(int idOrdenImpresion)
        {
            OrdenImpresionEntidad orden = new OrdenImpresionEntidad();
            string query = @"SELECT idOrdenImpresion, idApunte, cantidad, idEstadoOrdenImpresion, fecha FROM OrdenImpresion WHERE idOrdenImpresion = @id";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", idOrdenImpresion);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                orden.idOrdenImpresion = int.Parse(dr["idOrdenImpresion"].ToString());
                orden.idApunte = int.Parse(dr["idApunte"].ToString());
                orden.cantidad = int.Parse(dr["cantidad"].ToString());
                orden.idEstadoOrden = int.Parse(dr["idEstadoOrdenImpresion"].ToString());
                orden.fecha = DateTime.Parse(dr["fecha"].ToString());
            }
            dr.Close();
            cmd.Connection.Close();
            return orden;
        }

        //Se ingresa un id de un orden de impresion y cambia el estado de la orden de impresion a "En local" osea el 3
        public static void CambiarCantidadDeCopias(int idOrdenImpresion, int cantidad)
        {
            string query = @"UPDATE OrdenImpresion SET cantidad = @cantidad WHERE idOrdenImpresion = @id";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", idOrdenImpresion);
            cmd.Parameters.AddWithValue(@"cantidad", cantidad);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //Devuelve el estado de la orden de impresion
        public static int DevolverEstadoOrdenImpresion(int idOrdenImpresion)
        {
            string query = @"SELECT OrdenImpresion.idEstadoOrdenImpresion
                             FROM OrdenImpresion
                             WHERE OrdenImpresion.idOrdenImpresion = @id";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", idOrdenImpresion);
            int idEstado = (int)cmd.ExecuteScalar();
            cmd.Connection.Close();
            return idEstado;
        }

        //        //Devuelve el idApunte
        //        public static int DevolverIdApunte(int idOrdenImpresion)
        //        {
        //            string query = @"SELECT OrdenImpresion.idApunte
        //                             FROM OrdenImpresion
        //                             WHERE OrdenImpresion.idOrdenImpresion = @id";
        //            SqlCommand cmd = new SqlCommand(query, obtenerBD());
        //            cmd.Parameters.AddWithValue(@"id", idOrdenImpresion);
        //            int idApunte = (int)cmd.ExecuteScalar();
        //            cmd.Connection.Close();
        //            return idApunte;
        //        }

        
    }
}
