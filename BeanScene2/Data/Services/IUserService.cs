using BeanScene2.Models;

namespace BeanScene2.Services
{
    public interface IUserService
    {
        Task<Status> RegisterAsync(RegisterModel model);
        Task<Status> LoginAsync(LoginModel model);
        Task LogoutAsync();
     //   Task<Status> ChangePasswordAsync(ChangePasswordModel model, string username);
    }
}
