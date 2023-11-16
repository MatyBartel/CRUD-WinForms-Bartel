using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Entidades.Computadora))]
    [XmlInclude(typeof(Entidades.Telefono))]
    [XmlInclude(typeof(Entidades.Consola))]
    /// <summary>
    /// Clase abstracta que representa productos electrónicos.
    /// </summary>
    public abstract class Electronica
    {
        #region Atributos
        /// <summary>
        /// Establece el nombre del producto electrónico.
        /// </summary>
        public string nombre;

        /// <summary>
        /// Establece la cantidad de stock disponible del producto electrónico.
        /// </summary>
        public int stock;

        /// <summary>
        /// Establece la marca del producto electrónico.
        /// </summary>
        public EMarcas marca;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor predeterminado de la clase Electronica/>.
        /// Inicializa los atributos con valores predeterminados.
        /// </summary>
        public Electronica()
            {
               this.nombre = "Sin Nombre";
               this.marca = EMarcas.Ninguna;
               this.stock = 0;
            }


        public Electronica(string nombre) : this()
            {
                this.nombre = nombre;
            }


        public Electronica(string nombre, int stock) : this(nombre)
            {
                this.stock = stock;
            }

        /// <summary>
        /// Constructor de la clase Electronica que permite establecer todos los atributos.
        /// </summary>
        /// <param name="nombre">El nombre del producto electrónico.</param>
        /// <param name="stock">La cantidad de stock disponible.</param>
        /// <param name="marca">La marca del producto.</param>
        public Electronica(string nombre, int stock, EMarcas marca) : this(nombre, stock)
            {
                this.marca = marca;
            }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo para mostrar una informacion detallada de este producto.
        /// </summary>
        public virtual void InformacionDetallada()
        {
            Console.WriteLine($"Nombre: {nombre} - Marca: {marca} - Stock: {stock} - Tipo: Electronica");
        }

        public virtual void InformacionDetallada(string informacionAdicional)
        {
            Console.WriteLine($"Nombre: {nombre} - Marca: {marca} - Stock: {stock} - Tipo: Electronica - Mas info: {informacionAdicional}");
        }

        /// <summary>
        /// Metodo abstracto para comprobar el stock
        /// </summary>
        public abstract bool ComprobarDisponibilidad();

        public abstract bool ComprobarDisponibilidad(int cantidadMinima);

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Convierte el objeto Electronica en una representación de cadena que contiene el nombre, la marca y el stock del producto.
        /// </summary>
        /// <returns>Una cadena que representa el producto electrónico.</returns>
        public override string ToString()
        {
            return $"{this.nombre} {this.marca} {this.stock}";
        }

        /// <summary>
        /// Determina si el objeto actual es igual a otro objeto.
        /// </summary>
        /// <param name="obj">El objeto a comparar con el objeto actual.</param>
        /// <returns>
        /// <c>true</c> si el objeto actual es igual al objeto especificado;
        /// de lo contrario, <c>false</c>.
        /// </returns>
        public override bool Equals(object? obj)
        {
            Electronica producto = obj as Electronica;  
            return producto is not null && this == producto ;
        }

        /// <summary>
        /// Compara dos objetos de tipo Electronica para determinar si son iguales.
        /// </summary>
        /// <param name="p1">El primer objeto Electronica a comparar.</param>
        /// <param name="p2">El segundo objeto Electronica a comparar.</param>
        /// <returns>
        /// <c>true</c> si los objetos son iguales, <c>false</c> en caso contrario.
        /// </returns>
        public static bool operator ==(Electronica p1, Electronica p2)
        {
            if (ReferenceEquals(p1, p2))
            {
                return true;
            }

            if (ReferenceEquals(p1, null) || ReferenceEquals(p2, null))
            {
                return false;
            }

            return p1.nombre == p2.nombre && p1.marca == p2.marca && p1.stock == p2.stock;
        }

        public static bool operator !=(Electronica p1, Electronica p2)
        {
            return !(p1 == p2);
        }


        public static implicit operator string(Electronica p)
        {
            return p.nombre;
        }

        public static implicit operator int(Electronica p)
        {
            return p.stock;
        }
        #endregion
    }
}