using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormApp
{
    public class TablaCRUD
    {
        public int id;
        public string tipo;
        public string nombre;
        public string marca;
        public int stock;
        public string caracteristica1;
        public string caracteristica2;

        public override string ToString()
        {
            return $"ID:{id} - TIPO:{tipo} - NOMBRE:{nombre} - MARCA:{marca} - STOCK:{stock} - CARACTERISTICA1:{caracteristica1} - CARACTERISTICA2:{caracteristica2}";
        }
    }
}
