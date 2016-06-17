using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

using System.Data.Sql;
using System.Data.SqlClient;



namespace BaseDeDatos
{

    public class UniversidadDao : Conexion
    {

        /// <summary>
        /// Registra una universidad recibiendo un objeto universidad
        /// </summary>
        public static void RegistrarUniversidad(UniversidadEntidad uni)
        {
            string consulta = @"INSERT INTO Universidad (nombre) VALUES (@nom)";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"nom", uni.nombreUniversidad);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        /// <summary>
        /// Consulta todas las universidades registradas en la base de datos
        /// </summary>
        /// <returns>Lista de objetos universidad</returns>
        public static List<UniversidadEntidad> ConsultarUniversidad()
        {
            List<UniversidadEntidad> lista = new List<UniversidadEntidad>();
            string consulta = @"SELECT idUniversidad, nombre FROM Universidad";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());

            SqlDataReader dr = cmd.ExecuteReader();

            List<UniversidadEntidad> listaUni = new List<UniversidadEntidad>();
            while (dr.Read())
            {
                UniversidadEntidad uni = new UniversidadEntidad();
                uni.idUniversidad = int.Parse(dr["idUniversidad"].ToString());
                uni.nombreUniversidad = dr["nombre"].ToString();

                listaUni.Add(uni);
            }

            dr.Close();
            cmd.Connection.Close();
            return listaUni;

        }
        
        /// <summary>
        /// Consulta todas las universidades registradas en la base de datos y las compara con el parametro ingresado
        /// </summary>
        /// <returns>Lista de objetos universidad que comiencen con el parametro ingresado</returns>
        public static List<UniversidadEntidad> ConsultarUniversidadXParametro(string parametro)
        {
            List<UniversidadEntidad> lista = new List<UniversidadEntidad>();
            string consulta = @"SELECT idUniversidad, nombre FROM Universidad WHERE nombre like @parametro";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"parametro", parametro + "%" );
            SqlDataReader dr = cmd.ExecuteReader();

            List<UniversidadEntidad> listaUni = new List<UniversidadEntidad>();
            while (dr.Read())
            {
                UniversidadEntidad uni = new UniversidadEntidad();
                uni.idUniversidad = int.Parse(dr["idUniversidad"].ToString());
                uni.nombreUniversidad = dr["nombre"].ToString();

                listaUni.Add(uni);
            }

            dr.Close();
            cmd.Connection.Close();
            return listaUni;

        }
        /// <summary>
        /// Modifica una universidad recibiendo un objeto universidad
        /// </summary>
        public static void ModificarUniversidad(UniversidadEntidad uni)
        {
            string consulta = @"UPDATE Universidad nombre = @nom)";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"nom", uni.nombreUniversidad);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
    }
}
