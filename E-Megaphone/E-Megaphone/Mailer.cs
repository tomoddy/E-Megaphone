using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;

namespace E_Megaphone
{
    /// <summary>
    /// Mailer class used to send emails
    /// </summary>
    class Mailer
    {
        /// <summary>
        /// Send email
        /// </summary>
        /// <param name="logger">Logging object</param>
        /// <param name="subject">Email subject</param>
        /// <param name="text">Email body</param>
        /// <param name="recipients">Dictionary of recipients (email key and name value)</param>
        public void Send(Logger logger, string subject, string text, Dictionary<string, string> recipients)
        {
            // Create email with subject and body
            MimeMessage message = new MimeMessage
            {
                Subject = subject,
                Body = new TextPart(Config.SubType)
                {
                    Text = text
                }
            };
            logger.Add("Message created");

            // Add sender information
            message.From.Add(new MailboxAddress(Config.Sender, Config.Username));

            // Add receipients
            foreach (KeyValuePair<string, string> recipient in recipients)
            {
                message.To.Add(new MailboxAddress(recipient.Value, recipient.Key));
            }

            // Create smtp client
            using (SmtpClient smtpClient = new SmtpClient())
            {
                // Connect to server and authenticate
                smtpClient.Connect(Config.Host, Config.Port, SecureSocketOptions.StartTls);
                smtpClient.Authenticate(Config.Username, Config.Password);
                logger.Add("Connected and authenticated to SMTP server");

                // Send message and disconnect from server
                smtpClient.Send(message);
                smtpClient.Disconnect(true);
                logger.Add("Message sent and disconnected from SMTP");
            }
        }
    }
}
