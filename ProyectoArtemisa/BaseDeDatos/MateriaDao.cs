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
        public static void registrarMateria(MateriaEntidad materia)
        {
            string query = "INSERT INTO Materia (nombre, nivelCursado, descripcion) VALUES (@nombre, @nivelCursado, @descripcion)";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());

            cmd.Parameters.AddWithValue(@"nombre", materia.nombreMateria);
            cmd.Parameters.AddWithValue(@"nivelCursado",materia.nivelCursado);
            cmd.Parameters.AddWithValue(@"descripcion",materia.descripcion);

            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public MateriaEntidad ConsultarMateriaXNombre(string nombreMateria)
        {
            string query = @"SELECT idMateria FROM Materia WHERE nombreMateria = @nom";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());

            cmd.Parameters.AddWithValue(@"nom", nombreMateria);

            SqlDataReader dr = cmd.ExecuteReader();

            MateriaEntidad mat = new MateriaEntidad();
            while(dr.Read())
            {                
                mat.idMateria = int.Parse(dr["idMateria"].ToString());
                mat.nombreMateria = dr["nombreMateria"].ToString();
                mat.nivelCursado = int.Parse(dr["nivelCursado"].ToString());
                mat.descripcion = dr["descripcion"].ToString();
            }

            return mat;
        }

    }
}
