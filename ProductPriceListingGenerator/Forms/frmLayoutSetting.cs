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

namespace ProductPriceListingGenerator.Forms
{
    public partial class frmLayoutSetting : Components.BasedForm
    {
        public delegate void PreviewLayoutSettingEventHandler(Domains.LayoutSetting layoutSetting);
        public event PreviewLayoutSettingEventHandler PreviewLayoutSettingEventHandler_Click;

        private Domains.LayoutSetting layoutSetting;
        public frmLayoutSetting(Domains.LayoutSetting layoutSetting)
        {
            InitializeComponent();
            this.layoutSetting = layoutSetting;
        }

        private void frmLayoutSetting_Shown(object sender, EventArgs e)
        {
            txtBackground.Text = layoutSetting.Background;
            txtProductCover.Text = layoutSetting.ProductCover;
            txtProductCoverX.Text = layoutSetting.X + "";
            txtProductCoverY.Text = layoutSetting.Y + "";
            txtProductCoverRight.Text = layoutSetting.Right + "";
            txtProductCoverButtom.Text = layoutSetting.Buttom + "";
            txtLayoutColumn.Text = layoutSetting.Column + "";
            txtLayoutRow.Text = layoutSetting.Row + "";
        }

        private void frmLayoutSetting_Load(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (this.DoValidation())
            {
                layoutSetting.Background = txtBackground.Text;
                layoutSetting.ProductCover = txtProductCover.Text;
                layoutSetting.X = txtProductCoverX.getInt();
                layoutSetting.Y = txtProductCoverY.getInt();
                layoutSetting.Right = txtProductCoverRight.getInt();
                layoutSetting.Buttom = txtProductCoverButtom.getInt();
                layoutSetting.Column = txtLayoutColumn.getInt();
                layoutSetting.Row = txtLayoutRow.getInt();

                PreviewLayoutSettingEventHandler_Click(layoutSetting);
            }
        }

        private void btnChooseBackground_Click(object sender, EventArgs e)
        {
            string filename = Components.AppUtils.Default.openFileDialog("Choose Background", "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png");
            if (filename.NonNullOrEmpty())
            {
                if (System.IO.File.Exists(filename))
                {
                    txtBackground.Text = filename;
                }
            }
        }

        private void mButton2_Click(object sender, EventArgs e)
        {
            string filename = Components.AppUtils.Default.openFileDialog("Choose Product Cover", "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png");
            if (filename.NonNullOrEmpty())
            {
                txtProductCover.Text = filename;
            }
        }

        private void mButton1_Click(object sender, EventArgs e)
        {
            btnPreview_Click(sender, e);
            this.Close();
        }
    }
}
