using System;
using System.Collections.Generic;
using API.Dtos.Collaborator;
using API.Models;

namespace API.Services.Interfaces
{
    public interface ICollaboratorService
    {
        IEnumerable<CollaboratorDto> GetAllActive();
        IEnumerable<CollaboratorDto> GetAllDisable();
        CollaboratorDto GetByCpf(string cpf);
        CollaboratorDto GetByName(string name);
        CollaboratorNewDto Add(CollaboratorNewDto collaborator);
        void Update(CollaboratorUpdateDto collaborator);
        Boolean Disable(string cpf);
        Boolean Reactivate(string cpf);
    }
}