using System;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Collaborator
{
    public class CollaboratorNewDto
    {
        /// <summary> string: Primary Key </summary>
        /// <example> 06468786380 </example>
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(length: 11, ErrorMessage = "O tamanho máximo é 11")]
        public string CPF { get; set; }

        /// <summary> string: Nome do colaborador </summary>
        /// <example> Marcela dos Santos Lopes </example>
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(length: 50, ErrorMessage = "O tamanho máximo é 50")]
        public string Name { get; set; }

        /// <summary> DateTime: Data de nascimento do colaborador </summary>
        /// <example> 2002-07-09T00:00:00.793Z </example>
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public DateTime BirthDate { get; set; }

        /// <summary> string: Sexo do colaborador </summary>
        /// <example> F </example>
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(length: 2, ErrorMessage = "O tamanho máximo é 2")]
        public string Gender { get; set; }

        /// <summary> string: Número do colaborador </summary>
        /// <example> 86981425287 </example>
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(length: 14, ErrorMessage = "O tamanho máximo é 14")]
        public string Phone { get; set; }

        /// <summary> Guid: Id do endereço do colaborador </summary>
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public Guid AddressId { get; set; }
    }
}