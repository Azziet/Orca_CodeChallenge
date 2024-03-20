using Orca.Domain.Entities;

namespace Orca.Domain.Interfaces
{
    public interface IContractService
    {
        Task<Contract> GetContract(Guid id);
        Task SaveContract(Contract contract);
    }
}
