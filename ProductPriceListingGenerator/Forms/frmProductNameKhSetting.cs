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
    public partial class frmProductNameKhSetting : Components.BasedForm
    {
        private List<String> fonts = FontFamily.Families.Select(x => x.Name).OrderBy(y => y).ToList();
        public delegate void PreviewProductNameKhSettingEventHandler(Domains.ProductNameSetting productNameKhSetting);
        public event PreviewProductNameKhSettingEventHandler PreviewProductNameKhSettingEventHandler_Click;
        private Domains.ProductNameSetting productNameKhSetting;

        public frmProductNameKhSetting(Domains.ProductNameSetting productNameKhSetting)
        {
            InitializeComponent();
            this.productNameKhSetting = productNameKhSetting;
        }

        private void btnProductCodePickupColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtProductNameKhColor.Text = Components.AppUtils.Default.HexConverter(colorDialog.Color);
            }
        }

        private void frmProductCodeSetting_Shown(object sender, EventArgs e)
        {
            txtProductNameKhButtom.Text = productNameKhSetting.Buttom + "";
            txtProductNameKhH.Text = productNameKhSetting.Height + "";
            txtProductNameKhRight.Text = productNameKhSetting.Right + "";
            txtProductNameKhW.Text = productNameKhSetting.Width + "";
            txtProductNameKhX.Text = productNameKhSetting.X + "";
            txtProductNameKhY.Text = productNameKhSetting.Y + "";
            cboProductNameKhFont.SelectedItem = productNameKhSetting.FontName;
            cbProductNameKhBold.Checked = productNameKhSetting.FontBold;
            txtProductNameKhColor.Text = productNameKhSetting.HexColor;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (this.DoValidation() && cboProductNameKhFont.SelectedItem != null)
            {
                productNameKhSetting = new Domains.ProductNameSetting
                {
                    Buttom = txtProductNameKhButtom.getInt(),
                    HexColor = txtProductNameKhColor.Text,
                    FontBold = cbProductNameKhBold.Checked,
                    FontName = cboProductNameKhFont.SelectedItem.ToString(),
                    Height = txtProductNameKhH.getInt(),
                    Right = txtProductNameKhRight.getInt(),
                    Width = txtProductNameKhW.getInt(),
                    X = txtProductNameKhX.getInt(),
                    Y = txtProductNameKhY.getInt()
                };
                PreviewProductNameKhSettingEventHandler_Click(productNameKhSetting);
            }
        }

        private void frmProductNameEnSetting_Load(object sender, EventArgs e)
        {
            cboProductNameKhFont.BindingDataSource(new List<string>(fonts), "", "");
        }

        private void mButton2_Click(object sender, EventArgs e)
        {
            btnPreview_Click(sender, e);
            this.Close();
        }
    }
}
