using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FacturaEntidadQuery: FacturaEntidad
    {
        public string nombreTipoPago  { get; set; }
        public string nombreEmpleado { get; set; }
        public string apellidoEmpleado { get; set; }
        public string nombreCompletoEmpleado  { get; set; }
        public string nombreCompletoCliente { get; set; }
        public string descripcionTipoPago { get; set; }
        public string descripcionEstadoPago { get; set; }
    }
}
