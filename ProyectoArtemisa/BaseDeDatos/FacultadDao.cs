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
    public class FacultadDao : Conexion
    {

        /// <summary>
        /// Registrar: una facultad
        /// </summary>
        /// <param name="facultad"></param>
        public static void RegistrarFacultad(FacultadEntidad facultad)
        {
            string query = "INSERT INTO Facultad(nombreFacultad, idUniversidad, idCiudad, baja) VALUES (@nombreFacultad, @idUniversidad, @idCiudad, 0)";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"nombreFacultad", facultad.nombreFacultad);
            cmd.Parameters.AddWithValue(@"idUniversidad", facultad.idUniversidad);
            cmd.Parameters.AddWithValue(@"idCiudad", facultad.idCiudad);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        /// <summary>
        /// Eliminar: una facultad con un id determinado
        /// </summary>
        /// <param name="id"></param>
        public static void EliminarFacultad(int id)
        {
            string consulta = @"UPDATE Facultad SET baja = 1 WHERE idFacultad = @id";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        /// <summary>
        /// Modificar: una facultad pasando como datos una facultad completa
        /// </summary>
        /// <param name="facultad"></param>
        public static void ModificarFacultad(FacultadEntidad facultad)
        {
            string consulta = @"UPDATE Facultad SET nombreFacultad = @nom, idUniversidad = @idUniversidad, idCiudad = @idCiudad WHERE idFacultad = @idFacultad";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"nom", facultad.nombreFacultad);
            cmd.Parameters.AddWithValue(@"idUniversidad", facultad.idUniversidad);
            cmd.Parameters.AddWithValue(@"idCiudad", facultad.idCiudad);
            cmd.Parameters.AddWithValue(@"idFacultad", facultad.idFacultad);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        /// <summary>
        /// Consultar: todas las facultades
        /// </summary>
        /// <returns></returns>
        public static List<FacultadEntidad> ConsultarFacultad()
        {
            List<FacultadEntidad> listaFac = new List<FacultadEntidad>();
            string query = "SELECT idFacultad, nombreFacultad, idUniversidad, idCiudad FROM Facultad WHERE baja = 0";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                FacultadEntidad fac = new FacultadEntidad();
                fac.idFacultad = int.Parse(dr["idFacultad"].ToString());
                fac.nombreFacultad = dr["nombreFacultad"].ToString();
                fac.idUniversidad = (int)dr["idUniversidad"];
                fac.idCiudad = int.Parse(dr["idCiudad"].ToString());
                listaFac.Add(fac);
            }
            dr.Close();
            cmd.Connection.Close();
            return listaFac;
        }


        /// <summary>
        /// Consultar: todas las facultades de una universidad
        /// </summary>
        /// <param name="idUniversidad"></param>
        /// <returns></returns>
        public static List<FacultadEntidad> ConsultarFacultadXUniversidad(int idUniversidad)
        {
            List<FacultadEntidad> listaFac = new List<FacultadEntidad>();
            string query = "SELECT idFacultad, nombreFacultad, idUniversidad, idCiudad FROM Facultad WHERE idUniversidad = @idUniversidad AND baja = 0";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue("@idUniversidad", idUniversidad);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                FacultadEntidad fac = new FacultadEntidad();
                fac.idFacultad = int.Parse(dr["idFacultad"].ToString());
                fac.nombreFacultad = dr["nombreFacultad"].ToString();
                fac.idUniversidad = (int)dr["idUniversidad"];
                fac.idCiudad = int.Parse(dr["idCiudad"].ToString());
                listaFac.Add(fac);
            }
            dr.Close();
            cmd.Connection.Close();
            return listaFac;
        }


        /// <summary>
        /// Consultar: una sola facultad de un determinado ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static FacultadEntidad ConsultarUnaFacultad(int id)
        {
            FacultadEntidad fac = new FacultadEntidad();
            string query = "SELECT idFacultad, nombreFacultad, idUniversidad, idCiudad FROM Facultad WHERE idFacultad = @idFacultad";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue("@idFacultad", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                fac.idFacultad = int.Parse(dr["idFacultad"].ToString());
                fac.nombreFacultad = dr["nombreFacultad"].ToString();
                fac.idUniversidad = (int)dr["idUniversidad"];
                fac.idCiudad = int.Parse(dr["idCiudad"].ToString());
            }
            dr.Close();
            cmd.Connection.Close();
            return fac;
        }

    }
}
