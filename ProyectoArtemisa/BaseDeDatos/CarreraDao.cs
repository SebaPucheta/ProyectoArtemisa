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
    public class CarreraDao : Conexion
    {

        public static void RegistrarCarrera(CarreraEntidad carrera)
        {
            string query = "INSERT INTO Carrera(nombreCarrera, idFacultad) VALUES (@nombreCarrera, @idFacultad)";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"nombreCarrera", carrera.nombreCarrera);
            cmd.Parameters.AddWithValue(@"idFacultad", carrera.idFacultad);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public static List<CarreraEntidad> ConsultarCarrera()
        {
            List<CarreraEntidad> listaCarrera = new List<CarreraEntidad>();
            string query = "Select idCarrera, nombreCarrera, idFacultad FROM Carrera";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                CarreraEntidad carrera = new CarreraEntidad();
                carrera.idCarrera = int.Parse(dr["idCarrera"].ToString());
                carrera.nombreCarrera = dr["nombreCarrera"].ToString();
                carrera.idFacultad = int.Parse(dr["idFacultad"].ToString());
                listaCarrera.Add(carrera);
            }

            dr.Close();
            cmd.Connection.Close();
            return listaCarrera;
        }

        public static List<CarreraEntidad> ConsultarCarreraXMateria(int idMateria)
        {
            List<CarreraEntidad> lista = new List<CarreraEntidad>();
            string query = @"SELECT c.idCarrera as 'idCar', c.nombreCarrera
                             FROM Carrera c JOIN CarreraXMateria cm ON c.idCarrera = cm.idCarrera
                             WHERE cm.idMateria = @idMateria";

            SqlCommand cmd = new SqlCommand(query, obtenerBD());

            cmd.Parameters.AddWithValue(@"idMateria", idMateria);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                CarreraEntidad car = new CarreraEntidad();
                car.idCarrera = int.Parse(dr["idCar"].ToString());
                car.nombreCarrera = dr["nombreCarrera"].ToString();

                lista.Add(car);
            }

            dr.Close();
            cmd.Connection.Close();
            return lista;
        }

    }


}
