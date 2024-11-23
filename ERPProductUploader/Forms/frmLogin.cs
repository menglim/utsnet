using AutoUpdaterDotNET;
using Components;
using Components.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPClientTools.Forms
{
    public partial class frmLogin : BasedForm
    {

        private SortableBindingList<Domains.Server> list = new SortableBindingList<Domains.Server>();
        public frmLogin()
        {
            InitializeComponent();
            if (!this.DesignMode)
            {

            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.Text = "Login to " + MainForm.PRODUCT_TITLE;
            lbVersion.Text = "Version " + MainForm.Version;
            reloadServer();
            AutoUpdater.ApplicationExitEvent += AutoUpdater_ApplicationExitEvent;

            AutoUpdater.Mandatory = true;
            AutoUpdater.RunUpdateAsAdmin = true;
            //AutoUpdater.Start("https://serenitynailflorence.com/test/ERPClientTools.xml");
        }

        private void AutoUpdater_ApplicationExitEvent()
        {
            Text = @"Closing application...";
            Thread.Sleep(5000);
            Application.Exit();
        }

        private void reloadServer()
        {
            string jsonServer = AppConfig.GetParameterValue(KEYS.KEY_SERVER);
            list = AppUtils.Default.FromStringToObject<SortableBindingList<Domains.Server>>(jsonServer);
            if (list != null)
                cboCategory.BindingDataSource<Domains.Server>(new List<Domains.Server>(list.ToList()), "Name", "Name");
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.DoValidation())
            {
                MainForm.Server = cboCategory.SelectedItem as Domains.Server;
                Domains.Response<Domains.Login> response = DataService.Default.Login(txtUsername.Text, txtPassword.Text);

                if (response != null && response.ErrorCode == 0)
                {
                    lbMessage.Text = "";
                    MainForm.Login = response.Data;

                    Forms.frmMain frm = Application.OpenForms["frmMain"] as Forms.frmMain;
                    if (frm == null)
                    {
                        frm = new frmMain();
                    }
                    else
                    {
                        frm.frmMain_Load(null, null);
                    }
                    frm.Show();
                    this.PerformSafely(() => this.Hide());
                }
                else
                {
                    lbMessage.Text = (response != null ? response.ErrorMessage : "No response from Server");
                    //Helpers.Utilities.log.Error("Username/Password is not correct with username " + txtUsername.Text + " or may disabled by admin");
                    MainForm.setMessage(lbMessage.Text, true);
                }
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            Forms.frmServer frm = new frmServer(list);
            frm.CloseServerEventHandler_Click += Frm_CloseServerEventHandler_Click;
            frm.ShowDialog();
        }

        private void Frm_CloseServerEventHandler_Click(SortableBindingList<Domains.Server> servers)
        {
            this.list = servers;
            string json = AppUtils.Default.FromObjectToJsonString<SortableBindingList<Domains.Server>>(list);
            AppConfig.SaveParameter(KEYS.KEY_SERVER, json);
            reloadServer();
        }
    }
}
