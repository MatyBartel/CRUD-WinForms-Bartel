using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormApp
{
    public class DatosLoginEventArgs : EventArgs
    {
        public string Mensaje { get; }

        public DatosLoginEventArgs(string mensaje)
        {
            Mensaje = mensaje;
        }
    }
}
