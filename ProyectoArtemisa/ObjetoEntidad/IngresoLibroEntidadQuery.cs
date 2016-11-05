using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class IngresoLibroEntidadQuery : IngresoLibroEntidad
    {
        public string nombreProveedor { get; set; }
        public string nombreCliente { get; set; }
        public string apellidoCliente { get; set; }
    }
}
