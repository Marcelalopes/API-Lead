using System;

namespace API.Dtos.Collaborator
{
    public class CollaboratorUpdateDto
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public Guid? AddressId { get; set; }
    }
}