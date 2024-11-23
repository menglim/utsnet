using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintAttendanceLogUploader.Domains
{
    public class Response<T>
    {
        [JsonProperty("errorCode")]
        public int ErrorCode { get; set; }

        [JsonProperty("errorMessage")]
        public String ErrorMessage { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
