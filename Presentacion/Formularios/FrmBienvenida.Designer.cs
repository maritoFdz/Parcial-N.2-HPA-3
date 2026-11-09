namespace Presentacion.Formularios
{
    partial class FrmBienvenida
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
            lblBienvenida = new Label();
            SuspendLayout();
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Dock = DockStyle.Fill;
            lblBienvenida.Font = new Font("Segoe UI", 11.8956518F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBienvenida.Location = new Point(0, 0);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(63, 25);
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "label1";
            lblBienvenida.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmBienvenida
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblBienvenida);
            Name = "FrmBienvenida";
            Text = "Inicio";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBienvenida;
    }
}