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
        public static void RegistrarUsuario(UsuarioEntidad user, ClienteEntidad cli)
        {
            SqlConnection cn = obtenerBD();
            SqlTransaction trans = cn.BeginTransaction();
            try
            {
                string consulta = @"INSERT INTO Cliente (nombreCliente, apellidoCliente, nroDni, idTipoDNI) VALUES (@nom, @ape, @dni, @tipoDni); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(consulta, cn, trans);
                cmd.Parameters.AddWithValue(@"nom", cli.nombreCliente);
                cmd.Parameters.AddWithValue(@"ape", cli.apellidoCliente);
                cmd.Parameters.AddWithValue(@"dni", cli.nroDni);
                cmd.Parameters.AddWithValue(@"tipoDni", cli.idTipoDNI);
                cli.idCliente = Convert.ToInt32(cmd.ExecuteScalar());

                consulta = @"INSERT INTO Usuario (nombreUsuario, contrasena, idCliente) VALUES (@usuario, @pass, @idCli)";
                cmd = new SqlCommand(consulta, cn, trans);
                cmd.Parameters.AddWithValue("@usuario", user.nombreUsuario);
                cmd.Parameters.AddWithValue("@pass", user.contrasena);
                cmd.Parameters.AddWithValue("@idCli", cli.idCliente);
                cmd.ExecuteNonQuery();
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


    }
}
