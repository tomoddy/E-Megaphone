using System.Collections.Generic;

namespace E_Megaphone
{
    class Program
    {
        static void Main()
        { 
            Dictionary<string, string> recipients = new Dictionary<string, string>
            {
                { "test@emailsim.io", "Test Receipient" }
            };

            Mailer mailer = new Mailer();
            mailer.Send("Test Subject", "Test Body", recipients);
        }
    }
}