using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class LibroEntidad
    {
        public string codigoBarraLibro { get; set; }
        public string nombre { get; set; }
        public string autor { get; set; }
        public string descripcion { get; set; }
        public int stock { get; set; }
        public int cantidadHojas { get; set; }
        public float precioLibro { get; set; }
        public int idEditorial { get; set; }
        public int idEstado { get; set; }

    }
}
