using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Praktika.Models
{
    public class Address
    {
        public string? street { get; set; }
        public string? city { get; set; }


        public Address(string? street,string? city) 
        {
            this.street = street;
            this.city = city;
        }
        public Address()
        {
            
        }

        public override string ToString()
        {
            return $"{city},{street}";
        }
    }
}
