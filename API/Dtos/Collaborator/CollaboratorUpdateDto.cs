using System;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Collaborator
{
    public class CollaboratorUpdateDto
    {
        /// <summary> string: Nome do colaborador </summary>
        /// <example> Marcela dos Santos Lopes </example>
        [MaxLength(length: 50, ErrorMessage = "O tamanho máximo é 50")]
        public string Name { get; set; }

        /// <summary> string: Sexo do colaborador </summary>
        /// <example> F </example>
        [MaxLength(length: 2, ErrorMessage = "O tamanho máximo é 2")]
        public string Gender { get; set; }

        /// <summary> string: Número do colaborador </summary>
        /// <example> 86981425287 </example>
        [MaxLength(length: 14, ErrorMessage = "O tamanho máximo é 14")]
        public string Phone { get; set; }

        /// <summary> Guid: Id do endereço do colaborador </summary>
        public Guid? AddressId { get; set; }
    }
}