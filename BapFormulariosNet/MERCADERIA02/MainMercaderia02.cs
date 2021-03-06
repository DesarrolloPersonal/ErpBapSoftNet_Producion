﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using System.Xml;

namespace BapFormulariosNet.MERCADERIA02
{
    public partial class MainMercaderia02 : DevExpress.XtraEditors.XtraForm
    {
        private string TituloForm = "ERP - Bapsoft.Net - ";
        private System.Reflection.Assembly Ensamblado;
        private String _cajanume = string.Empty;
        public string perfil { get; set; }
        public string perianio { get; set; }
        public string perimes { get; set; }
        public DateTime fechdigini { get; set; }
        public DateTime fechdigfin { get; set; }
        public string dominioid { get; set; }
        public string moduloid { get; set; }
        public String moduloname { get; set; }
        public string local { get; set; }
        public string localname { get; set; }
        public string ctacte { get; set; }
        public string ctactename { get; set; }
        public string direcnume { get; set; }
        public bool novalidastock { get; set; }
        public bool editnumdoc { get; set; }
        public string estabsunat { get; set; }
        public DateTime localfeuiv { get; set; }


        public MainMercaderia02()
        {
            InitializeComponent();
        }

        private void MainMenuAlmacen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (XtraMessageBox.Show("Quieres cerrar el Módulo?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private DataTable dtMenuItems = new DataTable();
        private string appPath = string.Empty;

        private void MainMercaderia_Load(object sender, EventArgs e)
        {
            StatusBar();
            Metodo_VariablesStatic();
        }

        private void Metodo_VariablesPublicas()
        {
            Ensamblado = System.Reflection.Assembly.GetExecutingAssembly();
            try
            {
                perfil = VariablesPublicas.Perfil;
                appPath = Application.ExecutablePath;

                var usuariosBL = new usuariosBL();
                var COD_USU = Convert.ToString(VariablesPublicas.Usuar);
                dtMenuItems = usuariosBL.GenerarMenuXperfil(VariablesPublicas.EmpresaID, COD_USU, VariablesPublicas.Perfil).Tables[0];

                mainMenu.Items.Clear();
                appPath = appPath.Substring(0, 28) + "Iconos\\";

                for (var nMain = 0; nMain < dtMenuItems.Rows.Count; nMain++)
                {
                    if (dtMenuItems.Rows[nMain]["menid"].Equals(dtMenuItems.Rows[nMain]["padid"]))
                    {
                        var tsmMain = new ToolStripMenuItem(dtMenuItems.Rows[nMain]["descr"].ToString());
                        if (dtMenuItems.Rows[nMain]["icono"].ToString().Trim().Length > 0)
                        {
                            tsmMain.Image = Bitmap.FromFile(appPath + dtMenuItems.Rows[nMain]["icono"].ToString().Trim());
                        }
                        mainMenu.Items.Add(tsmMain);
                        AddSubMenu(dtMenuItems.Rows[nMain]["menid"].ToString(), tsmMain);
                    }
                }
                Controls.Add(mainMenu);
            }
            catch
            {
            }
        }

        private void Metodo_VariablesStatic()
        {
            Ensamblado = System.Reflection.Assembly.GetExecutingAssembly();
            try
            {
                appPath = Application.ExecutablePath;

                var usuariosBL = new usuariosBL();
                var COD_USU = Convert.ToString(VariablesPublicas.Usuar);
                dtMenuItems = usuariosBL.GenerarMenuXperfil(VariablesPublicas.EmpresaID, COD_USU, perfil).Tables[0];

                mainMenu.Items.Clear();
                appPath = appPath.Substring(0, 28) + "Iconos\\";

                for (var nMain = 0; nMain < dtMenuItems.Rows.Count; nMain++)
                {
                    if (dtMenuItems.Rows[nMain]["menid"].Equals(dtMenuItems.Rows[nMain]["padid"]))
                    {
                        var tsmMain = new ToolStripMenuItem(dtMenuItems.Rows[nMain]["descr"].ToString());
                        if (dtMenuItems.Rows[nMain]["icono"].ToString().Trim().Length > 0)
                        {
                            tsmMain.Image = Bitmap.FromFile(appPath + dtMenuItems.Rows[nMain]["icono"].ToString().Trim());
                        }
                        mainMenu.Items.Add(tsmMain);
                        AddSubMenu(dtMenuItems.Rows[nMain]["menid"].ToString(), tsmMain);
                    }
                }
                Controls.Add(mainMenu);
            }
            catch
            {
            }
        }

        private void MainAlmacen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (XtraMessageBox.Show("Quieres cerrar el Módulo?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void AddSubMenu(string sId, ToolStripMenuItem main)
        {
            String nameForm;
            foreach (System.Data.DataRow drMenuItem in dtMenuItems.Rows)
            {
                if (drMenuItem["padid"].ToString().Equals(sId) && !drMenuItem["menid"].Equals(drMenuItem["padid"]))
                {
                    var tsmSub = new ToolStripMenuItem(drMenuItem["descr"].ToString());
                    nameForm = drMenuItem["pgurl"].ToString();
                    tsmSub.Tag = drMenuItem["pgurl"].ToString();
                    if (drMenuItem["icono"].ToString().Trim().Length > 0)
                    {
                        tsmSub.Image = Bitmap.FromFile(appPath + drMenuItem["icono"].ToString().Trim());
                    }
                    tsmSub.Name = drMenuItem["pgurl"].ToString();

                    tsmSub.Click += new EventHandler(MenuItemClicked);
                    main.DropDownItems.Add(tsmSub);
                    AddSubMenu(drMenuItem["menid"].ToString(), tsmSub);
                }
            }
        }

        private void MenuItemClicked(object sender, EventArgs e)
        {
            try
            {
                if (sender.GetType() == typeof(ToolStripMenuItem))
                {
                    var NombreFormulario = ((ToolStripItem)sender).Tag.ToString();
                    Object ObjFrm;
                    var tipo = Ensamblado.GetType(Ensamblado.GetName().Name + "." + NombreFormulario);
                    if (tipo == null)
                    {
                    }
                    else
                    {
                        if (!FormularioEstaAbierto(NombreFormulario))
                        {
                            ObjFrm = Activator.CreateInstance(tipo);
                            var Formulario = (plantilla)ObjFrm;
                            Formulario.MdiParent = this;
                            Formulario.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private Boolean FormularioEstaAbierto(String NombreDelFrm)
        {
            if (MdiChildren.Length > 0)
            {
                for (var i = 0; i < MdiChildren.Length; i++)
                {
                    if (MdiChildren[i].Name == NombreDelFrm.Substring(NombreDelFrm.IndexOf("Frm_"), NombreDelFrm.Length - NombreDelFrm.IndexOf("Frm_")))
                    {
                        XtraMessageBox.Show("El formulario solicitado ya se encuentra abierto");
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        private void abrir_formulario2(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(ToolStripMenuItem))
            {
                var ClickedItemText = ((ToolStripItem)sender).Name;

                XtraMessageBox.Show(ClickedItemText);

                switch (ClickedItemText)
                {
                    case "Exit":
                        Application.Exit();
                        break;
                }
            }
        }

        private void _RecuperarNcaja()
        {
            var xDoc = new XmlDocument();
            var xArchivo = @"c:\ErpBapSoftNet_Config\BapConfig.cfg";
            xDoc.Load(xArchivo);

            var configuration = xDoc.GetElementsByTagName("configuration");
            var lista = ((XmlElement)configuration[0]).GetElementsByTagName("Paramlocal");

            foreach (XmlElement nodo in lista)
            {
                var i = 0;
                var ncajanume = nodo.GetElementsByTagName("cajanume");
                var nperimes = nodo.GetElementsByTagName("perimes");
                _cajanume = ncajanume[i].InnerText;
                perimes = nperimes[i].InnerText;
            }
        }


        private void StatusBar()
        {
            lblUsuario.Text = VariablesPublicas.Nombr.Trim();
            lblCompany.Text = VariablesPublicas.EmpresaName.Trim();
            lblPeriodo.Text = perianio;
            lblalmacen.Text = moduloname;

            Text = ((TituloForm + moduloname + " - " + lblCompany.Text + "  »» LOCAL »»  " + localname.ToString()));
        }



        private void btnPedidoAlmacen_Click(object sender, EventArgs e)
        {
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_precios_Click(object sender, EventArgs e)
        {
            try
            {
                var modd = string.Empty;
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                var dt = new DataTable();

                BE.dominioid = VariablesPublicas.Dominioid;
                BE.moduloid = VariablesPublicas.Moduloid;
                dt = BL.GetAll(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();
                        var frmayuda = new Ayudas.Form_help_productoprecio();

                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = " << *** Ayudas *** >>";
                        frmayuda.sqlquery =
                                "SELECT tb1.productid " +
                                ", tb2.productname " +
                                ", tb1.stock " +
                                ", tb1.costopromed " +
                                ", tb1.valoractual as StockValor " +
                                ", tb1.costoultimo as CostoSoles " +
                                ", tb3.compra as Tcamb" +
                                ", cast(tb1.costoultimo/cast(tb3.compra as decimal(10,4)) as decimal (10,4))as CostoDolar " +
                                " FROM  tb_" + modd + "_local_stock as tb1 ";
                        frmayuda.sqlinner =
                            "INNER JOIN tb_" + modd + "_productos as tb2 ON tb1.productid = tb2.productid " +
                            "INNER JOIN tb_tipocambio as tb3 ON tb3.fecha = CONVERT(date, GETDATE(), 103) ";
                        frmayuda.sqlwhere =
                            "Where " +
                            "tb1.local = '" + VariablesPublicas.Local + "'" +
                            "and tb2.status= 0 ";
                        frmayuda.sqland = "and";
                        frmayuda.criteriosbusqueda = new string[] { "PRODUCTO", "CODIGO" };
                        frmayuda.columbusqueda = "tb2.productname,tb1.productid";
                        frmayuda.returndatos = "0,1";
                        frmayuda.Owner = this;
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btn_InforProd_Click(object sender, EventArgs e)
        {
        }

        private void btn_information_Click(object sender, EventArgs e)
        {
            var BL = new sys_formulariosBL();
            var BE = new tb_sys_formulario();
            var DataFunc = new DataTable();

            BE.dominioid = VariablesPublicas.Dominioid;
            BE.moduloid = VariablesPublicas.Moduloid;
            BE.formname = Name;
            DataFunc = BL.GetAll(VariablesPublicas.EmpresaID, BE).Tables[0];
        }
    }
}
