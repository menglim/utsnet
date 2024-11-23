using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintAttendanceLogUploader.Fingerprint
{
    public class FingerprintUserInfo
    {
        [JsonProperty("machineNumber")]
        public int MachineNumber { get; set; }

        [JsonProperty("enrollNumber")]
        public string EnrollNumber { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("fingerIndex")]
        public int FingerIndex { get; set; }
        public string TmpData { get; set; }
        public int Privelage { get; set; }
        public string Password { get; set; }
        public bool Enabled { get; set; }
        public string iFlag { get; set; }
    }
}
