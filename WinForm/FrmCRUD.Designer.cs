namespace WinFormApp
{
    partial class FrmCRUD
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
            lstVisor = new ListBox();
            btnEliminar = new Button();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnOrdenarStock = new Button();
            label1 = new Label();
            btnOrdenarNombre = new Button();
            cmbAscDesc = new ComboBox();
            label2 = new Label();
            lblUsuarioLog = new Label();
            btnLimpiar = new Button();
            lblReloj = new Label();
            btnDeshacerCambios = new Button();
            SuspendLayout();
            // 
            // lstVisor
            // 
            lstVisor.FormattingEnabled = true;
            lstVisor.ItemHeight = 15;
            lstVisor.Location = new Point(17, 12);
            lstVisor.Name = "lstVisor";
            lstVisor.Size = new Size(674, 274);
            lstVisor.TabIndex = 0;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(537, 292);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(154, 56);
            btnEliminar.TabIndex = 1;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(17, 292);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(154, 56);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "AGREGAR";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(289, 292);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(154, 56);
            btnModificar.TabIndex = 3;
            btnModificar.Text = "MODIFICAR";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnOrdenarStock
            // 
            btnOrdenarStock.Location = new Point(709, 30);
            btnOrdenarStock.Name = "btnOrdenarStock";
            btnOrdenarStock.Size = new Size(175, 23);
            btnOrdenarStock.TabIndex = 4;
            btnOrdenarStock.Text = "Stock";
            btnOrdenarStock.UseVisualStyleBackColor = true;
            btnOrdenarStock.Click += btnOrdenarStock_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(709, 12);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 5;
            label1.Text = "ORDENAR POR:";
            // 
            // btnOrdenarNombre
            // 
            btnOrdenarNombre.Location = new Point(709, 59);
            btnOrdenarNombre.Name = "btnOrdenarNombre";
            btnOrdenarNombre.Size = new Size(175, 23);
            btnOrdenarNombre.TabIndex = 6;
            btnOrdenarNombre.Text = "Nombre";
            btnOrdenarNombre.UseVisualStyleBackColor = true;
            btnOrdenarNombre.Click += btnOrdenarNombre_Click;
            // 
            // cmbAscDesc
            // 
            cmbAscDesc.AutoCompleteCustomSource.AddRange(new string[] { "Ascendente", "Descendente" });
            cmbAscDesc.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAscDesc.FormattingEnabled = true;
            cmbAscDesc.Items.AddRange(new object[] { "Ascendente", "Descendente" });
            cmbAscDesc.Location = new Point(709, 131);
            cmbAscDesc.Name = "cmbAscDesc";
            cmbAscDesc.Size = new Size(175, 23);
            cmbAscDesc.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(709, 113);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 8;
            label2.Text = "FORMA:";
            // 
            // lblUsuarioLog
            // 
            lblUsuarioLog.AutoSize = true;
            lblUsuarioLog.Location = new Point(12, 363);
            lblUsuarioLog.Name = "lblUsuarioLog";
            lblUsuarioLog.Size = new Size(46, 15);
            lblUsuarioLog.TabIndex = 9;
            lblUsuarioLog.Text = "usuario";
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(740, 199);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(108, 29);
            btnLimpiar.TabIndex = 10;
            btnLimpiar.Text = "LIMPIAR";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // lblReloj
            // 
            lblReloj.AutoSize = true;
            lblReloj.Location = new Point(768, 363);
            lblReloj.Name = "lblReloj";
            lblReloj.Size = new Size(31, 15);
            lblReloj.TabIndex = 11;
            lblReloj.Text = "hora";
            // 
            // btnDeshacerCambios
            // 
            btnDeshacerCambios.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeshacerCambios.Location = new Point(567, 354);
            btnDeshacerCambios.Name = "btnDeshacerCambios";
            btnDeshacerCambios.Size = new Size(99, 24);
            btnDeshacerCambios.TabIndex = 12;
            btnDeshacerCambios.Text = "DESHACER CAMBIOS";
            btnDeshacerCambios.UseVisualStyleBackColor = true;
            btnDeshacerCambios.Click += btnDeshacerCambios_Click;
            // 
            // FrmCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(894, 392);
            Controls.Add(btnDeshacerCambios);
            Controls.Add(lblReloj);
            Controls.Add(btnLimpiar);
            Controls.Add(lblUsuarioLog);
            Controls.Add(label2);
            Controls.Add(cmbAscDesc);
            Controls.Add(btnOrdenarNombre);
            Controls.Add(label1);
            Controls.Add(btnOrdenarStock);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(btnEliminar);
            Controls.Add(lstVisor);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "FrmCRUD";
            Text = "APP";
            FormClosing += FrmCRUD_FormClosing;
            Load += FrmCRUD_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstVisor;
        private Button btnEliminar;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnOrdenarStock;
        private Label label1;
        private Button btnOrdenarNombre;
        private ComboBox cmbAscDesc;
        private Label label2;
        private Label lblUsuarioLog;
        private Button btnLimpiar;
        private Label lblReloj;
        private Button btnDeshacerCambios;
    }
}