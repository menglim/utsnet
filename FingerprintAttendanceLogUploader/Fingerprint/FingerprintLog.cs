using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintAttendanceLogUploader.Fingerprint
{
    public class FingerprintLog
    {
        [JsonProperty("machineNumber")]
        public int MachineNumber { get; set; }

        [JsonProperty("enrollNumber")]
        public int EnrollNumber { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("month")]
        public int Month { get; set; }

        [JsonProperty("day")]
        public int Day { get; set; }

        [JsonProperty("hour")]
        public int Hour { get; set; }

        [JsonProperty("minute")]
        public int Minute { get; set; }

        [JsonProperty("second")]
        public int Second { get; set; }

        [JsonProperty("inOutMode")]
        public int InOutMode { get; set; }
    }
}
