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

        /// <summary>
        /// Registrar: un nuevo apunte en la base de datos
        /// </summary>
        /// <param name="nuevoApunte"></param>
        public static void RegistrarApunte(ApunteEntidad nuevoApunte)
        {
            string query = @"INSERT INTO Apunte (stock, precioApunte, cantHoja, nombreApunte, descripcionApunte, anoApunte,
                                                codigoBarraApunte, idPrecioHoja, idCategoria, idTipoApunte, idEditorial, idEstado, 
                                                idProfesor, idMateria, baja) 
                            VALUES (@stock, @precio, @cantHoja, @nombre, @descripcion, @ano, @codigoBarraApunte
                                    @idPrecioHoja, @idCategoria, @idTipoApunte, @idEditorial, @idEstado, @idProfesor, @idMateria, 0)";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());

            cmd.Parameters.AddWithValue(@"stock", nuevoApunte.stock);
            cmd.Parameters.AddWithValue(@"precioApunte", nuevoApunte.precioApunte);
            cmd.Parameters.AddWithValue(@"cantHoja", nuevoApunte.cantHoja);
            cmd.Parameters.AddWithValue(@"nombreApunte", nuevoApunte.nombreApunte);
            cmd.Parameters.AddWithValue(@"descripcionApunte", nuevoApunte.descripcionApunte);
            cmd.Parameters.AddWithValue(@"anoApunte", nuevoApunte.anoApunte);
            cmd.Parameters.AddWithValue(@"codigoBarraApunte", nuevoApunte.codigoBarraApunte);
            cmd.Parameters.AddWithValue(@"idPrecioHoja", nuevoApunte.idPrecioHoja);
            cmd.Parameters.AddWithValue(@"idCategoria", nuevoApunte.idCategoria);
            cmd.Parameters.AddWithValue(@"idTipoApunte", nuevoApunte.idTipoApunte);
            cmd.Parameters.AddWithValue(@"idEditorial", nuevoApunte.idEditorial);
            cmd.Parameters.AddWithValue(@"idEstado", nuevoApunte.idEstado);
            cmd.Parameters.AddWithValue(@"idProfesor", nuevoApunte.idProfesor);
            cmd.Parameters.AddWithValue(@"idMateria", nuevoApunte.idMateria);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        /// <summary>
        /// Eliminar: un apunte con un id determinado
        /// </summary>
        /// <param name="id"></param>
        public static void EliminarApunte(int id)
        {
            string consulta = @"UPDATE Apunte SET baja = 1 WHERE idApunte = @idApunte";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"idApunte", id);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        /// <summary>
        /// Modificar: un apunte determinado identificado por su ID
        /// </summary>
        /// <param name="id"></param>
        public static void ModificarApunte(ApunteEntidad apu)
        {
            string consulta = @"UPDATE Apunte SET stock = @stock, precioApunte = @precioApunte, cantHoja = @cantHoja, nombreApunte = @nombreApunte,
                                                  descripcionApunte = @descripcionApunte, anoApunte = @anoApunte, codigoBarraApunte = @codigoBarraApunte,
                                                  idPrecioHoja = @idPrecioHoja, idCategoria = @idCategoria, idTipoApunte = @idTipoApunte,
                                                  idEditorial = @idEditorial, idEstado = @idEstado, idProfesor = @idProfesor, idMateria = @idMateria
                                              WHERE idApunte = @idApunte";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"idApunte", apu.idApunte);
            cmd.Parameters.AddWithValue(@"stock", apu.stock);
            cmd.Parameters.AddWithValue(@"precioApunte", apu.precioApunte);
            cmd.Parameters.AddWithValue(@"cantHoja", apu.cantHoja);
            cmd.Parameters.AddWithValue(@"nombreApunte", apu.nombreApunte);
            cmd.Parameters.AddWithValue(@"descripcionApunte", apu.descripcionApunte);
            cmd.Parameters.AddWithValue(@"anoApunte", apu.anoApunte);
            cmd.Parameters.AddWithValue(@"codigoBarraApunte", apu.codigoBarraApunte);
            cmd.Parameters.AddWithValue(@"idPrecioHoja", apu.idPrecioHoja);
            cmd.Parameters.AddWithValue(@"idCategoria", apu.idCategoria);
            cmd.Parameters.AddWithValue(@"idTipoApunte", apu.idTipoApunte);
            cmd.Parameters.AddWithValue(@"idEditorial", apu.idEditorial);
            cmd.Parameters.AddWithValue(@"idEstado", apu.idEstado);
            cmd.Parameters.AddWithValue(@"idProfesor", apu.idProfesor);
            cmd.Parameters.AddWithValue(@"idMateria", apu.idMateria);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        /// <summary>
        /// Consultar: todos los apuntes en forma de query (sin especificar las ID)
        /// </summary>
        /// <returns></returns>
        public static List<ApunteEntidadQuery> ConsultarTodosLosApuntes()
        {
            List<ApunteEntidadQuery> lista = new List<ApunteEntidadQuery>();
            string query = @"SELECT a.idApunte, a.stock, a.precioApunte, a.cantHoja, a.nombreApunte, a.descripcionApunte, a.anoApunte, a.codigoBarraApunte,
                                    pr.precioHoja, c.nombreCategoria, tp.nombreTipoApunte, e.nombreEditorial, es.nombreEstado, p.nombreProfesor, p.apellidoProfesor
                             FROM Apunte a JOIN PrecioXHoja pr ON a.idPrecioHoja = pr.idPrecioHoja
                                            JOIN Categoria c ON a.idCategoria = c.idCategoria
                                            JOIN TipoApunte tp ON a.idTipoApunte = tp.idTipoApunte
                                            JOIN Editorial e ON a.idEditorial = e.idEditorial
                                            JOIN Estado es ON a.idEstado = es.idEstado
                                            JOIN Profesor p ON a.idProfesor = p.idProfesor
                              WHERE a.baja = 0";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ApunteEntidadQuery apu = new ApunteEntidadQuery();
                apu.idApunte = int.Parse(dr["idApunte"].ToString());
                apu.stock = int.Parse(dr["stock"].ToString());
                apu.precioApunte = float.Parse(dr["precioApunte"].ToString());
                apu.cantHoja = int.Parse(dr["cantHoja"].ToString());
                apu.nombreApunte = dr["nombreApunte"].ToString();
                apu.descripcionApunte = dr["descripcionApunte"].ToString();
                apu.anoApunte = int.Parse(dr["anoApunte"].ToString());
                apu.codigoBarraApunte = dr["codigoBarraApunte"].ToString();
                apu.precioHoja = float.Parse(dr["precioHoja"].ToString());
                apu.nombreCategoria = dr["nombreCategoria"].ToString();
                apu.nombreTipoApunte = dr["nombreTipoApunte"].ToString();
                apu.nombreEditorial = dr["nombreEditorial"].ToString();
                apu.nombreEstado = dr["nombreEstado"].ToString();
                apu.nombreProfesor = dr["nombreProfesor"].ToString();
                apu.apellidoProfesor = dr["apellidoProfesor"].ToString();
                lista.Add(apu);
            }
            dr.Close();
            cmd.Connection.Close();
            return lista;
        }
        
        /// <summary>
        /// Consultar: codigo de barra para que el apunte no se ingrese con un codigo de barra igual a uno ya registrado
        /// </summary>
        /// <param name="codigoBarra"></param>
        /// <returns></returns>
        public static bool VerificarCodigoBarra(string codigoBarra)
        {
            string query = @"SELECT Count(codigoBarraApunte) FROM Apunte WHERE codigoBarraApunte = @codBarra and idTipoApunte= 1";
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

        /// <summary>
        /// Consultar: un solo apunte de un ID determinado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ApunteEntidad ConsultarApunte(int id)
        {
            ApunteEntidad apu = new ApunteEntidad();
            string consulta = @"SELECT idApunte, stock, precioApunte, cantHoja, nombreApunte, descripcionApunte, anoApunte,
                                                codigoBarraApunte, idPrecioHoja, idCategoria, idTipoApunte, idEditorial, idEstado, 
                                                idProfesor, idMateria
                                FROM Apunte WHERE idApunte = @id";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                apu.idApunte = int.Parse(dr["idApunte"].ToString());
                apu.stock = int.Parse(dr["stock"].ToString());
                apu.precioApunte = float.Parse(dr["precioApunte"].ToString());
                apu.cantHoja = int.Parse(dr["cantHoja"].ToString());
                apu.nombreApunte = dr["nombreApunte"].ToString();
                apu.descripcionApunte = dr["descripcionApunte"].ToString();
                apu.anoApunte = int.Parse(dr["anoApunte"].ToString());
                apu.codigoBarraApunte = dr["codigoBarraApunte"].ToString();
                apu.idPrecioHoja = int.Parse(dr["idPrecioHoja"].ToString());
                apu.idCategoria = int.Parse(dr["idCategoria"].ToString());
                apu.idTipoApunte = int.Parse(dr["idTipoApunte"].ToString());
                apu.idEditorial = int.Parse(dr["idEditorial"].ToString());
                apu.idEstado = int.Parse(dr["idEstado"].ToString());
                apu.idProfesor = int.Parse(dr["idProfesor"].ToString());
            }
            dr.Close();
            cmd.Connection.Close();
            return apu;
        }
    }
}
