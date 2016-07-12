using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;

namespace Negocio
{
    public class ColeccionFactura
    {
        private static List<FacturaEntidad> facturas;

        public static List<FacturaEntidad> Facturas
        {
            get { return ColeccionFactura.facturas; }
        }

        static public void Inicializar()
        {
            facturas = new List<FacturaEntidad>();
        }

        static public void Inicializar(List<FacturaEntidad> listaFacturas)
        {
            facturas = listaFacturas;
        }

        static public void GuardarFactura(FacturaEntidad factura)
        {
            facturas.Add(factura);
        }

        static public void EliminarFactura(int indice)
        {
            facturas.RemoveAt(indice);
        }
    }
}
