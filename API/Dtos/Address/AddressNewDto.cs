using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Address
{
    public class AddressNewDto
    {
        /// <summary> string: Nome da rua </summary>
        /// <example> Rua Projetada 1 </example>
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(length: 50, ErrorMessage = "O tamanho máximo é 50")]
        public string Street { get; set; }

        /// <summary> string: Numero da rua </summary>
        /// <example> 5B </example>
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(length: 10, ErrorMessage = "O tamanho máximo é 10")]
        public string Number { get; set; }

        /// <summary> string: Nome do bairro </summary>
        /// <example> Villa </example>
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(length: 50, ErrorMessage = "O tamanho máximo é 50")]
        public string District { get; set; }

        /// <summary> string: Nome da cidade </summary>
        /// <example> Pedro II </example>
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(length: 50, ErrorMessage = "O tamanho máximo é 50")]
        public string City { get; set; }

        /// <summary> string: Nome do estado </summary>
        /// <example> PI </example>
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(length: 3, ErrorMessage = "O tamanho máximo é 3")]
        public string State { get; set; }
    }
}