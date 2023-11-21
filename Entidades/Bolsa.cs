using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    /// <summary>
    /// Representa una colección de productos de electronica.
    /// </summary>
    public class Bolsa
    {
        private List<Electronica> elementos;

        #region Constructor
        /// <summary>
        /// Constructor de la clase Bolsa que inicializa una nueva instancia.
        /// </summary>
        public Bolsa()
        {
            this.elementos = new List<Electronica>();   
        }
        /// <summary>
        /// Obtiene la lista de productos en la bolsa.
        /// </summary>
        public List<Electronica> productos
        {
            get { return this.elementos; }
            set {  this.elementos = value; }
        }

        #endregion

        #region Sobrecarga Operadores
        /// <summary>
        /// Sobrecarga del operador '+' para agregar un producto a la bolsa.
        /// </summary>
        /// <param name="coleccion">La bolsa en la que se va a agregar el producto.</param>
        /// <param name="elemento">El producto que se va a agregar a la bolsa.</param>
        /// <returns>La bolsa actualizada con el producto agregado.</returns>
        public static Bolsa operator +(Bolsa coleccion, Electronica elemento)
        {
            coleccion.elementos.Add(elemento);
            return coleccion;
        }
        /// <summary>
        /// Sobrecarga del operador '-' para eliminar un producto de la bolsa.
        /// </summary>
        /// <param name="coleccion">La bolsa de la que se va a eliminar el producto.</param>
        /// <param name="elemento">El producto que se va a eliminar de la bolsa.</param>
        /// <returns>La bolsa actualizada con el producto eliminado.</returns>
        public static Bolsa operator -(Bolsa coleccion, Electronica elemento)
        {
            coleccion.elementos.Remove(elemento);
            return coleccion;
        }

        /// <summary>
        /// Sobrecarga del operador '==' para verificar si un producto está en la bolsa.
        /// </summary>
        /// <param name="coleccion">La bolsa en la que se va a verificar la presencia del producto.</param>
        /// <param name="elemento">El producto que se va a verificar.</param>
        /// <returns>Verdadero si el producto está en la bolsa, falso en caso contrario.</returns>
        public static bool operator ==(Bolsa coleccion, Electronica elemento)
        {
            return coleccion.elementos.Contains(elemento);
        }

        /// <summary>
        /// Sobrecarga del operador '!=' para verificar si un producto no está en la bolsa.
        /// </summary>
        /// <param name="coleccion">La bolsa en la que se va a verificar la ausencia del producto.</param>
        /// <param name="elemento">El producto que se va a verificar.</param>
        /// <returns>Verdadero si el producto no está en la bolsa, falso en caso contrario.</returns>
        public static bool operator !=(Bolsa coleccion, Electronica elemento)
        {
            return !coleccion.elementos.Contains(elemento);
        }
        #endregion

        #region Metodos Ordenamiento
        /// <summary>
        /// Ordena los productos en la bolsa por stock en orden ascendente o descendente.
        /// </summary>
        /// <param name="ascendente">Indica si se debe ordenar en orden ascendente (true) o descendente (false).</param>
        public void OrdenarProductosPorStock()
        {
            elementos = elementos.OrderByDescending(e => e.stock).ToList();
        }

        public void OrdenarProductosPorStock(bool ascendente)
        {
            elementos = elementos.OrderByDescending(e => e.stock).Reverse().ToList();
        }
        /// <summary>
        /// Ordena los productos en la bolsa por nombre en orden ascendente o descendente.
        /// </summary>
        /// <param name="ascendente">Indica si se debe ordenar en orden ascendente (true) o descendente (false).</param>
        public void OrdenarPorNombre()
        {
            elementos = elementos.OrderByDescending(e => e.nombre).ToList();
        }

        public void OrdenarPorNombre(bool ascendente)
        {
            elementos = elementos.OrderByDescending(e => e.nombre).Reverse().ToList();
        }
        #endregion
    }
}
