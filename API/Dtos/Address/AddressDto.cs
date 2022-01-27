using System;

namespace API.Dtos.Address
{
    public class AddressDto
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Boolean isActive {get;set;}
    }
}