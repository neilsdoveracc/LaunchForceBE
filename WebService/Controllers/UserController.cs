using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebService.Entities;
using WebService.Interfaces;
using Newtonsoft.Json;

namespace WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IUserManager _userManager;

        public UserController(ILogger<UserController> logger, IUserManager userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateCompany([FromBody] object request)
        {
            try
            {
                _logger.LogInformation("CreateCompany Start");
                var _request = JsonConvert.DeserializeObject<UserDTO>(request.ToString()); ;

                var result = _userManager.CreateUser(_request);

                _logger.LogInformation("CreateCompany End");

                return StatusCode((int)result.Status, result);
            }
            catch (Exception ex)
            {
                _logger.LogError("End - Failed", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError,ex.ToString());
            }
        }
    }
}