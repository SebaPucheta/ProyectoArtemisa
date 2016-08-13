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
        public static List<OrdenImpresionEntidadQuery> ListarOrdenesImpresion()
        {
            List<OrdenImpresionEntidadQuery> lista = new List<OrdenImpresionEntidadQuery>();
            //idOrdenImpresion
            //idApunte
            //cantidad
            //idEstadoOrdenImpresion
            //fecha

            string query = @"SELECT o.idOrdenImpresion, a.nombreApunte, o.cantidad, eo.nombreEstadoOrdenImpresion, o.fecha
                             FROM OrdenImpresion o INNER JOIN EstadoOrdenImpresion eo ON o.idEstadoOrdenImpresion = eo.idEstadoOrdenImpresion
					                               INNER JOIN Apunte a ON o.idApunte = a.idApunte";
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


        //Se ingresa un id de un orden de impresion y cambia el estado de la orden de impresion a "En local" osea el 3
        public static void CambiarEstadoEnLocal(int idOrdenImpresion)
        {
            string query = @"UPDATE OrdenImpresion SET idEstadoOrdenImpresion = 3 WHERE idOrdenImpresion = @id";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", idOrdenImpresion);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }





    }
}
