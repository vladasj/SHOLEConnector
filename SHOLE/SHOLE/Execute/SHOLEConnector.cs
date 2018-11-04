using System;
using System.ComponentModel;
using Sh4Ole;

namespace SHOLE.Execute
{

    public static class SHOLEHelper
    {
        public static int ConvertDate(this DateTime date)
        {
            var convertedValue = (int)(date - new DateTime(1899, 12, 30)).TotalDays;
            return convertedValue;
        }
    }

    public class SHOLEConnector
    {
        public static SHOLEConnector CurrentConnector = new SHOLEConnector();

        internal readonly SH4App ShConnector = new SH4App();
        private bool Connected => ShConnector.DBConnected() > 0;
        public string Server { get; set; }
        public uint Port { get; set; } = 9700;
        public uint Timeout { get; set; } = 50000;
        public string Login { get; set; }
        public string Password { get; set; }

        public void Init(string server, uint port, string login, string password, uint timeout = 50000)
        {
            Server = server;
            Port = port;
            Login = login;
            Password = password;
            Timeout = timeout;
        }

        public bool Connect()
        {
            ShConnector.SetServerName($"{Server}:pTa{Port}t{Timeout}");
            ShConnector.DBLoginEx(Login, Password);
            return Connected;
        }

        public string LastError()
        {
            return ShConnector.GetExcMessage();
        }

        public void Disconnect()
        {
            ShConnector.DBLogout();
        }

        ~SHOLEConnector() {
            if (Connected) Disconnect();
        }
    }
}
