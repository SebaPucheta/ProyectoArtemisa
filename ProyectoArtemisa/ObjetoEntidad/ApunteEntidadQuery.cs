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
        public string nombreCategoria { get; set; }
        public string nombreTipoApunte { get; set; }
        public string nombreEditorial { get; set; }
        public string nombreEstado { get; set; }
        public string nombreProfesor { get; set; }
        public string apellidoProfesor { get; set; }
        public string nombreMateria { get; set; }
        
        
    }
}
    