using System.Net.Mail;

namespace Car.Application.Services
{
    public interface IEmailService
    {
        public bool isHtml { get; set; }
        public MailAddress to { get; set; }
        public MailMessage email { get; set; }
        public MailAddress from { get; set; }


        public Task<bool> SendMailAsync(string mail, string title, string text, bool ishtml);
    }
}
