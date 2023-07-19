using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using System.Net.Mail;
using MailKit.Net.Smtp;
using BeanScene2.Data.Services;

namespace BeanScene2.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpPost]
        public IActionResult SendEmail(EmailDto request)
        {
            _emailService.SendEmail(request);

            //// create email message
            //var email = new MimeMessage();
            //email.From.Add(MailboxAddress.Parse("joehuianfeihe@gmail.com"));
            //email.To.Add(MailboxAddress.Parse("zhoujun418331@gmail.com"));
            //email.Subject = "Test Email Subject";
            //email.Body = new TextPart(TextFormat.Html) { Text = "<h1>Test Email Subject</h1>" };

            //// send email
            //using var smtp = new MailKit.Net.Smtp.SmtpClient();
            //smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            //smtp.Authenticate("joehuianfeihe@gmail.com", "!bean123456");
            //smtp.Send(email);
            //smtp.Disconnect(true);

          
            return Content("Email sent successfully!");

        }
    }
}
