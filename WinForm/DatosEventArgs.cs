using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormApp
{
    public class DatosEventArgs : EventArgs
    {
        public string Mensaje { get; }

        public DatosEventArgs(string mensaje)
        {
            Mensaje = mensaje;
        }
    }
}
