using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProfesorEntidad
    {
        public string nombreProfesor { get; set; }
        public string apellidoProfesor { get; set; }
        public int idProfesor { get; set; }

        public int idMateria { get; set; }
        public ProfesorEntidad(){}
    }
}
