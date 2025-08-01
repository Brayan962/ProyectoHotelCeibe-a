namespace ProyectoHotelCeibeña
{
    partial class EFECTIVO
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EFECTIVO));
            pictureBox1 = new PictureBox();
            button10 = new Button();
            panel2 = new Panel();
            textBox4 = new TextBox();
            label6 = new Label();
            dateTimePicker1 = new DateTimePicker();
            textBox1 = new TextBox();
            textBox3 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            textBox2 = new TextBox();
            label4 = new Label();
            label1 = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(33, 158, 188);
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(23, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(99, 61);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 54;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // button10
            // 
            button10.BackColor = Color.FromArgb(33, 158, 188);
            button10.BackgroundImage = (Image)resources.GetObject("button10.BackgroundImage");
            button10.BackgroundImageLayout = ImageLayout.Zoom;
            button10.FlatAppearance.BorderColor = Color.FromArgb(33, 158, 188);
            button10.FlatStyle = FlatStyle.Flat;
            button10.Font = new Font("MS Reference Sans Serif", 10.8F);
            button10.Location = new Point(40, 240);
            button10.Name = "button10";
            button10.Size = new Size(61, 57);
            button10.TabIndex = 53;
            button10.UseVisualStyleBackColor = false;
            button10.Click += button10_Click_1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Location = new Point(-27, -4);
            panel2.Name = "panel2";
            panel2.Size = new Size(23, 372);
            panel2.TabIndex = 50;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(195, 33);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(273, 27);
            textBox4.TabIndex = 48;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial Rounded MT Bold", 10.2F);
            label6.Location = new Point(28, 40);
            label6.Name = "label6";
            label6.Size = new Size(141, 20);
            label6.TabIndex = 47;
            label6.Text = "Metodo de pago";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(195, 205);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(273, 27);
            dateTimePicker1.TabIndex = 46;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(195, 90);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(273, 27);
            textBox1.TabIndex = 43;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(195, 261);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(273, 27);
            textBox3.TabIndex = 45;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 10.2F);
            label2.Location = new Point(29, 97);
            label2.Name = "label2";
            label2.Size = new Size(140, 20);
            label2.TabIndex = 39;
            label2.Text = "Codigo de pago";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 10.2F);
            label3.Location = new Point(11, 152);
            label3.Name = "label3";
            label3.Size = new Size(160, 20);
            label3.TabIndex = 40;
            label3.Text = "Codigo de reserva";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Rounded MT Bold", 10.2F);
            label5.Location = new Point(51, 268);
            label5.Name = "label5";
            label5.Size = new Size(118, 20);
            label5.TabIndex = 42;
            label5.Text = "Total a pagar";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(195, 145);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(273, 27);
            textBox2.TabIndex = 44;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 10.2F);
            label4.Location = new Point(39, 212);
            label4.Name = "label4";
            label4.Size = new Size(130, 20);
            label4.TabIndex = 41;
            label4.Text = "Fecha de pago";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(33, 158, 188);
            label1.Font = new Font("Arial Rounded MT Bold", 10.2F);
            label1.Location = new Point(11, 300);
            label1.Name = "label1";
            label1.Size = new Size(121, 20);
            label1.TabIndex = 55;
            label1.Text = "Aceptar pago";
            label1.Click += label1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(33, 158, 188);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button10);
            panel1.Location = new Point(548, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(135, 372);
            panel1.TabIndex = 56;
            panel1.Paint += panel1_Paint;
            // 
            // EFECTIVO
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(142, 202, 230);
            Controls.Add(panel2);
            Controls.Add(textBox4);
            Controls.Add(label6);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox1);
            Controls.Add(textBox3);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(textBox2);
            Controls.Add(label4);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "EFECTIVO";
            Size = new Size(683, 372);
            Load += EFECTIVO_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button10;
        private Panel panel2;
        private TextBox textBox4;
        private Label label6;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox1;
        private TextBox textBox3;
        private Label label2;
        private Label label3;
        private Label label5;
        private TextBox textBox2;
        private Label label4;
        private Label label1;
        private Panel panel1;
    }
}
