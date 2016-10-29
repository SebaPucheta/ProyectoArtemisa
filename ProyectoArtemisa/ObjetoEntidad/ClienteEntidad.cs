using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ClienteEntidad
    {
        public int idCliente { get; set; }
        public string nombreCliente { get; set; }
        public string apellidoCliente { get; set; }
        public int nroDni { get; set; }
        public int idTipoDNI { get; set; }
        public string email { get; set; }
        public List<CarreraEntidad> ListaCarreras { get; set; }
    }
}
