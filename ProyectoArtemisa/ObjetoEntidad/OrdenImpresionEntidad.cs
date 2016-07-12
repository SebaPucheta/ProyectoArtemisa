using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class OrdenImpresionEntidad
    {
        public DateTime fecha { get; set; }
        public int idOrdenImpresion { get; set; }
        public int idApunte { get; set; }
        public int cantidad { get; set; }
        public int idEstadoOrden { get; set; }
    }
}
