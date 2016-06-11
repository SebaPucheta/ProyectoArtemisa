using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using Entidades;

namespace BaseDeDatos
{
    public class CarreraDao: Conexion
    {

        public static void registrarCarrera(CarreraEntidad carrera)
        {
            //Se inserta el nombre de una 
            string query = "INSERT INTO Carrera(nombre) VALUES (@carrera)";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"carrera", carrera.nombre);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public static List<CarreraEntidad> consultarCarrera()
        {
            List<CarreraEntidad> listaCarrera = new List<CarreraEntidad>();
            string query = "Select * FROM Carrera";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                CarreraEntidad carrera = new CarreraEntidad();
                carrera.idCarrera = int.Parse(dr["idCarrera"].ToString());
                carrera.nombre = dr["nombre"].ToString();
                listaCarrera.Add(carrera);
            }

            dr.Close();
            cmd.Connection.Close();
            return listaCarrera;
        }

    }

    
}
