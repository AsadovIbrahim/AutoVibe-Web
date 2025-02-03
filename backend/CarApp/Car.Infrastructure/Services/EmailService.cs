using System.Net;
using System.Net.Mail;
using Car.Application.Services;

namespace Car.Infrastructure.Services
{
    public class EmailService:IEmailService
    {
        public MailAddress to { get; set; }
        public MailMessage email { get; set; }
        public bool isHtml { get; set; } = true;
        public MailAddress from { get; set; } = new MailAddress("ibrahimasadov31@gmail.com");

        // Methods

        public async Task<bool> SendMailAsync(string mail, string title, string text, bool ishtml)
        {
            try
            {
                to = new MailAddress(mail);
                email = new MailMessage(from, to);
            }
            catch (Exception ex)
            {
                return false;
            }

            isHtml = ishtml;
            email.IsBodyHtml = isHtml;
            email.Subject = title;
            email.Body = text;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("ibrahimasadov31@gmail.com", "treq fglc dwmt nduj");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;

            try
            {
                await smtp.SendMailAsync(email);
            }
            catch (SmtpException ex)
            {
                return false;
            }
            return true;
        }
    }
}
