using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class LibroEntidad
    {
        public int idLibro { get; set; }
        public string codigoBarraLibro { get; set; }
        public string nombreLibro { get; set; }
        public string autorLibro { get; set; }
        public string descripcionLibro { get; set; }
        public int stock { get; set; }
        public int cantidadHojasLibro { get; set; }
        public float precioLibro { get; set; }
        public int idEditorial { get; set; }
        public int idEstado { get; set; }

    }
}
