using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Bookstore.IdentityApi.Configurations;
using Bookstore.IdentityApi.Interfaces;
using Bookstore.IdentityApi.Models;
using Microsoft.Extensions.Options;

namespace Bookstore.IdentityApi.Services
{
    public class NotificationService : INotificationService
    {
        private readonly NotifierOptions _notifierOptions;

        public NotificationService(IOptions<NotifierOptions> notifierOptions)
        {
            _notifierOptions = notifierOptions.Value;
        }

        public async Task<bool> SendEmailAsync(string body, string subject, string email)
        {
            var from = new MailAddress(_notifierOptions.From, _notifierOptions.Username);
            var to = new MailAddress(email);
            var mail = new MailMessage(from, to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            using var smtp = new SmtpClient(_notifierOptions.SmtpServer, _notifierOptions.Port);
            smtp.Credentials = new NetworkCredential(_notifierOptions.From, _notifierOptions.Password);
            smtp.EnableSsl = true;

            try
            {
                await smtp.SendMailAsync(mail);
            }
            catch (Exception ex)
            {
                throw new Exception("Errors occurred during sending." + string.Join("\n",ex.Message));               
            }

            return true;
        }

        public string CreateMessageAboutUserCreation(User user, string userPass)
        {
            var message = $"<h1>Dear, {user.FirstName} {user.LastName}!</h1>" +
                          "<h3>For authorization, use the following data:</h3>" +
                          "<ul>" +
                          $"<li><span>E-mail: {user.Email}</span></li>" +
                          $"<li><span>Password: {userPass}</span></li>" +
                          "</ul>" +
                          "<p>Welcome and have a day!</p>";
            return message;
        }
    }
}
