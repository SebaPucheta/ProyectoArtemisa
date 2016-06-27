using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class LibroEntidadQuery : LibroEntidad
    {
        public string nombreEditorial { get; set; }
        public string nombreEstado { get; set; }
        public string nombreMateria { get; set; }
        public List<CarreraEntidad> listaCarreras { get; set; }
        public string nombreFacultad { get; set; }
        public string nombreUniversidad { get; set; }
    }
}
