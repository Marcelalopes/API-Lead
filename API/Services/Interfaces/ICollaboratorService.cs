using System;
using System.Collections.Generic;
using API.Models;

namespace API.Services.Interfaces
{
    public interface ICollaboratorService
    {
        IEnumerable<Collaborator> GetAllActive();
        IEnumerable<Collaborator> GetAllDisable();
        Collaborator GetByCpf(string cpf);
        Collaborator GetByName(string name);
        Collaborator Add(Collaborator collaborator);
        void Update(Collaborator collaborator);
        Boolean Disable(string cpf);
        Boolean Reactivate(string cpf);
    }
}