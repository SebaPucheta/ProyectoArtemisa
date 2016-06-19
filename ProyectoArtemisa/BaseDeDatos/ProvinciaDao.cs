using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace BaseDeDatos
{
    public class ProvinciaDao : Conexion
    {

        /// <summary>
        /// Registrar: una provincia recibiendo un objeto provincia
        /// </summary>
        public static void RegistrarProvincia(ProvinciaEntidad uni)
        {
            string consulta = @"INSERT INTO Provincia (nombreProvincia, baja) VALUES (@nom, 0)";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"nom", uni.nombreProvincia);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        /// <summary>
        /// Elimina una provincia determinada, es un UPDATE que cambia el atributo baja a 1
        /// </summary>
        /// <param name="id"></param>
        public static void EliminarProvincia(int id)
        {
            string consulta = @"UPDATE Provincia SET baja = 1 WHERE idProvincia = @id";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        /// <summary>
        /// Modifica una provincia recibiendo un objeto provincia
        /// </summary>
        public static void ModificarProvincia(ProvinciaEntidad uni)
        {
            string consulta = @"UPDATE Provincia SET nombreProvincia = @nom WHERE idProvincia = @id";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"nom", uni.nombreProvincia);
            cmd.Parameters.AddWithValue(@"id", uni.idProvincia);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }




        /// <summary>
        /// Consultar: todas las provincias registradas en la base de datos
        /// </summary>
        /// <returns>Lista de objetos provincia</returns>
        public static List<ProvinciaEntidad> ConsultarProvincias()
        {
            List<ProvinciaEntidad> lista = new List<ProvinciaEntidad>();
            string consulta = @"SELECT idProvincia, nombreProvincia FROM Provincia WHERE baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ProvinciaEntidad prov = new ProvinciaEntidad();
                prov.idProvincia = int.Parse(dr["idProvincia"].ToString());
                prov.nombreProvincia = dr["nombreProvincia"].ToString();
                lista.Add(prov);
            }
            dr.Close();
            cmd.Connection.Close();
            return lista;
        }

        /// <summary>
        /// Consultar: una provincia registrada en la base de datos
        /// </summary>
        /// <returns>Lista de objetos provincia</returns>
        public static ProvinciaEntidad ConsultarProvincia(int id)
        {
            ProvinciaEntidad prov = new ProvinciaEntidad();
            string consulta = @"SELECT idProvincia, nombreProvincia FROM Provincia WHERE idProvincia = @id AND baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                prov.idProvincia = int.Parse(dr["idProvincia"].ToString());
                prov.nombreProvincia = dr["nombreProvincia"].ToString();
            }
            dr.Close();
            cmd.Connection.Close();
            return prov;
        }



    }
}
