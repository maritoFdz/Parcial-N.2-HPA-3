namespace Presentacion.Formularios
{
    partial class FrmPrincipal
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
            components = new System.ComponentModel.Container();
            pnlMenu = new Panel();
            btnInicio = new Button();
            btnCerrarSesion = new Button();
            btnRegistrar = new Button();
            lblTitulo = new Label();
            lblHora = new Label();
            lblFecha = new Label();
            pnlUsuario = new Panel();
            lblUsuario = new Label();
            lblSesion = new Label();
            tmrReloj = new System.Windows.Forms.Timer(components);
            pnlMenu.SuspendLayout();
            pnlUsuario.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.FromArgb(0, 102, 204);
            pnlMenu.Controls.Add(btnInicio);
            pnlMenu.Controls.Add(btnCerrarSesion);
            pnlMenu.Controls.Add(btnRegistrar);
            pnlMenu.Controls.Add(lblTitulo);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(230, 450);
            pnlMenu.TabIndex = 1;
            // 
            // btnInicio
            // 
            btnInicio.BackColor = Color.FromArgb(0, 102, 204);
            btnInicio.FlatAppearance.BorderSize = 0;
            btnInicio.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 77, 153);
            btnInicio.FlatStyle = FlatStyle.Flat;
            btnInicio.ForeColor = Color.White;
            btnInicio.Location = new Point(0, 293);
            btnInicio.Name = "btnInicio";
            btnInicio.Size = new Size(230, 48);
            btnInicio.TabIndex = 5;
            btnInicio.Text = "Inicio";
            btnInicio.TextAlign = ContentAlignment.MiddleLeft;
            btnInicio.UseVisualStyleBackColor = false;
            btnInicio.Click += btnInicio_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.FromArgb(0, 102, 204);
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 77, 153);
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Location = new Point(0, 401);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(230, 48);
            btnCerrarSesion.TabIndex = 7;
            btnCerrarSesion.Text = "Cerrar sesión";
            btnCerrarSesion.TextAlign = ContentAlignment.MiddleLeft;
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.FromArgb(0, 102, 204);
            btnRegistrar.FlatAppearance.BorderSize = 0;
            btnRegistrar.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 77, 153);
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Location = new Point(0, 347);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(230, 48);
            btnRegistrar.TabIndex = 6;
            btnRegistrar.Text = "Registrar usuario";
            btnRegistrar.TextAlign = ContentAlignment.MiddleLeft;
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 13.7739134F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(72, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(79, 30);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "MENÚ";
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Dock = DockStyle.Right;
            lblHora.Font = new Font("Segoe UI", 21.913044F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHora.ForeColor = Color.White;
            lblHora.Location = new Point(450, 0);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(120, 47);
            lblHora.TabIndex = 3;
            lblHora.Text = "label1";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Dock = DockStyle.Right;
            lblFecha.Font = new Font("Segoe UI", 8.765218F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFecha.ForeColor = Color.White;
            lblFecha.Location = new Point(400, 0);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(50, 20);
            lblFecha.TabIndex = 4;
            lblFecha.Text = "label1";
            // 
            // pnlUsuario
            // 
            pnlUsuario.BackColor = Color.FromArgb(0, 77, 153);
            pnlUsuario.Controls.Add(lblUsuario);
            pnlUsuario.Controls.Add(lblFecha);
            pnlUsuario.Controls.Add(lblSesion);
            pnlUsuario.Controls.Add(lblHora);
            pnlUsuario.Dock = DockStyle.Bottom;
            pnlUsuario.Location = new Point(230, 375);
            pnlUsuario.Name = "pnlUsuario";
            pnlUsuario.Size = new Size(570, 75);
            pnlUsuario.TabIndex = 8;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 11.8956518F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuario.ForeColor = Color.White;
            lblUsuario.Location = new Point(149, 9);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(65, 25);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "label1";
            // 
            // lblSesion
            // 
            lblSesion.AutoSize = true;
            lblSesion.Font = new Font("Segoe UI", 8.765218F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSesion.ForeColor = Color.Gainsboro;
            lblSesion.Location = new Point(15, 14);
            lblSesion.Name = "lblSesion";
            lblSesion.Size = new Size(138, 20);
            lblSesion.TabIndex = 0;
            lblSesion.Text = "Sesión iniciada por:";
            // 
            // tmrReloj
            // 
            tmrReloj.Interval = 1000;
            tmrReloj.Tick += tmrReloj_Tick;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlUsuario);
            Controls.Add(pnlMenu);
            IsMdiContainer = true;
            Name = "FrmPrincipal";
            Text = "Parcial N.2 por Mario Fernandez";
            WindowState = FormWindowState.Maximized;
            Shown += FrmPrincipal_Shown;
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            pnlUsuario.ResumeLayout(false);
            pnlUsuario.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMenu;
        private Label lblTitulo;
        private Label lblHora;
        private Label lblFecha;
        private Button btnInicio;
        private Button btnRegistrar;
        private Button btnCerrarSesion;
        private Panel pnlUsuario;
        private Label lblUsuario;
        private Label lblSesion;
        private System.Windows.Forms.Timer tmrReloj;
    }
}