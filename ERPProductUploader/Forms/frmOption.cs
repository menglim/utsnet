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
    public partial class frmOption : Form
    {
        public frmOption()
        {
            InitializeComponent();
        }

        private void frmOption_Load(object sender, EventArgs e)
        {
            txtWebServiceURL.Text = Properties.Settings.Default.T24_WEBSERVICE_URL;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtWebServiceURL.DoValidation())
            {
                Properties.Settings.Default.T24_WEBSERVICE_URL = txtWebServiceURL.Text;
                Properties.Settings.Default.Save();
                MainForm.setMessage("Configuration is saved", true);
            }
        }
    }
}
