using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase publica telefono heredada de Electronica, representa todo producto tipo Telefono
    /// </summary>
    public class Telefono : Electronica
    {
        #region Atributos
        /// <summary>
        /// Representa la pantalla del telefono
        /// </summary>
        public string pantalla;

        /// <summary>
        /// Representa el modelo del telefono  EJ: S23 Plus
        /// </summary>
        public string modelo;

        public string tipo;

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por default.
        /// </summary>
        public Telefono()
        {
            this.tipo = "TELEFONO";
            this.pantalla = "Ninguna";
            this.modelo = "Ninguno";
        }
        public Telefono(string pantalla) : this()
        {
            this.pantalla = pantalla;
        }
        public Telefono(string pantalla, string modelo) : this(pantalla)
        {
            this.modelo = modelo;
        }

        public Telefono(string pantalla, string modelo,string tipo) : this(pantalla,modelo)
        {
            this.tipo = tipo;
        }

        public Telefono(string nombre, int stock, EMarcas marca) : base(nombre, stock, marca)
        {
            this.tipo = "TELEFONO";
            this.pantalla = "Ninguna";
            this.modelo = "Ninguno";
        }
        public Telefono(string nombre, int stock, EMarcas marca, string pantalla) : this(nombre, stock, marca)
        {
            this.pantalla = pantalla;
        }
        /// <summary>
        /// Constructor con todos los parametros de la base y la actual.
        /// </summary>
        public Telefono(string nombre, int stock, EMarcas marca, string pantalla, string modelo) : this(nombre, stock, marca, pantalla)
        {
            this.modelo = modelo;
        }

        public Telefono(string nombre, int stock, EMarcas marca, string pantalla, string modelo,string tipo) : this(nombre, stock, marca, pantalla,modelo)
        {
            this.tipo = tipo;
        }
        #endregion

        #region Metodos
        public override void InformacionDetallada()
        {
            base.InformacionDetallada();
            Console.WriteLine($"Este celular {modelo} cuenta con una pantalla: {pantalla}");
        }
        public override void InformacionDetallada(string informacionAdicional)
        {
            base.InformacionDetallada();
            Console.WriteLine($"Este celular {modelo} cuenta con una pantalla: {pantalla}  -  Mas info: {informacionAdicional}");
        }

        public override bool ComprobarDisponibilidad()
        {
            if (base.stock > 0)
            {
                return true; // Hay disponibles.
            }
            else
            {
                return false; // No hay disponibles.
            }
        }
        public override bool ComprobarDisponibilidad(int cantidadMinima)
        {
            if (base.stock >= cantidadMinima)
            {
                return true; // Hay al menos 'cantidadMinima' disponibles
            }
            else
            {
                return false; // No hay suficientes
            }
        }

        public override string InsertarDatoTabla()
        {
            return "insert into tabla_crud(tipo, nombre, marca, stock, caracteristica1, caracteristica2) values('" + this.tipo + "', '" + this.nombre + "', '" + this.marca + "', " + this.stock + ", '" + this.pantalla + "', '" + this.modelo + "')";
        }


        #endregion

        #region Sobrecarga
        /// <summary>
        /// Sobrecarga ToString para mostrar datos del producto.
        /// </summary>
        public override string ToString()
        {
            return $"-TELEFONO-    Nombre: {nombre} - Marca: {marca} - Pantalla: {pantalla} - Modelo: {modelo} - Stock: {stock}";

        }

        public override bool Equals(object? obj)
        {
            
            Telefono tel = obj as Telefono;
            return base.Equals(tel) && tel.pantalla == this.pantalla && tel.modelo == this.modelo;
        }


        public static implicit operator string(Telefono t)
        {
            return $"{t.pantalla} {t.modelo}";
        }
        #endregion
    }
}
