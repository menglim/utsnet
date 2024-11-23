using Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FingerprintAttendanceLogUploader
{
    static class Program
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            new BasedForm();
            BasedForm.AppConfig.GetParameterValue(CoreConstants.ParameterName.API_KEY.ToString(), "API_KEY_VALUE");
            String fingerprintUrl = BasedForm.AppConfig.GetParameterValue(CoreConstants.ParameterName.URL_FINGERPRINT_LISTING.ToString(), "http://localhost:8080/api/client/hr/fingerprint");
            String uploadAttendanceLogUrl = BasedForm.AppConfig.GetParameterValue(CoreConstants.ParameterName.URL_ATTENDACE_LOG_UPLOAD.ToString(), "http://localhost:8080/api/client/hr/upload-attendace-log");
            String botToken = BasedForm.AppConfig.GetParameterValue(CoreConstants.ParameterName.TELEGRAM_BOT_TOKEN.ToString(), "1861899491:AAEJpKATS899EbylCPnobVnA22RpAkN6f7k");
            String chatId = BasedForm.AppConfig.GetParameterValue(CoreConstants.ParameterName.TELEGRAM_BOT_CHAT_ID.ToString(), "-476311175");

            string json = Components.Utilities.RestAPIUtilities.Default.Get(fingerprintUrl);
            Domains.Response<List<Domains.FingerprintDevice>> response = Components.Utilities.JsonUtilities.Default.FromStringToObject<Domains.Response<List<Domains.FingerprintDevice>>>(json);
            if (response != null)
            {
                if (response.ErrorCode == 0)
                {
                    Components.Log.Debug("Found " + response.Data.Count + " devices");
                    response.Data.ForEach(x =>
                    {
                        //Thread myNewThread = new Thread(() => MyMethod("param1",5));
                        Thread thread = new Thread(() => process(x.MachineNo, x.IPAddress, x.Port, uploadAttendanceLogUrl, botToken, chatId));
                        thread.Start();
                    });
                }
                else
                {
                    Components.Log.Error(response.ErrorMessage);
                }
            }
            else
            {
                Components.Log.Error("No response from server. Make sure your server is alive");
            }
        }

        static void process(int machineNumber, string ipAddress, int port, string url, string telegramBotToken, string telegramChatId)
        {
            try
            {
                Fingerprint.FingerprintDeviceUtils fingerprint = new Fingerprint.FingerprintDeviceUtils(machineNumber, ipAddress, port);
                Components.Log.Debug("Trying connect " + ipAddress + " with port " + port);
                bool connected = fingerprint.ConnectNet();
                if (connected)
                {
                    Components.Log.Debug("Connected");
                    DateTime machineDateTime = fingerprint.GetDateTime();
                    Components.Log.Debug("Machine Date => " + machineDateTime.ToString());

                    List<Fingerprint.FingerprintUserInfo> fingerprintUsers = fingerprint.GetAllUserInfo();
                    Components.Log.Debug("UserInfo found => " + fingerprintUsers.Count);

                    List<Fingerprint.FingerprintLog> fingerprintLogs = fingerprint.GetLogData();
                    Components.Log.Debug("Attendance Log found => " + fingerprintLogs.Count);

                    fingerprint.Disconnect();
                    Components.Log.Debug("Disconnected");

                    Domains.UploadAttendaceLog upload = new Domains.UploadAttendaceLog
                    {
                        MachineDateTime = machineDateTime,
                        FingerprintUsers = fingerprintUsers,
                        FingerprintLogs = fingerprintLogs
                    };
                    string json = Components.Utilities.JsonUtilities.Default.FromObjectToJsonString<Domains.UploadAttendaceLog>(upload);
                    string responseBody = Components.Utilities.RestAPIUtilities.Default.Post(url, json);
                    Components.Log.Debug("Response Body => " + responseBody);
                    Components.Utilities.TelegramUtilities.Default.sendText(telegramBotToken, telegramChatId, "Upload " + upload.FingerprintLogs.Count + " successfully at " + DateTime.Now.ToString());
                }
                else
                {
                    Components.Log.Debug("Connect Failed");
                }
            }
            catch (Exception ex)
            {
                Components.Log.Debug(ex.Message);
            }

        }
    }
}
