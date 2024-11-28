using WebService.Entities;

namespace WebService.Interfaces
{
    public interface IUserManager
    {
        Task<ResponseObject> CreateUser(UserDTO user);
    }
}
