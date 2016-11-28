using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FacturaEntidad
    {
        public int idFactura { get; set; }
        public DateTime  fecha { get; set; }
        public float total { get; set; }
        public int idUsuarioCliente { get; set; }
        public int idUsuarioEmpleado { get; set; }
        public List<DetalleFacturaEntidad> listaDetalleFactura { get; set; }
        public int idTipoPago { get; set; }
        public int idEstadoPago { get; set; }
    }
}
