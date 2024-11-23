using Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPClientTools.Forms
{
    public partial class frmServer : BasedForm
    {
        private SortableBindingList<Domains.Server> servers;

        public delegate void CloseServerEventHandler(SortableBindingList<Domains.Server> servers);
        public event CloseServerEventHandler CloseServerEventHandler_Click;

        public frmServer(SortableBindingList<Domains.Server> servers)
        {
            InitializeComponent();
            this.servers = servers;
        }

        private void mButton1_Click(object sender, EventArgs e)
        {
            Forms.frmServerAddUpdate frm = new frmServerAddUpdate(null, ButtonAction.ADD);
            frm.AddUpdateServerEventHandlerClick += Frm_AddUpdateServerEventHandlerClick;
            frm.ShowDialog();
        }

        private void Frm_AddUpdateServerEventHandlerClick(Domains.Server obj, ButtonAction action, object sender, EventArgs e)
        {
            if (servers == null)
            {
                servers = new SortableBindingList<Domains.Server>();
            }
            if (action == ButtonAction.ADD)
            {
                servers.Add(obj);
            }
            else
            {
                Domains.Server selected = dgv.getSelectedObject<Domains.Server>();
                if (selected != null)
                {
                    selected.URL = obj.URL;
                    selected.APIKey = obj.APIKey;
                }
            }
            dgv.Bind(servers);
        }

        private void frmServer_Load(object sender, EventArgs e)
        {
            dgv.Bind(servers);
        }

        private void frmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseServerEventHandler_Click(servers);
        }

        private void mButton2_Click(object sender, EventArgs e)
        {
            Domains.Server server = this.dgv.getSelectedObject<Domains.Server>();
            if (server != null)
            {
                Forms.frmServerAddUpdate frm = new frmServerAddUpdate(server, ButtonAction.UPDATE);
                frm.AddUpdateServerEventHandlerClick += Frm_AddUpdateServerEventHandlerClick;
                frm.ShowDialog();
            }
        }

        private void mButton3_Click(object sender, EventArgs e)
        {
            Domains.Server server = this.dgv.getSelectedObject<Domains.Server>();
            if (server != null)
            {
                if (AppUtils.Default.showMessage(MainForm.PRODUCT_TITLE, "Do you want to delete " + server.Name + " ? ") == DialogResult.Yes)
                {
                    servers.Remove(server);
                    dgv.Bind(servers);
                }
            }

        }
    }
}
