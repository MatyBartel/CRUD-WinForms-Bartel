namespace WinFormApp
{
    partial class FrmInicio
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
            txtCorreo = new TextBox();
            txtPass = new TextBox();
            btnIniciar = new Button();
            lblCorreo = new Label();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(12, 100);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(222, 23);
            txtCorreo.TabIndex = 0;
            // 
            // txtPass
            // 
            txtPass.Location = new Point(12, 152);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '*';
            txtPass.Size = new Size(222, 23);
            txtPass.TabIndex = 1;
            // 
            // btnIniciar
            // 
            btnIniciar.Location = new Point(49, 192);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(149, 49);
            btnIniciar.TabIndex = 2;
            btnIniciar.Text = "INICIAR SESION";
            btnIniciar.UseVisualStyleBackColor = true;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(12, 82);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(46, 15);
            lblCorreo.TabIndex = 3;
            lblCorreo.Text = "Correo:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 134);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 4;
            label1.Text = "Contraseña:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(28, 36);
            label2.Name = "label2";
            label2.Size = new Size(190, 25);
            label2.TabIndex = 5;
            label2.Text = "INGRESA TU CUENTA";
            // 
            // FrmInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(246, 271);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblCorreo);
            Controls.Add(btnIniciar);
            Controls.Add(txtPass);
            Controls.Add(txtCorreo);
            Name = "FrmInicio";
            Text = "INICIO";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCorreo;
        private TextBox txtPass;
        private Button btnIniciar;
        private Label lblCorreo;
        private Label label1;
        private Label label2;
    }
}