using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using  Entidades;

namespace Negocio
{
    public class ColeccionOrdenImpresion
    {
        private static List<OrdenImpresionEntidad> ordenesImpresion;

        public static List<OrdenImpresionEntidad> Impresiones
        {
            get { return ColeccionOrdenImpresion.ordenesImpresion; }
        }

        static public void Inicializar()
        {
            ordenesImpresion = new List<OrdenImpresionEntidad>();
        }

        static public void Inicializar(List<OrdenImpresionEntidad> listaOrdenImpresion)
        {
            ordenesImpresion = listaOrdenImpresion;
        }

        static public void GuardarOrdenImpresion(OrdenImpresionEntidad ordenImpresion)
        {
            ordenesImpresion.Add(ordenImpresion);
        }

        static public void EliminarOrdenImpresion(int indice)
        {
            ordenesImpresion.RemoveAt(indice);
        }
    }
}




