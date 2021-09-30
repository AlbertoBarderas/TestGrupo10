namespace PruebaGrupo10
{
    partial class frmCalendar
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
            this.dgvReads = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpRead = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdLeerBoe = new System.Windows.Forms.Button();
            this.cmdCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReads)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvReads
            // 
            this.dgvReads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReads.Location = new System.Drawing.Point(21, 19);
            this.dgvReads.MultiSelect = false;
            this.dgvReads.Name = "dgvReads";
            this.dgvReads.ReadOnly = true;
            this.dgvReads.ShowEditingIcon = false;
            this.dgvReads.Size = new System.Drawing.Size(202, 335);
            this.dgvReads.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvReads);
            this.groupBox1.Location = new System.Drawing.Point(23, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 372);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lecturas del BOE";
            // 
            // dtpRead
            // 
            this.dtpRead.Location = new System.Drawing.Point(21, 44);
            this.dtpRead.Name = "dtpRead";
            this.dtpRead.Size = new System.Drawing.Size(200, 20);
            this.dtpRead.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdLeerBoe);
            this.groupBox2.Controls.Add(this.dtpRead);
            this.groupBox2.Location = new System.Drawing.Point(293, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(366, 100);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nueva Lectura";
            // 
            // cmdLeerBoe
            // 
            this.cmdLeerBoe.Location = new System.Drawing.Point(256, 41);
            this.cmdLeerBoe.Name = "cmdLeerBoe";
            this.cmdLeerBoe.Size = new System.Drawing.Size(95, 23);
            this.cmdLeerBoe.TabIndex = 4;
            this.cmdLeerBoe.Text = "Leer del BOE";
            this.cmdLeerBoe.UseVisualStyleBackColor = true;
            this.cmdLeerBoe.Click += new System.EventHandler(this.CmdLeerBoe_Click);
            // 
            // cmdCerrar
            // 
            this.cmdCerrar.Location = new System.Drawing.Point(570, 343);
            this.cmdCerrar.Name = "cmdCerrar";
            this.cmdCerrar.Size = new System.Drawing.Size(95, 23);
            this.cmdCerrar.TabIndex = 5;
            this.cmdCerrar.Text = "Cerrar";
            this.cmdCerrar.UseVisualStyleBackColor = true;
            this.cmdCerrar.Click += new System.EventHandler(this.CmdCerrar_Click);
            // 
            // frmCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 394);
            this.ControlBox = false;
            this.Controls.Add(this.cmdCerrar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCalendar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCalendar";
            this.Load += new System.EventHandler(this.FrmCalendar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReads)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReads;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpRead;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cmdLeerBoe;
        private System.Windows.Forms.Button cmdCerrar;
    }
}