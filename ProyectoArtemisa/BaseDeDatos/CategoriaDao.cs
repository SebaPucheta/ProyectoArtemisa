using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using Entidades;

namespace BaseDeDatos
{
    public class CategoriaDao : Conexion
    {
        /// <summary>
        /// Registrar: una categoria
        /// </summary>
        /// <param name="categoria"></param>
        public static void RegistrarCategoria(CategoriaEntidad categoria)
        {
            string query = "INSERT INTO Categoria(nombreCategoria, baja) VALUES (@nombreCategoria, 0)";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"nombreCategoria", categoria.nombreCategoria);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        /// <summary>
        /// Eliminar: una categoria con un id determinado
        /// </summary>
        /// <param name="id"></param>
        public static void EliminarCategoria(int id)
        {
            string consulta = @"UPDATE Categoria SET baja = 1 WHERE idCategoria = @id";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        /// <summary>
        /// Modificar: una categoria determinada identificada por su ID
        /// </summary>
        /// <param name="id"></param>
        public static void ModificarCategoria(CategoriaEntidad cat)
        {
            string consulta = @"UPDATE Categoria SET nombreCategoria = @nom WHERE idCategoria = @id";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"nom", cat.nombreCategoria);
            cmd.Parameters.AddWithValue(@"id", cat.idCategoria);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        
        /// <summary>
        ///  Consultar: todas las categorias
        /// </summary>
        /// <returns></returns>
        public static List<CategoriaEntidad> ConsultarCategoria()
        {
            List<CategoriaEntidad> listaCategoria = new List<CategoriaEntidad>();
            string query = "SELECT idCategoria, nombreCategoria FROM Categoria WHERE baja = 0";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CategoriaEntidad categoria = new CategoriaEntidad();
                categoria.idCategoria = int.Parse(dr["idCategoria"].ToString());
                categoria.nombreCategoria = dr["nombreCategoria"].ToString();
                listaCategoria.Add(categoria);
            }
            dr.Close();
            cmd.Connection.Close();
            return listaCategoria;
        }


        /// <summary>
        /// Consultar: una sola categoria determinada por un ID
        /// </summary>
        /// <param name="idCategoria"></param>
        /// <returns></returns>
        public static CategoriaEntidad ConsultarUnaCategoria(int idCategoria)
        {
            CategoriaEntidad categoria = new CategoriaEntidad();
            string consulta = "SELECT idCategoria, nombreCategoria FROM Categoria WHERE idCategoria = @id";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", idCategoria);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                categoria.idCategoria = int.Parse(dr["idCategoria"].ToString());
                categoria.nombreCategoria = dr["nombreCategoria"].ToString();
            }
            dr.Close();
            cmd.Connection.Close();
            return categoria;
        }
    }
}


