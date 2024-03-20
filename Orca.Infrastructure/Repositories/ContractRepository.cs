using System.Text.Json;
using Orca.Domain.Entities;
using Orca.Domain.Interfaces;
using StackExchange.Redis;

namespace Orca.Infrastructure.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly ConnectionMultiplexer _connectionMultiplexer;
        private readonly string connectionString = "OrcaPOC.redis.cache.windows.net:6380,password=VOhIaAj4jgyosQGXGGOYUgc41iQbdZyWoAzCaDkM0UE=,ssl=True,abortConnect=False";
        public ContractRepository()
        {
            _connectionMultiplexer = ConnectionMultiplexer.Connect(connectionString);
        }
        public async Task<Contract> GetContract(Guid id)
        {
            var db = _connectionMultiplexer.GetDatabase();
            var contract = await db.StringGetAsync(id.ToString());
            if (contract.IsNullOrEmpty)
            {
                return new Contract();
            }
            return JsonSerializer.Deserialize<Contract>(contract);
        }

        public async Task SaveContract(Contract contract)
        {
            var db = _connectionMultiplexer.GetDatabase();
            var contractToSave = JsonSerializer.Serialize(contract);
            await db.StringSetAsync(contract._id.ToString(), contractToSave);
        }
    }
}
