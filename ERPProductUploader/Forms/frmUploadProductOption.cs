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
    public partial class frmUploadProductOption : BasedForm
    {
        public frmUploadProductOption()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AppConfig.SaveParameter(KEYS.KEY_EXCEL_COLUMN_PRODUCT_CODE, txtProductCode.Text);
            AppConfig.SaveParameter(KEYS.KEY_EXCEL_COLUMN_PRODUCT_NAME_EN, txtProductNameEn.Text);
            AppConfig.SaveParameter(KEYS.KEY_EXCEL_COLUMN_PRODUCT_NAME_KH, txtProductNameKh.Text);
            AppConfig.SaveParameter(KEYS.KEY_EXCEL_COLUMN_PRODUCT_CATEGORY_EN, txtCategoryNameEn.Text);
            AppConfig.SaveParameter(KEYS.KEY_EXCEL_COLUMN_PRODUCT_CATEGORY_KH, txtCategoryNameKh.Text);
            AppConfig.SaveParameter(KEYS.KEY_EXCEL_COLUMN_PRODUCT_UNIT_EN, txtUnitNameEn.Text);
            AppConfig.SaveParameter(KEYS.KEY_EXCEL_COLUMN_PRODUCT_UNIT_KH, txtUnitNameKh.Text);
            AppConfig.SaveParameter(KEYS.KEY_EXCEL_COLUMN_PRODUCT_UNIT_PRICE, txtUnitPrice.Text);
            AppConfig.SaveParameter(KEYS.KEY_EXCEL_COLUMN_PRODUCT_RETAILSALE_PRICE, txtSalePrice.Text);
            AppConfig.SaveParameter(KEYS.KEY_EXCEL_START, txtExcelStart.getInt() + "");
            AppConfig.SaveParameter(KEYS.KEY_EXCEL_END, txtExcelTo.getInt() + "");
            Components.AppUtils.Default.AlertMessage("Configuration is saved", true);
        }

        private void frmOption_Shown(object sender, EventArgs e)
        {
            txtProductCode.Text = AppConfig.GetParameterValue(KEYS.KEY_EXCEL_COLUMN_PRODUCT_CODE, "B");
            txtProductNameEn.Text = AppConfig.GetParameterValue(KEYS.KEY_EXCEL_COLUMN_PRODUCT_NAME_EN, "C");
            txtProductNameKh.Text = AppConfig.GetParameterValue(KEYS.KEY_EXCEL_COLUMN_PRODUCT_NAME_KH, "D");
            txtUnitNameKh.Text = AppConfig.GetParameterValue(KEYS.KEY_EXCEL_COLUMN_PRODUCT_UNIT_KH, "F");
            txtUnitNameEn.Text = AppConfig.GetParameterValue(KEYS.KEY_EXCEL_COLUMN_PRODUCT_UNIT_EN, "F");
            txtUnitPrice.Text = AppConfig.GetParameterValue(KEYS.KEY_EXCEL_COLUMN_PRODUCT_UNIT_PRICE, "G");
            txtSalePrice.Text = AppConfig.GetParameterValue(KEYS.KEY_EXCEL_COLUMN_PRODUCT_RETAILSALE_PRICE, "H");
            txtExcelStart.Text = AppConfig.GetParameterValue(KEYS.KEY_EXCEL_START, "2");
            txtExcelTo.Text = AppConfig.GetParameterValue(KEYS.KEY_EXCEL_END, "100");
            txtCategoryNameKh.Text = AppConfig.GetParameterValue(KEYS.KEY_EXCEL_COLUMN_PRODUCT_CATEGORY_KH, "E");
            txtCategoryNameEn.Text = AppConfig.GetParameterValue(KEYS.KEY_EXCEL_COLUMN_PRODUCT_CATEGORY_EN, "E");
        }

        private void frmOption_Load(object sender, EventArgs e)
        {

        }
    }
}
