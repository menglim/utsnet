using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintAttendanceLogUploader
{
    public class CoreConstants
    {
        public const string acx_Disconnect = "Disconnected";
        public const string acx_Connect = "Conncected";

        public enum ParameterName
        {
            API_KEY,
            URL_FINGERPRINT_LISTING,
            URL_ATTENDACE_LOG_UPLOAD,
            TELEGRAM_BOT_TOKEN,
            TELEGRAM_BOT_CHAT_ID
        }
    }
}
