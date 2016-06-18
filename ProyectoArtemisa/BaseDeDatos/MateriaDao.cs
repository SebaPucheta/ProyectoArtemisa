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
        /// Registra en la base de datos una materia
        /// </summary>
        /// <param name="materia"></param>
        public static void RegistrarMateria(MateriaEntidad materia)
        {
            string query = "INSERT INTO Materia (nombre, nivelCursado, descripcion) VALUES (@nombre, @nivelCursado, @descripcion)";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());

            cmd.Parameters.AddWithValue(@"nombre", materia.nombreMateria);
            cmd.Parameters.AddWithValue(@"nivelCursado", materia.nivelCursado);
            cmd.Parameters.AddWithValue(@"descripcion", materia.descripcion);

            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public static MateriaEntidad ConsultarMateriaXNombre(string nombreMateria)
        {
            string query = @"SELECT idMateria FROM Materia WHERE nombreMateria = @nom";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());

            cmd.Parameters.AddWithValue(@"nom", nombreMateria);

            SqlDataReader dr = cmd.ExecuteReader();

            MateriaEntidad mat = new MateriaEntidad();
            while (dr.Read())
            {
                mat.idMateria = int.Parse(dr["idMateria"].ToString());
                mat.nombreMateria = dr["nombreMateria"].ToString();
                mat.nivelCursado = int.Parse(dr["nivelCursado"].ToString());
                mat.descripcion = dr["descripcion"].ToString();
            }
            cmd.Connection.Close();
            return mat;
        }

        public static List<MateriaEntidad> ConsultarMateria()
        {
            string query = @"SELECT idMateria, nombreMateria, nivelCursado, descripcion FROM Materia WHERE baja=0";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            SqlDataReader dr = cmd.ExecuteReader();

            List<MateriaEntidad> listaMateria = new List<MateriaEntidad>();
            
            while (dr.Read())
            {
                MateriaEntidad mat = new MateriaEntidad();
                mat.idMateria = int.Parse(dr["idMateria"].ToString());
                mat.nombreMateria = dr["nombreMateria"].ToString();
                mat.nivelCursado = int.Parse(dr["nivelCursado"].ToString());
                mat.descripcion = dr["descripcion"].ToString();
                listaMateria.Add(mat);
            }
            cmd.Connection.Close();
            return listaMateria;
        }

        public static List<MateriaEntidad> DevolverMateriaXFacultad(int idFacultad)
        {
            string query = @"select M.idMateria, M.nivelCursado,	M.nombreMateria, M.descripcionMateria  
                             From Materia M join CarreraXMateria CM on M.idMateria=CM.idMateria 
					                        join Carrera C on C.idCarrera=CM.idCarrera
					                        Where C.idFacultad= @idFacultad 
					                        and M.baja= 0";

            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            SqlDataReader dr = cmd.ExecuteReader();

            List<MateriaEntidad> listaMateria = new List<MateriaEntidad>();

            while (dr.Read())
            {
                MateriaEntidad mat = new MateriaEntidad();
                mat.idMateria = int.Parse(dr["idMateria"].ToString());
                mat.nombreMateria = dr["nombreMateria"].ToString();
                mat.nivelCursado = int.Parse(dr["nivelCursado"].ToString());
                mat.descripcion = dr["descripcion"].ToString();
                listaMateria.Add(mat);
            }
            cmd.Connection.Close();
            return listaMateria;
        }

    }
}
