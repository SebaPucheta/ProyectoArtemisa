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

        public static void RegistrarEditorial(EditorialEntidad editorial)
        {
            string query = @"INSERT INTO Editorial(nombreEditorial, telefono, email, direccion, nombreContacto, idCiudadEditorial) 
                            VALUES (@nombreEditorial, @telefono, @email, @direccion, @nombreContacto, @idCiudadEditorial)";

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
        public static List<EditorialEntidad> ConsultarEditorial()
        {
            string query = @"SELECT idEditorial, nombreEditorial, telefono, email, direccion, nombreContacto, idCiudadEditorial FROM Editorial WHERE baja=0";
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

            return listaEditorial;
        }

    }
}
