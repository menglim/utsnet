using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintAttendanceLogUploader.Fingerprint
{
    public class FingerprintDeviceUtils
    {
        private ZkemClient zkemClient;
        private int machineNumber;
        private string ipAddress;
        private int port;

        public FingerprintDeviceUtils(int machineNumber, string ipAddress, int port)
        {
            this.machineNumber = machineNumber;
            this.ipAddress = ipAddress;
            this.port = port;
        }

        public bool ConnectNet()
        {
            zkemClient = new ZkemClient();
            return zkemClient.Connect_Net(ipAddress, port);
        }

        public void Disconnect()
        {
            if (zkemClient != null)
            {
                zkemClient.Disconnect();
            }
        }

        public DateTime GetDateTime()
        {
            int dwYear = 0;
            int dwMonth = 0;
            int dwDay = 0;
            int dwHour = 0;
            int dwMinute = 0;
            int dwSecond = 0;

            bool result = zkemClient.GetDeviceTime(machineNumber, ref dwYear, ref dwMonth, ref dwDay, ref dwHour, ref dwMinute, ref dwSecond);
            if (result)
            {
                return new DateTime(dwYear, dwMonth, dwDay, dwHour, dwMinute, dwSecond);
            }
            else
            {
                return new DateTime(1917, 1, 1, 1, 1, 1);
            }
        }

        public List<FingerprintUserInfo> GetAllUserInfo()
        {
            string sdwEnrollNumber = string.Empty, sName = string.Empty, sPassword = string.Empty, sTmpData = string.Empty;
            int iPrivilege = 0, iTmpLength = 0, iFlag = 0, idwFingerIndex;
            bool bEnabled = false;

            List<FingerprintUserInfo> lstFPTemplates = new List<FingerprintUserInfo>();

            zkemClient.ReadAllUserID(machineNumber);
            zkemClient.ReadAllTemplate(machineNumber);

            while (zkemClient.SSR_GetAllUserInfo(machineNumber, out sdwEnrollNumber, out sName, out sPassword, out iPrivilege, out bEnabled))
            {
                for (idwFingerIndex = 0; idwFingerIndex < 10; idwFingerIndex++)
                {
                    if (zkemClient.GetUserTmpExStr(machineNumber, sdwEnrollNumber, idwFingerIndex, out iFlag, out sTmpData, out iTmpLength))
                    {
                        FingerprintUserInfo fpInfo = new FingerprintUserInfo();
                        fpInfo.MachineNumber = machineNumber;
                        fpInfo.EnrollNumber = sdwEnrollNumber;
                        fpInfo.Name = sName;
                        fpInfo.FingerIndex = idwFingerIndex;
                        fpInfo.TmpData = sTmpData;
                        fpInfo.Privelage = iPrivilege;
                        fpInfo.Password = sPassword;
                        fpInfo.Enabled = bEnabled;
                        fpInfo.iFlag = iFlag.ToString();

                        lstFPTemplates.Add(fpInfo);
                    }
                }

            }
            return lstFPTemplates;
        }

        public List<FingerprintLog> GetLogData()
        {
            string dwEnrollNumber1 = "";
            int dwVerifyMode = 0;
            int dwInOutMode = 0;
            int dwYear = 0;
            int dwMonth = 0;
            int dwDay = 0;
            int dwHour = 0;
            int dwMinute = 0;
            int dwSecond = 0;
            int dwWorkCode = 0;

            List<FingerprintLog> lstEnrollData = new List<FingerprintLog>();

            zkemClient.ReadAllGLogData(machineNumber);

            while (zkemClient.SSR_GetGeneralLogData(machineNumber, out dwEnrollNumber1, out dwVerifyMode, out dwInOutMode, out dwYear, out dwMonth, out dwDay, out dwHour, out dwMinute, out dwSecond, ref dwWorkCode))

            {
                FingerprintLog objInfo = new FingerprintLog();
                objInfo.MachineNumber = machineNumber;
                objInfo.EnrollNumber = int.Parse(dwEnrollNumber1);
                objInfo.Year = dwYear;
                objInfo.Month = dwMonth;
                objInfo.Day = dwDay;
                objInfo.Hour = dwHour;
                objInfo.Minute = dwMinute;
                objInfo.Second = dwSecond;
                objInfo.InOutMode = dwInOutMode;

                lstEnrollData.Add(objInfo);
            }

            return lstEnrollData;
        }
    }
}
