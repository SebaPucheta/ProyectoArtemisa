using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace BaseDeDatos
{
    public class PrecioXHojaDao : Conexion
    {

        /// <summary>
        /// Registra un precio por hoja recibiendo un objeto precio por hoja
        /// </summary>
        public static void RegistrarPrecioXHoja(PrecioXHojaEntidad pxh)
        {
            string consulta = @"INSERT INTO PrecioXHoja (precioHoja, fecha, baja) VALUES (@pre, @fec, 0)";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"pre", pxh.precioHoja);
            cmd.Parameters.AddWithValue(@"fec", pxh.fecha);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        ///No eliminamos precioXHoja
        ///


        ///No modificamos precioXHoja para guardar en el hisotorial
        ///


        /// <summary>
        /// Consulta todos los precios por hoja registradas en la base de datos
        /// </summary>
        /// <returns>Lista de objetos precio x hoja</returns>
        public static List<PrecioXHojaEntidad> ConsultarPrecioXHoja()
        {
            List<PrecioXHojaEntidad> lista = new List<PrecioXHojaEntidad>();
            string consulta = @"SELECT idPrecioHoja, precioHoja, fecha FROM PrecioXHoja WHERE baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                PrecioXHojaEntidad pxh = new PrecioXHojaEntidad();
                pxh.idPrecioHoja = int.Parse(dr["idPreciohoja"].ToString());
                pxh.precioHoja = float.Parse(dr["precioHoja"].ToString());
                pxh.fecha = (DateTime)dr["fecha"];
                lista.Add(pxh);
            }
            dr.Close();
            cmd.Connection.Close();
            return lista;
        }


        /// <summary>
        /// Consultar: un solo precio por hoja con un ID determinado (sirva para el seleccioanr de las grillas)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PrecioXHojaEntidad ConsultarUnPrecioXHoja(int id)
        {
            PrecioXHojaEntidad pxh = new PrecioXHojaEntidad();
            string consulta = @"SELECT idPrecioHoja, precioHoja, fecha FROM PrecioXHoja WHERE idPrecioHoja = @id AND baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {      
                pxh.idPrecioHoja = int.Parse(dr["idPreciohoja"].ToString());
                pxh.precioHoja = float.Parse(dr["precioHoja"].ToString());
                pxh.fecha = (DateTime)dr["fecha"];
            }
            dr.Close();
            cmd.Connection.Close();
            return pxh;
        }

    
    }
}
