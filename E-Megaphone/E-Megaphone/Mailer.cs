using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Collections.Generic;

namespace E_Megaphone
{
    class Mailer
    {
        public void Send(string subject, string text, Dictionary<string, string> recipients)
        {
            MimeMessage message = new MimeMessage
            {
                Subject = subject,
                Body = new TextPart(Config.SubType)
                {
                    Text = text
                }
            };

            message.From.Add(new MailboxAddress(Config.Sender, Config.Username));
            foreach (KeyValuePair<string, string> recipient in recipients)
            {
                message.To.Add(new MailboxAddress(recipient.Value, recipient.Key));
            }

            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Connect(Config.Host, Config.Port, SecureSocketOptions.StartTls);
                smtpClient.Authenticate(Config.Username, Config.Password);
                smtpClient.Send(message);
                smtpClient.Disconnect(true);
            }
        }
    }
}
