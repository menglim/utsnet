using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintAttendanceLogUploader.Domains
{
    public class FingerprintDevice
    {
        [JsonProperty("machineNo")]
        public int MachineNo { get; set; }

        [JsonProperty("ipAddress")]
        public string IPAddress { get; set; }

        [JsonProperty("port")]
        public int Port { get; set; }
    }
}
