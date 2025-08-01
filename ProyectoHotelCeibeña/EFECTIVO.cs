using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace ProyectoHotelCeibeña
{
    // Define el control de usuario EFECTIVO, diseñado para manejar pagos en efectivo.
    public partial class EFECTIVO : UserControl
    {
        // Cadena de conexión para acceder a la base de datos MySQL.
        string conexion = "server=localhost;user=root;password=Mikel2006429;database=HotelLaCeibenia";

        // Objeto para generar números aleatorios, utilizado para los IDs.
        private Random random = new Random();

        // Evento que se dispara cuando se solicita regresar al menú principal.
        public event EventHandler RegresarAlMenuClicked;

        // Constructor del control de usuario EFECTIVO.
        public EFECTIVO()
        {
            InitializeComponent(); // Inicializa los componentes visuales del UserControl.
            GenerateAndSetRandomId(); // Genera y asigna IDs aleatorios al iniciar.
            this.textBox4.Text = "Efectivo"; // Establece el método de pago por defecto como "Efectivo".
        }

        // Limpia los campos de entrada del formulario después de una operación.
        private void ClearFormFields()
        {
            textBox3.Clear(); // Borra el monto total.
            dateTimePicker1.Value = DateTime.Now; // Restablece la fecha a la actual.
            this.textBox4.Text = "Efectivo"; // Lo mantiene como "Efectivo" después de limpiar.
        }

        // Genera nuevos IDs aleatorios para el pago y la reserva, y los asigna a los TextBoxes correspondientes.
        private void GenerateAndSetRandomId()
        {
            int randomIdPAGO = random.Next(10000000, 100000000); // Genera un ID de pago de 8 dígitos.
            int randomIdRESERVA = random.Next(10000000, 100000000); // Genera un ID de reserva de 8 dígitos.

            textBox1.Text = randomIdPAGO.ToString(); // Asigna el ID de pago al textBox1.
            textBox2.Text = randomIdRESERVA.ToString(); // Asigna el ID de reserva al textBox2.
        }

        // Clase personalizada para pasar información de un método de pago solicitado.
        public class MetodoPagoRequestedEventArgs : EventArgs
        {
            public string MetodoPago { get; set; }
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {
        }

        // Manejador del evento Click para el botón 'button10'. Valida los datos y guarda un nuevo pago en la base de datos.
        private void button10_Click_1(object sender, EventArgs e)
        {
            // Valida que los campos de ID Reserva y Monto Total no estén vacíos.
            if (string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Por favor, complete los campos de ID Reserva y Monto Total.", "Campos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Intenta convertir el texto del ID de Pago a un número entero.
            int idPago;
            if (!int.TryParse(textBox1.Text, out idPago))
            {
                MessageBox.Show("El ID de Pago debe ser un número válido.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idReserva;
            decimal montoTotalValue;
            // string montoTotalString; // No es necesario declarar esto si se usa directamente montoTotalValue
            string metodoPago = textBox4.Text; // Este valor ahora será correctamente "Efectivo" si ClearFormFields lo establece en "Efectivo".

            // Intenta convertir el texto del ID de Reserva a un número entero.
            if (!int.TryParse(textBox2.Text, out idReserva))
            {
                MessageBox.Show("El ID de Reserva debe ser un número válido.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Intenta convertir el texto del Monto Total a un número decimal.
            if (!decimal.TryParse(textBox3.Text, out montoTotalValue))
            {
                MessageBox.Show("El Monto Total debe ser un número válido.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // montoTotalString = montoTotalValue.ToString(); // No es necesario, usa montoTotalValue directamente en los parámetros.

            DateTime fechaPago = DateTime.Now; // Obtiene la fecha y hora actuales para el pago.

            // Abre una conexión a la base de datos MySQL.
            using (MySqlConnection sqlCon = new MySqlConnection(conexion))
            {
                try
                {
                    sqlCon.Open(); // Abre la conexión.
                    // Define la consulta SQL para insertar un nuevo pago.
                    string query = "INSERT INTO Pagos (id_pago, id_reserva, fecha_pago, monto_total, metodo_pago) VALUES (@idPago, @idReserva, @fechaPago, @montoTotal, @metodoPago);";

                    // Crea un comando MySQL para ejecutar la consulta.
                    using (MySqlCommand command = new MySqlCommand(query, sqlCon))
                    {
                        // Añade parámetros a la consulta para evitar inyección SQL y asegurar el tipo de dato.
                        command.Parameters.AddWithValue("@idPago", idPago);
                        command.Parameters.AddWithValue("@idReserva", idReserva);
                        command.Parameters.AddWithValue("@fechaPago", fechaPago);
                        command.Parameters.AddWithValue("@montoTotal", montoTotalValue); // Usa decimal directamente
                        command.Parameters.AddWithValue("@metodoPago", metodoPago);

                        int rowsAffected = command.ExecuteNonQuery(); // Ejecuta la consulta y obtiene el número de filas afectadas.

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Datos de pago guardados exitosamente. ", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ClearFormFields(); // Esto ahora restablecerá correctamente a "Efectivo".
                            GenerateAndSetRandomId(); // Genera nuevos IDs para el siguiente pago.
                        }
                        else
                        {
                            MessageBox.Show("No se pudieron guardar los datos de pago. (0 filas afectadas)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                // Captura excepciones específicas de MySQL (por ejemplo, clave duplicada).
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062) // Código de error para entrada duplicada (Duplicate entry for primary key/unique constraint).
                    {
                        MessageBox.Show("Error: El ID de Pago generado ya existe. Por favor, intente de nuevo para generar uno diferente.", "Error de ID Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        GenerateAndSetRandomId(); // Genera un nuevo ID para intentar de nuevo.
                    }
                    else
                    {
                        MessageBox.Show("Error al conectar o guardar en la base de datos: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                // Captura cualquier otra excepción general.
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void EFECTIVO_Load(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}