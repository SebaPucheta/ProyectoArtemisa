using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Negocio
{
    public class ColeccionEditorialesProveedores
    {
        private static List<EditorialEntidad> editoriales;

        public static List<EditorialEntidad> Editoriales
        {
            get { return ColeccionEditorialesProveedores.editoriales; }
        }

        static public bool VerificarExistencia(EditorialEntidad edi)
        {
            return editoriales.Contains(edi);
        }

        static public void Inicializar()
        {
            editoriales = new List<EditorialEntidad>();
        }

        static public void Inicializar(List<EditorialEntidad> listaEditoriales)
        {
            editoriales = listaEditoriales;
        }

        static public void AgregarEditorial(EditorialEntidad editorial)
        {
            editoriales.Add(editorial);
        }

        static public void EliminarEditorial(int indice)
        {
            editoriales.RemoveAt(indice);
        }

    }
}
