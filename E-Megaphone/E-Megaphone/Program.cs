using System;
using System.Collections.Generic;

namespace E_Megaphone
{
    /// <summary>
    /// Main class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">
        /// 0 - Subject
        /// 1 - Body
        /// n + 2 - Recipient n email address
        /// n + 3 - Recipient n display name
        /// </param>
        /// <returns>
        /// 0 - Success
        /// -1 - Failure
        /// -2 - Missing arguments
        /// </returns>
        static int Main(string[] args)
        {
            // Create variables
            Logger logger = new Logger();
            int retVal = 0;
            try
            {
                // Check arguments
                if (args.Length >= 4 && args.Length % 2 == 0)
                {
                    // Get subject
                    string subject = args[0];
                    logger.Add($"Subject: {subject}");

                    // Get body
                    string body = args[1];
                    logger.Add($"Body: {body}");

                    // Get recipients
                    Dictionary<string, string> recipients = new Dictionary<string, string>();
                    for (int i = 2; i < args.Length; i += 2)
                    {
                        recipients.Add(args[i], args[i + 1]);
                        logger.Add($"Added Recipient: {args[i]} - {args[i + 1]}");
                    }

                    // Send email
                    Mailer mailer = new Mailer();
                    mailer.Send(logger, subject, body, recipients);
                }
                else
                {
                    // Log error
                    logger.Add("Requires at least 4 and an even number of command line arguments");
                    retVal = -2;
                }
            }
            catch (Exception ex)
            {
                // Log error
                logger.Add(ex.Message);
                retVal = -1;
            }

            // Save messages and return status code
            logger.Save();
            return retVal;
        }
    }
}