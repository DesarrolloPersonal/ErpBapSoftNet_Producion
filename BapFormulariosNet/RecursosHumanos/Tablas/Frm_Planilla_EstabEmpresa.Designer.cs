﻿namespace BapFormulariosNet.RecursosHumanos.Tablas
{
    partial class Frm_Planilla_EstabEmpresa
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Planilla_EstabEmpresa));
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.txtfiltronombre = new System.Windows.Forms.TextBox();
            this.btnfiltro = new System.Windows.Forms.Button();
            this.Label22 = new System.Windows.Forms.Label();
            this.Examinar = new System.Windows.Forms.DataGridView();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmbtipo = new System.Windows.Forms.ComboBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.barramain = new System.Windows.Forms.ToolStrip();
            this.btnnuevo = new System.Windows.Forms.ToolStripButton();
            this.btnmod = new System.Windows.Forms.ToolStripButton();
            this.btngrabar = new System.Windows.Forms.ToolStripButton();
            this.btncancelar = new System.Windows.Forms.ToolStripButton();
            this.btneliminar = new System.Windows.Forms.ToolStripButton();
            this.btnload = new System.Windows.Forms.ToolStripButton();
            this.btncerrar = new System.Windows.Forms.ToolStripButton();
            this.btnlog = new System.Windows.Forms.ToolStripButton();
            this.btnprimero = new System.Windows.Forms.ToolStripButton();
            this.btnanterior = new System.Windows.Forms.ToolStripButton();
            this.btnsiguiente = new System.Windows.Forms.ToolStripButton();
            this.btnultimo = new System.Windows.Forms.ToolStripButton();
            this.btnpdt = new System.Windows.Forms.ToolStripButton();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.FolderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblanulado = new System.Windows.Forms.Label();
            this.estabid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estabname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empresaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estabrtps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipestabname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Examinar)).BeginInit();
            this.TabPage2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.barramain.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Location = new System.Drawing.Point(9, 36);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(769, 389);
            this.TabControl1.TabIndex = 3;
            this.TabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            this.TabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabControl1_Selecting);
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.GroupBox2);
            this.TabPage1.Controls.Add(this.Examinar);
            this.TabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(761, 363);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Relación";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.txtfiltronombre);
            this.GroupBox2.Controls.Add(this.btnfiltro);
            this.GroupBox2.Controls.Add(this.Label22);
            this.GroupBox2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.GroupBox2.Location = new System.Drawing.Point(6, 4);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(711, 59);
            this.GroupBox2.TabIndex = 0;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = " Filtros ";
            // 
            // txtfiltronombre
            // 
            this.txtfiltronombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtfiltronombre.Location = new System.Drawing.Point(11, 31);
            this.txtfiltronombre.Name = "txtfiltronombre";
            this.txtfiltronombre.Size = new System.Drawing.Size(499, 20);
            this.txtfiltronombre.TabIndex = 1;
            // 
            // btnfiltro
            // 
            this.btnfiltro.ForeColor = System.Drawing.SystemColors.ControlText;
            //this.btnfiltro.Image = global::BapFormulariosNet.Properties.Resources.filtrar24;
            this.btnfiltro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnfiltro.Location = new System.Drawing.Point(618, 18);
            this.btnfiltro.Name = "btnfiltro";
            this.btnfiltro.Size = new System.Drawing.Size(68, 33);
            this.btnfiltro.TabIndex = 6;
            this.btnfiltro.Text = "&Filtrar";
            this.btnfiltro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnfiltro.UseVisualStyleBackColor = true;
            this.btnfiltro.Click += new System.EventHandler(this.btnfiltro_Click);
            // 
            // Label22
            // 
            this.Label22.AutoSize = true;
            this.Label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label22.Location = new System.Drawing.Point(8, 15);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(121, 13);
            this.Label22.TabIndex = 0;
            this.Label22.Text = "Ocurrencias descripción";
            // 
            // Examinar
            // 
            this.Examinar.AllowUserToAddRows = false;
            this.Examinar.AllowUserToDeleteRows = false;
            this.Examinar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Examinar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Examinar.ColumnHeadersHeight = 32;
            this.Examinar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.estabid,
            this.estabname,
            this.empresaid,
            this.estabrtps,
            this.tipestabname,
            this.status});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Examinar.DefaultCellStyle = dataGridViewCellStyle2;
            this.Examinar.Location = new System.Drawing.Point(7, 67);
            this.Examinar.MultiSelect = false;
            this.Examinar.Name = "Examinar";
            this.Examinar.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Examinar.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Examinar.RowHeadersWidth = 24;
            this.Examinar.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Examinar.Size = new System.Drawing.Size(745, 289);
            this.Examinar.TabIndex = 1;
            this.Examinar.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Examinar_CellContentDoubleClick);
            this.Examinar.Paint += new System.Windows.Forms.PaintEventHandler(this.Examinar_Paint);
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.GroupBox1);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(761, 363);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Datos";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.chkActivo);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.cmbtipo);
            this.GroupBox1.Controls.Add(this.Label10);
            this.GroupBox1.Controls.Add(this.txtdescripcion);
            this.GroupBox1.Controls.Add(this.Label8);
            this.GroupBox1.Controls.Add(this.txtcodigo);
            this.GroupBox1.Location = new System.Drawing.Point(15, 15);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(713, 224);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkActivo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkActivo.Location = new System.Drawing.Point(102, 141);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(56, 17);
            this.chkActivo.TabIndex = 6;
            this.chkActivo.Text = "Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label1.Location = new System.Drawing.Point(105, 81);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(28, 13);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Tipo";
            // 
            // cmbtipo
            // 
            this.cmbtipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtipo.Enabled = false;
            this.cmbtipo.FormattingEnabled = true;
            this.cmbtipo.Location = new System.Drawing.Point(143, 77);
            this.cmbtipo.Name = "cmbtipo";
            this.cmbtipo.Size = new System.Drawing.Size(327, 21);
            this.cmbtipo.TabIndex = 5;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label10.Location = new System.Drawing.Point(70, 52);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(63, 13);
            this.Label10.TabIndex = 2;
            this.Label10.Text = "Descripción";
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdescripcion.Location = new System.Drawing.Point(143, 48);
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(542, 20);
            this.txtdescripcion.TabIndex = 3;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label8.Location = new System.Drawing.Point(93, 24);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(40, 13);
            this.Label8.TabIndex = 0;
            this.Label8.Text = "Código";
            // 
            // txtcodigo
            // 
            this.txtcodigo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcodigo.Location = new System.Drawing.Point(143, 19);
            this.txtcodigo.MaxLength = 4;
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(77, 22);
            this.txtcodigo.TabIndex = 1;
            this.txtcodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcodigo_KeyPress);
            // 
            // barramain
            // 
            this.barramain.AutoSize = false;
            this.barramain.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.barramain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnnuevo,
            this.btnmod,
            this.btngrabar,
            this.btncancelar,
            this.btneliminar,
            this.btnload,
            this.btncerrar,
            this.btnlog,
            this.btnprimero,
            this.btnanterior,
            this.btnsiguiente,
            this.btnultimo,
            this.btnpdt});
            this.barramain.Location = new System.Drawing.Point(0, 0);
            this.barramain.Name = "barramain";
            this.barramain.Size = new System.Drawing.Size(785, 31);
            this.barramain.TabIndex = 2;
            this.barramain.Text = "ToolStrip2";
            // 
            // btnnuevo
            // 
            this.btnnuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnnuevo.Image = global::BapFormulariosNet.Properties.Resources.btn_nuevo;
            this.btnnuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnnuevo.Name = "btnnuevo";
            this.btnnuevo.Size = new System.Drawing.Size(26, 28);
            this.btnnuevo.Text = "Nuevo";
            this.btnnuevo.Click += new System.EventHandler(this.btnnuevo_Click);
            // 
            // btnmod
            // 
            this.btnmod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnmod.Image = global::BapFormulariosNet.Properties.Resources.btn_editar;
            this.btnmod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnmod.Name = "btnmod";
            this.btnmod.Size = new System.Drawing.Size(26, 28);
            this.btnmod.Text = "Editar";
            this.btnmod.Click += new System.EventHandler(this.btnmod_Click);
            // 
            // btngrabar
            // 
            this.btngrabar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btngrabar.Image = global::BapFormulariosNet.Properties.Resources.btn_grabar;
            this.btngrabar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btngrabar.Name = "btngrabar";
            this.btngrabar.Size = new System.Drawing.Size(26, 28);
            this.btngrabar.Text = "Guardar";
            this.btngrabar.Click += new System.EventHandler(this.btngrabar_Click);
            // 
            // btncancelar
            // 
            this.btncancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btncancelar.Image = global::BapFormulariosNet.Properties.Resources.btn_cancelar;
            this.btncancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(26, 28);
            this.btncancelar.Text = "Deshacer";
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // btneliminar
            // 
            this.btneliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btneliminar.Image = global::BapFormulariosNet.Properties.Resources.btn_eliminar;
            this.btneliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(26, 28);
            this.btneliminar.Text = "Eliminar";
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
            // 
            // btnload
            // 
            this.btnload.AutoSize = false;
            this.btnload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnload.Image = global::BapFormulariosNet.Properties.Resources.btn_refresh;
            this.btnload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnload.Name = "btnload";
            this.btnload.Size = new System.Drawing.Size(30, 30);
            this.btnload.Text = "Actualizar";
            this.btnload.Click += new System.EventHandler(this.btnload_Click);
            // 
            // btncerrar
            // 
            this.btncerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btncerrar.Image = global::BapFormulariosNet.Properties.Resources.btn_salir;
            this.btncerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(26, 28);
            this.btncerrar.Text = "Salir";
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // btnlog
            // 
            this.btnlog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnlog.Image = global::BapFormulariosNet.Properties.Resources.ojo32;
            this.btnlog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnlog.Name = "btnlog";
            this.btnlog.Size = new System.Drawing.Size(26, 28);
            this.btnlog.Text = "Log - Seguridad";
            this.btnlog.ToolTipText = "Log - Seguridad";
            this.btnlog.Click += new System.EventHandler(this.btnlog_Click);
            // 
            // btnprimero
            // 
            this.btnprimero.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnprimero.Image = global::BapFormulariosNet.Properties.Resources.btnInicio;
            this.btnprimero.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnprimero.Name = "btnprimero";
            this.btnprimero.Size = new System.Drawing.Size(26, 28);
            this.btnprimero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnprimero.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnprimero.ToolTipText = "Primer Registro";
            this.btnprimero.Click += new System.EventHandler(this.btnprimero_Click);
            // 
            // btnanterior
            // 
            this.btnanterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnanterior.Image = global::BapFormulariosNet.Properties.Resources.btnAnterior;
            this.btnanterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnanterior.Name = "btnanterior";
            this.btnanterior.Size = new System.Drawing.Size(26, 28);
            this.btnanterior.Text = "ToolStripButton2";
            this.btnanterior.ToolTipText = "Anterior Registro";
            this.btnanterior.Click += new System.EventHandler(this.btnanterior_Click);
            // 
            // btnsiguiente
            // 
            this.btnsiguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnsiguiente.Image = global::BapFormulariosNet.Properties.Resources.btnSiguiente;
            this.btnsiguiente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnsiguiente.Name = "btnsiguiente";
            this.btnsiguiente.Size = new System.Drawing.Size(26, 28);
            this.btnsiguiente.Text = "ToolStripButton1";
            this.btnsiguiente.ToolTipText = "Siguiente Registro";
            this.btnsiguiente.Click += new System.EventHandler(this.btnsiguiente_Click);
            // 
            // btnultimo
            // 
            this.btnultimo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnultimo.Image = global::BapFormulariosNet.Properties.Resources.btnUltimo;
            this.btnultimo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnultimo.Name = "btnultimo";
            this.btnultimo.Size = new System.Drawing.Size(26, 28);
            this.btnultimo.Text = "ToolStripButton3";
            this.btnultimo.ToolTipText = "Ultimo Registro";
            this.btnultimo.Click += new System.EventHandler(this.btnultimo_Click);
            // 
            // btnpdt
            // 
            this.btnpdt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnpdt.Image = global::BapFormulariosNet.Properties.Resources.PDT1;
            this.btnpdt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnpdt.Name = "btnpdt";
            this.btnpdt.Size = new System.Drawing.Size(26, 28);
            this.btnpdt.Text = "Generar Datos Formato E1 - ESTRUCTURA1: \"Datos de Establecimientos Propios";
            this.btnpdt.ToolTipText = "Generar Datos Formato E1 - ESTRUCTURA1: \"Datos de Establecimientos Propios";
            this.btnpdt.Click += new System.EventHandler(this.btnpdt_Click);
            // 
            // lblanulado
            // 
            this.lblanulado.AutoSize = true;
            this.lblanulado.BackColor = System.Drawing.Color.Red;
            this.lblanulado.Location = new System.Drawing.Point(311, 419);
            this.lblanulado.Name = "lblanulado";
            this.lblanulado.Size = new System.Drawing.Size(46, 13);
            this.lblanulado.TabIndex = 4;
            this.lblanulado.Text = "Anulado";
            this.lblanulado.Visible = false;
            // 
            // estabid
            // 
            this.estabid.DataPropertyName = "estabid";
            this.estabid.HeaderText = "Código";
            this.estabid.Name = "estabid";
            this.estabid.ReadOnly = true;
            this.estabid.Width = 70;
            // 
            // estabname
            // 
            this.estabname.DataPropertyName = "estabname";
            this.estabname.HeaderText = "Descripción";
            this.estabname.Name = "estabname";
            this.estabname.ReadOnly = true;
            this.estabname.Width = 380;
            // 
            // empresaid
            // 
            this.empresaid.DataPropertyName = "empresaid";
            this.empresaid.HeaderText = "empresaid";
            this.empresaid.Name = "empresaid";
            this.empresaid.ReadOnly = true;
            this.empresaid.Visible = false;
            // 
            // estabrtps
            // 
            this.estabrtps.DataPropertyName = "estabrtps";
            this.estabrtps.HeaderText = "estabrtps";
            this.estabrtps.Name = "estabrtps";
            this.estabrtps.ReadOnly = true;
            this.estabrtps.Visible = false;
            // 
            // tipestabname
            // 
            this.tipestabname.DataPropertyName = "tipestabname";
            this.tipestabname.HeaderText = "Tipo Local/Establecimiento";
            this.tipestabname.Name = "tipestabname";
            this.tipestabname.ReadOnly = true;
            this.tipestabname.Width = 250;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "Activo";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Visible = false;
            // 
            // Frm_Planilla_EstabEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 432);
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.barramain);
            this.Controls.Add(this.lblanulado);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Frm_Planilla_EstabEmpresa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Establecimientos Empresa";
            this.Activated += new System.EventHandler(this.Frm_Planilla_EstabEmpresa_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Planilla_EstabEmpresa_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Planilla_EstabEmpresa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Planilla_EstabEmpresa_KeyDown);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Examinar)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.barramain.ResumeLayout(false);
            this.barramain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.TextBox txtfiltronombre;
        internal System.Windows.Forms.Button btnfiltro;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.DataGridView Examinar;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cmbtipo;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.TextBox txtdescripcion;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.TextBox txtcodigo;
        internal System.Windows.Forms.ToolStrip barramain;
        internal System.Windows.Forms.ToolStripButton btnnuevo;
        internal System.Windows.Forms.ToolStripButton btnmod;
        internal System.Windows.Forms.ToolStripButton btngrabar;
        internal System.Windows.Forms.ToolStripButton btncancelar;
        internal System.Windows.Forms.ToolStripButton btneliminar;
        internal System.Windows.Forms.ToolStripButton btnload;
        internal System.Windows.Forms.ToolStripButton btncerrar;
        internal System.Windows.Forms.ToolStripButton btnlog;
        internal System.Windows.Forms.ToolStripButton btnprimero;
        internal System.Windows.Forms.ToolStripButton btnanterior;
        internal System.Windows.Forms.ToolStripButton btnsiguiente;
        internal System.Windows.Forms.ToolStripButton btnultimo;
        internal System.Windows.Forms.ToolStripButton btnpdt;
        internal System.Windows.Forms.ToolTip ToolTip1;
        internal System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog1;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Label lblanulado;
        private System.Windows.Forms.DataGridViewTextBoxColumn estabid;
        private System.Windows.Forms.DataGridViewTextBoxColumn estabname;
        private System.Windows.Forms.DataGridViewTextBoxColumn empresaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn estabrtps;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipestabname;
        private System.Windows.Forms.DataGridViewCheckBoxColumn status;
    }
}