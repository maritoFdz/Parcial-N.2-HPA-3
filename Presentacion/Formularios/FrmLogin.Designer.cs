namespace Presentacion.Formularios
{
    partial class FrmLogin
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
            lblTitulo = new Label();
            lblUsuario = new Label();
            lblPassword = new Label();
            lblMensaje = new Label();
            txtUsuario = new TextBox();
            txtPassword = new TextBox();
            btnIngresar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(273, 42);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(94, 20);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Iniciar sesión";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(284, 134);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(59, 20);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(273, 195);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(83, 20);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Contraseña";
            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.ForeColor = Color.Firebrick;
            lblMensaje.Location = new Point(284, 306);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(0, 20);
            lblMensaje.TabIndex = 3;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(256, 157);
            txtUsuario.MaxLength = 50;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(120, 26);
            txtUsuario.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(256, 218);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(120, 26);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(273, 250);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(90, 28);
            btnIngresar.TabIndex = 6;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // FrmLogin
            // 
            AcceptButton = btnIngresar;
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnIngresar);
            Controls.Add(txtPassword);
            Controls.Add(txtUsuario);
            Controls.Add(lblMensaje);
            Controls.Add(lblPassword);
            Controls.Add(lblUsuario);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Iniciar sesión";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblUsuario;
        private Label lblPassword;
        private Label lblMensaje;
        private TextBox txtUsuario;
        private TextBox txtPassword;
        private Button btnIngresar;
    }
}
