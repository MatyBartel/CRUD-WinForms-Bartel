using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WinFormApp
{
    /// <summary>
    /// Clase usuario que tendra los datos de este para tomarlos del json.
    /// </summary>
    public class Usuario
    {
        #region Atributos/Propiedades
        public string apellido { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        public string perfil { get; set; }
        #endregion

        #region Metodo
        /// <summary>
        /// Lista de usuarios que se conseguiran de la deserializacion del archivo JSON.
        /// </summary>
        public List<Usuario> ObtenerUsuariosDesdeJSON(string rutaArchivo)
        {
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                if (File.Exists(rutaArchivo))
                {
                    string contenidoJSON = File.ReadAllText(rutaArchivo);

                    usuarios = JsonSerializer.Deserialize<List<Usuario>>(contenidoJSON);
                }
                else
                {
                    Console.WriteLine("El archivo JSON de usuarios no existe.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar usuarios desde JSON: " + ex.Message);
            }

            return usuarios;
        }
        #endregion
    }
}
