using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPriceListingGenerator.Domains
{
    public class Product
    {
        [Components.MDataGridViewAttributes.DisplayName(Name ="")]
        [Components.MDataGridViewAttributes.Alignment(Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter)]
        public string ProductCode { get; set; }

        [Components.MDataGridViewAttributes.DisplayName(Name = "Product Name En")]
        [Components.MDataGridViewAttributes.Alignment(Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft)]
        public string ProductNameEn { get; set; }

        [Components.MDataGridViewAttributes.DisplayName(Name = "Product Name Kh")]
        [Components.MDataGridViewAttributes.Alignment(Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft)]
        public string ProductNameKh { get; set; }

        public string CategoryNameEn { get; set; }
        public string CategoryNameKh { get; set; }

        [Components.MDataGridViewAttributes.DisplayName(Name = "Unit Name")]
        [Components.MDataGridViewAttributes.Alignment(Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft)]
        public string UnitName { get; set; }

        [Components.MDataGridViewAttributes.DisplayName(Name = "Sale Price")]
        [Components.MDataGridViewAttributes.Alignment(Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight)]
        [Components.MDataGridViewAttributes.CurrencyFormat(Format = "#,##0.00")]
        public double SalePrice { get; set; }

        [Components.MDataGridViewAttributes.Hidden]
        public string UnitSalePrice
        {
            get
            {
                return "1" + UnitName + " = " + this.SalePrice.ToString("#,##0") + Properties.Settings.Default.CURRENCY_SYMBOL;
            }
        }

        [Components.MDataGridViewAttributes.Hidden]
        public string CategoryNameEnKh
        {
            get
            {
                return this.CategoryNameKh + " ( " + CategoryNameEn + " )";
            }
        }
    }
}
