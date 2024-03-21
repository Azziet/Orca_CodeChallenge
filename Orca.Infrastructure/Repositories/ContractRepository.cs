using Orca.Domain.Entities;
using Orca.Domain.Interfaces;

namespace Orca.Infrastructure.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly IRedisCache _redisCache;
        public ContractRepository(IRedisCache redisCache)
        {
            _redisCache = redisCache;
        }
        public Contract GetContract(Guid id)
        {
            return _redisCache.GetCacheData<Contract>(id.ToString());
        }

        public bool SaveContract(Contract contract)
        {
           return _redisCache.SetCacheData(contract._id.ToString(), contract);
        }

        public bool RemoveContract(Guid id)
        {
            return _redisCache.RemoveData(id.ToString());
        }
}
}
