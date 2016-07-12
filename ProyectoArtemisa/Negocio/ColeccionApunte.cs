using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;

namespace Negocio
{
    public class ColeccionApunte
    {
        private static List<ApunteEntidad> apuntes;

        public static List<ApunteEntidad> Apunte
        {
            get { return ColeccionApunte.apuntes; }
        }

        static public void Inicializar()
        {
            apuntes = new List<ApunteEntidad>();
        }

        static public void Inicializar(List<ApunteEntidad> listaApunte)
        {
            apuntes = listaApunte;
        }

        static public void GuardarDatalleFactura(ApunteEntidad apunte)
        {
            apuntes.Add(apunte);
        }

        static public void EliminarDetalleFactura(int indice)
        {
            apuntes.RemoveAt(indice);
        }
    }
}
