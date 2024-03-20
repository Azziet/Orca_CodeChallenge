using Orca.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Orca.API.DTOs
{
    public class AddContractResponse
    {
        public Guid _id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
