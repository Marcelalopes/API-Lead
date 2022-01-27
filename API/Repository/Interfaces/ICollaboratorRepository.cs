using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using API.Models;

namespace API.Repository.Interfaces
{
    public interface ICollaboratorRepository
    {
        Task<IEnumerable<Collaborator>> GetAll();
        Task<Collaborator> SearchCpf(string cpf);
        Task<Collaborator> SearchName(string name);
        Task<Collaborator> Add(Collaborator collaborator);
        Task<Boolean> Update(Collaborator collaborator);
    }
}