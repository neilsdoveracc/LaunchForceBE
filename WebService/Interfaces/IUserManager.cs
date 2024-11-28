using WebService.Entities;

namespace WebService.Interfaces
{
    public interface IUserManager
    {
        Task<HttpResponse> CreateUser(UserDTO user);
    }
}
