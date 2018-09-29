using System.Threading.Tasks;

namespace SecurityWebsite.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}