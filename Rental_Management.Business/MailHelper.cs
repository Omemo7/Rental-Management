using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net;
using MailKit.Net.Smtp;
using MailKit.Security;
using MailKit;
using MimeKit;
using Microsoft.Identity.Client;
namespace Rental_Management.Business
{
    public class MailHelper
    {
        public static async Task SendMailAsync(string toEmail,string subject,string content)
        {
            var email = new MimeMessage();
            //todo change email from
            email.From.Add(MailboxAddress.Parse("omarabuhadhoud7@gmail.com"));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = subject;
            email.Body = new TextPart("html")
            {
                Text = content
            };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            //todo change email password
            await smtp.AuthenticateAsync("omarabuhadhoud7@gmail.com", "X_omemo7@910");
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
