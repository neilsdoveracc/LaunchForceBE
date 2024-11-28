using System.Net;
using Webservice.Utils;
using WebService.Entities;
using WebService.Interfaces;
using WebService.Repositories;

namespace WebService.Managers
{
    public class VendorManager : IVendorManager
    {
        private readonly IVendorRepository _vendorRepository;

        public VendorManager (IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }

        public async Task<ResponseObject> CreateVendor(VendorDTO vendor)
        {
            vendor.VendorId = HashUtil.GetUniqueId();
            var result = await _vendorRepository.CreateVendor(vendor);
            if (result)
            {
                //_logger.LogInformation("CreateCompany manager - Success");
                return new ResponseObject(HttpStatusCode.Created, "Vendor Created Successfully", "");
            }
            else
            {
                //_logger.LogInformation("CreateCompany manager - Failure");
                return new ResponseObject(HttpStatusCode.BadRequest, "Vendor creation failed", null);
            }
            throw new NotImplementedException();
        }

        public async Task<ResponseObject> GetVendor()
        {
            try
            {
                // Try to fetch the vendor from the repository using the provided vendor info (e.g., VendorId)
                var result = await _vendorRepository.GetVendorList();  // Adjust if needed

                if (result != null)
                {
                    // Return a success response if vendor is found
                    return new ResponseObject(HttpStatusCode.OK, "Vendor found", result);
                }
                else
                {
                    // Return a not found response if vendor does not exist
                    return new ResponseObject(HttpStatusCode.NotFound, "Vendor not found", null);
                }
            }
            catch (Exception ex)
            {
                // Log the error if something goes wrong
                //_logger.LogError("Error retrieving vendor", ex);
                return new ResponseObject(HttpStatusCode.InternalServerError, "An error occurred", null);
            }
        }
    }
}
