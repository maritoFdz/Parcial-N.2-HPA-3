namespace Presentacion.Formularios
{
    partial class FrmRegistroUsuario
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
            lblTitulo = new Label();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConfirmar = new Label();
            txtConfirmacion = new TextBox();
            btnRegistrar = new Button();
            lblMensaje = new Label();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 13.7739134F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(93, 22);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(162, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Nuevo usuario";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(136, 91);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(59, 20);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(107, 114);
            txtUsuario.MaxLength = 50;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(120, 26);
            txtUsuario.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(50, 143);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(231, 20);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Contraseña (mínimo 6 caracteres)";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(107, 166);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(120, 26);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmar
            // 
            lblConfirmar.AutoSize = true;
            lblConfirmar.Location = new Point(93, 195);
            lblConfirmar.Name = "lblConfirmar";
            lblConfirmar.Size = new Size(151, 20);
            lblConfirmar.TabIndex = 5;
            lblConfirmar.Text = "Confirmar contraseña";
            // 
            // txtConfirmacion
            // 
            txtConfirmacion.Location = new Point(107, 218);
            txtConfirmacion.Name = "txtConfirmacion";
            txtConfirmacion.Size = new Size(120, 26);
            txtConfirmacion.TabIndex = 6;
            txtConfirmacion.UseSystemPasswordChar = true;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(119, 260);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(90, 28);
            btnRegistrar.TabIndex = 7;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.Dock = DockStyle.Bottom;
            lblMensaje.Location = new Point(0, 315);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(0, 20);
            lblMensaje.TabIndex = 8;
            lblMensaje.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 102, 204);
            panel1.Controls.Add(lblTitulo);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(342, 76);
            panel1.TabIndex = 9;
            // 
            // FrmRegistroUsuario
            // 
            AcceptButton = btnRegistrar;
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(342, 335);
            Controls.Add(lblMensaje);
            Controls.Add(btnRegistrar);
            Controls.Add(txtConfirmacion);
            Controls.Add(lblConfirmar);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(panel1);
            Name = "FrmRegistroUsuario";
            Text = "Registrar usuario";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblConfirmar;
        private TextBox txtConfirmacion;
        private Button btnRegistrar;
        private Label lblMensaje;
        private Panel panel1;
    }
}