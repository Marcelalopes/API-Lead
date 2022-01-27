using System;

namespace API.Models
{
    /// <summary> Objeto que representa os dados de um colaborador </summary>
    public class Collaborator
    {
        /// <summary> string: Primary Key </summary>
        /// <example> 06468786380 </example>
        public string CPF { get; set; }

        /// <summary> string: Nome do colaborador </summary>
        /// <example> Marcela dos Santos Lopes </example>
        public string Name { get; set; }

        /// <summary> DateTime: Data de nascimento do colaborador </summary>
        /// <example> 2002-07-09T00:00:00.793Z </example>
        public DateTime BirthDate { get; set; }

        /// <summary> string: Sexo do colaborador </summary>
        /// <example> F </example>
        public string Gender { get; set; }

        /// <summary> string: Número do colaborador </summary>
        /// <example> 86981425287 </example>
        public string Phone { get; set; }

        /// <summary> Boolean: variável de desativação do colaborador </summary>
        /// <example> true </example>
        public Boolean isActive {get;set;} = true;

        /// <summary> Address: Objeto de endereço </summary>
        public Address Address { get; set; }

        /// <summary> Guid: Id do endereço do colaborador </summary>
        public Guid AddressId { get; set; }
    }
}