using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace ProyectoHotelCeibeña
{
    // Formulario principal de la aplicación, utilizado para el inicio de sesión.
    public partial class MENULOGIN : Form
    {
        // Cadena de conexión a la base de datos MySQL.
        string conexion = "server=localhost;user=root;password=Mikel2006429;database=HotelLaCeibenia";
        // Bandera que indica si la contraseña se está mostrando o no (no utilizada en el código proporcionado).
        bool mostrando = false;

        // Constructor del formulario Form1.
        public MENULOGIN()
        {
            InitializeComponent(); // SIEMPRE el primer método llamado en el constructor para inicializar los controles de la interfaz de usuario.
        }

        // Maneja el evento Click del botón Salir, cerrando completamente la aplicación.
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Cierra todas las ventanas y termina la aplicación.
        }

        // Maneja el evento Click del botón Borrar, limpiando los campos de texto de usuario y contraseña.
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtContraseña.Clear();     // Limpia el campo de texto de la contraseña.
            txtNombreUsuario.Clear(); // Limpia el campo de texto del nombre de usuario.
        }

        // Valida que los campos de nombre de usuario y contraseña no estén vacíos.
        private bool isValid()
        {
            // Verifica si el campo de nombre de usuario está vacío o solo contiene espacios en blanco.
            if (txtNombreUsuario.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Ingrese el nombre de usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombreUsuario.Focus(); // Pone el foco en el campo de nombre de usuario.
                return false;
            }
            // Verifica si el campo de contraseña está vacío o solo contiene espacios en blanco.
            else if (txtContraseña.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Ingrese la contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContraseña.Focus(); // Pone el foco en el campo de contraseña.
                return false;
            }
            return true; // Retorna true si ambos campos son válidos.
        }

        // Maneja el evento Click del botón Ingresar, intentando autenticar al usuario.
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (isValid()) // Si los campos de entrada son válidos.
            {
                MySqlConnection conne = new MySqlConnection(conexion); // Crea una nueva conexión a la base de datos.
                try
                {
                    conne.Open(); // Abre la conexión a la base de datos.
                    // Consulta SQL para verificar el nombre de usuario y la contraseña.
                    string consulta = "SELECT * FROM Usuarios WHERE username = @username AND password = @password";
                    MySqlCommand comando = new MySqlCommand(consulta, conne); // Crea un comando SQL.
                    // Añade parámetros para evitar la inyección SQL y pasar los valores del usuario y contraseña.
                    comando.Parameters.AddWithValue("@username", txtNombreUsuario.Text.Trim());
                    comando.Parameters.AddWithValue("@password", txtContraseña.Text.Trim());

                    MySqlDataReader reader = comando.ExecuteReader(); // Ejecuta la consulta y obtiene un lector de datos.

                    if (reader.HasRows) // Si se encontraron filas, las credenciales son correctas.
                    {
                        MessageBox.Show("Bienvenido al Hotel La Ceibeña", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide(); // Oculta el formulario de inicio de sesión.
                        Menu menuForm = new Menu(); // Crea una nueva instancia del formulario de menú.
                        menuForm.Show(); // Muestra el formulario de menú.
                    }
                    else // Si no se encontraron filas, las credenciales son incorrectas.
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex) // Captura cualquier excepción que ocurra durante la conexión o la consulta.
                {
                    MessageBox.Show("Error al conectar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Asegura que la conexión a la base de datos se cierre siempre.
                    if (conne.State == ConnectionState.Open) // Verifica si la conexión está abierta antes de cerrarla.
                    {
                        conne.Close();
                    }
                }

                PopupNotifier popup = new PopupNotifier();
                popup.TitleText = "Ingreso en el Sistema Hoteleria";
                popup.ContentText = "Hola Acaba de Ingresar al Sistema";
                popup.Image = SystemIcons.Warning.ToBitmap();
                popup.BodyColor = Color.White;
                popup.TitleColor = Color.Black;
                popup.TitleFont = new Font("Arial", 14, FontStyle.Bold);
                popup.ContentFont = new Font("Segoe UI", 14);
                popup.Delay = 4000;

                popup.Popup(); //Muestra la notifiacion
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}