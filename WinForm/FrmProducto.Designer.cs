namespace WinFormApp
{
    partial class FrmProducto
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
            btnAceptar = new Button();
            btnCancelar = new Button();
            lblProducto = new Label();
            cmbProductos = new ComboBox();
            txtNombre = new TextBox();
            txtAtributo2 = new TextBox();
            txtAtributo1 = new TextBox();
            label1 = new Label();
            txtStock = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            lblAtributo1 = new Label();
            lblAtributo2 = new Label();
            cmbMarca = new ComboBox();
            btnLimpiar = new Button();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(44, 353);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(127, 57);
            btnAceptar.TabIndex = 3;
            btnAceptar.Text = "ACEPTAR";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(254, 353);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(127, 57);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblProducto
            // 
            lblProducto.AutoSize = true;
            lblProducto.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblProducto.Location = new Point(148, 9);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(114, 25);
            lblProducto.TabIndex = 8;
            lblProducto.Text = "PRODUCTO";
            // 
            // cmbProductos
            // 
            cmbProductos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProductos.FormattingEnabled = true;
            cmbProductos.Items.AddRange(new object[] { "Computadora", "Telefono", "Consola" });
            cmbProductos.Location = new Point(9, 12);
            cmbProductos.Name = "cmbProductos";
            cmbProductos.Size = new Size(133, 23);
            cmbProductos.TabIndex = 9;
            cmbProductos.SelectedIndexChanged += cmbProductos_SelectedIndexChanged;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(64, 116);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(302, 23);
            txtNombre.TabIndex = 10;
            // 
            // txtAtributo2
            // 
            txtAtributo2.Location = new Point(64, 292);
            txtAtributo2.Name = "txtAtributo2";
            txtAtributo2.Size = new Size(302, 23);
            txtAtributo2.TabIndex = 11;
            // 
            // txtAtributo1
            // 
            txtAtributo1.Location = new Point(64, 248);
            txtAtributo1.Name = "txtAtributo1";
            txtAtributo1.Size = new Size(302, 23);
            txtAtributo1.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(119, 63);
            label1.Name = "label1";
            label1.Size = new Size(173, 25);
            label1.TabIndex = 14;
            label1.Text = "CARACTERISTICAS";
            // 
            // txtStock
            // 
            txtStock.Location = new Point(64, 204);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(302, 23);
            txtStock.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(64, 98);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 16;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(64, 186);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 17;
            label3.Text = "Stock";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(64, 142);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 18;
            label4.Text = "Marca";
            // 
            // lblAtributo1
            // 
            lblAtributo1.AutoSize = true;
            lblAtributo1.Location = new Point(64, 230);
            lblAtributo1.Name = "lblAtributo1";
            lblAtributo1.Size = new Size(78, 15);
            lblAtributo1.TabIndex = 19;
            lblAtributo1.Text = "Caracteristica";
            // 
            // lblAtributo2
            // 
            lblAtributo2.AutoSize = true;
            lblAtributo2.Location = new Point(64, 274);
            lblAtributo2.Name = "lblAtributo2";
            lblAtributo2.Size = new Size(78, 15);
            lblAtributo2.TabIndex = 20;
            lblAtributo2.Text = "Caracteristica";
            // 
            // cmbMarca
            // 
            cmbMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMarca.FormattingEnabled = true;
            cmbMarca.Items.AddRange(new object[] { "AMD", "Intel", "Sony", "Microsoft", "Apple", "Samsung", "Ninguna" });
            cmbMarca.Location = new Point(64, 158);
            cmbMarca.Name = "cmbMarca";
            cmbMarca.Size = new Size(302, 23);
            cmbMarca.TabIndex = 21;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(327, 12);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(72, 23);
            btnLimpiar.TabIndex = 22;
            btnLimpiar.Text = "LIMPIAR";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // FrmProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(411, 451);
            Controls.Add(btnLimpiar);
            Controls.Add(cmbMarca);
            Controls.Add(lblAtributo2);
            Controls.Add(lblAtributo1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtStock);
            Controls.Add(label1);
            Controls.Add(txtAtributo1);
            Controls.Add(txtAtributo2);
            Controls.Add(txtNombre);
            Controls.Add(cmbProductos);
            Controls.Add(lblProducto);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Name = "FrmProducto";
            Text = "PRODUCTO";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAceptar;
        private Button btnCancelar;
        private Label lblProducto;
        private ComboBox cmbProductos;
        private TextBox txtNombre;
        private TextBox txtAtributo2;
        private TextBox txtAtributo1;
        private Label label1;
        private TextBox txtStock;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblAtributo1;
        private Label lblAtributo2;
        private ComboBox cmbMarca;
        private Button btnLimpiar;
    }
}