using System.Configuration;

namespace E_Megaphone
{
    /// <summary>
    /// Project configuration values
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// Log file output
        /// </summary>
        public static string LogOutput
        {
            get { return ConfigurationManager.AppSettings.Get("LogOutput"); }
        }

        /// <summary>
        /// Name of sender
        /// </summary>
        public static string Sender
        {
            get { return ConfigurationManager.AppSettings.Get("Sender"); }
        }

        /// <summary>
        /// Email address of sender
        /// </summary>
        public static string Username
        {
            get { return ConfigurationManager.AppSettings.Get("Username"); }
        }

        /// <summary>
        /// Password of sender
        /// </summary>
        public static string Password
        {
            get { return ConfigurationManager.AppSettings.Get("Password"); }
        }

        /// <summary>
        /// Email message contect subtype (text/SubType)
        /// </summary>
        public static string SubType
        {
            get { return ConfigurationManager.AppSettings.Get("SubType"); }
        }

        /// <summary>
        /// SMTP server hostname
        /// </summary>
        public static string Host
        {
            get { return ConfigurationManager.AppSettings.Get("Host"); }
        }

        /// <summary>
        /// SMTP server port
        /// </summary>
        public static int Port
        {
            get { return int.Parse(ConfigurationManager.AppSettings.Get("Port")); }
        }
    }
}