namespace ProyectoHotelCeibeña
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            panel2 = new Panel();
            label1 = new Label();
            btnINICIO = new Button();
            pictureBox1 = new PictureBox();
            btnClientes = new Button();
            btnHabitacionesReservas = new Button();
            btnFacturacion = new Button();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(254, 189, 89);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(btnINICIO);
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(0, -1);
            panel2.Name = "panel2";
            panel2.Size = new Size(1046, 74);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(278, 23);
            label1.Name = "label1";
            label1.Size = new Size(268, 40);
            label1.TabIndex = 7;
            label1.Text = "Menu Principal";
            // 
            // btnINICIO
            // 
            btnINICIO.BackColor = Color.Transparent;
            btnINICIO.BackgroundImage = (Image)resources.GetObject("btnINICIO.BackgroundImage");
            btnINICIO.BackgroundImageLayout = ImageLayout.Stretch;
            btnINICIO.Cursor = Cursors.Hand;
            btnINICIO.FlatAppearance.BorderSize = 0;
            btnINICIO.FlatStyle = FlatStyle.Flat;
            btnINICIO.ForeColor = Color.FromArgb(166, 204, 238);
            btnINICIO.Location = new Point(688, 12);
            btnINICIO.Margin = new Padding(3, 2, 3, 2);
            btnINICIO.Name = "btnINICIO";
            btnINICIO.Size = new Size(63, 51);
            btnINICIO.TabIndex = 6;
            btnINICIO.TextImageRelation = TextImageRelation.ImageAboveText;
            btnINICIO.UseVisualStyleBackColor = false;
            btnINICIO.Click += btnINICIO_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.LogoHotel;
            pictureBox1.Location = new Point(0, -12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(156, 104);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnClientes
            // 
            btnClientes.BackColor = Color.FromArgb(33, 158, 188);
            btnClientes.BackgroundImage = (Image)resources.GetObject("btnClientes.BackgroundImage");
            btnClientes.BackgroundImageLayout = ImageLayout.Stretch;
            btnClientes.FlatAppearance.BorderColor = Color.FromArgb(142, 202, 230);
            btnClientes.FlatAppearance.BorderSize = 5;
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClientes.ForeColor = Color.White;
            btnClientes.Location = new Point(173, 196);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(108, 98);
            btnClientes.TabIndex = 15;
            btnClientes.UseVisualStyleBackColor = false;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnHabitacionesReservas
            // 
            btnHabitacionesReservas.BackColor = Color.FromArgb(33, 158, 188);
            btnHabitacionesReservas.BackgroundImage = (Image)resources.GetObject("btnHabitacionesReservas.BackgroundImage");
            btnHabitacionesReservas.BackgroundImageLayout = ImageLayout.Stretch;
            btnHabitacionesReservas.FlatAppearance.BorderColor = Color.FromArgb(142, 202, 230);
            btnHabitacionesReservas.FlatAppearance.BorderSize = 5;
            btnHabitacionesReservas.FlatStyle = FlatStyle.Flat;
            btnHabitacionesReservas.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHabitacionesReservas.ForeColor = Color.FromArgb(2, 48, 71);
            btnHabitacionesReservas.ImageAlign = ContentAlignment.TopCenter;
            btnHabitacionesReservas.Location = new Point(349, 196);
            btnHabitacionesReservas.Name = "btnHabitacionesReservas";
            btnHabitacionesReservas.Size = new Size(108, 98);
            btnHabitacionesReservas.TabIndex = 16;
            btnHabitacionesReservas.TextAlign = ContentAlignment.BottomCenter;
            btnHabitacionesReservas.UseVisualStyleBackColor = false;
            btnHabitacionesReservas.Click += btnHabitacionesReservas_Click;
            // 
            // btnFacturacion
            // 
            btnFacturacion.BackColor = Color.FromArgb(33, 158, 188);
            btnFacturacion.BackgroundImage = (Image)resources.GetObject("btnFacturacion.BackgroundImage");
            btnFacturacion.BackgroundImageLayout = ImageLayout.Stretch;
            btnFacturacion.FlatAppearance.BorderColor = Color.FromArgb(142, 202, 230);
            btnFacturacion.FlatAppearance.BorderSize = 5;
            btnFacturacion.FlatStyle = FlatStyle.Flat;
            btnFacturacion.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFacturacion.ForeColor = Color.White;
            btnFacturacion.Location = new Point(522, 196);
            btnFacturacion.Name = "btnFacturacion";
            btnFacturacion.Size = new Size(108, 98);
            btnFacturacion.TabIndex = 17;
            btnFacturacion.UseVisualStyleBackColor = false;
            btnFacturacion.Click += btnFacturacion_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(187, 307);
            label5.Name = "label5";
            label5.Size = new Size(73, 18);
            label5.TabIndex = 19;
            label5.Text = "Clientes";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(540, 309);
            label6.Name = "label6";
            label6.Size = new Size(80, 18);
            label6.TabIndex = 20;
            label6.Text = "Facturas";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ButtonHighlight;
            label7.Location = new Point(342, 307);
            label7.Name = "label7";
            label7.Size = new Size(113, 18);
            label7.TabIndex = 21;
            label7.Text = "Habitaciones";
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(2, 48, 71);
            ClientSize = new Size(789, 418);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(btnFacturacion);
            Controls.Add(btnHabitacionesReservas);
            Controls.Add(btnClientes);
            Controls.Add(panel2);
            Name = "Menu";
            Text = "Menu";
            Load += Menu_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel2;
        private PictureBox pictureBox1;
        private Button btnINICIO;
        private Label label1;
        private Button btnClientes;
        private Button btnHabitacionesReservas;
        private Button btnFacturacion;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}