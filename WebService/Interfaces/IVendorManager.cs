using WebService.Entities;

namespace WebService.Interfaces
{
    public interface IVendorManager
    {
        Task<ResponseObject> CreateVendor(VendorDTO vendor);
        Task<ResponseObject> GetVendor();
    }
}
