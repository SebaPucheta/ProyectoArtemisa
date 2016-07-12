using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
namespace Negocio
{
    public class ColeccionDetalleFactura
    {
        private static List<DetalleFacturaEntidad> detallesFactura;

        public static List<DetalleFacturaEntidad> DetallesFactura
        {
            get { return ColeccionDetalleFactura.detallesFactura; }
        }

        static public void Inicializar()
        {
            detallesFactura = new List<DetalleFacturaEntidad>();
        }

        static public void Inicializar(List<DetalleFacturaEntidad> listaDetallesFactura)
        {
            detallesFactura = listaDetallesFactura;
        }

        static public void GuardarDatalleFactura(DetalleFacturaEntidad detalleFactura)
        {
            detallesFactura.Add(detalleFactura);
        }

        static public void EliminarDetalleFactura(int indice)
        {
            detallesFactura.RemoveAt(indice);
        }
    }
}
