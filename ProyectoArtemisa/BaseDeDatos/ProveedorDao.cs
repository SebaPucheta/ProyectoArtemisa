using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace BaseDeDatos
{
    public class ProveedorDao : Conexion
    {

        /// <summary>
        /// Registrar: una proveedor
        /// </summary>
        /// <param name="proveedor"></param>
        public static void RegistrarProveedor(ProveedorEntidad proveedor)
        {

            //FALTA REGISTRAR EL PROVEEDOR X EDITORIAL


            string query = @"INSERT INTO Proveedor(nombreProveedor, telefono, email, direccion, nombreContacto, idCiudadEditorial, baja) 
                            VALUES (@nombreProveedor, @telefono, @email, @direccion, @nombreContacto, @idCiudadEditorial, 0)";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"nombreEditorial", proveedor.nombreProveedor);
            cmd.Parameters.AddWithValue(@"telefono", proveedor.telefonoProveedor);
            cmd.Parameters.AddWithValue(@"email", proveedor.emailProveedor);
            cmd.Parameters.AddWithValue(@"direccion", proveedor.direccionProveedor);
            cmd.Parameters.AddWithValue(@"nombreContacto", proveedor.nombreContactoProveedor);
            cmd.Parameters.AddWithValue(@"idCiudadEditorial", proveedor.idCiudadEditorial);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        /// <summary>
        /// Eliminar: una proveedor con un id determinado
        /// </summary>
        /// <param name="id"></param>
        public static void EliminarProveedor(int id)
        {
            string consulta = @"UPDATE Proveedor SET baja = 1 WHERE idProveedor = @id";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        /// <summary>
        /// Modificar: una proveedor determinada identificada por su ID
        /// </summary>
        /// <param name="id"></param>
        public static void ModificarProveedor(ProveedorEntidad proveedor)
        {
            string consulta = @"UPDATE Proveedor SET nombreProveedor = @nomEditorial, telefono = @tel, email = @em, direccion = @dir,
                                                     nombreContacto = @nomContacto, idCiudadEditorial = @idCiudad
                                                 WHERE idProveedor = @idProveedor AND baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"nomEditorial", proveedor.nombreProveedor);
            cmd.Parameters.AddWithValue(@"tel", proveedor.telefonoProveedor);
            cmd.Parameters.AddWithValue(@"em", proveedor.emailProveedor);
            cmd.Parameters.AddWithValue(@"dir", proveedor.direccionProveedor);
            cmd.Parameters.AddWithValue(@"nomContacto", proveedor.nombreContactoProveedor);
            cmd.Parameters.AddWithValue(@"idCiudad", proveedor.idCiudadEditorial);
            cmd.Parameters.AddWithValue(@"idProveedor", proveedor.idProveedor);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        /// <summary>
        /// Consultar: todas los proveedores
        /// </summary>
        /// <returns></returns>
        public static List<ProveedorEntidad> ConsultarProveedores()
        {
            string query = @"SELECT idProveedor, nombreProveedor, telefono, email, direccion, nombreContacto, idCiudadEditorial FROM Proveedor WHERE baja = 0";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            SqlDataReader dr = cmd.ExecuteReader();
            List<ProveedorEntidad> listaProveedor = new List<ProveedorEntidad>();
            while (dr.Read())
            {
                ProveedorEntidad proveedor = new ProveedorEntidad();
                proveedor.idProveedor = int.Parse(dr["idProveedor"].ToString());
                proveedor.nombreProveedor = dr["nombreProveedor"].ToString();
                proveedor.telefonoProveedor = dr["telefono"].ToString();
                proveedor.emailProveedor = dr["email"].ToString();
                proveedor.direccionProveedor = dr["direccion"].ToString();
                proveedor.nombreContactoProveedor = dr["nombreContacto"].ToString();
                proveedor.idCiudadEditorial = (int)dr["idCiudadEditorial"];
                listaProveedor.Add(proveedor);
            }
            dr.Close();
            cmd.Connection.Close();
            return listaProveedor;
        }

        public static List<EditorialEntidad> ConsultarEditorialesDeUnProveedor(int id)
        {
            string query = @"SELECT e.idEditorial, e.nombreEditorial 
                            FROM Editorial e INNER JOIN EditorialXProveedor edXpr ON (e.idEditorial = edXpr.idEditorial)
                            WHERE edXpr.idProveedor = @id AND e.baja = 0;";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            List<EditorialEntidad> lista = new List<EditorialEntidad>();
            while (dr.Read())
            {
                EditorialEntidad editorial = new EditorialEntidad();
                editorial.idEditorial = int.Parse(dr["idEditorial"].ToString());
                editorial.nombreEditorial = dr["nombreEditorial"].ToString();
                lista.Add(editorial);
            }
            dr.Close();
            cmd.Connection.Close();
            return lista;
        }

        /// <summary>
        /// Consultar: todas los proveedores query
        /// </summary>
        /// <returns></returns>
        public static List<ProveedorQuery> ConsultarProveedoresQuery()
        {
            string query = @"SELECT idProveedor, nombreProveedor, telefono, email, direccion, nombreContacto, idCiudadEditorial FROM Proveedor WHERE baja = 0";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            SqlDataReader dr = cmd.ExecuteReader();
            List<ProveedorQuery> listaProveedor = new List<ProveedorQuery>();
            while (dr.Read())
            {
                ProveedorQuery proveedor = new ProveedorQuery();
                proveedor.idProveedor = int.Parse(dr["idProveedor"].ToString());
                proveedor.nombreProveedor = dr["nombreProveedor"].ToString();
                proveedor.telefonoProveedor = dr["telefono"].ToString();
                proveedor.emailProveedor = dr["email"].ToString();
                proveedor.direccionProveedor = dr["direccion"].ToString();
                proveedor.nombreContactoProveedor = dr["nombreContacto"].ToString();
                proveedor.nombreCiudadEditorial = CiudadDao.ConsultarCiudad((int)dr["idCiudadEditorial"]).nombreCiudad;
                listaProveedor.Add(proveedor);
            }
            dr.Close();
            cmd.Connection.Close();
            return listaProveedor;
        }

        public static ProveedorEntidad ConsultarUnProveedor(int id)
        {
            string query = @"SELECT idProveedor, nombreProveedor, telefono, email, direccion, nombreContacto, idCiudadEditorial FROM Proveedor WHERE idProveedor = @id AND baja = 0";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            ProveedorEntidad proveedor = new ProveedorEntidad();
            while (dr.Read())
            {
                proveedor.idProveedor = int.Parse(dr["idProveedor"].ToString());
                proveedor.nombreProveedor = dr["nombreProveedor"].ToString();
                proveedor.telefonoProveedor = dr["telefono"].ToString();
                proveedor.emailProveedor = dr["email"].ToString();
                proveedor.direccionProveedor = dr["direccion"].ToString();
                proveedor.nombreContactoProveedor = dr["nombreContacto"].ToString();
                proveedor.idCiudadEditorial = (int)dr["idCiudadEditorial"];
            }
            dr.Close();
            cmd.Connection.Close();
            return proveedor;
        }

        public static void RegistrarExP(int idProv, int idEdi, SqlTransaction tran, SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Transaction = tran;
            cmd.CommandText = @"INSERT INTO EditorialXProveedor (idEditorial, idProveedor) VALUES (@idEditorial, @idProveedor)";
            cmd.Parameters.AddWithValue(@"idEditorial", idEdi);
            cmd.Parameters.AddWithValue(@"idProveedor", idProv);
            cmd.ExecuteNonQuery();
        }

        public static void RegistrarProveedorConEditoriales(ProveedorEntidad proveedor, List<EditorialEntidad> editoriales)
        {
            //Esto no se hace
          
            SqlConnection con = obtenerBD();
            
            SqlTransaction tran = con.BeginTransaction();

            SqlCommand cmd = con.CreateCommand();
            cmd.Transaction = tran;

            try
            {
                // Execute two separate commands.
                cmd.CommandText = @"INSERT INTO Proveedor(nombreProveedor, telefono, email, direccion, nombreContacto, idCiudadEditorial, baja) 
                            VALUES (@nombreProveedor, @telefono, @email, @direccion, @nombreContacto, @idCiudadEditorial, 0); select scope_identity()";
                cmd.Parameters.AddWithValue(@"nombreProveedor", proveedor.nombreProveedor);
                cmd.Parameters.AddWithValue(@"telefono", proveedor.telefonoProveedor);
                cmd.Parameters.AddWithValue(@"email", proveedor.emailProveedor);
                cmd.Parameters.AddWithValue(@"direccion", proveedor.direccionProveedor);
                cmd.Parameters.AddWithValue(@"nombreContacto", proveedor.nombreContactoProveedor);
                cmd.Parameters.AddWithValue(@"idCiudadEditorial", proveedor.idCiudadEditorial);
                int idProxProveedor = int.Parse(cmd.ExecuteScalar().ToString());
                // Second command
                foreach (EditorialEntidad edi in editoriales)
                {
                    RegistrarExP(idProxProveedor, edi.idEditorial, tran, con);
                }

                // Commit the transaction.
                tran.Commit();

            }
            catch (Exception ex)
            {
                // Handle the exception if the transaction fails to commit.
                Console.WriteLine(ex.Message);

                try
                {
                    // Attempt to roll back the transaction.
                    tran.Rollback();
                }
                catch (Exception exRollback)
                {
                    // Throws an InvalidOperationException if the connection 
                    // is closed or the transaction has already been rolled 
                    // back on the server.
                    Console.WriteLine(exRollback.Message);
                }
            }
            finally
            {
                con.Close();
            }

        }


        ///// <summary>
        ///// Consultar: todas las proveedor con nombres en los campos
        ///// </summary>
        ///// <returns></returns>
        //public static List<EditorialEntidadQuery> ConsultarEditorialQuery()
        //{
        //    string query = @"SELECT e.idEditorial, e.nombreEditorial, e.telefono, e.email, e.direccion, e.nombreContacto, c.nombreCiudad 
        //                            FROM Editorial e INNER JOIN Ciudad c ON e.idCiudadEditorial = c.idCiudad  WHERE e.baja = 0";
        //    SqlCommand cmd = new SqlCommand(query, obtenerBD());
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    List<EditorialEntidadQuery> listaEditorial = new List<EditorialEntidadQuery>();
        //    while (dr.Read())
        //    {
        //        EditorialEntidadQuery editorial = new EditorialEntidadQuery();
        //        editorial.idEditorial = int.Parse(dr["idEditorial"].ToString());
        //        editorial.nombreEditorial = dr["nombreEditorial"].ToString();
        //        editorial.telefono = dr["telefono"].ToString();
        //        editorial.email = dr["email"].ToString();
        //        editorial.direccion = dr["direccion"].ToString();
        //        editorial.nombreContacto = dr["nombreContacto"].ToString();
        //        editorial.nombreCiudadEditorial = dr["nombreCiudad"].ToString();
        //        listaEditorial.Add(editorial);
        //    }
        //    dr.Close();
        //    cmd.Connection.Close();
        //    return listaEditorial;
        //}


        ///// <summary>
        ///// Consultar: una sola proveedor determinada por un ID
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public static EditorialEntidad ConsultarUnaEditorial(int id)
        //{
        //    EditorialEntidad editorial = new EditorialEntidad();
        //    string query = @"SELECT idEditorial, nombreEditorial, telefono, email, direccion, nombreContacto, idCiudadEditorial 
        //                        FROM Editorial WHERE baja = 0 AND idEditorial = @id";
        //    SqlCommand cmd = new SqlCommand(query, obtenerBD());
        //    cmd.Parameters.AddWithValue(@"id", id);
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        editorial.idEditorial = int.Parse(dr["idEditorial"].ToString());
        //        editorial.nombreEditorial = dr["nombreEditorial"].ToString();
        //        editorial.telefono = dr["telefono"].ToString();
        //        editorial.email = dr["email"].ToString();
        //        editorial.direccion = dr["direccion"].ToString();
        //        editorial.nombreContacto = dr["nombreContacto"].ToString();
        //        editorial.idCiudadEditorial = (int)dr["idCiudadEditorial"];
        //    }
        //    dr.Close();
        //    cmd.Connection.Close();
        //    return editorial;
        //}



        ///// <summary>
        ///// Consultar: datos de la proveedor segun provincia, ciudad, nobmre de contacto y nombre de la editorial
        ///// </summary>
        ///// <param name="idCiudad"></param>
        ///// <param name="idProvincia"></param>
        ///// <param name="nombreContacto"></param>
        ///// <param name="nombreEditorial"></param>
        ///// <returns></returns>
        //public static List<EditorialEntidadQuery> ConsultarEditorialXFiltro(string idCiudad, string idProvincia, string nombreContacto, string nombreEditorial)
        //{
        //    List<EditorialEntidadQuery> lista = new List<EditorialEntidadQuery>();
        //    string consulta = @"SELECT e.idEditorial, e.nombreEditorial, e.nombreContacto, e.telefono, c.nombreCiudad, p.nombreProvincia, e.email, e.direccion
        //                        FROM Editorial e INNER JOIN Ciudad c ON e.idCiudadEditorial = c.idCiudad
        //                                         INNER JOIN Provincia p ON p.idProvincia = c.idProvincia
        //                        WHERE e.nombreEditorial LIKE @nomEdi AND e.nombreContacto LIKE @nomCon AND p.idProvincia LIKE @idProv  AND c.idCiudad LIKE @idCiu AND e.baja = 0";
        //    SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
        //    cmd.Parameters.AddWithValue(@"nomEdi", nombreEditorial + "%");
        //    cmd.Parameters.AddWithValue(@"nomCon", nombreContacto + "%");
        //    cmd.Parameters.AddWithValue(@"idProv", idProvincia + "%");
        //    cmd.Parameters.AddWithValue(@"idCiu", idCiudad + "%");
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        EditorialEntidadQuery edi = new EditorialEntidadQuery();
        //        edi.idEditorial = int.Parse(dr["idEditorial"].ToString());
        //        edi.nombreEditorial = dr["nombreEditorial"].ToString();
        //        edi.nombreContacto = dr["nombreContacto"].ToString();
        //        edi.telefono = dr["telefono"].ToString();
        //        edi.nombreCiudadEditorial = dr["nombreCiudad"].ToString();
        //        edi.nombreProvinciaEditorial = dr["nombreProvincia"].ToString();
        //        edi.email = dr["email"].ToString();
        //        edi.direccion = (string)dr["direccion"];
        //        lista.Add(edi);
        //    }
        //    dr.Close();
        //    cmd.Connection.Close();
        //    return lista;
        //}

    }
}
