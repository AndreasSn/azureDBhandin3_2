using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace azureDBhandin3_2.Models
{
    public class Address
    {
        public long AddressId { get; set; }
        public long CityId { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }

        public City City { get; set; }
        public ICollection<Person> Person { get; set; }
    }
}
