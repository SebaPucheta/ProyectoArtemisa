using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace BaseDeDatos
{
    public class TipoApunteDao : Conexion
    {

        /// <summary>
        /// Registrar: un tipo de apunte recibiendo un objeto profesor
        /// </summary>
        public static void RegistrarTipoApunte(TipoApunteEntidad tipo)
        {
            string consulta = @"INSERT INTO TipoApunte (nombreTipoApunte, baja) VALUES (@nom, 0)";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"nom", tipo.nombreTipoApunte);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        /// <summary>
        /// Eliminar: un tipo de apunte con un id determinado
        /// </summary>
        /// <param name="id"></param>
        public static void EliminarProfesor(int id)
        {
            string consulta = @"UPDATE TipoApunte SET baja = 1 WHERE idTipoApunte = @id";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        /// <summary>
        /// Modifica un tipo de apunte recibiendo un objeto 
        /// </summary>
        public static void ModificarTipoApunte(TipoApunteEntidad tipo)
        {
            string consulta = @"UPDATE TipoApunte SET nombreTipoApunte = @nom WHERE idTipoApunte = @id";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"nom", tipo.nombreTipoApunte);
            cmd.Parameters.AddWithValue(@"id", tipo.idTipoApunte);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        /// <summary>
        /// Consultar: todos los tipos de apunte registrado en la base de datos
        /// </summary>
        /// <returns>Lista de objetos profesor</returns>
        public static List<TipoApunteEntidad> ConsultarTiposApunte()
        {
            List<TipoApunteEntidad> lista = new List<TipoApunteEntidad>();
            string consulta = @"SELECT idTipoApunte, nombreTipoApunte FROM TipoApunte WHERE baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TipoApunteEntidad tipo = new TipoApunteEntidad();
                tipo.idTipoApunte = int.Parse(dr["idTipoApunte"].ToString());
                tipo.nombreTipoApunte = dr["nombreTipoApunte"].ToString();
                lista.Add(tipo);
            }
            dr.Close();
            cmd.Connection.Close();
            return lista;
        }


        /// <summary>
        /// Consultar: un solo tipo de apunte con un ID determinado
        /// </summary>
        /// <returns></returns>
        public static TipoApunteEntidad ConsultarTipoApunte(int id)
        {
            TipoApunteEntidad tipo = new TipoApunteEntidad();
            string consulta = @"SELECT idTipoApunte, nombreTipoApunte FROM TipoApunte WHERE idTipoApunte = @id AND baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                tipo.idTipoApunte = int.Parse(dr["idTipoApunte"].ToString());
                tipo.nombreTipoApunte = dr["nombreTipoApunte"].ToString();
            }
            dr.Close();
            cmd.Connection.Close();
            return tipo;
        }


    }
}
