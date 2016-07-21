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
        private static List<OrdenImpresionEntidadQuery> ordenesImpresion;

        public static List<OrdenImpresionEntidadQuery> OrdenesImpresion
        {
            get { return ColeccionOrdenImpresion.ordenesImpresion; }
        }

        static public void Inicializar()
        {
            ordenesImpresion = new List<OrdenImpresionEntidadQuery>();
        }

        static public void Inicializar(List<OrdenImpresionEntidadQuery> listaOrdenImpresion)
        {
            ordenesImpresion = listaOrdenImpresion;
        }

        static public void GuardarOrdenImpresion(OrdenImpresionEntidadQuery ordenImpresion)
        {
            ordenesImpresion.Add(ordenImpresion);
        }

        static public void EliminarOrdenImpresion(int indice)
        {
            ordenesImpresion.RemoveAt(indice);
        }
    }
}




