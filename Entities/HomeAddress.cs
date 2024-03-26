using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TF_Net2024_DemoEntity.Entities
{
    public class HomeAddress
    {
        public int HomeId { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }

        public IEnumerable<Person> Habitants { get; set; }
    }
}
