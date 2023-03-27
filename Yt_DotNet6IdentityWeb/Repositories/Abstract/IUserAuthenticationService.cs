using Yt_DotNet6IdentityWeb.Models.DTO;

namespace Yt_DotNet6IdentityWeb.Repositories.Abstract
{
    public interface IUserAuthenticationService
    {
        Task<Status> LoginAsync(LoginModel model);
        Task<Status> RegistrationAsync(RegistrationModel model);
        Task LogoutAsync();
    }
}
