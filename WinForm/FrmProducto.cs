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
    public partial class FrmProducto : Form
    {
        #region Atributos
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
            string nombre = this.txtNombre.Text;
            string nombreMarca = this.cmbMarca.SelectedItem?.ToString();
            EMarcas marca;
            string atributo1 = txtAtributo1.Text;
            string atributo2 = txtAtributo2.Text;
            int stock;
            if (string.IsNullOrEmpty(nombreMarca) || !Enum.TryParse(nombreMarca, out marca))
            {
                MessageBox.Show("ERROR. Asegúrate de seleccionar una marca válida.");
            }
            else if (!int.TryParse(this.txtStock.Text, out stock))
            {
                MessageBox.Show("ERROR. Asegúrate de ingresar un valor numérico en Stock.");
            }
            else if (cmbProductos.SelectedIndex == 0 && !int.TryParse(txtAtributo2.Text, out _))
            {
                MessageBox.Show("ERROR. Asegúrate de ingresar un valor numérico en Memoria RAM.");
            }
            else if (cmbProductos.SelectedIndex == 2 && !int.TryParse(txtAtributo2.Text, out _))
            {
                MessageBox.Show("ERROR. Asegúrate de ingresar un valor numérico en Almacenamiento.");
            }
            else if (int.TryParse(nombre, out _))
            {
                MessageBox.Show("ERROR. Asegúrate de ingresar una cadena en Nombre.");
            }
            else if (string.IsNullOrEmpty(atributo1))
            {
                MessageBox.Show("ERROR. Asegúrate de ingresar valores en todos los campos.");
            }
            else if (string.IsNullOrEmpty(atributo2))
            {
                MessageBox.Show("ERROR. Asegúrate de ingresar valores en todos los campos.");
            }
            else
            {
                if (productoAEditar == null)
                {
                    Electronica nuevoProducto = null;
                    int cmbIndice = cmbProductos.SelectedIndex;
                    if (cmbIndice == 0)
                    {
                        nuevoProducto = new Computadora(nombre, stock, marca, atributo1, int.Parse(atributo2));
                    }
                    else if (cmbIndice == 1)
                    {
                        nuevoProducto = new Telefono(nombre, stock, marca, atributo1, atributo2);
                    }
                    else if (cmbIndice == 2)
                    {
                        nuevoProducto = new Consola(nombre, stock, marca, atributo1, int.Parse(atributo2));
                    }
                    else if (cmbIndice == -1)
                    {
                        MessageBox.Show("ERROR. Tipo de producto no seleccionado.");
                    }

                    if (nuevoProducto != null)
                    {
                        frmCRUD.bolsa += nuevoProducto;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("ERROR. Asegúrese de seleccionar un tipo válido.");
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
            #endregion

        }
        /// <summary>
        /// Boton para cancelar el agregado de productos.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion
    }
}
