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
    public partial class frmProductNameEnSetting : Components.BasedForm
    {
        private List<String> fonts = FontFamily.Families.Select(x => x.Name).OrderBy(y => y).ToList();
        public delegate void PreviewProductNameEnSettingEventHandler(Domains.ProductNameSetting productNameEnSetting);
        public event PreviewProductNameEnSettingEventHandler PreviewProductNameEnSettingEventHandler_Click;
        private Domains.ProductNameSetting productNameEnSetting;

        public frmProductNameEnSetting(Domains.ProductNameSetting productNameEnSetting)
        {
            InitializeComponent();
            this.productNameEnSetting = productNameEnSetting;
        }

        private void btnProductCodePickupColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtProductNameEnColor.Text = Components.AppUtils.Default.HexConverter(colorDialog.Color);
            }
        }

        private void frmProductCodeSetting_Shown(object sender, EventArgs e)
        {
            txtProductNameEnButtom.Text = productNameEnSetting.Buttom + "";
            txtProductNameEnH.Text = productNameEnSetting.Height + "";
            txtProductNameEnRight.Text = productNameEnSetting.Right + "";
            txtProductNameEnW.Text = productNameEnSetting.Width + "";
            txtProductNameEnX.Text = productNameEnSetting.X + "";
            txtProductNameEnY.Text = productNameEnSetting.Y + "";
            cboProductNameEnFont.SelectedItem = productNameEnSetting.FontName;
            cbProductNameEnBold.Checked = productNameEnSetting.FontBold;
            txtProductNameEnColor.Text = productNameEnSetting.HexColor;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (this.DoValidation() && cboProductNameEnFont.SelectedItem != null)
            {
                productNameEnSetting = new Domains.ProductNameSetting
                {
                    Buttom = txtProductNameEnButtom.getInt(),
                    HexColor = txtProductNameEnColor.Text,
                    FontBold = cbProductNameEnBold.Checked,
                    FontName = cboProductNameEnFont.SelectedItem.ToString(),
                    Height = txtProductNameEnH.getInt(),
                    Right = txtProductNameEnRight.getInt(),
                    Width = txtProductNameEnW.getInt(),
                    X = txtProductNameEnX.getInt(),
                    Y = txtProductNameEnY.getInt()
                };
                PreviewProductNameEnSettingEventHandler_Click(productNameEnSetting);
            }
        }

        private void frmProductNameEnSetting_Load(object sender, EventArgs e)
        {
            cboProductNameEnFont.BindingDataSource(new List<string>(fonts), "", "");
        }

        private void mButton2_Click(object sender, EventArgs e)
        {
            btnPreview_Click(sender, e);
            this.Close();
        }
    }
}
