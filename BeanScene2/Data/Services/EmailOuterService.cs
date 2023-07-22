using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using BeanScene2.Data;
using BeanScene2.Models;

namespace BeanScene2.Services
{
    public class EmailOuterService
    {
        
            public EmailInnerService Inner { get; set; }

            // Constructor to establish link between
            // instance of Outer_class to its
            // instance of the Inner_class
            public EmailOuterService()
            {
                this.Inner = new EmailInnerService(this);
            }

            public class EmailInnerService
            {
               
                private EmailOuterService obj;
                public EmailInnerService()
                {
                   

                }
                public EmailInnerService(EmailOuterService outer)
                {

                    this.obj = outer;
                }

                public bool SendEmailConfirmation(string emailTo, String Lname, string userName, string password)
                {
                
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("joehuianfeihe@gmail.com"));
                email.To.Add(MailboxAddress.Parse(emailTo));
                email.Subject = "Registration Confirmation";
                email.Body = new TextPart(TextFormat.Plain) { Text = "Dear" + Lname + ",\n" + "You have successfully register to the RetailWebApp. \n Your user name: " + userName + " and password: " + password + "\n Kind Regards\n RetailWebApp Service Team" };

                // send email
                using var smtp = new MailKit.Net.Smtp.SmtpClient();
                //smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("joehuianfeihe@gmail.com", "zfvwbbemxudconas");
                smtp.Send(email);
                smtp.Disconnect(true);

                return true;
            }
                

            }
        
    }
}
