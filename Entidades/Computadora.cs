using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{    /// <summary>
     /// Clase publica Computadora que representa productos de tipo Computadora heredados de la Electronica.
     /// </summary>
    public class Computadora : Electronica
    {
        #region Atributos
        /// <summary>
        /// Establece la grafica de la computadora
        /// </summary>
        public string grafica;
        /// <summary>
        /// Establece la memoria Ram de la computadora
        /// </summary>
        public int memoriaRam;

        public string tipo;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por default.
        /// </summary>
        public Computadora() : base()
        {
            this.tipo = "COMPUTADORA";
            this.grafica = "Integrada";
            this.memoriaRam = 0;
        }
        public Computadora(string grafica) : this()
        {
            this.grafica = grafica;
        }
        public Computadora(string grafica, int memoriaRam) : this(grafica)
        {
            this.memoriaRam = memoriaRam;
        }
        public Computadora(string grafica, int memoriaRam, string tipo) : this(grafica,memoriaRam)
        {
            this.tipo = tipo;
        }
        public Computadora(string nombre,int stock,EMarcas marca ) : base(nombre,stock,marca)
        {
            this.tipo = "COMPUTADORA";
            this.grafica = "Integrada";
            this.memoriaRam = 0;
        }
        public Computadora(string nombre, int stock, EMarcas marca,string grafica) : this(nombre, stock, marca)
        {
            this.grafica = grafica;
        }
        public Computadora(string nombre, int stock, EMarcas marca, string grafica,int memoriaRam) : this(nombre, stock, marca,grafica)
        {
            this.memoriaRam=memoriaRam;
        }

        /// <summary>
        /// Constructor con todos los parametros de la base y la actual
        /// </summary>
        public Computadora(string nombre, int stock, EMarcas marca, string grafica, int memoriaRam, string tipo) : this(nombre, stock, marca, grafica, memoriaRam)
        {
            this.tipo = tipo;
        }
        #endregion

        #region Metodos
        public override void InformacionDetallada()
        {
            base.InformacionDetallada();
            Console.WriteLine($"Esta computadora cuenta con una GPU: {grafica} y una cantidad de Memoria RAM: {memoriaRam}GB");
        }
        public override void InformacionDetallada(string informacionAdicional)
        {
            base.InformacionDetallada();
            Console.WriteLine($"Esta computadora cuenta con una GPU: {grafica} y una cantidad de Memoria RAM: {memoriaRam}GB - Mas info: {informacionAdicional}");
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

        /// <summary>
        /// Sobrecarga de metodo InsertarDatoTabla para SQL a la hora de insertar los datos de este tipo.
        /// </summary>
        public override string InsertarDatoTabla()
        {
            return "insert into tabla_crud(tipo, nombre, marca, stock, caracteristica1, caracteristica2) values('" + this.tipo + "', '" + this.nombre + "', '" + this.marca + "', " + this.stock + ", '" + this.grafica + "', '" + this.memoriaRam.ToString() + "')";
        }
        #endregion

        #region Sobrecarga
        /// <summary>
        /// Sobrecarga ToString para mostrar los datos de esta computadora
        /// </summary>
        public override string ToString()
        {
            return $"-COMPUTADORA-   Nombre: {nombre} - Marca: {marca} - GPU: {grafica} - RAM: {memoriaRam}GB - Stock: {stock}" ;
        }

        public override bool Equals(object? obj)
        {
            Computadora computadora = obj as Computadora;
            return base.Equals(computadora) && computadora.memoriaRam == this.memoriaRam && computadora.grafica == this.grafica;
        }

        public static implicit operator string(Computadora c)
        {
            return c.grafica;
        }

        public static implicit operator int(Computadora c)
        {
            return c.memoriaRam;
        }
        #endregion
    }
}
