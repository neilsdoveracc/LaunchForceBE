using System.ComponentModel.DataAnnotations;
using System.Net;
using Webservice.Utils;
using WebService.Controllers;
using WebService.Entities;
using WebService.Interfaces;

namespace WebService.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        { 
            _userRepository = userRepository;
        }
        public async Task<ResponseObject> CreateUser(UserDTO user)
        {
            //_logger.LogInformation("CreateUser manager Start");
            user.UserId= HashUtil.GetUniqueId();
            if(user.IsNewUser)
            {
                user.Password= HashUtil.GetUniqueId();
            }
            var result = await _userRepository.CreateUser(user);
            if (result)
            {
                //_logger.LogInformation("CreateCompany manager - Success");
                return new ResponseObject(HttpStatusCode.Created, "User Created Successfully", "");
            }
            else
            {
                //_logger.LogInformation("CreateCompany manager - Failure");
                return new ResponseObject(HttpStatusCode.BadRequest, "User creation failed", null);
            }
        }
    }
}
