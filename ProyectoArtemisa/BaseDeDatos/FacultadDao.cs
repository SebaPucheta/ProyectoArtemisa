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

        public static List<FacultadEntidad> ConsultarFacultad()
        {
            List<FacultadEntidad> listaFac = new List<FacultadEntidad>();
            string query = "Select idFacultad, nombreFacultad, idUniversidad  FROM Facultad Where baja=0";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                FacultadEntidad fac = new FacultadEntidad();
                fac.idFacultad = int.Parse(dr["idFacultad"].ToString());
                fac.nombreFacultad = dr["nombreFacultad"].ToString();
                fac.idUniversidad = (int)dr["idUniversidad"];
                listaFac.Add(fac);
            }

            dr.Close();
            cmd.Connection.Close();
            return listaFac;

        }

        public static List<FacultadEntidad> ConsultarFacultadXUniversidad(int idUniversidad)
        {
            List<FacultadEntidad> listaFac = new List<FacultadEntidad>();
            string query = "Select idFacultad, nombreFacultad, idUniversidad  FROM Facultad Where idUniversidad = @idUniversidad baja=0";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue("@idUniversidad", idUniversidad);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                FacultadEntidad fac = new FacultadEntidad();
                fac.idFacultad = int.Parse(dr["idFacultad"].ToString());
                fac.nombreFacultad = dr["nombreFacultad"].ToString();
                fac.idUniversidad = (int)dr["idUniversidad"];
                listaFac.Add(fac);
            }

            dr.Close();
            cmd.Connection.Close();
            return listaFac;

        }
    }
}
