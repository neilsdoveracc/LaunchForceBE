using WebService.Entities;

namespace WebService.Interfaces
{
    public interface IReqManager
    {
        Task<ResponseObject> CreateReq(ReqDTO req);
    }
}
