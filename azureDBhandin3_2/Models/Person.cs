using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace azureDBhandin3_2.Models
{
    public class Person
    {
        public long PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public ICollection<Address> Address { get; set; }
        public ICollection<Email> Email { get; set; }
    }



   
}
