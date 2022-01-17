using System.Threading.Tasks;
using Bookstore.IdentityApi.Models;

namespace Bookstore.IdentityApi.Interfaces
{
    public interface INotificationService
    {
        public Task<bool> SendEmailAsync(string body, string subject, string email);
        public string CreateMessageAboutUserCreation(User user, string userPass);
    }
}
