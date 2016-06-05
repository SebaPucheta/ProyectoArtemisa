using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoEntidad
{
    public class Apunte
    {
        public string codigoBarraApunte { get; set; }
        public int stock { get; set; }
        public double precio { get; set; }
        public int cantHoja { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int ano { get; set; }
        public int idPrecioHoja { get; set; }
        public int idCategoria { get; set; }
        public int idTipoApunte { get; set; }
        public int idEditorial { get; set; }
        public int idEstado { get; set; }
        public int idProfesor { get; set; }
    }
}
