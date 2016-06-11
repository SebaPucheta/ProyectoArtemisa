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
            string consulta = @"INSERT INTO PrecioHoja (precio, fecha) VALUES (@pre, @fec)";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"pre", pxh.precio);
            cmd.Parameters.AddWithValue(@"fec", pxh.fecha);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        /// <summary>
        /// Consulta todos los precios por hoja registradas en la base de datos
        /// </summary>
        /// <returns>Lista de objetos precio x hoja</returns>
        public static List<PrecioXHojaEntidad> ConsultarPrecioXHoja()
        {
            List<PrecioXHojaEntidad> lista = new List<PrecioXHojaEntidad>();
            string consulta = @"SELECT idPrecioHoja, precio, fecha FROM PrecioHoja";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                PrecioXHojaEntidad pxh = new PrecioXHojaEntidad();
                pxh.idPrecioHoja = int.Parse(dr["idPreciohoja"].ToString());
                pxh.precio = float.Parse(dr["precio"].ToString());
                pxh.fecha = (DateTime)dr["fecha"];
                lista.Add(pxh);
            }
            dr.Close();
            cmd.Connection.Close();
            return lista;
        }

        /// <summary>
        /// No se debe permitir modificacion
        /// </summary>
        public static void ModificarPrecioXHoja(PrecioXHojaEntidad phx)
        {
            //No se modifican
        }



    }
}
