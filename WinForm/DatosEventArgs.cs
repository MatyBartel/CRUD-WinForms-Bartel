using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormApp
{
    /// <summary>
    /// Clase de evento heredada de EventArgs
    /// </summary>
    public class DatosEventArgs<T> : EventArgs
    {
        public T Datos { get; }

        public DatosEventArgs(T datos)
        {
            Datos = datos;
        }
    }
}
