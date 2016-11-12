using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace BaseDeDatos
{
    public class Conexion
    {
        /// <summary> obtenerBD es un método de la clase Conexion
        /// para abrir la conexion con la base de datos
        /// </summary>
        /// <returns>SqlConnection con la base de datos abierta</returns>
        protected static SqlConnection obtenerBD()
        {

            string stringConexion = @"Data Source=DESKTOP-AOAFIPR\SQLEXPRESS;Initial Catalog=ProyectoArtemisa;Integrated Security=True";
            SqlConnection con = new SqlConnection(stringConexion);
            con.Open();
            return con;
        }
    }
}
