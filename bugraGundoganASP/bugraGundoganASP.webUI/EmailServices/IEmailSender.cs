using System.Threading.Tasks;

namespace bugraGundoganASP.webUI.EmailServices
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}