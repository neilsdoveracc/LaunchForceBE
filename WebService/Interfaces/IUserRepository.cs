using WebService.Entities;

namespace WebService.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> CreateUser(UserDTO user);
    }
}
