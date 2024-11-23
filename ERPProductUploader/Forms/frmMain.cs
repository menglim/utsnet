using Components;
using Components.Extensions;
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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private int STATUS_TIME_OUT = 10;
        private int CHECK_LICENSE_TIMEOUT = 60 * 60;
        private int CHECK_LICENSE_COUNTER = 0;

        private List<string> formChilds;


        private void openForm(Form frm, object sender)
        {
            if (formChilds == null) formChilds = new List<string>();
            if (formChilds.Contains(frm.Name))
            {
                Application.OpenForms[frm.Name].BringToFront();
            }
            else
            {
                bool accessible = true;
                if (sender.GetType() == typeof(Components.MToolStriptMenuItem))
                {
                    Components.MToolStriptMenuItem mToolStriptMenuItem = (Components.MToolStriptMenuItem)sender;
                    if (mToolStriptMenuItem != null)
                    {
                        if (mToolStriptMenuItem.PermissionCode.NonNullOrEmpty())
                        {
                            int permissionCode = int.Parse(mToolStriptMenuItem.PermissionCode) + 1;
                            string permissionCodeString = permissionCode.ToString("000000");
                        }
                    }
                }
                if (accessible)
                {
                    tabControl1.TabPages.Add(frm);
                    //frm.MdiParent = this;
                    //frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    //frm.ControlBox = false;
                    //frm.MaximizeBox = false;
                    //frm.MinimizeBox = false;
                    //frm.ShowIcon = false;
                    //frm.Dock = DockStyle.Fill;
                    //frm.Show();
                    ////frm.WindowState = FormWindowState.Maximized;
                    if (formChilds == null) formChilds = new List<string>();
                    formChilds.Add(frm.Name);
                    frm.FormClosing += frm_FormClosing;
                    frm.FormClosed += Frm_FormClosed;
                }
            }
            //allAllFormToWindowMenu();
            //Helpers.Utilities.log.Info(frm.Name + " is opened");
            // showOrHidePanelDashboard();
            setTitleMainForm();
        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //showOrHidePanelDashboard();
        }

        private void allAllFormToWindowMenu()
        {
            if (formChilds != null)
            {
                wINDOWSToolStripMenuItem.DropDownItems.Clear();
                Form form = null;
                ToolStripMenuItem item = null;
                for (int i = 0; i < formChilds.Count; i++)
                {
                    form = Application.OpenForms[formChilds[i]];
                    item = new ToolStripMenuItem(form.Text);
                    item.Tag = formChilds[i];
                    if (form.ContainsFocus) item.Checked = true;
                    else item.Checked = false;
                    wINDOWSToolStripMenuItem.DropDownItems.Add(item);
                    item.Click += item_Click;
                }
            }
        }
        private void item_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickMenuItem = (ToolStripMenuItem)sender;
            string formName = clickMenuItem.Tag.ToString();
            if (formName != "")
            {
                Application.OpenForms[formName].BringToFront();
            }
            allAllFormToWindowMenu();
        }

        public void frmMain_Load(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();

            lbDate.Text = DateTime.Now.ToString();
            lbStatusVersion.Text = ProductVersion.ToString();
            labelLoginAs.Text = "Login as " + MainForm.Login.Username;
            lbDatabasePath.Text = "Using " + MainForm.Server.Name;
        }
        public void setMessage(string title, string message, bool IsSuccess)
        {
            lbStatus.Text = message;
            if (!IsSuccess)
            {
                AppUtils.Default.AlertMessage(title, message);
            }
        }

        private void frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (formChilds != null)
            {
                Form frm = (Form)sender;
                formChilds.Remove(frm.Name);
            }
            setTitleMainForm();
        }


        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void tbStatus_Tick(object sender, EventArgs e)
        {
            //if (this.Cursor != Cursors.Default)
            //{
            if (lbStatus.Text != "Ready")
            {
                if (STATUS_TIME_OUT == 0)
                {
                    STATUS_TIME_OUT = 10;
                    tbStatus.Stop();
                    lbStatus.Text = "Ready";
                }
                STATUS_TIME_OUT--;
            }
            //}
        }

        private void lbStatus_TextChanged(object sender, EventArgs e)
        {
            if (lbStatus.Text != "Ready")
            {
                tbStatus.Start();
            }
            else if (lbStatus.Text == "Ready")
            {
                tbStatus.Stop();
            }
        }

        public static void SetTitle(string title)
        {
            
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            setTitleMainForm();
        }

        private void setTitleMainForm()
        {
            if (formChilds != null)
            {
                if (formChilds.Count > 0)
                {
                    Form form = null;
                    for (int i = 0; i < formChilds.Count; i++)
                    {
                        form = Application.OpenForms[formChilds[i]];
                        if (form != null)
                        {
                            this.Text = MainForm.PRODUCT_TITLE + " - " + form.Text;
                        }
                        else
                        {
                            this.Text = MainForm.PRODUCT_TITLE;
                        }
                    }
                }
                else
                {
                    this.Text = MainForm.PRODUCT_TITLE;
                }
            }
            else
            {
                this.Text = MainForm.PRODUCT_TITLE;
            }
        }

        private void uploadProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new Forms.frmUploadProduct(), sender);
        }

        private void wINDOWSToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            allAllFormToWindowMenu();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new Forms.frmProduct(), sender);
        }
    }
}
