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
    public class EditorialDao : Conexion
    {
        //idEditorial
        //nombreEditorial
        //telefono
        //email
        //direccion
        //nombreContacto
        //baja


        /// <summary>
        /// Registrar: una editorial
        /// </summary>
        /// <param name="editorial"></param>
        public static void RegistrarEditorial(EditorialEntidad editorial)
        {
            string query = @"INSERT INTO Editorial(nombreEditorial, telefono, email, direccion, nombreContacto, idCiudadEditorial, baja) 
                            VALUES (@nombreEditorial, @telefono, @email, @direccion, @nombreContacto, @idCiudadEditorial, 0)";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"nombreEditorial", editorial.nombreEditorial);
            cmd.Parameters.AddWithValue(@"telefono", editorial.telefono);
            cmd.Parameters.AddWithValue(@"email", editorial.email);
            cmd.Parameters.AddWithValue(@"direccion", editorial.direccion);
            cmd.Parameters.AddWithValue(@"nombreContacto", editorial.nombreContacto);
            cmd.Parameters.AddWithValue(@"idCiudadEditorial", editorial.idCiudadEditorial);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        /// <summary>
        /// Eliminar: una editorial con un id determinado
        /// </summary>
        /// <param name="id"></param>
        public static void EliminarEditorial(int id)
        {
            string consulta = @"UPDATE Editorial SET baja = 1 WHERE idEditorial = @id";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        /// <summary>
        /// Modificar: una editorial determinada identificada por su ID
        /// </summary>
        /// <param name="id"></param>
        public static void ModificarEditorial(EditorialEntidad editorial)
        {
            string consulta = @"UPDATE Editorial SET nombreEditorial = @nomEditorial, telefono = @tel, email = @em, direccion = @dir,
                                                     nombreContacto = @nomContacto, idCiudadEditorial = @idCiudad
                                                 WHERE idEditorial = @idEditorial AND baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"nomEditorial", editorial.nombreEditorial);
            cmd.Parameters.AddWithValue(@"tel", editorial.telefono);
            cmd.Parameters.AddWithValue(@"em", editorial.email);
            cmd.Parameters.AddWithValue(@"dir", editorial.direccion);
            cmd.Parameters.AddWithValue(@"nomContacto", editorial.nombreContacto);
            cmd.Parameters.AddWithValue(@"idCiudad", editorial.idCiudadEditorial);
            cmd.Parameters.AddWithValue(@"idEditorial", editorial.idEditorial);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        /// <summary>
        /// Consultar: todas las editoriales
        /// </summary>
        /// <returns></returns>
        public static List<EditorialEntidad> ConsultarEditorial()
        {
            string query = @"SELECT idEditorial, nombreEditorial, telefono, email, direccion, nombreContacto, idCiudadEditorial FROM Editorial WHERE baja = 0";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            SqlDataReader dr = cmd.ExecuteReader();
            List<EditorialEntidad> listaEditorial = new List<EditorialEntidad>();
            while (dr.Read())
            {
                EditorialEntidad editorial = new EditorialEntidad();
                editorial.idEditorial = int.Parse(dr["idEditorial"].ToString());
                editorial.nombreEditorial = dr["nombreEditorial"].ToString();
                editorial.telefono = dr["telefono"].ToString();
                editorial.email = dr["email"].ToString();
                editorial.direccion = dr["direccion"].ToString();
                editorial.nombreContacto = dr["nombreContacto"].ToString();
                editorial.idCiudadEditorial =(int)dr["idCiudadEditorial"];
                listaEditorial.Add(editorial);
            }
            dr.Close();
            cmd.Connection.Close();
            return listaEditorial;
        }


        /// <summary>
        /// Consultar: todas las editoriales con nombres en los campos
        /// </summary>
        /// <returns></returns>
        public static List<EditorialEntidadQuery> ConsultarEditorialQuery()
        {
            string query = @"SELECT e.idEditorial, e.nombreEditorial, e.telefono, e.email, e.direccion, e.nombreContacto, c.nombreCiudad 
                                    FROM Editorial e INNER JOIN Ciudad c ON e.idCiudadEditorial = c.idCiudad  WHERE e.baja = 0";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            SqlDataReader dr = cmd.ExecuteReader();
            List<EditorialEntidadQuery> listaEditorial = new List<EditorialEntidadQuery>();
            while (dr.Read())
            {
                EditorialEntidadQuery editorial = new EditorialEntidadQuery();
                editorial.idEditorial = int.Parse(dr["idEditorial"].ToString());
                editorial.nombreEditorial = dr["nombreEditorial"].ToString();
                editorial.telefono = dr["telefono"].ToString();
                editorial.email = dr["email"].ToString();
                editorial.direccion = dr["direccion"].ToString();
                editorial.nombreContacto = dr["nombreContacto"].ToString();
                editorial.nombreCiudadEditorial = dr["nombreCiudad"].ToString();
                listaEditorial.Add(editorial);
            }
            dr.Close();
            cmd.Connection.Close();
            return listaEditorial;
        }


        /// <summary>
        /// Consultar: una sola editorial determinada por un ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static EditorialEntidad ConsultarUnaEditorial(int id)
        {
            EditorialEntidad editorial = new EditorialEntidad();
            string query = @"SELECT idEditorial, nombreEditorial, telefono, email, direccion, nombreContacto, idCiudadEditorial 
                                FROM Editorial WHERE baja = 0 AND idEditorial = @id";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                editorial.idEditorial = int.Parse(dr["idEditorial"].ToString());
                editorial.nombreEditorial = dr["nombreEditorial"].ToString();
                editorial.telefono = dr["telefono"].ToString();
                editorial.email = dr["email"].ToString();
                editorial.direccion = dr["direccion"].ToString();
                editorial.nombreContacto = dr["nombreContacto"].ToString();
                editorial.idCiudadEditorial = (int)dr["idCiudadEditorial"];
            }
            dr.Close();
            cmd.Connection.Close();
            return editorial;
        }

    }
}
