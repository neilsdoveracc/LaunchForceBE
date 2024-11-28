using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebService.Entities;
using WebService.Interfaces;
using Newtonsoft.Json;

namespace WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendorController : ControllerBase
    {

        private readonly ILogger<VendorController> _logger;
        private readonly IVendorManager _vendorManager;

        public VendorController(ILogger<VendorController> logger, IVendorManager vendorManager)
        {
            _logger = logger;
            _vendorManager = vendorManager;
        }

        [HttpPost]
        [Route("CreateVendor")]
        public async Task<IActionResult> CreateVendor([FromBody] object request)
        {
            try
            {
                _logger.LogInformation("CreateVendor Start");
                var _request = JsonConvert.DeserializeObject<VendorDTO>(request.ToString()); ;

                var result = _vendorManager.CreateVendor(_request);

                _logger.LogInformation("CreateVendor End");

                return StatusCode((int)result.Status, result);
            }
            catch (Exception ex)
            {
                _logger.LogError("End - Failed", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
        [HttpGet]
        [Route("GetVendor")]
        public async Task<IActionResult> GetVendor([FromBody] object request)
        {
            try
            {
                _logger.LogInformation("GetVendor Start");

                // Deserialize the request object to VendorDTO or whatever type is appropriate
                var _request = JsonConvert.DeserializeObject<VendorDTO>(request.ToString());

                // Assuming _vendorManager has a GetVendor method that takes the VendorDTO and returns vendor data
                var result = await _vendorManager.GetVendor(_request);

                _logger.LogInformation("GetVendor End");

                // Return the result as a response, with appropriate status code
                return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError("End - Failed", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.ToString());
            }

        }

    }
}