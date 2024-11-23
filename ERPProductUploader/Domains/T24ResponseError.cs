using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPClientTools.Domains
{
    public class T24ResponseError
    {
        [JsonProperty("errorDetails")]
        public List<T24ResponseErrorDetail> ErrorDetails { get; set; }
    }
}
