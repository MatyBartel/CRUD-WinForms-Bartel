using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormApp
{
    public class DatosEventArgs<T> : EventArgs
    {
        public T Datos { get; }

        public DatosEventArgs(T datos)
        {
            Datos = datos;
        }
    }
}
