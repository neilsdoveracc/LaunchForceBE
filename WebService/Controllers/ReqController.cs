using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebService.Entities;
using WebService.Interfaces;
using Newtonsoft.Json;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReqController : ControllerBase
    {

        //private readonly ILogger<UserController> _logger;
        private readonly IReqManager _reqManager;

        public ReqController(IReqManager reqmanager)
        {
            //_logger = logger;
            _reqManager = reqmanager;
        }

        [HttpPost]
        [Route("CreateReq")]
        public async Task<IActionResult> CreateReq([FromBody] object request)
        {
            try
            {
                //_logger.LogInformation("CreateCompany Start");
                var _request = JsonConvert.DeserializeObject<ReqDTO>(request.ToString()); ;

                var result = await _reqManager.CreateReq(_request);

                //_logger.LogInformation("CreateCompany End");

                return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception ex)
            {
                //_logger.LogError("End - Failed", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
    }
}