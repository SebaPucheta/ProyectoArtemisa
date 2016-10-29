using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class UsuarioEntidadQuery : UsuarioEntidad
    {
        public ClienteEntidadQuery clienteQuery { get; set; }
        public string nombreRol { get; set; }
        public string nombreTipoDNI { get; set; }

    }
}
