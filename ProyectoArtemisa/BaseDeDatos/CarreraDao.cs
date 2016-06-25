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

        /// <summary>
        /// Registrar: una carrera en el sistema
        /// </summary>
        /// <param name="carrera"></param>
        public static void RegistrarCarrera(CarreraEntidad carrera)
        {
            string query = "INSERT INTO Carrera(nombreCarrera, idFacultad, baja) VALUES (@nombreCarrera, @idFacultad, 0)";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"nombreCarrera", carrera.nombreCarrera);
            cmd.Parameters.AddWithValue(@"idFacultad", carrera.idFacultad);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        /// <summary>
        /// Eliminar: una carrera con un id determinado
        /// </summary>
        /// <param name="id"></param>
        public static void EliminarCarrera(int id)
        {
            string consulta = @"UPDATE Carrera SET baja = 1 WHERE idCarrera = @id";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        /// <summary>
        /// Modificar: una carrera determinada identificada por su ID
        /// </summary>
        /// <param name="id"></param>
        public static void ModificarCarrera(CarreraEntidad car)
        {
            string consulta = @"UPDATE Carrera SET nombreCarrera = @nom, idFacultad = @idFacultad WHERE idCarrera = @idCarrera";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"nom", car.nombreCarrera);
            cmd.Parameters.AddWithValue(@"idFacultad", car.idFacultad);
            cmd.Parameters.AddWithValue(@"idCarrera", car.idCarrera);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        /// <summary>
        /// Consultar: todas las carreras registradas
        /// </summary>
        /// <returns></returns>
        public static List<CarreraEntidad> ConsultarCarrera()
        {
            List<CarreraEntidad> listaCarrera = new List<CarreraEntidad>();
            string query = "SELECT idCarrera, nombreCarrera, idFacultad FROM Carrera WHERE baja = 0";
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


        /// <summary>
        /// Consultar: todas las carreras query (con nombres de todos los datos)
        /// </summary>
        /// <returns></returns>
        public static List<CarreraEntidadQuery> ConsultarCarrerasQuery()
        {
            List<CarreraEntidadQuery> lista = new List<CarreraEntidadQuery>();
            string consulta = @"SELECT c.idCarrera, c.nombreCarrera, f.nombreFacultad 
                                FROM Carrera c INNER JOIN Facultad f ON c.idFacultad = f.idFacultad WHERE c.baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CarreraEntidadQuery car = new CarreraEntidadQuery();
                car.idCarrera = int.Parse(dr["idCarrera"].ToString());
                car.nombreCarrera = dr["nombreCarrera"].ToString();
                car.nombreFacultad = dr["nombreFacultad"].ToString();
                lista.Add(car);
            }
            dr.Close();
            cmd.Connection.Close();
            return lista;
        }


        /// <summary>
        /// Consultar: una carrera de un ID determinado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static CarreraEntidad ConsultarUnaCarrera(int id)
        {
            CarreraEntidad car = new CarreraEntidad();
            string consulta = @"SELECT idCarrera, nombreCarrera, idFacultad 
                                FROM Carrera WHERE idCarrera = @id";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                car.idCarrera = int.Parse(dr["idCarrera"].ToString());
                car.nombreCarrera = dr["nombreCarrera"].ToString();
                car.idFacultad = int.Parse(dr["idFacultad"].ToString());
            }
            dr.Close();
            cmd.Connection.Close();
            return car;
        }

        /// <summary>
        /// Consultar: una carreras de un idFacultad determinado
        /// </summary>
        /// <param name="idFacultad"></param>
        /// <returns>List<CarreraEntidad></returns>
        public static List<CarreraEntidad> ConsultarCarreraXFacultad(int idFacultad)
        {
            string consulta = @"SELECT idCarrera, nombreCarrera, idFacultad 
                                FROM Carrera WHERE idFacultad = @idFacultad";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue("@idFacultad", idFacultad);
            SqlDataReader dr = cmd.ExecuteReader();
            List<CarreraEntidad> listaCarrera = new List<CarreraEntidad>();
            while (dr.Read())
            {
                CarreraEntidad car = new CarreraEntidad();
                car.idCarrera = int.Parse(dr["idCarrera"].ToString());
                car.nombreCarrera = dr["nombreCarrera"].ToString();
                car.idFacultad = int.Parse(dr["idFacultad"].ToString());
                listaCarrera.Add(car);
            }
            dr.Close();
            cmd.Connection.Close();
            return listaCarrera;
        }

        /// <summary>
        /// Consultar: las carreras que dictan una materia específica
        /// </summary>
        /// <param name="idMateria"></param>
        /// <returns></returns>
        public static List<CarreraEntidad> ConsultarCarreraXMateria(int idMateria)
        {
            List<CarreraEntidad> lista = new List<CarreraEntidad>();
            string query = @"SELECT c.idCarrera as 'idCar', c.nombreCarrera
                             FROM Carrera c JOIN CarreraXMateria cm ON c.idCarrera = cm.idCarrera
                             WHERE cm.idMateria = @idMateria AND c.baja = 0";
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
