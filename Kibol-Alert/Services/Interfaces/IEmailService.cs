using System.Threading.Tasks;

namespace Kibol_Alert.Services.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
