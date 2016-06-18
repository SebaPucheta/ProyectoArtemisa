using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace BaseDeDatos
{
    public  class ProfesorDao : Conexion
    {
        /// <summary>
        /// Registra un profesor recibiendo un objeto profesor
        /// </summary>
        public static void RegistrarProfesor(ProfesorEntidad prof)
        {
            string consulta = @"INSERT INTO Profesor (nombreProfesor, apellido) VALUES (@nom, @ape)";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"nom", prof.nombreProfesor);
            cmd.Parameters.AddWithValue(@"ape", prof.apellidoProfesor);
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
            string consulta = @"SELECT idProfesor, nombreProfesor, apellido FROM Profesor";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ProfesorEntidad prof = new ProfesorEntidad();
                prof.idProfesor = int.Parse(dr["idProfesor"].ToString());
                prof.nombreProfesor = dr["nombreProfesor"].ToString();
                prof.apellidoProfesor = dr["apellido"].ToString();
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
            cmd.Parameters.AddWithValue(@"nom", prof.nombreProfesor);
            cmd.Parameters.AddWithValue(@"ape", prof.apellidoProfesor);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public static List<ProfesorEntidad> DevolverProfesorXMateria(int idMateria)
        {
            List<ProfesorEntidad> listaProfesor = new List<ProfesorEntidad>();
            string consulta = @"SELECT p.nombreProfesor, p.apellidoProfesor, p.idProfesor FROM Profesor p 
                                INNER JOIN MateriaXProfesor mxp ON p.idProfesor = mxp.idProfesor 
                                WHERE mxp.idMateria = @id AND p.baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", idMateria);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ProfesorEntidad prof = new ProfesorEntidad();
                prof.idProfesor = int.Parse(dr["idProfesor"].ToString());
                prof.nombreProfesor = dr["nombreProfesor"].ToString();
                prof.apellidoProfesor = dr["apellidoProfesor"].ToString();
                listaProfesor.Add(prof);
            }
            dr.Close();
            cmd.Connection.Close();
            return listaProfesor;
        } 
    }
}
