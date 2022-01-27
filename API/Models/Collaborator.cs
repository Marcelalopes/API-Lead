using System;

namespace API.Models
{
    public class Collaborator
    {
        public string CPF { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public Boolean isActive {get;set;}
        public Address Address { get; set; }
        public Guid AddressId { get; set; }
    }
}