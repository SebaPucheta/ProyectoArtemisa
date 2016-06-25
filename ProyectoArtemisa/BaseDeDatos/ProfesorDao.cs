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
        /// Registrar: un profesor recibiendo un objeto profesor
        /// </summary>
        public static void RegistrarProfesor(ProfesorEntidad prof)
        {
            SqlConnection cn = obtenerBD();
            SqlTransaction trans = cn.BeginTransaction();
            try 
            { 
                string consulta = @"INSERT INTO Profesor (nombreProfesor, apellidoProfesor, baja) VALUES (@nom, @ape, 0); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(consulta, cn, trans);
                cmd.Parameters.AddWithValue(@"nom", prof.nombreProfesor);
                cmd.Parameters.AddWithValue(@"ape", prof.apellidoProfesor);
                prof.idProfesor= Convert.ToInt32(cmd.ExecuteScalar());

                consulta = @"INSERT INTO MateriaXProfesor (idMateria, idProfesor) VALUES (@idMateria, @idProfesor)";
                cmd = new SqlCommand(consulta, cn, trans);
                cmd.Parameters.AddWithValue("@idMateria", prof.idMateria);
                cmd.Parameters.AddWithValue("@idProfesor", prof.idProfesor);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                trans.Rollback();
                cn.Close();
            }
            trans.Commit();
            cn.Close();
        }


        /// <summary>
        /// Eliminar: un profesor con un id determinado
        /// </summary>
        /// <param name="id"></param>
        public static void EliminarProfesor(int id)
        {
            string consulta = @"UPDATE Profesor SET baja = 1 WHERE idMateria = @id";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        /// <summary>
        /// Modifica un profesor recibiendo un objeto profesor
        /// </summary>
        public static void ModificarProfesor(ProfesorEntidad prof)
        {
            string consulta = @"UPDATE Profesor SET nombreProfesor = @nom, apellidoProfesor = @ape WHERE idProfesor = @id";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"nom", prof.nombreProfesor);
            cmd.Parameters.AddWithValue(@"ape", prof.apellidoProfesor);
            cmd.Parameters.AddWithValue(@"id", prof.idProfesor);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        /// <summary>
        /// Consultar: todos los profesores registrado en la base de datos
        /// </summary>
        /// <returns>Lista de objetos profesor</returns>
        public static List<ProfesorEntidad> ConsultarProfesor()
        {
            List<ProfesorEntidad> lista = new List<ProfesorEntidad>();
            string consulta = @"SELECT idProfesor, nombreProfesor, apellidoProfesor FROM Profesor WHERE baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ProfesorEntidad prof = new ProfesorEntidad();
                prof.idProfesor = int.Parse(dr["idProfesor"].ToString());
                prof.nombreProfesor = dr["nombreProfesor"].ToString();
                prof.apellidoProfesor = dr["apellidoProfesor"].ToString();
                lista.Add(prof);
            }
            dr.Close();
            cmd.Connection.Close();
            return lista;
        }


       
        /// <summary>
        /// Consultar: todos los profesores de una materia
        /// </summary>
        /// <param name="idMateria"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Consultar: un solo profesor con un ID determinado
        /// </summary>
        /// <returns></returns>
        public static ProfesorEntidad ConsultarUnProfesor(int id)
        {
            ProfesorEntidad prof = new ProfesorEntidad();
            string consulta = @"SELECT idProfesor, nombreProfesor, apellidoProfesor FROM Profesor WHERE idProfesor = @id AND baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                prof.idProfesor = int.Parse(dr["idProfesor"].ToString());
                prof.nombreProfesor = dr["nombreProfesor"].ToString();
                prof.apellidoProfesor = dr["apellidoProfesor"].ToString();
            }
            dr.Close();
            cmd.Connection.Close();
            return prof;
        }


    }
}
