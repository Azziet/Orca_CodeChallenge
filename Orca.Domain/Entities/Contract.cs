using Newtonsoft.Json;

namespace Orca.Domain.Entities
{
    public partial class Contract
    {
        public Contract()
        {
            Products = new HashSet<Product>();
        }
        public Guid _id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
