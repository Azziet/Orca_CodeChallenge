using Orca.Domain.Entities;
using Orca.Domain.Interfaces;

namespace Orca.API.Services
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;
        public ContractService(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }
        public async Task<Contract> GetContract(Guid id)
        {
            return await _contractRepository.GetContract(id);
        }
        public async Task SaveContract(Contract contract)
        {
            await _contractRepository.SaveContract(contract);
        }
    }
}
