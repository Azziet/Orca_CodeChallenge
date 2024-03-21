using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Orca.Domain.Entities
{
    public class Element
    {
        public string _t { get; set; }
        public string? Fee { get; set; }
        public double? Price { get; set; }
    }
}
