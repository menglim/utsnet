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
    public partial class frmOption : Form
    {
        public frmOption()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.EXCEL_COLUMN_PRODUCT_NO = txtProductCode.Text;
            Properties.Settings.Default.EXCEL_COLUMN_PRODUCT_NAME_EN = txtProductNameEn.Text;
            Properties.Settings.Default.EXCEL_COLUMN_PRODUCT_NAME_KH = txtProductNameKh.Text;
            Properties.Settings.Default.EXCEL_COLUMN_PRODUCT_UNIT_NAME = txtUnitName.Text;
            Properties.Settings.Default.EXCEL_COLUMN_PRODUCT_SALE_PRICE = txtSalePrice.Text;
            Properties.Settings.Default.EXCEL_START = txtExcelStart.getInt();
            Properties.Settings.Default.EXCEL_END = txtExcelTo.getInt();
            Properties.Settings.Default.EXCEL_COLUMN_CATEGORY_EN = txtCategoryNameEn.Text;
            Properties.Settings.Default.EXCEL_COLUMN_CATEGORY_KH = txtCategoryNameKh.Text;
            Properties.Settings.Default.CURRENCY_SYMBOL = txtCurrencySymbol.Text;
            Properties.Settings.Default.Save();
            Components.AppUtils.Default.AlertMessage("Configuration is saved", true);
        }

        private void frmOption_Shown(object sender, EventArgs e)
        {
            txtProductCode.Text = Properties.Settings.Default.EXCEL_COLUMN_PRODUCT_NO;
            txtProductNameEn.Text = Properties.Settings.Default.EXCEL_COLUMN_PRODUCT_NAME_EN;
            txtProductNameKh.Text = Properties.Settings.Default.EXCEL_COLUMN_PRODUCT_NAME_KH;
            txtUnitName.Text = Properties.Settings.Default.EXCEL_COLUMN_PRODUCT_UNIT_NAME;
            txtSalePrice.Text = Properties.Settings.Default.EXCEL_COLUMN_PRODUCT_SALE_PRICE;
            txtExcelStart.Text = Properties.Settings.Default.EXCEL_START + "";
            txtExcelTo.Text = Properties.Settings.Default.EXCEL_END + "";
            txtCategoryNameEn.Text = Properties.Settings.Default.EXCEL_COLUMN_CATEGORY_EN;
            txtCategoryNameKh.Text = Properties.Settings.Default.EXCEL_COLUMN_CATEGORY_KH;
            txtCurrencySymbol.Text = Properties.Settings.Default.CURRENCY_SYMBOL;
        }

        private void frmOption_Load(object sender, EventArgs e)
        {

        }
    }
}
