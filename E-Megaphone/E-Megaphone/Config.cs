using System.Configuration;

namespace E_Megaphone
{
    public static class Config
    {
        public static string Sender
        {
            get { return ConfigurationManager.AppSettings.Get("Sender"); }
        }

        public static string Username
        {
            get { return ConfigurationManager.AppSettings.Get("Username"); }
        }

        public static string Password
        {
            get { return ConfigurationManager.AppSettings.Get("Password"); }
        }

        public static string SubType
        {
            get { return ConfigurationManager.AppSettings.Get("SubType"); }
        }

        public static string Host
        {
            get { return ConfigurationManager.AppSettings.Get("Host"); }
        }

        public static int Port
        {
            get { return int.Parse(ConfigurationManager.AppSettings.Get("Port")); }
        }
    }
}