using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoHotelCeibeña
{
    // Formulario para la gestión de habitaciones y reservas.
    public partial class ReservaHabitaciones : Form
    {
        // Cadena de conexión a la base de datos MySQL.
        string conexion = "server=localhost;user=root;password=Mikel2006429;database=HotelLaCeibenia";
        // Objeto de conexión a MySQL (declarado aquí para uso general en la clase).
        MySqlConnection conn;
        // Adaptador de datos para MySQL (declarado aquí para uso general en la clase).
        MySqlDataAdapter adapter;
        // Objeto DataTable para almacenar los datos de la base de datos (declarado aquí para uso general en la clase).
        DataTable tabla;

        private PrintDocument printDocument1; // Objeto para manejar la impresión de documentos.

        // Constructor del formulario ReservaHabitaciones.
        public ReservaHabitaciones()
        {
            InitializeComponent(); // Inicializa los componentes visuales del formulario.
            GenerarNumeroHabitacionSiguiente(); // Genera el próximo número de habitación disponible.
            ActualizarContadorHabitaciones(); // Actualiza los contadores de habitaciones por tipo y estado.
            ActualizarTotalHabitaciones(); // Actualiza el total de habitaciones registradas.
            MostrarHabitaciones(); // Muestra todas las habitaciones en el DataGridView.

            // Agrega opciones al ComboBox de filtrado de estado de habitaciones.
            materialComboBoxFiltrado.Items.AddRange(new string[] { "Disponible", "Ocupada", "Mantenimiento", "Todas" });
            // Agrega opciones al ComboBox para cambiar el estado de la habitación.
            materialComboBoxEstado.Items.AddRange(new string[] { "Disponible", "Ocupada", "Mantenimiento" });

            // Inicializa PrintDocument y asocia el evento PrintPage.
            printDocument1 = new PrintDocument();
            printDocument1.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPageDataGridView);
        }

        private void ReservaHabitaciones_Load(object sender, EventArgs e)
        {
        }

        // Actualiza el contador de habitaciones por tipo y estado (ocupadas, disponibles).
        private void ActualizarContadorHabitaciones()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(conexion))
                {
                    conn.Open(); // Abre la conexión a la base de datos.
                    // Consulta SQL para obtener la cantidad de habitaciones por tipo y estado.
                    string query = @"
                    SELECT tipo, estado, COUNT(*) AS cantidad
                    FROM Habitaciones
                    GROUP BY tipo, estado;
                    ";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        int ocupadasSimple = 0, ocupadasDoble = 0, ocupadasSuite = 0;
                        int disponiblesSimple = 0, disponiblesDoble = 0, disponiblesSuite = 0;

                        while (reader.Read()) // Lee los resultados de la consulta.
                        {
                            string tipo = reader.GetString("tipo");
                            string estado = reader.GetString("estado");
                            int cantidad = reader.GetInt32("cantidad");

                            // Asigna las cantidades a las variables correspondientes según el tipo y estado.
                            if (estado == "Ocupada")
                            {
                                if (tipo == "Simple") ocupadasSimple = cantidad;
                                else if (tipo == "Doble") ocupadasDoble = cantidad;
                                else if (tipo == "Suite") ocupadasSuite = cantidad;
                            }
                            else if (estado == "Disponible")
                            {
                                if (tipo == "Simple") disponiblesSimple = cantidad;
                                else if (tipo == "Doble") disponiblesDoble = cantidad;
                                else if (tipo == "Suite") disponiblesSuite = cantidad;
                            }
                        }

                        // Actualiza el texto del Label para mostrar los contadores.
                        lbcontar.Text =
                            $"    OCUPADAS\n" +
                            $"    Simple: {ocupadasSimple} | Doble: {ocupadasDoble} | Suite: {ocupadasSuite} \n\n" +
                            $"    DISPONIBLE\n" +
                            $"    Simple: {disponiblesSimple} | Doble: {disponiblesDoble} | Suite: {disponiblesSuite} ";

                        int totalOcupadas = ocupadasSimple + ocupadasDoble + ocupadasSuite;
                        int totalDisponibles = disponiblesSimple + disponiblesDoble + disponiblesSuite;

                        // Cambia el color del texto y habilita/deshabilita el botón guardar según la ocupación.
                        // La lógica para habilitar/deshabilitar el botón 'btnguardar' parece ser siempre 'true' en este bloque,
                        // lo que podría ser revisado si se espera un comportamiento condicional.
                        if (totalOcupadas > 0 && totalOcupadas >= (totalOcupadas + totalDisponibles))
                        {
                            lbcontar.ForeColor = Color.Red; // Cambia el color a rojo si hay muchas ocupadas.
                            btnguardar.Enabled = true; // Habilita el botón guardar.
                        }
                        else
                        {
                            lbcontar.ForeColor = Color.Black; // Restablece el color a negro.
                            btnguardar.Enabled = true; // Habilita el botón guardar.
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar contadores de habitaciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Actualiza el número total de habitaciones en el campo de texto.
        private void ActualizarTotalHabitaciones()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(conexion))
                {
                    conn.Open(); // Abre la conexión.
                    string query = "SELECT COUNT(*) FROM Habitaciones"; // Consulta para contar todas las habitaciones.
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        int totalHabitaciones = Convert.ToInt32(cmd.ExecuteScalar()); // Obtiene el total.
                        materialTxtHabitaciones.Text = $"{totalHabitaciones}"; // Muestra el total.
                        materialTxtHabitaciones.ReadOnly = true; // Hace el campo de texto de solo lectura.
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el total de habitaciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Genera el siguiente número de habitación disponible basándose en el último número registrado.
        private void GenerarNumeroHabitacionSiguiente()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(conexion))
                {
                    conn.Open(); // Abre la conexión.
                    // Consulta para obtener el número de la última habitación registrada.
                    string query = "SELECT numero FROM Habitaciones ORDER BY id_habitacion DESC LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar(); // Ejecuta la consulta y obtiene el resultado.
                        int siguienteNumero = 1; // Número por defecto si no hay habitaciones.

                        // Si hay un resultado y es un número válido, calcula el siguiente número.
                        if (result != null && int.TryParse(result.ToString(), out int ultimoNumero))
                        {
                            siguienteNumero = ultimoNumero + 1;
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar número de habitación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Muestra todas las habitaciones en el DataGridView.
        private void MostrarHabitaciones()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(conexion))
                {
                    conn.Open(); // Abre la conexión.
                    // Consulta SQL para seleccionar y renombrar columnas para la visualización.
                    string query = "SELECT id_habitacion AS 'ID', numero AS 'NUMERO', tipo AS 'TIPO', precio_noche AS 'PRECIO_NOCHE', estado AS 'Estado' FROM Habitaciones ORDER BY id_habitacion";
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
                MessageBox.Show($"Error al mostrar habitaciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Maneja el clic en el botón Cancelar, cerrando el formulario actual.
        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario de Reservas de Habitaciones.
        }

        // Maneja el cambio de selección en el ComboBox de filtrado.
        private void materialComboBoxFiltrado_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filtroEstado = materialComboBoxFiltrado.SelectedItem?.ToString(); // Obtiene el estado seleccionado para filtrar.

            try
            {
                using (MySqlConnection conn = new MySqlConnection(conexion))
                {
                    conn.Open(); // Abre la conexión.
                    // Consulta base para obtener las habitaciones.
                    string query = "SELECT id_habitacion AS 'ID', numero AS 'NUMERO', tipo AS 'TIPO', precio_noche AS 'PRECIO_NOCHE', estado AS 'Estado' FROM Habitaciones";
                    if (filtroEstado != "Todas") // Si el filtro no es "Todas", añade la cláusula WHERE.
                    {
                        query += " WHERE estado = @estado";
                    }
                    query += " ORDER BY id_habitacion"; // Asegura que los resultados estén ordenados.

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (filtroEstado != "Todas") // Si se aplica un filtro, añade el parámetro.
                        {
                            cmd.Parameters.AddWithValue("@estado", filtroEstado);
                        }

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable tabla = new DataTable(); // Crea un nuevo DataTable.
                            adapter.Fill(tabla); // Llena el DataTable con los datos filtrados.
                            dataGridView1.DataSource = tabla; // Actualiza el DataGridView.
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar habitaciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        // Maneja el clic en el botón Eliminar, eliminando la habitación seleccionada.
        private void btneliminar_Click(object sender, EventArgs e)
        {
            // Verifica si hay una fila seleccionada en el DataGridView.
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una habitación para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Pide confirmación al usuario antes de eliminar.
            DialogResult result = MessageBox.Show("¿Está seguro de eliminar la habitación seleccionada?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes) // Si el usuario confirma la eliminación.
            {
                try
                {
                    // Obtiene el ID de la habitación de la fila seleccionada.
                    int idHabitacion = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                    using (MySqlConnection conn = new MySqlConnection(conexion))
                    {
                        conn.Open(); // Abre la conexión.
                        string query = "DELETE FROM Habitaciones WHERE id_habitacion = @id"; // Consulta SQL para eliminar.
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", idHabitacion); // Añade el parámetro del ID.
                            cmd.ExecuteNonQuery(); // Ejecuta la eliminación.

                            MessageBox.Show("Habitación eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            MostrarHabitaciones(); // Actualiza el DataGridView.
                            ActualizarContadorHabitaciones(); // Actualiza los contadores.
                            ActualizarTotalHabitaciones(); // Actualiza el total.
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar habitación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Dibuja el contenido del DataGridView en el documento de impresión.
        private void PrintDocument_PrintPageDataGridView(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics; // Objeto Graphics para dibujar en la página.
            Font font = new Font("Arial", 10); // Fuente para el texto normal.
            Font headerFont = new Font("Arial", 12, FontStyle.Bold); // Fuente para los encabezados de columna.
            Font titleFont = new Font("Arial", 18, FontStyle.Bold); // Fuente para el título del documento.

            float fontHeight = font.GetHeight(); // Altura de la fuente normal.
            float headerHeight = headerFont.GetHeight(); // Altura de la fuente del encabezado.
            int startX = e.MarginBounds.Left; // Coordenada X inicial para el dibujo (margen izquierdo).
            int currentY = e.MarginBounds.Top; // Coordenada Y actual para el dibujo (margen superior).
            int cellPadding = 10; // Espaciado entre celdas.

            string title = "Listado de Habitaciones"; // Título del documento a imprimir.
            SizeF titleSize = graphics.MeasureString(title, titleFont); // Calcula el tamaño del título.
            float titleX = startX + (e.MarginBounds.Width - titleSize.Width) / 2; // Centra el título.
            graphics.DrawString(title, titleFont, Brushes.Black, titleX, currentY); // Dibuja el título.
            currentY += (int)(titleSize.Height * 1.5); // Avanza la posición Y para el siguiente elemento.

            int currentX = startX; // Restablece la posición X para los encabezados.
            // Dibuja los encabezados de las columnas.
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Visible) // Solo imprime columnas visibles.
                {
                    graphics.DrawString(column.HeaderText, headerFont, Brushes.Black, currentX, currentY);
                    currentX += column.Width + cellPadding; // Avanza la posición X para la siguiente columna.
                }
            }
            currentY += (int)(headerHeight + 5); // Avanza la posición Y después de los encabezados.
            graphics.DrawLine(Pens.Black, startX, currentY, e.MarginBounds.Right, currentY); // Dibuja una línea separadora.
            currentY += 5; // Un pequeño espacio después de la línea.

            // Itera sobre cada fila del DataGridView para imprimir los datos.
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) // Ignora la fila de nueva entrada si existe.
                    continue;

                currentX = startX; // Restablece la posición X para cada nueva fila.
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (dataGridView1.Columns[cell.ColumnIndex].Visible) // Solo imprime celdas de columnas visibles.
                    {
                        if (cell.Value != null) // Asegura que el valor de la celda no sea nulo.
                        {
                            graphics.DrawString(cell.Value.ToString(), font, Brushes.Black, currentX, currentY);
                        }
                        currentX += dataGridView1.Columns[cell.ColumnIndex].Width + cellPadding; // Avanza la posición X para la siguiente celda.
                    }
                }
                currentY += (int)(fontHeight + 5); // Avanza la posición Y para la siguiente fila.

                // Comprueba si se ha llegado al final de la página.
                if (currentY >= e.MarginBounds.Bottom - fontHeight)
                {
                    e.HasMorePages = true; // Indica que hay más páginas por imprimir.
                    return; // Sale del manejador de eventos para que se genere una nueva página.
                }
            }
            e.HasMorePages = false; // Indica que no hay más páginas después de imprimir todas las filas.
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
        }

        // Maneja el clic en el botón Guardar, actualizando el estado de la habitación seleccionada.
        private void btnguardar_Click(object sender, EventArgs e)
        {
            // Verifica si hay una fila seleccionada.
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una habitación para cambiar su estado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Verifica si se ha seleccionado un nuevo estado en el ComboBox.
            if (materialComboBoxEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el nuevo estado que desea asignar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtiene el ID de la habitación de la fila seleccionada y el nuevo estado.
            int idHabitacion = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
            string nuevoEstado = materialComboBoxEstado.SelectedItem.ToString();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(conexion))
                {
                    conn.Open(); // Abre la conexión.
                    string query = "UPDATE Habitaciones SET estado = @estado WHERE id_habitacion = @id"; // Consulta SQL para actualizar el estado.
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@estado", nuevoEstado); // Asigna el nuevo estado.
                        cmd.Parameters.AddWithValue("@id", idHabitacion); // Asigna el ID de la habitación.
                        cmd.ExecuteNonQuery(); // Ejecuta la actualización.

                        MessageBox.Show("Estado de habitación actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MostrarHabitaciones(); // Actualiza el DataGridView para reflejar el cambio.
                        ActualizarContadorHabitaciones(); // Actualiza los contadores de habitaciones.
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el estado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Maneja el clic en el botón Retornar, volviendo al menú principal.
        private void btnreturn_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu(); // Crea una nueva instancia del formulario de menú.
            menu.Show(); // Muestra el formulario de menú.
            this.Hide(); // Oculta el formulario actual (ReservaHabitaciones).
        }

        // Maneja el clic en el materialTxtHabitaciones, actualizando el total de habitaciones.
        private void materialTxtHabitaciones_Click(object sender, EventArgs e)
        {
            ActualizarTotalHabitaciones(); // Llama a la función para actualizar el total de habitaciones en el campo de texto.
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
           
        }

        // Maneja el clic en el botón Imprimir, mostrando un cuadro de diálogo de vista previa de impresión.
        private void btnimprimir_Click_1(object sender, EventArgs e)
        {
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog(); // Crea una nueva instancia del diálogo de vista previa de impresión.
            printPreviewDialog.Document = printDocument1; // Asigna el documento de impresión a la vista previa.
            printPreviewDialog.ShowDialog(); // Muestra el diálogo de vista previa de impresión.
        }
    }
}