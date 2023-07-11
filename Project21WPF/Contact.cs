using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project21WPF
{
    public class Contact
    {
        public int ID { get; set; }
        public required string Surname { get; set; }
        public required string Name { get; set; }
        public required string FatherName { get; set; }
        public required string TelephoneNumber { get; set; }
        public required string ResidenceAdress { get; set; }
        public required string Description { get; set; }
    }
}
