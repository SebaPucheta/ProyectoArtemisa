using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace BaseDeDatos
{
    public class MateriaDao : Conexion
    {
        /// <summary>
        /// Registrar: una materia
        /// </summary>
        /// <param name="materia"></param>
        public static void RegistrarMateria(MateriaEntidad materia)
        {



            string query = "INSERT INTO Materia (nombreMateria, nivelCursado, descripcionMateria, baja) VALUES (@nombre, @nivelCursado, @descripcion, 0); SELECT SCOPE_IDENTITY();";
            SqlConnection cnn = obtenerBD();
            SqlTransaction trans = cnn.BeginTransaction();
            SqlCommand cmd = new SqlCommand(query, cnn, trans);
            try { 
                    cmd.Parameters.AddWithValue(@"nombre", materia.nombreMateria);
                    cmd.Parameters.AddWithValue(@"nivelCursado", materia.nivelCursado);
                    cmd.Parameters.AddWithValue(@"descripcion", materia.descripcionMateria);
                    materia.idMateria = Convert.ToInt32(cmd.ExecuteScalar());
                    

                    foreach (CarreraEntidad carrera in materia.listaCarreras)
                    {
                        string query2 = "INSERT INTO CarreraXMateria (idCarrera, idMateria) VALUES (@idCarrera, @idMateria)";
                        SqlCommand cmd2 = new SqlCommand(query2, cnn, trans);
                        cmd2.Parameters.AddWithValue("@idCarrera", carrera.idCarrera);
                        cmd2.Parameters.AddWithValue("@idMateria", materia.idMateria);
                        cmd2.ExecuteNonQuery();
                        
                    }
                }
            catch (Exception e)
            {
                trans.Rollback();
            }
            trans.Commit();
            cnn.Close();
        }


        /// <summary>
        /// Eliminar: una materia con un id determinado
        /// </summary>
        /// <param name="id"></param>
        public static void EliminarMateria(int id)
        {
            string consulta = @"UPDATE Materia SET baja = 1 WHERE idMateria = @id";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        /// <summary>
        /// Modificar: una materia determinada identificada por su ID
        /// </summary>
        /// <param name="id"></param>
        public static void ModificarMateria(MateriaEntidad materia)
        {
            string consulta = @"UPDATE Materia SET nombreMateria = @nom, nivelCursado = @nivel, 
                                                    descripcionMateria = @descripcion WHERE idMateria = @id";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"nom", materia.nombreMateria);
            cmd.Parameters.AddWithValue(@"nivelCursado", materia.nivelCursado);
            cmd.Parameters.AddWithValue(@"descripcion", materia.descripcionMateria);
            cmd.Parameters.AddWithValue(@"id", materia.idMateria);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        /// <summary>
        /// Consultar: una materia por el nombre
        /// </summary>
        /// <param name="nombreMateria"></param>
        /// <returns></returns>
        public static MateriaEntidad ConsultarMateriaXNombre(string nombreMateria)
        {
            string query = @"SELECT idMateria, nombreMateria, descripcionMateria, nivelCursado FROM Materia WHERE nombreMateria = @nom";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"nom", nombreMateria);
            SqlDataReader dr = cmd.ExecuteReader();
            MateriaEntidad mat = new MateriaEntidad();
            while (dr.Read())
            {
                mat.idMateria = int.Parse(dr["idMateria"].ToString());
                mat.nombreMateria = dr["nombreMateria"].ToString();
                mat.nivelCursado = int.Parse(dr["nivelCursado"].ToString());
                mat.descripcionMateria = dr["descripcionMateria"].ToString();
            }
            dr.Close();
            cmd.Connection.Close();
            return mat;
        }


        /// <summary>
        /// Consultar: una materia por in ID determinado
        /// </summary>
        /// <param name="nombreMateria"></param>
        /// <returns></returns>
        public static MateriaEntidad ConsultarMateria(int id)
        {
            string query = @"SELECT idMateria, nombreMateria, descripcionMateria, nivelCursado FROM Materia WHERE idMateria = @id";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            MateriaEntidad mat = new MateriaEntidad();
            while (dr.Read())
            {
                mat.idMateria = int.Parse(dr["idMateria"].ToString());
                mat.nombreMateria = dr["nombreMateria"].ToString();
                mat.nivelCursado = int.Parse(dr["nivelCursado"].ToString());
                mat.descripcionMateria = dr["descripcionMateria"].ToString();
            }
            dr.Close();
            cmd.Connection.Close();
            return mat;
        }


        /// <summary>
        /// Consutar: todas las materias
        /// </summary>
        /// <returns></returns>
        public static List<MateriaEntidad> ConsultarMateria()
        {
            string query = @"SELECT idMateria, nombreMateria, nivelCursado, descripcionMateria FROM Materia WHERE baja = 0";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            SqlDataReader dr = cmd.ExecuteReader();
            List<MateriaEntidad> lista = new List<MateriaEntidad>();
            while (dr.Read())
            {
                MateriaEntidad mat = new MateriaEntidad();
                mat.idMateria = int.Parse(dr["idMateria"].ToString());
                mat.nombreMateria = dr["nombreMateria"].ToString();
                mat.nivelCursado = int.Parse(dr["nivelCursado"].ToString());
                mat.descripcionMateria = dr["descripcionMateria"].ToString();
                lista.Add(mat);
            }
            dr.Close();
            cmd.Connection.Close();
            return lista;
        }
        

        /// <summary>
        /// Consultar: todas las materias de una facultad
        /// </summary>
        /// <param name="idFacultad"></param>
        /// <returns></returns>
        public static List<MateriaEntidad> DevolverMateriaXFacultad(int idFacultad)
        {
            List<MateriaEntidad> listaMateria = new List<MateriaEntidad>();
            string query = @"SELECT M.idMateria, M.nivelCursado, M.nombreMateria, M.descripcionMateria  
                             FROM Materia M JOIN CarreraXMateria CM ON M.idMateria=CM.idMateria 
					                        JOIN Carrera C ON C.idCarrera=CM.idCarrera
					                        WHERE C.idFacultad = @idFacultad 
					                        AND M.baja= 0";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"idFacultad", idFacultad);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                MateriaEntidad mat = new MateriaEntidad();
                mat.idMateria = int.Parse(dr["idMateria"].ToString());
                mat.nombreMateria = dr["nombreMateria"].ToString();
                mat.nivelCursado = int.Parse(dr["nivelCursado"].ToString());
                mat.descripcionMateria = dr["descripcionMateria"].ToString();
                listaMateria.Add(mat);
            }
            dr.Close();
            cmd.Connection.Close();
            return listaMateria;
        }



        /// <summary>
        /// Consultar: todas las materias de un profesor
        /// </summary>
        /// <param name="idFacultad"></param>
        /// <returns></returns>
        public static List<MateriaEntidad> DevolverMateriaXProfesor(int idProfesor)
        {
            List<MateriaEntidad> listaMateria = new List<MateriaEntidad>();
            string query = @"SELECT M.idMateria, M.nivelCursado, M.nombreMateria, M.descripcionMateria  
                             FROM Materia M JOIN MateriaXProfesor mp ON M.idMateria = mp.idMateria 
					                        WHERE mp.idProfesor = @idProfesor 
					                        AND M.baja= 0";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"idProfesor", idProfesor);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                MateriaEntidad mat = new MateriaEntidad();
                mat.idMateria = int.Parse(dr["idMateria"].ToString());
                mat.nombreMateria = dr["nombreMateria"].ToString();
                mat.nivelCursado = int.Parse(dr["nivelCursado"].ToString());
                mat.descripcionMateria = dr["descripcionMateria"].ToString();
                listaMateria.Add(mat);
            }
            dr.Close();
            cmd.Connection.Close();
            return listaMateria;
        }



    }
}
