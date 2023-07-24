using ContactManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagementSystem.Entities
{
    public class ContactEntity 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }   
        public string Phone { get; set; }
    }
}
