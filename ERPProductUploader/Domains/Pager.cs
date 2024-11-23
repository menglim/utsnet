using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPClientTools.Domains
{
    public class Pager<T>
    {
        [JsonProperty("startPage")]
        public int StartPage { get; set; }

        [JsonProperty("endPage")]
        public int EndPage { get; set; }

        [JsonProperty("currentPageSize")]
        public int CurrentPageSize { get; set; }

        [JsonProperty("data")]
        public Page<T> Page { get; set; }
    }
}
