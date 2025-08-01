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

    public partial class Facturacion : Form

    {

        // Cadena de conexión a la base de datos

        string conexion = "server=localhost;user=root;password=Mikel2006429;database=HotelLaCeibenia";



        // Instancias de los UserControls de pago

        private EFECTIVO efectivoControl;

        private TARJETA tarjetaControl;



        // Propiedades para la impresión y visualización de datos

        private Random random = new Random();

        public System.Windows.Forms.TextBox textBox1;



        private PrintDocument printDocument = new PrintDocument();



        private DataTable tablaDatos;

        private DataView vistaFiltrada;



        public Facturacion()

        {

            InitializeComponent();

            printDocument.PrintPage += PrintDocument_PrintPage;



            // Inicialización de los UserControls de pago

            efectivoControl = new EFECTIVO();

            tarjetaControl = new TARJETA();



            // Configuración del Dock para que llenen el panel contenedor

            efectivoControl.Dock = DockStyle.Fill;

            tarjetaControl.Dock = DockStyle.Fill;



            // Añadir los UserControls al panel contenedor (panel9) una sola vez al inicio

            panel9.Controls.Add(efectivoControl);

            panel9.Controls.Add(tarjetaControl);



            // Asegurarse de que ambos UserControls estén ocultos al inicio

            efectivoControl.Visible = false;

            tarjetaControl.Visible = false;


            // Cargar los items del ComboBox

            SetupComboBoxItems();

        }





        /// Refresca el DataGridView con los datos más recientes y oculta los controles de pago.

        /// Se invoca cuando un pago es guardado exitosamente en los UserControls de pago.

        private void UserControl_PagoGuardado(object sender, EventArgs e)

        {

            CargarDatos(); // Refrescar el DataGridView con los datos más recientes

            // Ocultar los UserControls de pago y limpiar la selección del ComboBox

            efectivoControl.Visible = false;

            tarjetaControl.Visible = false;

            comboBox1.SelectedIndex = -1;

        }





        /// Configura los elementos disponibles en el ComboBox para la selección del método de pago.

        private void SetupComboBoxItems()

        {

            comboBox1.Items.Clear();

            comboBox1.Items.Add("Efectivo");

            comboBox1.Items.Add("Tarjeta");

            comboBox1.SelectedIndex = -1; // No seleccionar nada por defecto

        }



        /// Maneja el cambio de selección en el ComboBox de método de pago, mostrando u ocultando

        /// el UserControl de pago correspondiente (Efectivo o Tarjeta).

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)

        {

            // Importante: No usar panel9.Controls.Clear() aquí.

            // Los controles ya están añadidos y solo necesitamos controlar su visibilidad.



            if (comboBox1.SelectedItem != null)

            {

                string selectedOption = comboBox1.SelectedItem.ToString();



                switch (selectedOption)

                {

                    case "Efectivo":

                        MostrarUserControl(efectivoControl); // Muestra el UserControl de Efectivo

                        break;

                    case "Tarjeta":

                        MostrarUserControl(tarjetaControl); // Muestra el UserControl de Tarjeta

                        break;

                    default:

                        // Si se selecciona algo inesperado o se borra la selección, ocultar ambos

                        efectivoControl.Visible = false;

                        tarjetaControl.Visible = false;

                        break;

                }

            }

            else

            {

                // Si la selección del ComboBox está vacía, ocultar ambos

                efectivoControl.Visible = false;

                tarjetaControl.Visible = false;

            }

        }



        /// Oculta todos los UserControls de pago y luego muestra solo el UserControl especificado,

        /// asegurando que esté al frente de otros controles.

        private void MostrarUserControl(UserControl ucToShow)

        {

            // Primero, ocultar todos los UserControls de pago

            efectivoControl.Visible = false;

            tarjetaControl.Visible = false;



            // Luego, mostrar solo el UserControl deseado

            ucToShow.Visible = true;

            ucToShow.BringToFront(); // Asegura que el control esté al frente

        }



        /// Maneja el clic en el botón para regresar al menú principal, limpiando la UI de pago si es necesario.

        private void btnRegresarMenu_Click(object sender, EventArgs e)

        {

            // Opcional: Llama a UserControl_PagoGuardado para limpiar la UI de pago antes de salir

            UserControl_PagoGuardado(sender, e);

            Menu menu = new Menu();

            menu.Show();

            this.Hide();

        }



        /// Carga los datos de pagos desde la base de datos en el DataGridView principal del formulario.

        private void CargarDatos()

        {

            using (MySqlConnection connec = new MySqlConnection(conexion))

            {

                try

                {

                    connec.Open();

                    string sql = "SELECT id_pago, id_reserva, fecha_pago, monto_total, metodo_pago FROM Pagos";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connec);

                    tablaDatos = new DataTable(); // Asegura que tablaDatos se inicialice aquí también si se llama desde fuera de Load

                    adapter.Fill(tablaDatos);



                    vistaFiltrada = new DataView(tablaDatos); // Reinicia la vista filtrada con los nuevos datos

                    dataGridView1.DataSource = vistaFiltrada;

                }

                catch (Exception ex)

                {

                    MessageBox.Show("Error al cargar datos: " + ex.Message);

                }

            }

        }



        /// Elimina un registro de pago de la base de datos dado su ID.

        private void EliminarRegistro(int id)

        {

            try

            {

                using (MySqlConnection con = new MySqlConnection(conexion))

                {

                    con.Open();

                    string query = "DELETE FROM Pagos WHERE id_pago = @id_pago";

                    MySqlCommand cmd = new MySqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@id_pago", id);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Registro eliminado correctamente.");

                }

            }

            catch (Exception ex)

            {

                MessageBox.Show("Error al eliminar: " + ex.Message);

            }

        }



        /// Maneja el clic en el botón para cargar o actualizar los datos en el DataGridView.

        private void button2_Click(object sender, EventArgs e) // Botón de Cargar Datos/Actualizar

        {

            CargarDatos();

        }



        /// Maneja el clic en el botón para eliminar un registro seleccionado en el DataGridView.

        /// Muestra una confirmación antes de la eliminación.

        private void btneliminar_Click_1(object sender, EventArgs e) // Botón de Eliminar

        {

            if (dataGridView1.CurrentRow != null)

            {

                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_pago"].Value);



                DialogResult confirmacion = MessageBox.Show("¿Deseas eliminar este registro?", "Confirmar", MessageBoxButtons.YesNo);

                if (confirmacion == DialogResult.Yes)

                {

                    EliminarRegistro(id);

                    CargarDatos(); // Refrescar DataGridView después de eliminar

                }

            }

            else

            {

                MessageBox.Show("Selecciona un registro para eliminar");

            }

        }



        /// Evento que se dispara al cargar el formulario. Llama a CargarDatos() para mostrar la información inicial.

        private void Facturacion_Load(object sender, EventArgs e)

        {

            CargarDatos();

        }



        /// Maneja el evento de cambio de texto en el TextBox de búsqueda.

        /// Filtra los datos del DataGridView en tiempo real y resalta las celdas que coinciden.

        private void textBox2_TextChanged(object sender, EventArgs e)

        {

            string textoBusqueda = textBox2.Text.Trim();



            // Limpiar resaltados anteriores

            foreach (DataGridViewRow row in dataGridView1.Rows)

            {

                foreach (DataGridViewCell cell in row.Cells)

                {

                    cell.Style.BackColor = System.Drawing.Color.Empty;

                    cell.Style.ForeColor = System.Drawing.Color.Empty;

                }

            }



            if (dataGridView1.DataSource is DataView dataView)

            {

                if (string.IsNullOrWhiteSpace(textoBusqueda))

                {

                    dataView.RowFilter = string.Empty; // Si el texto de búsqueda está vacío, elimina el filtro.

                }

                else

                {

                    // Escapar comillas simples para evitar errores en el filtro de DataView.

                    string textoEscapado = textoBusqueda.Replace("'", "''");

                    string filtro = "";

                    bool primeraColumna = true;



                    // Construir la cadena de filtro para todas las columnas visibles.

                    foreach (DataGridViewColumn col in dataGridView1.Columns)

                    {

                        if (col.Visible && !string.IsNullOrEmpty(col.DataPropertyName))

                        {

                            if (!primeraColumna)

                            {

                                filtro += " OR ";

                            }

                            // Convertir a String para comparar cualquier tipo de dato.

                            filtro += $"CONVERT([{col.DataPropertyName}], 'System.String') LIKE '%{textoEscapado}%'";

                            primeraColumna = false;

                        }

                    }

                    dataView.RowFilter = filtro; // Aplica el filtro a la DataView.

                }

            }



            // Resaltar celdas que coinciden con la búsqueda

            if (!string.IsNullOrWhiteSpace(textoBusqueda))

            {

                foreach (DataGridViewRow row in dataGridView1.Rows)

                {

                    if (row.Visible) // Solo resaltar filas que son visibles después del filtro

                    {

                        foreach (DataGridViewCell cell in row.Cells)

                        {

                            if (cell.Value != null && cell.Value.ToString().IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0)

                            {

                                cell.Style.BackColor = System.Drawing.Color.ForestGreen;

                                cell.Style.ForeColor = System.Drawing.Color.Black;

                            }

                        }

                    }

                }

            }

        }



        /// Dibuja el contenido de cada página a imprimir. Recupera los datos de pagos de la BD

        /// y los formatea para la impresión.

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)

        {

            float yPos = e.MarginBounds.Top;

            float leftMargin = e.MarginBounds.Left;

            Font fuente = new Font("Arial", 7);

            float lineHeight = fuente.GetHeight(e.Graphics);



            using (MySqlConnection connec = new MySqlConnection(conexion))

            {

                try

                {

                    connec.Open();

                    string sql = "SELECT id_pago, id_reserva, fecha_pago, monto_total, metodo_pago FROM Pagos";

                    MySqlCommand cmd = new MySqlCommand(sql, connec);

                    MySqlDataReader reader = cmd.ExecuteReader();



                    // Dibuja el título del listado de facturas.

                    e.Graphics.DrawString("LISTADO DE FACTURAS:", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, leftMargin, yPos);

                    yPos += lineHeight * 2; // Deja un espacio después del título.



                    // Itera sobre los resultados del lector de datos y dibuja cada línea en la página.

                    while (reader.Read())

                    {

                        string linea = $"ID DEL PAGO: {reader["id_pago"]}  |  ID DE LA RESERVA: {reader["id_reserva"]}  |  FECHA DE PAGO: {reader["fecha_pago"]}  |  MONTO TOTAL: {reader["monto_total"]}  |  METODO DE PAGO: {reader["metodo_pago"]}";

                        e.Graphics.DrawString(linea, fuente, Brushes.Black, leftMargin, yPos);

                        yPos += lineHeight; // Avanza a la siguiente línea.



                        // Si se supera el límite inferior de la página, indica que hay más páginas.

                        if (yPos > e.MarginBounds.Bottom)

                        {

                            e.HasMorePages = true;

                            return; // Sale del método para que se dibuje la siguiente página.

                        }

                    }

                    reader.Close(); // Cierra el lector de datos.

                }

                catch (Exception ex)

                {

                    MessageBox.Show("Error al imprimir: " + ex.Message);

                }

            }

        }






        private void tabPage1_Click(object sender, EventArgs e) { }





        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e) { }




        private void btnreturn_Click_1(object sender, EventArgs e) 
        { Menu menu = new Menu();
          menu.Show(); 
          this.Hide(); 
        }




        private void btnhome_Click(object sender, EventArgs e) { Menu menu = new Menu(); menu.Show(); this.Hide(); }




        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) { }




        private void panel9_Paint(object sender, PaintEventArgs e) { }




        private void tabPage2_Click(object sender, EventArgs e) { }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }



        /// Maneja el clic en el botón de impresión. Abre un diálogo de impresión y envía el documento a la impresora.

        private void btnprint_Click(object sender, EventArgs e)

        {

            PrintDialog printDialog = new PrintDialog();

            printDialog.Document = printDocument;



            if (printDialog.ShowDialog() == DialogResult.OK)

            {

                PaperSize a7 = new PaperSize("A7", 291, 413);



                printDocument.DefaultPageSettings.PaperSize = a7;

                printDocument.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);



                printDocument.Print();

            }

        }





        /// Maneja el clic en el botón de actualizar, volviendo a cargar los datos en el DataGridView.

        private void btnactualizar_Click(object sender, EventArgs e)

        {

            CargarDatos();

        }





        private void tabPage2_Click_1(object sender, EventArgs e)

        {



        }

        private void btnhome_Click_1(object sender, EventArgs e)
        {          
                Menu menu = new Menu();
                menu.Show();
                this.Hide();
        }
    }

}