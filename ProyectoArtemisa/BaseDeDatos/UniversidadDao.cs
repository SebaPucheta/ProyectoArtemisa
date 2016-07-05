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
        /// Registrar: una universidad recibiendo un objeto universidad
        /// </summary>
        public static void RegistrarUniversidad(UniversidadEntidad uni)
        {
            string consulta = @"INSERT INTO Universidad (nombreUniversidad, baja) VALUES (@nom, 0)";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"nom", uni.nombreUniversidad);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        /// <summary>
        /// Elimina una universidad determinada, es un UPDATE que cambia el atributo baja a 1
        /// </summary>
        /// <param name="id"></param>
        public static void EliminarUniversidad(int id)
        {
            string consulta = @"UPDATE Universidad SET baja = 1 WHERE idUniversidad = @id";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        /// <summary>
        /// Modifica una universidad recibiendo un objeto universidad
        /// </summary>
        public static void ModificarUniversidad(UniversidadEntidad uni)
        {
            string consulta = @"UPDATE Universidad SET nombreUniversidad = @nom WHERE idUniversidad = @id";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"nom", uni.nombreUniversidad);
            cmd.Parameters.AddWithValue(@"id", uni.idUniversidad);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }




        /// <summary>
        /// Consultar: todas las universidades registradas en la base de datos
        /// </summary>
        /// <returns>Lista de objetos universidad</returns>
        public static List<UniversidadEntidad> ConsultarUniversidad()
        {
            List<UniversidadEntidad> lista = new List<UniversidadEntidad>();
            string consulta = @"SELECT idUniversidad, nombreUniversidad FROM Universidad WHERE baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());

            SqlDataReader dr = cmd.ExecuteReader();

            List<UniversidadEntidad> listaUni = new List<UniversidadEntidad>();
            while (dr.Read())
            {
                UniversidadEntidad uni = new UniversidadEntidad();
                uni.idUniversidad = int.Parse(dr["idUniversidad"].ToString());
                uni.nombreUniversidad = dr["nombreUniversidad"].ToString();

                listaUni.Add(uni);
            }

            dr.Close();
            cmd.Connection.Close();
            return listaUni;

        }

        /// <summary>
        /// Consultar: todas las universidades registradas en la base de datos y las compara con el parametro ingresado
        /// </summary>
        /// <returns>Lista de objetos universidad que comiencen con el parametro ingresado</returns>
        public static List<UniversidadEntidad> ConsultarUniversidadXParametro(string parametro)
        {
            List<UniversidadEntidad> lista = new List<UniversidadEntidad>();
            string consulta = @"SELECT idUniversidad, nombreUniversidad FROM Universidad WHERE nombreUniversidad LIKE @parametro AND baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"parametro", parametro + "%");
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                UniversidadEntidad uni = new UniversidadEntidad();
                uni.idUniversidad = int.Parse(dr["idUniversidad"].ToString());
                uni.nombreUniversidad = dr["nombreUniversidad"].ToString();
                lista.Add(uni);
            }
            dr.Close();
            cmd.Connection.Close();
            return lista;

        }


        /// <summary>
        /// Consultar: una universidad registrada en la base de datos
        /// </summary>
        /// <returns>Lista de objetos universidad</returns>
        public static UniversidadEntidad ConsultarUnaUniversidad(int id)
        {
            UniversidadEntidad uni = new UniversidadEntidad();
            string consulta = @"SELECT idUniversidad, nombreUniversidad  FROM Universidad WHERE idUniversidad = @id AND baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                uni.idUniversidad = int.Parse(dr["idUniversidad"].ToString());
                uni.nombreUniversidad = dr["nombreUniversidad"].ToString();
            }
            dr.Close();
            cmd.Connection.Close();
            return uni;
        }

    }
}
