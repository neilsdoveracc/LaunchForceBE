using WebService.Entities;

namespace WebService.Interfaces
{
    public interface IVendorRepository
    {
        Task<bool> CreateVendor(VendorDTO vendor);
        Task<List<VendorDTO>> GetVendorList();
    }
}
