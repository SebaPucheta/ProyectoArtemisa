using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EmpleadoEntidad
    {
        public int idEmpleado { get; set; }
        public string nombreEmpleado { get; set; }
        public string  apellidoNombre { get; set; }
        public int dni { get; set; }
        public int tipoDNI { get; set; }
        public string email { get; set; }
    }
}
