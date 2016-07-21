using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace BaseDeDatos
{
    public class EstadoOrdenImpresionDao : Conexion
    {

        //Devuelve el nombre del estado que corresponde con el id ingresado
        public static string DevolverNombreEstado(int idEstadoOrdenImpresion)
        {
            string query = @"SELECT nombreEstadoOrdenImpresion 
                             FROM EstadoOrdenImpresion 
                             WHERE idEstadoOrdenImpresion = @id";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", idEstadoOrdenImpresion);
            SqlDataReader dr = cmd.ExecuteReader();
            EstadoOrdenImpresionEntidad estado = new EstadoOrdenImpresionEntidad();
            while (dr.Read())
            {
                estado.idEstado = idEstadoOrdenImpresion;
                estado.nombreEstado = dr["nombreEstadoOrdenImpresion"].ToString();
            }       
            dr.Close();
            cmd.Connection.Close();
            return estado.nombreEstado;
        }

        
    }
}
