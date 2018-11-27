using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace azureDBhandin3_2.Models
{
    public class City
    {
        public long CityId { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string CityName { get; set; }
    }
}
