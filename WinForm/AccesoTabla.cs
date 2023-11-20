using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormApp
{
    public class AccesoTabla
    {
        private SqlConnection conexion;
        private static string cadena_conexion;

        static AccesoTabla()
        {
            AccesoTabla.cadena_conexion = Properties.Resources.miConexion;
        }

        public AccesoTabla()
        {
            this.conexion = new SqlConnection(AccesoTabla.cadena_conexion);
        }
    }
}
