﻿namespace BapFormulariosNet.Ayudas
{
    partial class Frm_AyudaRubroIngresoPlla
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AyudaRubroIngresoPlla));
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.dgProveedor = new System.Windows.Forms.DataGridView();
            this.tipoplla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipopllaname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rubroid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rubroname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empresaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtpla = new System.Windows.Forms.TextBox();
            this.cmbempresa = new System.Windows.Forms.ComboBox();
            this.chkempresa = new System.Windows.Forms.CheckBox();
            this.cmbtipoplanilla = new System.Windows.Forms.ComboBox();
            this.chkdescripcion = new System.Windows.Forms.CheckBox();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.chktipoplanilla = new System.Windows.Forms.CheckBox();
            this.btnrefrescar = new System.Windows.Forms.Button();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProveedor)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.btnCerrar);
            this.GroupBox3.Controls.Add(this.btnSeleccionar);
            this.GroupBox3.Location = new System.Drawing.Point(349, 446);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(193, 42);
            this.GroupBox3.TabIndex = 2;
            this.GroupBox3.TabStop = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Image = global::BapFormulariosNet.Properties.Resources.Cancela16;
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Location = new System.Drawing.Point(98, 11);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(90, 25);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "&Cancelar   ";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Image = global::BapFormulariosNet.Properties.Resources.Acepta16;
            this.btnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionar.Location = new System.Drawing.Point(5, 11);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(90, 25);
            this.btnSeleccionar.TabIndex = 0;
            this.btnSeleccionar.Text = "&Seleccionar";
            this.btnSeleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // dgProveedor
            // 
            this.dgProveedor.AllowUserToAddRows = false;
            this.dgProveedor.AllowUserToDeleteRows = false;
            this.dgProveedor.AllowUserToResizeRows = false;
            this.dgProveedor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProveedor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProveedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipoplla,
            this.tipopllaname,
            this.rubroid,
            this.rubroname,
            this.empresaid});
            this.dgProveedor.Location = new System.Drawing.Point(14, 103);
            this.dgProveedor.MultiSelect = false;
            this.dgProveedor.Name = "dgProveedor";
            this.dgProveedor.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProveedor.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgProveedor.RowHeadersWidth = 24;
            this.dgProveedor.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgProveedor.RowTemplate.Height = 20;
            this.dgProveedor.Size = new System.Drawing.Size(867, 345);
            this.dgProveedor.TabIndex = 1;
            this.dgProveedor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProveedor_CellDoubleClick);
            this.dgProveedor.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgProveedor_RowHeaderMouseClick);
            this.dgProveedor.DoubleClick += new System.EventHandler(this.dgProveedor_DoubleClick);
            this.dgProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgProveedor_KeyDown);
            // 
            // tipoplla
            // 
            this.tipoplla.DataPropertyName = "tipoplla";
            this.tipoplla.HeaderText = "Tipo Planilla";
            this.tipoplla.Name = "tipoplla";
            this.tipoplla.ReadOnly = true;
            this.tipoplla.Width = 60;
            // 
            // tipopllaname
            // 
            this.tipopllaname.DataPropertyName = "tipopllaname";
            this.tipopllaname.HeaderText = "Descripción Planilla";
            this.tipopllaname.Name = "tipopllaname";
            this.tipopllaname.ReadOnly = true;
            this.tipopllaname.Width = 350;
            // 
            // rubroid
            // 
            this.rubroid.DataPropertyName = "rubroid";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rubroid.DefaultCellStyle = dataGridViewCellStyle2;
            this.rubroid.HeaderText = "Código";
            this.rubroid.Name = "rubroid";
            this.rubroid.ReadOnly = true;
            this.rubroid.Width = 60;
            // 
            // rubroname
            // 
            this.rubroname.DataPropertyName = "rubroname";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rubroname.DefaultCellStyle = dataGridViewCellStyle3;
            this.rubroname.HeaderText = "Descripción";
            this.rubroname.Name = "rubroname";
            this.rubroname.ReadOnly = true;
            this.rubroname.Width = 350;
            // 
            // empresaid
            // 
            this.empresaid.DataPropertyName = "empresaid";
            this.empresaid.HeaderText = "empresaid";
            this.empresaid.Name = "empresaid";
            this.empresaid.ReadOnly = true;
            this.empresaid.Visible = false;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtpla);
            this.GroupBox1.Controls.Add(this.cmbempresa);
            this.GroupBox1.Controls.Add(this.chkempresa);
            this.GroupBox1.Controls.Add(this.cmbtipoplanilla);
            this.GroupBox1.Controls.Add(this.chkdescripcion);
            this.GroupBox1.Controls.Add(this.txtdescripcion);
            this.GroupBox1.Controls.Add(this.chktipoplanilla);
            this.GroupBox1.Controls.Add(this.btnrefrescar);
            this.GroupBox1.Location = new System.Drawing.Point(14, 5);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(868, 95);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = " Filtros ";
            // 
            // txtpla
            // 
            this.txtpla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpla.Location = new System.Drawing.Point(597, 42);
            this.txtpla.Name = "txtpla";
            this.txtpla.Size = new System.Drawing.Size(42, 20);
            this.txtpla.TabIndex = 4;
            // 
            // cmbempresa
            // 
            this.cmbempresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbempresa.FormattingEnabled = true;
            this.cmbempresa.Location = new System.Drawing.Point(140, 15);
            this.cmbempresa.Name = "cmbempresa";
            this.cmbempresa.Size = new System.Drawing.Size(499, 21);
            this.cmbempresa.TabIndex = 1;
            this.cmbempresa.SelectedIndexChanged += new System.EventHandler(this.cmbempresa_SelectedIndexChanged);
            // 
            // chkempresa
            // 
            this.chkempresa.AutoSize = true;
            this.chkempresa.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkempresa.Checked = true;
            this.chkempresa.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkempresa.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkempresa.Location = new System.Drawing.Point(62, 17);
            this.chkempresa.Name = "chkempresa";
            this.chkempresa.Size = new System.Drawing.Size(67, 17);
            this.chkempresa.TabIndex = 0;
            this.chkempresa.Text = "Empresa";
            this.chkempresa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkempresa.UseVisualStyleBackColor = true;
            this.chkempresa.CheckedChanged += new System.EventHandler(this.chkempresa_CheckedChanged);
            // 
            // cmbtipoplanilla
            // 
            this.cmbtipoplanilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtipoplanilla.FormattingEnabled = true;
            this.cmbtipoplanilla.Location = new System.Drawing.Point(140, 41);
            this.cmbtipoplanilla.Name = "cmbtipoplanilla";
            this.cmbtipoplanilla.Size = new System.Drawing.Size(451, 21);
            this.cmbtipoplanilla.TabIndex = 3;
            this.cmbtipoplanilla.SelectedIndexChanged += new System.EventHandler(this.cmbtipoplanilla_SelectedIndexChanged);
            // 
            // chkdescripcion
            // 
            this.chkdescripcion.AutoSize = true;
            this.chkdescripcion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkdescripcion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkdescripcion.Location = new System.Drawing.Point(6, 70);
            this.chkdescripcion.Name = "chkdescripcion";
            this.chkdescripcion.Size = new System.Drawing.Size(123, 17);
            this.chkdescripcion.TabIndex = 5;
            this.chkdescripcion.Text = "Ocurrencias Nombre";
            this.chkdescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkdescripcion.UseVisualStyleBackColor = true;
            this.chkdescripcion.CheckedChanged += new System.EventHandler(this.chkdescripcion_CheckedChanged);
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdescripcion.Location = new System.Drawing.Point(140, 67);
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(499, 20);
            this.txtdescripcion.TabIndex = 6;
            this.txtdescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtdescripcion_KeyDown);
            // 
            // chktipoplanilla
            // 
            this.chktipoplanilla.AutoSize = true;
            this.chktipoplanilla.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chktipoplanilla.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chktipoplanilla.Location = new System.Drawing.Point(46, 43);
            this.chktipoplanilla.Name = "chktipoplanilla";
            this.chktipoplanilla.Size = new System.Drawing.Size(83, 17);
            this.chktipoplanilla.TabIndex = 2;
            this.chktipoplanilla.Text = "Tipo Planilla";
            this.chktipoplanilla.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chktipoplanilla.UseVisualStyleBackColor = true;
            this.chktipoplanilla.CheckedChanged += new System.EventHandler(this.chktipoplanilla_CheckedChanged);
            // 
            // btnrefrescar
            // 
            this.btnrefrescar.Image = global::BapFormulariosNet.Properties.Resources.btn_search20;
            this.btnrefrescar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrefrescar.Location = new System.Drawing.Point(726, 37);
            this.btnrefrescar.Name = "btnrefrescar";
            this.btnrefrescar.Size = new System.Drawing.Size(85, 40);
            this.btnrefrescar.TabIndex = 7;
            this.btnrefrescar.Text = "&Refrescar";
            this.btnrefrescar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnrefrescar.UseVisualStyleBackColor = true;
            this.btnrefrescar.Click += new System.EventHandler(this.btnrefrescar_Click);
            // 
            // Frm_AyudaRubroIngresoPlla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 490);
            this.Controls.Add(this.dgProveedor);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Frm_AyudaRubroIngresoPlla";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rubros Ingreso - Planilla";
            this.Activated += new System.EventHandler(this.Frm_AyudaRubroIngresoPlla_Activated);
            this.Load += new System.EventHandler(this.Frm_AyudaRubroIngresoPlla_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_AyudaRubroIngresoPlla_KeyDown);
            this.GroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgProveedor)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Button btnCerrar;
        internal System.Windows.Forms.Button btnSeleccionar;
        internal System.Windows.Forms.DataGridView dgProveedor;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox txtpla;
        internal System.Windows.Forms.ComboBox cmbempresa;
        internal System.Windows.Forms.CheckBox chkempresa;
        internal System.Windows.Forms.ComboBox cmbtipoplanilla;
        internal System.Windows.Forms.CheckBox chkdescripcion;
        internal System.Windows.Forms.TextBox txtdescripcion;
        internal System.Windows.Forms.CheckBox chktipoplanilla;
        internal System.Windows.Forms.Button btnrefrescar;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoplla;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipopllaname;
        private System.Windows.Forms.DataGridViewTextBoxColumn rubroid;
        private System.Windows.Forms.DataGridViewTextBoxColumn rubroname;
        private System.Windows.Forms.DataGridViewTextBoxColumn empresaid;
    }
}