﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.D60ALMACEN
{
    public partial class Frm_reporte_UbigeoInvRollos : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String PERFILID = string.Empty;

        private String ssModo = "NEW";

        public Frm_reporte_UbigeoInvRollos()
        {
            InitializeComponent();
            productid.LostFocus += new System.EventHandler(productid_LostFocus);
        }

        private void PARAMETROS_TABLA()
        {
            var xxferfil = string.Empty;
            var f = (MainAlmacen)MdiParent;
            xxferfil = f.perfil.ToString();
            if (xxferfil.Trim().Length != 9)
            {
                MessageBox.Show("::: NO TIENE PERFIL !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PERFILID = xxferfil;
        }


        private void form_bloqueado(Boolean var)
        {
            try
            {
                productid.Enabled = var;
                productname.Enabled = false;
                cmb_fechas.Enabled = var;
                btn_nuevo.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_imprimir.Enabled = false;
                btn_imprimir_gen.Enabled = false;
                btn_excel.Enabled = false;
                btn_buscar.Enabled = false;
                btn_salir.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void form_accion_cancelEdicion(int confirnar)
        {
            var sw_prosigue = true;
            if (confirnar == 1)
            {
                sw_prosigue = (MessageBox.Show("Desea cancelar ingreso de datos...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
            }
            else
            {
                sw_prosigue = true;
            }
            if (sw_prosigue)
            {
                limpiar_documento();
                form_bloqueado(false);
                btn_nuevo.Enabled = true;
                btn_buscar.Enabled = true;
                btn_salir.Enabled = true;

                ssModo = "NEW";
            }
        }

        private void solo_numero_enteros(object control, KeyPressEventArgs e)
        {
            if (((e.KeyChar) >= '0' && e.KeyChar <= '9') && !(e.KeyChar == '.'))
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete && !(e.KeyChar == '.'))
                {
                    e.Handled = false;
                }
                else
                {
                    if ((e.KeyChar) == (char)Keys.Tab)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        private void solo_numero_decimal(object control, KeyPressEventArgs e)
        {
            if (((e.KeyChar) >= '0' && e.KeyChar <= '9') && !(e.KeyChar == '.'))
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete && !(e.KeyChar == '.'))
                {
                    e.Handled = false;
                }
                else
                {
                    if ((e.KeyChar) == (char)Keys.Tab)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        if (e.KeyChar == '.')
                        {
                            e.Handled = false;
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
        }
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData )
        {
            if (keyData == Keys.Enter)
            {
                if (GetNextControl(ActiveControl, true) != null)
                {
                    SendKeys.Send("\t");
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public bool IsNumeric(String Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        public static KeyEventHandler CapturarTeclaGRID
        {
            get
            {
                KeyEventHandler keypress = new KeyEventHandler(LecturaTecla);
                return keypress;
            }
        }

        private static void LecturaTecla(System.Object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                VariablesPublicas.PulsaAyudaArticulos = true;
                SendKeys.Send("\t");
            }
            if (e.KeyCode == Keys.F2)
            {
                VariablesPublicas.PulsaTeclaF2 = true;
                SendKeys.Send("\t");
            }
            if (e.KeyCode == Keys.F3)
            {
                VariablesPublicas.PulsaTeclaF3 = true;
                SendKeys.Send("\t");
            }
        }

        private void AyudaLinea(String lpdescrlike)
        {
            try
            {
                var modd = string.Empty;
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                var dt = new DataTable();

                BE.dominioid = dominio;
                BE.moduloid = modulo;
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();

                        var frmayuda = new Ayudas.Frm_help_general();

                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< AYUDA  TABLA LINEA >>";
                        frmayuda.sqlquery = "SELECT lineaid, lineaname FROM tb_" + modd + "_linea ";
                        frmayuda.sqlinner = string.Empty;
                        frmayuda.sqlwhere = "where";
                        frmayuda.sqland = string.Empty;
                        frmayuda.criteriosbusqueda = new string[] { "LINEA", "CODIGO" };
                        frmayuda.columbusqueda = "lineaname,lineaid";
                        frmayuda.returndatos = "0,1";

                        frmayuda.Owner = this;
                        frmayuda.PasaProveedor = RecibeLinea;
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void RecibeLinea(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
            }
        }

        private void limpiar_documento()
        {
            try
            {
                productid.Text = string.Empty;
                productname.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevo()
        {
            limpiar_documento();
            form_bloqueado(true);
            btn_imprimir.Enabled = true;
            btn_imprimir_gen.Enabled = true;
            btn_excel.Enabled = true;
            btn_cancelar.Enabled = true;
            productid.Focus();
            ssModo = "NEW";
        }
        private void Frm_reporte_stockrollo_Load(object sender, EventArgs e)
        {
            modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
            local = ((D60ALMACEN.MainAlmacen)MdiParent).local;

            PARAMETROS_TABLA();

            limpiar_documento();
            CargarComboFechas();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_buscar.Enabled = true;
            btn_salir.Enabled = true;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            form_accion_cancelEdicion(1);
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                var miForma = new REPORTES.Frm_reportes();
                miForma.Text = "Diferencia de Inventario Rollos";
                miForma.dominioid = dominio.Trim();
                miForma.moduloid = modulo.Trim();
                miForma.local = local.Trim();
                miForma.productid = productid.Text.Trim();
                miForma.fechdoc = cmb_fechas.Text.ToString();
                miForma.formulario = "Frm_reporte_UbigeoInvRollos";
                miForma.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void productid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaProducto(string.Empty);
            }
            if (e.KeyCode == Keys.Enter)
            {
                cmb_fechas.Focus();
            }
        }

        private void AyudaProducto(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "<< AYUDA  TABLA PRODUCTOS >>";
                frmayuda.sqlquery = "SELECT tb1.productid, tb1.productname, tb2.stock,tb2.costoultimo FROM tb_ta_productos AS tb1 ";
                frmayuda.sqlinner = "inner join tb_ta_local_stock as tb2 on tb1.productid = tb2.productid ";
                frmayuda.sqlwhere = "where tb1.status = '0' and tb2.local = '" + local.ToString() + "'";
                frmayuda.sqland = "and";
                frmayuda.criteriosbusqueda = new string[] { "PRODUCTO", "CODIGO" };
                frmayuda.columbusqueda = "tb1.productname,tb1.productid";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeProducto;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }

        private void RecibeProducto(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0 && resultado2.Trim().Length > 0)
            {
                productid.Text = resultado1.Trim();
            }
        }

        private void productid_LostFocus(object sender, System.EventArgs e)
        {
            ValidaProducto();
        }

        private void ValidaProducto()
        {
            if (productid.Text.Trim().Length == 13)
            {
                var BL = new tb_60productosBL();
                var BE = new tb_60productos();
                var dt = new DataTable();

                BE.moduloid = modulo;
                BE.productid = productid.Text.Trim();
                BE.status = "0";

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    productid.Text = dt.Rows[0]["productid"].ToString().Trim();
                    productname.Text = dt.Rows[0]["productname"].ToString().Trim();
                }
                else
                {
                    productid.Text = string.Empty;
                    productname.Text = string.Empty;
                }
            }
            else
            {
                productid.Text = string.Empty;
                productname.Text = string.Empty;
            }
        }

        private void CargarComboFechas()
        {
            var BL = new tb_60local_stock_inventario_rollo_cargaBL();
            var BE = new tb_60local_stock_inventario_rollo_carga();
            var dt = new DataTable();
            dt = BL.GetAll_fechas(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cmb_fechas.DataSource = dt;
                cmb_fechas.DisplayMember = "fecha";
                cmb_fechas.ValueMember = "fecha";
            }
        }

        private void btn_imprimir_gen_Click(object sender, EventArgs e)
        {
            try
            {
                var miForma = new REPORTES.Frm_reportes();
                miForma.Text = "Diferencia de Inventario Rollos";
                miForma.dominioid = dominio.Trim();
                miForma.moduloid = modulo.Trim();
                miForma.local = local.Trim();
                miForma.fechdoc = cmb_fechas.Text.ToString();
                miForma.formulario = "Frm_reporte_UbigeoInvRollos_gen";
                miForma.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
