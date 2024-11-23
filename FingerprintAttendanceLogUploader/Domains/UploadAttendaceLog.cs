using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintAttendanceLogUploader.Domains
{
    public class UploadAttendaceLog
    {
        [JsonProperty("machineDateTime")]
        public DateTime MachineDateTime { get; set; }

        [JsonProperty("fingerprintLogs")]
        public List<Fingerprint.FingerprintLog> FingerprintLogs { get; set; }

        [JsonProperty("fingerprintUsers")]
        public List<Fingerprint.FingerprintUserInfo> FingerprintUsers { get; set; }
    }
}
