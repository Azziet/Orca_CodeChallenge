using Orca.Domain.Entities;

namespace Orca.Domain.Interfaces
{
    public interface IContractService
    {
        Contract GetContract(Guid id);
        bool SaveContract(Contract contract);
        bool RemoveContract(Guid id);
    }
}
