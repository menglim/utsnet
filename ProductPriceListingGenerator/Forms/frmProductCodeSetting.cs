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
    public partial class frmProductCodeSetting : Components.BasedForm
    {
        private List<String> fonts = FontFamily.Families.Select(x => x.Name).OrderBy(y => y).ToList();
        public delegate void PreviewProductCodeSettingEventHandler(Domains.ProductCodeSetting productCodeSetting);
        public event PreviewProductCodeSettingEventHandler PreviewProductCodeSettingEventHandler_Click;
        private Domains.ProductCodeSetting productCodeSetting;

        public frmProductCodeSetting(Domains.ProductCodeSetting productCodeSetting)
        {
            InitializeComponent();
            this.productCodeSetting = productCodeSetting;
        }

        private void btnProductCodePickupColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtProductCodeColor.Text = Components.AppUtils.Default.HexConverter(colorDialog.Color);
            }
        }

        private void frmProductCodeSetting_Shown(object sender, EventArgs e)
        {

            txtProductCodeButtom.Text = productCodeSetting.Buttom + "";
            txtProductCodeH.Text = productCodeSetting.Height + "";
            txtProductCodeRight.Text = productCodeSetting.Right + "";
            txtProductCodeW.Text = productCodeSetting.Width + "";
            txtProductCodeX.Text = productCodeSetting.X + "";
            txtProductCodeY.Text = productCodeSetting.Y + "";
            cboProductCodeFont.SelectedItem = productCodeSetting.FontName;
            cbProductCodeBold.Checked = productCodeSetting.FontBold;
            txtProductCodeColor.Text = productCodeSetting.HexColor;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (this.DoValidation() && cboProductCodeFont.SelectedItem != null)
            {
                productCodeSetting = new Domains.ProductCodeSetting
                {
                    FontName = cboProductCodeFont.SelectedItem.ToString(),
                    Buttom = txtProductCodeButtom.getInt(),
                    FontBold = cbProductCodeBold.Checked,
                    Height = txtProductCodeH.getInt(),
                    Width = txtProductCodeW.getInt(),
                    X = txtProductCodeX.getInt(),
                    Y = txtProductCodeY.getInt(),
                    Right = txtProductCodeRight.getInt(),
                    HexColor = txtProductCodeColor.Text,
                };
                PreviewProductCodeSettingEventHandler_Click(productCodeSetting);
            }
        }

        private void frmProductCodeSetting_Load(object sender, EventArgs e)
        {
            cboProductCodeFont.BindingDataSource(new List<string>(fonts), "", "");
        }

        private void btnApplyChangeAndClose_Click(object sender, EventArgs e)
        {
            btnPreview_Click(sender, e);
            this.Close();
        }
    }
}
