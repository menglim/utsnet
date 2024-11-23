using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPClientTools.Domains
{
    public class Product
    {
        [JsonProperty("productId")]
        public long ProductId { get; set; }

        [JsonProperty("productCode")]
        public string ProductCode { get; set; }

        [JsonProperty("productNameEn")]
        public string ProductNameEn { get; set; }

        [JsonProperty("productNameKh")]
        public string ProductNameKh { get; set; }

        [JsonProperty("categoryEntity")]
        [Components.MDataGridViewAttributes.Hidden]
        public Domains.Category Category { get; set; }

        [JsonIgnore]
        public string CategoryName
        {
            get
            {
                if (this.Category != null) return Category.CategoryName;
                return "";
            }
        }

        [JsonProperty("unitName")]
        public string UnitName { get; set; }

        //[JsonProperty("UnitPrice")]
        //public double UnitPrice { get; set; }

        //[JsonProperty("RetailsalePrice")]
        //public double RetailsalePrice { get; set; }
    }
}
