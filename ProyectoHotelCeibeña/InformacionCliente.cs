using MySql.Data.MySqlClient;
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
    // Formulario para la gestión de información de clientes.
    public partial class InformacionCliente : Form
    {
        // Cadena de conexión a la base de datos MySQL.
        string conexion = "server=localhost;user=root;password=Mikel2006429;database=HotelLaCeibenia";

        // Limpia los campos de texto del formulario de cliente.
        private void LimpiarCamposCliente()
        {
            TxtNombre.Text = "";    // Borra el texto del campo Nombre.
            TxtApellido.Text = "";  // Borra el texto del campo Apellido.
            TxtDNI.Text = "";       // Borra el texto del campo DNI.
            TxtTelefono.Text = "";  // Borra el texto del campo Teléfono.
            TxtCorreo.Text = "";    // Borra el texto del campo Correo.
            TxtDireccion.Text = ""; // Borra el texto del campo Dirección.
        }

        // Constructor del formulario InformacionCliente.
        public InformacionCliente()
        {
            InitializeComponent(); // Inicializa los componentes visuales del formulario.
            MostrarClientes();     // Muestra los clientes existentes al cargar el formulario.

            // Declaración de variables de conexión y datos (pueden ser declaradas a nivel de clase si se usan en múltiples métodos fuera del using).
            MySqlConnection conn;
            MySqlDataAdapter adapter;
            DataTable tabla;
        }

        // Manejador del evento Load del formulario InformacionCliente.
        // Establece la visibilidad de los paneles al cargar el formulario.
        private void InformacionCliente_Load(object sender, EventArgs e)
        {
            panel6.Visible = true;  // Hace visible el panel de Clientes.
            panel5.Visible = false; // Oculta el panel de Facturas.
            panel4.Visible = false; // Oculta el panel de Habitaciones.
        }

        // Muestra los clientes de la base de datos en el DataGridView.
        private void MostrarClientes()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(conexion))
                {
                    conn.Open(); // Abre la conexión a la base de datos.
                    // Consulta SQL para seleccionar los datos de los clientes y renombrar las columnas para visualización.
                    string query = "SELECT id_cliente AS 'ID', nombre AS 'Nombre', apellido AS 'Apellido', dni AS 'DNI', teléfono AS 'Teléfono', correo AS 'Correo', dirección AS 'Dirección' FROM Clientes ORDER BY id_cliente";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable tabla = new DataTable(); // Crea un nuevo DataTable.
                        adapter.Fill(tabla); // Llena el DataTable con los datos.
                        dataGridView1.DataSource = tabla; // Asigna el DataTable como origen de datos del DataGridView.
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Maneja el clic en el botón Guardar, insertando un nuevo cliente en la base de datos.
        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(conexion))
                {
                    conn.Open(); // Abre la conexión.
                    // Consulta SQL para insertar un nuevo cliente con parámetros.
                    string query = @"INSERT INTO Clientes (nombre, apellido, dni, teléfono, correo, dirección)
                                     VALUES (@nombre, @apellido, @dni, @telefono, @correo, @direccion)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Asigna los valores de los TextBoxes a los parámetros de la consulta.
                        cmd.Parameters.AddWithValue("@nombre", TxtNombre.Text);
                        cmd.Parameters.AddWithValue("@apellido", TxtApellido.Text);
                        cmd.Parameters.AddWithValue("@dni", TxtDNI.Text);
                        cmd.Parameters.AddWithValue("@telefono", TxtTelefono.Text);
                        cmd.Parameters.AddWithValue("@correo", TxtCorreo.Text);
                        cmd.Parameters.AddWithValue("@direccion", TxtDireccion.Text);

                        cmd.ExecuteNonQuery(); // Ejecuta la consulta de inserción.

                        MessageBox.Show("Cliente registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarClientes();     // Actualiza la tabla de clientes en el DataGridView.
                        LimpiarCamposCliente(); // Limpia los campos del formulario.
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Maneja el clic en el botón Eliminar, eliminando el cliente seleccionado de la base de datos.
        private void btneliminar_Click(object sender, EventArgs e)
        {
            // Verifica si hay alguna fila seleccionada en el DataGridView.
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Pide confirmación al usuario antes de eliminar.
                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar este cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes) // Si el usuario confirma la eliminación.
                {
                    try
                    {
                        // Obtiene el ID del cliente de la fila seleccionada.
                        int idCliente = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                        using (MySqlConnection conn = new MySqlConnection(conexion))
                        {
                            conn.Open(); // Abre la conexión.

                            string query = "DELETE FROM Clientes WHERE id_cliente = @id"; // Consulta SQL para eliminar.
                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", idCliente); // Añade el parámetro del ID.
                                cmd.ExecuteNonQuery(); // Ejecuta la eliminación.
                            }
                        }

                        MessageBox.Show("Cliente eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MostrarClientes();     // Actualiza la tabla de clientes en el DataGridView.
                        LimpiarCamposCliente(); // Limpia los campos del formulario.
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un cliente en la tabla para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Maneja el clic en el botón de retorno, volviendo al menú principal.
        private void btnreturn_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu(); // Crea una nueva instancia del formulario de menú.
            menu.Show(); // Muestra el formulario de menú.
            this.Hide(); // Oculta el formulario actual.
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}