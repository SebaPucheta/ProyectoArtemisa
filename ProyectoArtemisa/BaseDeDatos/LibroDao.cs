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
    public class LibroDao : Conexion
    {
        //Caso de uso 2 Registrar Libro
        public static void registrarLibro(LibroEntidad libro)
        {
            string query = "INSERT INTO Libro (nombre, autor, descripcion, stock, cantidadHojas, precioLibro, idEditorial, idEstado) VALUES (@nombre, @autor, @descripcion, @stock, @cantidadHojas, @precioLibro, @idEditorial, @idEstado)";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());

            cmd.Parameters.AddWithValue(@"nombre",libro.nombre);
            cmd.Parameters.AddWithValue(@"autor",libro.autor);
            cmd.Parameters.AddWithValue(@"descripcion",libro.descripcion);
            cmd.Parameters.AddWithValue(@"stock",libro.stock);
            cmd.Parameters.AddWithValue(@"cantidadHojas",libro.cantidadHojas);
            cmd.Parameters.AddWithValue(@"precioLibro",libro.precioLibro);
            cmd.Parameters.AddWithValue(@"idEditorial",libro.idEditorial);
            cmd.Parameters.AddWithValue(@"idEstado",libro.idEstado);

            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
    }
}
