﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using DevExpress.XtraEditors;

namespace BapFormulariosNet.D20Comercial.Ayudas
{
    public partial class Frm_AyudaPais : plantilla
    {
        public delegate void PasaCuentaDelegate(string codigo, string nombre);
        //Parametros
        public PasaCuentaDelegate _PasaRegistro;
        // Variables
        //string j_tipdoc = "";
        bool sw_Load = true;
        DataTable tabla;
        //DataTable tmptabla;
        string j_String = "";
        //bool sw_Select = false;
        
        public Frm_AyudaPais()
        {
            InitializeComponent();
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            //DevExpress.Skins.SkinManager.EnableFormSkins();

            KeyDown += Frm_AyudaPais_KeyDown;
            Load += Frm_AyudaPais_Load;
            Activated += Frm_AyudaPais_Activated;

            txtFilter.LostFocus += new System.EventHandler(txtFilter_LostFocus);
            txtFilter.GotFocus += new System.EventHandler(txtFilter_GotFocus);

            cboFiltro.SelectedIndex = 0;            
        }

        private void Frm_AyudaPais_Activated(object sender, EventArgs e)
        {
            if (sw_Load)
            {
                sw_Load = false;
                U_CargaDatos();
            }
        }  
        private void Frm_AyudaPais_Load(object sender, EventArgs e)
        {
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            //DevExpress.Skins.SkinManager.EnableFormSkins();

            U_RefrescaControles();
            VariablesPublicas.PintaEncabezados(gridExaminar);
        }
        private void Frm_AyudaPais_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCerrar_Click(sender, e);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            _PasaRegistro("", "");
            Close();
        }

        private void gridExaminar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                U_SeleccionaRegistros();
            }
        }
        private void gridExaminar_DoubleClick(object sender, EventArgs e)
        {
            U_SeleccionaRegistros();
        }

        public void U_CargaDatos()
        {
            string xpalabra1 = "";
            string xpalabra2 = "";
            string xpalabra3 = "";
            if (txtFilter.Enabled)
            {
                xpalabra1 = VariablesPublicas.Palabras(txtFilter.Text.Trim(), 1);
                xpalabra2 = VariablesPublicas.Palabras(txtFilter.Text.Trim(), 2);
                xpalabra3 = VariablesPublicas.Palabras(txtFilter.Text.Trim(), 3);
            }
            //tabla = ocapa.UBIGEO_CONSULTA("", "", "", xpalabra1, xpalabra2, xpalabra3);
            try
            {
                paisBL BL = new paisBL();
                tb_pais BE = new tb_pais();

                switch (cboFiltro.SelectedItem.ToString())
                {
                    case "Pais":
                        BE.paisname = txtFilter.Text.Trim().ToUpper();
                        break;
                    case "Código":
                        BE.paisid = txtFilter.Text.Trim().ToUpper();
                        break;
                    default:
                        BE.paisid = txtFilter.Text.Trim().ToUpper();
                        break;
                }
                tabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
            btnBuscar.Enabled = true;
            SortOrder sorted = default(SortOrder);
            string xnomcolumna = "";
            if ((gridExaminar.SortedColumn != null))
            {
                xnomcolumna = gridExaminar.Columns[gridExaminar.SortedColumn.Index].Name;
                sorted = gridExaminar.SortOrder;
            }
            gridExaminar.AutoGenerateColumns = false;
            gridExaminar.DataSource = tabla;
            gridExaminar.AllowUserToResizeRows = false;
            if (xnomcolumna.Trim().Length > 0)
            {
                if (sorted == SortOrder.Ascending)
                {
                    gridExaminar.Sort(gridExaminar.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Ascending);
                }
                else
                {
                    gridExaminar.Sort(gridExaminar.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Descending);
                }
            }
            else
            {
                gridExaminar.Sort(gridExaminar.Columns["paisid"], System.ComponentModel.ListSortDirection.Ascending);
            }
            if (gridExaminar.Rows.Count > 0)
            {
                gridExaminar.CurrentCell = gridExaminar.Rows[0].Cells["paisname"];
                gridExaminar.Focus();
                gridExaminar.BeginEdit(true);
            }
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            U_SeleccionaRegistros();
        }
        public void U_SeleccionaRegistros()
        {
            if ((gridExaminar.CurrentRow != null))
            {
                //sw_Select = true;
                _PasaRegistro(gridExaminar.Rows[gridExaminar.CurrentRow.Index].Cells["paisid"].Value.ToString(),
                                   gridExaminar.Rows[gridExaminar.CurrentRow.Index].Cells["paisname"].Value.ToString());
                Close();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            U_CargaDatos();
        }

        public void U_RefrescaControles()
        {
            gridExaminar.ReadOnly = true;
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            // Si el control tiene el foco...
            if (keyData == Keys.Enter & !btnSeleccion.Focused)
            {
                if ((gridExaminar.CurrentCell != null))
                {
                    if (gridExaminar.Focused)
                    {
                        U_SeleccionaRegistros();
                        return true;
                    }
                    else
                    {
                        SendKeys.Send("\t");
                        return true;
                    }
                }
                else
                {
                    SendKeys.Send("\t");
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtFilter_GotFocus(object sender, System.EventArgs e)
        {
            j_String = txtFilter.Text;
        }
        private void txtFilter_LostFocus(object sender, System.EventArgs e)
        {
            if (!sw_Load & !(j_String == txtFilter.Text))
            {
                U_CargaDatos();
            }
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                U_CargaDatos();
                btnBuscar.Focus();
            }
        }   
    }
}