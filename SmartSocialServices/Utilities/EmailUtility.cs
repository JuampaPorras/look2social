using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SmartSocialServices.Utilities
{
    public static class EmailUtility
    {
        public static bool SendEmail(MailMessage mailMessage) {
            try {
                // Command line argument must the the SMTP host.
                SmtpClient client = new SmtpClient();
                client.Port = 26;
                client.Host = "mail.appverified.com";
                client.EnableSsl = false;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(Resource.NoReplyEmail, Resource.NoReplyPassword);
                client.Send(mailMessage);
            }
            catch(Exception ex) {
                Console.Write(ex.Message);
                return false;
            }
            
            return true;
        }
    }
}
