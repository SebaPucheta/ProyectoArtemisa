using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using Entidades;

namespace BaseDeDatos
{
    public class FacultadDao: Conexion
    {

        public static List<FacultadEntidad> consultarFacultad()
        {
            List<FacultadEntidad> listaFac = new List<FacultadEntidad>();
            string query = "Select * FROM Facultad";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                FacultadEntidad fac = new FacultadEntidad();
                fac.idFacultad = int.Parse(dr["idFacultad"].ToString());
                fac.nombreFacultad = dr["nombre"].ToString();
                listaFac.Add(fac);
            }

            dr.Close();
            cmd.Connection.Close();
            return listaFac;

        }
    }
}
