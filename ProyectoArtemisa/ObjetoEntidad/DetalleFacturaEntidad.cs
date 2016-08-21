using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleFacturaEntidad
    {
        public int idDetalleFactura { get; set; }
        public int idItem { get; set; }
        public int cantidad { get; set; }
        public float subtotal { get; set; }
    }
}
