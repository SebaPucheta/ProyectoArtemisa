using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades

{
    public class ApunteEntidad
    {
        public int idApunte { get; set; }
        public string codigoBarraApunte { get; set; }
        public int stock { get; set; }
        public float precioApunte { get; set; }
        public int cantHoja { get; set; }
        public string nombreApunte { get; set; }
        public string descripcionApunte { get; set; }
        public int anoApunte { get; set; }
        public int idPrecioHoja { get; set; }
        public int idCategoria { get; set; }
        public int idTipoApunte { get; set; }
        public int idEditorial { get; set; }
        public int idEstado { get; set; }
        public int idProfesor { get; set; }
        public int idMateria { get; set; }
        
    }
}
