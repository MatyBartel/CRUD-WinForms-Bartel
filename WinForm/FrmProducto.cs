using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormApp
{
    public partial class FrmProducto : Form,ILimpiador
    {
        #region Atributos
        public delegate void DatosIncompletosEventHandler(object sender, DatosEventArgs<string> e);
        public delegate void InformacionProductoEliminadaEventHandler(object sender, DatosEventArgs<string> e);
        public event InformacionProductoEliminadaEventHandler InformacionProductoEliminada;
        public event DatosIncompletosEventHandler DatosIncompletos;
        /// <summary>
        /// Atributo del form principal.
        /// </summary>
        private FrmCRUD frmCRUD;
        /// <summary>
        /// Atributo para editar un producto.
        /// </summary>
        private Electronica productoAEditar;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor inicial para inicializar en posicion y cambiar los valores del label para no poder escribir.
        /// </summary>
        public FrmProducto(Bolsa bolsa, FrmCRUD frmCrud)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.frmCRUD = frmCrud;
            CambiarValoresLabel();
        }

        public FrmProducto(Computadora producto)
        {
            InitializeComponent();

            productoAEditar = producto;
            cmbProductos.Text = "Computadora";
            txtNombre.Text = producto.nombre;
            cmbMarca.Text = producto.marca.ToString();
            txtStock.Text = producto.stock.ToString();
            txtAtributo1.Text = producto.grafica;
            txtAtributo2.Text = producto.memoriaRam.ToString();
        }
        public FrmProducto(Telefono producto)
        {
            InitializeComponent();

            productoAEditar = producto;
            cmbProductos.Text = "Telefono";
            txtNombre.Text = producto.nombre;
            cmbMarca.Text = producto.marca.ToString();
            txtStock.Text = producto.stock.ToString();
            txtAtributo1.Text = producto.pantalla;
            txtAtributo2.Text = producto.modelo;
        }
        /// <summary>
        /// Constructores de cada clase para asi poder asignar valores.
        /// </summary>
        public FrmProducto(Consola producto)
        {
            InitializeComponent();

            productoAEditar = producto;
            cmbProductos.Text = "Consola";
            txtNombre.Text = producto.nombre;
            cmbMarca.Text = producto.marca.ToString();
            txtStock.Text = producto.stock.ToString();
            txtAtributo1.Text = producto.generacion;
            txtAtributo2.Text = producto.almacenamiento.ToString();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo para establecer los valores de txt en Falso asi no escribir hasta que se elija un tipo de producto.
        /// </summary>
        private void CambiarValoresLabel()
        {
            string label1 = "";
            string label2 = "";
            txtAtributo1.Enabled = false;
            txtAtributo2.Enabled = false;
            string tipoSeleccionado = cmbProductos.Text;

            switch (tipoSeleccionado)
            {
                case "Computadora":
                    label1 = "Grafica";
                    label2 = "Ram";
                    txtAtributo1.Enabled = true;
                    txtAtributo2.Enabled = true;
                    break;
                case "Telefono":
                    label1 = "Pantalla";
                    label2 = "Modelo";
                    txtAtributo1.Enabled = true;
                    txtAtributo2.Enabled = true;
                    break;
                case "Consola":
                    label1 = "Generacion";
                    label2 = "Almacenamiento";
                    txtAtributo1.Enabled = true;
                    txtAtributo2.Enabled = true;
                    break;

            }
            lblAtributo1.Text = label1;
            lblAtributo2.Text = label2;

        }

        /// <summary>
        /// Funcion para que al cambiar el indice del comboBoxProductos se cambien los label.
        /// </summary>
        private void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CambiarValoresLabel();
        }

        /// <summary>
        /// Funcion para que al aceptar valide los datos tomados se compare si este se esta editando o no, si no se esta editando se crea un nuevo, si no se sobreescriben los datos.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            #region Validaciones
            try
            {
                string nombre = this.txtNombre.Text;
                string nombreMarca = this.cmbMarca.SelectedItem?.ToString();
                EMarcas marca;
                string atributo1 = txtAtributo1.Text;
                string atributo2 = txtAtributo2.Text;
                int stock;
                string tipo;

                if (string.IsNullOrEmpty(nombreMarca) || !Enum.TryParse(nombreMarca, out marca))
                {
                    throw new Exception("Asegúrate de seleccionar una marca.");
                }

                if (!int.TryParse(this.txtStock.Text, out stock))
                {
                    throw new Exception("Asegúrate de ingresar un valor numérico en Stock.");
                }

                if (cmbProductos.SelectedIndex == 0 && !int.TryParse(txtAtributo2.Text, out _))
                {
                    throw new Exception("Asegúrate de ingresar un valor numérico en Memoria RAM.");
                }

                if (cmbProductos.SelectedIndex == 2 && !int.TryParse(txtAtributo2.Text, out _))
                {
                    throw new Exception("Asegúrate de ingresar un valor numérico en Almacenamiento.");
                }

                if (int.TryParse(nombre, out _))
                {
                    throw new Exception("Asegúrate de ingresar un Nombre valido.");
                }

                if (string.IsNullOrEmpty(atributo1) || string.IsNullOrEmpty(atributo2) || string.IsNullOrEmpty(nombre))
                {
                    throw new Exception("Asegúrate de ingresar valores en todos los campos.");
                }

                if (productoAEditar == null)
                {
                    Electronica nuevoProducto = null;
                    int cmbIndice = cmbProductos.SelectedIndex;
                    if (cmbIndice == 0)
                    {
                        tipo = "COMPUTADORA";
                        nuevoProducto = new Computadora(nombre, stock, marca, atributo1, int.Parse(atributo2),tipo);
                    }
                    else if (cmbIndice == 1)
                    {
                        tipo = "TELEFONO";
                        nuevoProducto = new Telefono(nombre, stock, marca, atributo1, atributo2,tipo);
                    }
                    else if (cmbIndice == 2)
                    {
                        tipo = "CONSOLA";
                        nuevoProducto = new Consola(nombre, stock, marca, atributo1, int.Parse(atributo2),tipo);
                    }
                    else if (cmbIndice == -1)
                    {
                        throw new Exception("Tipo de producto no seleccionado.");
                    }

                    if (nuevoProducto != null)
                    {
                        if(!frmCRUD.bolsa.productos.Contains(nuevoProducto))
                        {
                            frmCRUD.bolsa += nuevoProducto;
                            frmCRUD.accesoTabla.AgregarDato(nuevoProducto);
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            // Mostrar un mensaje indicando que el producto ya existe
                            MessageBox.Show("El producto ya existe en la bolsa.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        throw new Exception("Asegúrate de seleccionar un tipo válido.");
                    }
                }
                else
                {
                    if (productoAEditar is Computadora)
                    {
                        Computadora computadora = (Computadora)productoAEditar;
                        computadora.nombre = nombre;
                        computadora.marca = marca;
                        computadora.stock = stock;
                        computadora.grafica = atributo1;
                        computadora.memoriaRam = int.Parse(atributo2);
                    }
                    else if (productoAEditar is Telefono)
                    {
                        Telefono tel = (Telefono)productoAEditar;
                        tel.nombre = nombre;
                        tel.marca = marca;
                        tel.stock = stock;
                        tel.pantalla = atributo1;
                        tel.modelo = atributo2;
                    }
                    else if (productoAEditar is Consola)
                    {
                        Consola consola = (Consola)productoAEditar;
                        consola.nombre = nombre;
                        consola.marca = marca;
                        consola.stock = stock;
                        consola.generacion = atributo1;
                        consola.almacenamiento = int.Parse(atributo2);
                    }

                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                RellenarDatosIncompletos(ex.Message);
            }
            #endregion

        }
        /// <summary>
        /// Boton para cancelar el agregado de productos.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void RellenarDatosIncompletos(string mensaje)
        {
            if (DatosIncompletos != null)
            {
                DatosEventArgs<string> eventArgs = new DatosEventArgs<string>(mensaje);
                DatosIncompletos(this, eventArgs);
            }

            MessageBox.Show($"Error: {mensaje}");

            if (string.IsNullOrEmpty(txtAtributo2.Text))
            {
                txtAtributo2.Text = "COMPLETAR";
            }
            if (string.IsNullOrEmpty(txtAtributo1.Text))
            {
                txtAtributo1.Text = "COMPLETAR";
            }
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                txtNombre.Text = "COMPLETAR";
            }
            if (string.IsNullOrEmpty(txtStock.Text))
            {
                txtStock.Text = "COMPLETAR";
            }
        }

        public void LimpiarDatos()
        {
            txtStock.Text = "";
            txtNombre.Text = "";
            txtStock.Text = "";
            txtAtributo1.Text = "";
            txtAtributo2.Text = "";
            cmbMarca.SelectedIndex = -1;
            cmbProductos.SelectedIndex = -1;
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
            AvisoInformacionProductoEliminada("La información del producto fue eliminada.");
        }
        protected virtual void AvisoInformacionProductoEliminada(string mensaje)
        {
            if (InformacionProductoEliminada != null)
            {
                DatosEventArgs<string> eventArgs = new DatosEventArgs<string>(mensaje);
                InformacionProductoEliminada(this, eventArgs);
            }

            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}
