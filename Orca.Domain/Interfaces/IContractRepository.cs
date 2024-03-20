using Orca.Domain.Entities;

namespace Orca.Domain.Interfaces
{
    public interface IContractRepository
    {
        Task<Contract> GetContract(Guid id);
        Task SaveContract(Contract contract);
    }
}
