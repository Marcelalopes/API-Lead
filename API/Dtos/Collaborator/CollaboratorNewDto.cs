using System;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Collaborator
{
    public class CollaboratorNewDto
    {
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(length: 11, ErrorMessage = "O tamanho máximo é 11")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(length: 50, ErrorMessage = "O tamanho máximo é 50")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(length: 2, ErrorMessage = "O tamanho máximo é 2")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(length: 14, ErrorMessage = "O tamanho máximo é 14")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        public Guid AddressId { get; set; }
    }
}