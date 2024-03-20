using System.ComponentModel.DataAnnotations;
using Orca.Domain.Entities;

namespace Orca.API.DTOs
{
    public class AddContractRequest
    {
        [Required]
        public Guid _id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required]
        public virtual ICollection<Product> Products { get; set; }
    }
}
