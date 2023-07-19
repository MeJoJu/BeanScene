namespace BeanScene2.Data.Services
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}