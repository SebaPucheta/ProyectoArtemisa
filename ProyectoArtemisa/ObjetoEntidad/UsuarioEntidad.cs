using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class UsuarioEntidad
    {
        public string nombreUsuario { get; set; }
        public int idUsuario { get; set; }
        public string contrasena { get; set; }
        public int idCliente { get; set; }
    }
}
