using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace azureDBhandin3_2.Models
{
    public class Email
    {
        public long EmailId { get; set; }
        public long PersonId { get; set; }
        public string EmailAddress { get; set; }

        public Person Person { get; set; }
    }
}
