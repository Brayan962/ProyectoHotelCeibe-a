using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoHotelCeibeña
{
    // Define el formulario principal del menú de la aplicación.
    public partial class Menu : Form
    {
        // Cadena de conexión a la base de datos MySQL.
        string conexion = "server=localhost;user=root;password=Mikel2006429;database=HotelLaCeibenia";

        // Constructor del formulario Menu.
        public Menu()
        {
            InitializeComponent(); // Inicializa los componentes visuales del formulario.
        }

        // Maneja el clic en el botón SALIR, cerrando la aplicación.
        private void btnSALIR_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual (y la aplicación si es el formulario principal).
        }

        // Maneja el clic en el botón INICIO, navega al formulario de inicio (Form1).
        private void btnINICIO_Click(object sender, EventArgs e)
        {
            MENULOGIN Inicio = new MENULOGIN(); // Crea una nueva instancia del formulario de inicio.
            Inicio.Show(); // Muestra el formulario de inicio.
            this.Hide(); // Oculta el formulario de menú actual.
        }

        // Maneja el clic en el botón Habitaciones y Reservas, navega al formulario de Reserva de Habitaciones.
        private void btnHabitacionesReservas_Click(object sender, EventArgs e)
        {
            ReservaHabitaciones reservaHabitaciones = new ReservaHabitaciones(); // Crea una nueva instancia del formulario de reservas.
            reservaHabitaciones.Show(); // Muestra el formulario de reservas.
            this.Hide(); // Oculta el formulario de menú actual.
        }

        // Maneja el clic en el botón Clientes, navega al formulario de Información del Cliente.
        private void btnClientes_Click(object sender, EventArgs e)
        {
            InformacionCliente informacionCliente = new InformacionCliente(); // Crea una nueva instancia del formulario de clientes.
            informacionCliente.Show(); // Muestra el formulario de clientes.
            this.Hide(); // Oculta el formulario de menú actual.
        }

        // Maneja el clic en el botón Facturación, navega al formulario de Facturación.
        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            Facturacion facturacion = new Facturacion(); // Crea una nueva instancia del formulario de facturación.
            facturacion.Show(); // Muestra el formulario de facturación.
            this.Hide(); // Oculta el formulario de menú actual.
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}