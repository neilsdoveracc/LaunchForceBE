using WebService.Entities;
using WebService.Interfaces;

namespace WebService.Managers
{
    public class ReqManager : IReqManager
    {
        private readonly IReqRepository _reqRepository;

        public ReqManager(IReqRepository reqRepository)
        {
            _reqRepository = reqRepository;
        }
        public Task<ResponseObject> CreateReq(ReqDTO req)
        {
            
        }
    }
}
