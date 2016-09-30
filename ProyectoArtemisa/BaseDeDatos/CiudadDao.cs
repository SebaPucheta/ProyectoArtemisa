using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace BaseDeDatos
{
    public class CiudadDao : Conexion
    {

        /// <summary>
        /// Registrar: una ciudad recibiendo un objeto ciudad
        /// </summary>
        public static void RegistrarCiudad(CiudadEntidad ciudad)
        {
            string consulta = @"INSERT INTO Ciudad (nombreCiudad, idProvincia, baja) VALUES (@nom, @idProv, 0)";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"idProv", ciudad.idProvincia);
            cmd.Parameters.AddWithValue(@"nom", ciudad.nombreCiudad);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        /// <summary>
        /// Eliminar: una ciudad determinada, es un UPDATE que cambia el atributo baja a 1
        /// </summary>
        /// <param name="id"></param>
        public static void EliminarCiudad(int id)
        {
            string consulta = @"UPDATE Ciudad SET baja = 1 WHERE idCiudad = @id";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        /// <summary>
        /// Modificar: una ciudad recibiendo un objeto ciudad
        /// </summary>
        public static void ModificarCiudad(CiudadEntidad ciudad)
        {
            string consulta = @"UPDATE Ciudad SET nombreCiudad = @nom, idProvincia = @idProv WHERE idCiudad = @id";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"nom", ciudad.nombreCiudad);
            cmd.Parameters.AddWithValue(@"id", ciudad.idCiudad);
            cmd.Parameters.AddWithValue(@"idProv", ciudad.idProvincia);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }




        /// <summary>
        /// Consultar: todas las ciudades registradas en la base de datos
        /// </summary>
        /// <returns>Lista de objetos ciudad</returns>
        public static List<CiudadEntidad> ConsultarCiudades()
        {
            List<CiudadEntidad> lista = new List<CiudadEntidad>();
            string consulta = @"SELECT idCiudad, idProvincia, nombreCiudad FROM Ciudad WHERE baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CiudadEntidad ciudad = new CiudadEntidad();
                ciudad.idCiudad = int.Parse(dr["idCiudad"].ToString());
                ciudad.nombreCiudad = dr["nombreCiudad"].ToString();
                ciudad.idProvincia = int.Parse(dr["idProvincia"].ToString());
                lista.Add(ciudad);
            }
            dr.Close();
            cmd.Connection.Close();
            return lista;
        }

        /// <summary>
        /// Consultar: una ciudad registrada en la base de datos por un idProvincia
        /// </summary>
        /// <returns>Lista de objetos ciudad</returns>
        public static List<CiudadEntidad> ConsultarCiudadXProvincia(int id)
        {
            
            string consulta = @"SELECT idCiudad, idProvincia, nombreCiudad FROM Ciudad WHERE idProvincia = @id AND baja = 0 order by nombreCiudad";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            List<CiudadEntidad> listaCiudad = new List<CiudadEntidad>();
            while (dr.Read())
            {
                CiudadEntidad ciudad = new CiudadEntidad();
                ciudad.idCiudad = int.Parse(dr["idCiudad"].ToString());
                ciudad.nombreCiudad = dr["nombreCiudad"].ToString();
                ciudad.idProvincia = int.Parse(dr["idProvincia"].ToString());
                listaCiudad.Add(ciudad);
            }
            dr.Close();
            cmd.Connection.Close();
            return listaCiudad;
        }

        /// <summary>
        /// Consultar: una ciudad registrada en la base de datos por un idCiudad
        /// </summary>
        /// <returns>CiudadEntidad</returns>
        public static CiudadEntidad ConsultarCiudad(int id)
        {

            string consulta = @"SELECT idCiudad, idProvincia, nombreCiudad FROM Ciudad WHERE idCiudad = @id AND baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            CiudadEntidad ciudad = new CiudadEntidad();
            while (dr.Read())
            {
                ciudad.idCiudad = int.Parse(dr["idCiudad"].ToString());
                ciudad.nombreCiudad = dr["nombreCiudad"].ToString();
                ciudad.idProvincia = int.Parse(dr["idProvincia"].ToString());
            }
            dr.Close();
            cmd.Connection.Close();
            return ciudad;
        }
        /// <summary>
        /// El metodo recibe el id de una ciudad y devuelve el id de la provincia
        /// a la que pertenece
        /// </summary>
        /// <param name="id"></param>
        /// <returns>int</returns>
        public static int ConsultaridProvinciaDeLaCiudad(int id)
        {
            int idProvincia = 0;
            string consulta = @"SELECT idProvincia FROM Ciudad WHERE idCiudad = @id AND baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            if(cmd.ExecuteScalar() != DBNull.Value)
                idProvincia = (int)(cmd.ExecuteScalar());
            
            cmd.Connection.Close();
            return idProvincia;
        }


    }
}
