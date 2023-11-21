using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;

namespace WinFormApp
{
    /// <summary>
    /// Clase del form para iniciar sesion.
    /// </summary>
    public partial class FrmInicio : Form
    {
        #region Atributos
        /// <summary>
        /// Delegado conectado con DatosEventArgs.
        /// </summary>
        public delegate void AutenticacionFallidaEventHandler(object sender, DatosEventArgs<string> e);
        /// <summary>
        /// Evento AutenticacionFallida.
        /// </summary>
        public event AutenticacionFallidaEventHandler AutenticacionFallida;
        /// <summary>
        /// Atributo de usuario privado para que no se pueda acceder.
        /// </summary>
        private Usuario usuario;
        /// <summary>
        /// Propiedad que obtiene el objeto Usuario asociado al formulario.
        /// </summary>
        public Usuario UsuarioDelForm
        {
            get { return this.usuario; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor inicial con la posicion inicial.
        /// </summary>
        public FrmInicio()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        public FrmInicio(Usuario usuario) : this()
        {
            this.usuario = usuario;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Funcion para verificar con la deserializacion del archivo json.
        /// </summary>
        private Usuario Verificar()
        {
            Usuario? rta = null;

            using (System.IO.StreamReader sr = new System.IO.StreamReader(@"..\..\..\MOCK_DATA.json"))
            {
                System.Text.Json.JsonSerializerOptions opciones = new System.Text.Json.JsonSerializerOptions();
                opciones.WriteIndented = true;

                string json_str = sr.ReadToEnd();

                List<Usuario> users = JsonSerializer.Deserialize<List<Usuario>>(json_str, opciones);

                foreach (Usuario item in users)
                {
                    if (item.correo == this.txtCorreo.Text && item.clave == this.txtPass.Text)
                    {
                        rta = item;
                        this.usuario = item;
                        break;
                    }
                }
            }

            return rta;
        }
        /// <summary>
        /// Boton iniciar sesion que me dara la bienvenida si es correcto y si usara mi evento.
        /// </summary>
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Usuario usuarioAutenticado = this.Verificar();

            if (usuarioAutenticado is Usuario)
            {
                MessageBox.Show($"Bienvenido al programa {this.usuario.nombre}");
                FrmCRUD frmCrud = new FrmCRUD(usuario);
                frmCrud.Show();
                this.Hide();
            }
            else
            {
                AutenticacionUsuarioFallida("Email y/o contraseña inválida. Vuelva a intentar");
            }
        }

        /// <summary>
        /// Metodo que usara mi evento para hacer un mensaje al haber un error de inicio de sesion y borrar los datos ingresados.
        /// </summary>
        private void AutenticacionUsuarioFallida(string mensaje)
        {
            if (AutenticacionFallida != null)
            {
                DatosEventArgs<string> eventArgs = new DatosEventArgs<string>(mensaje);
                AutenticacionFallida(this, eventArgs);
            }

            MessageBox.Show($"Error de autenticación: {mensaje}");
            this.txtCorreo.Text = string.Empty;
            this.txtPass.Text = string.Empty;
        }
    }
    #endregion

}
