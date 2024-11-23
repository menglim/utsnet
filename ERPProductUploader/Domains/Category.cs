using Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPClientTools.Domains
{
    public class Category
    {
        [JsonProperty("categoryId")]
        public long CategoryId { get; set; }

        [JsonProperty("categoryNameEn")]
        public string CategoryNameEn { get; set; }

        [JsonProperty("categoryNameKh")]
        public string CategoryNameKh { get; set; }

        public string CategoryName
        {
            get
            {
                return AppUtils.Default.Concat(this.CategoryNameKh, this.CategoryNameEn);
            }
        }
    }
}
