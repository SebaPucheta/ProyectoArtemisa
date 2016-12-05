using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;
namespace BaseDeDatos
{
    public class IngresoLibroDao : Conexion
    {
        public static List<IngresoLibroEntidadQuery> DevolverIngresoLibroPorFiltro( string fechaDesde, string fechaHasta, string nombreUsuario, string idProveedor)
        {
            if (idProveedor.Equals("0")) 
            { idProveedor = ""; }
            string query = @"select il.fecha, il.idIngresoLibro, p.nombreProveedor, il.total,  e.nombreEmpleado, e.apellidoEmpleado
                                        from IngresoLibro il inner join Proveedor p 
					                                        on p.idProveedor = il.idProveedor
					                                        inner join Usuario u
					                                        on u.idUsuario = il.idUsuario
					                                        inner join Empleado e
					                                        on e.idEmpleados = u.idCliente
					                                        inner join Rol r
					                                        on u.idRol = r.idRol
					
                                        WHERE il.fecha BETWEEN convert(datetime, '@desde', 103)
		                                        and   convert(datetime, '@hasta', 103)
		                                        and p.idProveedor like  @idProveedor
		                                        and e.nombreEmpleado like @nombre
		                                        and e.apellidoEmpleado like @apellido";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"desde", fechaDesde );
            cmd.Parameters.AddWithValue(@"hasta", fechaHasta );
            cmd.Parameters.AddWithValue(@"idProveedor", "%" + idProveedor + "%");
            cmd.Parameters.AddWithValue(@"nombre", "%" + nombreUsuario + "%");
            cmd.Parameters.AddWithValue(@"apellido", "%" + nombreUsuario + "%");
            SqlDataReader dr = cmd.ExecuteReader();
            List<IngresoLibroEntidadQuery> listaIngreso = new List<IngresoLibroEntidadQuery>();
            while (dr.Read())
            {
                IngresoLibroEntidadQuery ingreso = new IngresoLibroEntidadQuery();
                ingreso.nombreProveedor = dr["nombreProveedor"].ToString();
                ingreso.apellidoCliente = dr["apellidoEmpleado"].ToString();
                ingreso.nombreCliente = dr["nombreEmpleado"].ToString();
                ingreso.total = float.Parse(dr["total"].ToString());
                ingreso.idIngresoLibro = int.Parse(dr["idIngresoLibro"].ToString());
                ingreso.fecha = DateTime.Parse(dr["fecha"].ToString());
                listaIngreso.Add(ingreso);
            }
            dr.Close();
            cmd.Connection.Close();
            return listaIngreso;
        }
        public static List<DetalleIngresoLibroEntidadQuery> DevolverDetalleIngresoLibroPorId(int idIngresoLibro)
        {
            string query = @"select dil.cantidad, dil.idDetalleIngresoLibro, dil.idLibro, dil.precioUnitario, l.nombreLibro
                                    from DetalleIngresoLibro dil inner join Libro l
				                                    on dil.idLibro = l.idLibro
                                    WHERE dil.idIngresoLibro = @idIngresoLibro";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"idIngresoLibro", idIngresoLibro);
            SqlDataReader dr = cmd.ExecuteReader();
            List<DetalleIngresoLibroEntidadQuery> listaDetalleIngreso = new List<DetalleIngresoLibroEntidadQuery>();
            while (dr.Read())
            {
                DetalleIngresoLibroEntidadQuery DetalleIngreso = new DetalleIngresoLibroEntidadQuery();
                DetalleIngreso.idDetalleIngresoLibro = int.Parse( dr["idDetalleIngresoLibro"].ToString());
                DetalleIngreso.cantidad =int.Parse( dr["cantidad"].ToString());
                DetalleIngreso.idLibro =int.Parse( dr["idLibro"].ToString());
                DetalleIngreso.precioUnitario = float.Parse(dr["precioUnitario"].ToString());
                DetalleIngreso.nombreLibro = dr["nombreLibro"].ToString();
                
                listaDetalleIngreso.Add(DetalleIngreso);
            }
            dr.Close();
            cmd.Connection.Close();
            return listaDetalleIngreso;
        }
    }
}
