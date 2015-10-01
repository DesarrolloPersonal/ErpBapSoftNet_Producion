﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.APT600100.CATALOGO
{
    public partial class Frm_canalvta : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        private DataTable TablaCanalVta;
        private Boolean procesado = false;

        private String ssModo = "NEW";

        public Frm_canalvta()
        {
            InitializeComponent();          
        }

        private void PARAMETROS_TABLA()
        {
            var xxferfil = string.Empty;
            var f = (MainAlmacenPT)MdiParent;
            xxferfil = f.perfil.ToString();
            if (xxferfil.Trim().Length != 9)
            {
                MessageBox.Show("::: NO TIENE PERFIL !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PERFILID = xxferfil;
            var XTABLA_PERFIL = string.Empty;
            XTABLA_PERFIL = VariablesPublicas.GET_PARAMETROS_TABLA(xxferfil, Name);
            if (XTABLA_PERFIL.Trim().Length > 0 && XTABLA_PERFIL.Trim() != "0")
            {
                if (XTABLA_PERFIL.Trim().Length == 2)
                {
                    dominio = XTABLA_PERFIL.Trim().Substring(0, 2);
                }
                else
                {
                    if (XTABLA_PERFIL.Trim().Length == 6)
                    {
                        dominio = XTABLA_PERFIL.Trim().Substring(0, 2);
                        modulo = XTABLA_PERFIL.Trim().Substring(2, 4);
                    }
                    else
                    {
                        if (XTABLA_PERFIL.Trim().Length == 9)
                        {
                            dominio = XTABLA_PERFIL.Trim().Substring(0, 2);
                            modulo = XTABLA_PERFIL.Trim().Substring(2, 4);
                            local = XTABLA_PERFIL.Trim().Substring(6, 3);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("::: No puede accede a FORMULARIO. \n::: Es necesario DOMINIO, MODULO Y LOCAL !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void NIVEL_FORMS()
        {
            XNIVEL = VariablesPublicas.Get_nivelperfil(PERFILID, Name).Substring(0, 1);
            if (XNIVEL != "0")
            {
                btn_clave.Image = global::BapFormulariosNet.Properties.Resources.btn_Lock20;
            }
            else
            {
                btn_clave.Image = global::BapFormulariosNet.Properties.Resources.btn_Un_Lock20;
            }
        }
        private void btn_clave_Click(object sender, EventArgs e)
        {
            try
            {
                var miForma = new Ayudas.Form_user_admin();
                miForma.Owner = this;
                miForma.PasaDatos = RecibePermiso;
                miForma.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RecibePermiso(Boolean resultado1, String resultado2)
        {
            if (resultado1)
            {
                XNIVEL = "0";
                XGLOSA = resultado2.Trim();
                btn_clave.Image = global::BapFormulariosNet.Properties.Resources.btn_Un_Lock20;
            }
        }

        private void form_bloqueado(Boolean var)
        {
            try
            {
                txtcanalvtaid.Enabled = var;
                txtcanalvtaname.Enabled = var;
                chkapto.Enabled = var;
                dtpdigitos.Enabled = var;
                
                dgb_canalvta.ReadOnly = true;
                dgb_canalvta.Enabled = !var;
                txtbusqueda.Enabled = !var;
                btn_busqueda.Enabled = !var;

                btn_nuevo.Enabled = false;
                btn_editar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_grabar.Enabled = false;
                btn_eliminar.Enabled = false;
                btn_imprimir.Enabled = false;

                btn_clave.Enabled = true;
                btn_log.Enabled = true;
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
                NIVEL_FORMS();
                limpiar_documento();
                form_bloqueado(false);               
                btn_nuevo.Enabled = true;           
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

        private void SEGURIDAD_LOG(String accion)
        {
            var xclave = VariablesPublicas.EmpresaID + "/" + VariablesPublicas.perianio;
            try
            {
                var BL = new tb_co_seguridadlogBL();
                var BE = new tb_co_seguridadlog();

                BE.moduloid = Name;
                BE.clave = xclave;
                BE.cuser = VariablesPublicas.Usuar;
                BE.fecha = DateTime.Now;
                BE.pc = VariablesPublicas.userip;
                BE.accion = accion.Trim();
                BE.detalle = txtcanalvtaid.Text.Trim() + "/" + txtcanalvtaname.Text.Trim().ToUpper()  + "/" + XGLOSA;

                BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiar_documento()
        {
            txtcanalvtaid.Text = "";
            txtcanalvtaname.Text = "";
            dtpdigitos.Value = 0;
            chkapto.Checked = false;
        }

        private void nuevo()
        {
            limpiar_documento();
            form_bloqueado(true);          
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_log.Enabled = true;
            txtcanalvtaid.Focus();
            ssModo = "NEW";
        }

        private void Insert()
        {
            try
            {
                if (txtcanalvtaid.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Falta Codigo de Canal !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (txtcanalvtaname.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese Nombre de Canal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new tb_cp_canalventaBL();
                        var BE = new tb_cp_canalventa();

                        BE.canalventaid = txtcanalvtaid.Text.ToString();
                        BE.canalventaname = txtcanalvtaname.Text.ToString();
                        BE.digitos = Convert.ToInt32(dtpdigitos.Text);
                        BE.chk_apt = chkapto.Checked;                        

                        if (BL.Insert(EmpresaID, BE))
                        {
                            MessageBox.Show("Datos Grabados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            procesado = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Update()
        {
            try
            {
                if (txtcanalvtaid.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Falta Codigo de Canal !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (txtcanalvtaname.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese Nombre de Canal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new tb_cp_canalventaBL();
                        var BE = new tb_cp_canalventa();

                        BE.canalventaid = txtcanalvtaid.Text.ToString();
                        BE.canalventaname = txtcanalvtaname.Text.ToString();
                        BE.digitos = Convert.ToInt32(dtpdigitos.Text);
                        BE.chk_apt = chkapto.Checked;    

                        if (BL.Update(EmpresaID, BE))
                        {
                            SEGURIDAD_LOG("M");
                            MessageBox.Show("Datos Modificado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            procesado = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Delete()
        {
            try
            {
                if (txtcanalvtaid.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Falta Codigo Canal !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_cp_canalventaBL();
                    var BE = new tb_cp_canalventa();
                    BE.canalventaid = txtcanalvtaid.Text.ToString();

                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos Eliminados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        form_bloqueado(false);
                        limpiar_documento();
                        data_TablaCanalVta();
                        btn_nuevo.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_estado_Load(object sender, EventArgs e)
        {           
            
            modulo = ((APT600100.MainAlmacenPT)MdiParent).moduloid;
            local = ((APT600100.MainAlmacenPT)MdiParent).local;
            PERFILID = ((APT600100.MainAlmacenPT)MdiParent).perfil;            

            NIVEL_FORMS();
            TablaCanalVta = new DataTable();

            txtcanalvtaname.CharacterCasing = CharacterCasing.Upper;
            data_TablaCanalVta();
            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;            
            btn_salir.Enabled = true;
        }

        private void Frm_estado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.G)
            {
                if (btn_grabar.Enabled)
                {
                    btn_grabar_Click(sender, e);
                }
            }

            if (e.Control && e.KeyCode == Keys.N)
            {
                if (btn_nuevo.Enabled)
                {
                    btn_nuevo_Click(sender, e);
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                if (btn_cancelar.Enabled)
                {
                    form_accion_cancelEdicion(1);
                }
                else
                {
                    btn_salir_Click(sender, e);
                }
            }
        }
      

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
            {
                nuevo();
            }
        }
        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0")
            {
                ssModo = "EDIT";
                form_bloqueado(true);
                txtcanalvtaname.Focus();

                btn_cancelar.Enabled = true;
                btn_grabar.Enabled = true;
            }
        }
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            form_accion_cancelEdicion(1);
        }
        private void btn_grabar_Click(object sender, EventArgs e)
        {
            procesado = false;
            var sw_prosigue = false;
            if (ssModo == "NEW")
            {
                if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
                {
                    Insert();
                }
            }
            else
            {
                if (XNIVEL == "0" || XNIVEL == "1")
                {
                    sw_prosigue = (MessageBox.Show("¿Desea Modificar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                    if (sw_prosigue)
                    {
                        Update();
                    }
                }
            }
            if (procesado)
            {
                NIVEL_FORMS();
                data_TablaCanalVta();
                form_bloqueado(false);
                txtcanalvtaid.Text = "NN";
                btn_nuevo.Enabled = true;             

                btn_salir.Enabled = true;
            }
        }
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0")
            {
                var sw_prosigue = false;
                sw_prosigue = (MessageBox.Show("¿Desea Eliminar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                if (sw_prosigue)
                {
                    Delete();
                }
            }
        }
        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (TablaCanalVta.Rows.Count > 0)
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void btn_log_Click(object sender, EventArgs e)
        {
            var oform = new Seguridadlog.FrmSeguridad();
            var xclave = VariablesPublicas.EmpresaID + "/" + VariablesPublicas.perianio;
            oform._Nombre = Name;
            oform._ClaveForm = xclave;
            oform.Owner = this;
            oform.ShowDialog();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void data_TablaCanalVta()
        {
            try
            {
                if (TablaCanalVta.Rows.Count > 0)
                {
                    TablaCanalVta.Rows.Clear();
                }
                var BL = new tb_cp_canalventaBL();
                var BE = new tb_cp_canalventa();

                BE.parameters = txtbusqueda.Text.Trim().ToUpper();

                TablaCanalVta = BL.GetAll2(EmpresaID, BE).Tables[0];
                if (TablaCanalVta.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    dgb_canalvta.DataSource = TablaCanalVta;
                    dgb_canalvta.Rows[0].Selected = false;                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridestado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgb_canalvta.CurrentRow != null)
                {
                    var xcanalvtaid = string.Empty;
                    xcanalvtaid = dgb_canalvta.Rows[e.RowIndex].Cells["canalventaid"].Value.ToString().Trim();
                    data_CanalVta(xcanalvtaid);
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void gridestado_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xcanalvtaid = string.Empty;
                xcanalvtaid = dgb_canalvta.Rows[dgb_canalvta.CurrentRow.Index].Cells["canalventaid"].Value.ToString().Trim();
                data_CanalVta(xcanalvtaid);
            }
        }

        private void gridestado_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgb_canalvta[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            dgb_canalvta[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            dgb_canalvta.EnableHeadersVisualStyles = false;
            dgb_canalvta.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            dgb_canalvta.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void gridestado_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            dgb_canalvta[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }

        private void data_CanalVta(String xcanalvtaid)
        {
            form_bloqueado(false);
            var rowcanalvtaid = TablaCanalVta.Select("canalventaid='" + xcanalvtaid + "'");
            if (rowcanalvtaid.Length > 0)
            {
                foreach (DataRow row in rowcanalvtaid)
                {
                    txtcanalvtaid.Text = row["canalventaid"].ToString().Trim();
                    txtcanalvtaname.Text = row["canalventaname"].ToString().Trim();
                    dtpdigitos.Value = Convert.ToInt32(row["digitos"]);
                    chkapto.Checked = Convert.ToBoolean(row["chk_apt"]);

                    btn_nuevo.Enabled = true;
                    btn_editar.Enabled = true;
                    btn_eliminar.Enabled = true;
                    btn_imprimir.Enabled = true;
                    btn_log.Enabled = true;
                    btn_salir.Enabled = true;
                }
            }
        }

        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            data_TablaCanalVta();
        }

        private void txt_criterio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_busqueda_Click(sender, e);
            }
        }

        private void txtbusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            data_TablaCanalVta();
        }



    }
}
