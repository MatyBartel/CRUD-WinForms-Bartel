using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Entidades;

namespace WinFormApp
{
    /// <summary>
    /// FormCRUD que contendra una lista con los productos y podra ordenarlos modificarlos eliminarlos etc.
    /// </summary>
    public partial class FrmCRUD : Form
    {
        #region Atributos y Propiedades
        /// <summary>
        /// Lista de productos de la clase de coleccion.
        /// </summary>
        private Bolsa bolsaDeProductos;

        /// <summary>
        /// Proporciona acceso a la bolsa de productos electrónicos.
        /// </summary>
        public Bolsa bolsa
        {
            get { return bolsaDeProductos; }
            set { bolsaDeProductos = value; }
        }

        private Usuario usuarioActual;

        private string rutaArchivo = @"..\..\..\archivo.xml";
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor inicial con la posicion inicial,creacion de la bolsa y el seteo del usuario con fecha.
        /// </summary>
        public FrmCRUD(Usuario usuario)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.usuarioActual = usuario;
            bolsaDeProductos = new Bolsa();
            lblUsuarioLog.Text = "Usuario: " + usuario.nombre + " - Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");
            ConfigurarInterfazSegunPerfil();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo para actualizar la pantalla/visor con productos
        /// </summary>
        private void ActualizarVisor()
        {
            this.lstVisor.Items.Clear();
            foreach (Electronica producto in bolsaDeProductos.productos)
            {
                lstVisor.Items.Add(producto.ToString());
            }
        }
        /// <summary>
        /// Metodo para abrir form producto que dejara agregar un producto.
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmProducto frm1 = new FrmProducto(bolsa, this);
            frm1.ShowDialog();

            if (frm1.DialogResult == DialogResult.OK)
            {
                this.ActualizarVisor();
            }
        }
        /// <summary>
        /// Metodo que dejara modificar ese producto seleccionado segun su indice
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            int indice = lstVisor.SelectedIndex;

            if (indice >= 0 && indice < bolsa.productos.Count)
            {
                Electronica productoSeleccionado = bolsa.productos[indice];

                if (productoSeleccionado is Computadora)
                {
                    Computadora computadoraSeleccionada = (Computadora)productoSeleccionado;
                    FrmProducto frmModificar = new FrmProducto(computadoraSeleccionada);
                    DialogResult resultado = frmModificar.ShowDialog();

                    if (resultado == DialogResult.OK)
                    {
                        ActualizarVisor();
                    }
                }
                else if (productoSeleccionado is Consola)
                {
                    Consola consolaSeleccionada = (Consola)productoSeleccionado;
                    FrmProducto frmModificar = new FrmProducto(consolaSeleccionada);
                    DialogResult resultado = frmModificar.ShowDialog();

                    if (resultado == DialogResult.OK)
                    {
                        ActualizarVisor();
                    }
                }
                else if (productoSeleccionado is Telefono)
                {
                    Telefono telefonoSeleccionado = (Telefono)productoSeleccionado;
                    FrmProducto frmModificar = new FrmProducto(telefonoSeleccionado);
                    DialogResult resultado = frmModificar.ShowDialog();

                    if (resultado == DialogResult.OK)
                    {
                        ActualizarVisor();
                    }
                }
            }
        }
        /// <summary>
        /// Metodo que dejara eliminar un producto seleccionado segun su indice.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = lstVisor.SelectedIndex;

                bolsa.productos.RemoveAt(selectedIndex);
                ActualizarVisor();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Por favor, seleccione un producto para eliminar.");
            }
        }

        /// <summary>
        /// Metodo para ordenar por stock los productos con sus validaciones.
        /// </summary>
        private void btnOrdenarStock_Click(object sender, EventArgs e)
        {
            if (bolsa.productos.Count == 0)
            {
                MessageBox.Show("No hay elementos para ordenar.");
                return;
            }
            if (cmbAscDesc.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un orden antes de ordenar. (Ascendente/Descendente)");
                return;
            }

            string ordenSeleccionado = cmbAscDesc.SelectedItem.ToString();

            if (ordenSeleccionado == "Ascendente")
            {
                bolsa.OrdenarProductosPorStock();
            }
            else if (ordenSeleccionado == "Descendente")
            {
                bolsa.OrdenarProductosPorStock(true);
            }

            ActualizarVisor();
        }

        /// <summary>
        /// Metodo para ordenar por nombre los productos y con validaciones.
        /// </summary>
        private void btnOrdenarNombre_Click(object sender, EventArgs e)
        {
            if (bolsa.productos.Count == 0)
            {
                MessageBox.Show("No hay elementos para ordenar.");
                return;
            }
            if (cmbAscDesc.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un orden antes de ordenar. (Ascendente/Descendente)");
                return;
            }

            string ordenSeleccionado = cmbAscDesc.SelectedItem.ToString();

            if (ordenSeleccionado == "Ascendente")
            {
                bolsa.OrdenarPorNombre();
            }
            else if (ordenSeleccionado == "Descendente")
            {
                bolsa.OrdenarPorNombre(true);
            }

            ActualizarVisor();
        }
        /// <summary>
        /// Metodo para cerrar el form y serializar al cerrar.
        /// </summary>
        private bool cerrarAplicacion = false;

        private void FrmCRUD_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!cerrarAplicacion)
            {
                DialogResult result = MessageBox.Show("¿Desea cerrar el programa y guardar los datos?", "Confirmación", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    using (XmlTextWriter writer = new XmlTextWriter(rutaArchivo, Encoding.UTF8)) // Utiliza la misma ruta
                    {
                        XmlSerializer ser = new XmlSerializer(typeof(Bolsa));
                        ser.Serialize(writer, bolsaDeProductos);
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }

                cerrarAplicacion = true;

                Application.Exit();
            }
        }
        /// <summary>
        /// Metodo para al abrir el form deserializar el archivo.
        /// </summary>
        private void FrmCRUD_Load(object sender, EventArgs e)
        {

            try
            {
                if (File.Exists(rutaArchivo))
                {
                    using (XmlTextReader reader = new XmlTextReader(rutaArchivo))
                    {
                        XmlSerializer serializador = new XmlSerializer(typeof(Bolsa));
                        this.bolsaDeProductos = (Bolsa)serializador.Deserialize(reader);
                    }
                }
                else
                {
                    this.bolsaDeProductos = new Bolsa();

                    using (XmlTextWriter writer = new XmlTextWriter(rutaArchivo, Encoding.UTF8))
                    {
                        XmlSerializer ser = new XmlSerializer(typeof(Bolsa));
                        ser.Serialize(writer, bolsaDeProductos);
                    }

                    throw new ArchivoDesconocidoException();
                }
            }
            // EXCEPCION PERSONALIZADA //
            catch (ArchivoDesconocidoException ex)
            {
                MessageBox.Show(ex.Message);
            }

            ActualizarVisor();
        }

        private void ConfigurarInterfazSegunPerfil()
        {
            if (usuarioActual.perfil == "administrador")
            {
                // CRUD
                btnAgregar.Enabled = true;
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else if (usuarioActual.perfil == "supervisor")
            {
                // CRU
                btnAgregar.Enabled = true;
                btnModificar.Enabled = true;
                btnEliminar.Enabled = false;
            }
            else if (usuarioActual.perfil == "vendedor")
            {
                // R
                btnAgregar.Enabled = false;
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
        }

        public void LimpiarDatos()
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar todos los productos?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                bolsa.productos.Clear();
            }
            ActualizarVisor();
        }
    }
    #endregion
}
