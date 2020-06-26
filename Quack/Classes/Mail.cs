using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Quack.Classes
{
    public class Mail
    {
        public static bool SendMail(string email, string subject, string messageText)
        {
            MailMessage message = new MailMessage(email, "kijolakijek3@gmail.com")
            {
                From = new MailAddress(email, email),
                Subject = subject,
                Body = messageText
            };
            SmtpClient client = new SmtpClient("smtp.gmail.com")
            {
                UseDefaultCredentials = false,
                EnableSsl = true,
                Credentials = new System.Net.NetworkCredential("clothesland2@gmail.com", "mamatata1")
            };
            try
            {
                client.Send(message);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}