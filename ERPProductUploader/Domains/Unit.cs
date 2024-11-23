using Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPClientTools.Domains
{
    public class Unit
    {
        [JsonProperty("unitId")]
        public long UnitId { get; set; }

        [JsonProperty("unitNameEn")]
        public string UnitNameEn { get; set; }

        [JsonProperty("unitNameKh")]
        public string UnitNameKh { get; set; }

        public string UnitName
        {
            get
            {
                return AppUtils.Default.Concat(this.UnitNameKh, this.UnitNameEn);
            }
        }
    }
}
