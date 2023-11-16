using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public class ArchivoDesconocidoException : Exception
    {
        public ArchivoDesconocidoException() : 
            base("ERROR: ARCHIVO DESCONOCIDO O VACIO - Creando uno nuevo.")
        {
        }
    }
}
