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
                                                precioLibro, idEditorial, codigoBarraLibro, idMateria, baja) VALUES
                                                (@nombre, @autor, @descripcion, @stock, @cantidadHojas,
                                                 @precioLibro, @idEditorial, @codigoBarra, @idMateria, 0)";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"nombre", libro.nombreLibro);
            cmd.Parameters.AddWithValue(@"autor", libro.autorLibro);
            if (libro.descripcionLibro == null)
            { cmd.Parameters.AddWithValue(@"descripcion", DBNull.Value); }
            else
            { cmd.Parameters.AddWithValue(@"descripcion", libro.descripcionLibro); }
            cmd.Parameters.AddWithValue(@"stock", libro.stock);
            cmd.Parameters.AddWithValue(@"cantidadHojas", libro.cantidadHojasLibro);
            cmd.Parameters.AddWithValue(@"precioLibro", libro.precioLibro);
            cmd.Parameters.AddWithValue(@"idEditorial", libro.idEditorial);
            cmd.Parameters.AddWithValue(@"idMateria", libro.idMateria);
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
                                                 autorLibro = @autor,  idMateria = @idMateria, stock = @stock, 
                                                 cantidadHojasLibro = @cantidadHojas, precioLibro = @precio, idEditorial = @idEditorial
                                                  WHERE idLibro = @idLibro";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"idLibro", libro.idLibro);
            cmd.Parameters.AddWithValue(@"nombre", libro.nombreLibro);
            cmd.Parameters.AddWithValue(@"autor", libro.autorLibro);
            cmd.Parameters.AddWithValue(@"stock", libro.stock);
            cmd.Parameters.AddWithValue(@"codigoBarra", libro.codigoBarraLibro);
            cmd.Parameters.AddWithValue(@"descripcion", libro.descripcionLibro);
            cmd.Parameters.AddWithValue(@"cantidadHojas", libro.cantidadHojasLibro);
            cmd.Parameters.AddWithValue(@"precio", libro.precioLibro);
            cmd.Parameters.AddWithValue(@"idEditorial", libro.idEditorial);
            //cmd.Parameters.AddWithValue(@"idEstado", libro.idEstado);
            cmd.Parameters.AddWithValue(@"idMateria", libro.idMateria);
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
                                cantidadHojasLibro, precioLibro, idEditorial, idEstado, idMateria FROM Libro WHERE baja = 0";
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
                libro.idMateria = int.Parse(dr["idMateria"].ToString());
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
            string consulta = @"SELECT l.idLibro, l.codigoBarraLibro, l.nombreLibro, l.autorLibro, l.descripcionLibro, l.stock, l.idMateria
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
                libro.idMateria = (int)dr["idMateria"];
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
                                cantidadHojasLibro, precioLibro, idEditorial, idEstado, idMateria FROM Libro WHERE idLibro = @id";
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
                libro.idMateria = (int)dr["idMateria"];
                if (dr["idEstado"] != DBNull.Value)
                { libro.idEstado = (int)dr["idEstado"]; }

            }
            dr.Close();
            cmd.Connection.Close();
            return libro;
        }

        /// <summary>
        /// Consultar: un solo libro dada una ID pero con los datos de las otras tablas
        /// </summary>
        /// <param name="idLibro"></param>
        /// <returns></returns>
        public static LibroEntidadQuery ConsultarLibroQuery(int idLibro)
        {
            LibroEntidadQuery libro = new LibroEntidadQuery();
            string query = @"SELECT DISTINCT l.idLibro, l.codigoBarraLibro, l.nombreLibro, l.autorLibro, l.descripcionLibro, l.stock,
                                       l.cantidadHojasLibro, l.precioLibro, e.nombreEditorial, est.nombreEstado, 
                                       u.nombreUniversidad, f.nombreFacultad, m.nombreMateria
                                FROM Libro l INNER JOIN Materia m ON m.idMateria = l.idMateria
			                                  INNER JOIN CarreraXMateria cxr ON cxr.idMateria = m.idMateria
			                                  INNER JOIN Carrera c ON cxr.idCarrera = c.idCarrera
			                                  INNER JOIN Facultad f ON c.idFacultad = f.idFacultad
			                                  INNER JOIN Universidad u ON f.idUniversidad = u.idUniversidad
											  INNER JOIN Editorial e ON e.idEditorial = l.idEditorial
											  LEFT JOIN Estado est ON est.idEstado = l.idEstado
                                WHERE l.idLibro = @idLibro AND l.baja = 0";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"idLibro", idLibro);
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
                libro.nombreEditorial = dr["nombreEditorial"].ToString();
                libro.nombreEstado = dr["nombreEstado"].ToString();
                libro.nombreFacultad = dr["nombreFacultad"].ToString();
                libro.nombreUniversidad = dr["nombreUniversidad"].ToString();
                libro.listaCarreras = ConsultarCarrerasXLibro(libro.idLibro);
                libro.nombreMateria = dr["nombreMateria"].ToString();
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


        /// <summary>
        /// Consultar: todos los libros con los filtros (elegir entre materia o carrera)
        /// </summary>
        /// <param name="nombreLibro"></param>
        /// <param name="idUniversidad"></param>
        /// <param name="idFacultad"></param>
        /// <param name="idMateria"></param>
        /// <param name="idCarrera"></param>
        /// <returns></returns>
        public static List<LibroEntidadQuery> ConsultarLibroXFiltro(string nombreLibro, string idUniversidad, string idFacultad,
                                                                     string idMateria, string idCarrera)
        {
            List<LibroEntidadQuery> lista = new List<LibroEntidadQuery>();
            string consulta = @"SELECT l.idLibro, l.codigoBarraLibro, l.nombreLibro, l.autorLibro, l.descripcionLibro, l.stock,
                                       l.cantidadHojasLibro, l.precioLibro, e.nombreEditorial, est.nombreEstado, 
                                       u.nombreUniversidad, f.nombreFacultad, m.nombreMateria
                                FROM Libro l INNER JOIN Materia m ON m.idMateria = l.idMateria
			                                  INNER JOIN CarreraXMateria cxr ON cxr.idMateria = m.idMateria
			                                  INNER JOIN Carrera c ON cxr.idCarrera = c.idCarrera
			                                  INNER JOIN Facultad f ON c.idFacultad = f.idFacultad
			                                  INNER JOIN Universidad u ON f.idUniversidad = u.idUniversidad
											  INNER JOIN Editorial e ON e.idEditorial = l.idEditorial
											  INNER JOIN Estado est ON est.idEstado = l.idEstado
								WHERE l.nombreLibro LIKE @nomLib AND u.idUniversidad LIKE @idUni AND f.idFacultad LIKE @idFacu
													AND l.idMateria LIKE @idMat AND c.idCarrera like @idCar AND l.baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"nomLib", "%" + nombreLibro + "%");
            cmd.Parameters.AddWithValue(@"idUni", idUniversidad + "%");
            cmd.Parameters.AddWithValue(@"idFacu", idFacultad + "%");
            cmd.Parameters.AddWithValue(@"idMat", idMateria + "%");
            cmd.Parameters.AddWithValue(@"idCar", idCarrera + "%");
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
                libro.nombreFacultad = dr["nombreFacultad"].ToString();
                libro.nombreUniversidad = dr["nombreUniversidad"].ToString();
                libro.listaCarreras = ConsultarCarrerasXLibro(libro.idLibro);
                libro.nombreMateria = (string)dr["nombreMateria"];
                lista.Add(libro);
            }
            dr.Close();
            cmd.Connection.Close();
            return lista;
        }

        public static List<LibroEntidadQuery> ConsultarLibroXFiltroMateria(string nombreLibro, string idUniversidad, string idFacultad,
                                                                     string idMateria)
        {
            List<LibroEntidadQuery> lista = new List<LibroEntidadQuery>();
            string consulta = @"SELECT DISTINCT l.idLibro, l.codigoBarraLibro, l.nombreLibro, l.autorLibro, l.descripcionLibro, l.stock,
                                       l.cantidadHojasLibro, l.precioLibro, e.nombreEditorial,  
                                       u.nombreUniversidad, f.nombreFacultad, m.nombreMateria
                                FROM Libro l INNER JOIN Materia m ON m.idMateria = l.idMateria
			                                  INNER JOIN CarreraXMateria cxr ON cxr.idMateria = m.idMateria
			                                  INNER JOIN Carrera c ON cxr.idCarrera = c.idCarrera
			                                  INNER JOIN Facultad f ON c.idFacultad = f.idFacultad
			                                  INNER JOIN Universidad u ON f.idUniversidad = u.idUniversidad
											  INNER JOIN Editorial e ON e.idEditorial = l.idEditorial
								WHERE l.nombreLibro LIKE @nomLib AND u.idUniversidad LIKE @idUni AND f.idFacultad LIKE @idFacu
													AND l.idMateria LIKE @idMat  AND l.baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"nomLib", nombreLibro + '%');
            cmd.Parameters.AddWithValue(@"idUni", idUniversidad + '%');
            cmd.Parameters.AddWithValue(@"idFacu", idFacultad + '%');
            cmd.Parameters.AddWithValue(@"idMat", idMateria + '%');
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
                libro.nombreFacultad = dr["nombreFacultad"].ToString();
                libro.nombreUniversidad = dr["nombreUniversidad"].ToString();
                libro.listaCarreras = ConsultarCarrerasXLibro(libro.idLibro);
                libro.nombreMateria = (string)dr["nombreMateria"];
                lista.Add(libro);
            }
            dr.Close();
            cmd.Connection.Close();
            return lista;
        }

        public static List<LibroEntidadQuery> ConsultarLibroXFiltroCarrera(string nombreLibro, string idUniversidad, string idFacultad, string idCarrera)
        {
            List<LibroEntidadQuery> lista = new List<LibroEntidadQuery>();
            string consulta = @"SELECT l.idLibro, l.codigoBarraLibro, l.nombreLibro, l.autorLibro, l.descripcionLibro, l.stock,
                                       l.cantidadHojasLibro, l.precioLibro, e.nombreEditorial, 
                                       u.nombreUniversidad, f.nombreFacultad, m.nombreMateria
                                FROM Libro l INNER JOIN Materia m ON m.idMateria = l.idMateria
			                                  INNER JOIN CarreraXMateria cxr ON cxr.idMateria = m.idMateria
			                                  INNER JOIN Carrera c ON cxr.idCarrera = c.idCarrera
			                                  INNER JOIN Facultad f ON c.idFacultad = f.idFacultad
			                                  INNER JOIN Universidad u ON f.idUniversidad = u.idUniversidad
											  INNER JOIN Editorial e ON e.idEditorial = l.idEditorial
								WHERE l.nombreLibro LIKE @nomLib AND u.idUniversidad LIKE @idUni AND f.idFacultad LIKE @idFacu
													AND  c.idCarrera like @idCar AND l.baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"nomLib", nombreLibro + '%');
            cmd.Parameters.AddWithValue(@"idUni", idUniversidad + '%');
            cmd.Parameters.AddWithValue(@"idFacu", idFacultad + '%');
            cmd.Parameters.AddWithValue(@"idCar", idCarrera + '%');
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
                libro.nombreFacultad = dr["nombreFacultad"].ToString();
                libro.nombreUniversidad = dr["nombreUniversidad"].ToString();
                libro.listaCarreras = ConsultarCarrerasXLibro(libro.idLibro);
                libro.nombreMateria = (string)dr["nombreMateria"];
                lista.Add(libro);
            }
            dr.Close();
            cmd.Connection.Close();
            return lista;
        }

        public static List<CarreraEntidad> ConsultarCarrerasXLibro(int idLibro)
        {
            List<CarreraEntidad> lista = new List<CarreraEntidad>();
            string consulta = @"SELECT cxm.idCarrera, c.nombreCarrera 
                                FROM Libro l JOIN CarreraXMateria cxm ON l.idMateria = cxm.idMateria
									          JOIN Carrera c ON cxm.idCarrera = c.idCarrera WHERE l.idLibro = @id AND l.baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", idLibro);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CarreraEntidad car = new CarreraEntidad();
                car.idCarrera = int.Parse(dr["idCarrera"].ToString());
                car.nombreCarrera = dr["nombreCarrera"].ToString();
                lista.Add(car);
            }
            dr.Close();
            cmd.Connection.Close();
            return lista;
        }

        public static List<MateriaEntidad> ConsultarMateriasXLibro(int idLibro)
        {
            List<MateriaEntidad> lista = new List<MateriaEntidad>();
            string consulta = @"SELECT cxm.idMateria, m.nombreMateria 
                                FROM Libro l JOIN CarreraXMateria cxm ON l.idMateria = cxm.idMateria
									          JOIN Materia m ON cxm.idMateria = m.idMateria WHERE l.idLibro = @id AND a.baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", idLibro);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                MateriaEntidad car = new MateriaEntidad();
                car.idMateria = int.Parse(dr["idMateria"].ToString());
                car.nombreMateria = dr["nombreMateria"].ToString();
                lista.Add(car);
            }
            dr.Close();
            cmd.Connection.Close();
            return lista;
        }

        public static void RegistrarIngresoLibro(IngresoLibroEntidad libro)
        {
            SqlConnection cnn = obtenerBD();
            SqlTransaction trans = cnn.BeginTransaction();

            try
            {
                //Insert de la tabla ingresoLibro
                string query1 = "INSERT INTO IngresoLibro (fecha, idProveedor, total, idUsuario) VALUES (@fecha, @idProveedor, @total, @idUsuario); select scope_identity()";
                SqlCommand cmd1 = new SqlCommand(query1, cnn, trans);
                cmd1.Parameters.AddWithValue(@"fecha", libro.fecha);
                cmd1.Parameters.AddWithValue(@"idProveedor", libro.idProveedor);
                cmd1.Parameters.AddWithValue(@"total", libro.total);
                cmd1.Parameters.AddWithValue(@"idUsuario", libro.idUsuario);
                int idIngresoLibro = int.Parse(cmd1.ExecuteScalar().ToString());

                foreach(DetalleIngresoLibroEntidad detalleIngresoLibro in libro.listaDetalleIngresoLibro)
                {
                    //Insert de la tabla detalleIngresoLibro
                    string query2 = "INSERT INTO DetalleIngresoLibro (idIngresoLibro, idLibro, cantidad, precioUnitario) VALUES (@idIngresoLibro, @idLibro, @cantidad, @precioUnitario)";
                    SqlCommand cmd2 = new SqlCommand(query2, cnn, trans);
                    cmd2.Parameters.AddWithValue(@"idIngresoLibro", idIngresoLibro);
                    cmd2.Parameters.AddWithValue(@"idLibro", detalleIngresoLibro.idLibro);
                    cmd2.Parameters.AddWithValue(@"cantidad", detalleIngresoLibro.cantidad);
                    cmd2.Parameters.AddWithValue(@"precioUnitario", detalleIngresoLibro.precioUnitario);
                    cmd2.ExecuteNonQuery();
                    //Update de la cantidad y precio de un libro
                    string query3 = "UPDATE Libro SET stock = stock + @cantidad, precioLibro = @precioUnitario WHERE idLibro = @idLibro";
                    SqlCommand cmd3 = new SqlCommand(query3, cnn, trans);
                    cmd3.Parameters.AddWithValue(@"idLibro", detalleIngresoLibro.idLibro);
                    cmd3.Parameters.AddWithValue(@"cantidad", detalleIngresoLibro.cantidad);
                    cmd3.Parameters.AddWithValue(@"precioUnitario", detalleIngresoLibro.precioUnitario);
                    cmd3.ExecuteNonQuery();
                }


                //--- Commit
                trans.Commit();
            }
            catch (Exception)
            {
                trans.Rollback();
            }
            finally
            {
                cnn.Close();
            }
        }
    }
}
