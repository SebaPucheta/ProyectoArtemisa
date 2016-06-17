using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace BaseDeDatos
{
    public class ApunteDao : Conexion
    {
        //stock
        //precio
        //cantHoja
        //nombre
        //descripcion
        //ano
        //codigoBarraApunte
        //idPrecioHoja
        //idCategoria
        //idTipoApunte
        //idEditorial
        //idEstado
        //idProfesor

        /// <summary>
        /// Registra un nuevo apunte en la base de datos
        /// </summary>
        /// <param name="nuevoApunte"></param>
        public static void RegistrarApunte(ApunteEntidad nuevoApunte)
        {
            string query = @"INSERT INTO Apunte (stock, precio, cantHoja, nombre, descripcion, ano, codigoBarraApunte
                                                 idPrecioHoja, idCategoria, idTipoApunte, idEditorial, idEstado, idProfesor) 
                            VALUES (@stock, @precio, @cantHoja, @nombre, @descripcion, @ano, @codigoBarraApunte
                                    @idPrecioHoja, @idCategoria, @idTipoApunte, @idEditorial, @idEstado, @idProfesor)";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());

            cmd.Parameters.AddWithValue(@"stock", nuevoApunte.stock);
            cmd.Parameters.AddWithValue(@"precio", nuevoApunte.precio);
            cmd.Parameters.AddWithValue(@"cantHoja", nuevoApunte.cantHoja);
            cmd.Parameters.AddWithValue(@"nombre", nuevoApunte.nombre);
            cmd.Parameters.AddWithValue(@"descripcion", nuevoApunte.descripcion);
            cmd.Parameters.AddWithValue(@"ano", nuevoApunte.ano);
            cmd.Parameters.AddWithValue(@"codigoBarraApunte", nuevoApunte.codigoBarraApunte);
            cmd.Parameters.AddWithValue(@"idPrecioHoja", nuevoApunte.idPrecioHoja);
            cmd.Parameters.AddWithValue(@"idCategoria", nuevoApunte.idCategoria);
            cmd.Parameters.AddWithValue(@"idTipoApunte", nuevoApunte.idTipoApunte);
            cmd.Parameters.AddWithValue(@"idEditorial", nuevoApunte.idEditorial);
            cmd.Parameters.AddWithValue(@"idEstado", nuevoApunte.idEstado);
            cmd.Parameters.AddWithValue(@"idProfesor", nuevoApunte.idProfesor);

            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

        }

        public static List<ApunteEntidadQuery> ConsultarTodosLosApuntes()
        {
            List<ApunteEntidadQuery> lista = new List<ApunteEntidadQuery>();

            string query = @"SELECT a.idApunte, a.stock, a.precio, a.cantHoja, a.nombre, a.descripcion, a.ano, a.codigoBarraApunte,
                                    pr.precio, c.nombreCategoria, tp.nombreTipoApunte, e.nombreEditorial, es.nombreEstado, p.nombreProfesor, p.apellido
                             FROM Apuntes a JOIN PrecioHoja pr ON a.idPrecioHoja = pr.idPrecioHoja
                                            JOIN Categoria c ON a.idCategoria = c.idCategoria
                                            JOIN TipoApunte tp ON a.idTipoApunte = tp.idTipoApunte
                                            JOIN Editorial e ON a.idEditorial = e.idEditorial
                                            JOIN Estado es ON a.idEstado = es.idEstado
                                            JOIN Profesor p ON a.idProfesor = p.idProfesor";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ApunteEntidadQuery apu = new ApunteEntidadQuery();
                
            }
            dr.Close();
            cmd.Connection.Close();

            return lista;

        }
        public static List<ApunteEntidadQuery> ConsultarTodosLosApuntes()
        {

        }

        public static bool VerificarCodigoBarra(string codigoBarra)
        {
            string query = @"SELECT Count(codigoBarra) FROM Apunte WHERE codigoBarra = @codBarra";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());

            cmd.Parameters.AddWithValue(@"codBarra", codigoBarra);

            if (int.Parse(cmd.ExecuteScalar().ToString()) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
