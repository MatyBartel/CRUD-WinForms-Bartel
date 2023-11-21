using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase publica Consola que representa productos de tipo Consola heredados de la Electronica.
    /// </summary>
    public class Consola : Electronica
    {
        #region Atributos
        /// <summary>
        /// Establece la generacion de la consola Ej: Play5
        /// </summary>
        public string generacion;
        /// <summary>
        /// Establece el almacenamiento de la consola
        /// </summary>
        public int almacenamiento;

        public string tipo;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por default.
        /// </summary>
        public Consola() : base()
        {
            this.tipo = "CONSOLA";
            this.generacion = "Sin Generacion";
            this.almacenamiento = 0;
        }
        public Consola(string generacion) : this()
        {
            this.generacion = generacion;
        }
        public Consola(string generacion,int almacenamiento) : this(generacion)
        {
            this.almacenamiento = almacenamiento;
        }

        public Consola(string generacion, int almacenamiento,string tipo) : this(generacion,almacenamiento)
        {
            this.tipo = tipo;
        }

        public Consola(string nombre, int stock, EMarcas marca) : base(nombre, stock, marca)
        {
            this.tipo = "CONSOLA";
            this.generacion = "Sin Generacion";
            this.almacenamiento = 0;
        }
        public Consola(string nombre, int stock, EMarcas marca, string generacion) : this(nombre, stock, marca)
        {
            this.generacion = generacion;
        }
        public Consola(string nombre, int stock, EMarcas marca, string generacion, int almacenamiento) : this(nombre, stock, marca, generacion)
        {
            this.almacenamiento = almacenamiento;
        }

        /// <summary>
        /// Constructor con todos los parametros de la actual y la base.
        /// </summary>
        public Consola(string nombre, int stock, EMarcas marca, string generacion, int almacenamiento, string tipo) : this(nombre, stock, marca, generacion,almacenamiento)
        {
            this.tipo = tipo;
        }
        #endregion

        #region Metodos
        public override void InformacionDetallada()
        {
            base.InformacionDetallada();
            Console.WriteLine($"Esta es una {generacion} cuenta con un almacenamiento de: {almacenamiento}GB");
        }

        public override void InformacionDetallada(string informacionAdicional)
        {
            base.InformacionDetallada();
            Console.WriteLine($"Esta es una {generacion} cuenta con un almacenamiento de: {almacenamiento}GB - Mas info: {informacionAdicional}");
        }

        public override bool ComprobarDisponibilidad()
        {
            if (base.stock > 0)
            {
                return true; // Hay consolas disponibles.
            }
            else
            {
                return false; // No hay consolas disponibles.
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
        #endregion

        #region Sobrecarga
        /// <summary>
        /// Sobrecarga ToString para mostrar datos del producto.
        /// </summary>
        public override string ToString()
        {
            return $"-CONSOLA-    Nombre: {nombre} - Marca: {marca} - Generacion: {generacion} - Almacenamiento: {almacenamiento}GB - Stock: {stock}";

        }

        public override bool Equals(object? obj)
        {
            Consola console = obj as Consola;
            return base.Equals(console) && console.almacenamiento == this.almacenamiento && console.generacion == this.generacion;
        }

        public static implicit operator string(Consola c)
        {
            return c.generacion;
        }

        public static implicit operator int(Consola c)
        {
            return c.almacenamiento;
        }

        public override string InsertarDatoTabla()
        {
            return "insert into tabla_crud(tipo, nombre, marca, stock, caracteristica1, caracteristica2) values('" + this.tipo + "', '" + this.nombre + "', '" + this.marca + "', " + this.stock + ", '" + this.generacion + "', '" + this.almacenamiento.ToString() + "')";
        }
        #endregion
    }
}
