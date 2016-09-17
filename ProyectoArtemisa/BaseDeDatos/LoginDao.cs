using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace BaseDeDatos
{
    public class LoginDao : Conexion
    {

        /// <summary>
        /// Para ver si existe el usuario en la base de datos
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool Autenticar(string usuario, string password)
        {
            string consulta = @"SELECT COUNT(*) FROM Usuario WHERE nombreUsuario = @user AND contrasena = @pass";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue("@user", usuario);
            cmd.Parameters.AddWithValue("@pass", password);
            int count = Convert.ToInt32(cmd.ExecuteScalar()); 
            //Devuelve la unica fila para saber si existe o no
            if (count == 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Obtiene los roles de un solo usuario conociendo el nombre de usuario
        /// </summary>
        /// <param name="nombreUsuarioLogueado"></param>
        /// <returns></returns>
        public static string[] ObtenerRoles(string nombreUsuarioLogueado)
        {
            string consulta = @"SELECT r.nombreRol FROM Usuario u JOIN Rol r ON (u.idRol = r.idRol) WHERE u.nombreUsuario = @nombreUsuario";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"nombreUsuario", nombreUsuarioLogueado);
            int contador = 0;
            List<string> roles = new List<string>();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                roles.Add(dr["nombreRol"].ToString());
                contador++;
            }
            string[] listaRoles = new string[contador];
            roles.CopyTo(listaRoles);
            return listaRoles;

        }

    }
}
