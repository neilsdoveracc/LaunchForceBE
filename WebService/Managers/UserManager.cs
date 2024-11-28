using WebService.Entities;
using WebService.Interfaces;

namespace WebService.Managers
{
    public class UserManager : IUserManager
    {
        public Task<HttpResponse> CreateUser(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
