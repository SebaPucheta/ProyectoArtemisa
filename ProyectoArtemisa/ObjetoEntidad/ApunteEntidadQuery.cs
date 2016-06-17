using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ApunteEntidadQuery : ApunteEntidad
    {
        //idPrecioHoja
        //idCategoria
        //idTipoApunte
        //idEditorial
        //idEstado
        //idProfesor

        public float precioHoja { get; set; }
        public string categoria { get; set; }
        public string tipoApunte { get; set; }
        public string editorial { get; set; }
        public string estado { get; set; }
        public string profesor { get; set; }
        
    }
}
