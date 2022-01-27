using System.Collections;
using System.Collections.Generic;
using API.Models;

namespace API.Repository.Interfaces
{
    public interface ICollaboratorRepository
    {
        IEnumerable<Collaborator> GetAll();
        Collaborator SearchCpf(string cpf);
        Collaborator SearchName(string name);
        Collaborator Add(Collaborator collaborator);
        void Update(Collaborator collaborator);
    }
}