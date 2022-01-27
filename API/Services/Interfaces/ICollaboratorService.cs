using System;
using System.Collections.Generic;
using API.Dtos.Collaborator;
using API.Models;

namespace API.Services.Interfaces
{
    public interface ICollaboratorService
    {
        IEnumerable<Collaborator> GetAllActive();
        IEnumerable<Collaborator> GetAllDisable();
        Collaborator GetByCpf(string cpf);
        Collaborator GetByName(string name);
        CollaboratorNewDto Add(CollaboratorNewDto collaborator);
        void Update(CollaboratorUpdateDto collaborator);
        Boolean Disable(string cpf);
        Boolean Reactivate(string cpf);
    }
}