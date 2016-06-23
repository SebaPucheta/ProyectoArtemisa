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

        /// <summary>
        /// Registrar: un libro
        /// </summary>
        /// <param name="libro"></param>
        public static void RegistrarLibro(LibroEntidad libro)
        {
            string query = @"INSERT INTO Libro (nombreLibro, autorLibro, descripcionLibro, stock, cantidadHojasLibro,
                                                precioLibro, idEditorial, idEstado, codigoBarraLibro, baja) VALUES
                                                (@nombre, @autor, @descripcion, 0, @cantidadHojas,
                                                 @precioLibro, @idEditorial, @idEstado, @codigoBarra, 0)";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"nombre", libro.nombreLibro);
            cmd.Parameters.AddWithValue(@"autor", libro.autorLibro);
            cmd.Parameters.AddWithValue(@"descripcion", libro.descripcionLibro);
            cmd.Parameters.AddWithValue(@"stock", libro.stock);
            cmd.Parameters.AddWithValue(@"cantidadHojas", libro.cantidadHojasLibro);
            cmd.Parameters.AddWithValue(@"precioLibro", libro.precioLibro);
            cmd.Parameters.AddWithValue(@"idEditorial", libro.idEditorial);
            if(libro.idEstado == null)
            {
                cmd.Parameters.AddWithValue(@"idEstado", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue(@"idEstado", libro.idEstado);
            }
            cmd.Parameters.AddWithValue(@"codigobarra", libro.codigoBarraLibro);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        /// <summary>
        /// Eliminar: un libro con un id determinado
        /// </summary>
        /// <param name="id"></param>
        public static void EliminarLibro(int id)
        {
            string consulta = @"UPDATE Libro SET baja = 1 WHERE idLibro = @id";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        /// <summary>
        /// Modificar: una carrera determinada identificada por su ID
        /// </summary>
        /// <param name="id"></param>
        public static void ModificarLibro(LibroEntidad libro)
        {
            string consulta = @"UPDATE Libro SET nombreLibro = @nombre, descripcionLibro = @descripcion, codigoBarraLibro = @codigoBarra,
                                                 autorLibro = @autor, stock = @stock,
                                                 cantidadHojasLibro = @cantidadHojas, precioLibro = @precio, idEditorial = @idEditorial,
                                                 idEstado = @idEstado WHERE idLibro = @idLibro";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"nombre", libro.nombreLibro);
            cmd.Parameters.AddWithValue(@"autor", libro.autorLibro);
            cmd.Parameters.AddWithValue(@"codigoBarra", libro.codigoBarraLibro);
            cmd.Parameters.AddWithValue(@"descripcion", libro.autorLibro);
            cmd.Parameters.AddWithValue(@"stock", libro.descripcionLibro);
            cmd.Parameters.AddWithValue(@"cantidadHojas", libro.stock);
            cmd.Parameters.AddWithValue(@"precio", libro.cantidadHojasLibro);
            cmd.Parameters.AddWithValue(@"idEditorial", libro.precioLibro);
            cmd.Parameters.AddWithValue(@"idEstado", libro.idEditorial);
            cmd.Parameters.AddWithValue(@"idLibro", libro.idEstado);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        /// <summary>
        /// Consultar: todos los libros
        /// </summary>
        /// <returns></returns>
        public static List<LibroEntidad> ConsultarLibros()
        {
            List<LibroEntidad> lista = new List<LibroEntidad>();
            string consulta = @"SELECT idLibro, codigoBarraLibro, nombreLibro, autorLibro, descripcionLibro, stock,
                                cantidadHojasLibro, precioLibro, idEditorial, idEstado FROM Libro WHERE baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LibroEntidad libro = new LibroEntidad();
                libro.idLibro = int.Parse(dr["idLibro"].ToString());
                libro.codigoBarraLibro = dr["codigoBarraLibro"].ToString();
                libro.nombreLibro = dr["nombreLibro"].ToString();
                libro.autorLibro = dr["autorLibro"].ToString();
                libro.descripcionLibro = dr["descripcionLibro"].ToString();
                libro.stock = int.Parse(dr["stock"].ToString());
                libro.cantidadHojasLibro = int.Parse(dr["cantidadHojasLibro"].ToString());
                libro.precioLibro = float.Parse(dr["precioLibro"].ToString());
                libro.idEditorial = int.Parse(dr["idEditorial"].ToString());
                libro.idEstado = int.Parse(dr["idEstado"].ToString());
                lista.Add(libro);
            }
            dr.Close();
            cmd.Connection.Close();
            return lista;
        }


        /// <summary>
        /// Consultar: todos los libros para mostrar en grilla (con todos los nombres)
        /// </summary>
        /// <returns></returns>
        public static List<LibroEntidadQuery> ConsultarLibrosQuery()
        {
            List<LibroEntidadQuery> lista = new List<LibroEntidadQuery>();
            string consulta = @"SELECT l.idLibro, l.codigoBarraLibro, l.nombreLibro, l.autorLibro, l.descripcionLibro, l.stock,
                                l.cantidadHojasLibro, l.precioLibro, e.nombreEditorial, es.nombreEstado
                                FROM Libro l INNER JOIN Editorial e ON l.idEditorial = e.idEditorial
			                                 INNER JOIN Estado es ON l.idEstado = es.idEstado
			                    WHERE l.baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LibroEntidadQuery libro = new LibroEntidadQuery();
                libro.idLibro = int.Parse(dr["idLibro"].ToString());
                libro.codigoBarraLibro = dr["codigoBarraLibro"].ToString();
                libro.nombreLibro = dr["nombreLibro"].ToString();
                libro.autorLibro = dr["autorLibro"].ToString();
                libro.descripcionLibro = dr["descripcionLibro"].ToString();
                libro.stock = int.Parse(dr["stock"].ToString());
                libro.cantidadHojasLibro = int.Parse(dr["cantidadHojasLibro"].ToString());
                libro.precioLibro = float.Parse(dr["precioLibro"].ToString());
                libro.nombreEditorial = dr["nombreEditorial"].ToString();
                libro.nombreEstado = dr["nombreEstado"].ToString();
                lista.Add(libro);
            }
            dr.Close();
            cmd.Connection.Close();
            return lista;
        }


        /// <summary>
        /// Consultar: un solo libro dada una ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static LibroEntidad ConsultarLibro(int id)
        {
            LibroEntidad libro = new LibroEntidad();
            string consulta = @"SELECT idLibro, codigoBarraLibro, nombreLibro, autorLibro, descripcionLibro, stock,
                                cantidadHojasLibro, precioLibro, idEditorial, idEstado FROM Libro WHERE idLibro = @id";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                libro.idLibro = int.Parse(dr["idLibro"].ToString());
                libro.codigoBarraLibro = dr["codigoBarraLibro"].ToString();
                libro.nombreLibro = dr["nombreLibro"].ToString();
                libro.autorLibro = dr["autorLibro"].ToString();
                libro.descripcionLibro = dr["descripcionLibro"].ToString();
                libro.stock = int.Parse(dr["stock"].ToString());
                libro.cantidadHojasLibro = int.Parse(dr["cantidadHojasLibro"].ToString());
                libro.precioLibro = float.Parse(dr["precioLibro"].ToString());
                libro.idEditorial = int.Parse(dr["idEditorial"].ToString());
                libro.idEstado = int.Parse(dr["idEstado"].ToString());
            }
            dr.Close();
            cmd.Connection.Close();
            return libro;
        }

        /// <summary>
        /// Verifica que el codigo de barra recibido por parametro no este en
        /// la base de datos
        /// </summary>
        /// <param name="codigoBarra"></param>
        /// <returns>bool</returns>
        public static bool VerificarCodigoBarra(string codigoBarra)
        {
            string query = @"SELECT Count(codigoBarraLibro) FROM Libro WHERE codigoBarraLibro = @codBarra";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"codBarra", codigoBarra);
            if (int.Parse(cmd.ExecuteScalar().ToString()) == 0)
            {
                cmd.Connection.Close();
                return true;
            }
            else
            {
                cmd.Connection.Close();
                return false;
            }
        }
    }
}
