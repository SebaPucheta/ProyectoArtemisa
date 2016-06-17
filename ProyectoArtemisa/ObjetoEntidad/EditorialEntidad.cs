using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EditorialEntidad
    {
        public int idEditorial { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string email { get; set; }
        public string nombreContacto { get; set; }
        public int idCiudadEditorial { get; set; }
    }
}
