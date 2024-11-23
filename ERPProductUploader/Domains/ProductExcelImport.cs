using Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPClientTools.Domains
{
    public class ProductExcelImport
    {
        public long ProductId { get; set; }

        public string ProductCode { get; set; }

        [Components.MDataGridViewAttributes.Hidden]
        public string ProductNameEn { get; set; }

        [Components.MDataGridViewAttributes.Hidden]
        public string ProductNameKh { get; set; }

        public string ProductName
        {
            get
            {
                return AppUtils.Default.ConcatWithSeparator("-", this.ProductNameKh, this.ProductNameEn);
            }
        }

        public long? CategoryId { get; set; }

        [Components.MDataGridViewAttributes.Hidden]
        public string CategoryNameEn { get; set; }

        [Components.MDataGridViewAttributes.Hidden]
        public string CategoryNameKh { get; set; }

        public string CategoryName
        {
            get
            {
                return AppUtils.Default.ConcatWithSeparator("-", this.CategoryNameKh, this.CategoryNameEn);
            }
        }

        public long? UnitId { get; set; }

        [Components.MDataGridViewAttributes.Hidden]
        public string UnitNameEn { get; set; }

        [Components.MDataGridViewAttributes.Hidden]
        public string UnitNameKh { get; set; }

        public string UnitName
        {
            get
            {
                return AppUtils.Default.ConcatWithSeparator("-", this.UnitNameKh, this.UnitNameEn);
            }
        }

        [Components.MDataGridViewAttributes.CurrencyFormat(Format = "#,##0.00")]
        [Components.MDataGridViewAttributes.Alignment(Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight)]
        public double UnitPrice { get; set; }

        [Components.MDataGridViewAttributes.CurrencyFormat(Format = "#,##0.00")]
        [Components.MDataGridViewAttributes.Alignment(Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight)]
        public double RetailsalePrice { get; set; }
    }
}
