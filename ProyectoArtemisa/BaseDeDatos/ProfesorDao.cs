using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace BaseDeDatos
{
    public class ProfesorDao : Conexion
    {
        /// <summary>
        /// Registra un profesor recibiendo un objeto profesor
        /// </summary>
        public static void RegistrarProfesor(ProfesorEntidad prof)
        {
            string consulta = @"INSERT INTO Profesor (nombre, apellido) VALUES (@nom, @ape)";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"nom", prof.nombre);
            cmd.Parameters.AddWithValue(@"ape", prof.apellido);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        /// <summary>
        /// Consulta todos los profesores registrado en la base de datos
        /// </summary>
        /// <returns>Lista de objetos profesor</returns>
        public static List<ProfesorEntidad> ConsultarProfesor()
        {
            List<ProfesorEntidad> lista = new List<ProfesorEntidad>();
            string consulta = @"SELECT idProfesor, nombre, apellido FROM Profesor";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ProfesorEntidad prof = new ProfesorEntidad();
                prof.idProfesor = int.Parse(dr["idProfesor"].ToString());
                prof.nombre = dr["nombre"].ToString();
                prof.apellido = dr["apellido"].ToString();
                lista.Add(prof);
            }
            dr.Close();
            cmd.Connection.Close();
            return lista;
        }

        /// <summary>
        /// Modifica un profesor recibiendo un objeto profesor
        /// </summary>
        public static void ModificarProfesor(ProfesorEntidad prof)
        {
            string consulta = @"UPDATE Profesor nombre = @nom, apellido = @ape)";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"nom", prof.nombre);
            cmd.Parameters.AddWithValue(@"ape", prof.apellido);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

    }
}
