using System;

namespace API.Dtos.Collaborator
{
    public class CollaboratorNewDto
    {
        public string CPF { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public Guid AddressId { get; set; }
    }
}