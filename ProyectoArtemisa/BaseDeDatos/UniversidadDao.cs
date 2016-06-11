using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.Sql;
using System.Data.SqlClient;



namespace BaseDeDatos
{
    public class UniversidadDao: Conexion
    {
        public static List<UniversidadEntidad> consultarUniversidad()
        {
            List<UniversidadEntidad> listaUni = new List<UniversidadEntidad>();
            string query = "Select * FROM Universidad";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                UniversidadEntidad uni = new UniversidadEntidad();
                uni.idUniversidad = int.Parse(dr["idUniversidad"].ToString());
                uni.nombreUniversidad = dr["nombre"].ToString();
                listaUni.Add(uni);
            }

            dr.Close();
            cmd.Connection.Close();
            return listaUni;

        }
    }
}
