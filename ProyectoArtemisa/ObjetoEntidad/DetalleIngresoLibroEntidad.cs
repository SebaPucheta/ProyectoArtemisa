﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class DetalleIngresoLibroEntidad
    {
        public int idDetalleIngresoLibro { get; set; }
        public int idIngresoLibro { get; set; }
        public int idLibro { get; set; }
        public int cantidad { get; set; }
    }
}
