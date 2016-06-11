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
        protected static SqlConnection obtenerBD()
        {
            string stringConexion = "Data Source=192.168.1.12,49170;Initial Catalog=EDUCOM;Persist Security Info=True;User ID=sa;Password=artemisa";
            SqlConnection con = new SqlConnection(stringConexion);
            con.Open();
            return con;
        }
    }
}
