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
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic.Logging;

namespace WinFormApp
{
    
    /// <summary>
    /// Delegado que actualizara la fecha de mi FrmCRUD
    /// </summary>
    public delegate void DelegadoActualizar(DateTime fecha);

    /// <summary>
    /// FormCRUD que contendra una lista con los productos y podra ordenarlos modificarlos eliminarlos etc.
    /// </summary>
    public partial class FrmCRUD : Form,ILimpiador,IDeshacerCambios
    {
        #region Atributos y Propiedades
        /// <summary>
        /// Variable donde guardare mi producto eliminado para asi hacer uso de este para retornarlo si se desea.
        /// </summary>
        private Electronica productoEliminado;
        /// <summary>
        /// Representa una solicitud de cancelación. Se utiliza para notificar a los hilos o tareas que deben interrumpir su trabajo.
        /// </summary>
        private CancellationToken cancelarFlujo;
        /// <summary>
        /// Proporciona un objeto que se puede utilizar para emitir solicitudes de cancelación a uno o más objetos CancellationToken.
        /// </summary>
        private CancellationTokenSource fuenteDeCancelacion;
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
        /// <summary>
        /// Usuario que esta usando la app.
        /// </summary>
        private Usuario usuarioActual;
        /// <summary>
        /// Ruta en donde se serializara y deserializaran los datos.
        /// </summary>
        private string rutaArchivo = @"..\..\..\archivo.xml";

        /// <summary>
        /// Flag para alternar asi se puede ordenar los datos.
        /// </summary>
        public bool flagOrdenar = false;

        /// <summary>
        /// Acceso a la tabla de mi Base de Datos.
        /// </summary>
        public AccesoTabla accesoTabla = new AccesoTabla();
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor inicial con la posicion inicial,creacion de la bolsa y el seteo del usuario con fecha.
        /// </summary>
        public FrmCRUD(Usuario usuario)
        {
            InitializeComponent();
            this.fuenteDeCancelacion = new CancellationTokenSource();
            this.cancelarFlujo = this.fuenteDeCancelacion.Token;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.usuarioActual = usuario;
            bolsaDeProductos = new Bolsa();
            lblUsuarioLog.Text = "Usuario: " + usuario.nombre;
            btnDeshacerCambios.Enabled = false;

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

            if (!this.flagOrdenar)
            {
                bolsaDeProductos.productos = this.accesoTabla.ObtenerListaDatos();
            }
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
                        this.accesoTabla.ModificarDato(productoSeleccionado);
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
                        this.accesoTabla.ModificarDato(productoSeleccionado);
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
                        this.accesoTabla.ModificarDato(productoSeleccionado);

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
                productoEliminado = bolsa.productos[selectedIndex];
                this.accesoTabla.EliminarDato(this.bolsaDeProductos.productos[selectedIndex].id);
                bolsa.productos.RemoveAt(selectedIndex);
                btnDeshacerCambios.Enabled = true;

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
                this.flagOrdenar = true;
                bolsa.Ordenar(e => e.stock, true);
            }
            else if (ordenSeleccionado == "Descendente")
            {
                this.flagOrdenar = true;
                bolsa.Ordenar(e => e.stock, false);
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
                this.flagOrdenar = true;
                bolsa.Ordenar(e => e.nombre, true);
            }
            else if (ordenSeleccionado == "Descendente")
            {
                this.flagOrdenar = true;
                bolsa.Ordenar(e => e.nombre, false);
            }

            ActualizarVisor();
        }

        /// <summary>
        /// Flag para cerrar la APP y que no se ejecute dos veces un mensaje.
        /// </summary>
        private bool cerrarAplicacion = false;
        /// <summary>
        /// Metodo para cerrar el form y serializar al cerrar.
        /// </summary>
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
                this.fuenteDeCancelacion.Cancel();
                cerrarAplicacion = true;
                Application.Exit();
            }
        }
        /// <summary>
        /// Metodo para al abrir el form y deserializar el archivo. Uso de excepcion personalizada.
        /// </summary>
        private void FrmCRUD_Load(object sender, EventArgs e)
        {

            try
            {
                Task t1 = Task.Run(() => { this.BucleTiempo(); });
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
        /// <summary>
        /// Metodo para configurar las posibilidades de uso segun el perfil del usuario. Se inabilitan los usos de los botones.
        /// </summary>
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
                btnLimpiar.Enabled = false;
                btnDeshacerCambios.Enabled = false;
            }
            else if (usuarioActual.perfil == "vendedor")
            {
                // R
                btnAgregar.Enabled = false;
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
                btnLimpiar.Enabled = false;
                btnDeshacerCambios.Enabled = false;
            }
        }

        /// <summary>
        /// Boton que usa un metodo de una Interfaz para borrar todo el listado de productos.
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
        }

        /// <summary>
        /// Metodo para borrar todos los elementos del tipo que se le asigne "T" en el CRUD.
        /// </summary>
        public void LimpiarDatos()
        {
            DialogResult resultado = MessageBox.Show($"¿Estás seguro de que deseas eliminar todos los elementos? No se podra reestablecer.", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                foreach (var producto in bolsa.productos.ToList())
                {
                    this.accesoTabla.EliminarDato(producto.id);
                    bolsa.productos.Remove(producto);
                }
            }
            ActualizarVisor();
        }

        /// <summary>
        /// Metodo que actualiza la fecha.
        /// </summary>
        private void ActualizarFecha(DateTime fecha)
        {
            if (this.lblReloj.InvokeRequired)
            {
                DelegadoActualizar d = new DelegadoActualizar(ActualizarFecha);
                object[] arrayParametro = { fecha };

                this.lblReloj.Invoke(d, arrayParametro);

            }
            else this.lblReloj.Text = fecha.ToString();
        }

        /// <summary>
        /// Metodo que tiene el bucle Do While de mi Reloj que actualiza la fecha.
        /// </summary>
        private void BucleTiempo()
        {
            do
            {
                if (this.cancelarFlujo.IsCancellationRequested) break;

                this.ActualizarFecha(DateTime.Now);
                Thread.Sleep(1000);
            } while (true);
        }


        private void btnDeshacerCambios_Click(object sender, EventArgs e)
        {
            if (productoEliminado != null)
            {
                DeshacerCambios();
            }
            else
            {
                btnDeshacerCambios.Enabled = false;
            }
        }

        public void DeshacerCambios()
        {
            bolsa.productos.Add(productoEliminado);
            accesoTabla.AgregarDato(productoEliminado);
            ActualizarVisor();

            productoEliminado = null;
            btnDeshacerCambios.Enabled = false;
        }
    #endregion
    }
}
