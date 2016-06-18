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
    public class CategoriaDao: Conexion
    {
        public static void RegistrarCategoria(CategoriaEntidad categoria)
        {            
            //Se inserta una carrera
            string query = "INSERT INTO Categoria(nombre) VALUES (@categoria)";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"categoria", categoria.nombreCategoria);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public static List<CategoriaEntidad> ConsultarCategoria()
        {
            List<CategoriaEntidad> listaCategoria = new List<CategoriaEntidad>();
            string query = "SELECT idCategoria, nombreCategoria FROM Categoria Where baja=0";
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
    }
    }


