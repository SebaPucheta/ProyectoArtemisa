using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace BaseDeDatos
{
    public class UsuarioDao : Conexion
    {
        /// <summary>
        /// Registrar Usuario y Cliente
        /// </summary>
        /// <param name=""></param>
        public static void RegistrarUsuarioEmpleado(UsuarioEntidad user, EmpleadoEntidad empleado)
        {
            SqlConnection cn = obtenerBD();
            SqlTransaction trans = cn.BeginTransaction();
            try
            {
                string consulta = @"INSERT INTO Empleado (nombreEmpleado, apellidoEmpleado, dni, idTipoDNI, email) VALUES (@nom, @ape, @dni, @tipoDni, @email); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(consulta, cn, trans);
                cmd.Parameters.AddWithValue(@"nom", empleado.nombreEmpleado);
                cmd.Parameters.AddWithValue(@"ape", empleado.apellidoEmpleado);
                cmd.Parameters.AddWithValue(@"dni", empleado.dni);
                cmd.Parameters.AddWithValue(@"tipoDni", empleado.tipoDNI);
                cmd.Parameters.AddWithValue(@"email", empleado.email);
                empleado.idEmpleado = Convert.ToInt32(cmd.ExecuteScalar());

                consulta = @"INSERT INTO Usuario (nombreUsuario, contrasena, idCliente, idRol) VALUES (@usuario, @pass, @idCli, @idRol)";
                SqlCommand cmd2 = new SqlCommand(consulta, cn, trans);
                cmd2.Parameters.AddWithValue("@usuario", user.nombreUsuario);
                cmd2.Parameters.AddWithValue("@pass", user.contrasena);
                cmd2.Parameters.AddWithValue("@idCli", empleado.idEmpleado);
                cmd2.Parameters.AddWithValue("@idRol", user.idRol);
                cmd2.ExecuteNonQuery();
            }
            catch
            {
                trans.Rollback();
                cn.Close();
            }
            trans.Commit();
            cn.Close();
        }

        /// <summary>
        /// Registrar Cliente
        /// </summary>
        /// <param name=""></param>
        public static void RegistrarUsuarioCliente(UsuarioEntidad user, ClienteEntidad cli)
        {
            SqlConnection cn = obtenerBD();
            SqlTransaction trans = cn.BeginTransaction();
            try
            {
                string consulta = @"INSERT INTO Cliente (nombreCliente, apellidoCliente, email) VALUES (@nom, @ape, @email); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(consulta, cn, trans);
                cmd.Parameters.AddWithValue(@"nom", cli.nombreCliente);
                cmd.Parameters.AddWithValue(@"ape", cli.apellidoCliente);
                cmd.Parameters.AddWithValue(@"email", cli.email);
                cli.idCliente = Convert.ToInt32(cmd.ExecuteScalar());

                consulta = @"INSERT INTO Usuario (nombreUsuario, contrasena, idCliente, idRol) VALUES (@usuario, @pass, @idCli, @idRol)";
                SqlCommand cmd2 = new SqlCommand(consulta, cn, trans);
                cmd2.Parameters.AddWithValue("@usuario", cli.email);
                cmd2.Parameters.AddWithValue("@pass", user.contrasena);
                cmd2.Parameters.AddWithValue("@idCli", cli.idCliente);
                cmd2.Parameters.AddWithValue("@idRol", user.idRol);
                cmd2.ExecuteNonQuery();
            }
            catch
            {
                trans.Rollback();
                cn.Close();
            }
            trans.Commit();
            cn.Close();
        }

        public static void CambiarContraseña(UsuarioEntidad user, string nuevaPass)
        {
            string query = "UPDATE Usuario SET contrasena = @pass WHERE nombreUsuario = @user";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"pass", user.nombreUsuario);
            cmd.Parameters.AddWithValue(@"pass", nuevaPass);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        /// <summary>
        /// FALSO = no existe, TRUE = ya existe
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <returns></returns>
        public static bool VerificarUsuarioYEmailExistente(string nombreUsuario, string email)
        {
            string query = "SELECT COUNT(*) FROM Usuario WHERE nombreUsuario = @nom AND email = @em";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"nom", nombreUsuario);
            cmd.Parameters.AddWithValue(@"em", email);
            if (int.Parse(cmd.ExecuteScalar().ToString()) == 0)
            {
                cmd.Connection.Close();
                return false;
            }
            else
            {
                cmd.Connection.Close();
                return true;
            }
        }

        /// <summary>
        /// Consulta los datos de un usuario y completa con los del cliente
        /// </summary> By Gumer 
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public static UsuarioEntidadQuery ConsultarUnUsuario(int idUsuario)
        {
            UsuarioEntidadQuery usu = new UsuarioEntidadQuery();

            string query = @"SELECT u.idUsuario, u.nombreUsuario, u.contrasena, r.nombreRol, c.nombreCliente, c.apellidoCliente, c.nroDni, t.nombreTipoDNI, c.email
                             FROM Usuario u INNER JOIN Rol r ON u.idRol = r.idRol
                                            INNER JOIN Cliente c ON u.idCLiente = c.idCliente
                                            INNER JOIN TipoDNI t ON c.idTipoDNI = t.idTipoDNI
                             WHERE u.idusuario = @idUsuario";

            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"idUsuario", idUsuario);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                usu.idUsuario = int.Parse(dr["idUsuario"].ToString());
                usu.nombreUsuario = dr["nombreUsuario"].ToString();
                usu.contrasena = dr["contrasena"].ToString();
                usu.nombreRol = dr["nombreRol"].ToString();
                usu.clienteQuery.nombreCliente = dr["nombreCliente"].ToString();
                usu.clienteQuery.apellidoCliente = dr["apellidoCliente"].ToString();
                usu.clienteQuery.nroDni = int.Parse(dr["nroDni"].ToString());
                usu.nombreTipoDNI = dr["nombreTipoDNI"].ToString();
                usu.clienteQuery.email = dr["email"].ToString();
            }
            dr.Close();
            cmd.Connection.Close();
            return usu;
        }

        public static UsuarioEntidadQuery ConsultarUnUsuarioPorNick(string nombreUsuario)
        {
            UsuarioEntidadQuery usu = new UsuarioEntidadQuery();

            string query = @"SELECT u.idUsuario, 
	                                u.nombreUsuario, 
	                                u.contrasena, 
	                                r.nombreRol, 
	                                e.nombreEmpleado, 
	                                e.apellidoEmpleado, 
	                                e.dni, 
	                                ISNULL(e.email,'') AS email
                            FROM Usuario u INNER JOIN Rol r ON u.idRol = r.idRol
			                               INNER JOIN Empleado e ON u.idCLiente = e.idEmpleados
                                           INNER JOIN TipoDNI t ON e.idTipoDNI = t.idTipoDNI	
                             WHERE u.nombreUsuario = @nombreUsuario";

            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"nombreUsuario", nombreUsuario);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                usu.idUsuario = int.Parse(dr["idUsuario"].ToString());
                usu.nombreUsuario = dr["nombreUsuario"].ToString();
                usu.contrasena = dr["contrasena"].ToString();
                usu.nombreRol = dr["nombreRol"].ToString();
                EmpleadoEntidad empleado = new EmpleadoEntidad();
                empleado.nombreEmpleado = dr["nombreEmpleado"].ToString();
                empleado.apellidoEmpleado = dr["apellidoEmpleado"].ToString();
                empleado.dni = int.Parse(dr["dni"].ToString());
                empleado.email = dr["email"].ToString();
                usu.empleadoQuery = empleado;
            }
            dr.Close();
            cmd.Connection.Close();
            return usu;
        }

        public static ClienteEntidadQuery ConsultarUnClienteQuery(int idCliente)
        {
            ClienteEntidadQuery cli = new ClienteEntidadQuery();
            string query = @"SELECT c.idCliente, c.nombreCliente, c.apellidoCliente, c.nroDni, t.idTipoDNI
                             FROM Cliente c INNER JOIN TipoDNI t ON t.idTipoDNI = c.idTipoDNI
                             WHERE c.idCliente = @idCliente";

            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"idCliente", idCliente);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cli.idCliente = int.Parse(dr["idCliente"].ToString());
                cli.nombreCliente = dr["nombreCliente"].ToString();
                cli.apellidoCliente = dr["idCliente"].ToString();
                cli.nroDni = int.Parse(dr["nroDni"].ToString());
                cli.idTipoDNI = int.Parse(dr["idTipoDNI"].ToString());
                
            }
            dr.Close();
            cmd.Connection.Close();
            return cli;
        }

        public static List<RolEntidad> ConsultarRoles()
        {
            List<RolEntidad> listaRol = new List<RolEntidad>();
            string query = @"Select r.idRol, r.nombreRol From Rol r";

            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                RolEntidad rol = new RolEntidad();
                rol.idRol = int.Parse(dr["idRol"].ToString());
                rol.nombreRol = dr["nombreRol"].ToString();
                listaRol.Add(rol);
            }
            dr.Close();
            cmd.Connection.Close();
            return listaRol;
        }
     
        public static List<TipoDNIEntidad> DevolverTipDNI()
        {
            List<TipoDNIEntidad> listaTipoDNI = new List<TipoDNIEntidad>();
            string query = @"Select TD.idTipoDNI, TD.nombreTipoDNI from TipoDNI TD";

            SqlCommand cmd = new SqlCommand(query, obtenerBD());

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TipoDNIEntidad tipoDNI = new TipoDNIEntidad();
                tipoDNI.idTipoDNI = int.Parse(dr["idTipoDNI"].ToString());
                tipoDNI.nombreTipoDNI = dr["nombreTipoDNI"].ToString();
                listaTipoDNI.Add(tipoDNI);
            }
            dr.Close();
            cmd.Connection.Close();
            return listaTipoDNI;
        }

        public static bool ExisteUsuario( int idUsuario, string pass)
        {
            UsuarioEntidadQuery usu = new UsuarioEntidadQuery();

            string query = @"SELECT u.idUsuario, u.nombreUsuario, u.contrasena
                             FROM Usuario u 
                             WHERE u.idUsuario = @idUsuario and u.contrasena = @pass";

            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"idUsuario", idUsuario);
            cmd.Parameters.AddWithValue(@"pass", pass);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dr.Close();
                cmd.Connection.Close();
                return true;
            }
            dr.Close();
            cmd.Connection.Close();
            return false;
        }

        public static void ModificarContrasena(int idUsuario, string pass)
        {
            UsuarioEntidadQuery usu = new UsuarioEntidadQuery();

            string query = @"UPDATE Usuario Set   contrasena = @pass
                             WHERE idUsuario = @idUsuario";

            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"idUsuario", idUsuario);
            cmd.Parameters.AddWithValue(@"pass", pass);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
    }
}
