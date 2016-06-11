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
            string query = "INSERT INTO Materia (nombre, ano, descripcion) VALUES (@nombre, @ano, @descripcion)";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());

            cmd.Parameters.AddWithValue(@"nombre", materia.nombreMateria);
            cmd.Parameters.AddWithValue(@"ano",materia.nivelCursado);
            cmd.Parameters.AddWithValue(@"descripcion",materia.descripcion);

            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


    }
}
