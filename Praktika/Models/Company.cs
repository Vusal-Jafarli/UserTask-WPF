using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika.Models
{
    public class Company
    {
        public string? name { get; set; }
        public string? bs { get; set; }

        public Company(string? name, string? bs)
        {
            this.name = name;
            this.bs = bs;
        }
        public Company()
        {
            
        }
    }

}
