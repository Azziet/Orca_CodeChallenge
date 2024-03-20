using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orca.Domain.Entities
{
    public class Product
    {
        public Product()
        {
            Elements = new HashSet<Element>();
        }
        public Guid _id { get; set; }
        public virtual ICollection<Element> Elements { get; set; }
    }
}
