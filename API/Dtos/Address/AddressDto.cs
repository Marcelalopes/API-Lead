using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Address
{
    public class AddressDto
    {
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(length: 50, ErrorMessage = "O tamanho máximo é 50")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(length: 10, ErrorMessage = "O tamanho máximo é 10")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(length: 50, ErrorMessage = "O tamanho máximo é 50")]
        public string District { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(length: 45, ErrorMessage = "O tamanho máximo é 50")]
        public string City { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(length: 3, ErrorMessage = "O tamanho máximo é 3")]
        public string State { get; set; }

        [DefaultValueAttribute(true)]
        public Boolean isActive { get; set; }
    }
}