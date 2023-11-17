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
        public event EventHandler<DatosLoginEventArgs> AutenticacionFallida;
        /// <summary>
        /// Atributo de usuario privado para que no se pueda acceder.
        /// </summary>
        private Usuario usuario;

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

        private void AutenticacionUsuarioFallida(string mensaje)
        {
            MessageBox.Show($"Error de autenticación: {mensaje}");

            AutenticacionFallida?.Invoke(this, new DatosLoginEventArgs(mensaje));

            this.txtCorreo.Text = string.Empty;
            this.txtPass.Text = string.Empty;
        }
    }
    #endregion

}
