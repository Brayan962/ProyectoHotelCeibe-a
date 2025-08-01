namespace ProyectoHotelCeibeña
{
    partial class MENULOGIN
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnIngresar = new Button();
            txtNombreUsuario = new TextBox();
            txtContraseña = new TextBox();
            pictureBox3 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            btnBorrar = new Button();
            btnSalir = new Button();
            panel1 = new Panel();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(158, 12);
            label1.Name = "label1";
            label1.Size = new Size(0, 29);
            label1.TabIndex = 0;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.MediumAquamarine;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIngresar.Location = new Point(100, 336);
            btnIngresar.Margin = new Padding(3, 4, 3, 4);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(114, 55);
            btnIngresar.TabIndex = 2;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(238, 189);
            txtNombreUsuario.Margin = new Padding(3, 4, 3, 4);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(267, 27);
            txtNombreUsuario.TabIndex = 3;
            txtNombreUsuario.UseSystemPasswordChar = true;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(238, 254);
            txtContraseña.Margin = new Padding(3, 4, 3, 4);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(267, 27);
            txtContraseña.TabIndex = 4;
            txtContraseña.UseSystemPasswordChar = true;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.LogoHotel;
            pictureBox3.Location = new Point(205, -19);
            pictureBox3.Margin = new Padding(3, 4, 3, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(176, 150);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 7;
            pictureBox3.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(53, 192);
            label2.Name = "label2";
            label2.Size = new Size(176, 23);
            label2.TabIndex = 8;
            label2.Text = "Nombre Usuario:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(94, 257);
            label3.Name = "label3";
            label3.Size = new Size(130, 23);
            label3.TabIndex = 9;
            label3.Text = "Contraseña:";
            // 
            // btnBorrar
            // 
            btnBorrar.BackColor = Color.FromArgb(255, 128, 128);
            btnBorrar.FlatStyle = FlatStyle.Flat;
            btnBorrar.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBorrar.Location = new Point(239, 336);
            btnBorrar.Margin = new Padding(3, 4, 3, 4);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(114, 55);
            btnBorrar.TabIndex = 10;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = false;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(128, 128, 255);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = SystemColors.ControlText;
            btnSalir.Location = new Point(378, 336);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(114, 55);
            btnSalir.TabIndex = 11;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(254, 189, 89);
            panel1.Controls.Add(pictureBox3);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(589, 93);
            panel1.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(248, 113);
            label4.Name = "label4";
            label4.Size = new Size(105, 34);
            label4.TabIndex = 13;
            label4.Text = "Log In";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(2, 48, 71);
            ClientSize = new Size(589, 428);
            Controls.Add(label4);
            Controls.Add(panel1);
            Controls.Add(btnSalir);
            Controls.Add(btnBorrar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtContraseña);
            Controls.Add(txtNombreUsuario);
            Controls.Add(btnIngresar);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Log In";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnIngresar;
        private TextBox txtNombreUsuario;
        private TextBox txtContraseña;
        private PictureBox pictureBox3;
        private Label label2;
        private Label label3;
        private Button btnBorrar;
        private Button btnSalir;
        private Panel panel1;
        private Label label4;
    }
}
