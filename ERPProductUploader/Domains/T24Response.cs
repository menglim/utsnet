using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPClientTools.Domains
{
  public  class T24Response
    {
        [JsonProperty("header")]
        public T24ResponseHeader  Header { get; set; }

        [JsonProperty("error")]
        public T24ResponseError Error { get; set; }
    }
}
