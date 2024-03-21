using Orca.Domain.Entities;

namespace Orca.Domain.Interfaces
{
    public interface IContractRepository
    {
        Contract GetContract(Guid id);
        bool SaveContract(Contract contract);
        bool RemoveContract(Guid id);
    }
}
