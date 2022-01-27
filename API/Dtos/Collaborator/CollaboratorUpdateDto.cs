using System;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Collaborator
{
    public class CollaboratorUpdateDto
    {
        [MaxLength(length: 50, ErrorMessage = "O tamanho máximo é 50")]
        public string Name { get; set; }

        [MaxLength(length: 2, ErrorMessage = "O tamanho máximo é 2")]
        public string Gender { get; set; }

        [MaxLength(length: 14, ErrorMessage = "O tamanho máximo é 14")]
        public string Phone { get; set; }
        public Guid? AddressId { get; set; }
    }
}