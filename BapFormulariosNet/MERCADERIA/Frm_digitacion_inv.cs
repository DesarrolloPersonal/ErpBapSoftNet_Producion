﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.MERCADERIA
{
    public partial class Frm_digitacion_inv : plantilla
    {
        private String EmpresaID = string.Empty;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;
        private String perianio = string.Empty;
        private String perimes = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        private DataTable Tabladetallemov;
        private String almacaccionid = string.Empty;
        private DataRow row;
        private TextBox txtCDetalle = null;
        private Boolean fechadocedit = false;
        private Boolean tipodocautomatico = false;
        private Boolean tipodocmanejaserie = false;
        private Boolean statusDoc = true;

        private String incprec = "N";
        private String ssModo = "NEW";

        public Frm_digitacion_inv()
        {
            InitializeComponent();
            numdoc.LostFocus += new System.EventHandler(numdoc_LostFocus);
        }

        private void PARAMETROS_TABLA()
        {
            var xxferfil = string.Empty;
            var f = (MainMercaderia)MdiParent;
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
                if (var == false)
                {
                    tipodoc.Enabled = !var;
                    numdoc.Enabled = !var;
                }
                else
                {
                    tipodoc.Enabled = !var;
                    numdoc.Enabled = !var;
                }

                serdoc.Enabled = false;
                fechdoc.Enabled = var;

                ubic.Enabled = var;
                userinventario.Enabled = var;
                ubic.Enabled = var;
                userinventario.Enabled = var;
                cmblinea.Enabled = var;
                cmblinea2.Enabled = var;
                btnrefresh.Enabled = var;

                itemsT.Enabled = var;
                itemsT.ReadOnly = true;
                totpzas.Enabled = var;
                totpzas.ReadOnly = true;
                totpzas2.Enabled = var;
                totpzas2.ReadOnly = true;
                glosa.Enabled = var;

                griddetallemov.ReadOnly = !var;
                griddetallemov.Columns["item"].ReadOnly = true;
                griddetallemov.Columns["productname"].ReadOnly = true;
                griddetallemov.Columns["stocklibros"].ReadOnly = true;
                griddetallemov.Columns["diferencia"].ReadOnly = true;
                griddetallemov.Columns["costopromlibros"].ReadOnly = true;
                griddetallemov.Columns["costopromfisico"].ReadOnly = true;

                btn_nuevo.Enabled = false;
                btn_editar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_grabar.Enabled = false;
                btn_eliminar.Enabled = false;
                btnImprimirNoval.Enabled = false;

                btn_primero.Enabled = false;
                btn_anterior.Enabled = false;
                btn_siguiente.Enabled = false;
                btn_ultimo.Enabled = false;

                btn_detanadir.Enabled = false;
                btn_deteliminar.Enabled = false;
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
                limpiar_documento();
                form_bloqueado(false);
                btn_nuevo.Enabled = true;
                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;
                btn_salir.Enabled = true;
                ssModo = "NEW";
            }
        }

        private void form_cargar_datos(String posicion)
        {
            try
            {
                limpiar_documento();

                var BL = new tb_60local_stock_inventarioBL();
                var BE = new tb_60local_stock_inventario();

                var dt = new DataTable();

                BE.moduloid = modulo;
                BE.local = local;
                BE.tipodoc = tipodoc.SelectedValue.ToString().Trim();
                if (serdoc.Text.Trim().Length > 0)
                {
                    BE.serdoc = serdoc.Text.Trim().PadLeft(4, '0');
                    BE.numdoc = numdoc.Text.Trim().PadLeft(10, '0');
                }
                else
                {
                    if (posicion.Trim().Length > 0)
                    {
                        MessageBox.Show("Seleccionar el Tipo de Documento !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }
                if (numdoc.Text.Trim().Length > 0)
                {
                    BE.numdoc = numdoc.Text.Trim().PadLeft(10, '0');
                }

                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    ssModo = "EDIT";

                    userinventario.Text = dt.Rows[0]["userinventario"].ToString().Trim();
                    cmblinea2.SelectedValue = dt.Rows[0]["lineaid"].ToString();

                    serdoc.Text = dt.Rows[0]["serdoc"].ToString().Trim();
                    numdoc.Text = dt.Rows[0]["numdoc"].ToString().Trim();
                    fechdoc.Text = dt.Rows[0]["fechdoc"].ToString().Trim();

                    totpzas.Text = dt.Rows[0]["totpzasl"].ToString().Trim();
                    totpzas2.Text = dt.Rows[0]["totpzasf"].ToString().Trim();

                    glosa.Text = dt.Rows[0]["glosa"].ToString().Trim();
                    itemsT.Text = dt.Rows[0]["items"].ToString().Trim();

                    data_Tabladetallemovmov();
                    btn_editar.Enabled = true;
                    btn_eliminar.Enabled = true;
                    btnImprimirNoval.Enabled = true;

                    btn_primero.Enabled = true;
                    btn_anterior.Enabled = true;
                    btn_siguiente.Enabled = true;
                    btn_ultimo.Enabled = true;
                    btn_salir.Enabled = true;
                    griddetallemov.Focus();
                    griddetallemov.Rows[0].Selected = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (e.KeyCode == Keys.Enter)
            {
                VariablesPublicas.Enter = true;
                SendKeys.Send("\t");
            }
        }
        private void AyudaProducto(String lpdescrlike)
        {
            try
            {
                griddetallemov.CurrentCell = griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["productname"];
                var prod = Convert.ToString(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productid"].Value);
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
                        var frmayuda = new Ayudas.Form_help_stockinventario();

                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< Ayuda Producto Inventariado >>";

                        frmayuda.sqlquery = " select li.productid," +
                                                    " p.productname," +
                                                    " li.stocklibros," +
                                                    " li.stockfisico," +
                                                    " li.diferencia," +
                                                    " li.costopromlibros," +
                                                    " li.costopromfisico " +
                                                    " from tb_" + modd + "_local_stock_inventario li ";
                        frmayuda.sqlinner = " left join tb_" + modd + "_productos p on li.productid = p.productid ";
                        frmayuda.sqlwhere = "where";
                        frmayuda.criteriosbusqueda = new string[] { "PRODUCTO", "CODIGO" };
                        frmayuda.columbusqueda = "p.productname,li.productid";
                        frmayuda.returndatos = "0,1";

                        frmayuda.Owner = this;
                        frmayuda.PasaProveedor = RecibeProductoRollo;
                        if (prod == string.Empty)
                        {
                            prod = "_";
                        }
                        frmayuda.txt_busqueda.Text = prod;
                        frmayuda.btnbuscar.PerformClick();
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RecibeProductoRollo(DataTable dtresultado)
        {
            try
            {
                if (dtresultado.Rows.Count > 0)
                {
                    var cont = 0;
                    foreach (DataRow fila in dtresultado.Rows)
                    {
                        cont = cont + 1;
                        if (griddetallemov.Rows.Count > 0)
                        {
                            var nFilaAnt = griddetallemov.RowCount - 1;
                            var xProductid = fila["productid"].ToString();
                            var xProductname = fila["productname"].ToString();

                            if (cont > 1)
                            {
                                Tabladetallemov.Rows.Add(VariablesPublicas.InsertIntoTable(Tabladetallemov));
                                Tabladetallemov.Rows[Tabladetallemov.Rows.Count - 1]["items"] = VariablesPublicas.CalcMaxField(Tabladetallemov, "items", 5);
                                griddetallemov.Rows[nFilaAnt + 1].Cells["productid"].Value = xProductid;
                                griddetallemov.Rows[nFilaAnt + 1].Cells["productname"].Value = xProductname;
                            }
                            else
                            {
                                griddetallemov.Rows[nFilaAnt].Cells["productid"].Value = xProductid;
                                griddetallemov.Rows[nFilaAnt].Cells["productname"].Value = xProductname;
                            }

                            griddetallemov.CurrentCell = griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["stockfisico"];
                            griddetallemov.BeginEdit(true);
                            ValidaTabladetallemovmov(xProductid);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SEGURIDAD_LOG(String accion)
        {
            var xclave = VariablesPublicas.EmpresaID + "-" + modulo + "-" + tipodoc.Text.Trim() + "-" + serdoc.Text.Trim() + "-" + numdoc.Text.Trim();
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
                BE.detalle = tipodoc.Text.Trim() + "-" + serdoc.Text.Trim() + "-" + numdoc.Text.Trim() + "/" + XGLOSA;

                BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiar_documento()
        {
            try
            {
                NIVEL_FORMS();
                incprec = "N";
                ssModo = "NEW";
                ubic.Text = string.Empty;
                userinventario.Text = string.Empty;
                itemsT.Text = "0";
                totpzas.Text = "0";
                totpzas2.Text = "0";
                data_Tabladetallemovmov();
                glosa.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void calcular_totales()
        {
            if (Tabladetallemov != null)
            {
                if (Tabladetallemov.Rows.Count != 0)
                {
                    itemsT.Text = Tabladetallemov.Rows.Count.ToString();
                    totpzas.Text = Convert.ToDecimal(Tabladetallemov.Compute("sum(stocklibros)", string.Empty)).ToString("##,###,##0.00");
                    totpzas2.Text = Convert.ToDecimal(Tabladetallemov.Compute("sum(stockfisico)", string.Empty)).ToString("##,###,##0.00");
                }
                else
                {
                    itemsT.Text = Tabladetallemov.Rows.Count.ToString();
                    totpzas.Text = "0";
                    totpzas2.Text = "0";
                }
            }
        }

        private void nuevo()
        {
            tipodoc.SelectedIndex = 0;
            limpiar_documento();

            pnllineano.Visible = false;
            pnllineasi.Visible = true;

            form_bloqueado(false);
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_detanadir.Enabled = true;
            btn_deteliminar.Enabled = true;

            ssModo = "NEW";
        }

        private void Insert()
        {
            try
            {
                if (Tabladetallemov.Rows.Count == 0)
                {
                    MessageBox.Show("Documento no tiene Items !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_60local_stock_inventarioBL();
                    var BE = new tb_60local_stock_inventario();

                    var Detalle = new tb_60local_stock_inventario.Item();
                    var ListaItems = new List<tb_60local_stock_inventario.Item>();

                    BE.dominioid = dominio;
                    BE.moduloid = modulo;
                    BE.local = local;
                    BE.lineaid = cmblinea.SelectedValue.ToString();
                    BE.tipodoc = tipodoc.SelectedValue.ToString();
                    BE.serdoc = serdoc.Text;
                    BE.numdoc = numdoc.Text;
                    BE.items = itemsT.Text.Trim();
                    BE.totpzasl = totpzas.Text.Trim();
                    BE.totpzasf = totpzas2.Text.Trim();
                    BE.userinventario = userinventario.Text;
                    BE.glosa = glosa.Text.Trim().ToUpper().ToString();
                    BE.fechdoc = Convert.ToDateTime(fechdoc.Text);
                    BE.usuar = VariablesPublicas.Usuar;


                    var item = 0;
                    foreach (DataRow fila in Tabladetallemov.Rows)
                    {
                        Detalle = new tb_60local_stock_inventario.Item();
                        item++;

                        Detalle.items = fila["items"].ToString();
                        Detalle.productid = fila["productid"].ToString();
                        Detalle.stocklibros = Convert.ToDecimal(fila["stocklibros"].ToString());
                        Detalle.stockfisico = Convert.ToDecimal(fila["stockfisico"].ToString());

                        Detalle.costopromlibros = Convert.ToDecimal(fila["costopromlibros"].ToString());
                        Detalle.costopromfisico = Convert.ToDecimal(fila["costopromfisico"].ToString());

                        Detalle.fechdoc = Convert.ToDateTime(fechdoc.Text);
                        Detalle.userinventariado = userinventario.Text;
                        Detalle.codigoubic = ubic.Text;
                        Detalle.usuar = VariablesPublicas.Usuar;

                        if (fila["productid"].ToString().Trim().Length == 13 && Convert.ToDecimal(fila["stockfisico"]) > 0)
                        {
                            ListaItems.Add(Detalle);
                        }
                        else
                        {
                            MessageBox.Show("Documento DETALLE EN FORMATO INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    if (ListaItems.Count == 0)
                    {
                        MessageBox.Show("Documento SIN DETALLE Y/O DETALLE INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    BE.ListaItems = ListaItems;
                    if (BL.Insert(EmpresaID, BE))
                    {
                        NIVEL_FORMS();
                        MessageBox.Show("Datos grabados correctamente !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        form_bloqueado(false);
                        btn_nuevo.Enabled = true;
                        btnImprimirNoval.Enabled = true;
                        btn_primero.Enabled = true;
                        btn_anterior.Enabled = true;
                        btn_siguiente.Enabled = true;
                        btn_ultimo.Enabled = true;
                        btn_salir.Enabled = true;
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
                if (Tabladetallemov.Rows.Count == 0)
                {
                    MessageBox.Show("Documento no tiene Items !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_60local_stock_inventarioBL();
                    var BE = new tb_60local_stock_inventario();

                    var Detalle = new tb_60local_stock_inventario.Item();
                    var ListaItems = new List<tb_60local_stock_inventario.Item>();

                    BE.dominioid = dominio;
                    BE.moduloid = modulo;
                    BE.local = local;
                    BE.lineaid = cmblinea2.SelectedValue.ToString();
                    BE.tipodoc = tipodoc.SelectedValue.ToString();
                    BE.serdoc = serdoc.Text;
                    BE.numdoc = numdoc.Text;
                    BE.items = itemsT.Text.Trim();
                    BE.totpzasl = totpzas.Text.Trim();
                    BE.totpzasf = totpzas2.Text.Trim();
                    BE.userinventario = userinventario.Text;
                    BE.glosa = glosa.Text.Trim().ToUpper().ToString();
                    BE.fechdoc = Convert.ToDateTime(fechdoc.Text);
                    BE.usuar = VariablesPublicas.Usuar;


                    var item = 0;
                    foreach (DataRow fila in Tabladetallemov.Rows)
                    {
                        Detalle = new tb_60local_stock_inventario.Item();
                        item++;

                        Detalle.items = fila["items"].ToString();
                        Detalle.productid = fila["productid"].ToString();

                        Detalle.stocklibros = Convert.ToDecimal(fila["stocklibros"].ToString());
                        Detalle.stockfisico = Convert.ToDecimal(fila["stockfisico"].ToString());

                        Detalle.costopromlibros = Convert.ToDecimal(fila["costopromlibros"].ToString());
                        Detalle.costopromfisico = Convert.ToDecimal(fila["costopromfisico"].ToString());


                        Detalle.fechdoc = Convert.ToDateTime(fechdoc.Text);
                        Detalle.userinventariado = userinventario.Text;
                        Detalle.codigoubic = ubic.Text;
                        Detalle.usuar = VariablesPublicas.Usuar;

                        if (fila["productid"].ToString().Trim().Length == 13 && Convert.ToDecimal(fila["stockfisico"]) > 0)
                        {
                            ListaItems.Add(Detalle);
                        }
                        else
                        {
                            MessageBox.Show("Documento DETALLE EN FORMATO INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    if (ListaItems.Count == 0)
                    {
                        MessageBox.Show("Documento SIN DETALLE Y/O DETALLE INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    BE.ListaItems = ListaItems;
                    if (BL.Update(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("M");
                        NIVEL_FORMS();
                        MessageBox.Show("Datos modificados correctamente !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        form_bloqueado(false);
                        btn_nuevo.Enabled = true;
                        btnImprimirNoval.Enabled = true;
                        btn_primero.Enabled = true;
                        btn_anterior.Enabled = true;
                        btn_siguiente.Enabled = true;
                        btn_ultimo.Enabled = true;
                        btn_salir.Enabled = true;
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
                if (Tabladetallemov.Rows.Count == 0)
                {
                    MessageBox.Show("Documento no tiene Items !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (numdoc.Text.Trim().Length == 10)
                    {
                        var BL = new tb_60local_stock_inventarioBL();
                        var BE = new tb_60local_stock_inventario();
                        BE.moduloid = modulo;
                        BE.local = local;
                        BE.tipodoc = tipodoc.SelectedValue.ToString();
                        BE.serdoc = serdoc.Text.Trim();
                        BE.numdoc = numdoc.Text.Trim();

                        if (BL.Delete(EmpresaID, BE))
                        {
                            SEGURIDAD_LOG("E");
                            NIVEL_FORMS();
                            MessageBox.Show("Datos eliminados correctamente !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limpiar_documento();
                            form_bloqueado(false);
                            btn_nuevo.Enabled = true;
                            btn_primero.Enabled = true;
                            btn_anterior.Enabled = true;
                            btn_siguiente.Enabled = true;
                            btn_ultimo.Enabled = true;
                            btn_salir.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_digitacion_inv_Load(object sender, EventArgs e)
        {
            EmpresaID = VariablesPublicas.EmpresaID.Trim();
            pnllineano.Visible = false;
            pnllineasi.Visible = false;
            PARAMETROS_TABLA();
            data_cbo_tipodoc();

            cargar_lineanoLSI();
            cargar_lineasiLSI();

            ubic.CharacterCasing = CharacterCasing.Upper;
            userinventario.CharacterCasing = CharacterCasing.Upper;
            fechdoc.Text = DateTime.Today.ToShortDateString();

            Tabladetallemov = new DataTable("detallemov");
            Tabladetallemov.Columns.Add("items", typeof(String));
            Tabladetallemov.Columns.Add("productid", typeof(String));
            Tabladetallemov.PrimaryKey = new DataColumn[] { Tabladetallemov.Columns["productid"] };
            Tabladetallemov.Columns["productid"].Unique = true;


            Tabladetallemov.Columns.Add("productname", typeof(String));
            Tabladetallemov.Columns.Add("rollo", typeof(String));

            Tabladetallemov.Columns.Add("stocklibros", typeof(Decimal));
            Tabladetallemov.Columns["stocklibros"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("stockfisico", typeof(Decimal));
            Tabladetallemov.Columns["stockfisico"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("diferencia", typeof(Decimal));
            Tabladetallemov.Columns["diferencia"].DefaultValue = 0;

            Tabladetallemov.Columns.Add("costopromlibros", typeof(Decimal));
            Tabladetallemov.Columns["costopromlibros"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("costopromfisico", typeof(Decimal));
            Tabladetallemov.Columns["costopromfisico"].DefaultValue = 0;
            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_primero.Enabled = true;
            btn_anterior.Enabled = true;
            btn_siguiente.Enabled = true;
            btn_ultimo.Enabled = true;
            btn_salir.Enabled = true;
        }

        private void Frm_digitacion_inv_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btn_grabar.Enabled)
            {
                MessageBox.Show("Finalice edición para cerrar formulario", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void cargar_lineasiLSI()
        {
            try
            {
                var BE = new tb_60linea();
                var BL = new tb_60lineaBL();

                BE.moduloid = modulo;
                BE.local = local;
                var table = BL.GetAllsiLSI(EmpresaID, BE).Tables[0];

                cmblinea.DataSource = table;
                cmblinea.ValueMember = "lineaid";
                cmblinea.DisplayMember = "lineaname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargar_lineanoLSI()
        {
            try
            {
                var BE = new tb_60linea();
                var BL = new tb_60lineaBL();

                BE.moduloid = modulo;
                BE.local = local;
                var table = BL.GetAll(EmpresaID, BE).Tables[0];

                cmblinea2.DataSource = table;
                cmblinea2.ValueMember = "lineaid";
                cmblinea2.DisplayMember = "lineaname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (XNIVEL == "0" || XNIVEL == "1")
            {
                ssModo = "EDIT";
                form_bloqueado(true);

                btn_cancelar.Enabled = true;
                btn_grabar.Enabled = true;
                btn_detanadir.Enabled = true;
                btn_deteliminar.Enabled = true;
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            form_accion_cancelEdicion(1);
            pnllineano.Visible = false;
            pnllineasi.Visible = false;
        }

        private void btn_grabar_Click(object sender, EventArgs e)
        {
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
                if (Tabladetallemov.Rows.Count > 0)
                {
                    var miForma = new REPORTES.Frm_reportes();

                    miForma.dominioid = dominio.Trim();
                    miForma.moduloid = modulo.Trim();
                    miForma.local = local.Trim();

                    miForma.Text = "Reporte Movimientos de Productos";
                    miForma.formulario = "Frm_movimiento_rollos";
                    miForma.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_imprimir2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Tabladetallemov.Rows.Count > 0)
                {
                    var miForma = new REPORTES.Frm_reportes();

                    miForma.dominioid = dominio.Trim();
                    miForma.moduloid = modulo.Trim();
                    miForma.local = local.Trim();

                    miForma.Text = "Reporte Movimientos de Productos";
                    miForma.formulario = "Frm_movimiento_rollos2";
                    miForma.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_primero_Click(object sender, EventArgs e)
        {
            pnllineasi.Visible = false;
            pnllineano.Visible = true;
            form_cargar_datos(Genericas.primero);
        }

        private void btn_anterior_Click(object sender, EventArgs e)
        {
            pnllineasi.Visible = false;
            pnllineano.Visible = true;
            form_cargar_datos(Genericas.anterior);
        }

        private void btn_siguiente_Click(object sender, EventArgs e)
        {
            pnllineasi.Visible = false;
            pnllineano.Visible = true;
            form_cargar_datos(Genericas.siguiente);
        }

        private void btn_ultimo_Click(object sender, EventArgs e)
        {
            pnllineasi.Visible = false;
            pnllineano.Visible = true;
            form_cargar_datos(Genericas.ultimo);
        }

        private void btn_detanadir_Click(object sender, EventArgs e)
        {
            try
            {
                if (griddetallemov.Enabled)
                {
                    if (griddetallemov.Rows.Count > 0)
                    {
                        if (griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["productid"].Value.ToString().Trim().Length > 0)
                        {
                            griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["productid"].Value.ToString();
                            griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["productname"].Value.ToString();
                            Tabladetallemov.Rows.Add(VariablesPublicas.InsertIntoTable(Tabladetallemov));
                            Tabladetallemov.Rows[Tabladetallemov.Rows.Count - 1]["items"] = VariablesPublicas.CalcMaxField(Tabladetallemov, "items", 5);
                            griddetallemov.CurrentCell = griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["productid"];
                            griddetallemov.BeginEdit(true);
                        }
                        else
                        {
                            MessageBox.Show("Ingrese producto !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        Tabladetallemov.Rows.Add(VariablesPublicas.InsertIntoTable(Tabladetallemov));
                        Tabladetallemov.Rows[Tabladetallemov.Rows.Count - 1]["items"] = VariablesPublicas.CalcMaxField(Tabladetallemov, "items", 5);
                        griddetallemov.CurrentCell = griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["productid"];
                        griddetallemov.BeginEdit(true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_deteliminar_Click(object sender, EventArgs e)
        {
            var lc_cont = 0;
            var xcoditem = string.Empty;
            if ((griddetallemov.CurrentRow != null))
            {
                xcoditem = griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["item"].Value.ToString();
                for (lc_cont = 0; lc_cont <= Tabladetallemov.Rows.Count - 1; lc_cont++)
                {
                    if (Tabladetallemov.Rows[lc_cont]["items"].ToString() == xcoditem)
                    {
                        Tabladetallemov.Rows[lc_cont].Delete();
                        Tabladetallemov.AcceptChanges();
                        break;
                    }
                }
                for (lc_cont = 0; lc_cont <= Tabladetallemov.Rows.Count - 1; lc_cont++)
                {
                    Tabladetallemov.Rows[lc_cont]["items"] = VariablesPublicas.PADL(Convert.ToString(lc_cont + 1), 5, "0");
                }
                calcular_totales();
            }
        }

        private void Recibedetallemov(DataTable resultado)
        {
            if (resultado.Rows.Count > 0)
            {
                Tabladetallemov = resultado;
                griddetallemov.DataSource = Tabladetallemov;
                calcular_totales();
            }
        }

        private void btn_log_Click(object sender, EventArgs e)
        {
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quieres cerrar el formulario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void data_Tabladetallemovmov()
        {
            try
            {
                Decimal
                xxdiferencia = 0,
                xxstockfisico = 0,
                xxstocklibros = 0;
                griddetallemov.AutoGenerateColumns = false;

                var BL = new tb_60local_stock_inventarioBL();
                var BE = new tb_60local_stock_inventario();

                var dt = new DataTable();
                BE.moduloid = modulo;
                BE.local = local;
                BE.tipodoc = tipodoc.SelectedValue.ToString().Trim();
                BE.serdoc = serdoc.Text.Trim().PadLeft(4, '0');
                BE.numdoc = numdoc.Text.Trim().PadLeft(10, '0');

                dt = BL.GetAll_datosdetalle(EmpresaID, BE).Tables[0];
                if (Tabladetallemov != null)
                {
                    Tabladetallemov.Clear();
                }

                foreach (DataRow fila in dt.Rows)
                {
                    var BL2 = new tb_60local_stock_inventarioBL();
                    var BE2 = new tb_60local_stock_inventario();
                    var dt2 = new DataTable();
                    BE2.moduloid = modulo;
                    BE2.local = local;
                    BE2.productid = fila["productid"].ToString();

                    dt2 = BL2.GetOneNew(EmpresaID, BE2).Tables[0];

                    if (dt2.Rows.Count > 0)
                    {
                    }

                    row = Tabladetallemov.NewRow();
                    row["items"] = fila["items"].ToString();
                    row["productid"] = fila["productid"].ToString().Trim();
                    row["productname"] = fila["productname"].ToString().Trim();
                    row["stocklibros"] = fila["stocklibros"].ToString();
                    row["stockfisico"] = fila["stockfisico"].ToString();
                    xxstocklibros = Convert.ToDecimal(fila["stocklibros"].ToString());
                    xxstockfisico = Convert.ToDecimal(fila["stockfisico"].ToString());
                    xxdiferencia = xxstocklibros - xxstockfisico;
                    ubic.Text = fila["codigoubic"].ToString();
                    row["diferencia"] = xxdiferencia;
                    row["costopromlibros"] = Convert.ToDecimal(fila["costopromlibros"].ToString());
                    row["costopromfisico"] = Convert.ToDecimal(fila["costopromfisico"].ToString());
                    Tabladetallemov.Rows.Add(row);
                }
                griddetallemov.DataSource = Tabladetallemov;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidaTabladetallemovmov(String valproductid)
        {
            var xproductid = string.Empty;
            Decimal xstocklibros = 0,
            xstockfisico = 0,
            xdiferencia = 0;
            xproductid = valproductid.Trim();

            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productname"].Value = string.Empty;
            if (xproductid.Trim().Length == 13)
            {
                var BL = new tb_60local_stock_inventarioBL();
                var BE = new tb_60local_stock_inventario();
                var DT = new DataTable();
                BE.moduloid = modulo;
                BE.productid = xproductid;

                DT = BL.GetOneNew(EmpresaID, BE).Tables[0];

                if (DT.Rows.Count > 0)
                {
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productid"].Value = DT.Rows[0]["productid"].ToString().Trim();
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productname"].Value = DT.Rows[0]["productname"].ToString().Trim();
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["stocklibros"].Value = DT.Rows[0]["stocklibros"].ToString().Trim();
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["stockfisico"].Value = DT.Rows[0]["stockfisico"].ToString().Trim();

                    xstocklibros = Convert.ToDecimal(DT.Rows[0]["stocklibros"].ToString());
                    xstockfisico = Convert.ToDecimal(DT.Rows[0]["stockfisico"].ToString());

                    xdiferencia = xstocklibros - xstockfisico;

                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["diferencia"].Value = xdiferencia;

                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["costopromlibros"].Value = DT.Rows[0]["costopromlibros"].ToString().Trim();
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["costopromfisico"].Value = DT.Rows[0]["costopromfisico"].ToString().Trim();

                    Tabladetallemov.AcceptChanges();
                    griddetallemov.CurrentCell = griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["stockfisico"];
                }
                else
                {
                    MessageBox.Show("Producto no existe en tabla LOCAL_STOCK !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Producto no existe !!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void griddetallemov_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    if ((griddetallemov.CurrentCell != null))
                    {
                        if (griddetallemov.CurrentCell.ReadOnly == false)
                        {
                            if (griddetallemov.Columns[griddetallemov.CurrentCell.ColumnIndex].Name.ToUpper() == "productid".ToUpper())
                            {
                                griddetallemov.CurrentCell = griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["productname"];
                                var xcod = string.Empty;
                                var prod = Convert.ToString(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productid"].Value);
                                if (prod == string.Empty)
                                {
                                    xcod = "_";
                                    AyudaProducto(xcod);
                                }
                                else
                                {
                                    AyudaProducto(prod);
                                }
                            }
                        }
                    }
                }


                if (e.KeyCode == (Keys.Back | Keys.LButton))
                {
                    if ((griddetallemov.CurrentCell != null))
                    {
                        if (griddetallemov.CurrentCell.ReadOnly == true)
                        {
                            var prod = Convert.ToString(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productid"].Value);
                            if (prod != string.Empty)
                            {
                                ValidaTabladetallemovmov(prod);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void griddetallemov_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (VariablesPublicas.PulsaAyudaArticulos)
                {
                    if (griddetallemov.Columns[griddetallemov.CurrentCell.ColumnIndex].Name.ToUpper() == "productid".ToUpper())
                    {
                        AyudaProducto(string.Empty);
                    }
                    VariablesPublicas.PulsaAyudaArticulos = false;
                    Tabladetallemov.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void griddetallemov_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (griddetallemov.Columns[griddetallemov.CurrentCell.ColumnIndex].Name.ToUpper() == "productid".ToUpper())
            {
                txtCDetalle = (TextBox)e.Control;
                txtCDetalle.MaxLength = 13;
                txtCDetalle.CharacterCasing = CharacterCasing.Upper;
                txtCDetalle.Text.Trim();
                e.Control.KeyDown += CapturarTeclaGRID;
            }
        }

        private void griddetallemov_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (griddetallemov.CurrentRow != null)
                {
                    if (griddetallemov.Columns[e.ColumnIndex].Name.ToUpper() == "productid".ToUpper())
                    {
                        var xrollo = string.Empty;
                        xrollo = (griddetallemov.Rows[griddetallemov.CurrentRow.Index].Cells["rollo"].Value.ToString().Trim()).PadLeft(13, '0');
                        if (xrollo != "0000000000000")
                        {
                            ValidaTabladetallemovmov(xrollo);
                        }
                    }

                    if (griddetallemov.Columns[e.ColumnIndex].Name.ToUpper() == "stockfisico".ToUpper())
                    {
                        Decimal xstocklib = 0, xstockfis = 0, diferencia = 0;

                        xstocklib = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["stocklibros"].Value);
                        xstockfis = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["stockfisico"].Value);
                        diferencia = xstocklib - xstockfis;
                        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["diferencia"].Value = diferencia;
                    }
                }

                calcular_totales();
            }
            catch (Exception ex)
            {
                var error = string.Empty;
                error = ex.GetType().ToString();
                if (error == "System.Data.ConstraintException")
                {
                    MessageBox.Show("Producto ya existe!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void griddetallemov_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            griddetallemov.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            griddetallemov[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(39, 95, 178);
            griddetallemov[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);
        }

        private void griddetallemov_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            griddetallemov[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }
        private void btnImprimirNoval_Click(object sender, EventArgs e)
        {
            try
            {
                if (Tabladetallemov.Rows.Count > 0)
                {
                    var miForma = new REPORTES.Frm_reportes();

                    miForma.dominioid = dominio.Trim();
                    miForma.moduloid = modulo.Trim();
                    miForma.local = local.Trim();

                    miForma.Text = "Reporte Inventariado Fisico";
                    miForma.formulario = "Frm_reporte_inventariado";
                    miForma.tipdoc = tipodoc.SelectedValue.ToString();
                    miForma.serdoc = serdoc.Text.Trim().PadLeft(4, '0');
                    miForma.numdoc = numdoc.Text.Trim().PadLeft(10, '0');
                    miForma.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tipodoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            perianio = string.Empty;
            perimes = string.Empty;
            fechadocedit = false;

            tipodocautomatico = false;
            tipodocmanejaserie = false;
            statusDoc = true;

            if (btn_nuevo.Enabled == false)
            {
                limpiar_documento();
                select_tipodoc();
                if (statusDoc)
                {
                    form_bloqueado(true);
                    fechdoc.Enabled = false;
                    btn_cancelar.Enabled = true;
                    btn_grabar.Enabled = true;
                    btn_detanadir.Enabled = true;
                    btn_deteliminar.Enabled = true;
                }
            }
            else
            {
                select_tipodoc();
                numdoc.Text = string.Empty;
            }
        }

        private void data_cbo_tipodoc()
        {
            try
            {
                var BL = new modulo_local_tipodocBL();
                var BE = new tb_modulo_local_tipodoc();
                BE.dominioid = dominio;
                BE.moduloid = modulo;
                BE.local = local;
                BE.visiblealmac = true;
                BE.status = "1";

                tipodoc.DataSource = BL.GetAll_mov(EmpresaID, BE).Tables[0];
                tipodoc.ValueMember = "tipodoc";
                tipodoc.DisplayMember = "tipodocname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void select_tipodoc()
        {
            try
            {
                if (tipodoc.SelectedValue.ToString() != "00" && tipodoc.SelectedIndex != 0)
                {
                    var BL = new modulo_local_tipodocBL();
                    var BE = new tb_modulo_local_tipodoc();
                    var dt = new DataTable();

                    BE.dominioid = dominio;
                    BE.moduloid = modulo;
                    BE.local = local;
                    BE.tipodoc = tipodoc.SelectedValue.ToString().Trim();
                    BE.visiblealmac = true;

                    dt = BL.GetAll(EmpresaID, BE).Tables[0];

                    almacaccionid = dt.Rows[0]["almacaccionid"].ToString().Trim();

                    tipodocautomatico = Convert.ToBoolean(dt.Rows[0]["tipodocautomatico"]);
                    tipodocmanejaserie = Convert.ToBoolean(dt.Rows[0]["tipodocmanejaserie"]);

                    if (almacaccionid.Trim().Length > 0)
                    {
                        if (tipodocautomatico)
                        {
                            if (tipodocmanejaserie)
                            {
                                get_autoCS_numMov();
                            }
                            else
                            {
                                MessageBox.Show("Documento debe manejar Serie", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                statusDoc = false;
                            }
                        }
                        else
                        {
                            if (tipodocmanejaserie)
                            {
                                get_autoCS_numMov();
                                numdoc.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("Documento debe manejar Serie", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                statusDoc = false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Asignar la Accion del Documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        statusDoc = false;
                    }
                }
                else
                {
                    serdoc.Text = string.Empty;
                    numdoc.Text = string.Empty;
                    statusDoc = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusDoc = false;
            }
        }

        private void get_autoCS_numMov()
        {
            try
            {
                var BL = new modulo_local_tipodocseriesBL();
                var BE = new tb_modulo_local_tipodocseries();
                var dt = new DataTable();
                BE.dominioid = dominio;
                BE.moduloid = modulo;
                BE.local = local;
                BE.tipodoc = tipodoc.SelectedValue.ToString().Trim();

                dt = BL.GetAll_nuevonumero(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    serdoc.Text = dt.Rows[0]["serdoc"].ToString();
                    numdoc.Text = dt.Rows[0]["numero"].ToString();
                }
                else
                {
                    serdoc.Text = string.Empty;
                    numdoc.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            cargar_lineasiLSI();
        }

        private void Frm_digitacion_inv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                if (!griddetallemov.ReadOnly)
                {
                    btn_detanadir_Click(sender, e);
                }
            }

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

        private void numdoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(numdoc, e);
        }

        private void numdoc_LostFocus(object sender, System.EventArgs e)
        {
            form_cargar_datos(string.Empty);
        }
    }
}
