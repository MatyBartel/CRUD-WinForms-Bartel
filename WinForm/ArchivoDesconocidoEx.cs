using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase de Exception al encontrar un Archivo Desconocido.
    /// </summary>
    public class ArchivoDesconocidoException : Exception
    {
        /// <summary>
        /// Constructor con mensaje de Archivo desconocido donde luego se hara una accion.
        /// </summary>
        public ArchivoDesconocidoException() : 
            base("ERROR: ARCHIVO DESCONOCIDO O VACIO - Creando uno nuevo.")
        {
        }
    }
}
