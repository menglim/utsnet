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
    public partial class frmServerAddUpdate : BasedForm
    {
        private Domains.Server selectedServer;
        public delegate void AddUpdateServerEventHandler(Domains.Server obj, ButtonAction action, object sender, EventArgs e);
        public event AddUpdateServerEventHandler AddUpdateServerEventHandlerClick;
        private ButtonAction mAction;

        public frmServerAddUpdate(Domains.Server obj, ButtonAction action)
        {
            InitializeComponent();
            selectedServer = obj;
            mAction = action;
        }

        private void mButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void addorUpdateForm()
        {
            btnSave.ButtonAction = mAction;
            if (mAction == ButtonAction.ADD)
            {
                this.ClearControls();
                this.Text = "Add New Server";

            }
            else if (mAction == ButtonAction.UPDATE)
            {
                if (selectedServer != null)
                {
                    txtUrl.Text = selectedServer.URL;
                    txtApiKey.Text = selectedServer.APIKey;
                    txtName.Text = selectedServer.Name;
                    this.Text = "Update Server";
                }
            }
        }
        private void frmEmployeeAddUpdate_Load(object sender, EventArgs e)
        {
            addorUpdateForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.DoValidation())
            {
                if (mAction == ButtonAction.ADD)
                {
                    selectedServer = new Domains.Server { URL = txtUrl.Text, APIKey = txtApiKey.Text, Name = txtName.Text };
                    AddUpdateServerEventHandlerClick(selectedServer, ButtonAction.ADD, sender, e);
                }
                else
                {
                    selectedServer.URL = txtUrl.Text;
                    selectedServer.APIKey = txtApiKey.Text;
                    selectedServer.Name = txtName.Text;
                    AddUpdateServerEventHandlerClick(selectedServer, ButtonAction.UPDATE, sender, e);
                }
                this.Close();
            }
        }
    }
}
