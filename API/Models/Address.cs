using System;
using System.Collections.Generic;

namespace API.Models
{
    /// <summary> Objeto que representa os dados de um endereço </summary>
    public class Address
    {
        public Address()
        {
            Id = new Guid();
        }

        /// <summary> Guid: Primary Key </summary>
        public Guid Id { get; set; }

        /// <summary> string: Nome da rua </summary>
        /// <example> Rua Projetada 1 </example>
        public string Street { get; set; }

        /// <summary> string: Numero da rua </summary>
        /// <example> 5B </example>
        public string Number { get; set; }

        /// <summary> string: Nome do bairro </summary>
        /// <example> Villa </example>
        public string District { get; set; }

        /// <summary> string: Nome da cidade </summary>
        /// <example> Pedro II </example>
        public string City { get; set; }

        /// <summary> string: Nome do estado </summary>
        /// <example> PI </example>
        public string State { get; set; }

        /// <summary> Boolean: variável de desativação do endereço </summary>
        /// <example> true </example>
        public Boolean isActive {get;set;} = true;

        /// <summary> List: Lista de colaboradores residentes do endereço </summary>
        public List<Collaborator> Collaborator { get; set; }
    }
}