namespace Presentacion.Formularios
{
    partial class FrmProductos
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
            pnlSuperior = new Panel();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            btnActualizar = new Button();
            btnAgregar = new Button();
            txtStock = new TextBox();
            txtPrecio = new TextBox();
            txtNombre = new TextBox();
            lblStock = new Label();
            lblPrecio = new Label();
            lblNombre = new Label();
            pnlInferior = new Panel();
            lblMensaje = new Label();
            lblUsuarioActual = new Label();
            dgvProductos = new DataGridView();
            pnlSuperior.SuspendLayout();
            pnlInferior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // pnlSuperior
            // 
            pnlSuperior.Controls.Add(btnLimpiar);
            pnlSuperior.Controls.Add(btnEliminar);
            pnlSuperior.Controls.Add(btnActualizar);
            pnlSuperior.Controls.Add(btnAgregar);
            pnlSuperior.Controls.Add(txtStock);
            pnlSuperior.Controls.Add(txtPrecio);
            pnlSuperior.Controls.Add(txtNombre);
            pnlSuperior.Controls.Add(lblStock);
            pnlSuperior.Controls.Add(lblPrecio);
            pnlSuperior.Controls.Add(lblNombre);
            pnlSuperior.Dock = DockStyle.Top;
            pnlSuperior.Location = new Point(0, 0);
            pnlSuperior.Name = "pnlSuperior";
            pnlSuperior.Size = new Size(800, 140);
            pnlSuperior.TabIndex = 0;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(392, 106);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(90, 28);
            btnLimpiar.TabIndex = 9;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(488, 106);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(90, 28);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(296, 106);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(90, 28);
            btnActualizar.TabIndex = 7;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(200, 106);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(90, 28);
            btnAgregar.TabIndex = 6;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(573, 48);
            txtStock.MaxLength = 100;
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(120, 26);
            txtStock.TabIndex = 5;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(425, 48);
            txtPrecio.MaxLength = 100;
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(120, 26);
            txtPrecio.TabIndex = 4;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(91, 48);
            txtNombre.MaxLength = 100;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(300, 26);
            txtNombre.TabIndex = 3;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(614, 25);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(45, 20);
            lblStock.TabIndex = 2;
            lblStock.Text = "Stock";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(458, 25);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(50, 20);
            lblPrecio.TabIndex = 1;
            lblPrecio.Text = "Precio";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(194, 25);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(64, 20);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            // 
            // pnlInferior
            // 
            pnlInferior.Controls.Add(lblMensaje);
            pnlInferior.Controls.Add(lblUsuarioActual);
            pnlInferior.Dock = DockStyle.Bottom;
            pnlInferior.Location = new Point(0, 412);
            pnlInferior.Name = "pnlInferior";
            pnlInferior.Size = new Size(800, 38);
            pnlInferior.TabIndex = 1;
            // 
            // lblMensaje
            // 
            lblMensaje.Dock = DockStyle.Fill;
            lblMensaje.Location = new Point(0, 0);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(540, 38);
            lblMensaje.TabIndex = 1;
            lblMensaje.Text = "label1";
            lblMensaje.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUsuarioActual
            // 
            lblUsuarioActual.Dock = DockStyle.Right;
            lblUsuarioActual.Font = new Font("Segoe UI", 8.765218F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuarioActual.Location = new Point(540, 0);
            lblUsuarioActual.Name = "lblUsuarioActual";
            lblUsuarioActual.Size = new Size(260, 38);
            lblUsuarioActual.TabIndex = 0;
            lblUsuarioActual.Text = "label1";
            lblUsuarioActual.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Dock = DockStyle.Fill;
            dgvProductos.Location = new Point(0, 140);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.RowHeadersWidth = 49;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(800, 272);
            dgvProductos.TabIndex = 2;
            dgvProductos.CellClick += dgvProductos_CellClick;
            // 
            // FrmProductos
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(dgvProductos);
            Controls.Add(pnlInferior);
            Controls.Add(pnlSuperior);
            Name = "FrmProductos";
            Text = "Inicio – Productos";
            pnlSuperior.ResumeLayout(false);
            pnlSuperior.PerformLayout();
            pnlInferior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSuperior;
        private Label lblStock;
        private Label lblPrecio;
        private Label lblNombre;
        private Panel pnlInferior;
        private DataGridView dgvProductos;
        private TextBox txtStock;
        private TextBox txtPrecio;
        private TextBox txtNombre;
        private Button btnActualizar;
        private Button btnAgregar;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Label lblMensaje;
        private Label lblUsuarioActual;
    }
}