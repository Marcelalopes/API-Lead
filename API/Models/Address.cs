using System;
using System.Collections.Generic;

namespace API.Models
{
    public class Address
    {
        public Address()
        {
            Id = new Guid();
        }
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Boolean isActive {get;set;}
        public List<Collaborator> Collaborator { get; set; }
    }
}