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
        public Contract GetContract(Guid id)
        {
            return _contractRepository.GetContract(id);
        }
        public bool SaveContract(Contract contract)
        {
            return _contractRepository.SaveContract(contract);
        }
        public bool RemoveContract(Guid id)
        {
            return _contractRepository.RemoveContract(id);
        }
    }
}
