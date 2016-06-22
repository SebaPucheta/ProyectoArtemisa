using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    //Esta clase mantiene una pila que me ingica que form han sido abiertos y en que orden.
    //Para que cuando tenga que cerrar un form sepa que form fue el anterior, para abrirlo.
    public static class PilaForms
    {
        public static Stack<string> pila { set; get; }

        public static void Inicializar()
        {
            pila =new Stack<string>();
        }

        public static void AgregarForm(string nombreForm)
        {
            pila.Push(nombreForm);
        }

        public static string DevolverForm()
        {
            return pila.Pop();
        }
    }
}
