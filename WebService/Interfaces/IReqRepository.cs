using WebService.Entities;

namespace WebService.Interfaces
{
    public interface IReqRepository
    {
        Task<bool> CreateReq(ReqDTO reqDTO);
    }
}
