using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class IngresoLibroEntidad
    {
        public int idIngresoLibro { get; set; }
        public DateTime fecha { get; set; }
        public int idProveedor { get; set; }
        public float total { get; set; }
        public int idUsuario { get; set; }
    }
}
