namespace PruebaGrupo10
{
    partial class frmListadoEmpresas
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
            this.dgvCompanies = new System.Windows.Forms.DataGridView();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.txtFilterCompanyName = new System.Windows.Forms.TextBox();
            this.cmbProvincias = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanies)).BeginInit();
            this.grpFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCompanies
            // 
            this.dgvCompanies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompanies.Location = new System.Drawing.Point(32, 137);
            this.dgvCompanies.Name = "dgvCompanies";
            this.dgvCompanies.ReadOnly = true;
            this.dgvCompanies.Size = new System.Drawing.Size(1030, 363);
            this.dgvCompanies.TabIndex = 0;
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Location = new System.Drawing.Point(934, 22);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(75, 23);
            this.cmdBuscar.TabIndex = 1;
            this.cmdBuscar.Text = "Buscar";
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.CmdBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Razón social";
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.label2);
            this.grpFiltros.Controls.Add(this.cmdBuscar);
            this.grpFiltros.Controls.Add(this.cmbProvincias);
            this.grpFiltros.Controls.Add(this.txtFilterCompanyName);
            this.grpFiltros.Controls.Add(this.label1);
            this.grpFiltros.Location = new System.Drawing.Point(32, 53);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(1030, 62);
            this.grpFiltros.TabIndex = 3;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros";
            // 
            // txtFilterCompanyName
            // 
            this.txtFilterCompanyName.Location = new System.Drawing.Point(114, 19);
            this.txtFilterCompanyName.Name = "txtFilterCompanyName";
            this.txtFilterCompanyName.Size = new System.Drawing.Size(218, 20);
            this.txtFilterCompanyName.TabIndex = 3;
            // 
            // cmbProvincias
            // 
            this.cmbProvincias.FormattingEnabled = true;
            this.cmbProvincias.Items.AddRange(new object[] {
            "ALBACETE",
            "ALICANTE"});
            this.cmbProvincias.Location = new System.Drawing.Point(464, 18);
            this.cmbProvincias.Name = "cmbProvincias";
            this.cmbProvincias.Size = new System.Drawing.Size(121, 21);
            this.cmbProvincias.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(398, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Provincia";
            // 
            // cmdSalir
            // 
            this.cmdSalir.Location = new System.Drawing.Point(966, 12);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(75, 23);
            this.cmdSalir.TabIndex = 4;
            this.cmdSalir.Text = "Cerrar";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.CmdSalir_Click);
            // 
            // frmListadoEmpresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 526);
            this.ControlBox = false;
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.dgvCompanies);
            this.Name = "frmListadoEmpresas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmListadoEmpresas";
            this.Load += new System.EventHandler(this.FrmListadoEmpresas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanies)).EndInit();
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCompanies;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.TextBox txtFilterCompanyName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbProvincias;
        private System.Windows.Forms.Button cmdSalir;
    }
}